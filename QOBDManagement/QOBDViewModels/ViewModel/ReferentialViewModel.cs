using System;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;

namespace QOBDViewModels.ViewModel
{
    public class ReferentialViewModel : Classes.ViewModel
    {
        private Func<object, object> _page;
        
        //----------------------------[ Models ]------------------

        private ReferentialSideBarViewModel _referentialSideBarViewModel;
        private OptionSecurityViewModel _optionSecurityViewModel;
        private OptionGeneralViewModel _optionGeneralViewModel;
        private OptionDataAndDisplayViewModel _optionDataAndDisplayViewModel;
        private OptionEmailViewModel _optionEmailViewModel;
        private IMainWindowViewModel _main;

        // An unhandled exception of type 'System.StackOverflowException' occurred in QOBDModels.dll

        public ReferentialViewModel(IMainWindowViewModel mainWindowViewModel)
        {
            this._main = mainWindowViewModel;
            _page = _main.navigation;
            instancesModel(mainWindowViewModel);
        }

        //----------------------------[ Initialization ]------------------

        private void instancesModel(IMainWindowViewModel main)
        {
            _referentialSideBarViewModel = (ReferentialSideBarViewModel)_main.ViewModelCreator.createViewModel( Enums.EViewModel.REFERENTIALMENU, main);
            _optionSecurityViewModel = new OptionSecurityViewModel(main);
            _optionGeneralViewModel = new OptionGeneralViewModel(main);
            _optionDataAndDisplayViewModel = new OptionDataAndDisplayViewModel(main);
            _optionEmailViewModel = new OptionEmailViewModel(main);
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
