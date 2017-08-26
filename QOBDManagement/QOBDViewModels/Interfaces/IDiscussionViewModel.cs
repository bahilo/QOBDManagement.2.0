using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Command;
using QOBDModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IDiscussionViewModel
    {
        string TxtNbNewMessage { get; set; }
        IChatRoomViewModel MainChatRoom { get; }
        DiscussionModel DiscussionModel { get; set; }
        List<AgentModel> ChatAgentModelList { get; set; }
        string ByeMessage { get; }
        string WelcomeMessage { get; }
        List<DiscussionModel> DiscussionList { get; set; }
        Dictionary<AgentModel, Tuple<Guid, UdpClient>> ServerClientsDictionary { get; set; }        
        Agent AuthenticatedUser { get; }
        AgentModel ChatAgentModelSelectedFromAgentList { get; set; }
        string TxtMessageIcon { get; set; }
        int InputCharactersCount { get; set; }
        int MaxCharacterAllowed { get; set; }
        BusinessLogic BL { get; }
        AgentModel SelectedAgentModel { get; set; }
        ObservableCollection<MessageModel> ChatMessages { get; set; }
        string InputMessage { get; set; }
        string OutputMessage { get; set; }
        System.Net.Sockets.UdpClient UdpClient { get; set; }
        IPEndPoint EndPoint { get; set; }
        ObservableCollection<string> UserGroupList { get; set; }

        //----------------------------[ Commands ]------------------

        ButtonCommand<string> SendMessageCommand { get; set; }
        ButtonCommand<AgentModel> SelectUserForDiscussionCommand { get; set; }
        ButtonCommand<AgentModel> DeleteDiscussionCommand { get; set; }
        ButtonCommand<string> selectDiscussionGroupCommand { get; set; }
        ButtonCommand<object> ResetDiscussionGroupCommand { get; set; }
        ButtonCommand<object> OpenDiscussionGroupCommand { get; set; }
        ButtonCommand<object> NavigToHomeCommand { get; set; }
        ButtonCommand<object> ReadNewMessageCommand { get; set; }
        ButtonCommand<object> DiscussionAddUserCommand { get; set; }
        ButtonCommand<string> GetDiscussionGroupCommand { get; set; }
        ButtonCommand<string> GetIndividualDiscussionCommand { get; set; }
        ButtonCommand<string> DeleteGroupDiscussionCommand { get; set; }
        ButtonCommand<object> ShowMoreMessagesCommand { get; set; }
        ButtonCommand<string> NewMessageHomePageCommand { get; set; }


        void load();
        void getMessage();
        void Dispose();
        void broadcast(string msg);
        void executeNavig(string obj);
        void removeObserver(PropertyChangedEventHandler observerMethode);
        void addObserver(PropertyChangedEventHandler observerMethode);
        Task broadcastMessageAsync(string message);
        void markMessageAsUnRead(DiscussionModel discussionModel, MessageModel messageModel);
        void markMessageAsRead(DiscussionModel discussionModel, MessageModel messageModel);
        void displayMessage(Message message, Agent user);
        Task<List<DiscussionModel>> retrieveUserDiscussions(Agent user);
        List<Agent> updateDiscussionUserList(DiscussionModel discussionModel, List<string> userIDList);
    }
}
