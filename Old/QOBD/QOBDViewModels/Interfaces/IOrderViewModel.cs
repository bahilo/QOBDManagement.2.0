using QOBDCommon.Entities;
using QOBDViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IOrderViewModel
    {
        void loadOrders();
        List<OrderModel> OrderListToModelList(List<Order> OrderList);
        void Dispose();
    }
}
