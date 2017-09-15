using QOBDCommon.Entities;
using QOBDCommon.Enum;
using QOBDCommon.Interfaces.REMOTE;
using QOBDGateway.Abstracts;
using QOBDGateway.Classes;
using QOBDGateway.Helper.ChannelHelper;
using QOBDGateway.QOBDServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDGateway.Core
{
    public class GateWayStatistic : IStatisticManager, INotifyPropertyChanged
    {
        private ClientProxy _channel;
        private string _companyName;

        public event PropertyChangedEventHandler PropertyChanged;

        public GateWayStatistic(ClientProxy servicePort)
        {
            _channel = servicePort;
        }

        private void onPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void setServiceCredential(object channel)
        {
            _channel = (ClientProxy)channel;
        }

        public void setCompanyName(string companyName)
        {
            _companyName = companyName;
        }

        public  async Task<List<Statistic>> InsertStatisticAsync(List<Statistic> statisticList)
        {
            List<Statistic> result = new List<Statistic>();
            try
            {
                result = (await _channel.insert_data_statisticAsync(_companyName,statisticList.StatisticTypeToArray())).ArrayTypeToStatistic();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public  async Task<List<Statistic>> UpdateStatisticAsync(List<Statistic> statisticList)
        {
            List<Statistic> result = new List<Statistic>();
            try
            {
                result = (await _channel.update_data_statisticAsync(_companyName, statisticList.StatisticTypeToArray())).ArrayTypeToStatistic();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public  async Task<List<Statistic>> DeleteStatisticAsync(List<Statistic> statisticList)
        {
            List<Statistic> result = new List<Statistic>();
            try
            {
                result = (await _channel.delete_data_statisticAsync(_companyName, statisticList.StatisticTypeToArray())).ArrayTypeToStatistic();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public  async Task<List<Statistic>> GetStatisticDataAsync(int nbLine)
        {
            List<Statistic> result = new List<Statistic>();
            try
            {
                result = (await _channel.get_data_statisticAsync(_companyName, nbLine.ToString())).ArrayTypeToStatistic().OrderBy(x => x.ID).ToList();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public  async Task<List<Statistic>> searchStatisticAsync(Statistic statistic, ESearchOption filterOperator)
        {
            List<Statistic> result = new List<Statistic>();
            try
            {
                result = (await _channel.get_filter_statisticAsync(_companyName, statistic.StatisticTypeToFilterArray(filterOperator))).ArrayTypeToStatistic();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public  async Task<List<Statistic>> GetStatisticDataById(int id)
        {
            List<Statistic> result = new List<Statistic>();
            try
            {
                result = (await _channel.get_data_statistic_by_idAsync(_companyName, id.ToString())).ArrayTypeToStatistic();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public Task<List<Statistic>> searchStatisticFromWebServiceAsync(Statistic statisitic, ESearchOption filterOperator)
        {
            return searchStatisticAsync(statisitic, filterOperator);
        }

        public void Dispose()
        {
            if (_channel.State == CommunicationState.Opened)
                _channel.Close();
        }
    } /* end class BLStatisitc */
}