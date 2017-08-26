﻿using Entity = QOBDCommon.Entities;
using QOBDCommon.Entities;
using QOBDCommon.Enum;
using QOBDCommon.Structures;
using QOBDViewModels.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using QOBDCommon.Classes;
using QOBDViewModels.Interfaces;
using System.Globalization;
using System.Configuration;
using QOBDModels.Models;
using QOBDModels.Classes;
using QOBDModels.Command;

namespace QOBDViewModels.ViewModel
{
    public class OrderDetailViewModel : Classes.ViewModel
    {
        #region [ Variables ]
        private string _title;
        private string _outputStringFormat;
        //private string _incomeHeaderWithCurrency;
        private decimal _totalBeforeTax;
        private CurrencyModel _currencyModel;
        private InfoFileWriter _mailFile;
        private ParamOrderToPdf _paramQuoteToPdf;
        private ParamOrderToPdf _paramOrderToPdf;
        private ParamDeliveryToPdf _paramDeliveryToPdf;
        public NotifyTaskCompletion<bool> _updateOrderStatusTask { get; set; }
        private Func<object, object> _page;
        private List<Tax> _taxes;
        private EOrderStatus _orderNewStatus;

        #endregion

        #region [ Models Variables ]
        //----------------------------[ Models ]------------------

        private List<Order_itemModel> _order_itemList;
        private List<Item_deliveryModel> _item_deliveryModelBillingInProcessList;
        private OrderModel _orderSelected;
        private BillModel _selectedBillToSend;
        private List<Item_deliveryModel> _item_ModelDeliveryInProcess;
        private List<Item_deliveryModel> _item_deliveryModelCreatedList;
        private IMainWindowViewModel _main;
        private StatisticModel _statistic;
        #endregion

        #region [ Commands Variables ]
        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> UpdateOrder_itemListCommand { get; set; }
        public ButtonCommand<Item_deliveryModel> CancelDeliveryReceiptCreationCommand { get; set; }
        public ButtonCommand<Item_deliveryModel> CancelDeliveryReceiptCreatedCommand { get; set; }
        public ButtonCommand<BillModel> CancelBillCreatedCommand { get; set; }
        public ButtonCommand<DeliveryModel> GenerateDeliveryReceiptCreatedPdfCommand { get; set; }
        public ButtonCommand<BillModel> GeneratePdfCreatedBillCommand { get; set; }
        public ButtonCommand<Order_itemModel> DeliveryReceiptCreationCommand { get; set; }
        public ButtonCommand<Order_itemModel> BillCreationCommand { get; set; }
        public ButtonCommand<Order_itemModel> DeleteItemCommand { get; set; }
        public ButtonCommand<object> BilledCommand { get; set; }
        public ButtonCommand<Address> DeliveryAddressSelectionCommand { get; set; }
        public ButtonCommand<Address> BillingAddressSelectionCommand { get; set; }
        public ButtonCommand<Tax> TaxCommand { get; set; }
        public ButtonCommand<CurrencyModel> CurrencyCommand { get; set; }
        public ButtonCommand<object> GeneratePdfCreatedQuoteCommand { get; set; }
        public ButtonCommand<BillModel> SendEmailCommand { get; set; }
        public ButtonCommand<BillModel> UpdateBillCommand { get; set; }
        public ButtonCommand<object> UpdateCommentCommand { get; set; }

        #endregion

        #region [ Contructors]
        public OrderDetailViewModel()
        {
            
        }

        public OrderDetailViewModel(IMainWindowViewModel main) : this()
        {
            _main = main;
            _page = _main.navigation;
            instances();
            instancesModel();
            instancesCommand();
            initEvents();
        }

        #endregion

        #region [ Initialization ]
        //----------------------------[ Initialization ]------------------

        private void initEvents()
        {
            PropertyChanged += onOrder_itemModelWorkFlowChange;
            PropertyChanged += onCurrencyChange;
            _updateOrderStatusTask.PropertyChanged += onInitializationTaskComplete_UpdateOrderStatus;
        }

        private void instances()
        {
            _taxes = new List<Tax>();
            _currencyModel = (CurrencyModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.CURRENCY);
            _statistic = (StatisticModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.STATISTIC);
            _selectedBillToSend = (BillModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.INVOICE);
            _updateOrderStatusTask = new NotifyTaskCompletion<bool>();
            _paramDeliveryToPdf = new ParamDeliveryToPdf();
            _paramQuoteToPdf = new ParamOrderToPdf(EOrderStatus.Quote, 2);
            _paramOrderToPdf = new ParamOrderToPdf(EOrderStatus.Order);
            _outputStringFormat = "F";
            _title = ConfigurationManager.AppSettings["title_order_detail"];
            _paramOrderToPdf.Currency = _paramQuoteToPdf.Currency = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            //_incomeHeaderWithCurrency = "Total Income (" + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + ")";
            _paramDeliveryToPdf.Lang = _paramOrderToPdf.Lang = _paramQuoteToPdf.Lang = _paramDeliveryToPdf.Lang = CultureInfo.CurrentCulture.Name.Split('-').FirstOrDefault() ?? "en";

            _mailFile = new InfoFileWriter("", EOption.mails);
        }

        private void instancesModel()
        {
            _orderSelected = (OrderModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ORDER);
            _order_itemList = new List<Order_itemModel>();
            _item_deliveryModelBillingInProcessList = new List<Item_deliveryModel>();
            _item_deliveryModelCreatedList = new List<Item_deliveryModel>();
            _item_ModelDeliveryInProcess = new List<Item_deliveryModel>();
        }

        private void instancesCommand()
        {
            UpdateOrder_itemListCommand = _main.CommandCreator.createSingleInputCommand<string>(updateOrder_itemData, canUpdateOrder_itemData);
            CancelDeliveryReceiptCreationCommand = _main.CommandCreator.createSingleInputCommand<Item_deliveryModel>(deleteDeliveryReceiptInProcess, canCancelDeliveryReceiptInProcess);
            GenerateDeliveryReceiptCreatedPdfCommand = _main.CommandCreator.createSingleInputCommand<DeliveryModel>(generateDeliveryReceiptPdf, canGenerateDeliveryReceiptPdf);
            CancelDeliveryReceiptCreatedCommand = _main.CommandCreator.createSingleInputCommand<Item_deliveryModel>(cancelDeliveryReceiptCreated, canCancelDeliveryReceiptCreated);
            DeliveryReceiptCreationCommand = _main.CommandCreator.createSingleInputCommand<Order_itemModel>(createDeliveryReceipt, canCreateDeliveryReceipt);
            BillCreationCommand = _main.CommandCreator.createSingleInputCommand<Order_itemModel>(createInvoice, canCreateBill);
            CancelBillCreatedCommand = _main.CommandCreator.createSingleInputCommand<BillModel>(deleteCreatedInvoice, canCancelCreatedInvoice);
            GeneratePdfCreatedBillCommand = _main.CommandCreator.createSingleInputCommand<BillModel>(generateOrderBillPdf, canGenerateOrderBillPdf);
            DeleteItemCommand = _main.CommandCreator.createSingleInputCommand<Order_itemModel>(deleteItem, canDeleteItem);
            BilledCommand = _main.CommandCreator.createSingleInputCommand<object>(orderBilling, canBillOrder);
            DeliveryAddressSelectionCommand = _main.CommandCreator.createSingleInputCommand<Address>(selectDeliveryAddress, canSelectDeliveryAddress);
            BillingAddressSelectionCommand = _main.CommandCreator.createSingleInputCommand<Address>(selectBillingAddress, canSelectBillingAddress);
            TaxCommand = _main.CommandCreator.createSingleInputCommand<Tax>(createOrderTax, canCreateOrderTax);
            GeneratePdfCreatedQuoteCommand = _main.CommandCreator.createSingleInputCommand<object>(generateQuotePdf, canGenerateQuotePdf);
            SendEmailCommand = _main.CommandCreator.createSingleInputCommand<BillModel>(sendEmail, canSendEmail);
            UpdateBillCommand = _main.CommandCreator.createSingleInputCommand<BillModel>(updateInvoice, canUpdateInvoice);
            UpdateCommentCommand = _main.CommandCreator.createSingleInputCommand<object>(updateComment, canUpdateComment);
            CurrencyCommand = _main.CommandCreator.createSingleInputCommand<CurrencyModel>(createOrderCurrency, canCreateOrderCurrency);
        }
        #endregion

        #region [ Properties ]
        //----------------------------[ Properties ]------------------        

        public string Title
        {
            get { return _title; }
            set { setProperty(ref _title, value); }
        }

        public string IntegerOutputStringFormat
        {
            get { return _outputStringFormat; }
            set { setProperty(ref _outputStringFormat, value); }
        }

        public BillModel SelectedBillToSend
        {
            get { return _selectedBillToSend; }
            set { setProperty(ref _selectedBillToSend, value); }
        }

        public List<BillModel> BillModelList
        {
            get { return OrderSelected.BillModelList; }
            set { OrderSelected.BillModelList = value; onPropertyChange(); updateItemListBindingByCallingPropertyChange(); }
        }

        public List<DeliveryModel> DeliveryModelList
        {
            get { return OrderSelected.DeliveryModelList; }
            set { OrderSelected.DeliveryModelList = value; onPropertyChange(); }
        }

        public InfoFileWriter EmailFile
        {
            get { return _mailFile; }
            set { setProperty(ref _mailFile, value); }
        }

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public OrderModel OrderSelected
        {
            get { return _orderSelected; }
            set { setProperty(ref _orderSelected, value); }
        }

        public string TxtQuoteValidityInDays
        {
            get { return _paramQuoteToPdf.ValidityDay.ToString(); }
            set { int convertedNumber; if (int.TryParse(value, out convertedNumber)) { _paramQuoteToPdf.ValidityDay = convertedNumber; onPropertyChange(); } }
        }

        public bool IsQuote
        {
            get
            {
                if (_paramQuoteToPdf.TypeQuoteOrProformat == EOrderStatus.Quote)
                    return true;

                return false;
            }
            set
            {
                if (value == true)
                {
                    _paramQuoteToPdf.TypeQuoteOrProformat = EOrderStatus.Quote;
                    onPropertyChange();
                }
            }
        }

        public bool IsProForma
        {
            get
            {
                if (_paramQuoteToPdf.TypeQuoteOrProformat == EOrderStatus.Proforma)
                    return true;

                return false;
            }
            set
            {
                if (value == true)
                {
                    _paramQuoteToPdf.TypeQuoteOrProformat = EOrderStatus.Proforma;
                    onPropertyChange();
                }
            }
        }

        public bool IsQuoteReferencesVisible
        {
            get { return _paramQuoteToPdf.IsQuoteConstructorReferencesVisible; }
            set { _paramQuoteToPdf.IsQuoteConstructorReferencesVisible = value; onPropertyChange(); }
        }

        public bool IsOrderReferencesVisible
        {
            get { return _paramOrderToPdf.IsOrderConstructorReferencesVisible; }
            set { _paramOrderToPdf.IsOrderConstructorReferencesVisible = value; onPropertyChange(); }
        }

        public StatisticModel StatisticModel
        {
            get { return _statistic; }
            set { setProperty(ref _statistic, value); updateStatisticsByCallingPropertyChange(); }
        }

        public string TxtTotalTaxExcluded
        {
            get { return _statistic.TxtTotalTaxExcluded; }
            set { _statistic.TxtTotalTaxExcluded = value; onPropertyChange(); }
        }

        public string TxtTotalIncomePercent
        {
            get { return _statistic.TxtTotalIncomePercent; }
            set { _statistic.TxtTotalIncomePercent = value; onPropertyChange(); }
        }

        public string TxtTotalIncome
        {
            get { return _statistic.TxtTotalIncome; }
            set { _statistic.TxtTotalIncome = value; onPropertyChange(); }
        }

        public string TxtTotalTaxAmount
        {
            get { return _statistic.TxtTotalTaxAmount; }
            set { _statistic.TxtTotalTaxAmount = value; onPropertyChange(); }
        }

        public Tax Tax
        {
            get { return _orderSelected.Tax; }
            set { _orderSelected.Tax = value; onPropertyChange(); }
        }

        public string TxtTotalTaxIncluded
        {
            get { return _statistic.TxtTotalTaxIncluded; }
            set { setProperty(ref _totalBeforeTax, Convert.ToDecimal(value)); }
        }

        public string TxtTotalPurchase
        {
            get { return _statistic.TxtTotalPurchase; }
            set { _statistic.TxtTotalPurchase = value; onPropertyChange(); }
        }

        public List<Order_itemModel> Order_ItemModelList
        {
            get { return _order_itemList; }
            set { _order_itemList = value; refreshBindingByCallingPropertyChange(); }
        }

        public List<Item_deliveryModel> Item_ModelDeliveryInProcess
        {
            get { return _item_ModelDeliveryInProcess; }
            set { setProperty(ref _item_ModelDeliveryInProcess, value); updateItemListBindingByCallingPropertyChange(); }
        }

        public List<Item_deliveryModel> Item_deliveryModelCreatedList
        {
            get { return _item_deliveryModelCreatedList; }
            set { setProperty(ref _item_deliveryModelCreatedList, value); }
        }

        public List<Item_deliveryModel> Item_deliveryModelBillingInProcess
        {
            get { return _item_deliveryModelBillingInProcessList; }
            set { setProperty(ref _item_deliveryModelBillingInProcessList, value); BillCreationCommand.raiseCanExecuteActionChanged(); onPropertyChange("Item_deliveryModelBillingInProcessSelectionList"); updateItemListBindingByCallingPropertyChange(); }
        }

        public List<Item_deliveryModel> Item_deliveryModelBillingInProcessSelectionList
        {
            get { return Item_deliveryModelBillingInProcess.GroupBy(x => x.Item_delivery.DeliveryId).Select(x => x.First()).ToList(); }
        }

        public CurrencyModel CurrencyModel
        {
            get { return _currencyModel; }
            set { if (value == null) return; _currencyModel = value; onPropertyChange(); }
        }

        #endregion

        #region [ Signaling ]
        //---------------------------[ Signaling ]------------------

        public bool IsItemListCommentTextBoxEnabled
        {
            get { return UIControlManager.disableUIElementByBoolean(OrderSelected); }
        }

        public bool IsItemListQuantityTextBoxEnable
        {
            get { return UIControlManager.disableUIElementByBoolean(OrderSelected); }
        }

        public string BlockItemListDetailVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockEmailVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockBillCreationVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockDeliveryReceiptCreationVisiblity
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockDeliveryAddressVisiblity
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockDeliveryReceiptCreatedVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockBillCreatedVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockStepOneVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockStepTwoVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockStepThreeVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockDeliveryListToIncludeVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BlockBillListBoxVisibility
        {
            get { return UIControlManager.disableUIElementByString(OrderSelected, Item_ModelDeliveryInProcess, Item_deliveryModelBillingInProcess); }
        }

        public string BoxVisibility
        {
            get { return UIControlManager.disableUIElementByString(_main.AgentViewModel.IsAuthenticatedAgentAdmin); }
        }

        public string BlockVisibility
        {
            get { return UIControlManager.disableUIElementByString(_main.AgentViewModel.IsAuthenticatedAgentAdmin); }
        }

        #endregion

        #region [ Actions ]
        //----------------------------[ Actions ]------------------

        /// <summary>
        /// load the data
        /// </summary>
        public void loadOrder_items(OrderModel order)
        {
            _orderSelected = order;
            load();
            //loadOrder_items();
        }
        
        /*public async void loadOrder_items()
        {
            await load();
        }

        public async Task loadOrder_itemsAsync()
        {
            await load();
        }*/

        /// <summary>
        /// load the data
        /// </summary>
        public override async void load()
        {
            await loadAsync();
        }

        public async Task loadAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["load_message"]);

                // getting the order currency
                _main.OrderViewModel.loadCurrencies();
                CurrencyModel = _main.OrderViewModel.CurrenciesList.Where(x => x.Currency.ID == OrderSelected.Order.CurrencyId).SingleOrDefault();

                Order_ItemModelList = Order_ItemListToModelViewList(Bl.BlOrder.searchOrder_item(new Order_item { OrderId = OrderSelected.Order.ID }, ESearchOption.AND));

                StatisticModel = totalCalcul(Order_ItemModelList);

                loadAddresses();
                loadEmail();

                refreshBindings();
                BilledCommand.raiseCanExecuteActionChanged();
                Singleton.getDialogueBox().IsDialogOpen = false;
            });
        }

        /// <summary>
        /// gathering order item information
        /// </summary>
        /// <param name="Order_ItemList"></param>
        /// <returns></returns>
        public List<Order_itemModel> Order_ItemListToModelViewList(List<Order_item> Order_ItemList)
        {
            int index = 0;
            List<Order_itemModel> output = new List<Order_itemModel>();

            // unsuscribe event
            foreach (var Order_itemModel in Order_ItemModelList)
                Order_itemModel.PropertyChanged -= onQuantityOrPriceChange;

            foreach (Order_item order_Item in Order_ItemList)
            {
                Order_itemModel localOrder_item = new Order_itemModel(IntegerOutputStringFormat);
                localOrder_item.PropertyChanged += onQuantityOrPriceChange;
                localOrder_item.Order = OrderSelected.Order;
                localOrder_item.Order_Item = order_Item;
                localOrder_item.CurrencyModel = CurrencyModel;

                //load item and its information (delivery and item_delivery)
                localOrder_item.ItemModel = loadOrder_itemItem(order_Item.Item_ref, order_Item.ItemId);

                // displaying every two rows colored
                if (index % 2 == 0)
                    localOrder_item.IsRowColored = true;

                output.Add(localOrder_item);
                index++;
            }
            return output;
        }

        /// <summary>
        /// loading the items
        /// </summary>
        /// <param name="itemRef"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public ItemModel loadOrder_itemItem(string itemRef, int itemId = 0)
        {
            List<ItemModel> itemModelFoundList = new List<ItemModel>();
            if (itemId != 0)
                itemModelFoundList = _main.ItemViewModel.ItemModelList.Where(x => x.TxtRef == itemRef && x.Item.ID == itemId).ToList();// await Bl.BlItem.searchItemAsync(new Item { Ref = itemRef, ID = itemId }, ESearchOption.AND);
            else
                itemModelFoundList = _main.ItemViewModel.ItemModelList.Where(x => x.TxtRef == itemRef).ToList();//await Bl.BlItem.searchItemAsync(new Item { Ref = itemRef }, ESearchOption.AND);

            if (itemModelFoundList.Count > 0)
            {
                itemModelFoundList[0].Item_deliveryModelList = getItemsDeliveryReceipt(new List<ItemModel> { itemModelFoundList[0] });
                return itemModelFoundList[0];
            }
            return (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
        }

        private List<Item_deliveryModel> getItemsDeliveryReceipt(List<ItemModel> itemModelList)
        {
            List<Item_deliveryModel> output = new List<Item_deliveryModel>();

            foreach (ItemModel itemModel in itemModelList)
            {
                // search for the item's delivery receipt
                var deliveryFoundList = Bl.BlOrder.searchDelivery(new Delivery { OrderId = OrderSelected.Order.ID }, ESearchOption.AND);
                foreach (var delivery in deliveryFoundList)
                {
                    // search for the delivery reference of the item
                    Item_deliveryModel item_deliveryModelFound = Bl.BlItem.searchItem_delivery(new Item_delivery { Item_ref = itemModel.TxtRef, DeliveryId = delivery.ID }, ESearchOption.AND).Select(x => new Item_deliveryModel { Item_delivery = x, ItemModel = new ItemModel { Item = itemModel.Item }, DeliveryModel = new DeliveryModel { Delivery = delivery } }).FirstOrDefault();
                    if (item_deliveryModelFound != null)
                    {
                        output.Add(item_deliveryModelFound);
                        break;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// download the email templates form the ftp host
        /// </summary>
        public void loadEmail()
        {
            if (OrderSelected != null)
            {
                var infos = Bl.BlReferential.searchInfo(new Info { Name = "Company_name" }, ESearchOption.AND).FirstOrDefault();
                var infosFTP = Bl.BlReferential.searchInfo(new QOBDCommon.Entities.Info { Name = "ftp_" }, ESearchOption.AND).ToList();
                string login = infosFTP.Where(x => x.Name == "ftp_login").Select(x => x.Value).FirstOrDefault() ?? "";
                string password = infosFTP.Where(x => x.Name == "ftp_password").Select(x => x.Value).FirstOrDefault() ?? "";
                switch (OrderSelected.TxtStatus)
                {
                    case "Quote":
                        EmailFile = new InfoFileWriter("quote", EOption.mails, ftpLogin: login, ftpPassword: password);
                        EmailFile.read();
                        if (infos != null)
                            EmailFile.TxtSubject = "** " + infos.Value + " – Your Quote n°{QUOTE_ID} **";
                        else
                            EmailFile.TxtSubject = "** Your Quote n°{QUOTE_ID} **";
                        break;
                    case "Pre_Order":
                        EmailFile = new InfoFileWriter("order_confirmation", EOption.mails, ftpLogin: login, ftpPassword: password);
                        EmailFile.read();
                        if (infos != null)
                            EmailFile.TxtSubject = "** " + infos.Value + " – Your Invoice n°{BILL_ID} **";
                        else
                            EmailFile.TxtSubject = "** Your Order n°{BILL_ID} **";
                        break;
                    case "Pre_Credit":
                        EmailFile = new InfoFileWriter("order_confirmation", EOption.mails, ftpLogin: login, ftpPassword: password);
                        EmailFile.read();
                        if (infos != null)
                            EmailFile.TxtSubject = "** " + infos.Value + " – Your Credit with Invoice n°{BILL_ID} **";
                        else
                            EmailFile.TxtSubject = "** Your Credit with Invoice n°{BILL_ID} **";
                        break;
                    case "Order":
                        EmailFile = new InfoFileWriter("bill", EOption.mails, ftpLogin: login, ftpPassword: password);
                        EmailFile.read();
                        if (infos != null)
                            EmailFile.TxtSubject = "** " + infos.Value + " – Bill n°{BILL_ID} **";
                        else
                            EmailFile.TxtSubject = "** Your Bill n°{BILL_ID} **";
                        break;
                }
            }
        }

        /// <summary>
        /// refresh the data
        /// </summary>
        private void refreshBindings()
        {
            loadInvoicesAndDeliveryReceipts();

            // check that the item in the list is erasable
            DeleteItemCommand.raiseCanExecuteActionChanged();
        }


        /// <summary>
        /// load all bills of the selected Order
        /// </summary>
        public void loadInvoicesAndDeliveryReceipts()
        {
            // unsucribe events select/unselect items with the same delivery receipt
            foreach (Item_deliveryModel item_deliveryModel in Item_deliveryModelBillingInProcess)
                item_deliveryModel.PropertyChanged -= onItem_ModelDeliveryInProcessIselectedChanged;

            // get the invoice creation list
            Item_deliveryModelBillingInProcess = (from c in Order_ItemModelList
                                                  from d in c.ItemModel.Item_deliveryModelList
                                                  where d.DeliveryModel.TxtStatus == EOrderStatus.Not_Billed.ToString()
                                                  select d).ToList();

            // select/unselect all items with the same delivery receipt
            foreach (Item_deliveryModel item_deliveryModel in Item_deliveryModelBillingInProcess)
                item_deliveryModel.PropertyChanged += onItem_ModelDeliveryInProcessIselectedChanged;

            // get the delivery creation list
            Item_ModelDeliveryInProcess = Order_ItemModelList.Where(x => x.Order_Item.Quantity_current > 0).Select(x => new Item_deliveryModel
            {
                ItemModel = x.ItemModel,
                TxtItem_ref = x.ItemModel.TxtRef,
                TxtQuantity_current = x.TxtQuantity_current,
                TxtQuantity_delivery = x.TxtQuantity_delivery
            }).ToList();

            // get the created bills
            BillModelList = billListToModelViewList(Bl.BlOrder.searchBill(new Bill { OrderId = OrderSelected.Order.ID }, ESearchOption.AND));

            // get the created delivery list
            DeliveryModelList = new DeliveryModel().DeliveryListToModelViewList(Bl.BlOrder.searchDelivery(new Delivery { OrderId = OrderSelected.Order.ID }, ESearchOption.AND));

            // check if email sending is allowed
            SendEmailCommand.raiseCanExecuteActionChanged();
        }

        public List<BillModel> billListToModelViewList(List<Bill> BillList)
        {
            List<BillModel> output = new List<BillModel>();
            foreach (Bill bill in BillList)
            {
                BillModel billModel = (BillModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.INVOICE);
                billModel.Bill = bill;
                billModel.CurrencyModel = CurrencyModel;
                billModel.TxtOutputStringFormat = _outputStringFormat;
                output.Add(billModel);
            }
            return output;
        }

        /// <summary>
        /// calcul the total amount of the order
        /// </summary>
        /// <param name="order_itemList"></param>
        /// <returns></returns>
        private StatisticModel totalCalcul(List<Order_itemModel> order_itemList, bool isDefaultCurrency = false)
        {
            object _lock = new object();
            lock (_lock)
            {
                StatisticModel statistic = (StatisticModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.STATISTIC);

                if (Order_ItemModelList.Count > 0)
                {
                    decimal totalIncome = 0.0m;
                    decimal totalTaxExcluded = 0.0m;
                    decimal totalTaxAmount = 0.0m;
                    decimal totalPurchase = 0.0m;
                    decimal totalTaxIncluded = 0.0m;

                    foreach (Order_itemModel order_itemModel in order_itemList)
                    {
                        // update the tax value
                        order_itemModel.Order = OrderSelected.Order;

                        // execute the total calculation per item
                        if (isDefaultCurrency)
                            order_itemModel.calculWithDefaultCurrency();
                        else
                            order_itemModel.calcul();

                        totalIncome += (Utility.decimalTryParse(order_itemModel.TxtTotalIncome));
                        totalTaxExcluded += (Utility.decimalTryParse(order_itemModel.TxtTotalSelling));
                        totalPurchase += (Utility.decimalTryParse(order_itemModel.TxtTotalPurchase));

                        totalTaxAmount += (Utility.decimalTryParse(order_itemModel.TxtTotalTaxAmount));
                        totalTaxIncluded += (Utility.decimalTryParse(order_itemModel.TxtTotalTaxIncluded));

                    }

                    statistic.TxtTotalTaxAmount = totalTaxAmount.ToString(IntegerOutputStringFormat);
                    statistic.TxtTotalIncome = totalIncome.ToString(IntegerOutputStringFormat);
                    statistic.TxtTotalTaxExcluded = totalTaxExcluded.ToString(IntegerOutputStringFormat);
                    statistic.TxtTotalTaxIncluded = totalTaxIncluded.ToString(IntegerOutputStringFormat);
                    try
                    {
                        statistic.TxtTotalIncomePercent = (totalIncome / totalTaxExcluded * 100).ToString(IntegerOutputStringFormat);
                    }
                    catch (DivideByZeroException)
                    {
                        statistic.TxtTotalIncomePercent = 0.ToString(IntegerOutputStringFormat);
                    }
                    statistic.TxtTotalPurchase = totalPurchase.ToString(IntegerOutputStringFormat);
                    statistic.TxtTaxValue = Tax.Value.ToString(IntegerOutputStringFormat);
                }
                return statistic;
            }
        }


        /// <summary>
        /// load the client addresses
        /// </summary>
        private void loadAddresses()
        {
            OrderSelected.AddressList = Bl.BlClient.searchAddress(new Address { ClientId = OrderSelected.CLientModel.Client.ID }, ESearchOption.AND);
        }

        /// <summary>
        /// update the order status
        /// </summary>
        /// <param name="status">the status to convert to</param>
        public void updateOrderStatus(EOrderStatus status)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["wait_message"]);
            _updateOrderStatusTask.initializeNewTask(updateOrderStatusAsync(status));
        }

        /// <summary>
        /// update the order status async
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<bool> updateOrderStatusAsync(EOrderStatus status)
        {
            bool canChangeStatus = true;
            _orderNewStatus = status;
            switch (_orderNewStatus)
            {
                case EOrderStatus.Order:
                    break;
                case EOrderStatus.Quote:
                    canChangeStatus = await cleanUpBeforeConvertingToQuoteAsync();
                    break;
                case EOrderStatus.Billed:
                    break;
                case EOrderStatus.Bill_Order:
                    break;
                case EOrderStatus.Bill_Credit:
                    break;
                case EOrderStatus.Pre_Order:
                    break;
                case EOrderStatus.Pre_Credit:
                    break;
                case EOrderStatus.Order_Close:
                    canChangeStatus = await Singleton.getDialogueBox().showAsync("Order Closing: Be careful as it will not be possible to do any change after.");
                    break;
                case EOrderStatus.Credit_CLose:
                    canChangeStatus = await Singleton.getDialogueBox().showAsync("Credit CLosing: Be careful as it will not be possible to do any change after.");
                    break;
            }
            return canChangeStatus;
        }

        /// <summary>
        /// check that the invoice in parameter is the latest one
        /// in order to prevent holes in the invoice IDs
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<bool> checkIfLastBillAsync(Bill bill, int offset)
        {
            bool isLastBill = false;
            Bill lastBill = await Bl.BlOrder.GetLastBillAsync();

            if (lastBill != null)
            {
                if (lastBill.ID - offset <= bill.ID)
                    isLastBill = true;
                else
                    isLastBill = false;
            }
            return isLastBill;
        }

        /// <summary>
        /// check that the invoice list in parameter are the latest
        /// to prevent holes in the invoice IDs
        /// </summary>
        /// <param name="billModelList"></param>
        /// <returns></returns>
        public async Task<bool> checkIfLastBillAsync(List<BillModel> billModelList)
        {
            bool isLastBill = false;
            var billList = billModelList.OrderByDescending(x => x.Bill.ID).ToList();
            for (int i = 0; i < billList.Count(); i++)
            {
                if (await checkIfLastBillAsync(billList[i].Bill, i))
                {
                    isLastBill = true;
                }
                else
                {
                    isLastBill = false;
                    break;
                }
            }
            return isLastBill;
        }

        /// <summary>
        /// delete the information relative to an order
        /// before converting back to quote
        /// </summary>
        /// <returns></returns>
        private async Task<bool> cleanUpBeforeConvertingToQuoteAsync()
        {
            bool canDelete = await checkIfLastBillAsync(BillModelList);

            // invoice and delivery receipts deletion
            if (canDelete || BillModelList.Count == 0)
            {
                Singleton.getDialogueBox().showSearchingMessage(ConfigurationManager.AppSettings["wait_message"]);

                // update item stock
                await _main.ItemViewModel.updateStockAsync(Order_ItemModelList, isStockReset: true);

                foreach (BillModel billModel in BillModelList.Select(x => new BillModel { Bill = x.Bill }).ToList())
                {
                    // deleting the related statistics
                    var statisticsFoundList = await Bl.BlStatisitc.searchStatisticAsync(new Statistic { BillId = billModel.Bill.ID }, ESearchOption.AND);
                    if (statisticsFoundList.Count > 0)
                        await Bl.BlStatisitc.DeleteStatisticAsync(new List<Statistic> { statisticsFoundList[0] });
                    await deleteInvoice(billModel, isLastest: true);
                }

                var Item_deliveryToDeleteList = new List<Item_delivery>();// Bl.BlItem.GetItem_deliveryDataByDeliveryList(DeliveryModelList.Select(x => x.Delivery).ToList());

                foreach (var item_deliveryModel in Order_ItemModelList.SelectMany(x => x.ItemModel.Item_deliveryModelList).ToList())
                {
                    Item_deliveryToDeleteList.Add(item_deliveryModel.Item_delivery);
                    item_deliveryModel.Item_delivery = new Item_delivery();
                    item_deliveryModel.DeliveryModel = new DeliveryModel();
                }

                var tax_OrderFoundListToDelete = Bl.BlOrder.searchTax_order(new Tax_order { OrderId = OrderSelected.Order.ID }, ESearchOption.AND);

                // deleting
                await Bl.BlOrder.DeleteTax_orderAsync(tax_OrderFoundListToDelete);
                await Bl.BlItem.DeleteItem_deliveryAsync(Item_deliveryToDeleteList);
                await Bl.BlOrder.DeleteDeliveryAsync(DeliveryModelList.Select(x => x.Delivery).ToList());

                foreach (var Order_itemToUpdate in Order_ItemModelList)
                {
                    Order_itemToUpdate.Order_Item.Quantity_current = 0;
                    Order_itemToUpdate.Order_Item.Quantity_delivery = 0;
                }

                BillModelList = new List<BillModel>();
                DeliveryModelList = new List<DeliveryModel>();

                if (OrderSelected.TxtStatus.Equals(EOrderStatus.Credit.ToString())
                    || OrderSelected.TxtStatus.Equals(EOrderStatus.Pre_Credit.ToString()))
                    await Bl.BlOrder.UpdateOrder_itemAsync(createOrResetCredit(Order_ItemModelList));
                else
                    await Bl.BlOrder.UpdateOrder_itemAsync(Order_ItemModelList.Select(x => x.Order_Item).ToList());

                canDelete = true;
                Singleton.getDialogueBox().IsDialogOpen = false;
            }
            return canDelete;
        }

        /// <summary>
        /// prevent erasing items in used in any order
        /// </summary>
        public async void lockOrUnlockedOrder_itemItems(List<Order_itemModel> order_itemModel, bool isLocked = true)
        {
            List<Item> itemToSaveList = new List<Item>();
            foreach (var Order_itemModel in order_itemModel)
            {
                if (isLocked)
                    Order_itemModel.ItemModel.TxtErasable = EItem.No.ToString();
                else
                {
                    // checking that the item is not in used in any order
                    var order_itemWithThisItemList = Bl.BlOrder.searchOrder_item(new Order_item { Item_ref = Order_itemModel.TxtItem_ref }, ESearchOption.AND);
                    if (order_itemWithThisItemList.Count == 0)
                        Order_itemModel.ItemModel.TxtErasable = EItem.Yes.ToString();
                }
                itemToSaveList.Add(Order_itemModel.ItemModel.Item);
            }
            await Bl.BlItem.UpdateItemAsync(itemToSaveList);
        }

        /// <summary>
        /// convert the order into credit
        /// </summary>
        /// <param name="isReset"></param>
        private List<Order_item> createOrResetCredit(List<Order_itemModel> order_itemModelList)
        {
            foreach (Order_itemModel order_itemModel in order_itemModelList)
            {
                order_itemModel.Order = OrderSelected.Order;
                order_itemModel.calcul();
            }
            return Order_ItemModelList.Select(x => x.Order_Item).ToList();
        }

        private Task<Order_item> updateOrder_item(Order_itemModel order_itemModel)
        {
            return Task.Factory.StartNew(() =>
            {
                int quantityReceived = Utility.intTryParse(order_itemModel.TxtQuantity_received);
                int quantity = order_itemModel.Order_Item.Quantity;
                int quantityDelivery = order_itemModel.Order_Item.Quantity_delivery;
                int quantityCurrent = order_itemModel.Order_Item.Quantity_current;

                if (quantityReceived > 0)
                {
                    int quentityPending = quantity - (quantityDelivery + quantityReceived);
                    if (quentityPending >= 0)
                    {
                        // Checking that the number of received items matches the expected number
                        if (quantityReceived > (quantity - quantityDelivery))
                            quantityReceived = (quantity - quantityDelivery);

                        // checking that the number of received items is not greater than the stock
                        if (quantityReceived > order_itemModel.ItemModel.Item.Stock)
                            quantityReceived = order_itemModel.ItemModel.Item.Stock;

                        quantityDelivery += quantityReceived;
                        quantityCurrent += quantityReceived;
                        order_itemModel.Order_Item.Quantity_current = quantityCurrent;
                        order_itemModel.Order_Item.Quantity_delivery = quantityDelivery;

                    }
                }
                order_itemModel.TxtQuantity_received = 0.ToString();

                return order_itemModel.Order_Item;
            });
        }

        /// <summary>
        /// delete an invoice and items stock update
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isLastest"></param>
        /// <returns></returns>
        private async Task<bool> deleteInvoice(BillModel obj, bool isLastest = false)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);

            bool isInvoiceDeleted = false;

            if (isLastest || await checkIfLastBillAsync(obj.Bill, offset: 0))
            {
                List<Bill> billToDelteList = new List<Bill>();
                List<Delivery> deliveryToUpdateList = new List<Delivery>();

                // Getting the delivery ID for processing
                var deliveryModelList = (from c in Order_ItemModelList
                                         from d in c.ItemModel.Item_deliveryModelList
                                         where d.DeliveryModel.TxtBillId == obj.TxtID
                                                 && d.DeliveryModel.TxtStatus == EOrderStatus.Billed.ToString()
                                         select d.DeliveryModel).ToList();

                foreach (var deliveryModel in deliveryModelList)
                {
                    deliveryModel.TxtStatus = EOrderStatus.Not_Billed.ToString();
                    deliveryModel.Delivery.BillId = 0;
                    deliveryToUpdateList.Add(deliveryModel.Delivery);
                }

                // invoice delettion
                var InvoiceDeletionFaildList = await Bl.BlOrder.DeleteBillAsync(new List<Bill> { obj.Bill });

                var updatedDeliveryList = await Bl.BlOrder.UpdateDeliveryAsync(deliveryToUpdateList);
                if (updatedDeliveryList.Count == 0 && deliveryToUpdateList.Count > 0)
                {
                    string errorMessage = "Error occurred while deleting the invoice (ID=" + obj.TxtID + ").";
                    Log.error(errorMessage, EErrorFrom.ORDER);
                    await Singleton.getDialogueBox().showAsync(errorMessage);
                }

                // deleting the related statistics
                var statisticsFoundList = await Bl.BlStatisitc.searchStatisticAsync(new Statistic { BillId = obj.Bill.ID }, ESearchOption.AND);
                if (statisticsFoundList.Count > 0)
                    await Bl.BlStatisitc.DeleteStatisticAsync(new List<Statistic> { statisticsFoundList[0] });

                // delete the invoice notification information
                var NotificationFoundList = await Bl.BlNotification.searchNotificationAsync(new Notification { BillId = obj.Bill.ID }, ESearchOption.AND);
                if (NotificationFoundList.Count > 0)
                    await Bl.BlNotification.DeleteNotificationAsync(NotificationFoundList);

                // remove the deleted invoice from the list 
                BillModel billModelToRemove = BillModelList.Where(x => x.Bill.ID == obj.Bill.ID).FirstOrDefault();
                if (billModelToRemove != null)
                    BillModelList.Remove(billModelToRemove);

                if (InvoiceDeletionFaildList.Count == 0)
                    isInvoiceDeleted = true;
            }
            else
                await Singleton.getDialogueBox().showAsync("Deletion Failed! Order's invoice is not the latest.");

            Singleton.getDialogueBox().IsDialogOpen = false;

            return isInvoiceDeleted;
        }



        /// <summary>
        /// fire the IU data refresh events
        /// </summary>
        private void updateStepBinding()
        {
            onPropertyChange("BlockStepOneVisibility");
            onPropertyChange("BlockStepTwoVisibility");
            onPropertyChange("BlockStepThreeVisibility");
        }

        /// <summary>
        /// fire the IU data refresh events
        /// </summary>
        private void refreshBindingByCallingPropertyChange()
        {
            onPropertyChange("Order_ItemModelList");
            onPropertyChange("Item_deliveryModelCreatedList");
            onPropertyChange("Item_ModelDeliveryInProcess");
            onPropertyChange("Item_deliveryModelBillingInProcess");
        }

        /// <summary>
        /// fire the IU data refresh events
        /// </summary>
        private void updateItemListBindingByCallingPropertyChange()
        {
            onPropertyChange("IsItemListCommentTextBoxEnabled");
            onPropertyChange("IsItemListQuantityTextBoxEnable");
        }

        /// <summary>
        /// fire the IU data refresh events
        /// </summary>
        private void updateStatisticsByCallingPropertyChange()
        {
            onPropertyChange("TxtTotalTaxAmount");
            onPropertyChange("TxtTotalIncome");
            onPropertyChange("TxtTotalTaxExcluded");
            onPropertyChange("TxtTotalTaxIncluded");
            onPropertyChange("TxtTotalIncomePercent");
            onPropertyChange("TxtTotalPurchase");
            onPropertyChange("TxtTaxValue");
        }

        /// <summary>
        /// unsuscribe events and dispose
        /// </summary>
        public override void Dispose()
        {
            PropertyChanged -= onOrder_itemModelWorkFlowChange;
            _updateOrderStatusTask.PropertyChanged -= onInitializationTaskComplete_UpdateOrderStatus;

            foreach (Order_itemModel order_itemModel in Order_ItemModelList)
            {
                order_itemModel.PropertyChanged -= onQuantityOrPriceChange;
                order_itemModel.Dispose();
            }

            foreach (Item_deliveryModel item_deliveryModel in Item_deliveryModelBillingInProcess)
            {
                item_deliveryModel.PropertyChanged -= onItem_ModelDeliveryInProcessIselectedChanged;
                item_deliveryModel.Dispose();
            }

            Bl.BlOrder.Dispose();
        }

        #endregion

        #region [ Event Handler ]
        //----------------------------[ Event Handler ]------------------

        /// <summary>
        /// event listener to calculate the total amount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onQuantityOrPriceChange(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "TxtQuantity") || string.Equals(e.PropertyName, "TxtPrice") || string.Equals(e.PropertyName, "TxtPrice_purchase"))
                StatisticModel = totalCalcul(Order_ItemModelList);
        }

        /// <summary>
        /// event listener to update the binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onOrder_itemModelWorkFlowChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Item_ModelDeliveryInProcess")
                || e.PropertyName.Equals("Item_deliveryModelBillingInProcess")
                || e.PropertyName.Equals("BillModelList"))
            {
                updateStepBinding();
            }
        }

        /// <summary>
        /// event listener to update the order status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onInitializationTaskComplete_UpdateOrderStatus(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsSuccessfullyCompleted"))
            {
                if (_updateOrderStatusTask.Result)
                {
                    string oldStatus = OrderSelected.TxtStatus;
                    OrderSelected.TxtStatus = _orderNewStatus.ToString();
                    OrderSelected.Order.Date = DateTime.Now;
                    var savedOrderList = await Bl.BlOrder.UpdateOrderAsync(new List<Entity.Order> { { OrderSelected.Order } });
                    if (savedOrderList.Count > 0 && oldStatus != OrderSelected.TxtStatus)
                    {
                        OrderSelected.Order = savedOrderList[0];
                        createOrResetCredit(Order_ItemModelList);
                        await Singleton.getDialogueBox().showAsync(oldStatus + " successfully Converted to " + OrderSelected.TxtStatus);
                        loadEmail();

                        // recalcul the order statistics
                        StatisticModel = totalCalcul(Order_ItemModelList);

                        _page(this);
                    }
                    else
                    {
                        string errorMessage = "Convertion from " + oldStatus + " to " + _orderNewStatus + " Failed! - ID [" + OrderSelected.TxtID + "]";
                        Log.error(errorMessage, EErrorFrom.ORDER);
                        await Singleton.getDialogueBox().showAsync(errorMessage);
                    }

                }
                else
                    await Singleton.getDialogueBox().showAsync("Convertion to " + _orderNewStatus + " Failed! " +
                        Environment.NewLine + "Please make sure that this order bill is the latest.");
                Singleton.getDialogueBox().IsDialogOpen = false;
            }
            else if (e.PropertyName.Equals("Exception"))
            {
                Singleton.getDialogueBox().IsDialogOpen = false;
                Singleton.getDialogueBox().showSearch("Oops! an error occurred while processing your request." +
                    Environment.NewLine + "Please contact your administrator.");
                Log.error("Error while updating the order(ID=+" + OrderSelected.TxtID + ") from " + OrderSelected.TxtStatus + "" + _orderNewStatus.ToString(), EErrorFrom.ORDER);
            }

        }

        /// <summary>
        /// when one item of a delivery receipt is selected 
        /// then select all items of the delivery receipt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onItem_ModelDeliveryInProcessIselectedChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsSelected"))
            {
                foreach (var item_deliveryModel in Item_deliveryModelBillingInProcess.Where(x => x.Item_delivery.DeliveryId == ((Item_deliveryModel)sender).Item_delivery.DeliveryId).ToList())
                    item_deliveryModel.updateIselected(((Item_deliveryModel)sender).IsSelected);
                refreshBindings();
            }
        }

        private void onCurrencyChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrencyModel"))
            {
                OrderSelected.CurrencyModel = CurrencyModel;
                onPropertyChange("Order_ItemModelList");
            }
        }

        #endregion

        #region [ Actions Command ]

        //----------------------------[ Action Command ]------------------

        /// <summary>
        /// update the order items
        /// </summary>
        /// <param name="obj"></param>
        private async void updateOrder_itemData(string obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
            List<Order_item> Order_itemToSave = new List<Order_item>();
            foreach (var newOrder_itemModel in Order_ItemModelList)
            {
                if (await _main.ItemViewModel.checkIfStockAvailable(newOrder_itemModel))
                {
                    if (Utility.intTryParse(newOrder_itemModel.TxtQuantity_received) == 0)
                        newOrder_itemModel.TxtQuantity_received = (newOrder_itemModel.Order_Item.Quantity - newOrder_itemModel.Order_Item.Quantity_delivery).ToString();
                }

                Order_itemToSave.Add(await updateOrder_item(newOrder_itemModel));
            }

            var savedOrder_itemList = await Bl.BlOrder.UpdateOrder_itemAsync(Order_itemToSave);

            BilledCommand.raiseCanExecuteActionChanged();
            refreshBindingByCallingPropertyChange();
            refreshBindings();
            Singleton.getDialogueBox().IsDialogOpen = false;
            _page(this);
        }

        /// <summary>
        /// check that all requirements are respected in order to update the order items
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canUpdateOrder_itemData(string arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (!isUpdate)
                return false;

            if (string.IsNullOrEmpty(OrderSelected.TxtStatus))
                return false;

            if (!OrderSelected.TxtStatus.Equals(EOrderStatus.Order.ToString())
                && !OrderSelected.TxtStatus.Equals(EOrderStatus.Quote.ToString())
                && !OrderSelected.TxtStatus.Equals(EOrderStatus.Credit.ToString())
                && !OrderSelected.TxtStatus.Equals(EOrderStatus.Pre_Order.ToString())
                && !OrderSelected.TxtStatus.Equals(EOrderStatus.Pre_Credit.ToString()))
                return false;

            return true;
        }

        /// <summary>
        /// delete one item from the order
        /// </summary>
        /// <param name="obj"></param>
        private async void deleteItem(Order_itemModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);
            await Bl.BlOrder.DeleteOrder_itemAsync(new List<Order_item> { obj.Order_Item });
            Order_ItemModelList.Remove(obj);

            // refresh binding
            onPropertyChange("Order_ItemModelList");

            Singleton.getDialogueBox().IsDialogOpen = false;
            _page(this);
        }

        /// <summary>
        /// check that all requirements are respected in order to delete one item from the order
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canDeleteItem(Order_itemModel arg)
        {
            // prevent deletion if deletion right not allowed
            bool isDelete = _main.securityCheck(EAction.Order, ESecurity._Delete);
            if (!isDelete)
                return false;

            // prevent item deletion if delivery process has started
            if (Item_ModelDeliveryInProcess.Count != 0
                || Item_deliveryModelBillingInProcess.Count != 0
                || OrderSelected.BillModelList.Count != 0)
                return false;

            // if order different from quote status prevent item deletion
            if (OrderSelected == null
                || OrderSelected.TxtStatus == null
                || !OrderSelected.TxtStatus.Equals(EOrderStatus.Quote.ToString()))
                return false;

            return true;
        }

        /// <summary>
        /// generate the pdf document of the delivery receipt
        /// </summary>
        /// <param name="obj"></param>
        private void generateDeliveryReceiptPdf(DeliveryModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["create_message"]);
            _paramDeliveryToPdf.OrderId = OrderSelected.Order.ID;
            _paramDeliveryToPdf.DeliveryId = obj.Delivery.ID;
            Bl.BlOrder.GeneratePdfDelivery(_paramDeliveryToPdf);
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all requirements are respected in order to generate the pdf document
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canGenerateDeliveryReceiptPdf(DeliveryModel arg)
        {
            return true;
        }

        /// <summary>
        /// create a delivery receipt
        /// </summary>
        /// <param name="obj"></param>
        public async void createDeliveryReceipt(Order_itemModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["create_message"]);
            int first = 0;
            List<Delivery> insertNewDeliveryList = new List<Delivery>();
            List<Delivery> savedDeliveryList = new List<Delivery>();
            List<Order_item> Order_itemListToUpdate = new List<Order_item>();

            foreach (var item_deliveryModel in Item_ModelDeliveryInProcess)
            {
                if (item_deliveryModel.TxtQuantity_current != 0.ToString())
                {
                    if (first == 0)
                    {
                        // creation of the delivery receipt
                        Delivery delivery = new Delivery();
                        delivery.OrderId = OrderSelected.Order.ID;
                        delivery.Date = DateTime.Now;
                        delivery.Status = EOrderStatus.Not_Billed.ToString();
                        delivery.Package = item_deliveryModel.DeliveryModel.Delivery.Package;
                        insertNewDeliveryList.Add(delivery);
                        savedDeliveryList = await Bl.BlOrder.InsertDeliveryAsync(insertNewDeliveryList);
                        first++;
                    }

                    // creation of the reference of the delivery created inside item_delivery
                    if (savedDeliveryList.Count > 0)
                    {
                        item_deliveryModel.Item_delivery.DeliveryId = savedDeliveryList[0].ID;
                        var savedItem_deliveryList = await Bl.BlItem.InsertItem_deliveryAsync(new List<Item_delivery> { item_deliveryModel.Item_delivery });

                        var Order_itemModelFound = (from c in Order_ItemModelList
                                                    where c.ItemModel.Item.ID == item_deliveryModel.ItemModel.Item.ID && c.ItemModel.Item.Ref == item_deliveryModel.ItemModel.TxtRef
                                                    select c).FirstOrDefault();

                        if (savedItem_deliveryList.Count > 0 && Order_itemModelFound != null)
                        {
                            Order_itemModelFound.Order_Item.Quantity_current = 0;
                            Order_itemModelFound.ItemModel.Item_deliveryModelList.Add(savedItem_deliveryList.Select(x => new Item_deliveryModel { Item_delivery = x, DeliveryModel = new DeliveryModel { Delivery = savedDeliveryList[0] } }).FirstOrDefault());
                            Order_itemListToUpdate.Add(Order_itemModelFound.Order_Item);
                        }
                    }
                }
            }
            var savedOrder_itemList = await Bl.BlOrder.UpdateOrder_itemAsync(Order_itemListToUpdate);
            refreshBindings();
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all requirements are respected in order to create a delivery receipt
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canCreateDeliveryReceipt(Order_itemModel arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (isUpdate)
                return true;

            return false;
        }

        /// <summary>
        /// remove the delivery receipt from the list of delivery in process
        /// </summary>
        /// <param name="obj">the delivery receipt to process</param>
        private async void deleteDeliveryReceiptInProcess(Item_deliveryModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);

            var Order_itemFound = (from c in Order_ItemModelList
                                   where c.ItemModel.Item.Ref == obj.ItemModel.TxtRef && c.ItemModel.Item.ID == obj.ItemModel.Item.ID
                                   select c).FirstOrDefault();

            if (Order_itemFound != null)
            {
                // cancelling the receiption of items
                Order_itemFound.Order_Item.Quantity_delivery = Math.Max(0, Order_itemFound.Order_Item.Quantity_delivery - Order_itemFound.Order_Item.Quantity_current);
                Order_itemFound.Order_Item.Quantity_current = 0;
                var Order_itemSavedList = await Bl.BlOrder.UpdateOrder_itemAsync(new List<Order_item> { Order_itemFound.Order_Item });

                // remove the delivery receipt.
                Item_ModelDeliveryInProcess.Remove(obj);

                // update the bindings
                refreshBindingByCallingPropertyChange();
                refreshBindings();
            }
            _page(this);
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all requirements are respected in order to delete the deleivery receipt in process
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canCancelDeliveryReceiptInProcess(Item_deliveryModel arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (isUpdate)
                return true;

            return false;
        }

        /// <summary>
        /// delete on delivery receipt of the order
        /// </summary>
        /// <param name="obj">the delivery receipt to process</param>
        private async void cancelDeliveryReceiptCreated(Item_deliveryModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);

            // Searching the targeting item for processing
            var Order_itemModelTargeted = (from c in Order_ItemModelList
                                           from d in c.ItemModel.Item_deliveryModelList
                                           where d.Item_delivery.DeliveryId == obj.DeliveryModel.Delivery.ID
                                                 && d.TxtItem_ref == obj.TxtItem_ref
                                           select c).FirstOrDefault();

            // getting the previous delivery receipt of the targeted item
            var item_deliveryModelPrevious = (from c in Order_ItemModelList
                                              from d in c.ItemModel.Item_deliveryModelList
                                              where d.Item_delivery.DeliveryId < obj.DeliveryModel.Delivery.ID
                                                      && d.Item_delivery.Quantity_delivery < obj.Item_delivery.Quantity_delivery
                                                      && d.TxtItem_ref == obj.TxtItem_ref
                                              orderby d.Item_delivery.DeliveryId descending
                                              select d.Item_delivery).FirstOrDefault();

            if (Order_itemModelTargeted != null && Order_itemModelTargeted.TxtQuantity_pending != Order_itemModelTargeted.TxtQuantity)
            {
                // calcul of the quantity delivery for resetting
                int quantityDelivery = obj.Item_delivery.Quantity_delivery - (item_deliveryModelPrevious != null ? item_deliveryModelPrevious.Quantity_delivery : 0);

                // push this item back to delivery creation list
                Order_itemModelTargeted.Order_Item.Quantity_current += quantityDelivery;
                Order_itemModelTargeted.ItemModel.Item_deliveryModelList.Remove(obj);
                var savedOrder_itemList = await Bl.BlOrder.UpdateOrder_itemAsync(new List<Order_item> { Order_itemModelTargeted.Order_Item });

                // deldete any delivery receipt regarding this item
                await Bl.BlOrder.DeleteDeliveryAsync(new List<Delivery> { obj.DeliveryModel.Delivery });
                await Bl.BlItem.DeleteItem_deliveryAsync(new List<Item_delivery> { obj.Item_delivery });
            }

            // otherwise delete any delivery receipt created by mistake
            else
            {
                Order_itemModelTargeted.ItemModel.Item_deliveryModelList.Remove(obj);
                await Bl.BlOrder.DeleteDeliveryAsync(new List<Delivery> { obj.DeliveryModel.Delivery });
                await Bl.BlItem.DeleteItem_deliveryAsync(new List<Item_delivery> { obj.Item_delivery });
            }

            refreshBindingByCallingPropertyChange();
            refreshBindings();
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all requirements are respected in order to delete the delivery's receipt
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canCancelDeliveryReceiptCreated(Item_deliveryModel arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (!isUpdate)
                return false;

            if (arg != null)
            {
                var item_deliveryModelList = from c in Order_ItemModelList
                                             from d in c.ItemModel.Item_deliveryModelList
                                             where d.TxtItem_ref == arg.TxtItem_ref
                                             orderby d.Item_delivery.Quantity_delivery descending
                                             select d.Item_delivery;

                if (item_deliveryModelList.Where(x => x.Quantity_delivery > arg.Item_delivery.Quantity_delivery).Count() > 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// create one invoice of the order
        /// </summary>
        /// <param name="obj"></param>
        private async void createInvoice(Order_itemModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["create_message"]);

            List<Bill> invoiceSavedList = new List<Bill>();
            var Order_itemInProcess = new List<Order_itemModel>();
            Client searchClient = new Client();
            decimal totalInvoiceAmount = 0m;

            // Limit date of payment Calculation
            searchClient.ID = OrderSelected.CLientModel.Client.ID;
            var foundClients = Bl.BlClient.searchClient(searchClient, ESearchOption.AND);
            int payDelay = (foundClients.Count > 0) ? foundClients[0].PayDelay : 0;
            DateTime expire = DateTime.Now.AddDays(payDelay);

            int first = 0;

            List<Item_deliveryModel> item_deliveryModelToRemoveList = new List<Item_deliveryModel>();

            foreach (var item_deliveryModel in _item_deliveryModelBillingInProcessList)
            {
                if (item_deliveryModel.IsSelected)
                {
                    // search of the last inserted bill 
                    Bill lastInvoice = (await Bl.BlOrder.GetLastBillAsync()) ?? new Bill();

                    if (first == 0)
                    {
                        // Manual incrementation of the bill ID 
                        // to make sure that the IDs follow each others                      
                        int billId = lastInvoice.ID + 1;
                        Bill invoice = new Bill();
                        invoice.ID = billId;
                        invoice.OrderId = OrderSelected.Order.ID;
                        invoice.ClientId = OrderSelected.Order.ClientId;
                        invoice.Date = DateTime.Now;
                        invoice.DateLimit = expire;
                        invoice.PayReceived = 0m;

                        // Bill creation
                        invoiceSavedList = await Bl.BlOrder.InsertBillAsync(new List<Bill> { invoice });
                        first = 1;
                    }

                    // Update of delivery bill status
                    if (invoiceSavedList.Count > 0)
                    {
                        Order_itemInProcess = Order_ItemModelList.Where(x => x.TxtItem_ref == item_deliveryModel.TxtItem_ref).ToList();

                        var deliveryModelFoundList = (from o in Order_itemInProcess
                                                      from i in o.ItemModel.Item_deliveryModelList
                                                      where i.DeliveryModel.Delivery.ID == item_deliveryModel.DeliveryModel.Delivery.ID
                                                             && i.DeliveryModel.TxtStatus == EOrderStatus.Not_Billed.ToString()
                                                      select i.DeliveryModel).ToList();

                        foreach (DeliveryModel deliveryModel in deliveryModelFoundList)
                        {
                            if (deliveryModel != null)
                            {
                                deliveryModel.Delivery.Status = EOrderStatus.Billed.ToString();
                                deliveryModel.Delivery.BillId = invoiceSavedList[0].ID;
                                var savedDeliveryList = await Bl.BlOrder.UpdateDeliveryAsync(new List<Delivery> { deliveryModel.Delivery });

                                if (savedDeliveryList.Count > 0)
                                    deliveryModel.Delivery = savedDeliveryList[0];
                            }
                        }
                        if (Order_itemInProcess.Count > 0)
                            totalInvoiceAmount += Order_itemInProcess[0].Order_Item.Price * item_deliveryModel.Item_delivery.Quantity_delivery;

                        item_deliveryModelToRemoveList.Add(item_deliveryModel);
                    }
                }
            }

            var invoicelFound = Bl.BlOrder.searchBill(new Bill { ID = invoiceSavedList[0].ID }, ESearchOption.AND).FirstOrDefault();

            if (first == 1)
            {
                // update of the invoice amount                
                if (invoicelFound != null)
                {
                    invoicelFound.Pay = totalInvoiceAmount;
                    invoicelFound.DatePay = DateTime.Now;
                    var savedInvoice = await Bl.BlOrder.UpdateBillAsync(new List<Bill> { invoicelFound });
                }
            }

            // calcul and  creating the statistics              
            var order_itemFoundList = Order_ItemModelList.GroupBy(x => x.TxtItem_ref).Select(x => x.First()).Where(x => x.ItemModel.Item_deliveryModelList.Where(y => y.DeliveryModel.Delivery.BillId == invoicelFound.ID).Count() > 0).ToList();
            if (order_itemFoundList.Count > 0)
            {
                StatisticModel statisticModel = (StatisticModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.STATISTIC);
                statisticModel = totalCalcul(order_itemFoundList);
                statisticModel.Statistic.Bill_datetime = invoicelFound.Date;
                statisticModel.Statistic.Date_limit = invoicelFound.DateLimit;
                statisticModel.Statistic.BillId = (invoicelFound != null) ? invoicelFound.ID : 0;
                statisticModel.TxtCompanyName = (!string.IsNullOrEmpty(OrderSelected.CLientModel.TxtCompany)) ? OrderSelected.CLientModel.TxtCompany : OrderSelected.CLientModel.TxtCompanyName;

                // statistics saving
                var savedstatisticsList = await Bl.BlStatisitc.InsertStatisticAsync(new List<Statistic> { statisticModel.Statistic });
            }

            // create the invoice notification
            await Bl.BlNotification.InsertNotificationAsync(new List<Notification> { new Notification { BillId = invoicelFound.ID, Reminder1 = default(DateTime), Reminder2 = default(DateTime) } });

            // removing processed item from the Qeue
            foreach (var item_deliveryModel in item_deliveryModelToRemoveList)
                _item_deliveryModelBillingInProcessList.Remove(item_deliveryModel);

            // update item stock
            //await _main.ItemViewModel.updateStockAsync(Order_ItemModelList);

            refreshBindings();
            Singleton.getDialogueBox().IsDialogOpen = false;

            // once the invoice created, enable the email sending
            SendEmailCommand.raiseCanExecuteActionChanged();
        }


        /// <summary>
        /// check that all requirements are respected in order to create an invoice
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canCreateBill(Order_itemModel arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (isUpdate)
                return true;

            if (Item_deliveryModelBillingInProcess.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// delete one of the order created invoice
        /// </summary>
        /// <param name="obj">the invoice to process</param>
        private async void deleteCreatedInvoice(BillModel obj)
        {
            if (await Singleton.getDialogueBox().showAsync("do you really want to delete this invoice (" + obj.TxtID + ")"))
            {
                // delete the targeted invoice
                await deleteInvoice(obj);

                // refresh the User Interface
                refreshBindings();

                // once the invoice deleted disable the email sending
                SendEmailCommand.raiseCanExecuteActionChanged();
            }
        }

        /// <summary>
        /// check that all the requirements are respeceted in order to delete an invoice
        /// </summary>
        /// <param name="arg">the invoice to process</param>
        /// <returns></returns>
        private bool canCancelCreatedInvoice(BillModel arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (!isUpdate)
                return false;

            if (!(arg != null && BillModelList.Count > 0 && BillModelList.OrderByDescending(x => x.Bill.ID).First().Bill.ID <= arg.Bill.ID))
                return false;

            return true;
        }

        /// <summary>
        /// update the item list information
        /// </summary>
        /// <param name="obj"></param>
        private async void updateInvoice(BillModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
            var savedBillList = await Bl.BlOrder.UpdateBillAsync(new List<Bill> { obj.Bill });
            if (savedBillList.Count > 0)
            {
                var statisticsFoundList = await Bl.BlStatisitc.searchStatisticAsync(new Statistic { BillId = savedBillList[0].ID }, ESearchOption.AND);
                if (statisticsFoundList.Count > 0)
                {
                    var order_itemFoundList = Order_ItemModelList.GroupBy(x => x.TxtItem_ref).Select(x => x.First()).Where(x => x.ItemModel.Item_deliveryModelList.Where(y => y.DeliveryModel.Delivery.BillId == savedBillList[0].ID).Count() > 0).ToList();
                    StatisticModel statisticModel = totalCalcul(order_itemFoundList);

                    statisticsFoundList[0].Date_limit = statisticModel.Statistic.Date_limit;
                    statisticsFoundList[0].Bill_datetime = statisticModel.Statistic.Bill_datetime;
                    statisticsFoundList[0].Pay_date = statisticModel.Statistic.Pay_date;
                    statisticsFoundList[0].Pay_received = statisticModel.Statistic.Pay_received;
                    statisticsFoundList[0].Price_purchase_total = statisticModel.Statistic.Price_purchase_total;
                    statisticsFoundList[0].Tax_value = statisticModel.Statistic.Tax_value;
                    statisticsFoundList[0].Total = statisticModel.Statistic.Total;
                    statisticsFoundList[0].Total_tax_included = statisticModel.Statistic.Total_tax_included;

                    var savedStatisticsList = await Bl.BlStatisitc.UpdateStatisticAsync(new List<Statistic> { statisticsFoundList[0] });
                }
            }
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        private bool canUpdateInvoice(BillModel arg)
        {
            return true;
        }

        /// <summary>
        /// generate the order bill pdf document
        /// </summary>
        /// <param name="obj"></param>
        private void generateOrderBillPdf(BillModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["create_message"]);
            _paramOrderToPdf.ParamEmail = new ParamEmail();
            _paramOrderToPdf.BillId = obj.Bill.ID;
            _paramOrderToPdf.OrderId = OrderSelected.Order.ID;
            Bl.BlOrder.GeneratePdfOrder(_paramOrderToPdf);
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all the requirements are respecred in order to generate the invoice
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canGenerateOrderBillPdf(BillModel arg)
        {
            return true;
        }

        /// <summary>
        /// generate the quote
        /// </summary>
        /// <param name="obj"></param>
        private void generateQuotePdf(object obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["create_message"]);
            _paramQuoteToPdf.ParamEmail = new ParamEmail();
            _paramQuoteToPdf.OrderId = OrderSelected.Order.ID;
            Bl.BlOrder.GeneratePdfQuote(_paramQuoteToPdf);
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all the requirements are respecred in order to generate the quote
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canGenerateQuotePdf(object arg)
        {
            return true;
        }

        /// <summary>
        /// close the order
        /// </summary>
        /// <param name="obj"></param>
        private async void orderBilling(object obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["create_message"]);

            if (OrderSelected.TxtStatus.Equals(EOrderStatus.Order.ToString()))
            {
                updateOrderStatus(EOrderStatus.Bill_Order);
                if (OrderSelected.TxtStatus.Equals(EOrderStatus.Bill_Order.ToString()))
                {
                    // update item stock
                    await _main.ItemViewModel.updateStockAsync(Order_ItemModelList);

                    await Singleton.getDialogueBox().showAsync("Billing Completed Successfully!");
                    _page(this);
                }
            }
            else if (OrderSelected.TxtStatus.Equals(EOrderStatus.Credit.ToString()))
            {
                updateOrderStatus(EOrderStatus.Bill_Credit);
                if (OrderSelected.TxtStatus.Equals(EOrderStatus.Bill_Credit.ToString()))
                {
                    await Singleton.getDialogueBox().showAsync("Credit Billing Completed Successfully!");
                    _page(this);
                }
            }

            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all the requirements are respecred in order to close the order
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canBillOrder(object arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order_Billed, ESecurity._Update) && _main.securityCheck(EAction.Order_Billed, ESecurity._Update);
            bool isWrite = _main.securityCheck(EAction.Order_Billed, ESecurity._Write);
            if (!isUpdate || !isWrite)
                return false;

            if (Order_ItemModelList != null)
            {
                bool isValid = true;
                foreach (var order_itemModel in Order_ItemModelList)
                {
                    if (Utility.intTryParse(order_itemModel.TxtQuantity_pending) > 0)
                        isValid = false;
                }
                return isValid;
            }

            return false;
        }

        /// <summary>
        /// select the client delivery address
        /// </summary>
        /// <param name="obj"></param>
        private async void selectDeliveryAddress(Address obj)
        {
            if (obj != null)
            {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
                OrderSelected.Order.DeliveryAddress = obj.ID;
                var savedOrderList = await Bl.BlOrder.UpdateOrderAsync(new List<Entity.Order> { OrderSelected.Order });
                if (savedOrderList.Count > 0)
                {
                    var deliveryAddressFoundList = OrderSelected.AddressList.Where(x => x.ID == savedOrderList[0].DeliveryAddress).ToList();
                    OrderSelected.DeliveryAddress = (deliveryAddressFoundList.Count() > 0) ? deliveryAddressFoundList[0] : new Address();
                    await Singleton.getDialogueBox().showAsync("The delivery Address has been updated Successfully!");
                }
                Singleton.getDialogueBox().IsDialogOpen = false;
            }
        }

        /// <summary>
        /// check that all the requirements are respecred in order select the address
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canSelectDeliveryAddress(Address arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (isUpdate)
                return true;

            return false;
        }

        private async void selectBillingAddress(Address obj)
        {
            if (obj != null)
            {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
                OrderSelected.Order.BillAddress = obj.ID;
                var savedOrderList = await Bl.BlOrder.UpdateOrderAsync(new List<Entity.Order> { OrderSelected.Order });
                if (savedOrderList.Count > 0)
                {
                    var billAddressFoundList = OrderSelected.AddressList.Where(x => x.ID == savedOrderList[0].BillAddress).ToList();
                    OrderSelected.BillAddress = (billAddressFoundList.Count() > 0) ? billAddressFoundList.First() : new Address();
                    await Singleton.getDialogueBox().showAsync("The billing Address has been updated Successfully!");
                }
                Singleton.getDialogueBox().IsDialogOpen = false;
            }
        }

        private bool canSelectBillingAddress(Address arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (isUpdate)
                return true;

            return false;
        }

        /// <summary>
        /// set the order tax value
        /// </summary>
        /// <param name="obj">the tax value to process</param>
        private async void createOrderTax(Tax obj)
        {
            if (obj != null)
            {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
                OrderSelected.Tax = obj;

                if (OrderSelected.Tax_orderModel.Tax_order.ID == 0)
                    await Bl.BlOrder.InsertTax_orderAsync(new List<Tax_order> { OrderSelected.Tax_orderModel.Tax_order });
                else
                    await Bl.BlOrder.UpdateTax_orderAsync(new List<Tax_order> { OrderSelected.Tax_orderModel.Tax_order });

                await Bl.BlOrder.UpdateOrderAsync(new List<Order> { OrderSelected.Order });

                // update the statistics
                StatisticModel = totalCalcul(Order_ItemModelList);

                Singleton.getDialogueBox().IsDialogOpen = false;
            }
        }

        /// <summary>
        /// check that all the requirements are respecred in order set a new tax value
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canCreateOrderTax(Tax arg)
        {
            bool isUpdate = _main.securityCheck(EAction.Order, ESecurity._Update);
            if (isUpdate)
                return true;

            return false;
        }

        private async void createOrderCurrency(CurrencyModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
            CurrencyModel = obj;
            OrderSelected.CurrencyModel = CurrencyModel;
            OrderSelected.Order.CurrencyId = CurrencyModel.Currency.ID;
            await Bl.BlOrder.UpdateOrderAsync(new List<Order> { OrderSelected.Order });

            Singleton.getDialogueBox().IsDialogOpen = false;
            _main.appNavig("refresh");
        }

        private bool canCreateOrderCurrency(CurrencyModel arg)
        {
            return true;
        }

        /// <summary>
        /// email the quote or order bill to the client
        /// </summary>
        /// <param name="obj">the invoice to process</param>
        private async void sendEmail(BillModel obj)
        {
            if (await Singleton.getDialogueBox().showAsync("Confirme sending email!"))
            {
                var paramEmail = new ParamEmail();
                paramEmail.IsCopyToAgent = await Singleton.getDialogueBox().showAsync("Do you want to receive a copy of the email?");

                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["wait_message"]);

                paramEmail.Subject = EmailFile.TxtSubject;
                paramEmail.IsSendEmail = true;

                // sending quote email to the client 
                if (EmailFile.TxtFileNameWithoutExtension.Equals("quote"))
                {
                    _paramQuoteToPdf.ParamEmail = paramEmail;
                    _paramQuoteToPdf.OrderId = OrderSelected.Order.ID;
                    Bl.BlOrder.GeneratePdfQuote(_paramQuoteToPdf);
                }

                // sending order email to client
                else
                {
                    _paramOrderToPdf.BillId = obj.Bill.ID;
                    _paramOrderToPdf.OrderId = OrderSelected.Order.ID;

                    var NotificationFoundList = await Bl.BlNotification.searchNotificationAsync(new Notification { BillId = obj.Bill.ID }, ESearchOption.AND);

                    // create a new notification entry for this invoice
                    if (NotificationFoundList.Count == 0)
                        NotificationFoundList = await Bl.BlNotification.InsertNotificationAsync(new List<Notification> { new Notification { BillId = obj.Bill.ID, Reminder1 = default(DateTime), Reminder2 = default(DateTime) } });

                    // update notification

                    if (NotificationFoundList[0].Date <= Utility.DateTimeMinValueInSQL2005)
                    {
                        paramEmail.Reminder = 0;
                        NotificationFoundList[0].Date = DateTime.Now;
                    }
                    else if (NotificationFoundList[0].Reminder1 <= Utility.DateTimeMinValueInSQL2005
                        && NotificationFoundList[0].Reminder2 <= Utility.DateTimeMinValueInSQL2005)
                    {
                        paramEmail.Reminder = 1;
                        NotificationFoundList[0].Reminder1 = DateTime.Now;
                    }
                    else
                    {
                        paramEmail.Reminder = 2;
                        NotificationFoundList[0].Reminder2 = DateTime.Now;
                    }
                    await Bl.BlNotification.UpdateNotificationAsync(NotificationFoundList);


                    _paramOrderToPdf.ParamEmail = paramEmail;
                    Bl.BlOrder.GeneratePdfOrder(_paramOrderToPdf);
                }

                Singleton.getDialogueBox().IsDialogOpen = false;
            }
        }

        /// <summary>
        /// check that all the requirements are respecred in order to send the email
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canSendEmail(BillModel arg)
        {
            bool isSendEmailValidOrder = _main.securityCheck(EAction.Order, ESecurity.SendEmail);
            bool isSendEmailValidPreOrder = _main.securityCheck(EAction.Order_Preorder, ESecurity.SendEmail);
            bool isSendEmailQuote = _main.securityCheck(EAction.Quote, ESecurity.SendEmail);

            if (OrderSelected == null)
                return false;

            if (!isSendEmailValidPreOrder && OrderSelected.TxtStatus.Equals(EOrderStatus.Pre_Order.ToString()))
                return false;

            if (!isSendEmailQuote && OrderSelected.TxtStatus.Equals(EOrderStatus.Quote.ToString()))
                return false;

            if (!isSendEmailValidOrder
                && (OrderSelected.TxtStatus.Equals(EOrderStatus.Order.ToString())
                || OrderSelected.TxtStatus.Equals(EOrderStatus.Credit.ToString())))
                return false;

            if ((BillModelList.Count == 0)
                && (OrderSelected.TxtStatus.Equals(EOrderStatus.Order.ToString())
                || OrderSelected.TxtStatus.Equals(EOrderStatus.Credit.ToString())))
                return false;

            return true;
        }

        /// <summary>
        /// update the comments
        /// </summary>
        /// <param name="obj"></param>
        private async void updateComment(object obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
            var savedOrderList = await Bl.BlOrder.UpdateOrderAsync(new List<QOBDCommon.Entities.Order> { OrderSelected.Order });
            if (savedOrderList.Count > 0)
                await Singleton.getDialogueBox().showAsync("Comment updated successfully!");
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /// <summary>
        /// check that all the requirements are respecred in order update the comments
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool canUpdateComment(object arg)
        {
            return true;
        }

        #endregion

    }

}
