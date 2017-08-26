using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Command;
using QOBDModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface INotificationViewModel  
    {
        ISideBarViewModel NotificationSideBarViewModel { get; set; }
        BusinessLogic Bl { get;  }
        string Title { get; }
        List<BillModel> BillNotPaidList { get; set; }
        List<OrderModel> OrderWaitingValidationList { get; set; }
        List<ClientModel> ClientList { get; set; }

        //----------------------------[ Commands ]------------------

        ButtonCommand<string> BtnDeleteCommand { get; set; }
        ButtonCommand<ClientModel> DetailSelectedClientCommand { get; set; }
        ButtonCommand<BillModel> SendBillCommand { get; set; }
        ButtonCommand<BillModel> ValidChangeCommand { get; set; }


        Task loadNotifications();
        Task<List<BillModel>> billListToModelViewList(List<Bill> billList);
        void Dispose();
    }
}
