using QOBDModels.Models;

namespace QOBDViewModels.Interfaces
{
    public interface IChatRoom
    {      
        void showRecipientReply(MessageModel messageModel, bool isNewDiscussion = false);
        void showMyReply(MessageModel messageModel, bool isNewDiscussion = false);
        void showInfo(MessageModel messageModel);
    }
}
