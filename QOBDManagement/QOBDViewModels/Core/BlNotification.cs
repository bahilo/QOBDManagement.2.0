using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDCommon.Enum;
using QOBDCommon.Interfaces.BL;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDViewModels.Core
{
    public class BlNotification : INotificationManager
    {
        // Attributes

        // Attributes
        public QOBDCommon.Interfaces.DAC.IDataAccessManager DAC { get; set; }

        public BlNotification(QOBDCommon.Interfaces.DAC.IDataAccessManager DataAccessComponent)
        {
            DAC = DataAccessComponent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void initializeCredential(Agent user)
        {
            if (user != null)
                DAC.DALNotification.initializeCredential(user);
        }


        public void setServiceCredential(object channel)
        {
            DAC.DALNotification.setServiceCredential(channel);
        }

        public void cacheWebServiceData()
        {
            DAC.DALNotification.cacheWebServiceData();
        }

        public void progressBarManagement(Func<double, double> progressBarFunc)
        {
            if (progressBarFunc != null)
                DAC.DALNotification.progressBarManagement(progressBarFunc);
        }

        public async Task<List<Notification>> InsertNotificationAsync(List<Notification> notificationList)
        {
            if (notificationList == null || notificationList.Count == 0)
                return new List<Notification>();

            List<Notification> result = new List<Notification>();
            try
            {
                result = await DAC.DALNotification.InsertNotificationAsync(notificationList);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public async Task<List<Notification>> UpdateNotificationAsync(List<Notification> notificationList)
        {
            List<Notification> result = new List<Notification>();
            if (!checkIfUpdateOrDeleteParamRepectsRequirements(notificationList.Where(x => x.ID == 0).Count()))
                notificationList = notificationList.Where(x => x.ID != 0).ToList();

            if (notificationList == null || notificationList.Count == 0)
                return result;

            try
            {
                result = await DAC.DALNotification.UpdateNotificationAsync(notificationList);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public async Task<List<Notification>> DeleteNotificationAsync(List<Notification> notificationList)
        {
            List<Notification> result = new List<Notification>();
            if (!checkIfUpdateOrDeleteParamRepectsRequirements(notificationList.Where(x => x.ID == 0).Count()))
                notificationList = notificationList.Where(x => x.ID != 0).ToList();

            if (notificationList == null || notificationList.Count == 0)
                return result;

            try
            {
                result = await DAC.DALNotification.DeleteNotificationAsync(notificationList);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public List<Notification> GetNotificationData(int nbLine)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = DAC.DALNotification.GetNotificationData(nbLine);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public async Task<List<Notification>> GetNotificationDataAsync(int nbLine)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = await DAC.DALNotification.GetNotificationDataAsync(nbLine);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public List<Notification> GetNotificationDataById(int id)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = DAC.DALNotification.GetNotificationDataById(id);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public List<Notification> searchNotification(Notification notification, ESearchOption filterOperator)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = DAC.DALNotification.searchNotification(notification, filterOperator);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public async Task<List<Notification>> searchNotificationAsync(Notification notification, ESearchOption filterOperator)
        {
            List<Notification> result = new List<Notification>();
            try
            {
                result = await DAC.DALNotification.searchNotificationAsync(notification, filterOperator);
            }
            catch (Exception ex) { Log.error(ex.Message, EErrorFrom.NOTIFICATION); }
            return result;
        }

        public void Dispose()
        {
            DAC.DALNotification.Dispose();
        }

        private bool checkIfUpdateOrDeleteParamRepectsRequirements(int IDValues, [CallerMemberName] string functionName = null)
        {
            bool isRequirementsRespected = true;
            if (IDValues > 0)
            {
                isRequirementsRespected = false;
                Log.warning(functionName + " params (count = " + IDValues + ") with ID = 0", EErrorFrom.NOTIFICATION);
            }
            return isRequirementsRespected;
        }


        // Operations


    } /* end class BlNotification */
}