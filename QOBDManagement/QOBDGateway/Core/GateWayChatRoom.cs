using QOBDCommon.Entities;
using QOBDCommon.Enum;
using QOBDGateway.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using QOBDGateway.Helper.ChannelHelper;
using System.Threading.Tasks;
using QOBDGateway.Abstracts;

namespace QOBDGateway.Core
{
    public class GateWayChatRoom: QOBDCommon.Interfaces.REMOTE.IChatRoomManager
    {

        private ClientProxy _channel;
        private string _companyName;

        public event PropertyChangedEventHandler PropertyChanged;


        public GateWayChatRoom(ClientProxy servicePort)
        {
            _channel = servicePort;
        }

        public void setServiceCredential(object channel)
        {
            _channel = (ClientProxy)channel;
        }

        private void onPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public ClientProxy GateWayChatRoomChannel
        {
            get { return _channel; }
        }

        public void setCompanyName(string companyName)
        {
            _companyName = companyName;
        }

        // discussion
        #region [ Discussion ]
        public async Task<List<Discussion>> DeleteDiscussionAsync(List<Discussion> listDiscussion)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.delete_data_discussionAsync(_companyName, listDiscussion.DiscussionTypeToArray())).ArrayTypeToDiscussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Discussion>> GetDiscussionDataAsync(int nbLine)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.get_data_discussionAsync(_companyName, nbLine.ToString())).ArrayTypeToDiscussion().OrderBy(x => x.ID).ToList();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Discussion>> GetDiscussionDataByIdAsync(int id)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.get_data_discussion_by_idAsync(_companyName, id.ToString())).ArrayTypeToDiscussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Discussion>> GetDiscussionDataByUser_discussionListAsync(List<User_discussion> user_discussionList)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.get_data_discussion_by_user_discussion_listAsync(_companyName, user_discussionList.User_discussionTypeToArray())).ArrayTypeToDiscussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Discussion>> GetDiscussionDataByMessageListAsync(List<Message> messageList)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.get_data_discussion_by_message_listAsync(_companyName, messageList.MessageTypeToArray())).ArrayTypeToDiscussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }


        public async Task<List<Discussion>> InsertDiscussionAsync(List<Discussion> listDiscussion)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.insert_data_discussionAsync(_companyName, listDiscussion.DiscussionTypeToArray())).ArrayTypeToDiscussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Discussion>> UpdateDiscussionAsync(List<Discussion> listDiscussion)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.update_data_discussionAsync(_companyName, listDiscussion.DiscussionTypeToArray())).ArrayTypeToDiscussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Discussion>> searchDiscussionAsync(Discussion discussion, ESearchOption filterOperator)
        {
            List<Discussion> result = new List<Discussion>();
            try
            {
                result = (await _channel.get_filter_discussionAsync(_companyName, discussion.DiscussionTypeToFilterArray(filterOperator.ToString()))).ArrayTypeToDiscussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        #endregion

        #region [ Message ]
        public async Task<List<Message>> DeleteMessageAsync(List<Message> listMessage)
        {
            List<Message> result = new List<Message>();
            try
            {
                result = (await _channel.delete_data_messageAsync(_companyName, listMessage.MessageTypeToArray())).ArrayTypeToMessage();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Message>> GetMessageDataAsync(int nbLine)
        {
            List<Message> result = new List<Message>();
            try
            {
                result = (await _channel.get_data_messageAsync(_companyName, nbLine.ToString())).ArrayTypeToMessage().OrderBy(x => x.ID).ToList();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Message>> GetMessageDataByIdAsync(int id)
        {
            List<Message> result = new List<Message>();
            try
            {
                result = (await _channel.get_data_message_by_idAsync(_companyName, id.ToString())).ArrayTypeToMessage();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }


        public async Task<List<Message>> InsertMessageAsync(List<Message> listMessage)
        {
            List<Message> result = new List<Message>();
            try
            {
                result = (await _channel.insert_data_messageAsync(_companyName, listMessage.MessageTypeToArray())).ArrayTypeToMessage();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Message>> UpdateMessageAsync(List<Message> listMessage)
        {
            List<Message> result = new List<Message>();
            try
            {
                result = (await _channel.update_data_messageAsync(_companyName, listMessage.MessageTypeToArray())).ArrayTypeToMessage();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<Message>> searchMessageAsync(Message message, ESearchOption filterOperator)
        {
            List<Message> result = new List<Message>();
            try
            {
                result = (await _channel.get_filter_messageAsync(_companyName, message.MessageTypeToFilterArray(filterOperator.ToString()))).ArrayTypeToMessage();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }
        #endregion

        #region [ User_discussion ]
        public async Task<List<User_discussion>> DeleteUser_discussionAsync(List<User_discussion> listUser_discussion)
        {
            List<User_discussion> result = new List<User_discussion>();
            try
            {
                result = (await _channel.delete_data_user_discussionAsync(_companyName, listUser_discussion.User_discussionTypeToArray())).ArrayTypeToUser_discussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<User_discussion>> GetUser_discussionDataAsync(int nbLine)
        {
            List<User_discussion> result = new List<User_discussion>();
            try
            {
                result = (await _channel.get_data_user_discussionAsync(_companyName, nbLine.ToString())).ArrayTypeToUser_discussion().OrderBy(x => x.ID).ToList();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<User_discussion>> GetUser_discussionDataByIdAsync(int id)
        {
            List<User_discussion> result = new List<User_discussion>();
            try
            {
                result = (await _channel.get_data_user_discussion_by_idAsync(_companyName, id.ToString())).ArrayTypeToUser_discussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<User_discussion>> InsertUser_discussionAsync(List<User_discussion> listUser_discussion)
        {
            List<User_discussion> result = new List<User_discussion>();
            try
            {
                result = (await _channel.insert_data_user_discussionAsync(_companyName, listUser_discussion.User_discussionTypeToArray())).ArrayTypeToUser_discussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<User_discussion>> UpdateUser_discussionAsync(List<User_discussion> listUser_discussion)
        {
            List<User_discussion> result = new List<User_discussion>();
            try
            {
                result = (await _channel.update_data_user_discussionAsync(_companyName, listUser_discussion.User_discussionTypeToArray())).ArrayTypeToUser_discussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }

        public async Task<List<User_discussion>> searchUser_discussionAsync(User_discussion user_discussion, ESearchOption filterOperator)
        {
            List<User_discussion> result = new List<User_discussion>();
            try
            {
                result = (await _channel.get_filter_user_discussionAsync(_companyName, user_discussion.User_discussionTypeToFilterArray(filterOperator.ToString()))).ArrayTypeToUser_discussion();
            }
            catch (FaultException) { Dispose(); throw; }
            catch (CommunicationException) { _channel.Abort(); throw; }
            catch (TimeoutException) { _channel.Abort(); }
            return result;
        }
        #endregion

        public void Dispose()
        {
            if (_channel.State == CommunicationState.Opened)
                _channel.Close();
        }
    }
}
