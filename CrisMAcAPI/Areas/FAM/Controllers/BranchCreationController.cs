﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.FAM.Models.Repository;
using CrisMAcAPI.Areas.FAM.Models.Repository.BranchCreationRepository;
using CrisMAcAPI.Filter;

namespace CrisMAcAPI.Areas.FAM.Controllers
{
    [Authorize]
    [LogFilter]
    public class BranchCreationController : ApiController
    {
        IBranchCreationRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();


        public BranchCreationController(IBranchCreationRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/BranchAuxData/{param}")]
        [HttpGet]
        //Aux Data
        public string AuxBranch(string param)
        {


            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }



        [Route("CrisMAc/FetchBranchDetails/{param}")]
        [HttpGet]
        //Fetch Branch details
        public string FetchBranchDetails(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchBranchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/BranchInsertUpdateData/")]
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
                result = repository.InsertUpdateBranchData(_mainData);
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
        [Route("CrisMAc/SolIDData/{param}")]
        [HttpGet]
        //Aux Data
        public string SolIDData(string param)
        {


            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetSolIddata(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

    }
}
