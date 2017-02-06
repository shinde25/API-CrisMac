using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.RemarkAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class RemarkAggregatorController : ApiController
    {
        IRemarkAggregatorRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public RemarkAggregatorController(IRemarkAggregatorRepository repository)
        {
            this.repository = repository;
        }
        [Route("CrisMAc/GetMetaRemarkAggregator/{param}")]
        [HttpGet]
        public string GetMetaRemarkAggregator(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetMetaData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }      

        [Route("CrisMAc/FetchRemarkAggregator/{param}")]
        [HttpGet]
        public string FetchRemarkAggregator(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/InsertRemarkAggregator/")]
        [HttpPost]
        public HttpResponseMessage InsertRemarkAggregator()
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
