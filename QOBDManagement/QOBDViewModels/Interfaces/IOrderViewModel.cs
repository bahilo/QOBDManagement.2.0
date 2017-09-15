using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IOrderViewModel
    {
        string TxtIconColour { get; }
        OrderSearchModel OrderSearchModel { get; }
        string OutputStringFormat { get; }
        string Title { get; }
        ClientModel SelectedClient { get; set; }
        List<Tax> TaxList { get; }
        List<CurrencyModel> CurrenciesList { get; set; }
        IOrderDetailViewModel OrderDetailViewModel { get; }
        ISideBarViewModel OrderSideBarViewModel { get; set; }
        OrderModel SelectedOrderModel { get; }
        string NavigTo { get; }
        List<OrderModel> OrderModelList { get; }
        BusinessLogic Bl { get; }
        List<OrderModel> WaitValidClientOrderList { get; }
        List<OrderModel> InProcessOrderList { get; }
        List<OrderModel> WaitValidOrderList { get; }
        List<OrderModel> ClosedOrderList { get; }
        List<OrderModel> WaitPayOrderList { get; }
        CurrencyModel CurrencyModel { get; set; }
        string BlockSearchResultVisibility { get; set; }
        string BlockOrderVisibility { get; set; }

        //----------------------------[ Commands ]------------------

        QOBDModels.Command.ButtonCommand<string> NavigCommand { get; set; }
        QOBDModels.Command.ButtonCommand<OrderModel> GetCurrentOrderCommand { get; set; }
        QOBDModels.Command.ButtonCommand<OrderModel> DeleteCommand { get; set; }
        QOBDModels.Command.ButtonCommand<object> SearchCommand { get; set; }

        void Dispose();
        void removeObserver(PropertyChangedEventHandler observerMethode);
        void addObserver(PropertyChangedEventHandler observerMethode);
        void load();
        void loadOrdersAsync();
        void loadCurrencies();
        Task loadCurrenciesAsync();
        void executeNavig(string obj);
        bool canDeleteOrder(OrderModel arg);
        void saveSelectedOrder(OrderModel obj);
        Task deleteOrderDataAsync(OrderModel orderModel);
        List<OrderModel> OrderListToModelList(List<Order> OrderList);
    }
}
