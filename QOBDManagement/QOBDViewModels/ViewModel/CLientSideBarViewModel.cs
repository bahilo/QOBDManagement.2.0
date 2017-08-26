using System;
using System.Collections.Generic;
using System.ComponentModel;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;
using QOBDCommon.Enum;
using QOBDModels.Command;
using QOBDModels.Models;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class CLientSideBarViewModel : Classes.ViewModel, ISideBarViewModel
    {
        private Func<Object, Object> _page; 

        //----------------------------[ Models ]------------------

        private IMainWindowViewModel _main;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> SetupCommand { get; set; }
        public ButtonCommand<string> UtilitiesCommand { get; set; }



        public CLientSideBarViewModel() : base()
        {
            
        }

        public CLientSideBarViewModel(IMainWindowViewModel main): this()
        {
            _main = main;
            _page = _main.navigation;
            instancesCommand();
        }

        //----------------------------[ Initialization ]------------------
        
        private void instancesCommand()
        {
            SetupCommand = _main.CommandCreator.createSingleInputCommand<string>(executeSetupAction, canExecuteSetupAction);
            UtilitiesCommand = _main.CommandCreator.createSingleInputCommand<string>(executeUtilityAction, canExecuteUtilityAction);

        }

        //----------------------------[ Properties ]------------------
        
        public ClientModel SelectedClient
        {
            get { return _main.ClientViewModel.SelectedCLientModel; }
            set { _main.ClientViewModel.SelectedCLientModel = value; onPropertyChange(); }
        }

        public string TxtIconColour
        {
            get { return Utility.getRandomColour(); }
        }

        //----------------------------[ Actions ]------------------
        
        private void updateCommand()
        {
            UtilitiesCommand.raiseCanExecuteActionChanged();
            SetupCommand.raiseCanExecuteActionChanged();
        }

        public override void Dispose()
        {
        }

        //----------------------------[ Event Handler ]------------------
        
        private void onSelectedCLientChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedClient"))
                updateCommand();
        }

        public void onCurrentPageChange_updateCommand(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrentViewModel"))
                updateCommand();
        }

        //----------------------------[ Action Commands ]------------------
        
        private void executeUtilityAction(string obj)
        {
            if (_main != null)
            {
                switch (obj)
                {
                    case "select-quote-client":
                        Singleton.getCart().ClientModel = SelectedClient;
                        _page(_main.QuoteViewModel);
                        break;
                    case "client-order":
                        _main.OrderViewModel.SelectedClient = SelectedClient;
                        _page(_main.OrderViewModel);
                        break;
                    case "client-quote":
                        _main.QuoteViewModel.SelectedClient = SelectedClient;
                        _page(_main.QuoteViewModel);
                        break;
                    case "client":
                        _page(_main.ClientViewModel);
                        break;
                }
            }
        }

        private bool canExecuteUtilityAction(string arg)
        {
            bool canUpdate = _main.securityCheck(EAction.Client, ESecurity._Update) && _main.securityCheck(EAction.Quote, ESecurity._Update);
            bool canWrite = _main.securityCheck(EAction.Client, ESecurity._Write) && _main.securityCheck(EAction.Quote, ESecurity._Write);

            if (arg.Equals("client") && _page(null) as ClientViewModel == null)
                return false;

            if (_page(null) as ClientDetailViewModel == null)
                return false;

            if (arg.Equals("select-quote-client") && (!canWrite || !canUpdate))
                return false;
            
            if ( SelectedClient.Client.ID == 0
                && (arg.Equals("client-order")
                || arg.Equals("client-quote")
                || arg.Equals("select-quote-client")))
                return false;

            return true;
        }

        private void executeSetupAction(string obj)
        {
           switch (obj)
            {
                case "new-client":
                    SelectedClient.Client = new QOBDCommon.Entities.Client();
                    SelectedClient.Address = new QOBDCommon.Entities.Address();
                    SelectedClient.AddressList = new List<QOBDCommon.Entities.Address>();
                    SelectedClient.Contact = new QOBDCommon.Entities.Contact();
                    SelectedClient.ContactList = new List<QOBDCommon.Entities.Contact>();
                    _page((ClientDetailViewModel)_main.ViewModelCreator.createViewModel(Enums.EViewModel.CLIENTDETAIL, _main));
                    break;
                case "new-address":
                    SelectedClient.Address = new QOBDCommon.Entities.Address();
                    break;
                case "new-contact":
                    SelectedClient.Contact = new QOBDCommon.Entities.Contact();
                    break;
            }
        }

        private bool canExecuteSetupAction(string arg)
        {
            bool isUpdate = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Update);
            bool isWrite = _main.securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Write);
            if ((!isUpdate || !isWrite)
                && (arg.Equals("new-client")
                || arg.Equals("new-contact")
                || arg.Equals("new-address")))
                return false;

            if (_page(null) as ClientDetailViewModel == null && !arg.Equals("new-client"))
                return false;

            if (SelectedClient.Client.ID == 0
                && (arg.Equals("new-contact")
                || arg.Equals("new-address")))
                return false;

            if (SelectedClient.AddressList.Count == 0
                && arg.Equals("new-address"))
                return false;

            if (SelectedClient.ContactList.Count == 0
                && arg.Equals("new-contact"))
                return false;

            return true;
        }

        

        

    }
}
