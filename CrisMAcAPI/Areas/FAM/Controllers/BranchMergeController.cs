using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.FAM.Models.Repository;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Areas.FAM.Models.Repository.BranchMergeRepository;

namespace CrisMAcAPI.Areas.FAM.Controllers
{
    [Authorize]
    [LogFilter]
    public class BranchMergeController : ApiController
    {
        IBranchMergeRepository repository;

        // GET: FAM/BranchMerge
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public BranchMergeController(IBranchMergeRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/FetchBranchMerge/{param}")]
        [HttpGet]
        //Fetch Branch details
        public string FetchBranchMerge(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchBranchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/BranchMergeclose/{param}")]
        [HttpGet]
        public string BranchcloseData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchBranchClose(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/insertUpdateBranchMerge/")]
        [HttpPost]
        //Insert Update details
        public HttpResponseMessage BranchInsertUpdateData()
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
                result = repository.InsertUpdateBranchMerge(_mainData);
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