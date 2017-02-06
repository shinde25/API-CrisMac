﻿using CrisMAcAPI.Filter;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using CrisMAcAPI.Areas.IFAM_Premises.Models.Repository.CommonPremiseRepository;
using CrisMAc.Models.Utility;

namespace CrisMAcAPI.Areas.IFAM_Premises.Controllers
{
    [Authorize]
    [LogFilter]
    public class CommonNewPremiseController : ApiController
    {
        ICommonPremiseRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public CommonNewPremiseController(ICommonPremiseRepository repository)
        {
            this.repository = repository;
        }
        //      Paramatrised  
        //[Route("CrisMAc/GetAssetBlockandSubBlockMain/{param}")]
        //[HttpGet]
        //public string GetAssetBlockandSubBlockMain(string param)
        //{
        //
        //    param = objutility.DecryptString(param);
        //    var objAuxDetail = repository.GetAssetBlockandSubBlockData(param);
        //    var json = _JavaScriptSerializer.Serialize(objAuxDetail);
        //    return objutility.EnryptString(json);
        //}

        [Route("CrisMAc/PremiseFetchCommonNewAsset/{param}")]
        [HttpGet]
        public string PremiseFetchCommonNewAsset(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/PremiseInsertCommonNewAsset/")]
        [HttpPost]
        public HttpResponseMessage PremiseInsertCommonNewAsset()
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

        [Route("CrisMAc/PremiseFetchCommonTxn/{param}")]
        [HttpGet]
        public string PremiseFetchCommonTxn(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchDataTxn(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/PremiseInsertCommonTxn/")]
        [HttpPost]
        public HttpResponseMessage PremiseInsertCommonTxn()
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

        [Route("CrisMAc/PremiseValidateTxnCBSSystem/")]
        [HttpPost]
        public HttpResponseMessage PremiseValidate_With_CBS_System()
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

        ////     Transaction mian Grid data FETCH   ************************    //
        //[Route("CrisMAc/PremiseMainTransactionDataFetch/{param}")]
        //[HttpGet]
        //public string PremiseMainTransactionDataFetch(string param)
        //{
        //    JObject JsonParam = new JObject();
        //    param = objutility.DecryptString(param);
        //    string[] strJson = param.Split(',', '{', '}');
        //    if (strJson[0].ToString().Contains("Txn"))
        //    {
        //        JsonParam.Add("ScreenType", strJson[0]);
        //        JsonParam.Add("_BranchCode", strJson[1]);
        //        JsonParam.Add("UserLoginID", strJson[2]);
        //        JsonParam.Add("AssetBlockAlt_Key", strJson[3]);
        //        JsonParam.Add("AssetSubBlockAlt_Key", strJson[4]);
        //        //JsonParam.Add("AssetSearchString", strJson[5]);
        //        JsonParam.Add("AssetLocation", strJson[6]);
        //        JsonParam.Add("_TimeKey", strJson[7]);
        //        JsonParam.Add("TxnType", strJson[8]);
        //        //JsonParam.Add("PurchaseDateFrom", strJson[10]);
        //        //JsonParam.Add("PurchaseDateTo", strJson[11]);
        //        //JsonParam.Add("PurchaseAmountFrom", strJson[12]);
        //        //JsonParam.Add("PurchaseAmountTo", strJson[13]);
        //
        //        var objAuxDetail = repository.FetchDataTxn(JsonParam.ToString());
        //        var json = _JavaScriptSerializer.Serialize(objAuxDetail);
        //        return objutility.EnryptString(json);
        //    }
        //    else
        //    {
        //        JsonParam.Add("ScreenType", strJson[0]);
        //        JsonParam.Add("_BranchCode", strJson[1]);
        //        JsonParam.Add("UserLoginID", strJson[2]);
        //        JsonParam.Add("AssetBlockAlt_Key", strJson[3]);
        //        JsonParam.Add("AssetSubBlockAlt_Key", strJson[4]);
        //        //JsonParam.Add("AssetSearchString", strJson[5]);
        //        //JsonParam.Add("AssetLocation", strJson[6]);
        //        
        //        JsonParam.Add("TxnType", strJson[7]);
        //        JsonParam.Add("TxnStatus", strJson[8]);
        //        JsonParam.Add("TxnDateFrom", strJson[9]);
        //        JsonParam.Add("TxnDateTo", strJson[10]);
        //        JsonParam.Add("_TimeKey", strJson[11]);
        //        var objAuxDetail = repository.PremiseDisplayGridDataFetch(JsonParam.ToString());
        //        var json = _JavaScriptSerializer.Serialize(objAuxDetail);
        //        return objutility.EnryptString(json);
        //    }
        //}

    }
}