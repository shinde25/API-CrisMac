using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.SubParameterMatrixRepository;
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
    public class SubParameterMatrixController : ApiController
    {
        ISubParameterMatrixRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public SubParameterMatrixController(ISubParameterMatrixRepository repository)
        {
            this.repository = repository;
        }

        //      AUX     *************************//
        [Route("CrisMAc/SubParameterMatrixAuxData/{param}")]
        [HttpGet]
        public string GetAuxSubParameterMatrix(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param); // repository's GetAuxData() call
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        //      FETCH   ************************    //
        [Route("CrisMAc/FetchSubParameterMatrix/{param}")]
        [HttpGet]
        public string FetchSubParameterMatrix(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);  // repository's FetchData() call
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        //      INSERT UPDATE SP    ********************  //
        [Route("CrisMAc/InsertSubParameterMatrix/")]
        [HttpPost]
        public HttpResponseMessage InsertSubParameterMatrix()
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
