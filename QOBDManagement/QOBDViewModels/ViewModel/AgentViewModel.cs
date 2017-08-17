﻿using QOBDCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QOBDCommon.Enum;
using System.Configuration;
using QOBDCommon.Classes;
using QOBDModels.Models;
using QOBDViewModels.Interfaces;
using QOBDModels.Command;
using System.Windows;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class AgentViewModel : Classes.ViewModel
    {
        
        private Func<Object, Object> _page;
        private List<string> _chatUserGroupList;
        private List<Agent> _clientAgentToMoveList;
        private string _title;


        //----------------------------[ Models ]------------------

        private AgentModel _agentModel;
        private AgentDetailViewModel _agentDetailViewModel;
        private IMainWindowViewModel _main;
        public IDiscussionViewModel _chatDiscussionViewModel;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<AgentModel> CheckBoxCommand { get; set; }
        public ButtonCommand<string> NavigCommand { get; set; }
        public ButtonCommand<AgentModel> GetCurrentAgentCommand { get; set; }
        public ButtonCommand<AgentModel> ClientMoveCommand { get; set; }


        public AgentViewModel()
        {
            
        }

        public AgentViewModel(IMainWindowViewModel mainWindowViewModel): this()
        {
            _main = mainWindowViewModel;
            _page = _main.navigation;
            instancesCommand();
            instancesModel(mainWindowViewModel);
        }

        //----------------------------[ Initialization ]------------------
        
        private void instancesModel(IMainWindowViewModel mainWindowViewModel)
        {
            _clientAgentToMoveList = new List<Agent>();
            _agentModel = (AgentModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.AGENT);
            _agentDetailViewModel = (AgentDetailViewModel)_main.ViewModelCreator.createViewModel( Enums.EViewModel.AGENTDETAIL, mainWindowViewModel);
            AgentSideBarViewModel = (AgentSideBarViewModel)_main.ViewModelCreator.createViewModel(Enums.EViewModel.AGENTMENU, mainWindowViewModel);
        }

        private void instancesCommand()
        {
            ClientMoveCommand = _main.CommandCreator.createSingleInputCommand<AgentModel>(moveAgentCLient, canMoveClientAgent);
            CheckBoxCommand = _main.CommandCreator.createSingleInputCommand<AgentModel>(saveResultGridChecks, canSaveResultGridChecks);
            NavigCommand = _main.CommandCreator.createSingleInputCommand<string>(executeNavig, canExecuteNavig);
            GetCurrentAgentCommand = _main.CommandCreator.createSingleInputCommand<AgentModel>(selectAgent, canSelectAgent);         
        }        


        //----------------------------[ Properties ]------------------

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public string Title
        {
            get { return _title; }
            set { setProperty(ref _title, value); }
        }

        public AgentModel AgentModel
        {
            get { return _agentModel; }
            set { _agentModel = value; onPropertyChange(); }
        }

        public List<AgentModel> AgentModelList
        {
            get { return _agentDetailViewModel.AgentModelList; }
            set
            {
                if(Application.Current != null && !Application.Current.Dispatcher.CheckAccess())
                {
                    Application.Current.Dispatcher.Invoke(() => {
                        _agentDetailViewModel.AgentModelList = value;
                    });
                }
                else
                    _agentDetailViewModel.AgentModelList = value;
                               
                onPropertyChange(); onPropertyChange("UserModelList"); onPropertyChange("ActiveAgentModelList"); onPropertyChange("DeactivatedAgentModelList");
            }
        }

        public List<AgentModel> ActiveAgentModelList
        {
            get { return AgentModelList.Where(x => x.TxtStatus.Equals(EStatus.Active.ToString())).ToList(); }
        }

        public List<AgentModel> DeactivatedAgentModelList
        {
            get { return AgentModelList.Where(x => x.TxtStatus.Equals(EStatus.Deactivated.ToString())).ToList(); }
        }

        public AgentModel SelectedAgentModel
        {
            get { return AgentDetailViewModel.SelectedAgentModel; }
            set { AgentDetailViewModel.SelectedAgentModel = value; onPropertyChange("SelectedAgentModel"); }
        }

        public AgentDetailViewModel AgentDetailViewModel
        {
            get { return _agentDetailViewModel; }
            set { _agentDetailViewModel = value; onPropertyChange("AgentDetailViewModel"); }
        }

        public AgentSideBarViewModel AgentSideBarViewModel
        {
            get { return _agentDetailViewModel.AgentSideBarViewModel; }
            set { _agentDetailViewModel.AgentSideBarViewModel = value; onPropertyChange("AgentSideBarViewModel"); }
        }

        public List<AgentModel> UserModelList
        {
            get { return AgentModelList.Where(x => x.Agent.ID != Bl.BlSecurity.GetAuthenticatedUser().ID).OrderByDescending(x => x.Agent.IsOnline).ToList(); }
        }

        public bool IsAuthenticatedAgentAdmin
        {
            get { return checkIfAuthenticatedUserAdmin(); }
        }

        public List<string> UserGroupList
        {
            get { return _chatUserGroupList; }
            set { setProperty(ref _chatUserGroupList, value); }
        }



        //----------------------------[ Actions ]------------------

        /// <summary>
        /// initialize the agent view (called by the view code behind)
        /// </summary>
        public async Task loadAgents()
        {
            await loadAsync();
        } 

        /// <summary>
        /// Convert the list of agent received from the web service into 
        /// a list of agent model used by the agent view
        /// </summary>
        /// <param name="AgentList">data from the web service</param>
        /// <returns></returns>
        public List<AgentModel> agentListToModelViewList(List<Agent> AgentList)
        {
            List<AgentModel> output = new List<AgentModel>();
            var credentialInfoList = Bl.BlReferential.searchInfo(new Info { Name = "ftp_" }, ESearchOption.AND);
            foreach (Agent Agent in AgentList)
            {
                AgentModel avm = (AgentModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.AGENT);
                avm.Agent = Agent;
                output.Add(avm);
            }
            return output;
        }

        private async Task loadAsync()
        {
            // closing agent image file before reloading
            if (SelectedAgentModel != null && SelectedAgentModel.Image != null)
                SelectedAgentModel.Image.closeImageSource();

            foreach (AgentModel agentModel in AgentModelList)
            {
                if(agentModel.Image != null)
                    agentModel.Image.closeImageSource();
            }                

            AgentModelList = agentListToModelViewList(await Bl.BlAgent.GetAgentDataAsync(-999));
        }

        private bool checkIfAuthenticatedUserAdmin()
        {
            bool isAdminOnSecurtity = _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnCatalogue = _main.securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnAgent = _main.securityCheck(QOBDCommon.Enum.EAction.Agent, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Agent, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Agent, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Agent, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Agent, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnClient = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnNotification = _main.securityCheck(QOBDCommon.Enum.EAction.Notification, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Notification, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Notification, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Notification, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Notification, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnOption = _main.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnOrder = _main.securityCheck(QOBDCommon.Enum.EAction.Order, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Order, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Order, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Order, QOBDCommon.Enum.ESecurity._Update)
                                                && _main.securityCheck(QOBDCommon.Enum.EAction.Order, QOBDCommon.Enum.ESecurity._Write)
                                                   && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Billed, QOBDCommon.Enum.ESecurity.SendEmail)
                                                      && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Billed, QOBDCommon.Enum.ESecurity._Delete)
                                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Billed, QOBDCommon.Enum.ESecurity._Read)
                                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Billed, QOBDCommon.Enum.ESecurity._Update)
                                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Billed, QOBDCommon.Enum.ESecurity._Write)
                                                                    && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Close, QOBDCommon.Enum.ESecurity.SendEmail)
                                                                        && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Close, QOBDCommon.Enum.ESecurity._Delete)
                                                                            && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Close, QOBDCommon.Enum.ESecurity._Read)
                                                                                && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Close, QOBDCommon.Enum.ESecurity._Update)
                                                                                    && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Close, QOBDCommon.Enum.ESecurity._Write)
                                                                                        && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Preorder, QOBDCommon.Enum.ESecurity.SendEmail)
                                                                                            && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Preorder, QOBDCommon.Enum.ESecurity._Delete)
                                                                                                && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Preorder, QOBDCommon.Enum.ESecurity._Read)
                                                                                                    && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Preorder, QOBDCommon.Enum.ESecurity._Update)
                                                                                                        && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Preorder, QOBDCommon.Enum.ESecurity._Write)
                                                                                                            && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Valid, QOBDCommon.Enum.ESecurity.SendEmail)
                                                                                                                && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Valid, QOBDCommon.Enum.ESecurity._Delete)
                                                                                                                    && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Valid, QOBDCommon.Enum.ESecurity._Read)
                                                                                                                        && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Valid, QOBDCommon.Enum.ESecurity._Update)
                                                                                                                            && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Valid, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnQuote = _main.securityCheck(QOBDCommon.Enum.EAction.Quote, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Quote, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Quote, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Quote, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Quote, QOBDCommon.Enum.ESecurity._Write)
                                                    && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Quote, QOBDCommon.Enum.ESecurity.SendEmail)
                                                        && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Quote, QOBDCommon.Enum.ESecurity._Delete)
                                                            && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Quote, QOBDCommon.Enum.ESecurity._Read)
                                                                && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Quote, QOBDCommon.Enum.ESecurity._Update)
                                                                    && _main.securityCheck(QOBDCommon.Enum.EAction.Order_Quote, QOBDCommon.Enum.ESecurity._Write);

            bool isAdminOnStatistic = _main.securityCheck(QOBDCommon.Enum.EAction.Statistic, QOBDCommon.Enum.ESecurity.SendEmail)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Statistic, QOBDCommon.Enum.ESecurity._Delete)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Statistic, QOBDCommon.Enum.ESecurity._Read)
                                             && _main.securityCheck(QOBDCommon.Enum.EAction.Statistic, QOBDCommon.Enum.ESecurity._Update)
                                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Statistic, QOBDCommon.Enum.ESecurity._Write);

            return isAdminOnAgent && isAdminOnCatalogue && isAdminOnClient && isAdminOnNotification && isAdminOnOption && isAdminOnOrder && isAdminOnQuote && isAdminOnSecurtity && isAdminOnStatistic;
        }

        public override void Dispose()
        {
            // closing the image file before closing the app
            foreach (var agentModel in AgentModelList)
                if(agentModel.Image != null)
                    agentModel.Image.closeImageSource();

            Bl.BlAgent.Dispose();
            AgentDetailViewModel.Dispose();
            AgentSideBarViewModel.Dispose();
        }

        
        //----------------------------[ Action Commands ]------------------

        public async void moveAgentCLient(AgentModel obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["wait_message"]);
            List<Client> clientMovedList = new List<Client>();
            if(obj != null)
                foreach (var fromAgent in _clientAgentToMoveList)
                {
                    clientMovedList = clientMovedList.Concat( await Bl.BlAgent.MoveAgentClient(fromAgent, obj.Agent)).ToList();
                }
            if (clientMovedList.Count > 0)
                await Singleton.getDialogueBox().showAsync(string.Format("CLients moved successfully to {0}.", obj.TxtLastName));
            _clientAgentToMoveList.Clear();
            Singleton.getDialogueBox().IsDialogOpen = false;
            _page(this);
        }

        private bool canMoveClientAgent(AgentModel arg)
        {
            bool _isUserAdmin = _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity.SendEmail)
                             && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Delete)
                                 && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Read)
                                     && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Update)
                                         && _main.securityCheck(QOBDCommon.Enum.EAction.Security, QOBDCommon.Enum.ESecurity._Write);

            if (_isUserAdmin)
                return true;

            return false;
        }

        public void saveResultGridChecks(AgentModel param)
        {
            if (!_clientAgentToMoveList.Contains(param.Agent))
                _clientAgentToMoveList.Add(param.Agent);
            else
                _clientAgentToMoveList.Remove(param.Agent);
        }

        private bool canSaveResultGridChecks(AgentModel arg)
        {
            return true;
        }
        
        public void selectAgent(AgentModel obj)
        {
            if (obj != null)
            {
                SelectedAgentModel = obj;
                executeNavig("agent-detail");
            }                
        }

        private bool canSelectAgent(AgentModel arg)
        {
            // admin profile can access all profiles
            bool isUserAdmin = _main.AgentViewModel.IsAuthenticatedAgentAdmin;

            if (isUserAdmin)
                return true;

            // none admin can only access their own profile
            if (arg != null && (_page(null) as AgentViewModel == null && arg.Agent.ID == 0 ||  arg.Agent.ID != 0 && arg.TxtID == _main.AuthenticatedUserModel.TxtID))
                return true;


            return false;
        }

        public void executeNavig(string obj)
        {
            switch (obj)
            {
                case "agent":
                    _page(this);
                    break;
                case "agent-detail":
                    _page(AgentDetailViewModel);
                    break;
                default:
                    goto case "agent";
            }
        }

        private bool canExecuteNavig(string arg)
        {
            return true;
        }

        


    }
}
