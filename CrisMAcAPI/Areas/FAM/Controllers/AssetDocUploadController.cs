using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.FAM.Models.Repository.AssetDocUploadRepository;
using CrisMAcAPI.Filter;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class AssetDocUploadController : ApiController
    {
        IAssetDocUploadRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public AssetDocUploadController(IAssetDocUploadRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/FetchDocumentUploadParameterisedData/{param}")]
        [HttpGet]
        public string FetchDocumentUploadParameterisedData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetMetaDataForDocumentUpload(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        //      FETCH   ************************    //
        [Route("CrisMAc/FetchDocumentUploadData/{param}")]
        [HttpGet]
        public string FetchDocumentUploadData(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/SaveDocumentUploadMain/")]
        [HttpPost]
        public HttpResponseMessage SaveDocumentUploadMain()
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
                result = repository.SaveDocumentUploadMain(_mainData);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("Result", objutility.EnryptString(result.ToString()));

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("Result", objutility.EnryptString(result.ToString()));

                return response;
            }
        }
    }

}
