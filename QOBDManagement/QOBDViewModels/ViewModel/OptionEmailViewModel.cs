using QOBDCommon.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QOBDViewModels.Interfaces;
using QOBDCommon.Enum;
using System.Configuration;
using System.IO;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDCommon.Classes;

namespace QOBDViewModels.ViewModel
{
    public class OptionEmailViewModel : Classes.ViewModel
    {
        Dictionary<string, InfoFileWriter> _emails;
        private string _title;
        private IReferentialViewModel _referential;
        
        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> DeleteCommand { get; set; }
        public ButtonCommand<string> UpdateCommand { get; set; }


        public OptionEmailViewModel()
        {
            
        }

        public OptionEmailViewModel(IReferentialViewModel viewModel): this()
        {
            _referential = viewModel;
            instances();
            instancesCommand();
        }


        //----------------------------[ Initialization ]------------------

        private void instances()
        {
            _title = ConfigurationManager.AppSettings["title_setting_email"];
            _emails = new Dictionary<string, InfoFileWriter>();
            _emails["quote"] = new InfoFileWriter("quote", EOption.mails);
            _emails["reminder_1"] = new InfoFileWriter("reminder_1", EOption.mails);
            _emails["reminder_2"] = new InfoFileWriter("reminder_2", EOption.mails);
            _emails["bill"] = new InfoFileWriter("bill", EOption.mails);
            _emails["order_confirmation"] = new InfoFileWriter("order_confirmation", EOption.mails);
        }

        private void instancesCommand()
        {
            UpdateCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<string>(updateEmailFiles, canUpdateEmailFiles);
            DeleteCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<string>(eraseContent, canEraseContent);
        }

        //----------------------------[ Properties ]------------------

        public BusinessLogic Bl
        {
            get { return _referential.MainWindowViewModel.Startup.Bl; }
        }

        public string Title
        {
            get { return _title; }
            set { setProperty(ref _title, value); }
        }

        public InfoFileWriter OrderConfirmationEmailFile
        {
            get { return _emails["order_confirmation"]; }
            set { _emails["order_confirmation"] = value; onPropertyChange(); }
        }

        public InfoFileWriter BillEmailFile
        {
            get { return _emails["bill"]; }
            set { _emails["bill"] = value; onPropertyChange(); }
        }

        public InfoFileWriter ReminderTwoEmailFile
        {
            get { return _emails["reminder_2"]; }
            set { _emails["reminder_2"] = value; onPropertyChange(); }
        }

        public InfoFileWriter ReminderOneEmailFile
        {
            get { return _emails["reminder_1"]; }
            set { _emails["reminder_1"] = value; onPropertyChange(); }
        }

        public InfoFileWriter QuoteEmailFile
        {
            get { return _emails["quote"]; }
            set { _emails["quote"] = value; onPropertyChange(); }
        }

        //----------------------------[ Actions ]------------------

        public override async void load()
        {
            await Task.Factory.StartNew(()=> {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["load_message"]);

                string login = (_referential.MainWindowViewModel.Startup.Bl.BlReferential.searchInfo(new QOBDCommon.Entities.Info { Name = "ftp_login" }, ESearchOption.OR).FirstOrDefault() ?? new Info()).Value;
                string password = (_referential.MainWindowViewModel.Startup.Bl.BlReferential.searchInfo(new QOBDCommon.Entities.Info { Name = "ftp_password" }, ESearchOption.OR).FirstOrDefault() ?? new Info()).Value;

                foreach (var email in _emails)
                {
                    email.Value.TxtLogin = login;
                    email.Value.TxtPassword = password;
                    if (string.IsNullOrEmpty(email.Value.TxtFileFullPath) || !File.Exists(email.Value.TxtFileFullPath))
                        email.Value.read();
                }

                Singleton.getDialogueBox().IsDialogOpen = false;
            });
        }

        public override void Dispose()
        {
            foreach (var email in _emails)
            {
                if(File.Exists(email.Value.TxtFileFullPath))
                    File.Delete(email.Value.TxtFileFullPath);
            }
        }

        //----------------------------[ Action Commands ]------------------

        private void eraseContent(string obj)
        {
            switch (obj)
            {
                case "bill":
                    _emails["bill"].TxtContent = "";
                    break;
                case "reminder-2":
                    _emails["reminder_2"].TxtContent = "";
                    break;
                case "reminder-1":
                    _emails["reminder_1"].TxtContent = "";
                    break;
                case "order-confirmation":
                    _emails["order_confirmation"].TxtContent = "";
                    break;
                case "quote":
                    _emails["quote"].TxtContent = "";
                    break;
            }
        }

        private bool canEraseContent(string arg)
        {
            bool isWrite = _referential.MainWindowViewModel.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Write);
            bool isUpdate = _referential.MainWindowViewModel.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Update);
            if (isUpdate && isWrite)
                return true;
            return false;
        }

        private async void updateEmailFiles(string obj)
        { 
            switch (obj)
            {
                case "bill":
                    if (_emails["bill"].save())
                        await Singleton.getDialogueBox().showAsync("Email Bill saved Successfully!");
                    break;
                case "reminder-2":
                    if (_emails["reminder_2"].save())
                        await Singleton.getDialogueBox().showAsync("Email first Bill reminder saved Successfully!");
                    break;
                case "reminder-1":
                    if (_emails["reminder_1"].save())
                        await Singleton.getDialogueBox().showAsync("Email second Bill reminder saved Successfully!");
                    break;
                case "order-confirmation":
                    if (_emails["order_confirmation"].save())
                        await Singleton.getDialogueBox().showAsync("Email validation Order confirmation saved Successfully!");
                    break;
                case "quote":
                    if (_emails["quote"].save())
                        await Singleton.getDialogueBox().showAsync("Email Quote saved Successfully!");
                    break;
            }
        }

        private bool canUpdateEmailFiles(string arg)
        {
            bool isWrite = _referential.MainWindowViewModel.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Write);
            bool isUpdate = _referential.MainWindowViewModel.securityCheck(QOBDCommon.Enum.EAction.Option, QOBDCommon.Enum.ESecurity._Update);
            if (isUpdate && isWrite)
                return true;
            return false;
        }
    }
}
