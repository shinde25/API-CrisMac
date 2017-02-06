using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.CMA.Models.Repository.DataSync;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CMA.Controllers
{
    public class DataSyncController : ApiController
    {
        IDataSyncRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

        public DataSyncController(IDataSyncRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/APP_GetCustomerDetailsSync/{param}")]
        [HttpGet]
        public string APP_GetCustomerDetailsSync(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetCustomerDetailsSyncRepo(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetDetailsSync/{param}")]
        [HttpGet]
        public string APP_GetDetailsSync(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetDetailsSyncRepo(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetActionDetailsSync/{param}")]
        [HttpGet]
        public string APP_GetActionDetailsSync(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetActionDetailsSyncRepo(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_UploadDataToServer/")]
        [HttpPost]
        public string APP_UploadDataToServer()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;

            var ResultData = repository.UploadDataToServer(_data);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);
        }
    }
}