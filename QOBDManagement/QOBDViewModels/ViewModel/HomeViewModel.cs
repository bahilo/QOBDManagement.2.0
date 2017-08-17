using System;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;
using QOBDModels.Classes;

namespace QOBDViewModels.ViewModel
{
    public class HomeViewModel : BindBase//, IHomeViewModel
    {
        private IMainWindowViewModel _main;
        private Func<object, object> _page;

        
        public HomeViewModel()
        {
        }

        public HomeViewModel(IMainWindowViewModel mainWindowViewModel) : this()
        {
            _main = mainWindowViewModel;
            _page = _main.navigation;
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

        public void loadData()
        {
            
        }        


    }
}
