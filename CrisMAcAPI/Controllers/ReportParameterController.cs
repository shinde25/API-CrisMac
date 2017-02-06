﻿using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.ReportParameterRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class ReportParameterController : ApiController
    {
        IReportParameterRepository repository;
        UtilityWeb objutility = new UtilityWeb();

        public ReportParameterController(IReportParameterRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/SelectReportParams/{param}")]
        [HttpGet]
        public string SelectReportParams(string param)
        {
            try
            {
                param = objutility.DecryptString(param);
                var objAuxDetail = repository.FetchData(param);

                //var json = JsonConvert.SerializeObject(objAuxDetail, Formatting.None, new JsonSerializerSettings()
                //{
                //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                //});

                  var json = new JavaScriptSerializer().Serialize(objAuxDetail);
                return objutility.EnryptString(json);
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }


        [Route("CrisMAc/SelectMetaParameterised/")]
        [HttpPost]
        public string SelectMetaParameterised()
        {
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
              //  var _mainData = objutility.DecryptString(_data);

                var  param = objutility.DecryptString(_data);
                var objAuxDetail = repository.GetAuxdata(param);
                var json = new JavaScriptSerializer().Serialize(objAuxDetail);
                return objutility.EnryptString(json);
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }

        [Route("CrisMAc/GetBranchMaster/{param}")]
        [HttpGet]
        public string GetBranchMaster(string param)
        {
            try
            {
                param = objutility.DecryptString(param);
                var objAuxDetail = repository.GetBranchMaster(param);

               

                var json = new JavaScriptSerializer().Serialize(objAuxDetail);
                return objutility.EnryptString(json);
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }

        [Route("CrisMAc/GetDynamicMaster/")]
        [HttpPost]
        public string GetDynamicMaster()
        {
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;

                //JObject json1 = JObject.Parse(_data);
               // var param = objutility.DecryptString(_data);
                var objAuxDetail = repository.GetDynamicMasterData(_data);



                var json = new JavaScriptSerializer().Serialize(objAuxDetail);
                return objutility.EnryptString(json);
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }
    }
}
