using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDCommon.Enum;
using QOBDCommon.Interfaces.DAC;
using QOBDGateway.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Threading.Tasks;
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
    public class DALStatisitc : IStatisticManager
    {
        public Agent AuthenticatedUser { get; set; }
        private QOBDCommon.Interfaces.REMOTE.IStatisticManager _gateWayStatistic;
        private ClientProxy _servicePortType;
        private bool _isLodingDataFromWebServiceToLocal;
        private int _loadSize;
        private int _progressStep;
        private Func<double, double> _progressBarFunc;
        private object _lock;
        private Interfaces.IQOBDSet _dataSet;
        private ICommunication _serviceCommunication;

        public event PropertyChangedEventHandler PropertyChanged;

        public DALStatisitc(ClientProxy servicePort)
        {
            _lock = new object();
            _servicePortType = servicePort;
            _gateWayStatistic = new GateWayStatistic(_servicePortType);
            _loadSize = Utility.intTryParse(ConfigurationManager.AppSettings["load_size"]);
            _progressStep = Utility.intTryParse(ConfigurationManager.AppSettings["progress_step"]);
        }

        public DALStatisitc(ClientProxy servicePort, Interfaces.IQOBDSet _dataSet) : this(servicePort)
        {
            this._dataSet = _dataSet;
        }

        public DALStatisitc(ClientProxy servicePort, Interfaces.IQOBDSet _dataSet, ICommunication serviceCommunication) : this(servicePort, _dataSet)
        {
            _serviceCommunication = serviceCommunication;
        }

        public void initializeCredential(Agent user)
        {
            AuthenticatedUser = user;
            _gateWayStatistic.setServiceCredential(_servicePortType);
        }

        public async void cacheWebServiceData()
        {
            try
            {
                await DALHelper.doAction(retrieveGateWayStatisticDataAsync, TimeSpan.FromSeconds(1), 0, new List<Exception>(), 3);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.STATISTIC); }
        }

        public void setServiceCredential(object channel)
        {
            _servicePortType = (ClientProxy)channel;
            if (AuthenticatedUser != null && string.IsNullOrEmpty(_servicePortType.ClientCredentials.UserName.UserName) && string.IsNullOrEmpty(_servicePortType.ClientCredentials.UserName.Password))
            {
                _servicePortType.ClientCredentials.UserName.UserName = AuthenticatedUser.UserName;
                _servicePortType.ClientCredentials.UserName.Password = AuthenticatedUser.HashedPassword;
            }
            _gateWayStatistic.setServiceCredential(_servicePortType);
        }

        public void setCompanyName(string companyName)
        {
            _gateWayStatistic.setCompanyName(companyName);
        }

        public bool IsDataDownloading
        {
            get { return _isLodingDataFromWebServiceToLocal; }
            set { _isLodingDataFromWebServiceToLocal = value; onPropertyChange("IsDataDownloading"); }
        }

        public void onPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task retrieveGateWayStatisticDataAsync()
        {
            lock (_lock) IsDataDownloading = true;
            try
            {
                checkServiceCommunication();
                var statisticList = await _gateWayStatistic.GetStatisticDataAsync(_loadSize);
                if (statisticList.Count > 0)
                    LoadStatistic(statisticList);

                try { _progressBarFunc((double)100 / _progressStep); }
                catch (DivideByZeroException ex) { Log.error(ex.Message, EErrorFrom.STATISTIC); }
            }
            catch (Exception) { throw; }
            finally { lock (_lock) IsDataDownloading = false; }

        }

        public void progressBarManagement(Func<double, double> progressBarFunc)
        {
            _progressBarFunc = progressBarFunc;
        }

        private void checkServiceCommunication()
        {
            _serviceCommunication.checkServiceCommunication(_servicePortType);
        }

        #region [ Actions ]
        //=================================[ Actions ]================================================
        public async Task<List<Statistic>> InsertStatisticAsync(List<Statistic> statisticList)
        {
            List<Statistic> gateWayResultList = new List<Statistic>();
            checkServiceCommunication();
            gateWayResultList = await _gateWayStatistic.InsertStatisticAsync(statisticList);
            List<Statistic> result = LoadStatistic(gateWayResultList);
            return result;
        }

        public async Task<List<Statistic>> UpdateStatisticAsync(List<Statistic> statisticList)
        {
            checkServiceCommunication();
            List<Statistic> gateWayResultList = await _gateWayStatistic.UpdateStatisticAsync(statisticList);
            List<Statistic> result = LoadStatistic(gateWayResultList);
            return result;
        }

        public List<Statistic> LoadStatistic(List<Statistic> statisticList)
        {
            List<Statistic> result = new List<Statistic>();
            foreach (var statistic in statisticList)
            {
                int returnResult = _dataSet.LoadStatistic(statistic);
                if (returnResult > 0)
                    result.Add(statistic);
            }
            return result;
        }

        public async Task<List<Statistic>> DeleteStatisticAsync(List<Statistic> statisticList)
        {
            List<Statistic> result = new List<Statistic>();
            checkServiceCommunication();
            List<Statistic> gateWayResultList = await _gateWayStatistic.DeleteStatisticAsync(statisticList);
            if (gateWayResultList.Count == 0)
                foreach (Statistic statistic in gateWayResultList)
                {
                    int returnResult = _dataSet.DeleteStatistic(statistic.ID);
                    if (returnResult > 0)
                        result.Add(statistic);
                }
            return result;
        }

        public List<Statistic> GetStatisticData(int nbLine)
        {
            List<Statistic> result = new List<Statistic>();
            result = _dataSet.GetStatisticData();
            if (nbLine == 999 || result.Count == 0 || result.Count < nbLine)
                return result;
            return result.GetRange(0, nbLine);
        }

        public async Task<List<Statistic>> GetStatisticDataAsync(int nbLine)
        {
            checkServiceCommunication();
            return await _gateWayStatistic.GetStatisticDataAsync(nbLine);
        }

        public List<Statistic> GetStatisticDataById(int id)
        {
            return _dataSet.GetStatisticDataById(id);
        }

        public List<Statistic> searchStatistic(Statistic statistic, ESearchOption filterOperator)
        {
            return _dataSet.searchStatistic(statistic, filterOperator);
        }

        public async Task<List<Statistic>> searchStatisticAsync(Statistic statistic, ESearchOption filterOperator)
        {
            checkServiceCommunication();
            return await _gateWayStatistic.searchStatisticAsync(statistic, filterOperator);
        }
        #endregion

        public void Dispose()
        {
            if (_gateWayStatistic != null)
                _gateWayStatistic.Dispose();
        }
    } /* end class BLStatisitc */
}