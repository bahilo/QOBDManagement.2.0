using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDDAL.Core;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDModels.Models;
using QOBDViewModels.Classes;
using QOBDViewModels.Helper;
using QOBDViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace QOBDViewModels.ViewModel
{
    public class ChatRoomViewModel : Classes.ViewModel, IChatRoomViewModel
    {
        private Context _context;
        private Object _currentViewModel;
        private bool _isServerConnectionError;
        private IMainWindowViewModel _main;
        private AgentModel _authenticatedAgent;

        //----------------------------[ ViewModels ]------------------

        public IDiscussionViewModel DiscussionViewModel { get; set; }
        public IMessageViewModel MessageViewModel { get; set; }



        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> CommandNavig { get; set; }
        public ButtonCommand<object> DisplayAccountCommand { get; set; }
        public ButtonCommand<object> ChatValidUserAccountCommand { get; set; }


        public ChatRoomViewModel()
        {
            
        }

        public ChatRoomViewModel(IMainWindowViewModel mainWindowViewModel) : this()
        {
            _main = mainWindowViewModel;
            _context = _main.ContextCreator.createContext(_main);
            init();
            setInitEvents();
        }


        //----------------------------[ Initialization ]------------------
        
        private void init()
        {
            DiscussionViewModel = (DiscussionViewModel)_main.ViewModelCreator.createChatViewModel(Enums.EViewModel.CHATDISCUSSION, this);
            MessageViewModel = (MessageViewModel)_main.ViewModelCreator.createChatViewModel(Enums.EViewModel.CHATMESSAGE, this);
            CurrentViewModel = MessageViewModel;            
        }

        private void setInitEvents()
        {
            DiscussionViewModel.addObserver(onChatRoomChange);
            DiscussionViewModel.addObserver(onUpdateUsersStatusChange);
            _main.Startup.Dal.DALAgent.PropertyChanged += onAgentDataDownloadingStatusChange;
        }

        private void CommandInstances()
        {
            CommandNavig = _main.CommandCreator.createSingleInputCommand<string>(appNavig, canAppNavig);
            DisplayAccountCommand = _main.CommandCreator.createSingleInputCommand<object>(displayChatAgentAccount, canDisplayChatAgentAccount);
            ChatValidUserAccountCommand = _main.CommandCreator.createSingleInputCommand<object>(validChatAccount, canValidChatAccount);
        }


        //----------------------------[ Properties ]------------------

        public Object CurrentViewModel
        {
            get { return _currentViewModel; }
            set { setProperty(ref _currentViewModel, value); }
        }

        public IConfirmationViewModel Dialog
        {
            get { return Singleton.getDialogueBox(); }
        }

        public string TxtIconColour
        {
            get { return Utility.getRandomColour(); }
        }

        public AgentModel AuthenticatedAgent
        {
            get { return _authenticatedAgent; }
            set { _authenticatedAgent = value; onPropertyChange(); }
        }

        public string ChatAuthenticatedWelcomeMessage
        {
            get { return _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().Comment; }
            set { _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().Comment = value; onPropertyChange(); }
        }

        public IAgentViewModel AgentViewModel
        {
            get { return _main.AgentViewModel; }
        }

        public IPEndPoint EndPoint
        {
            get { return DiscussionViewModel.EndPoint; }
            set { DiscussionViewModel.EndPoint = value; onPropertyChange(); }
        }

        public UdpClient UdpClient
        {
            get { return DiscussionViewModel.UdpClient; }
            set { DiscussionViewModel.UdpClient = value; onPropertyChange(); }
        }

        public IMainWindowViewModel MainWindowViewModel
        {
            get { return _main; }
        }

        public string TxtUserName
        {
            get { return (_main.Startup.Bl != null) ? _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().UserName : ""; }
        }

        public Context Context
        {
            get { return _context; }
            set { setProperty(ref _context, value); }
        }


        //----------------------------[ Actions ]------------------
        
        /// <summary>
        /// start the chat server
        /// </summary>
        public async void start()
        {      
            if(Application.Current != null)
            {
                // loading chat information
                loadChatData();

                // listening incoming messages
                await receiverAsync();
            }
        }

        private async void loadChatData()
        {
            int port = 0;

            // get user details
            await getChatUserInformation();

            // loading users dicussions
            await MessageViewModel.loadAsync();

            // getting available port number
            string myIpAddress = GetAddresses();
            using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                sock.Bind(new IPEndPoint(IPAddress.Parse(myIpAddress), 0));
                port = ((IPEndPoint)sock.LocalEndPoint).Port;
            }

            AuthenticatedAgent.TxtIPAddress = myIpAddress + ":" + port;
        }

        public async Task getChatUserInformation()
        {
            _authenticatedAgent = new AgentModel { Agent = _main.Startup.Bl.BlSecurity.GetAuthenticatedUser() };

            // load chat user
            await _main.AgentViewModel.loadAgents();

            // close user images
            foreach (AgentModel agentModel in _main.AgentViewModel.AgentModelList)
            {
                if (agentModel.Image != null)
                    agentModel.Image.closeImageSource();
            }

            // download chat user's picture
            var ftpCredentials = _main.Startup.Bl.BlReferential.searchInfo(new Info { Name = "ftp_" }, QOBDCommon.Enum.ESearchOption.AND);
            foreach (AgentModel agentModel in _main.AgentViewModel.AgentModelList)
                agentModel.Image = await Task.Factory.StartNew(()=> { return agentModel.Image.downloadPicture(ConfigurationManager.AppSettings["ftp_profile_image_folder"], ConfigurationManager.AppSettings["local_profile_image_folder"], agentModel.TxtPicture, agentModel.TxtProfileImageFileNameBase + "_" + agentModel.Agent.ID, ftpCredentials); });

            DiscussionViewModel.ChatAgentModelList = _main.AgentViewModel.AgentModelList.Where(x => x.Agent.ID != _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().ID).OrderByDescending(x=>x.IsOnline).ToList();
            AuthenticatedAgent.Image = _main.AgentViewModel.AgentModelList.Where(x => x.TxtID == AuthenticatedAgent.TxtID).Select(x => x.Image).SingleOrDefault();

            Singleton.getDialogueBox().IsChatDialogOpen = false;
        }

        /// <summary>
        /// broadcast 
        /// </summary>
        private async Task receiverAsync()
        {
            try
            {
                // updating the user status                
                AuthenticatedAgent.IsOnline = true;
                var updatedUserList = await _main.Startup.Bl.BlAgent.UpdateAgentAsync(new List<Agent> { AuthenticatedAgent.Agent });

                if (updatedUserList.Count > 0)
                {
                    int port = Utility.intTryParse(updatedUserList[0].IPAddress.Split(':')[1]);
                    IPAddress ipAddress = default(IPAddress);
                    IPAddress.TryParse(updatedUserList[0].IPAddress.Split(':')[0], out ipAddress);

                    EndPoint = new IPEndPoint(ipAddress, port);
                    UdpClient = new UdpClient(port);
                    
                    // updating authenticated user online status 
                    DiscussionViewModel.SelectedAgentModel = (AgentModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.AGENT);
                    await DiscussionViewModel.broadcastMessageAsync(DiscussionViewModel.WelcomeMessage);

                    // create discussion thread
                    Thread ctThread = new Thread(DiscussionViewModel.getMessage);
                    ctThread.SetApartmentState(ApartmentState.STA);
                    ctThread.IsBackground = true;
                    ctThread.Start();
                }
                else
                    new ApplicationException("Error while updating the user["+ AuthenticatedAgent.TxtID + "|"+ AuthenticatedAgent.TxtIPAddress+ "] network information");
            }
            catch (Exception ex)
            {
                _isServerConnectionError = true;
                CurrentViewModel = DiscussionViewModel;
                Log.error("<[" + _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().UserName + "]Localhost =" + _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().IPAddress + "> " + ex.Message, QOBDCommon.Enum.EErrorFrom.CHATROOM);

                // updating the user status
                AuthenticatedAgent.IsOnline = false;
                var updatedUserList = await _main.Startup.Bl.BlAgent.UpdateAgentAsync(new List<Agent> { AuthenticatedAgent.Agent });
            }
        }

        public static string GetAddresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            var addressList = (from ip in host.AddressList where ip.AddressFamily == AddressFamily.InterNetwork select ip.ToString()).ToList();
            foreach (string address in addressList)
            {
                IPAddress ipAddress = GetIPAddress(address);
                if (ipAddress != null)
                    return ipAddress.ToString();
            }
            return "";
        }

        public static IPAddress GetIPAddress(string hostName)
        {
            Ping ping = new Ping();
            var replay = ping.Send(hostName);

            if (replay.Status == IPStatus.Success)
            {
                return replay.Address;
            }
            return null;
        }

        private async void updateUsersOnlineStatus()
        {
            // load chat user
            await _main.AgentViewModel.loadAgents();

            // close user images
            foreach (AgentModel agentModel in DiscussionViewModel.ChatAgentModelList)
            {
                var agentWithNewStatus = _main.AgentViewModel.AgentModelList.Where(x => x.TxtID == agentModel.TxtID).FirstOrDefault();
                if (agentWithNewStatus != null)
                    agentModel.IsOnline = agentWithNewStatus.IsOnline;
            }

            DiscussionViewModel.SelectUserForDiscussionCommand.raiseCanExecuteActionChanged();
            DiscussionViewModel.DiscussionAddUserCommand.raiseCanExecuteActionChanged();
        }

        public object navigation(object centralPageContent = null)
        {
            if (centralPageContent != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Context.PreviousState = CurrentViewModel as IState;
                    CurrentViewModel = centralPageContent;
                    Context.NextState = centralPageContent as IState;
                });
            }
            return CurrentViewModel;
        }

        private void unSubscribeEvents()
        {
            // unsubscribe events
            DiscussionViewModel.removeObserver(onChatRoomChange);
            DiscussionViewModel.removeObserver(onUpdateUsersStatusChange);
            _main.Startup.Dal.DALAgent.PropertyChanged -= onAgentDataDownloadingStatusChange;
        }

        private async Task signOutFromServerAsync(List<DiscussionModel> discussionList)
        {
            try
            {
                // disconnect the authenticated user
                Agent authenticatedUser = _main.Startup.Bl.BlSecurity.GetAuthenticatedUser();
                authenticatedUser.IsOnline = false;
                await _main.Startup.Bl.BlAgent.UpdateAgentAsync(new List<Agent> { _main.Startup.Bl.BlSecurity.GetAuthenticatedUser() });

                // ending the discussions
                DiscussionViewModel.SelectedAgentModel = (AgentModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.AGENT);
                await DiscussionViewModel.broadcastMessageAsync(DiscussionViewModel.ByeMessage);

                foreach (var ClientElement in DiscussionViewModel.ServerClientsDictionary)
                {
                    ClientElement.Value.Item2.Close();
                }
            }
            catch (System.IO.IOException) { }
            catch (System.Net.Sockets.SocketException) { }
            catch (Exception ex)
            {
                Log.error("<[" + _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().UserName + "]Localhost =" + _main.Startup.Bl.BlSecurity.GetAuthenticatedUser().IPAddress + "> " + ex.Message, QOBDCommon.Enum.EErrorFrom.CHATROOM);
            }
        }

        public void cleanUp()
        {
            if (UdpClient != null)
                UdpClient.Close();
            
            DiscussionViewModel.Dispose();
            MessageViewModel.Dispose();
            _main.Startup.Dal.Dispose();

            if (_main.Startup.ProxyClient.State == System.ServiceModel.CommunicationState.Opened)
                _main.Startup.ProxyClient.Close();
        }

        public async Task DisposeAsync()
        {
            unSubscribeEvents();
            await chatLogOutAsync(null);            
            cleanUp();
        }

        //----------------------------[ Event Handler ]------------------

        private async void onChatRoomChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("ChatRoom") && _isServerConnectionError)
            {
                _isServerConnectionError = false;
                await Singleton.getDialogueBox().showAsync("Error occurred while trying to connect to server!", isChatDialogBox: true);
            }
        }

        /// <summary>
        /// called from the DiscussionViewModel.getMessage()
        /// on status updated reload users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onUpdateUsersStatusChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("updateStatus"))
            {
                if (Application.Current.Dispatcher.CheckAccess())
                    updateUsersOnlineStatus();
                else
                    Application.Current.Dispatcher.Invoke(()=> {
                        updateUsersOnlineStatus();
                    });
            }
        }

        private void onAgentDataDownloadingStatusChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsDataDownloading") && !((DALAgent)sender).IsDataDownloading)
            {
                // if not unit testing
                if (Application.Current != null)
                {
                    // load chat
                    start();
                }
            }
        }


        //----------------------------[ Action Commands ]------------------


        private void appNavig(string obj)
        {
            switch (obj)
            {
                case "chat":
                    CurrentViewModel = DiscussionViewModel;
                    break;
                case "back":
                    Context.Request();
                    break;
                case "home":
                    CurrentViewModel = MessageViewModel;
                    break;
                default:
                    goto case "home";
            }
        }

        private bool canAppNavig(string arg)
        {
            return true;
        }

        private async Task chatLogOutAsync(object obj)
        {
            await signOutFromServerAsync(DiscussionViewModel.DiscussionList);
            DiscussionViewModel.DiscussionList = new List<DiscussionModel>();
            CurrentViewModel = null;
        }

        private async void displayChatAgentAccount(object obj)
        {
            await Singleton.getDialogueBox().showAsync(new ChatAccountViewModel(), isChatDialogBox: true);
        }

        private bool canDisplayChatAgentAccount(object arg)
        {
            return true;
        }

        private async void validChatAccount(object obj)
        {
            var savedAgentList = await _main.Startup.Bl.BlAgent.UpdateAgentAsync(new List<Agent> { AuthenticatedAgent.Agent });
            if (savedAgentList.Count > 0)
                await Singleton.getDialogueBox().showAsync("Account successfully updated!", isChatDialogBox: true);
        }

        private bool canValidChatAccount(object arg)
        {
            return true;
        }




    }
}
