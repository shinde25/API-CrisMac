﻿using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.Alert.Models.Repository;
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
    public class AlertController : ApiController
    {
        IAlertRepository repository;

        public AlertController(IAlertRepository repository)
        {
            this.repository = repository;
        }

        UtilityWeb objutility = new UtilityWeb();
        [Route("CrisMAc/ProspectAuxSelect/{param}")]
        [HttpGet]
        public string GetAuxData(string param)
        {
            param = objutility.DecryptString(param);
            var objFetchData = repository.GetAuxdata(param);
            var json = new JavaScriptSerializer().Serialize(objFetchData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/ProspectFetchSelect/{param}")]
        [HttpGet]
        public string FetchData(string param)
        {
            param = objutility.DecryptString(param);
            var objFetchData = repository.FetchData(param);
            var json = new JavaScriptSerializer().Serialize(objFetchData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/ParameterisedData")]
        [HttpGet]
        public string MasterData()
        {
            var objFetchData = repository.GetMetaData();
            var json = new JavaScriptSerializer().Serialize(objFetchData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/ProspectManagementInsertUpdate")]
        [HttpPost]
        public HttpResponseMessage InsertUpdate()
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

    }
}
