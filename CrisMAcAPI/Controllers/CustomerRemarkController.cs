﻿using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.CustomerRemarkRepository;
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
    public class CustomerRemarkController : ApiController
    {
        ICustomerRemarkRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public CustomerRemarkController(ICustomerRemarkRepository repository)
        {
            this.repository = repository;
        }
        [Route("CrisMAc/CustomerRemarkAuxData/{param}")]
        [HttpGet]
        public string CustomerRemarkAuxData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/GetMetaCustomerRemark/{param}")]
        [HttpGet]
        public string GetMetaCustomerRemark(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetMetaData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/FetchCustomerRemark/{param}")]
        [HttpGet]
        public string FetchCustomerRemark(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/FetchCustomerRemark_AccIds/{param}")]
        [HttpGet]
        public string FetchCustomerRemark_AccIds(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData_AccIds(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/InsertCustomerRemark/")]
        [HttpPost]
        public HttpResponseMessage InsertCustomerRemark()
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
        [Route("CrisMAc/CustomerRemarkListSelect/{param}")]
        [HttpGet]
        public string CustomerRemarkListSelect(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetCustomerRemarkListSelect(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }
    }
}
