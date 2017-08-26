using QOBDCommon.Enum;
using QOBDModels.Abstracts;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDModels.Models;
using QOBDViewModels.Abstracts;
using QOBDViewModels.Classes;
using QOBDViewModels.ViewModel;
using System;

namespace QOBDViewModels.Interfaces
{
    public interface IMainWindowViewModel
    {
        //----------------[ Properties ]
        IClientViewModel ClientViewModel { get; set; }
        IItemViewModel ItemViewModel { get; set; }
        IOrderViewModel OrderViewModel { get; set; }
        IAgentViewModel AgentViewModel { get; set; }
        INotificationViewModel NotificationViewModel { get; set; }
        IHomeViewModel HomeViewModel { get; set; }
        IReferentialViewModel ReferentialViewModel { get; set; }
        IStatisticViewModel StatisticViewModel { get; set; }
        IQuoteViewModel QuoteViewModel { get; set; }
        IChatRoomViewModel ChatRoomViewModel { get; set; }
        ISecurityLoginViewModel SecurityLoginViewModel { get; set; }

        bool IsRefresh { get; set; }
        bool IsThroughContext { get; set; }
        Creator ViewModelCreator { get; }
        Creator CommandCreator { get; }
        Creator ContextCreator { get; }
        Creator ImageCreator { get; }
        ModelCreator ModelCreator { get; }
        IStartup Startup { get; }
        bool isNewAgentAuthentication { get; set; }
        AgentModel AuthenticatedUserModel { get; }
        Context Context { get; set; }
        ButtonCommand<string> CommandNavig { get; set; }
        Object CurrentViewModel { get; set; }
        Object ChatRoomCurrentView { get; set; }
                      
        //---------------[ Actions ]
        bool canAppNavig(string arg);
        void appNavig(string propertyName);
        double progressBarManagement(double status = 0);
        bool securityCheck(EAction action, ESecurity right);
        Object navigation(Object centralPageContent = null);
    }
}
