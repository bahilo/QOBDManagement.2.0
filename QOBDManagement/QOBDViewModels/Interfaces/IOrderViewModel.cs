using QOBDCommon.Entities;
using QOBDModels.Models;
using System.Collections.Generic;

namespace QOBDViewModels.Interfaces
{
    public interface IOrderViewModel
    {
        void loadOrders();
        List<OrderModel> OrderListToModelList(List<Order> OrderList);
        void Dispose();
    }
}
