using QOBDCommon.Entities;
using QOBDModels.Models;
using System.Collections.Generic;
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
