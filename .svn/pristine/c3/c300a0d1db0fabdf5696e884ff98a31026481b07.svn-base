using System.Web.Mvc;

namespace CrisMAcAPI.Areas.IFAM_Premises
{
    public class IFAM_PremisesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IFAM_Premises";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IFAM_Premises_default",
                "IFAM_Premises/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}