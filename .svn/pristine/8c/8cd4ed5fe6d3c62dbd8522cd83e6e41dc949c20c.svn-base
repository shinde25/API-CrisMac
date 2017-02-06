using System.Web.Mvc;

namespace CrisMAcAPI.Areas.EWS
{
    public class EWSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EWS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EWS_default",
                "EWS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}