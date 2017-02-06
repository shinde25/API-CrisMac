﻿using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.DiaryActionEventClosureRepository;
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
    public class DiaryActionEventClosureController : ApiController
    {
        IDiaryActionEventClosureRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public DiaryActionEventClosureController(IDiaryActionEventClosureRepository repository)
        {
            this.repository = repository;
        }

        //------------- Aux
        [Route("CrisMAc/DiaryActionEventClosureAuxData/{param}")]
        [HttpGet]
        public string DiaryActionEventClosureAuxData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        //------------- Meta
        [Route("CrisMAc/GetMetaDiaryActionEventClosure/{param}")]
        [HttpGet]
        public string GetMetaDiaryActionEventClosure(string param) 
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetMetaData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        //------------- select
        [Route("CrisMAc/FetchDiaryActionEventClosure/{param}")]
        [HttpGet]
        public string FetchDiaryActionEventClosure(string param) 
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        //------------- insert
        [Route("CrisMAc/InsertDiaryActionEventClosure/")]
        [HttpPost]
        public HttpResponseMessage InsertDiaryActionEventClosure()
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
        [Route("CrisMAc/FetchEmailSMSData/{param}")]
        [HttpGet]
        public string FetchEmailSMSData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetEmailSMSData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }
    }
}


    
    