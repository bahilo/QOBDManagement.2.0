using QOBDModels.Models;

namespace QOBDModels.Interfaces
{
    public interface ICart
    {
        void AddItem(Cart_itemModel cart_itemModel);
        void RemoveItem(Cart_itemModel cart_itemModel);

    }
}
