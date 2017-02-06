using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.CompanyListRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class CompanyListController : ApiController
    {
        ICompanyListRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public CompanyListController(ICompanyListRepository repository)
        {
            this.repository = repository;
        }

        //[Route("CrisMAc/APP_GetCompanyList/{param}")]
        //[HttpGet]
        //public string APP_GetCompanyList(string param)
        //{
        //    param = objutility.DecryptString(param);
        //    var LstData = repository.GetCompanyList(param);
        //    var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
        //    return objutility.EnryptString(json);
        //}
    }
}