using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CrisMAcAPI.Areas.LOS.Models.Repository.AdminRepository;
using System.Net.Http;
using System.Web.Http;
using CrisMAc.Models.Utility;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CrisMAcAPI.Areas.LOS.Controllers
{
    public class AdminController : ApiController
    {
        IAdminRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/GetQECApplicationData/{Parameters}")]
        [HttpGet]
        public string GetQECApplicationData(string Parameters)
        {
            Parameters = objutility.DecryptString(Parameters);
            var LstData = repository.GetQECApplicationData(Parameters);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

    }
}
