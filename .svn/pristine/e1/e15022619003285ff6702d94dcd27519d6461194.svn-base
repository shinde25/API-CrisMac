using System.Web.Mvc;

namespace CrisMAcAPI.Areas.UPGRADATION
{
    public class UPGRADATIONAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UPGRADATION";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UPGRADATION_default",
                "UPGRADATION/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}