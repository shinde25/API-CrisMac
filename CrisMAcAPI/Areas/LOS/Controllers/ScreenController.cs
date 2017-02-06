using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.LOS.Models.Repository.ScreenRepository;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Http;

namespace CrisMAcAPI.Areas.LOS.Controllers
{
   
    public class ScreenController : ApiController
    {

        IScreenRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

        public ScreenController(IScreenRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/GetScreenPreviousNextData/{Parameters}")]
        [HttpGet]
        public string GetScreenPreviousNextData(string Parameters)
        {
            Parameters = objutility.DecryptString(Parameters);
            var LstData = repository.GetScreenPreviousNextData(Parameters);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

    }
}