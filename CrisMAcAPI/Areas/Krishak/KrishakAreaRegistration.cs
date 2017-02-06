using System.Web.Mvc;

namespace CrisMAcAPI.Areas.Krishak
{
    public class KrishakAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Krishak";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Krishak_default",
                "Krishak/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}