using QOBDViewModels.ViewModel;

namespace QOBDViewModels.Interfaces
{
    public interface IChatRoomViewModel
    {
        //----------------[ Properties ]--------------
        IMainWindowViewModel MainWindowViewModel { get; }
        DiscussionViewModel DiscussionViewModel { get; set; }
        MessageViewModel MessageViewModel { get; set; }
        AgentViewModel AgentViewModel { get; }

        //---------------[ Actions ]---------------------
        void start();
        void cleanUp();
        //Task signOutFromServer(List<DiscussionModel> discussionList);
        object navigation(object centralPageContent = null);        
    }
}
