using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using QOBDCommon.Classes;
using System.Windows.Controls;
using QOBDCommon.Enum;
using QOBDViewModels.Interfaces;
using QOBDCommon.Entities;
using System.Configuration;
using QOBDModels.Models;
using QOBDModels.Command;
using QOBDModels.Classes;
using System.IO;

namespace QOBDViewModels.ViewModel
{
    public class SecurityLoginViewModel : Classes.ViewModel, ISecurityLoginViewModel
    {
        private Func<Object, Object> _page;
        private string _errorMessage;
        private string _clearPassword;
        private string _login;
        private bool _isLicenseValid;

        //----------------------------[ Models ]------------------

        private AgentModel _agentModel;
        private IMainWindowViewModel _main;
        private LicenseViewModel _licenseViewModel;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<object> LogoutCommand { get; set; }


        public SecurityLoginViewModel()
        {
            instances();                         
        }

        public SecurityLoginViewModel(IMainWindowViewModel mainWindowViewModel): this()
        {
            _main = mainWindowViewModel;
            _page = _main.navigation;
            instancesModel();
            instancesCommand();
            initEvents();
            load();
        }

        //----------------------------[ Initialization ]------------------

        private void initEvents()
        {
            AgentModel.PropertyChanged += onAgentChange_goToHomePage;
        }

        private void instances()
        {
            _errorMessage = "";            
        }

        private void instancesModel()
        {
            _agentModel = (AgentModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.AGENT);
            _licenseViewModel = (LicenseViewModel)_main.ViewModelCreator.createViewModel(Enums.EViewModel.LICENSE, _main);
        }

        private void instancesCommand()
        {
            LogoutCommand = _main.CommandCreator.createSingleInputCommand<object>(logOut, canLogOut);
        }
        //----------------------------[ Properties ]------------------

        public string TxtPathFavicon
        {
            get { return System.IO.Path.Combine(Utility.getOrCreateDirectory("Docs", "images"), "favicon.ico"); }
        }

        public string TxtInfoAllRightText
        {
            get { return ConfigurationManager.AppSettings["info_all_right"]; }
        }

        public string TxtInfoCompanyName
        {
            get { return ConfigurationManager.AppSettings["info_company_name"]; }
        }

        public string TxtWelcomeMessage
        {
            get { return ConfigurationManager.AppSettings["info_welcome_message"]; }
        }

        public AgentModel AgentModel
        {
            get { return _agentModel; }
            set { setProperty(ref _agentModel, value); }
        }

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public string TxtErrorMessage
        {
            get { return _errorMessage; }
            set { setProperty(ref _errorMessage, value); }
        }

        public string TxtClearPassword
        {
            get { return _clearPassword; }
            set { _clearPassword = value; onPropertyChange(); }
        }

        public string TxtLogin
        {
            get { return _login; }
            set { _login = value; onPropertyChange(); }
        }

        public string TxtLicenseKey
        {
            get { return _licenseViewModel.LicenseKey; }
        }

        //----------------------------[ Actions ]------------------

        /// <summary>
        /// Show the login page when the Dialogue box is ready
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async override void load()
        {
            if (Application.Current != null)
                await showLoginView();
            //await startAuthentication(); //"<< for dev mode >>";
            else
                await startAuthentication();
        }

        public async Task showLoginView()
        {
            // display license view
            await checkLicense();                 

            // display login view
            bool result = await Singleton.getDialogueBox().showAsync(this);
            if (!string.IsNullOrEmpty(TxtLogin) && !string.IsNullOrEmpty(TxtClearPassword) && result)
            {
                await authenticateAgent();
                if (!Bl.BlSecurity.IsUserAuthenticated() || !Bl.BlSecurity.GetAuthenticatedUser().Status.Equals(EStatus.Active.ToString()))
                    await showLoginView();
            }
            //else
            //    await showLoginView();
        }

        public async Task<object> authenticateAgent()
        {
            try
            {
                Bl.BlSecurity.setCompanyName(_licenseViewModel.License.CompanyName);
                var agentFound = await Bl.BlSecurity.AuthenticateUserAsync(TxtLogin, TxtClearPassword, _licenseViewModel.License.Key);
                if (Bl.BlSecurity.IsUserAuthenticated())
                {
                    if(agentFound.Status.Equals(EStatus.Active.ToString()))
                    {
                        AgentModel.Agent = agentFound;
                        TxtLogin = "";
                        TxtClearPassword = "";
                        TxtErrorMessage = "";

                        if (_licenseViewModel.License.EndDate >= Utility.DateTimeMinValueInSQL2005
                            && _licenseViewModel.License.EndDate.Year == DateTime.Now.Year 
                                && _licenseViewModel.License.EndDate.Month == DateTime.Now.Month
                                    && _licenseViewModel.License.EndDate.Day - DateTime.Now.Day <= 10)
                            await Singleton.DialogBox.showAsync("Your license will expire in: [ " + (_licenseViewModel.License.EndDate.Day - DateTime.Now.Day) + " Day(s) ]");

                    }
                    else
                        TxtErrorMessage = "Your profile has been Deactivated!";
                }
                else
                    TxtErrorMessage = "Your user name or password is incorrect!";
            }
            catch (Exception)
            {
                await Singleton.getDialogueBox().showAsync("This application requires an internet connection, please check your internet connection." );
                await showLoginView();
            }             
            
            return null;
        }

        public async Task startAuthentication()
        {
            TxtLogin = "demo";// "<< Login here for dev mode >>";
            TxtClearPassword = "demo"; //"<< Password here for dev mode >>";

            await checkLicense();

            await authenticateAgent();
        }

        public bool securityCheck(EAction action, ESecurity right)
        {
            if (_main.Startup != null)
            {
                Agent agent = Bl.BlSecurity.GetAuthenticatedUser();
                if (agent.RoleList != null)
                {
                    foreach (var role in agent.RoleList)
                    {
                        var actionFound = role.ActionList.Where(x => x.Name.Equals(action.ToString())).FirstOrDefault();
                        if (actionFound != null)
                        {
                            switch (right)
                            {
                                case ESecurity._Delete:
                                    if (actionFound.Right.IsDelete)
                                        return actionFound.Right.IsDelete;
                                    break;
                                case ESecurity._Read:
                                    if (actionFound.Right.IsRead)
                                        return actionFound.Right.IsRead;
                                    break;
                                case ESecurity._Update:
                                    if (actionFound.Right.IsUpdate)
                                        return actionFound.Right.IsUpdate;
                                    break;
                                case ESecurity._Write:
                                    if (actionFound.Right.IsWrite)
                                        return actionFound.Right.IsWrite;
                                    break;
                                case ESecurity.SendEmail:
                                    if (actionFound.Right.IsSendMail)
                                        return actionFound.Right.IsSendMail;
                                    break;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private async Task checkLicense()
        {
            // display license view
            if (!_isLicenseValid)
            {
                _isLicenseValid = await _licenseViewModel.checkLicenseKey();
                if (!_isLicenseValid)
                {
                    await Singleton.getDialogueBox().showAsync(_licenseViewModel);
                    await showLoginView();
                }
            }
        }

        public override void Dispose()
        {
            AgentModel.PropertyChanged -= onAgentChange_goToHomePage;
        }

        //----------------------------[ Event Handler ]------------------
        
        /// <summary>
        /// get the password from the authentication dialog box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onPwdBoxPasswordChange_updateTxtClearPassword(object sender, RoutedEventArgs e)
        {
            TxtClearPassword = ((PasswordBox)sender).Password;
        }

        /// <summary>
        /// Display the home page if the user is authenticated 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onAgentChange_goToHomePage(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Agent") && Bl.BlSecurity.IsUserAuthenticated())
                _page(new HomeViewModel());
        } 

        //----------------------------[ Action Commands ]------------------

        private async void logOut(object obj)
        {
            await Bl.BlSecurity.DisconnectAuthenticatedUser();
            await Task.Factory.StartNew(()=> {
                _main.ChatRoomViewModel.Dispose();
            });
            AgentModel.Agent = new QOBDCommon.Entities.Agent();
            await showLoginView();
        }

        private bool canLogOut(object arg)
        {
            return true;
        }




    }
}
