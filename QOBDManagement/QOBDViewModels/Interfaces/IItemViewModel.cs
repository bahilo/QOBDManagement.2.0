using QOBDCommon.Entities;
using QOBDModels.Models;
using System.Collections.Generic;

namespace QOBDViewModels.Interfaces
{
    public interface IItemViewModel
    {
        void loadItems();
        List<Item_deliveryModel> item_deliveryListToModelList(List<Item_delivery> item_deliveryList);
        void Dispose();
    }
}
