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
        ClientViewModel ClientViewModel { get; set; }
        ItemViewModel ItemViewModel { get; set; }
        OrderViewModel OrderViewModel { get; set; }
        AgentViewModel AgentViewModel { get; set; }
        NotificationViewModel NotificationViewModel { get; set; }
        HomeViewModel HomeViewModel { get; set; }
        ReferentialViewModel ReferentialViewModel { get; set; }
        StatisticViewModel StatisticViewModel { get; set; }
        QuoteViewModel QuoteViewModel { get; set; }
        ChatRoomViewModel ChatRoomViewModel { get; set; }
        SecurityLoginViewModel SecurityLoginViewModel { get; set; }

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
        void appNavig(string propertyName);
        double progressBarManagement(double status = 0);
        bool securityCheck(EAction action, ESecurity right);
        Object navigation(Object centralPageContent = null);
    }
}
