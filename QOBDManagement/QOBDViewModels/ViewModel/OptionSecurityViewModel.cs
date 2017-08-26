﻿using Entity = QOBDCommon.Entities;
using QOBDCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QOBDViewModels.Interfaces;
using QOBDCommon.Enum;
using System.Configuration;
using QOBDModels.Models;
using QOBDModels.Command;
using QOBDCommon.Classes;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class OptionSecurityViewModel : Classes.ViewModel
    {
        private string _title;
        private IReferentialViewModel _referential;
        private Func<object, object> _page;
        private List<RoleModel> _roleModelList;
        private List<AgentModel> _agentModelList;
        private Dictionary<int, Role> _agentCreddentailTableHeaders;
        private Dictionary<int, int> _rolePosition = new Dictionary<int, int>();

        //----------------------------[ Models ]------------------

        //public ReferentialSideBarViewModel ReferentialSideBarViewModel { get; set; }

        //----------------------------[ Commands ]------------------

        public ButtonCommand<object> UpdateCredentialCommand { get; set; }
        public ButtonCommand<RoleModel> CbxGetSelectedRoleCommand { get; set; }
        public ButtonCommand<AgentModel> CbxGetSelectedAgentCommand { get; set; }


        public OptionSecurityViewModel()
        {
            
        }

        public OptionSecurityViewModel(IReferentialViewModel viewModel) : this()
        {
            _referential = viewModel;
            _page = _referential.MainWindowViewModel.navigation;
            instances();
            //instancesModel();
            instancesCommand();
        }

        //----------------------------[ Initialization ]------------------
        
        private void instances()
        {
            _roleModelList = new List<RoleModel>();
            _agentCreddentailTableHeaders = new Dictionary<int, Role>();
            _rolePosition = new Dictionary<int, int>();
            _agentModelList = new List<AgentModel>();
            _title = ConfigurationManager.AppSettings["title_setting_security"];
        }

        /*private void instancesModel()
        {
            ReferentialSideBarViewModel = _referential.MainWindowViewModel.ReferentialViewModel.ReferentialSideBarViewModel;
        }*/

        private void instancesCommand()
        {
            CbxGetSelectedRoleCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<RoleModel>(getCurrentRoleModel, canGetCurrentRoleModel);
            CbxGetSelectedAgentCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<AgentModel>(getCurrentAgentModel, canGetCurrentAgentModel);
            UpdateCredentialCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<object>(updateSecurityCredential, canUpdateSecurityCredential);
        }

        //----------------------------[ Properties ]------------------


        public string Title
        {
            get { return _title; }
            set { setProperty(ref _title, value); }
        }

        public Role HeaderRole1
        {
            get { return (_rolePosition.Count > 0) ? AgentCredentialHeaderTable[_rolePosition[0]] : new Role { Name = "HeaderRole1" }; }
        }

        public Role HeaderRole2
        {
            get { return (_rolePosition.Count > 1) ? AgentCredentialHeaderTable[_rolePosition[1]] : new Role { Name = "HeaderRole2" }; }
        }

        public Role HeaderRole3
        {
            get { return (_rolePosition.Count > 2) ? AgentCredentialHeaderTable[_rolePosition[2]] : new Role { Name = "HeaderRole3" }; }
        }

        public Role HeaderRole4
        {
            get { return (_rolePosition.Count > 3) ? AgentCredentialHeaderTable[_rolePosition[3]] : new Role { Name = "HeaderRole4" }; }
        }

        public Role HeaderRole5
        {
            get { return (_rolePosition.Count > 4) ? AgentCredentialHeaderTable[_rolePosition[4]] : new Role { Name = "HeaderRole5" }; }
        }

        public Role HeaderRole6
        {
            get { return (_rolePosition.Count > 5) ? AgentCredentialHeaderTable[_rolePosition[5]] : new Role { Name = "HeaderRole6" }; }
        }

        public Role HeaderRole7
        {
            get { return (_rolePosition.Count > 6) ? AgentCredentialHeaderTable[_rolePosition[6]] : new Role { Name = "HeaderRole7" }; }
        }

        public Role HeaderRole8
        {
            get { return (_rolePosition.Count > 7) ? AgentCredentialHeaderTable[_rolePosition[7]] : new Role { Name = "HeaderRole8" }; }
        }

        public Role HeaderRole9
        {
            get { return (_rolePosition.Count > 8) ? AgentCredentialHeaderTable[_rolePosition[8]] : new Role { Name = "HeaderRole9" }; }
        }

        public Dictionary<int, Role> AgentCredentialHeaderTable
        {
            get { return _agentCreddentailTableHeaders; }
            set { setProperty(ref _agentCreddentailTableHeaders, value); }
        }

        public List<AgentModel> AgentModelList
        {
            get { return _agentModelList; }
            set { setProperty(ref _agentModelList, value); }
        }

        public List<RoleModel> RoleModelList
        {
            get { return _roleModelList; }
            set { setProperty(ref _roleModelList, value); }
        }

        public BusinessLogic Bl
        {
            get { return _referential.MainWindowViewModel.Startup.Bl; }
        }

        //----------------------------[ Actions ]------------------

        public async Task<List<RoleModel>> getRoleModelAsync()
        {
            List<RoleModel> output = new List<RoleModel>();
            List<Role> roleList = await Bl.BlSecurity.GetRoleDataAsync(999);

            output = (from ro in roleList
                      from ac in ro.ActionList
                      let actionModel = new ActionModel
                      {
                          Action = ac,
                          PrivilegeModel = new PrivilegeModel { Privilege = ac.Right }
                      }
                      select new RoleModel
                      {
                          Role = ro,
                          ActionModel = actionModel
                      }).ToList();

            for (int i = 0; i < roleList.Count; i++)
            {
                _rolePosition[i] = roleList[i].ID;
                AgentCredentialHeaderTable[roleList[i].ID] = roleList[i];
            }

            onPropertyChange("HeaderRole1");
            onPropertyChange("HeaderRole2");
            onPropertyChange("HeaderRole3");
            onPropertyChange("HeaderRole4");
            onPropertyChange("HeaderRole5");
            onPropertyChange("HeaderRole6");
            onPropertyChange("HeaderRole7");
            onPropertyChange("HeaderRole8");
            onPropertyChange("HeaderRole9");

            return output;
        }

        public async Task<List<AgentModel>> getAgentModelAsync()
        {
            List<Agent> agentList = await Bl.BlAgent.GetAgentDataAsync(999);
            List<AgentModel> output = new List<AgentModel>();

            output = (from ag in agentList
                      select new AgentModel {
                          Agent = ag,
                          RoleModelList = RoleModelList.OrderBy(x => x.TxtID).Distinct().ToList(),
                          RolePositionDisplay = _rolePosition
                      }).ToList();
            
            return output;
        }

        public override async void load()
        {
            await Task.Factory.StartNew(async ()=> {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["load_message"]);
                RoleModelList = await getRoleModelAsync();
                AgentModelList = await getAgentModelAsync();

                Singleton.getDialogueBox().IsDialogOpen = false;
            });
        }

        private async Task<bool> updateRoleRights(List<RoleModel> roles)
        {
            bool isUpdateSuccessful = false;
            List<Privilege> privilegeToSaveList = new List<Privilege>();

            foreach (var roleModel in roles)
            {
                if (roleModel.ActionModel.PrivilegeModel.Privilege.ID != 0)
                     privilegeToSaveList.Add(roleModel.ActionModel.PrivilegeModel.Privilege);
                
            }
            var savedPrivilegeList = await Bl.BlSecurity.UpdatePrivilegeAsync(privilegeToSaveList);
            var savedRoleList = await Bl.BlSecurity.UpdateRoleAsync(roles.Where(x => x.Role.Name != "Anonymous").Select(x => x.Role).Distinct().ToList());

            if (savedPrivilegeList.Count > 0 || savedPrivilegeList.Count > 0)
                isUpdateSuccessful = true;

            return isUpdateSuccessful;
        }

        private async Task<bool> updateAgentRoles(Agent agent, List<RoleModel> RoleToAddList, List<RoleModel> RoleToRemoveList)
        {
            bool isUpdateSuccessful = false;

            List<Agent_role> agent_roleToAddList = new List<Agent_role>();
            List<Agent_role> agent_roleToRemoveList = new List<Agent_role>();

            // add role to agent
            foreach (var roleModel in RoleToAddList)
            {
                Agent_role agent_role = new Agent_role();
                agent_role.AgentId = agent.ID;
                agent_role.RoleId = roleModel.Role.ID;
                agent_roleToAddList.Add(agent_role);
            }

            // save new roles
            var agent_roleSavedList = await Bl.BlSecurity.InsertAgent_roleAsync(agent_roleToAddList);
            
            // delete agent role
            foreach (var roleModel in RoleToRemoveList)
            {
                var agent_roleFoundList = await Bl.BlSecurity.searchAgent_roleAsync(new Agent_role { AgentId = agent.ID, RoleId = roleModel.Role.ID }, ESearchOption.AND);
                agent_roleToRemoveList = new List<Agent_role>(agent_roleToRemoveList.Concat(agent_roleFoundList));
            }
            var deletedAgent_roleList = await Bl.BlSecurity.DeleteAgent_roleAsync(agent_roleToRemoveList);

            if (agent_roleSavedList.Count > 0 && deletedAgent_roleList.Count == 0)
                isUpdateSuccessful = true;

            return isUpdateSuccessful;
        }

        private bool updateAuthenticatedUserCredentialsOnActions(List<RoleModel> roles)
        {
            bool isUpdateSuccessful = false;
            Agent authenticatedUser = Bl.BlSecurity.GetAuthenticatedUser();
            
            foreach (RoleModel roleModel in roles)
            {
                Role authenticatedUserRole = authenticatedUser.RoleList.Where(x => x.Name.Equals(roleModel.Role.Name)).FirstOrDefault();
                if(authenticatedUserRole != null)
                {
                    Entity.Action authenticatedUserAction = (from r in authenticatedUser.RoleList.GroupBy(x => x.ActionList.Where(y => y.Name.Equals(roleModel.ActionModel.TxtName)).Count() > 0).Select(x => x.First()).ToList()
                                                             from a in r.ActionList
                                                             where a.Name == roleModel.ActionModel.TxtName
                                                             select a).FirstOrDefault();
                    if (authenticatedUserAction != null)
                    {
                        authenticatedUserAction.Right.IsDelete = roleModel.ActionModel.PrivilegeModel.IsDelete;
                        authenticatedUserAction.Right.IsRead = roleModel.ActionModel.PrivilegeModel.IsRead;
                        authenticatedUserAction.Right.IsUpdate = roleModel.ActionModel.PrivilegeModel.IsUpdate;
                        authenticatedUserAction.Right.IsWrite = roleModel.ActionModel.PrivilegeModel.IsWrite;
                        isUpdateSuccessful = true;
                    }
                }                
            }
            return isUpdateSuccessful;
        }

        private bool updateAuthenticatedUserRoles(List<RoleModel> roles)
        {
            bool isUpdateSuccessful = false;
            Agent authenticatedUser = Bl.BlSecurity.GetAuthenticatedUser();
           
            // add role to agent
            foreach (var roleModel in roles)
            {
                Role authenticatedUserRole = authenticatedUser.RoleList.Where(x => x.Name.Equals(roleModel.Role.Name)).FirstOrDefault();
                if (authenticatedUserRole == null)
                    authenticatedUser.RoleList.Add(roleModel.Role);
            }

            // Delete Agent role
            foreach (var roleModel in roles)
            {
                Role authenticatedUserRole = authenticatedUser.RoleList.Where(x => x.Name.Equals(roleModel.Role.Name)).FirstOrDefault();
                if (authenticatedUserRole != null)
                    authenticatedUser.RoleList.Remove(roleModel.Role);
            }

            return isUpdateSuccessful;
        }

        //----------------------------[ Action Commands ]------------------

        private void getCurrentRoleModel(RoleModel obj)
        {
            obj.IsModified = true;
            obj.ActionModel.IsModified = true;
        }

        private bool canGetCurrentRoleModel(RoleModel arg)
        {
            return true;
        }

        private async void updateSecurityCredential(object obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);

            // update role right on actions
            List<RoleModel> roleModifiedList = RoleModelList.Where(x => x.IsModified).ToList();
            bool isRightsUpdatedSuccessfully = await updateRoleRights(roleModifiedList);

            // updating authenticated user
            if(isRightsUpdatedSuccessfully)
                isRightsUpdatedSuccessfully = updateAuthenticatedUserCredentialsOnActions(roleModifiedList);

            // update agent role            
            var agent_roleProcessedList = new List<Agent_role>();
            var agentModifiedList = AgentModelList.Where(x => x.IsModified).ToList();
            
            foreach (var agentModel in agentModifiedList)
            {
                if ( await updateAgentRoles(agentModel.Agent, agentModel.RoleToAddList, agentModel.RoleToRemoveList))
                    agent_roleProcessedList = agent_roleProcessedList.Concat(agentModel.RoleToAddList.Select(x=>new Agent_role { AgentId = agentModel.Agent.ID, RoleId = x.Role.ID }).ToList()).ToList();
                
                agentModel.IsModified = false;
                agentModel.RoleToAddList.Clear();
                agentModel.RoleToRemoveList.Clear();
            }

            if (agent_roleProcessedList.Count > 0 || isRightsUpdatedSuccessfully)
            {
                updateAuthenticatedUserRoles(agentModifiedList.Where(x => x.Agent.ID == Bl.BlSecurity.GetAuthenticatedUser().ID).SelectMany(x => x.RoleList.Select(y=>new RoleModel { Role = y })).ToList());
                await Singleton.getDialogueBox().showAsync("Security updated successfuly!");
                _referential.MainWindowViewModel.CommandNavig.raiseCanExecuteActionChanged();
                //_page(this);
            }
            
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        private bool canUpdateSecurityCredential(object arg)
        {
            return true;
        }

        private void getCurrentAgentModel(AgentModel obj)
        {
            obj.IsModified = true;
        }

        private bool canGetCurrentAgentModel(AgentModel arg)
        {
            return true;
        }



    }
}
