// FILE: D:/Just IT Training/BillManagment/Classes//IActionManager.cs

// In this section you can add your own using directives
// section -64--88-0-12--65b75d98:1535bf612db:-8000:0000000000000B88 begin
// section -64--88-0-12--65b75d98:1535bf612db:-8000:0000000000000B88 end

/// <summary>
///  An interface defining operations expected of ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDCommon.Interfaces.BL
{
    public interface IActionManager
    {

        IAgentManager BlAgent { get; set; }
        IOrderManager BlOrder { get; set; }
        IClientManager BlClient { get; set; }
        IItemManager BlItem { get; set; }
        IReferentialManager BlReferential { get; set; }
        ISecurityManager BlSecurity { get; set; }
        IStatisticManager BlStatisitc { get; set; }
        INotificationManager BlNotification { get; set; }
    } /* end interface IActionManager */
}
