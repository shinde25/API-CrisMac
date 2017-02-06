using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.LOS.Models.Repository.LOSDashBoardRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.LOS.Controllers
{
    public class LOSDashBoardController : ApiController
    {
        ILOSDashBoardRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

        public LOSDashBoardController(ILOSDashBoardRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/GetCriteriaEligibleData/{Parameters}")]
        [HttpGet]
        public string GetCriteriaEligibleData(string Parameters)
        {
            Parameters = objutility.DecryptString(Parameters);
            var LstData = repository.GetCriteriaEligibleData(Parameters);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }
    }
}