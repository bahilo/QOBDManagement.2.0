using QOBDModels.Abstracts;
using QOBDModels.Enums;
using QOBDModels.Models;

namespace QOBDModels.Classes
{
    public class ModelConcreteCreator : ModelCreator
    {
        public override object createModel(EModel modelName)
        {
            switch (modelName)
            {
                case EModel.AGENT:
                    return new AgentModel();
                case EModel.ACTION:
                    return new ActionModel();
                case EModel.ADDRESS:
                    return new AddressModel();
                case EModel.CLIENT:
                    return new ClientModel();
                case EModel.CART_ITEM:
                    return new Cart_itemModel();
                case EModel.CURRENCY:
                    return new CurrencyModel();
                case EModel.DELIVERY:
                    return new DeliveryModel();
                case EModel.INFO:
                    return new InfosModel();
                case EModel.ITEM:
                    return new ItemModel();
                case EModel.INVOICE:
                    return new BillModel();
                case EModel.ITEM_DELIVERY:
                    return new Item_deliveryModel();
                case EModel.NOTIFICATION:
                    return new NotificationModel();
                case EModel.ORDERSEARCH:
                    return new OrderSearchModel();
                case EModel.ORDER:
                    return new OrderModel();
                case EModel.ORDER_ITEM:
                    return new Order_itemModel();
                case EModel.PRIVILEGE:
                    return new PrivilegeModel();
                case EModel.PROVIDER_ITEM:
                    return new Provider_itemModel();
                case EModel.ROLE:
                    return new RoleModel();
                case EModel.TAX:
                    return new TaxModel();
                case EModel.TAX_ORDER:
                    return new Tax_orderModel();
                case EModel.STATISTIC:
                    return new StatisticModel();   
                case EModel.PROVIDER:
                    return new ProviderModel();           
        }
            return null;
        }
    }
}
