using QOBDCommon.Entities;
using QOBDCommon.Interfaces.DAC;
using QOBDGateway.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Concurrent;
using QOBDCommon.Classes;
using QOBDCommon.Enum;
using QOBDGateway.Classes;
using QOBDGateway.Interfaces;
using QOBDGateway.Abstracts;
using QOBDDAL.Helper.ChannelHelper;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDDAL.Core
{
    public class DALReferential : IReferentialManager
    {
        private QOBDCommon.Interfaces.REMOTE.IReferentialManager _gateWayReferential;
        private ClientProxy _servicePortType;
        private bool _isLodingDataFromWebServiceToLocal;
        private int _loadSize;
        private object _lock = new object();
        private int _progressStep;
        private Func<double, double> _progressBarFunc;
        private Interfaces.IQOBDSet _dataSet;
        private ICommunication _serviceCommunication;

        public event PropertyChangedEventHandler PropertyChanged;

        public Agent AuthenticatedUser { get; set; }


        public DALReferential(ClientProxy servicePort)
        {
            _servicePortType = servicePort;
            _gateWayReferential = new GateWayReferential(_servicePortType);
            _loadSize = Utility.intTryParse(ConfigurationManager.AppSettings["load_size"]);
            _progressStep = Utility.intTryParse(ConfigurationManager.AppSettings["progress_step"]);            
        }

        public DALReferential(ClientProxy servicePort, Interfaces.IQOBDSet _dataSet) : this(servicePort)
        {
            this._dataSet = _dataSet;
        }

        public DALReferential(ClientProxy servicePort, Interfaces.IQOBDSet _dataSet, ICommunication serviceCommunication) : this(servicePort, _dataSet)
        {
            _serviceCommunication = serviceCommunication;
        }

        public bool IsDataDownloading
        {
            get { return _isLodingDataFromWebServiceToLocal; }
            set { _isLodingDataFromWebServiceToLocal = value; onPropertyChange("IsDataDownloading"); }
        }

        public void initializeCredential(Agent user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.HashedPassword))
            {
                AuthenticatedUser = user;
                _gateWayReferential.setServiceCredential(_servicePortType);                
            }
        }

        public async void cacheWebServiceData()
        {
            try
            {
                await DALHelper.doAction(retrieveGateWayReferentialDataAsync, TimeSpan.FromSeconds(1), 0, new List<Exception>(), 3);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.REFERENTIAL); }
        }

        public void setServiceCredential(object channel)
        {
            _servicePortType = (ClientProxy)channel;
            if (AuthenticatedUser != null && string.IsNullOrEmpty(_servicePortType.ClientCredentials.UserName.Password) && string.IsNullOrEmpty(_servicePortType.ClientCredentials.UserName.Password))
            {
                _servicePortType.ClientCredentials.UserName.UserName = "none";
                _servicePortType.ClientCredentials.UserName.Password = AuthenticatedUser.WebServiceCredential;
            }
            _gateWayReferential.setServiceCredential(_servicePortType);
        }

        public void setCompanyName(string companyName)
        {
            _gateWayReferential.setCompanyName(companyName);
        }

        private async Task retrieveGateWayReferentialDataAsync()
        {
            object _lock = new object();

            lock (_lock) IsDataDownloading = true;
            try
            {
                ConcurrentBag<Info> infosList = new ConcurrentBag<Info>(await _gateWayReferential.GetInfoDataAsync(_loadSize));
                List<Info> savedInfosList = LoadInfos(infosList.ToList());

                try { _progressBarFunc((double)100 / _progressStep); }
                catch (DivideByZeroException ex) { Log.error(ex.Message, EErrorFrom.REFERENTIAL); }
            }
            catch (Exception) { throw; }
            finally { lock (_lock) IsDataDownloading = false; }
        }

        public void progressBarManagement(Func<double, double> progressBarFunc)
        {
            _progressBarFunc = progressBarFunc;
        }

        public void onPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void checkServiceCommunication()
        {
            _serviceCommunication.checkServiceCommunication(_servicePortType);
        }



        #region [ Actions ]
        //=================================[ Actions ]================================================

        public async Task<List<Info>> InsertInfoAsync(List<Info> listInfos)
        {
            List<Info> result = new List<Info>();
            checkServiceCommunication();
            List<Info> gateWayResultList = await _gateWayReferential.InsertInfoAsync(listInfos);                
                result = LoadInfos(gateWayResultList);
            return result;
        }

        public async Task<List<Info>> DeleteInfoAsync(List<Info> listInfos)
        {
            List<Info> result = new List<Info>();
            checkServiceCommunication();
            List<Info> gateWayResultList = await _gateWayReferential.DeleteInfoAsync(listInfos);
                if (gateWayResultList.Count == 0)
                {
                    foreach (Info infos in listInfos)
                    {
                        int returnValue = _dataSet.DeleteInfo(infos.ID);
                        if (returnValue > 0)
                            result.Add(infos);
                    }
                }
            return result;
        }
        
        public async Task<List<Info>> UpdateInfoAsync(List<Info> infoList)
        {
            checkServiceCommunication();
            List<Info> gateWayResultList = await _gateWayReferential.UpdateInfoAsync(infoList);
            List<Info> result = LoadInfos(gateWayResultList);

            return result;
        }

        public List<Info> LoadInfos(List<Info> infoList)
        {
            List<Info> result = new List<Info>();
            foreach (var Info in infoList)
                {
                    int returnValue = _dataSet.LoadInfo(Info);
                    if (returnValue > 0)
                        result.Add(Info);
                }
            return result;
        }

        public List<Info> GetInfoData(int nbLine)
        {
            List<Info> result =_dataSet.GetInfosData();
            if (nbLine.Equals(999) || result.Count == 0|| result.Count < nbLine)
                return result;
            return result.GetRange(0, nbLine);
        }

        public async Task<List<Info>> GetInfoDataAsync(int nbLine)
        {
            checkServiceCommunication();
            return await _gateWayReferential.GetInfoDataAsync(nbLine);
        }

        public List<Info> GetInfosDataById(int id)
        {
            return _dataSet.GetInfosDataById(id);
        }

        public List<Info> searchInfo(Info Info, ESearchOption filterOperator)
        {
            return _dataSet.searchInfo(Info, filterOperator);
        }

        public async Task<List<Info>> searchInfoAsync(Info Infos, ESearchOption filterOperator)
        {
            checkServiceCommunication();
            return await _gateWayReferential.searchInfoAsync(Infos, filterOperator);
        }
        #endregion

        public void Dispose()
        {
            if (_gateWayReferential != null)
                _gateWayReferential.Dispose();
        }
    } /* end class BlReferential */
}