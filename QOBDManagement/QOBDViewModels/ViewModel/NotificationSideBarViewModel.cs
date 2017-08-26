using QOBDCommon.Classes;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDViewModels.Interfaces;
using System;
using System.ComponentModel;

namespace QOBDViewModels.ViewModel
{
    public class NotificationSideBarViewModel : Classes.ViewModel, ISideBarViewModel
    {
        private Func<Object, Object> _page;
        private IMainWindowViewModel _main;

        public ButtonCommand<string> UtilitiesCommand { get; set; }
        public ButtonCommand<string> SetupCommand { get; set; }

        public NotificationSideBarViewModel()
        {
            
        }

        public NotificationSideBarViewModel(IMainWindowViewModel mainWindowViewModel) : this()
        {
            _main = mainWindowViewModel;
            _page = _main.navigation;
            UtilitiesCommand = _main.CommandCreator.createSingleInputCommand<string>(executeUtilityAction, canExecuteUtilityAction);
        }

        public string TxtIconColour
        {
            get { return Utility.getRandomColour(); }
        }

        //----------------------------[ Actions ]----------------------

        private void updateCommand()
        {
            UtilitiesCommand.raiseCanExecuteActionChanged();
            SetupCommand.raiseCanExecuteActionChanged();
        }

        //----------------------------[ Event Handler ]------------------

        public void onCurrentPageChange_updateCommand(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrentViewModel"))
                updateCommand();
        }

        //----------------------------[ Action Commands ]------------------

        private bool canExecuteUtilityAction(string arg)
        {
            bool isUserAdmin = _main.AgentViewModel.IsAuthenticatedAgentAdmin;

            if(isUserAdmin)
                return true;

            return false;
        }

        private async void executeUtilityAction(string obj)
        {
            switch (obj)
            {
                case "email-unpaid":
                    await Singleton.getDialogueBox().showAsync("TO DO: Send email for unpaid bill");
                    break;
            }
        }
    }
}
