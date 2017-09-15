using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using QOBDCommon.Entities;
using System.IO;
using System.Threading;
using QOBDCommon.Enum;
using QOBDCommon.Classes;
using System.Configuration;
using QOBDDAL.Core;
using QOBDModels.Classes;
using QOBDModels.Interfaces;
using QOBDViewModels.ViewModel;
using QOBDViewModels.Abstracts;
using System.Windows;
using QOBDModels.Command;
using QOBDModels.Models;
using QOBDViewModels.Interfaces;
using QOBDViewModels.Classes;
using QOBDModels.Abstracts;
using QOBDViewModels.Enums;
using System.Reflection;

namespace QOBDViewModels
{

    public class MainWindowViewModel : Classes.ViewModel, IMainWindowViewModel
    {
        string _lang;
        private IStartup _startup;
        private Object _currentViewModel;
        private object _chatRoomCurrentView;
        private double _progressBarPercentValue;
        private string _searchProgressVisibolity;
        private Context _context;
        private bool _isThroughContext;
        private bool _isRefresh;
        private int _heightDataList;
        private int _widthDataList;
        private Creator _viewModelCreator;
        private Creator _imageCreator;
        private Creator _contextCreator;
        private Creator _commandCreator;
        private ModelCreator _modelCreator;
        private string _companyName;

        //----------------------------[ Models ]------------------

        public IClientViewModel ClientViewModel { get; set; }
        public IItemViewModel ItemViewModel { get; set; }
        public IOrderViewModel OrderViewModel { get; set; }
        public IAgentViewModel AgentViewModel { get; set; }
        public INotificationViewModel NotificationViewModel { get; set; }
        public IHomeViewModel HomeViewModel { get; set; }
        public IReferentialViewModel ReferentialViewModel { get; set; }
        public IStatisticViewModel StatisticViewModel { get; set; }
        public IQuoteViewModel QuoteViewModel { get; set; }
        public ISecurityLoginViewModel SecurityLoginViewModel { get; set; }
        public IChatRoomViewModel ChatRoomViewModel { get; set; }


        //----------------------------[ Orders ]------------------        

        public ButtonCommand<string> CommandNavig { get; set; }
        public ButtonCommand<string> InformationDisplayCommand { get; set; }


        public MainWindowViewModel( IStartup startup, 
                                    Creator viewModelCreator, 
                                    Creator imageCreator,
                                    Creator contextCreator,
                                    Creator commandCreator,
                                    ModelCreator modelCreator) 
            : base()
        {           
            createCache();
            init(startup, viewModelCreator, imageCreator, contextCreator, modelCreator, commandCreator);
            CommandInstances();
            setInitEvents();
        }

        //----------------------------[ Initialization ]------------------

        private void init(  IStartup startup, 
                            Creator viewModelCreator, 
                            Creator imageCreator,
                            Creator contextCreator,
                            ModelCreator modelCreator,
                            Creator commandCreator)
        {
            _startup = startup;
            _viewModelCreator = viewModelCreator;
            _imageCreator = imageCreator;
            _contextCreator = contextCreator;
            _modelCreator = modelCreator;
            _commandCreator = commandCreator;

            _lang = Thread.CurrentThread.CurrentCulture.Name;
            _context = _contextCreator.createContext(this);
            _searchProgressVisibolity = "Visible";
            _startup.initialize();
            _widthDataList = 1200;
            _heightDataList = 600;                        
            
            //------[ ViewModels ]
            ItemViewModel = (IItemViewModel)_viewModelCreator.createViewModel( EViewModel.ITEM, this);
            ClientViewModel = (IClientViewModel)_viewModelCreator.createViewModel(EViewModel.CLIENT, this);
            AgentViewModel = (IAgentViewModel)_viewModelCreator.createViewModel(EViewModel.AGENT, this);
            ChatRoomViewModel = (IChatRoomViewModel)_viewModelCreator.createViewModel(EViewModel.CHAT, this);
            HomeViewModel = (IHomeViewModel)_viewModelCreator.createViewModel(EViewModel.HOME, this);
            NotificationViewModel = (INotificationViewModel)_viewModelCreator.createViewModel(EViewModel.NOTIFICATION, this);
            ReferentialViewModel = (IReferentialViewModel)_viewModelCreator.createViewModel(EViewModel.REFERENTIAL, this);
            StatisticViewModel = (IStatisticViewModel)_viewModelCreator.createViewModel(EViewModel.STATISTIC, this);
            OrderViewModel = (IOrderViewModel)_viewModelCreator.createViewModel(EViewModel.ORDER, this);
            QuoteViewModel = (IQuoteViewModel)_viewModelCreator.createViewModel(EViewModel.QUOTE, this);
            SecurityLoginViewModel = (ISecurityLoginViewModel)_viewModelCreator.createViewModel(EViewModel.SECURITYLOGIN, this);

        }

        private void CommandInstances()
        {            
            CommandNavig = _commandCreator.createSingleInputCommand<string>(appNavig, canAppNavig);
            InformationDisplayCommand = _commandCreator.createSingleInputCommand<string>(displayInformation, canDisplayInformation);
        }

        private void setInitEvents()
        {
            SecurityLoginViewModel.AgentModel.PropertyChanged += onAuthenticatedAgentChange;
            PropertyChanged += AgentViewModel.AgentSideBarViewModel.onCurrentPageChange_updateCommand;
            PropertyChanged += OrderViewModel.OrderSideBarViewModel.onCurrentPageChange_updateCommand;
            PropertyChanged += ClientViewModel.ClientSideBarViewModel.onCurrentPageChange_updateCommand;
        }

        //----------------------------[ Properties ]------------------

        public bool isNewAgentAuthentication { get; set; }

        public string TxtUserName
        {
            get { return AuthenticatedUserModel.TxtLogin ?? ""; }
        }

        public IConfirmationViewModel Dialog
        {
            get { return Singleton.getDialogueBox(); }
        }

        public IStartup Startup
        {
            get { return _startup; }
        }

        public AgentModel AuthenticatedUserModel
        {
            get { return new AgentModel { Agent = Startup.Bl.BlSecurity.GetAuthenticatedUser() }; }
        }

        public Creator ViewModelCreator
        {
            get { return _viewModelCreator; }
        }

        public Creator CommandCreator
        {
            get { return _commandCreator; }
        }

        public Creator ContextCreator
        {
            get { return _contextCreator; }
        }

        public Creator ImageCreator
        {
            get { return _imageCreator; }
        }

        public ModelCreator ModelCreator
        {
            get { return _modelCreator; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { setProperty(ref _companyName, value); }
        }

        public string TxtHeightDataList
        {
            get { return _heightDataList.ToString(); }
            set { setProperty(ref _heightDataList, Utility.intTryParse(value)); }
        }

        public string TxtWidthDataList
        {
            get { return _widthDataList.ToString(); }
            set { setProperty(ref _widthDataList, Utility.intTryParse(value)); }
        }

        public bool IsThroughContext
        {
            get { return _isThroughContext; }
            set { setProperty(ref _isThroughContext, value); }
        }

        public bool IsRefresh
        {
            get { return _isRefresh; }
            set { setProperty(ref _isRefresh, value); }
        }

        public Context Context
        {
            get { return _context; }
            set { setProperty(ref _context, value); }
        }

        public ISideBarViewModel OrderQuoteSideBar
        {
            get { return OrderViewModel.OrderSideBarViewModel; }
        }

        public string SearchProgressVisibility
        {
            get { return _searchProgressVisibolity; }
            set { setProperty(ref _searchProgressVisibolity, value); }
        }

        public Object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (Application.Current != null && !Application.Current.Dispatcher.CheckAccess())
                    Application.Current.Dispatcher.BeginInvoke((System.Action)(() =>
                    {
                        _currentViewModel = value;
                        onPropertyChange("CurrentViewModel");
                    }));
                else
                {
                    _currentViewModel = value;
                    onPropertyChange();
                }
            }
        }

        public Object ChatRoomCurrentView
        {
            get { return _chatRoomCurrentView; }
            set
            {
                if (Application.Current != null && !Application.Current.Dispatcher.CheckAccess())
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _chatRoomCurrentView = value;
                    });
                else
                    _chatRoomCurrentView = value;
                onPropertyChange();
            }
        }

        public double ProgressBarPercentValue
        {
            get { return _progressBarPercentValue; }
            set
            {
                if (Application.Current != null && !Application.Current.Dispatcher.CheckAccess())
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _progressBarPercentValue = value;
                    });
                else
                    _progressBarPercentValue = value;
                onPropertyChange();
            }
        }

        //----------------------------[ information properties ]------------------

        public string TxtInfo
        {
            get { return ConfigurationManager.AppSettings["info_description"]; }
        }

        public string TxtInfoAllRightText
        {
            get { return ConfigurationManager.AppSettings["info_all_right"]; }
        }

        public string TxtInfoActivationCode
        {
            get { return ConfigurationManager.AppSettings["info_activation_code"]; }
        }

        public string TxtInfoVersion
        {
            get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); }
        }

        public string TxtInfoCompanyName
        {
            get { return ConfigurationManager.AppSettings["info_company_name"]; }
        }

        //----------------------------[ Actions ]------------------

        private void createCache()
        {
            // initialize the DataDirectory to the user local folder
            AppDomain.CurrentDomain.SetData("DataDirectory", Utility.BaseDirectory);

            var unWritableAppDataDir = Utility.getOrCreateDirectory(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            var writableAppDataDir = (string)AppDomain.CurrentDomain.GetData("DataDirectory");

            try
            {
                // delete database if exists
                if (File.Exists(System.IO.Path.Combine(Utility.getOrCreateDirectory("App_Data"), "QCBDDatabase.sdf")))
                    File.Delete(System.IO.Path.Combine(Utility.getOrCreateDirectory("App_Data"), "QCBDDatabase.sdf"));

                // copy the database to user local folder
                if (!File.Exists(System.IO.Path.Combine(Utility.getOrCreateDirectory("App_Data"), "QCBDDatabase.sdf")))
                    File.Copy(System.IO.Path.Combine(unWritableAppDataDir, "QCBDDatabase.sdf"), System.IO.Path.Combine(Utility.getOrCreateDirectory("App_Data"), "QCBDDatabase.sdf"));

            }
            catch (Exception ex)
            {
                Log.error(ex.Message, EErrorFrom.MAIN);
            }
        }

        /// <summary>
        /// Initializing the User Interface
        /// </summary>
        public override void load()
        {
            SearchProgressVisibility = "Visible";
            if (isNewAgentAuthentication)
            {
                ProgressBarPercentValue = -1;
                _startup.Dal.SetUserCredential(SecurityLoginViewModel.Bl.BlSecurity.GetAuthenticatedUser(), CompanyName, isNewAgentAuthentication);
                isNewAgentAuthentication = false;
                ProgressBarPercentValue = 100;
            }
            else if (SecurityLoginViewModel.AgentModel.Agent.ID != 0)
            {
                _startup.Dal.ProgressBarFunc = progressBarManagement;
                _startup.Dal.SetUserCredential(AuthenticatedUserModel.Agent, CompanyName); 
            }

            CommandNavig.raiseCanExecuteActionChanged();
            AgentViewModel.GetCurrentAgentCommand.raiseCanExecuteActionChanged();
                      
            // display the chat view
            ChatRoomCurrentView = ChatRoomViewModel;

            // start the chat application
            //ChatRoomViewModel.start();
        }

        public Object navigation(Object centralPageContent = null)
        {
            if (centralPageContent != null)
            {      
                // save the previous page for later navigation
                if(Context.PreviousState != CurrentViewModel as IState)
                    Context.PreviousState = CurrentViewModel as IState;

                // set the current page 
                CurrentViewModel = centralPageContent;

                Context.NextState = centralPageContent as IState;
            }

            return CurrentViewModel;
        }

        public double progressBarManagement(double status = 0)
        {
            object _lock = new object();

            lock (_lock)
            {
                if (status != 0)
                {
                    _progressBarPercentValue += status;
                    if (status > 0)
                        SearchProgressVisibility = "Hidden";
                    onPropertyChange("ProgressBarPercentValue");
                }
            }

            return _progressBarPercentValue;
        }

        public bool securityCheck(EAction action, ESecurity right)
        {
            return SecurityLoginViewModel.securityCheck(action, right);
        }

        private void unsubscribeEvents()
        {
            SecurityLoginViewModel.AgentModel.PropertyChanged -= onAuthenticatedAgentChange;
            PropertyChanged -= AgentViewModel.AgentSideBarViewModel.onCurrentPageChange_updateCommand;
            PropertyChanged -= ClientViewModel.ClientSideBarViewModel.onCurrentPageChange_updateCommand;
            PropertyChanged -= OrderViewModel.OrderSideBarViewModel.onCurrentPageChange_updateCommand;
        }

        private void deleteCache()
        {
            try
            {
                // delete local temp database if exists
                if (File.Exists(System.IO.Path.Combine(Utility.getOrCreateDirectory("App_Data"), "QCBDDatabase.sdf")))
                    File.Delete(System.IO.Path.Combine(Utility.getOrCreateDirectory("App_Data"), "QCBDDatabase.sdf"));

                foreach (var file in Directory.GetFiles(Utility.getOrCreateDirectory(ConfigurationManager.AppSettings["local_tmp_folder"])))
                    File.Delete(file);
            }
            catch (Exception) { }
        }

        public async Task<bool> DisposeAsync()
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["close_message"]);
            unsubscribeEvents();
            ItemViewModel.Dispose();
            ClientViewModel.Dispose();
            QuoteViewModel.Dispose();
            OrderViewModel.Dispose();
            ReferentialViewModel.Dispose();
            AgentViewModel.Dispose();
            NotificationViewModel.Dispose();
            SecurityLoginViewModel.Dispose();
            HomeViewModel.Dispose();
            ChatRoomCurrentView = null;
            await ChatRoomViewModel.DisposeAsync();
            deleteCache();
            return true;
        }

        //----------------------------[ Event Handler ]------------------

        /// <summary>
        /// event listener to load UI data on authenticated user change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onAuthenticatedAgentChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Agent"))
            {
                if (Startup.Bl.BlSecurity.IsUserAuthenticated())
                    load();
                onPropertyChange("AuthenticatedUserModel");
                onPropertyChange("TxtUserName");
                CommandNavig.raiseCanExecuteActionChanged();
            }

        }


        //----------------------------[ Action Commands ]------------------
                

        /// <summary>
        /// display the software information
        /// </summary>
        /// <param name="obj"></param>
        private async void displayInformation(string obj)
        {
            await Singleton.getDialogueBox().showAsync(new HelperViewModel());
        }

        private bool canDisplayInformation(string arg)
        {
            return true;
        }

        /// <summary>
        /// allows navigating through the application
        /// </summary>
        /// <param name="propertyName"></param>
        public void appNavig(string propertyName)
        {
            // reset the navigation to previous page
            IsThroughContext = false;

            // reset page refreshing
            IsRefresh = false;

            switch (propertyName)
            {
                case "home":
                    CurrentViewModel = HomeViewModel;
                    break;
                case "client":
                    ClientViewModel.executeNavig(propertyName);
                    break;
                case "item":
                    ItemViewModel.executeNavig(propertyName);
                    break;
                case "order":
                    OrderViewModel.executeNavig(propertyName);
                    break;
                case "quote":
                    QuoteViewModel.executeNavig(propertyName);
                    break;
                case "agent":
                    AgentViewModel.executeNavig(propertyName);
                    break;
                case "notification":
                    CurrentViewModel = NotificationViewModel;
                    break;
                case "option":
                    ReferentialViewModel.executeNavig(propertyName);
                    break;
                case "statistic":
                    CurrentViewModel = StatisticViewModel;
                    break;
                case "back":
                    IsThroughContext = true;
                    Context.Request();
                    break;
                case "refresh":
                    IsRefresh = true;
                    onPropertyChange("CurrentViewModel");
                    break;
            }
        }

        public bool canAppNavig(string arg)
        {
            if (_startup == null)
                return false;
            if (AuthenticatedUserModel == null || AuthenticatedUserModel.TxtStatus == EStatus.Deactivated.ToString())
                return false;
            if (arg.Equals("client"))
                return securityCheck(QOBDCommon.Enum.EAction.Client, QOBDCommon.Enum.ESecurity._Read);
            if (arg.Equals("item"))
                return securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity._Read);
            if (arg.Equals("agent"))
                return AgentViewModel.IsAuthenticatedAgentAdmin;
            if (arg.Equals("notification"))
                return securityCheck(QOBDCommon.Enum.EAction.Notification, QOBDCommon.Enum.ESecurity._Read);
            if (arg.Equals("quote"))
                return securityCheck(QOBDCommon.Enum.EAction.Quote, QOBDCommon.Enum.ESecurity._Read);
            if (arg.Equals("order"))
                return securityCheck(QOBDCommon.Enum.EAction.Order, QOBDCommon.Enum.ESecurity._Read);
            if (arg.Equals("statistic"))
                return AgentViewModel.IsAuthenticatedAgentAdmin;
            if (arg.Equals("option"))
                return securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Read);
            if (arg.Equals("home") || arg.Equals("back") || arg.Equals("refresh"))
                return true;

            return false;
        }
    }
}
