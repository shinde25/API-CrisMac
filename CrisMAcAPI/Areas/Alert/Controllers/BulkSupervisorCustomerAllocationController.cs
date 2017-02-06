using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.Alert.Models.Repository.BulkSupervisorCustomerAllocationRepository;
using CrisMAcAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.Alert.Controllers
{
    [Authorize]
    [LogFilter]
    public class BulkSupervisorCustomerAllocationController : ApiController
    {
        IBulkSupervisorCustomerAllocationRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public BulkSupervisorCustomerAllocationController(IBulkSupervisorCustomerAllocationRepository repository)
        {
            this.repository = repository;
        }
        [Route("CrisMAc/GetMetaBulkSupervisorCustomerAllocation/{param}")]
        [HttpGet]
        public string GetMetaBulkSupervisorCustomerAllocation(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetMetaData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/BulkSupervisorCustomerAllocationAuxData/{param}")]
        [HttpGet]
        public string BulkSupervisorCustomerAllocationAuxData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/FetchBulkSupervisorCustomerAllocation/{param}")]
        [HttpGet]
        public string FetchBulkSupervisorCustomerAllocation(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/InsertBulkSupervisorCustomerAllocation/")]
        [HttpPost]
        public HttpResponseMessage InsertBulkSupervisorCustomerAllocation()
        {
            object result = new
            {
                Result = -1,
                D2Ktimestamp = 0
            };
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.InsertUpdateData(_mainData);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));

                return response;
            }
        }
    }
}
