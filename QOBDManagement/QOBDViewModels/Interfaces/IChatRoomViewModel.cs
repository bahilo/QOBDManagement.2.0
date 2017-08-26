using QOBDModels.Command;
using QOBDModels.Models;
using QOBDViewModels.Classes;
using QOBDViewModels.ViewModel;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IChatRoomViewModel
    {
        //----------------[ Properties ]--------------

        Object CurrentViewModel { get; set; }
        IConfirmationViewModel Dialog { get; }
        string TxtIconColour { get; }
        AgentModel AuthenticatedAgent { get; set; }
        string ChatAuthenticatedWelcomeMessage { get; set; }
        IAgentViewModel AgentViewModel { get; }
        IPEndPoint EndPoint { get; set; }
        UdpClient UdpClient { get; set; }
        IMainWindowViewModel MainWindowViewModel { get; }
        string TxtUserName { get; }
        Context Context { get; set; }
        IDiscussionViewModel DiscussionViewModel { get; set; }
        IMessageViewModel MessageViewModel { get; set; }

        //----------------------------[ Commands ]------------------

        ButtonCommand<string> CommandNavig { get; set; }
        ButtonCommand<object> DisplayAccountCommand { get; set; }
        ButtonCommand<object> ChatValidUserAccountCommand { get; set; }


        //---------------[ Actions ]---------------------
        void start();
        void Dispose();
        void cleanUp();
        Task DisposeAsync();
        Task getChatUserInformation();
        object navigation(object centralPageContent = null);        
    }
}
