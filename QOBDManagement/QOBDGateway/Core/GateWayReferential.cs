using QOBDCommon.Entities;
using QOBDCommon.Interfaces.REMOTE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using QOBDGateway.Helper.ChannelHelper;
using System.ServiceModel;
using System.Linq;
using QOBDGateway.QOBDServiceReference;
using QOBDCommon.Enum;
using QOBDGateway.Classes;
using QOBDGateway.Abstracts;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDGateway.Core
{
    public class GateWayReferential : IReferentialManager, INotifyPropertyChanged
    {
        private ClientProxy _channel;
        private string _companyName;

        public event PropertyChangedEventHandler PropertyChanged;

        public GateWayReferential(ClientProxy servicePort)
        {
            _channel = servicePort;
        }

        public void setServiceCredential(object channel)
        {
            _channel = (ClientProxy)channel;
        }

        private void onPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void setCompanyName(string companyName)
        {
            _companyName = companyName;
        }

        public async Task<List<Info>> DeleteInfoAsync(List<Info> listInfos)
        {
            List<Info> result = new List<Info>();
            try
            {
                result = (await _channel.delete_data_infosAsync(_companyName, listInfos.InfosTypeToArray())).ArrayTypeToInfos();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Info>> InsertInfoAsync(List<Info> listInfos)
        {
            List<Info> result = new List<Info>();
            try
            {
                result = (await _channel.insert_data_infosAsync(_companyName, listInfos.InfosTypeToArray())).ArrayTypeToInfos();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Info>> UpdateInfoAsync(List<Info> listInfos)
        {
            List<Info> result = new List<Info>();
            try
            {
                result = (await _channel.update_data_infosAsync(_companyName, listInfos.InfosTypeToArray())).ArrayTypeToInfos();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Info>> GetInfoDataAsync(int nbLine)
        {
            List<Info> result = new List<Info>();
            try
            {
                result = (await _channel.get_data_infosAsync(_companyName, nbLine.ToString())).ArrayTypeToInfos().OrderBy(x => x.ID).ToList();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Info>> GetInfosDataById(int id)
        {
            List<Info> result = new List<Info>();
            try
            {
                result = (await _channel.get_data_infos_by_idAsync(_companyName, id.ToString())).ArrayTypeToInfos();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Info>> searchInfoAsync(Info Infos, ESearchOption filterOperator)
        {
            List<Info> result = new List<Info>();
            try
            {
                result = (await _channel.get_filter_infosAsync(_companyName, Infos.InfosTypeToFilterArray(filterOperator))).ArrayTypeToInfos();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public void Dispose()
        {
            if (_channel.State == CommunicationState.Opened)
                _channel.Close();
        }
    } /* end class BlReferential */
}