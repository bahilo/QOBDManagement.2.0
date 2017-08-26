using System;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;

namespace QOBDViewModels.ViewModel
{
    public class ReferentialViewModel : Classes.ViewModel, IReferentialViewModel
    {
        private Func<object, object> _page;
        
        //----------------------------[ Models ]------------------

        private ReferentialSideBarViewModel _referentialSideBarViewModel;
        private OptionSecurityViewModel _optionSecurityViewModel;
        private OptionGeneralViewModel _optionGeneralViewModel;
        private OptionDataAndDisplayViewModel _optionDataAndDisplayViewModel;
        private OptionEmailViewModel _optionEmailViewModel;
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
            _referentialSideBarViewModel = (ReferentialSideBarViewModel)_main.ViewModelCreator.createSettingViewModel( Enums.EViewModel.REFERENTIALMENU, this);
            _optionSecurityViewModel = (OptionSecurityViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALSECURITY, this);
            _optionGeneralViewModel = (OptionGeneralViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALGENERAL, this);
            _optionDataAndDisplayViewModel = (OptionDataAndDisplayViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALDATAANDDISPLAY, this);
            _optionEmailViewModel = (OptionEmailViewModel)_main.ViewModelCreator.createSettingViewModel(Enums.EViewModel.REFERENTIALEMAIL, this);
        }

        //----------------------------[ Properties ]------------------
                

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public OptionGeneralViewModel OptionGeneralViewModel
        {
            get { return _optionGeneralViewModel; }
            set { setProperty(ref _optionGeneralViewModel, value); }
        }

        public OptionDataAndDisplayViewModel OptionDataAndDisplayViewModel
        {
            get { return _optionDataAndDisplayViewModel; }
            set { setProperty(ref _optionDataAndDisplayViewModel, value); }
        }

        public OptionSecurityViewModel OptionSecurityViewModel
        {
            get { return _optionSecurityViewModel; }
            set { setProperty(ref _optionSecurityViewModel, value); }
        }

        public ReferentialSideBarViewModel ReferentialSideBarViewModel
        {
            get { return _referentialSideBarViewModel; }
            set { setProperty(ref _referentialSideBarViewModel, value); }
        }

        public OptionEmailViewModel OptionEmailViewModel
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
