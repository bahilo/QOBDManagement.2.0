using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IItemViewModel
    {
        string SearchItemName { get; set; }
        BusinessLogic Bl { get; }
        string Title { get; set; }
        string ProviderTitle { get; set; }
        string TxtIconColour { get; }
        IItemDetailViewModel ItemDetailViewModel { get; set; }
        ProviderModel SelectedProviderModel { get; set; }
        ISideBarViewModel ItemSideBarViewModel { get; set; }
        ItemModel ItemModel { get; set; }
        List<ItemModel> ItemModelList { get; set; }
        List<ProviderModel> ProviderList { get; set; }
        List<ProviderModel> ItemProviderList { get; set; }
        HashSet<string> FamilyList { get; set; }
        HashSet<string> BrandList { get; set; }
        ItemModel SelectedItemModel { get; set; }
        List<CurrencyModel> CurrenciesList { get; }
        CurrencyModel CurrencyModel { get; }
        List<CurrencyModel> ItemCurrenciesList { get; }
        string BoxVisibility { get; }
        Cart Cart { get; }

        //----------------------------[ Commands ]------------------

        ButtonCommand<string> checkBoxSearchCommand { get; set; }
        ButtonCommand<ItemModel> checkBoxToCartCommand { get; set; }
        ButtonCommand<string> btnSearchCommand { get; set; }
        ButtonCommand<Cart_itemModel> DeleteFromCartCommand { get; set; }
        ButtonCommand<string> NavigCommand { get; set; }
        ButtonCommand<ItemModel> GetCurrentItemCommand { get; set; }
        ButtonCommand<object> GoToQuoteCommand { get; set; }
        ButtonCommand<object> ClearCartCommand { get; set; }
        ButtonCommand<ProviderModel> BtnProviderSearchCommand { get; set; }
        ButtonCommand<object> BtnAddProviderAddressCommand { get; set; }
        ButtonCommand<object> BtnDeleteProviderAddressCommand { get; set; }
        ButtonCommand<Address> SelectedAddressDetailCommand { get; set; }
        ButtonCommand<object> btnDeleteProviderCommand { get; set; }
        ButtonCommand<object> btnValidProviderCommand { get; set; }
        ButtonCommand<object> btnClearSelectedProviderCommand { get; set; }

        void loadItems();
        void executeNavig(string obj);
        Task<bool> checkIfStockAvailable(Cart_itemModel cart_itemModel);
        Task<bool> checkIfStockAvailable(Order_itemModel order_itemModel);
        Task updateStockAsync(List<Order_itemModel> order_itemModelList, bool isStockReset = false);
        List<Item_deliveryModel> item_deliveryListToModelList(List<Item_delivery> item_deliveryList);
        List<Provider_itemModel> loadProvider_itemInformation(List<Provider_item> provider_itemFoundList, int userSourceId);
        void Dispose();
    }
}
