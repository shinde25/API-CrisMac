using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.CommonComponent.Models.Repository.GapDataMasterRepository;
using CrisMAcAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CommonComponent.Controllers
{
    [Authorize]
    [LogFilter]
    public class GapDataMasterController : ApiController
    {
        UtilityWeb objutility = new UtilityWeb();
        IGapDataMasterRepository repository;

        public GapDataMasterController(IGapDataMasterRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/GapDataCommonMast/{param}")]
        [HttpGet]
        public string GetMasterMetaData(string param)
        {
            param = objutility.DecryptString(param);
            var objFetchData = repository.FetchData(param);
            var json = new JavaScriptSerializer().Serialize(objFetchData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/GapDataCommonMasterAuxData/{param}")]
        [HttpGet]
        public string GetMasterAuxData(string param)
        {
            param = objutility.DecryptString(param);
            List<object> objAuxData = repository.GetAuxMasterdata(param);
            JavaScriptSerializer jser = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };
            var json = jser.Serialize(objAuxData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/GapDataCommonMasterSaveData/")]
        [HttpPost]
        public HttpResponseMessage GetMasterSaveData()
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
