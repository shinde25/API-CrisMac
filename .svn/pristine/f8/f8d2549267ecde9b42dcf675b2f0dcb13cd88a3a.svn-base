using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrisMAcAPI.Areas.Axis_MOC
{
    public class IncorporationRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Axis_MOC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                 "Axis_MOC_default",
                 "Axis_MOC/{controller}/{action}/{id}",
                 new { action = "Index", id = UrlParameter.Optional }
             );
        }
    }
}