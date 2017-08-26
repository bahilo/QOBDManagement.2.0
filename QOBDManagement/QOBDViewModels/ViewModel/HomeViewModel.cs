using System;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;
using QOBDModels.Classes;
using QOBDModels.Command;

namespace QOBDViewModels.ViewModel
{
    public class HomeViewModel : Classes.ViewModel
    {
        private IMainWindowViewModel _main;
        private Func<object, object> _page;
        public ButtonCommand<string> CommandNavig { get; set; }

        public HomeViewModel()
        {
        }

        public HomeViewModel(IMainWindowViewModel mainWindowViewModel) : this()
        {
            _main = mainWindowViewModel;
            _page = _main.navigation;
            CommandNavig = _main.CommandCreator.createSingleInputCommand<string>(appNavig, canAppNavig);
        }

        //----------------------------[ Properties ]------------------

        public string TxtMaterialDesignColourName
        {
            get { return Utility.getRandomMaterialDesignColour(); }
        }

        public string TxtColourName
        {
            get { return Utility.getRandomColour(); }
        }

        //----------------------------[ Actions ]------------------


        //----------------------------[ Action Commands ]------------------

        private void appNavig(string obj)
        {
            _main.appNavig(obj);
        }

        private bool canAppNavig(string arg)
        {
            return _main.canAppNavig(arg);
        }

    }
}
