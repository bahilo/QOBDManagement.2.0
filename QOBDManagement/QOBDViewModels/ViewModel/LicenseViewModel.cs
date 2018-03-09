using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.ViewModel
{
    public class LicenseViewModel : Classes.ViewModel
    {
        private string _registrationStatus;
        private string _licenseKey;
        private string _applicationVersion;
        private string _licenseFileFullPath;
        private string _errorMessage;
        private License _license;
        private IMainWindowViewModel _main;

        public ButtonCommand<object> UpdateLicenseCommand { get; set; }

        public LicenseViewModel()
        {
            _license = new License();
            _registrationStatus = "NOT REGISTERED";
            _errorMessage = "";
            _licenseKey = "";
            _applicationVersion = "";
            _licenseFileFullPath = Path.Combine(Utility.BaseDirectory, "license.txt");
            UpdateLicenseCommand = new ButtonCommand<object>(updateLicenseKey, canUpdateLicenseKey);
        }

        public LicenseViewModel(IMainWindowViewModel main) : this()
        {
            _main = main;
            ApplicationVersion = _main.TxtInfoVersion;
        }

        public License License
        {
            get { return _license; }
            set { setProperty(ref _license, value); }
        }

        public string TxtErrorMessage
        {
            get { return _errorMessage; }
            set { setProperty(ref _errorMessage, value); }
        }

        public string LicenseKey
        {
            get { return _licenseKey; }
            set { setProperty(ref _licenseKey, value); }
        }

        public string RegistrationStatus
        {
            get { return _registrationStatus; }
            set { setProperty(ref _registrationStatus, value); }
        }

        public string ApplicationVersion
        {
            get { return _applicationVersion; }
            set { setProperty(ref _applicationVersion, value); }
        }

        public string LicenseFileFullPath
        {
            get { return _licenseFileFullPath; }
            set { setProperty(ref _licenseFileFullPath, value); }
        }


        public bool saveLicenseFile()
        {
            try
            {
                File.WriteAllText(LicenseFileFullPath, LicenseKey);
            }
            catch (Exception ex)
            {
                Log.error(ex.Message, QOBDCommon.Enum.EErrorFrom.LICENSE);
                return false;
            }
            return true;
        }

        public string readLicenseFile()
        {
            try
            {
                LicenseKey = File.ReadAllText(LicenseFileFullPath);
            }
            catch (Exception ex)
            {
                LicenseKey = "";
                Log.error(ex.Message, QOBDCommon.Enum.EErrorFrom.LICENSE);
            }
            return LicenseKey;
        }

        public async Task<bool> checkLicenseKey()
        {
            if (readLicenseFile().Length == 0)
                return false;

            TxtErrorMessage = "License key not valid, please purchase a valid key.";

            try
            {
                var licensesFound = await _main.Startup.Bl.BlSecurity.checkLicenseByKeyAsync(LicenseKey);
                
                if (licensesFound.Count() > 0 && (licensesFound[0].EndDate <= Utility.DateTimeMinValueInSQL2005 || licensesFound[0].EndDate > DateTime.Now))
                {                    
                    TxtErrorMessage = "";
                    RegistrationStatus = "REGISTERED";
                    License = licensesFound[0];
                    _main.CompanyName = License.CompanyName;
                    return true;
                }
                else if (licensesFound.Count() > 0 && licensesFound[0].EndDate > Utility.DateTimeMinValueInSQL2005
                         && licensesFound[0].EndDate < DateTime.Now)
                {
                    TxtErrorMessage = "Your license key has expired, please purchase a valid key.";
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.warning(ex.Message, QOBDCommon.Enum.EErrorFrom.LICENSE);
                return false;
            }
        }


        private async void updateLicenseKey(object obj)
        {
            if (saveLicenseFile())
            {
                await Singleton.getDialogueBox().showAsync("Your license key has been saved successfully!");
                //await _main.SecurityLoginViewModel.showLoginView();
                //Singleton.DialogBox.IsDialogOpen = false;
            }
        }

        private bool canUpdateLicenseKey(object arg)
        {
            return true;
        }

    }
}
