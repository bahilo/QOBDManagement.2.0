using QOBDCommon.Entities;
using QOBDViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface INotificationViewModel
    {
        Task loadNotifications();
        Task<List<BillModel>> billListToModelViewList(List<Bill> billList);
        void Dispose();
    }
}
