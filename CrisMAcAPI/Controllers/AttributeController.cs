﻿using CrisMAc.Models.Utility;
using CrisMAcAPI.Models.Repository.AttributeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net;
using CrisMAcAPI.Filter;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class AttributeController : ApiController
    {
        IAttributeRepository repository;

        UtilityWeb objutility = new UtilityWeb();
        public AttributeController(IAttributeRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/GetAttributeAux/{param}")]
        [HttpGet]
        public string GetAuxDetails(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/GetAttributeData/{param}")]
        [HttpGet]
        public string Fetchdata(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/GetAttributeMetaData/")]
        [HttpGet]
        public string GetMetaData()
        {

            var objAuxDetail = repository.GetMetaData();
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/AddAttribute/")]
        [HttpPost]
        public HttpResponseMessage InsertAttribute()
        {
            int result = -1;
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.InsertUpdateData(_mainData);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("result", result.ToString());

                return response;
            }
            catch (Exception e)
            {

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", result.ToString());

                return response;
            }
        }

        [Route("CrisMAc/GetAttributeSegmentParameterAux/{param}")]
        [HttpGet]
        public string GetAttributeSegmentParameterAux(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetSegmentParameterFetch(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

    }
}