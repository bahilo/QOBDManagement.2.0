using System;
using System.Collections.Generic;
using Entity = QOBDCommon.Entities;
using QOBDCommon.Enum;
using System.ComponentModel;
using QOBDCommon.Classes;
using QOBDViewModels.Interfaces;
using QOBDModels.Command;
using QOBDModels.Models;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class OrderSideBarViewModel : Classes.ViewModel, ISideBarViewModel
    {
        private Func<Object, Object> _page;
        private NotifyTaskCompletion<List<Entity.Order_item>> _order_itemTask_updateItem;
        private NotifyTaskCompletion<List<Entity.Order_item>> _order_itemTask_updateCommand_Item;
        private NotifyTaskCompletion<object> _quoteTask;

        //----------------------------[ Models ]------------------

        private IOrderDetailViewModel _orderDetailViewModel;
        private IMainWindowViewModel _main;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> UtilitiesCommand { get; set; }
        public ButtonCommand<string> SetupCommand { get; set; }


        public OrderSideBarViewModel()
        {
            
        }

        public OrderSideBarViewModel(IMainWindowViewModel mainWindowViewModel, IOrderDetailViewModel orderDetailvieModel) : this()
        {
            _main = mainWindowViewModel;
            _orderDetailViewModel = orderDetailvieModel;
            _page = _main.navigation;
            instances();
            instancesCommand();
            initEvents();
        }


        //----------------------------[ Initialization ]------------------

        private void initEvents()
        {
            _orderDetailViewModel.addObserver(onSelectedCommandModelChange);
        }

        private void instances()
        {
            _order_itemTask_updateItem = new NotifyTaskCompletion<List<Entity.Order_item>>();
            _order_itemTask_updateCommand_Item = new NotifyTaskCompletion<List<Entity.Order_item>>();
            _quoteTask = new NotifyTaskCompletion<object>();
        }

        private void instancesCommand()
        {
            UtilitiesCommand = _main.CommandCreator.createSingleInputCommand<string>(executeUtilityAction, canExecuteUtilityAction);
            SetupCommand = _main.CommandCreator.createSingleInputCommand<string>(executeSetupAction, canExecuteSetupAction);
        }

        //----------------------------[ Properties ]------------------

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public OrderModel SelectedOrderModel
        {
            get { return _orderDetailViewModel.OrderSelected; }
            set { _orderDetailViewModel.OrderSelected = value; onPropertyChange(); }
        }


        //----------------------------[ Actions ]------------------


        private void updateCommand()
        {
            UtilitiesCommand.raiseCanExecuteActionChanged();
            SetupCommand.raiseCanExecuteActionChanged();
        }

        private void generateAllBillsPdf()
        {
            foreach (var billModel in SelectedOrderModel.BillModelList)
            {
                Bl.BlOrder
                    .GeneratePdfOrder(new QOBDCommon
                        .Structures
                            .ParamOrderToPdf
                    {
                        BillId = billModel.Bill.ID,
                        OrderId = SelectedOrderModel.Order.ID
                    });
            }
        }

        /// <summary>
        /// Navigate through the application
        /// </summary>
        /// <param name="obj"> the page to navig to</param>
        public void executeNavig(string obj)
        {
            switch (obj)
            {
                case "select-client":
                    _page(new ClientViewModel());
                    break;
            }
        }

        public override void Dispose()
        {
            _orderDetailViewModel.removeObserver(onSelectedCommandModelChange);
        }

        //----------------------------[ Event Handler ]------------------
        
        public void onCurrentPageChange_updateCommand(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrentViewModel"))
                updateCommand();
        }

        private void onSelectedCommandModelChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedOrderModel"))
                updateCommand();
        }

        //----------------------------[ Action Commands ]------------------


        private bool canExecuteUtilityAction(string arg)
        {
            bool isUserAdmin = _main.AgentViewModel.IsAuthenticatedAgentAdmin;

            if (_page(null) as OrderViewModel == null && arg.Equals("order"))
                return true;

            if (_page(null) as QuoteViewModel == null && arg.Equals("quote"))
                return true;

            if (_page(null) as OrderDetailViewModel == null)
                return false;

            if (_page(null) as OrderDetailViewModel != null && 
                (SelectedOrderModel.Order.ID == 0
                || string.IsNullOrEmpty(SelectedOrderModel.TxtStatus)))
                return false;

            if (!SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Quote.ToString())
                && (arg.Equals("convert-quoteToOrder") || arg.Equals("convert-quoteToCredit")))
                return false;

            if ((arg.Equals("close-order") || arg.Equals("close-credit")) && (!_main.securityCheck(EAction.Order_Close, ESecurity._Update) || !_main.securityCheck(EAction.Order_Close, ESecurity._Write))
                || (arg.Equals("valid-order") || arg.Equals("valid-credit")) && (!_main.securityCheck(EAction.Order_Valid, ESecurity._Update) || !_main.securityCheck(EAction.Order_Valid, ESecurity._Write))
                || arg.Equals("convert-orderToQuote") && !isUserAdmin )
                return false;

            if (!SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Quote.ToString())
                && ((arg.Equals("convert-quoteToOrder") || arg.Equals("convert-quoteToCredit")) 
                && (!_main.securityCheck(EAction.Quote_Order, ESecurity._Update) || !_main.securityCheck(EAction.Quote_Order, ESecurity._Write))))
                return false;

            if (SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Quote.ToString())
                && (arg.Equals("close-order")
                   || arg.Equals("close-credit")
                   || arg.Equals("valid-order")
                   || arg.Equals("convert-orderToQuote")
                   ))
                return false;

            if ((SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Order.ToString()) || !SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Pre_Order.ToString()))
                && arg.Equals("valid-order"))
                return false;

            if ((SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Credit.ToString()) || !SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Pre_Credit.ToString()))
                && arg.Equals("valid-credit"))
                return false;

            if ((SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Order_Close.ToString()) || !SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Bill_Order.ToString()) )//|| !SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Billed.ToString())
                && arg.Equals("close-order"))
                return false;

            if ((SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Credit_CLose.ToString()) || !SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Bill_Credit.ToString()) ) // || !SelectedOrderModel.TxtStatus.Equals(EOrderStatus.Billed.ToString())
                && arg.Equals("close-credit"))
                return false;

            return true;
        }

        private async void executeUtilityAction(string obj)
        {
            IOrderDetailViewModel orderDetail = _main.OrderViewModel.OrderDetailViewModel;
            switch (obj)
            {
                case "convert-quoteToOrder":
                    orderDetail.updateOrderStatus(EOrderStatus.Pre_Order);
                    break;
                case "valid-order":
                    orderDetail.updateOrderStatus(EOrderStatus.Order);
                    break;
                case "valid-credit":
                    if (await Singleton.getDialogueBox().showAsync("Do you really want to validate this credit?"))
                        orderDetail.updateOrderStatus(EOrderStatus.Credit);
                    break;
                case "convert-orderToQuote":
                    if (await Singleton.getDialogueBox().showAsync("Do you really want to convert into quote?"))
                        orderDetail.updateOrderStatus(EOrderStatus.Quote);                        
                    break;
                case "convert-quoteToCredit":
                    if (await Singleton.getDialogueBox().showAsync("Do you really want to convert into credit?"))
                        orderDetail.updateOrderStatus(EOrderStatus.Pre_Credit);
                    break;
                case "close-order":
                    if (await Singleton.getDialogueBox().showAsync("Do you really want to close this order?"))
                        orderDetail.updateOrderStatus(EOrderStatus.Order_Close);
                    break;
                case "close-credit":
                    if (await Singleton.getDialogueBox().showAsync("Do you really want to close this credit?"))
                        orderDetail.updateOrderStatus(EOrderStatus.Credit_CLose);
                    break;
                case "order":
                    _page(_main.OrderViewModel);
                    break;
                case "quote":
                    _page(_main.QuoteViewModel);
                    break;
            }
            
        }

        /// <summary>
        /// set the value of the next page.
        /// </summary>
        /// <param name="obj"></param>
        private void executeSetupAction(string obj)
        {
            executeNavig(obj);
        }

        private bool canExecuteSetupAction(string arg)
        {
            if ((_page(null) as QuoteViewModel) == null)
                return false;

            if ((_page(null) as QuoteViewModel) != null
                && Singleton.getCart().ClientModel != null && Singleton.getCart().ClientModel.Client.ID != 0
                && arg.Equals("select-client"))
                return false;

            return true;
        }




    }
}