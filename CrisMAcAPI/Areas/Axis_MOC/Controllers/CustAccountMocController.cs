using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.Axis_MOC.Models.Repository.Incorporation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json.Linq;
using CrisMAcAPI.Filter;

namespace CrisMAcAPI.Areas.Axis_MOC.Controllers
{
    [Authorize]
    [LogFilter]
    public class CustAccountMocController : ApiController
    {
        ICustAccountMocRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

        public CustAccountMocController(ICustAccountMocRepository repository)
        {
            this.repository = repository;
        }


        #region Incorporation

        [System.Web.Http.Route("CrisMAc/IncorporationSelect/{param}")]//----------IncorporationSelect
        [System.Web.Http.HttpGet]
        public string CustAccountMOCelect(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetIncorporation(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [System.Web.Http.Route("CrisMAc/AssetClassMeta/{param}")]//----------IncorporationSelect
        [System.Web.Http.HttpGet]
        public string ParametriceMeta(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetParametriceMeta(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [System.Web.Http.Route("CrisMAc/CustAccountGridMOC/{param}")]//----------IncorporationSelect
        [System.Web.Http.HttpGet]
        public string CustAccountGrid(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetCustAccountGrid(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [System.Web.Http.Route("CrisMAc/CustAccountInsertUpdate/")]//----------IncorporationSelect
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CustAccountInsertUpdate()
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
                result = repository.GetCustAccountInsertUpdate(_mainData);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("Result", objutility.EnryptString(result.ToString()));

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));

                return response;
            }
        }

        #endregion Incorporation


        #region Customer Excel Upload

        /*[System.Web.Http.Route("CrisMAc/GetLastQtrDate/{param}")]
        [System.Web.Http.HttpGet]
        public string GetLastQtrDate(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.LastQtrDateRepo(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }*/

        [System.Web.Http.Route("CrisMAc/ValidateExcelData/")]
        [System.Web.Http.HttpPost]
        public string ValidateExcelData()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            var _mainData = objutility.DecryptString(_data);
            var objAuxDetail = repository.ValidateExcelRepo(_mainData);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [System.Web.Http.Route("CrisMAc/CustExcelUpload/")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CustExcelUpload()
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
                result = repository.CustExcelUpload(_mainData);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("Result", objutility.EnryptString(result.ToString()));
                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));
                return response;
            }

            #region commented
            //JObject JsonParam = new JObject();
            //param = objutility.DecryptString(param);
            //string[] strJson = param.Split(',', '{', '}');
            //JsonParam.Add("XmlData", strJson[0]);
            //JsonParam.Add("_MenuID", strJson[1]);
            //JsonParam.Add("_dateCreatedmodified", strJson[2]);
            //JsonParam.Add("_CreatetedModifiedBy", strJson[3]);
            //JsonParam.Add("_LastQtrDateKey", strJson[4]);
            //JsonParam.Add("_EffectiveFromTimeKey", strJson[5]);
            //JsonParam.Add("_EffectiveToTimeKey", strJson[6]);
            //JsonParam.Add("__D2Ktimestamp", strJson[7]);
            //JsonParam.Add("CreateModifyApprovedBy", strJson[8]);
            //JsonParam.Add("DateCreatedModifiedApproved", strJson[9]);
            //var objAuxDetail = repository.GetCustAccountExcelUpload(JsonParam.ToString());  // repository's FetchData() call
            //var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            //return objutility.EnryptString(json); 
            #endregion
        }

        [System.Web.Http.Route("CrisMAc/fetchExcelData/{param}")]
        [System.Web.Http.HttpGet]
        public string fetchExcelData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetExcelData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        #endregion Customer Excel Upload
                

        #region Acccount Excel Upload
        [System.Web.Http.Route("CrisMAc/ValidateAccExcelData/")]
        [System.Web.Http.HttpPost]
        public string ValidateAccExcelData()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            var _mainData = objutility.DecryptString(_data);
            var objAuxDetail = repository.ValidateAccExcelRepo(_mainData);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [System.Web.Http.Route("CrisMAc/AccountExcelUpload/")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AccountExcelUpload()
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
                result = repository.AccExcelUpload(_mainData);                
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("Result", objutility.EnryptString(result.ToString()));
                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));
                return response;
            }
        }

        [System.Web.Http.Route("CrisMAc/fetchAccExcelData/{param}")]
        [System.Web.Http.HttpGet]
        public string fetchAccExcelData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAccExcelData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        #endregion Acccount Excel Upload
    }
}