using QOBDViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QOBDModels.Classes;
using QOBDModels.Enums;
using QOBDModels.Interfaces;
using QOBDViewModels.ViewModel;
using QOBDViewModels.Interfaces;
using QOBDViewModels.Enums;

namespace QOBDViewModels.Classes
{
    public class ViewModelConcreteCreator: Creator
    {
        public override object createViewModel(EViewModel viewModelName, IMainWindowViewModel mainViewModel)
        {
            switch (viewModelName)
            {
                case EViewModel.AGENT:
                    return new AgentViewModel(mainViewModel);
                case EViewModel.AGENTDETAIL:
                    return new AgentDetailViewModel(mainViewModel);
                case EViewModel.AGENTMENU:
                    return new AgentSideBarViewModel(mainViewModel);
                case EViewModel.CLIENT:
                    return new ClientViewModel(mainViewModel);
                case EViewModel.CLIENTMENU:
                    return new CLientSideBarViewModel(mainViewModel);
                case EViewModel.CLIENTDETAIL:
                    return new ClientDetailViewModel(mainViewModel);
                case EViewModel.CHAT:
                    return new ChatRoomViewModel(mainViewModel);
                case EViewModel.HOME:
                    return new HomeViewModel(mainViewModel);
                case EViewModel.ITEM:
                    return new ItemViewModel(mainViewModel);
                case EViewModel.ITEMDETAIL:
                    return new ItemDetailViewModel(mainViewModel);
                case EViewModel.ITEMMENU:
                    return new ItemSideBarViewModel(mainViewModel);
                case EViewModel.NOTIFICATION:
                    return new NotificationViewModel(mainViewModel);
                case EViewModel.NOTIFICATIONMENU:
                    return new NotificationSideBarViewModel(mainViewModel);
                case EViewModel.ORDER:
                    return new OrderViewModel(mainViewModel);
                case EViewModel.QUOTE:
                    return new QuoteViewModel(mainViewModel);
                case EViewModel.REFERENTIAL:
                    return new ReferentialViewModel(mainViewModel);
                case EViewModel.REFERENTIALDATAANDDISPLAY:
                    return new OptionDataAndDisplayViewModel(mainViewModel);
                case EViewModel.REFERENTIALEMAIL:
                    return new OptionEmailViewModel(mainViewModel);
                case EViewModel.REFERENTIALGENERAL:
                    return new OptionGeneralViewModel(mainViewModel);
                case EViewModel.REFERENTIALSECURITY:
                    return new OptionSecurityViewModel(mainViewModel);
                case EViewModel.REFERENTIALMENU:
                    return new ReferentialSideBarViewModel(mainViewModel);
                case EViewModel.SECURITYLOGIN:
                    return new SecurityLoginViewModel(mainViewModel);
                case EViewModel.STATISTIC:
                    return new StatisticViewModel(mainViewModel);
            }
            return null;
        }

        public override object createChatViewModel(EViewModel viewModelName, IChatRoomViewModel mainChatViewModel)
        {
            switch (viewModelName)
            {
                case EViewModel.CHATDISCUSSION:
                    return new DiscussionViewModel(mainChatViewModel);
                case EViewModel.CHATMESSAGE:
                    return new MessageViewModel(mainChatViewModel);
            }
            return null;
        }
    }
}
