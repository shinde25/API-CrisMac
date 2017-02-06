using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.D2k_Inventory.Models.Repository.AppMasterRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.D2k_Inventory.Controllers
{
    public class AppInventoryController : ApiController
    {
        IAppInventoryRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public AppInventoryController(IAppInventoryRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/SelectMasterDetails/{param}")]
        [HttpGet]
        public string SelectMasterDetails(string param)
        {
            param = objutility.DecryptString(param);
            var dataSetMasterTables = repository.AppMasterInventoryDetails(param);
            var json = JsonConvert.SerializeObject(dataSetMasterTables,Formatting.Indented);
            return objutility.EnryptString(json);
        }      

        [Route("CrisMAc/SearchInventoryDetails/{param}")]
        [HttpGet]
        public string SearchInventoryDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.AppSearchInventoryDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/SelectInventoryDetails/{param}")]
        [HttpGet]
        public string SelectInventoryDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.AppSelectInventoryDetails(param);
            // var json = new JavaScriptSerializer().Serialize(LstData);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/AddInventoryDetails/{param}")]
        [HttpGet]
        public string AddInventoryDetails(string param)
        {

            param = objutility.DecryptString(param);
            var LstData = repository.InsertInventoryDetails(param);
            // var json = new JavaScriptSerializer().Serialize(LstData);
            var json = JsonConvert.SerializeObject(LstData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/UpdateInventory/{param}")]
        [HttpGet]
        public string UpdateInventory(string param)
        {

            param = objutility.DecryptString(param);
            var LstData = repository.UpdateInventoryDetails(param);

            var json = JsonConvert.SerializeObject(LstData);
            return objutility.EnryptString(json);

        }

      }
}
