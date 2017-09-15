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
    public class GateWayNotification : INotificationManager, INotifyPropertyChanged
    {
        private ClientProxy _channel;
        private string _companyName;

        public event PropertyChangedEventHandler PropertyChanged;

        public GateWayNotification(ClientProxy servicePort)
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

        public ClientProxy NotificationGatWayChannel
        {
            get
            {
                return _channel;
            }
        }

        public void setCompanyName(string companyName)
        {
            _companyName = companyName;
        }

        public async Task<List<Notification>> DeleteNotificationAsync(List<Notification> listNotification)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = (await _channel.delete_data_notificationAsync(_companyName, listNotification.NotificationTypeToArray())).ArrayTypeToNotification();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Notification>> GetNotificationDataAsync(int nbLine)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = (await _channel.get_data_notificationAsync(_companyName, nbLine.ToString())).ArrayTypeToNotification().OrderBy(x => x.ID).ToList();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Notification>> GetNotificationDataByIdAsync(int id)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = (await _channel.get_data_notification_by_idAsync(_companyName, id.ToString())).ArrayTypeToNotification();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Notification>> GetNotificationDataByOrderListAsync(List<Order> orderList)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = (await _channel.get_data_notification_by_order_listAsync(_companyName, orderList.OrderTypeToArray())).ArrayTypeToNotification();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }


        public async Task<List<Notification>> InsertNotificationAsync(List<Notification> listNotification)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = (await _channel.insert_data_notificationAsync(_companyName, listNotification.NotificationTypeToArray())).ArrayTypeToNotification();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Notification>> UpdateNotificationAsync(List<Notification> listNotification)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = (await _channel.update_data_notificationAsync(_companyName, listNotification.NotificationTypeToArray())).ArrayTypeToNotification();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Notification>> searchNotificationAsync(Notification notification, ESearchOption filterOperator)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = (await _channel.get_filter_notificationAsync(_companyName, notification.NotificationTypeToFilterArray(filterOperator))).ArrayTypeToNotification();
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
    } /* end class BlNotification */
}