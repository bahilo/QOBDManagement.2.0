﻿using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using QOBDModels.Models;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class MessageViewModel : Classes.ViewModel
    {
        private int _maxMessageCharacters;
        private Func<object, object> _page;
        private Dictionary<AgentModel, Pair<MessageModel, int>> _messageIndividualHistoryList;
        private Dictionary<AgentModel, Pair<MessageModel, int>> _messageGroupHistoryList;
        private IChatRoomViewModel _mainChatRoom;

        public MessageViewModel()
        {
            _maxMessageCharacters = 10;
            _messageIndividualHistoryList = new Dictionary<AgentModel, Pair<MessageModel, int>>();
            _messageGroupHistoryList = new Dictionary<AgentModel, Pair<MessageModel, int>>();
        }

        public MessageViewModel(IChatRoomViewModel mainChatRoom) : this()
        {
            _mainChatRoom = mainChatRoom;
            this._page = _mainChatRoom.navigation;
        }

        public Agent AuthenticatedUser
        {
            get { return BL.BlSecurity.GetAuthenticatedUser(); }
        }

        public int MaxMessageLength
        {
            get { return _maxMessageCharacters; }
        }

        public BusinessLogic BL
        {
            get { return _mainChatRoom.MainWindowViewModel.Startup.Bl; }
        }

        public Dictionary<AgentModel, Pair<MessageModel, int>> MessageIndividualHistoryList
        {
            get { return _messageIndividualHistoryList; }
            set { setProperty(ref _messageIndividualHistoryList, value); }
        }

        public Dictionary<AgentModel, Pair<MessageModel, int>> MessageGroupHistoryList
        {
            get { return _messageGroupHistoryList; }
            set { setProperty(ref _messageGroupHistoryList, value); }
        }

        public async Task loadAsync()
        {
            Singleton.getDialogueBox().showSearchingMessage(ConfigurationManager.AppSettings["load_message"], isChatDialogBox: true);

            MessageIndividualHistoryList.Clear();
            MessageGroupHistoryList.Clear();

            // searching all common discussion
            var discussionList = _mainChatRoom.DiscussionViewModel.DiscussionList;
            if (discussionList == null || discussionList.Count == 0)
                discussionList = await _mainChatRoom.DiscussionViewModel.retrieveUserDiscussions(BL.BlSecurity.GetAuthenticatedUser());

            foreach (var discussionModel in discussionList)
            {
                if (MessageIndividualHistoryList.Values.Where(x => x.PairID.Message.DiscussionId == discussionModel.Discussion.ID).Count() == 0
                    && MessageGroupHistoryList.Values.Where(x => x.PairID.Message.DiscussionId == discussionModel.Discussion.ID).Count() == 0)
                {
                    int numberOfUnReadMessages = 0;
                    MessageModel lastMessage = new MessageModel();
                    if (discussionModel.MessageList.Count > 0)
                    {
                        lastMessage = discussionModel.MessageList.Where(x => x.IsNewMessage && x.Message.UserId != AuthenticatedUser.ID).OrderByDescending(x => x.Message.ID).Select(x => new MessageModel { Message = new Message { ID = x.Message.ID, Content = x.TxtContent }, IsNewMessage = x.IsNewMessage }).FirstOrDefault();
                        if (lastMessage == null)
                            lastMessage = discussionModel.MessageList.OrderByDescending(x => x.Message.ID).Select(x => new MessageModel { Message = new Message { ID = x.Message.ID, Content = x.TxtContent }, IsNewMessage = false }).First();

                        numberOfUnReadMessages = discussionModel.MessageList.Where(x => x.IsNewMessage && x.Message.UserId != AuthenticatedUser.ID).Count();

                        // limit the amount of message characters to display in the history
                        if (lastMessage.TxtContent.Length > MaxMessageLength)
                            lastMessage.TxtContent = lastMessage.TxtContent.Substring(0, MaxMessageLength) + "...";

                        if (discussionModel.UserList.Count() > 0)
                        {
                            lastMessage.Message.UserId = discussionModel.UserList[0].Agent.ID;
                            lastMessage.TxtGroupName = discussionModel.TxtGroupName;
                            lastMessage.Message.Date = discussionModel.MessageList.OrderByDescending(x => x.Message.Date).Select(x => x.Message.Date).First();
                        }

                        // saving the messages for group and individual discussion
                        var usersFound = discussionModel.UserList.Where(x => x.Agent.ID == lastMessage.Message.UserId).ToList();// await BL.BlAgent.searchAgentAsync( new Agent { ID = lastMessage.Message.UserId }, QOBDCommon.Enum.ESearchOption.AND);
                        if (usersFound.Count > 0)
                        {
                            Pair<MessageModel, int> messageInfo = new Pair<MessageModel, int>();

                            if (discussionModel.UserList.Count == 1)
                            {
                                messageInfo.PairID = lastMessage;
                                messageInfo.PairValue = numberOfUnReadMessages;
                                addMessageIndividualHistoryList(new Dictionary<AgentModel, Pair<MessageModel, int>> { { usersFound.First(), messageInfo } });
                            }
                            else
                            {                                
                                messageInfo.PairID = lastMessage;
                                messageInfo.PairValue = numberOfUnReadMessages;
                                addMessageGroupHistoryList(new Dictionary<AgentModel, Pair<MessageModel, int>> { { usersFound.First(), messageInfo } });
                            }
                                
                        }
                    }
                }
            }            

            Singleton.getDialogueBox().IsChatDialogOpen = false;
        }

        private void addMessageGroupHistoryList(Dictionary<AgentModel, Pair<MessageModel, int>> dict)
        {
            if (Application.Current != null)
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageGroupHistoryList = Utility.concat(MessageGroupHistoryList, dict);
                });
            else
                MessageGroupHistoryList = Utility.concat(MessageGroupHistoryList, dict);
        }

        private void addMessageIndividualHistoryList(Dictionary<AgentModel, Pair<MessageModel, int>> dict)
        {
            if(Application.Current != null)
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageIndividualHistoryList = Utility.concat(MessageIndividualHistoryList, dict);
                });
            else
                MessageIndividualHistoryList = Utility.concat(MessageIndividualHistoryList, dict);
        }


    }
}
