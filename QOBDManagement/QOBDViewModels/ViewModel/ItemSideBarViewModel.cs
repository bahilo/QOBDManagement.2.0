using System;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;
using QOBDModels.Models;
using QOBDModels.Command;

namespace QOBDViewModels.ViewModel
{
    public class ItemSideBarViewModel : Classes.ViewModel
    {
        
        private Func<object, object> _page;

        //----------------------------[ Models ]------------------

        private ItemModel _selectedItem;
        private IMainWindowViewModel _main;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> SetupItemCommand { get; set; }
        public ButtonCommand<string> UtilitiesCommand { get; set; }



        public ItemSideBarViewModel()
        {
            
        }

        public ItemSideBarViewModel(IMainWindowViewModel main) :this()
        {
            this._main = main;
            _page = _main.navigation;
            instances();
            instancesCommand();
        }

        //----------------------------[ Initialization ]------------------

        private void instances()
        {
            _selectedItem = (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
        }

        private void instancesCommand()
        {
            SetupItemCommand = _main.CommandCreator.createSingleInputCommand<string>(executeSetupAction, canExecuteSetupAction);
            UtilitiesCommand = _main.CommandCreator.createSingleInputCommand<string>(executeUtilityAction, canExecuteUtilityAction);
        }

        //----------------------------[ Properties ]------------------

        public ItemModel SelectedItem
        {
            get { return _selectedItem; }
            set { setProperty(ref _selectedItem, value, "SelectedItem"); }
        }

        public string TxtIconColour
        {
            get { return Utility.getRandomColour(); }
        }

        //----------------------------[ Action Commands ]------------------

        private void executeUtilityAction(string obj)
        {
            switch (obj)
            {
                case "catalogue":
                    _page(_main.ItemViewModel);
                    break;
                case "provider":
                    _page((ProviderModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.PROVIDER));
                    break;
            }
        }

        private bool canExecuteUtilityAction(string arg)
        {
            if (arg.Equals("catalogue") && _page(null) as ItemViewModel != null)
                return false;

            if (arg.Equals("provider") && _page(null) as ProviderModel != null)
                return false;

            return true;
        }

        private void executeSetupAction(string obj)
        {
            switch (obj)
            {
                case "new-item":
                    // resetting the selected item
                    if(_main.ItemViewModel.SelectedItemModel != null)
                    {
                        _main.ItemViewModel.SelectedItemModel.PropertyChanged -= _main.ItemViewModel.ItemDetailViewModel.onItemNameChange_generateReference;
                        if(_main.ItemViewModel.SelectedItemModel.Image != null)
                            _main.ItemViewModel.SelectedItemModel.Image.Dispose();
                    }
                    
                    _main.ItemViewModel.SelectedItemModel = (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
                    _main.ItemViewModel.SelectedItemModel.PropertyChanged += _main.ItemViewModel.ItemDetailViewModel.onItemNameChange_generateReference;
                    _page(_main.ItemViewModel.ItemDetailViewModel);
                    break;
            }
        }

        private bool canExecuteSetupAction(string arg)
        {
            bool isUpdate = _main.securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity._Update);
            bool isWrite = _main.securityCheck(QOBDCommon.Enum.EAction.Item, QOBDCommon.Enum.ESecurity._Write);
            if ((!isUpdate || !isWrite)
                && arg.Equals("new-item"))
                return false;

            if (arg.Equals("catalogue") && _page(null) as ItemViewModel != null)
                return false;

            return true;
        }  

    }
}
