using System;
using QOBDViewModels.Interfaces;
using QOBDCommon.Classes;
using QOBDModels.Models;
using QOBDModels.Command;
using System.ComponentModel;

namespace QOBDViewModels.ViewModel
{
    public class ItemSideBarViewModel : Classes.ViewModel, ISideBarViewModel
    {
        
        private Func<object, object> _page;

        //----------------------------[ Models ]------------------

        private IMainWindowViewModel _main;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<string> SetupCommand { get; set; }
        public ButtonCommand<string> UtilitiesCommand { get; set; }
        

        public ItemSideBarViewModel()
        {
            
        }

        public ItemSideBarViewModel(IMainWindowViewModel main) :this()
        {
            this._main = main;
            _page = _main.navigation;
            instancesCommand();
        }

        //----------------------------[ Initialization ]------------------
        
        private void instancesCommand()
        {
            SetupCommand = _main.CommandCreator.createSingleInputCommand<string>(executeSetupAction, canExecuteSetupAction);
            UtilitiesCommand = _main.CommandCreator.createSingleInputCommand<string>(executeUtilityAction, canExecuteUtilityAction);
        }

        //----------------------------[ Actions ]----------------------

        private void updateCommand()
        {
            UtilitiesCommand.raiseCanExecuteActionChanged();
            SetupCommand.raiseCanExecuteActionChanged();
        }

        //----------------------------[ Event Handler ]------------------

        public void onCurrentPageChange_updateCommand(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrentViewModel"))
                updateCommand();
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
