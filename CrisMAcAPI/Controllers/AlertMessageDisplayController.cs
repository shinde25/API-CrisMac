using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.AlertMessageDisplayRepository;
using CrisMAc.Models.Utility;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class AlertMessageDisplayController : ApiController
    {
        IAlertMessageDisplayRepository repository;
        UtilityWeb objutility = new UtilityWeb();

        public AlertMessageDisplayController(IAlertMessageDisplayRepository repository )
        {
            this.repository = repository;
        }
        [Route("CrisMAc/AlertMessageList/{param}")]
        [HttpGet]
        public string GetAlertMessageList(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAlertMessageList(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

    }
}
