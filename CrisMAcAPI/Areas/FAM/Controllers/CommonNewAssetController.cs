﻿using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.FAM.Models.Repository.ReplicationRepository;
using CrisMAcAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.FAM.Controllers
{
    [Authorize]
    [LogFilter]
    public class CommonNewAssetController : ApiController
    {

        ICommonNewAssetRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public CommonNewAssetController(ICommonNewAssetRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/FetchCommonNewAsset/{param}")]
        [HttpGet]
        public string FetchCommonNewAsset(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/InsertCommonNewAsset/")]
        [HttpPost]
        public HttpResponseMessage InsertCommonNewAsset()
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

        [Route("CrisMAc/FetchCommonTxn/{param}")]
        [HttpGet]
        public string FetchCommonTxn(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchDataTxn(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/InsertCommonTxn/")]
        [HttpPost]
        public HttpResponseMessage InsertCommonTxn()
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
                result = repository.InsertUpdateDataTxn(_mainData);

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

        [Route("CrisMAc/ValidateTxnCBSSystem/")]
        [HttpPost]
        public HttpResponseMessage Validate_With_CBS_System()
        {
            string json = "";
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                List<object> result = repository.CBSTxnSystem_Validation(_mainData);
                json = _JavaScriptSerializer.Serialize(result);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("result", objutility.EnryptString(json.ToString()));

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(json.ToString()));

                return response;
            }
        }


        [Route("CrisMAc/TransactionHistorySelectData/{param}")]
        [HttpGet]
        public string TransactionHistorySelect(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchTranHistoryData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/InitializationAndFreezing/{param}")]
        [HttpGet]
        public string InitializationAndFreezingSelect(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchInitiFreez(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/InsertUpdateIntiFreezing/")]
        [HttpPost]
        public HttpResponseMessage InsertUpdateIntiFreezing()
        {
            string json = "";
            object result = new
            {
                result = -1,
                //D2Ktimestamp = 0
            };
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.InsertUpdateIntiFreezing(_mainData);
                //List<object> result = repository.InsertUpdateIntiFreezing(_mainData);
                //json = _JavaScriptSerializer.Serialize(result);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(json.ToString()));

                return response;
            }
        }


        //FetchInitiFreez
    }
}
