﻿using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDCommon.Enum;
using QOBDViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using QOBDModels.Models;
using QOBDModels.Command;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class ClientViewModel : Classes.ViewModel
    {
        private List<string> _saveSearchParametersList;
        private Func<Object, Object> _page;
        private string _title;
        private List<Agent> _agentList;
        private List<Client> _clientList;
        private List<Client> _saveResultParametersList;

        //----------------------------[ Models ]------------------

        private ClientModel _clientModel;
        private List<ClientModel> _clientsModel;
        private ClientDetailViewModel _clientDetailViewModel;
        private IMainWindowViewModel _main;
        public CLientSideBarViewModel ClientSideBarViewModel { get; set; }

        //----------------------------[ Commands ]------------------

        public ButtonCommand<ClientModel> checkBoxResultGridCommand { get; set; }
        public ButtonCommand<string> checkBoxSearchCommand { get; set; }
        public ButtonCommand<string> rBoxSearchCommand { get; set; }
        public ButtonCommand<Agent> btnComboBxCommand { get; set; }
        public ButtonCommand<string> btnSearchCommand { get; set; }
        public ButtonCommand<string> NavigCommand { get; set; }
        public ButtonCommand<ClientModel> ClientDetailCommand { get; set; }
        public ButtonCommand<ClientModel> rbSelectClientForQuoteCommand { get; set; }
                

        public ClientViewModel()
        {
            instances();
            
        }

        public ClientViewModel(IMainWindowViewModel mainWindowViewModel): this()
        {
            this._main = mainWindowViewModel;
            _page = _main.navigation;
            instancesModel(mainWindowViewModel);
            instancesCommand();
        }

        //----------------------------[ Initialization ]------------------
        

        private void instances()
        {
            _title = ConfigurationManager.AppSettings["title_client"];
            _saveSearchParametersList = new List<string>();
            _saveResultParametersList = new List<Client>();
            _agentList = new List<Agent>();
            _clientList = new List<Client>();
        }

        private void instancesModel(IMainWindowViewModel main)
        {
            _clientsModel = new List<ClientModel>();
            _clientModel = (ClientModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.CLIENT);
            _clientDetailViewModel = (ClientDetailViewModel)_main.ViewModelCreator.createViewModel(Enums.EViewModel.CLIENTDETAIL, main);
            ClientSideBarViewModel = (CLientSideBarViewModel)_main.ViewModelCreator.createViewModel(Enums.EViewModel.CLIENTMENU, main);
        }

        private void instancesCommand()
        {
            checkBoxResultGridCommand = _main.CommandCreator.createSingleInputCommand<ClientModel>(saveResultGridChecks, canSaveResultGridChecks);
            checkBoxSearchCommand = _main.CommandCreator.createSingleInputCommand<string>(saveSearchChecks, canSaveSearchChecks);
            rBoxSearchCommand = _main.CommandCreator.createSingleInputCommand<string>(saveSearchRadioButtonSelection, canSaveSearchRadioButtonSelection);
            btnComboBxCommand = _main.CommandCreator.createSingleInputCommand<Agent>(moveCLientAgent, canMoveClientAgent);
            btnSearchCommand = _main.CommandCreator.createSingleInputCommand<string>(filterClient, canFilterClient);
            NavigCommand = _main.CommandCreator.createSingleInputCommand<string>(executeNavig, canExecuteNavig);
            ClientDetailCommand = _main.CommandCreator.createSingleInputCommand<ClientModel>(selectCurrentClient, canSelectedCurrentClient);
            rbSelectClientForQuoteCommand = _main.CommandCreator.createSingleInputCommand<ClientModel>(selectClientForQuote, canSelectClientForQuote);

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

        public List<ClientModel> ClientModelList
        {
            get { return _clientsModel; }
            set { setProperty(ref _clientsModel, value); }
        }

        public List<Agent> AgentList
        {
            get { return _agentList; }
            set { setProperty(ref _agentList, value); }
        }

        public ClientDetailViewModel ClientDetailViewModel
        {
            get { return _clientDetailViewModel; }
            set { _clientDetailViewModel = value; onPropertyChange("ClientDetailViewModel"); }
        }

        public ClientModel SelectedCLientModel
        {
            get { return _clientDetailViewModel.SelectedCLientModel; }
            set { _clientDetailViewModel.SelectedCLientModel = value; onPropertyChange("SelectedCLientModel"); }
        }

        public ClientModel ClientModel
        {
            get { return _clientModel; }
            set { _clientModel = value; onPropertyChange("ClientModel"); }
        }


        //----------------------------[ Actions ]------------------

        public void loadClients()
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["load_message"]);
            AgentList = Bl.BlAgent.GetAgentData(999);
            ClientModelList = clientListToModelViewList(Bl.BlClient.searchClient(new Client { AgentId = Bl.BlSecurity.GetAuthenticatedUser().ID }, ESearchOption.AND));
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        public List<ClientModel> clientListToModelViewList(List<Client> clientList)
        {
            object objectLock = new object();
            List<ClientModel> output = new List<ClientModel>();

            lock(objectLock)
                foreach(Client client in clientList)
                {
                    ClientModel cvm = (ClientModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.CLIENT);
                    if (AgentList.Count() > 0)
                    {
                        var result = AgentList.Where(x => x.ID.Equals(client.AgentId)).ToList();
                        cvm.Agent.Agent = (result.Count > 0) ? result[0] : new Agent();
                    }
                    cvm.Client = client;
                    output.Add(cvm);
                }
            return output;
        }

        public override void Dispose()
        {
            ClientDetailViewModel.Dispose();
            ClientSideBarViewModel.Dispose();
        }

        //----------------------------[ Event Handler ]------------------
        

        //----------------------------[ Action Commands ]------------------

        public void selectCurrentClient(ClientModel obj)
        {
            SelectedCLientModel = ClientDetailViewModel.loadContactsAndAddresses(obj);
            executeNavig("client-detail");
        }

        private bool canSelectedCurrentClient(ClientModel arg)
        {
            return true;
        }

        public void executeNavig(string obj)
        {
            switch (obj)
            {
                case "client":
                    _page(this);
                    break;
                case "client-detail":
                    _page(ClientDetailViewModel);
                    break;
                case "client-new":
                    SelectedCLientModel = (ClientModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.CLIENT);
                    _page(ClientDetailViewModel);
                    break;
                default:
                    goto case "client";
            }
        }

        private bool canExecuteNavig(string arg)
        {
            return true;
        }

        private async void moveCLientAgent(Agent obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["wait_message"]);
            var movedClientList = await Bl.BlClient.MoveClientAgentBySelection(_saveResultParametersList, obj);
            if (movedClientList.Count > 0)
                await Singleton.getDialogueBox().showAsync(movedClientList.Count +" client(s) have been moved to "+obj.LastName+" successfully!");

            _saveResultParametersList.Clear();
            Singleton.getDialogueBox().IsDialogOpen = false;
            _page(this);
        }

        private bool canMoveClientAgent(Agent arg) 
        {
            bool isUserAdmin = _main.AgentViewModel.IsAuthenticatedAgentAdmin;

            if (isUserAdmin)
                return true;

            return false;
        }

        private async void filterClient(string obj)
        {
            ClientModel clientModel = (ClientModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.CLIENT);
            string restrict = "";
            bool isDeep = false;
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["search_message"]);

            clientModel.TxtID = obj;
            foreach (string checkedValue in _saveSearchParametersList)
            {
                switch (checkedValue)
                {
                    case "cbContact":
                        clientModel.TxtFirstName = obj;
                        clientModel.TxtLastName = obj;
                        break;
                    case "cbCompany":
                        clientModel.TxtCompany = clientModel.TxtCompanyName = obj;
                        //client.CompanyName = obj;
                        break;
                    case "Client":
                        restrict = EStatus.Client.ToString();
                        clientModel.TxtStatus = EStatus.Client.ToString();
                        break;
                    case "Prospect":
                        restrict = EStatus.Prospect.ToString();
                        clientModel.TxtStatus = EStatus.Prospect.ToString();
                        break;
                    case "cbDeep":
                        isDeep = true;
                        break;
                }
            }

            List<Client> resultAfterFilter = new List<Client>();
            List<Client> resultBeforeFilter = new List<Client>();

            if(isDeep)
                resultBeforeFilter = await Bl.BlClient.searchClientAsync(clientModel.Client, ESearchOption.AND);
            else
                resultBeforeFilter = Bl.BlClient.searchClient(clientModel.Client, ESearchOption.AND);

            // getting only clients created by the authenticated agent.
            resultBeforeFilter = resultBeforeFilter.Where(x=>x.AgentId == Bl.BlSecurity.GetAuthenticatedUser().ID).ToList();

            if (string.Equals(restrict, EStatus.Client.ToString()))
            {
                resultAfterFilter = resultBeforeFilter.Where(x => x.Status == EStatus.Client.ToString()).ToList();
            }
            else if (string.Equals(restrict, EStatus.Prospect.ToString()))
            {
                resultAfterFilter = resultBeforeFilter.Where(x => x.Status == EStatus.Prospect.ToString()).ToList();
            }
            else
            {
                resultAfterFilter = resultBeforeFilter;
            }

            ClientModelList = clientListToModelViewList(resultAfterFilter);
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        private bool canFilterClient(string arg)
        {
            return true;
        }

        public void saveResultGridChecks(ClientModel param)
        {
            if (!_saveResultParametersList.Contains(param.Client))
                _saveResultParametersList.Add(param.Client);
            else
                _saveResultParametersList.Remove(param.Client);
        }

        public bool canSaveResultGridChecks(ClientModel param)
        {
            return true;
        }

        private void saveSearchChecks(string obj)
        {
            if (!_saveSearchParametersList.Contains(obj))
                _saveSearchParametersList.Add(obj);
            else
                _saveSearchParametersList.Remove(obj);
        }

        private bool canSaveSearchChecks(string arg)
        {
            return true;
        }


        private void saveSearchRadioButtonSelection(string obj)
        {
            if (!_saveSearchParametersList.Contains(obj) && string.Equals(obj, "Client"))
            {
                _saveSearchParametersList.Add(obj);
                _saveSearchParametersList.Remove("Prospect");
            }
            else
            {
                _saveSearchParametersList.Add(obj);
                _saveSearchParametersList.Remove("Client");
            }

        }

        private bool canSaveSearchRadioButtonSelection(string arg)
        {
            return true;
        }

        private async void selectClientForQuote(ClientModel obj)
        {
            if (obj != null && await Singleton.getDialogueBox().showAsync("Do you confirme selecting " + obj.TxtCompany + " for a Quote?"))
                ClientDetailViewModel.setCartClientForQuote(obj);
            else
                obj.IsSelectForQuote = false;
        }

        private bool canSelectClientForQuote(ClientModel arg)
        {
            // enable only during quote creation
            if(_main.Context != null && (_main.Context.PreviousState as QuoteViewModel) != null)
                return true;

            return false;
        }


    }
}
