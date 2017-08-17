﻿using QOBDCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QOBDCommon.Classes;
using QOBDViewModels.Interfaces;
using QOBDCommon.Enum;
using System.Configuration;
using QOBDModels.Models;
using QOBDModels.Command;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class ClientDetailViewModel : Classes.ViewModel
    {
        private Func<Object, Object> _page;
        private string _title;
        private List<string> _addressTypeList;


        //----------------------------[ Models ]------------------

        private ClientModel _selectedCLientModel;
        private IMainWindowViewModel _main;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<ClientModel> BtnSearchCommand { get; set; }
        public ButtonCommand<string> BtnDeleteCommand { get; set; }
        public ButtonCommand<string> BtnAddCommand { get; set; }
        public ButtonCommand<ClientModel> SelectClientForQuoteCommand { get; set; }
        public ButtonCommand<string> ValidChangeCommand { get; set; }
        public ButtonCommand<Contact> DetailSelectedContactCommand { get; set; }
        public ButtonCommand<Address> DetailSelectedAddressCommand { get; set; }

        public ClientDetailViewModel()
        {
            
        }

        public ClientDetailViewModel(IMainWindowViewModel main): this()
        {
            this._main = main;
            _page = _main.navigation;
            instances();
            instancesModel();
            instancesCommand();
        }

        //----------------------------[ Initialization ]------------------
        

        private void instances()
        {
            _title = ConfigurationManager.AppSettings["title_client_detail"];
            _addressTypeList = new List<string> { "Bill", "Delivery", "Other" };
        }

        private void instancesModel()
        {
            _selectedCLientModel = (ClientModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.CLIENT);
        }

        private void instancesCommand()
        {
            SelectClientForQuoteCommand = _main.CommandCreator.createSingleInputCommand<ClientModel>(setCartClientForQuote, canSetCartClientForQuote);
            ValidChangeCommand = _main.CommandCreator.createSingleInputCommand<string>(saveChanges, canSaveChanges);
            BtnSearchCommand = _main.CommandCreator.createSingleInputCommand<ClientModel>(selectNewClient, canSelectNewClient);
            BtnDeleteCommand = _main.CommandCreator.createSingleInputCommand<string>(deleteClientInfo, canDeleteClientInfo);
            BtnAddCommand = _main.CommandCreator.createSingleInputCommand<string>(addClientInfo, canAddClientInfo);
            DetailSelectedAddressCommand = _main.CommandCreator.createSingleInputCommand<Address>(detailSelectedAddress, canDetailSelectedAddress);
            DetailSelectedContactCommand = _main.CommandCreator.createSingleInputCommand<Contact>(detailSelectedContact, canDetailSelectedContact);
        }

        //----------------------------[ Properties ]------------------
        
        public ClientModel SelectedCLientModel
        {
            get { return _selectedCLientModel; }
            set { _selectedCLientModel = value; onPropertyChange("SelectedCLientModel"); }
        }

        public List<string> AddressTypeList
        {
            get { return _addressTypeList; }
            set { _addressTypeList = value; onPropertyChange("AddressTypeList"); }
        }

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public string Title
        {
            get { return _title; }
            set { setProperty(ref _title, value, "Title"); }
        }

        public bool IsNewContact { get; set; }
        public bool IsNewAddress { get; set; }

        //----------------------------[ Actions ]------------------
        
        public async Task<bool> confirmDeleting(string obj)
        {
            return await Singleton.getDialogueBox().showAsync(string.Format("Do you want to delete the {0}? ", obj));
        }

        public ClientModel loadContactsAndAddresses(ClientModel cLientModel)
        {
            cLientModel.AddressList = Bl.BlClient.searchAddress(new Address { ClientId = cLientModel.Client.ID }, ESearchOption.AND);
            cLientModel.Address = (cLientModel.AddressList.Count() > 0) ? cLientModel.AddressList.OrderBy(x => x.ID).Last() : new Address();
            cLientModel.ContactList = Bl.BlClient.GetContactDataByClientList(new List<Client> { new Client { ID = cLientModel.Client.ID } });
            cLientModel.Contact = (cLientModel.ContactList.Count() > 0) ? cLientModel.ContactList.OrderBy(x => x.ID).Last() : new Contact();

            return cLientModel;
        }

        //----------------------------[ Action Commands ]------------------

        private async void saveChanges(string obj)
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
            List<Client> savedClientList = new List<Client>();
            List<Address> savedAddressList = new List<Address>();
            List<Contact> savedContactList = new List<Contact>();

            bool isClientMandatoryFieldNotEmpty = !string.IsNullOrEmpty(SelectedCLientModel.TxtFirstName)
                                                && !string.IsNullOrEmpty(SelectedCLientModel.TxtLastName)
                                                    && !string.IsNullOrEmpty(SelectedCLientModel.TxtEmail)
                                                        && !string.IsNullOrEmpty(SelectedCLientModel.TxtCompany)
                                                            && !string.IsNullOrEmpty(SelectedCLientModel.TxtStatus)
                                                                && SelectedCLientModel.Client.MaxCredit != 0
                                                                    && SelectedCLientModel.Client.PayDelay != 0;

            bool isAddressMandatoryFieldNotEmpty = !string.IsNullOrEmpty(SelectedCLientModel.Address.Name)
                                                    && !string.IsNullOrEmpty(SelectedCLientModel.Address.AddressName)
                                                        && !string.IsNullOrEmpty(SelectedCLientModel.Address.CityName)
                                                            && !string.IsNullOrEmpty(SelectedCLientModel.Address.Postcode)
                                                                && !string.IsNullOrEmpty(SelectedCLientModel.Address.Country);

            bool isContactMandatoryFieldNotEmpty = ((!string.IsNullOrEmpty(SelectedCLientModel.Contact.Firstname)
                                                    && !string.IsNullOrEmpty(SelectedCLientModel.Contact.LastName))
                                                        && !string.IsNullOrEmpty(SelectedCLientModel.Contact.Phone)
                                                            && !string.IsNullOrEmpty(SelectedCLientModel.Contact.Email))
                                                                || (string.IsNullOrEmpty(SelectedCLientModel.Contact.Firstname)
                                                                    && string.IsNullOrEmpty(SelectedCLientModel.Contact.LastName));

            if (isClientMandatoryFieldNotEmpty && isAddressMandatoryFieldNotEmpty && isContactMandatoryFieldNotEmpty)
            {
                var updateCount = 0;
                var createCount = 0;

                // Client updating and creating
                if (SelectedCLientModel.Client.ID != 0)
                {
                    var updatedList = await Bl.BlClient.UpdateClientAsync(new List<Client> { SelectedCLientModel.Client });
                    updateCount++;
                }                    
                else
                {
                    SelectedCLientModel.Client.AgentId = Bl.BlSecurity.GetAuthenticatedUser().ID;
                    savedClientList = await Bl.BlClient.InsertClientAsync(new List<Client> { SelectedCLientModel.Client });
                    if (savedClientList.Count() > 0)
                    {
                        SelectedCLientModel.Client = savedClientList[0];
                        createCount++;
                    }
                }

                // Address updating and creating
                if (SelectedCLientModel.Address.ID != 0)
                {
                    var updatedList = await Bl.BlClient.UpdateAddressAsync(new List<Address> { SelectedCLientModel.Address });
                    updateCount++;
                }
                    
                else
                {
                    SelectedCLientModel.Address.ClientId = SelectedCLientModel.Client.ID;
                    savedAddressList = await Bl.BlClient.InsertAddressAsync(new List<Address> { SelectedCLientModel.Address });
                    if (savedAddressList.Count() > 0)
                    {
                        SelectedCLientModel.AddressList.Add(savedAddressList[0]);
                        SelectedCLientModel.Address = savedAddressList[0];
                        createCount++;
                    }
                }

                // Contact updating and creating
                if (SelectedCLientModel.Contact.ID != 0)
                {
                    var updatedList = await Bl.BlClient.UpdateContactAsync(new List<Contact> { SelectedCLientModel.Contact });
                    updateCount++;
                }                    
                else
                {
                    SelectedCLientModel.Contact.ClientId = SelectedCLientModel.Client.ID;
                    savedContactList = await Bl.BlClient.InsertContactAsync(new List<Contact> { SelectedCLientModel.Contact });
                    if (savedContactList.Count() > 0)
                    {
                        SelectedCLientModel.ContactList.Add(savedContactList[0]);
                        SelectedCLientModel.Contact = savedContactList[0];
                        createCount++;
                    }
                }

                if (updateCount > 0)
                    await Singleton.getDialogueBox().showAsync("Client has been successfully updated!");
                else if(createCount > 0)
                    await Singleton.getDialogueBox().showAsync("Client has been successfully created!");
            }
            else
            {
                if (!isClientMandatoryFieldNotEmpty)
                    await Singleton.getDialogueBox().showAsync("[Main detail]: Please fill up mandatory fields.");
                if (!isAddressMandatoryFieldNotEmpty)
                    await Singleton.getDialogueBox().showAsync("[Address detail]: Please fill up mandatory fields.");
                if (!isContactMandatoryFieldNotEmpty)
                    await Singleton.getDialogueBox().showAsync("[Contact detail]: Please fill up mandatory fields.");
            }

            Singleton.getDialogueBox().IsDialogOpen = false;       
            
            _page(this);

        }

        private bool canSaveChanges(string arg)
        {
            bool isUpdate = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Update);
            bool isWrite = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Write);
            if (isUpdate && isWrite)
                return true;
            return false;
        }

        public void setCartClientForQuote(ClientModel obj)
        {
            if (obj != null && obj.Client.ID != 0)
                Singleton.getCart().ClientModel = obj;
            else
                Singleton.getCart().ClientModel = SelectedCLientModel;

            _page(_main.QuoteViewModel);
        }

        private bool canSetCartClientForQuote(ClientModel arg)
        {
            bool canUpdate = _main.securityCheck(EAction.Client, ESecurity._Update) && _main.securityCheck(EAction.Quote, ESecurity._Update);
            bool canWrite = _main.securityCheck(EAction.Client, ESecurity._Write) && _main.securityCheck(EAction.Quote, ESecurity._Write);

            if (canWrite && canUpdate)
                return true;

            return false;
        }

        private async void deleteClientInfo(string obj)
        {            
            switch (obj)
            {
                case "client":
                    if (SelectedCLientModel != null && SelectedCLientModel.Client.ID != 0 && await confirmDeleting(obj))
                    {
                        Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);
                        var deletedAddressList = await Bl.BlClient.DeleteAddressAsync(_selectedCLientModel.AddressList);
                        var deletedContactList = await Bl.BlClient.DeleteContactAsync(_selectedCLientModel.ContactList);
                        var deletedClientList = await Bl.BlClient.DeleteClientAsync(new List<Client> { SelectedCLientModel.Client });
                        if (deletedClientList.Count == 0)
                        {
                            Singleton.getDialogueBox().showSearch("Client deleted successfully!");
                            _page(new ClientViewModel());
                        }                            
                    }
                    break;
                case "address":
                    if (SelectedCLientModel.Address != null && SelectedCLientModel.Address.ID != 0 && await confirmDeleting(obj))
                    {
                        Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);
                        var deletedAddressList = await Bl.BlClient.DeleteAddressAsync(new List<Address> { SelectedCLientModel.Address });
                        var clientModel = loadContactsAndAddresses(SelectedCLientModel);
                        SelectedCLientModel.AddressList = clientModel.AddressList;
                        SelectedCLientModel.Address = clientModel.Address;
                        if (deletedAddressList.Count == 0)
                        {
                            Singleton.getDialogueBox().showSearch("Address deleted successfully!");
                            _page(this);
                        }                            
                    }
                    break;
                case "contact":
                    if (SelectedCLientModel.Contact != null && SelectedCLientModel.Contact.ID != 0 && await confirmDeleting(obj))
                    {
                        Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);
                        var deletedContactList = await Bl.BlClient.DeleteContactAsync(new List<Contact> { SelectedCLientModel.Contact });
                        var clientModel = loadContactsAndAddresses(SelectedCLientModel);
                        SelectedCLientModel.ContactList = clientModel.ContactList;
                        SelectedCLientModel.Contact = clientModel.Contact;
                        if (deletedContactList.Count == 0)
                        {
                            Singleton.getDialogueBox().showSearch("Contact deleted successfully!");
                            _page(this);
                        } 
                    }
                    break;
            }
            Singleton.getDialogueBox().IsDialogOpen = false;
            
        }

        private bool canDeleteClientInfo(string arg)
        {
            bool isDelete = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Delete);
            if (isDelete)
                return true;
            return false;
        }

        private void addClientInfo(string obj)
        {
            switch (obj)
            {
                case "address":
                    SelectedCLientModel.Address = new Address();
                    break;
                case "contact":
                    SelectedCLientModel.Contact = new Contact();
                    break;
            }
        }

        private bool canAddClientInfo(string arg)
        {
            bool isUpdate = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Update);
            bool isWrite = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Write);
            if (isUpdate && isWrite)
                return true;
            return false;
        }

        private void selectNewClient(ClientModel obj)
        {
            SelectedCLientModel = loadContactsAndAddresses(obj);
            _page(this);
        }

        private bool canSelectNewClient(ClientModel arg)
        {
            return true;
        }

        private void detailSelectedContact(Contact obj)
        {
            SelectedCLientModel.Contact = obj;
        }

        private bool canDetailSelectedContact(Contact arg)
        {
            return true;
        }

        private void detailSelectedAddress(Address obj)
        {
            SelectedCLientModel.Address = obj;
        }

        private bool canDetailSelectedAddress(Address arg)
        {
            return true;
        }
    }
}
