using System.Web.Mvc;

namespace CrisMAcAPI.Areas.D2k_Inventory
{
    public class D2k_InventoryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "D2k_Inventory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "D2k_Inventory_default",
                "D2k_Inventory/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}