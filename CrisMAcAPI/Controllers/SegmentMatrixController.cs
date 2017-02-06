using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.SegmentMatrixRepository;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class SegmentMatrixController : ApiController
    {
        ISegmentMatrixRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public SegmentMatrixController(ISegmentMatrixRepository repository)
        {
            this.repository = repository;
        }
        //      parmatrised    **************************** //
        //[Route("CrisMAc/GetMetaParameterMetrics/{param}")]
        //[HttpGet]
        //public string GetMetaParameterMetrics(string param)
        //{
        //    param = objutility.DecryptString(param);
        //    var objAuxDetail = repository.GetMetaData(param); // repository's GetMetaData() call for paramatrised
        //    var json = _JavaScriptSerializer.Serialize(objAuxDetail);
        //    return objutility.EnryptString(json);
        //}


        //      AUX     *************************//
        [Route("CrisMAc/SegmentMatrixAuxData/{param}")]
        [HttpGet]
        public string GetAuxSegmentMatrix(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param); // repository's GetAuxData() call
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        //      FETCH   ************************    //
        [Route("CrisMAc/FetchSegmentMatrix/{param}")]
        [HttpGet]
        public string FetchSegmentMatrix(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);  // repository's FetchData() call
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        //      INSERT UPDATE SP    ********************  //
        [Route("CrisMAc/InsertSegmentMatrix/")]
        [HttpPost]
        public HttpResponseMessage InsertSegmentMatrix()
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
                result = repository.InsertUpdateData(_mainData); // repository's InsertUpdateData() call

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
    }
}
