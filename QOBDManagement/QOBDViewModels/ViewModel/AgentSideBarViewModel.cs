using QOBDCommon.Entities;
using QOBDCommon.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;
using QOBDModels.Models;
using QOBDModels.Command;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class AgentSideBarViewModel : Classes.ViewModel, ISideBarViewModel
    {
        private Func<object, object> _page;

        //----------------------------[ Models ]------------------
        
        private IMainWindowViewModel _main;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> SetupCommand { get; set; }
        public ButtonCommand<string> UtilitiesCommand { get; set; }


        public AgentSideBarViewModel()
        {
            
        }

        public AgentSideBarViewModel(IMainWindowViewModel mainWindowViewModel) :this()
        {
            _main = mainWindowViewModel;
            _page = mainWindowViewModel.navigation;
            instancesCommand();
            initEvents();
        }

        //----------------------------[ Initialization ]------------------

        private void initEvents()
        {
            PropertyChanged += onSelectedAgentModelChange;
        }

        private void instancesCommand()
        {
            SetupCommand = _main.CommandCreator.createSingleInputCommand<string>(executeSetupAction, canExcecuteSetupAction);
            UtilitiesCommand = _main.CommandCreator.createSingleInputCommand<string>(executeUtilityAction, canExecuteUtilityAction);
        }


        //----------------------------[ Properties ]------------------

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public string TxtIconColour
        {
            get { return Utility.getRandomColour(); }
        }

        public AgentModel SelectedAgentModel
        {
            get { return _main.AgentViewModel.AgentDetailViewModel.SelectedAgentModel; }
            set { _main.AgentViewModel.AgentDetailViewModel.SelectedAgentModel = value; onPropertyChange("SelectedAgentModel"); }
        }

        public Func<object, object> Page
        {
            get { return _page; }
            set { _page = value; onPropertyChange("Page"); }
        }

        //----------------------------[ Actions ]------------------

        private async Task<Agent> loadNewUser(Agent agent)
        {
            Agent newAgent = new Agent();
            if (_main != null)
            {
                await Bl.BlSecurity.DisconnectAuthenticatedUser();
                _main.Context = _main.ContextCreator.createContext(_main);
                await Task.Factory.StartNew(() => {
                    _main.ChatRoomViewModel.Dispose();
                });
                newAgent = await Bl.BlSecurity.UseAgentAsync(agent);
                if (Bl.BlSecurity.IsUserAuthenticated())
                {
                    _main.isNewAgentAuthentication = true;
                    _main.SecurityLoginViewModel.AgentModel.Agent = Bl.BlSecurity.GetAuthenticatedUser();
                }
            }
            return newAgent;
        }

        private void updateCommand()
        {
            UtilitiesCommand.raiseCanExecuteActionChanged();
            SetupCommand.raiseCanExecuteActionChanged();
        }

        public override void Dispose()
        {
            PropertyChanged -= onSelectedAgentModelChange;
        }

        //----------------------------[ Event Handler ]------------------
        
        public void onCurrentPageChange_updateCommand(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrentViewModel"))
                updateCommand();
        }

        private void onSelectedAgentModelChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedAgentModel"))
                updateCommand();
        }

        //----------------------------[ Action Commands ]------------------


        private bool canExecuteUtilityAction(string arg)
        {
            bool canUpdate = _main.securityCheck(EAction.Agent, ESecurity._Update);
            bool canWrite = _main.securityCheck(EAction.Agent, ESecurity._Write);
            bool canDelete = _main.securityCheck(EAction.Agent, ESecurity._Delete);
            bool canRead = _main.securityCheck(EAction.Agent, ESecurity._Read);
            bool isUserAdmin = _main.AgentViewModel.IsAuthenticatedAgentAdmin;

            if (!canUpdate || !canWrite)
                return false;

            if (arg.Equals("agent") && Page(null) as AgentViewModel != null)
                return false;

            if (Page(null) as AgentDetailViewModel == null)
                return false;
            
            if (SelectedAgentModel == null || SelectedAgentModel.Agent.ID == 0)
                return false;

            if (!isUserAdmin && 
                (arg.Equals("use")
                || arg.Equals("activate")
                || arg.Equals("deactivate")))
                return false;

            if (SelectedAgentModel.TxtStatus.Equals(EStatus.Active.ToString())
                && arg.Equals("activate"))
                return false;

            if (SelectedAgentModel.TxtStatus.Equals(EStatus.Deactivated.ToString())
                && arg.Equals("deactivate"))
                return false;

            return true;
        }
        
        private async void executeUtilityAction(string obj)
        {
            List<Agent> updatedAgentList = new List<Agent>();
            switch (obj)
            {
                case "activate": // change the agent status to active
                    if (await Singleton.getDialogueBox().showAsync("Do you confirm " + SelectedAgentModel.TxtLogin + " profile activation?"))
                    {
                        Singleton.getDialogueBox().showSearch("Activating Status...");
                        SelectedAgentModel.TxtStatus = EStatus.Active.ToString();
                        updatedAgentList = await Bl.BlAgent.UpdateAgentAsync(new List<Agent> { SelectedAgentModel.Agent });
                        if (updatedAgentList.Count > 0)
                            await Singleton.getDialogueBox().showAsync("The Agent " + updatedAgentList[0].LastName + "has been successfully activated!");
                    }                    
                    break;
                case "deactivate": // change the agent status to deactivated
                    if (await Singleton.getDialogueBox().showAsync("Do you confirm "+ SelectedAgentModel.TxtLogin + " profile deactivation?"))
                    {
                        Singleton.getDialogueBox().showSearch("Deactivating Status...");
                        SelectedAgentModel.TxtStatus = EStatus.Deactivated.ToString();
                        updatedAgentList = await Bl.BlAgent.UpdateAgentAsync(new List<Agent> { SelectedAgentModel.Agent });
                        if (updatedAgentList.Count > 0)
                            await Singleton.getDialogueBox().showAsync("The Agent " + updatedAgentList[0].LastName + " has been successfully deactivated!");
                    }
                    break;
                case "use": // connect a new user
                    if (await Singleton.getDialogueBox().showAsync("Do you confirm reconnecting as user " + SelectedAgentModel.TxtLogin + "?"))
                    {
                        Singleton.getDialogueBox().showSearch("Please wait while we are dealing with your request...");
                        var newAgent = await loadNewUser(SelectedAgentModel.Agent);
                        if (newAgent.ID != 0)
                            await Singleton.getDialogueBox().showAsync("Your are successfully connected as " + newAgent.FirstName + " " + newAgent.LastName);
                    }                    
                   break;
                case "agent": // connect a new user
                    _page(_main.AgentViewModel);
                    break;
            }
            Singleton.getDialogueBox().IsDialogOpen = false;
            UtilitiesCommand.raiseCanExecuteActionChanged();
        }

        private bool canExcecuteSetupAction(string arg)
        {
            bool canUpdate = _main.securityCheck(EAction.Agent, ESecurity._Update);
            bool canWrite = _main.securityCheck(EAction.Agent, ESecurity._Write);
            if (!canWrite || !canUpdate && Bl.BlSecurity.GetAuthenticatedUser().ID != SelectedAgentModel.Agent.ID)
                return false;
            return true;
        }

        private void executeSetupAction(string obj)
        {
            switch (obj)
            {
                case "new-agent":
                    if (_main != null)
                    {
                        _main.AgentViewModel.AgentDetailViewModel.SelectedAgentModel = SelectedAgentModel = (AgentModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.AGENT);
                        Page(new AgentDetailViewModel());
                    }
                    break;
            }
        }
    }
}
