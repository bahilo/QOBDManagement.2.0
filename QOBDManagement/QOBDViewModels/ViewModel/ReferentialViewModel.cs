using System;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;

namespace QOBDViewModels.ViewModel
{
    public class ReferentialViewModel : Classes.ViewModel, IReferentialViewModel
    {
        private Func<object, object> _page;
        
        //----------------------------[ Models ]------------------

        private ISideBarViewModel _referentialSideBarViewModel;
        private IOptionSecurityViewModel _optionSecurityViewModel;
        private IOptionGeneralViewModel _optionGeneralViewModel;
        private IOptionDataAndDisplayViewModel _optionDataAndDisplayViewModel;
        private IOptionEmailViewModel _optionEmailViewModel;
        private IMainWindowViewModel _main;
        
        public ReferentialViewModel(IMainWindowViewModel mainWindowViewModel)
        {
            this._main = mainWindowViewModel;
            _page = _main.navigation;
            instancesModel(mainWindowViewModel);
        }

        //----------------------------[ Initialization ]------------------

        private void instancesModel(IMainWindowViewModel main)
        {
            _referentialSideBarViewModel = (ISideBarViewModel)_main.ViewModelCreator.createSettingViewModel( Enums.EViewModel.REFERENTIALMENU, this);
            _optionSecurityViewModel = (IOptionSecurityViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALSECURITY, this);
            _optionGeneralViewModel = (IOptionGeneralViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALGENERAL, this);
            _optionDataAndDisplayViewModel = (IOptionDataAndDisplayViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALDATAANDDISPLAY, this);
            _optionEmailViewModel = (IOptionEmailViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALEMAIL, this);
        }

        //----------------------------[ Properties ]------------------
                

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public IOptionGeneralViewModel OptionGeneralViewModel
        {
            get { return _optionGeneralViewModel; }
            set { setProperty(ref _optionGeneralViewModel, value); }
        }

        public IOptionDataAndDisplayViewModel OptionDataAndDisplayViewModel
        {
            get { return _optionDataAndDisplayViewModel; }
            set { setProperty(ref _optionDataAndDisplayViewModel, value); }
        }

        public IOptionSecurityViewModel OptionSecurityViewModel
        {
            get { return _optionSecurityViewModel; }
            set { setProperty(ref _optionSecurityViewModel, value); }
        }

        public ISideBarViewModel ReferentialSideBarViewModel
        {
            get { return _referentialSideBarViewModel; }
            set { setProperty(ref _referentialSideBarViewModel, value); }
        }

        public IOptionEmailViewModel OptionEmailViewModel
        {
            get { return _optionEmailViewModel; }
            set { setProperty(ref _optionEmailViewModel, value); }
        }

        public IMainWindowViewModel MainWindowViewModel
        {
            get { return _main; }
            set { setProperty(ref _main, value); }
        }

        //----------------------------[ Actions ]------------------

        public override void Dispose()
        {
            OptionDataAndDisplayViewModel.Dispose();
            OptionEmailViewModel.Dispose();
            OptionGeneralViewModel.Dispose();
            OptionSecurityViewModel.Dispose();
        }
        
        //----------------------------[ Action Commands ]------------------
        
        public void executeNavig(string obj)
        {
            switch (obj)
            {
                case "option":
                    _page(new OptionGeneralViewModel());
                    break;                
            }
        }
        
    }
}
