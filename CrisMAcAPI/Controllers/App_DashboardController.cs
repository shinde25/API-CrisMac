using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.App_DashboardRepository;
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
    public class App_DashboardController : ApiController
    {
        IApp_DashboardRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public App_DashboardController(IApp_DashboardRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/APP_GetCompanyList/{param}")]
        [HttpGet]
        public string APP_GetCompanyList(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetCompanyList(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/APP_GetCompanyScore/{param}")]
        [HttpGet]
        public string APP_GetCompanyScore(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetCompanyScore(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/APP_GetCompanyDetail/{param}")]
        [HttpGet]
        public string APP_GetCompanyDetail(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetCompanyDetail(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetStandingList/{param}")]
        [HttpGet]
        public string APP_GetStandingList(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetStandingList(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetNewsDetails/{param}")]
        [HttpGet]
        public string APP_GetNewsDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetNewsDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetTwitterDetails/{param}")]
        [HttpGet]
        public string APP_GetTwitterDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetTwitterDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetStockDetails/{param}")]
        [HttpGet]
        public string APP_GetStockDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetStockDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }
    }
}