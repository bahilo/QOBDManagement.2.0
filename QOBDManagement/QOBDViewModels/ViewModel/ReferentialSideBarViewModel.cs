using QOBDCommon.Classes;
using QOBDViewModels.Interfaces;
using System;
using QOBDModels.Command;

namespace QOBDViewModels.ViewModel
{
    public class ReferentialSideBarViewModel : Classes.ViewModel
    {
        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> UtilitiesCommand { get; set; }
        public ButtonCommand<string> SetupCommand { get; set; }
        private Func<object, object> _page;
        private IReferentialViewModel _referential;


        public ReferentialSideBarViewModel()
        {
            
        }

        public ReferentialSideBarViewModel(IReferentialViewModel viewModel) : this()
        {
            _referential = viewModel;
            _page = _referential.MainWindowViewModel.navigation;
            instancesCommand();
        }

        //----------------------------[ Initialization ]------------------
        
        private void instancesCommand()
        {
            UtilitiesCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<string>(executeUtilityAction, canExecuteUtilityAction);
            SetupCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<string>(executeSetupAction, canExecuteSetupAction);
        }

        //----------------------------[ Properties ]------------------


        public BusinessLogic Bl
        {
            get { return _referential.MainWindowViewModel.Startup.Bl; }
        }

        public string TxtIconColour
        {
            get { return Utility.getRandomColour(); }
        }

        //----------------------------[ Actions ]------------------

        public void executeNavig(string obj)
        {
            switch (obj.ToLower())
            {
                case "credential":
                    _page(new OptionSecurityViewModel());
                    break;
                case "data-display":
                    _page(new OptionDataAndDisplayViewModel());
                    break;
                case "email":
                    _page(new OptionEmailViewModel());
                    break;
                case "setting":
                    _page(new OptionGeneralViewModel());
                    break;
            }
        }
        
        //----------------------------[ Action Commands ]------------------

        private void executeSetupAction(string obj)
        {
            switch (obj)
            {
                case "data-display":
                    executeNavig(obj);
                    break;
                case "credential":
                    executeNavig(obj);
                    break;
            }
        }

        private bool canExecuteSetupAction(string arg)
        {
            bool isUserAdmin = _referential.MainWindowViewModel.AgentViewModel.IsAuthenticatedAgentAdmin;

            if (isUserAdmin && arg.Equals("credential") && _page(null) as OptionSecurityViewModel == null)
                return true;

            if (isUserAdmin && arg.Equals("data-display") && _page(null) as OptionDataAndDisplayViewModel == null)
                return true;

            return false;
        }

        private bool canExecuteUtilityAction(string arg)
        {
            bool canRead = _referential.MainWindowViewModel.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Read);

            if (arg.Equals("setting") && _page(null) as OptionGeneralViewModel != null)
                return false;

            if (!canRead && (arg.Equals("email") || arg.Equals("setting")))
                return false;

            if (arg.Equals("setting") && _page(null) as OptionGeneralViewModel != null)
                return false;

            if (arg.Equals("email") && _page(null) as OptionEmailViewModel != null)
                return false;

            return true;
        }

        private void executeUtilityAction(string obj)
        {
            switch (obj)
            {
                case "email":
                    executeNavig(obj);
                    break;
                case "setting":
                    executeNavig(obj);
                    break;
            }
        }
    }
}
