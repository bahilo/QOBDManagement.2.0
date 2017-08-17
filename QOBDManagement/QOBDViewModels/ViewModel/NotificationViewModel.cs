using QOBDCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QOBDViewModels.Interfaces;
using QOBDCommon.Structures;
using QOBDCommon.Classes;
using System.Globalization;
using QOBDCommon.Enum;
using System.Configuration;
using QOBDModels.Models;
using QOBDModels.Command;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class NotificationViewModel : Classes.ViewModel
    {
        private Func<Object, Object> _page;
        private Notification _notification;
        private List<Notification> _notifications;
        private string _title;
        private IMainWindowViewModel _main;

        //----------------------------[ Models ]------------------

        
        private List<BillModel> _billNotPaidList;
        private List<OrderModel> _orderWaitingValidationList;
        private List<ClientModel> _clientList;
        private NotificationSideBarViewModel _notificationSideBarViewModel;


        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> BtnDeleteCommand { get; set; }
        public ButtonCommand<ClientModel> DetailSelectedClientCommand { get; set; }
        public ButtonCommand<BillModel> SendBillCommand { get; set; }
        public ButtonCommand<BillModel> ValidChangeCommand { get; set; }

        public NotificationViewModel()
        {
            
            
        }

        public NotificationViewModel(IMainWindowViewModel mainWindowViewModel) : this()
        {
            _main = mainWindowViewModel;
            _page = _main.navigation;
            instances();
            instancesModel();
            instancesCommand();
            initEvents();
        }        

        //----------------------------[ Initialization ]------------------

        private void initEvents()
        {
        }

        private void instances()
        {
            _title = ConfigurationManager.AppSettings["title_notification"];
            _notification = new Notification();
            _notifications = new List<Notification>();                        
        }

        private void instancesModel()
        {
            _notificationSideBarViewModel = (NotificationSideBarViewModel)_main.ViewModelCreator.createViewModel( Enums.EViewModel.NOTIFICATIONMENU, _main);
            _billNotPaidList = new List<BillModel>();
            _clientList = new List<ClientModel>();
            _orderWaitingValidationList = new List<OrderModel>();
        }

        private void instancesCommand()
        {
            BtnDeleteCommand = _main.CommandCreator.createSingleInputCommand<string>(deleteClient, canDeleteClient);
            DetailSelectedClientCommand = _main.CommandCreator.createSingleInputCommand<ClientModel>(showClientDetails, canShowCLientDetails);
            SendBillCommand = _main.CommandCreator.createSingleInputCommand<BillModel>(sendUnpaidInvoiceReminderEmail, canSendUnpaidInvoiceReminderEmail);
            ValidChangeCommand = _main.CommandCreator.createSingleInputCommand<BillModel>(validateChanges, canValidateChanges);
        }

        //----------------------------[ Properties ]------------------

        public NotificationSideBarViewModel NotificationSideBarViewModel
        {
            get { return _notificationSideBarViewModel; }
            set { setProperty(ref _notificationSideBarViewModel, value); }
        }

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public string Title
        {
            get { return _title; }
        }

        public List<BillModel> BillNotPaidList
        {
            get { return _billNotPaidList; }
            set { setProperty(ref _billNotPaidList, value); }
        }

        public List<OrderModel> OrderWaitingValidationList
        {
            get { return _orderWaitingValidationList; }
            set { setProperty(ref _orderWaitingValidationList, value); }
        }

        public List<ClientModel> ClientList
        {
            get { return _clientList; }
            set { setProperty(ref _clientList, value); }
        }


        //----------------------------[ Actions ]------------------

        public async Task loadNotifications()
        {
            ClientList = (await Bl.BlClient.GetClientMaxCreditOverDataByAgentAsync(Bl.BlSecurity.GetAuthenticatedUser().ID)).Select(x=> new ClientModel { Client = x }).ToList();
            ClientList = await getClientBillInfoAsync(ClientList);
            BillNotPaidList = await billListToModelViewList(await Bl.BlOrder.GetUnpaidBillDataByAgentAsync(Bl.BlSecurity.GetAuthenticatedUser().ID));

            // getting the orders waiting to be validated for more than a week
            _main.OrderViewModel.loadOrders();
            OrderWaitingValidationList = _main.OrderViewModel.OrderModelList.Where(x=> x.TxtStatus.Equals(EOrderStatus.Pre_Order.ToString()) && x.Order.Date < DateTime.Now.AddDays(-7)).ToList();
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        private async Task<List<ClientModel>> getClientBillInfoAsync(List<ClientModel> clientList)
        {
            foreach (ClientModel clientModel in clientList)
            {
                var billFoundList = await Bl.BlOrder.searchBillAsync(new Bill { ClientId = clientModel.Client.ID }, ESearchOption.AND);
                if (billFoundList.Count > 0)
                    clientModel.TxtUsedCredit = (billFoundList[0].Pay - billFoundList[0].PayReceived).ToString(); 
            }
            return clientList;
        }

        public async Task<List<BillModel>> billListToModelViewList(List<Bill> billList)
        {
            List<BillModel> output = new List<BillModel>();
            foreach (Bill bill in billList)
            {
                BillModel bvm = (BillModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.INVOICE);
                bvm.Bill = bill;

                var clientFound = (await Bl.BlClient.searchClientAsync(new Client { ID = bill.ClientId }, QOBDCommon.Enum.ESearchOption.AND)).FirstOrDefault();
                if(clientFound != null)
                {
                    bvm.ClientModel = new ClientModel { Client = clientFound };
                    bvm.ClientModel.TxtUsedCredit = (bill.Pay - bill.PayReceived).ToString();
                }
                    

                var orderFound = (await Bl.BlOrder.searchOrderAsync(new Order { ID = bill.OrderId }, QOBDCommon.Enum.ESearchOption.AND)).FirstOrDefault();
                if (orderFound != null)
                    bvm.OrderModel = new OrderModel { Order = orderFound };

                var notificationFound = (await Bl.BlNotification.searchNotificationAsync(new Notification { BillId = bill.ID }, QOBDCommon.Enum.ESearchOption.AND)).FirstOrDefault();
                if (notificationFound != null)
                    bvm.NotificationModel = new NotificationModel { Notification = notificationFound };

                output.Add(bvm);
            }
            return output;
        }

        public override void Dispose()
        {
            NotificationSideBarViewModel.Dispose();
        }

        //----------------------------[ Action Commands ]------------------
        
        private void validateChanges(BillModel obj)
        {
            
        }

        private bool canValidateChanges(BillModel arg)
        {
            return true;
        }

        private async void sendUnpaidInvoiceReminderEmail(BillModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["wait_message"]);
            ParamOrderToPdf paramOrderToPdf = new ParamOrderToPdf();
            var paramEmail = new ParamEmail();
            paramEmail.IsCopyToAgent = await Singleton.getDialogueBox().showAsync("Do you want to receive a copy?");
            paramEmail.IsSendEmail = true;

            paramOrderToPdf.BillId = obj.Bill.ID;
            paramOrderToPdf.OrderId = obj.Bill.OrderId;
            paramOrderToPdf.Lang = CultureInfo.CurrentCulture.Name.Split('-').FirstOrDefault() ?? "en";
            paramOrderToPdf.ParamEmail = paramEmail;

            var billNotPaidFoundList = BillNotPaidList.Where(x => x.Bill.ID == obj.Bill.ID).ToList();
            var notificationFoundList = await Bl.BlNotification.searchNotificationAsync(new Notification { BillId = obj.Bill.ID }, QOBDCommon.Enum.ESearchOption.AND) ;
            if(notificationFoundList.Count > 0)
            {
                // the first reminder of unpaid invoice
                if (notificationFoundList[0].Reminder1 <= Utility.DateTimeMinValueInSQL2005 && notificationFoundList[0].Reminder2 <= Utility.DateTimeMinValueInSQL2005)
                {
                    paramEmail.Reminder = 1;
                    notificationFoundList[0].Reminder1 = DateTime.Now;

                    // update the invoice notification
                    if (billNotPaidFoundList.Count > 0)
                        billNotPaidFoundList[0].TxtDateFirstReminder = notificationFoundList[0].Reminder1.ToString();
                }

                // the second reminder of unpaid invoice
                else
                {
                    paramEmail.Reminder = 2;
                    notificationFoundList[0].Reminder2 = DateTime.Now;

                    // update the invoice notification
                    if (billNotPaidFoundList.Count > 0)
                        billNotPaidFoundList[0].TxtDateSecondReminder = notificationFoundList[0].Reminder2.ToString();
                }

                // save that a reminder has been sent
                var savedNotificationList = await Bl.BlNotification.UpdateNotificationAsync(new List<Notification> { notificationFoundList[0] });
                     
                // generate and send the invoice 
                Bl.BlOrder.GeneratePdfOrder(paramOrderToPdf);
            }           
            
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        private bool canSendUnpaidInvoiceReminderEmail(BillModel arg)
        {
            return true;
        }

        private void showClientDetails(ClientModel obj)
        {
            _main.ClientViewModel.SelectedCLientModel = obj;
            _page((ClientDetailViewModel)_main.ViewModelCreator.createViewModel( Enums.EViewModel.CLIENTDETAIL, _main));
        }

        private bool canShowCLientDetails(ClientModel arg)
        {
            return true;
        }

        private void deleteClient(string obj)
        {
            
        }

        private bool canDeleteClient(string arg)
        {
            return true;
        }

    }
}
