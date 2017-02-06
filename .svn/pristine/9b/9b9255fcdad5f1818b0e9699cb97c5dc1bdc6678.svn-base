using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.ActivityLinkageRepository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class ActivityLinkageController : ApiController
    {
        IActivityLinkageRepository repository;
        UtilityWeb objutility = new UtilityWeb();


        public ActivityLinkageController(IActivityLinkageRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/ActivityLinkageAuxData/{param}")]
        [HttpGet]
        public string GetAuxDetails(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param);
                        
            //FOR BIG DATA
            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };
            var json = serializer.Serialize(objAuxDetail);      

            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/ActivityLinkageInsertUpdate/")]
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