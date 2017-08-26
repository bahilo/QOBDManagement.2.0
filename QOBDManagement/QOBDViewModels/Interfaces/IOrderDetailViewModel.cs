using System.Collections.Generic;
using System.Threading.Tasks;
using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDCommon.Enum;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDModels.Models;
using System.ComponentModel;

namespace QOBDViewModels.Interfaces
{
    public interface IOrderDetailViewModel
    {
        ButtonCommand<Order_itemModel> BillCreationCommand { get; set; }
        ButtonCommand<object> BilledCommand { get; set; }
        ButtonCommand<Address> BillingAddressSelectionCommand { get; set; }
        List<BillModel> BillModelList { get; set; }
        BusinessLogic Bl { get; }
        string BlockBillCreatedVisibility { get; }
        string BlockBillCreationVisibility { get; }
        string BlockBillListBoxVisibility { get; }
        string BlockDeliveryAddressVisiblity { get; }
        string BlockDeliveryListToIncludeVisibility { get; }
        string BlockDeliveryReceiptCreatedVisibility { get; }
        string BlockDeliveryReceiptCreationVisiblity { get; }
        string BlockEmailVisibility { get; }
        string BlockItemListDetailVisibility { get; }
        string BlockStepOneVisibility { get; }
        string BlockStepThreeVisibility { get; }
        string BlockStepTwoVisibility { get; }
        string BlockVisibility { get; }
        string BoxVisibility { get; }
        ButtonCommand<BillModel> CancelBillCreatedCommand { get; set; }
        ButtonCommand<Item_deliveryModel> CancelDeliveryReceiptCreatedCommand { get; set; }
        ButtonCommand<Item_deliveryModel> CancelDeliveryReceiptCreationCommand { get; set; }
        ButtonCommand<CurrencyModel> CurrencyCommand { get; set; }
        CurrencyModel CurrencyModel { get; set; }
        ButtonCommand<Order_itemModel> DeleteItemCommand { get; set; }
        ButtonCommand<Address> DeliveryAddressSelectionCommand { get; set; }
        List<DeliveryModel> DeliveryModelList { get; set; }
        ButtonCommand<Order_itemModel> DeliveryReceiptCreationCommand { get; set; }
        InfoFileWriter EmailFile { get; set; }
        ButtonCommand<DeliveryModel> GenerateDeliveryReceiptCreatedPdfCommand { get; set; }
        ButtonCommand<BillModel> GeneratePdfCreatedBillCommand { get; set; }
        ButtonCommand<object> GeneratePdfCreatedQuoteCommand { get; set; }
        string IntegerOutputStringFormat { get; set; }
        bool IsItemListCommentTextBoxEnabled { get; }
        bool IsItemListQuantityTextBoxEnable { get; }
        bool IsOrderReferencesVisible { get; set; }
        bool IsProForma { get; set; }
        bool IsQuote { get; set; }
        bool IsQuoteReferencesVisible { get; set; }
        List<Item_deliveryModel> Item_deliveryModelBillingInProcess { get; set; }
        List<Item_deliveryModel> Item_deliveryModelBillingInProcessSelectionList { get; }
        List<Item_deliveryModel> Item_deliveryModelCreatedList { get; set; }
        List<Item_deliveryModel> Item_ModelDeliveryInProcess { get; set; }
        OrderModel OrderSelected { get; set; }
        List<Order_itemModel> Order_ItemModelList { get; set; }
        BillModel SelectedBillToSend { get; set; }
        ButtonCommand<BillModel> SendEmailCommand { get; set; }
        StatisticModel StatisticModel { get; set; }
        Tax Tax { get; set; }
        ButtonCommand<Tax> TaxCommand { get; set; }
        string Title { get; set; }
        string TxtQuoteValidityInDays { get; set; }
        string TxtTotalIncome { get; set; }
        string TxtTotalIncomePercent { get; set; }
        string TxtTotalPurchase { get; set; }
        string TxtTotalTaxAmount { get; set; }
        string TxtTotalTaxExcluded { get; set; }
        string TxtTotalTaxIncluded { get; set; }
        ButtonCommand<BillModel> UpdateBillCommand { get; set; }
        ButtonCommand<object> UpdateCommentCommand { get; set; }
        ButtonCommand<string> UpdateOrder_itemListCommand { get; set; }
        NotifyTaskCompletion<bool> _updateOrderStatusTask { get; set; }


        void removeObserver(PropertyChangedEventHandler observerMethode);
        void addObserver(PropertyChangedEventHandler observerMethode);
        List<BillModel> billListToModelViewList(List<Bill> BillList);
        Task<bool> checkIfLastBillAsync(List<BillModel> billModelList);
        Task<bool> checkIfLastBillAsync(Bill bill, int offset);
        void createDeliveryReceipt(Order_itemModel obj);
        void Dispose();
        void load();
        Task loadAsync();
        void loadEmail();
        void loadInvoicesAndDeliveryReceipts();
        ItemModel loadOrder_itemItem(string itemRef, int itemId = 0);
        void loadOrder_items(OrderModel order);
        void lockOrUnlockedOrder_itemItems(List<Order_itemModel> order_itemModel, bool isLocked = true);
        List<Order_itemModel> Order_ItemListToModelViewList(List<Order_item> Order_ItemList);
        void updateOrderStatus(EOrderStatus status);
        Task<bool> updateOrderStatusAsync(EOrderStatus status);
    }
}