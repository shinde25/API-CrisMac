using CrisMAc.Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using CrisMAcAPI.Areas.CMA.Models.Repository.AppLoginRepository;
using Newtonsoft.Json;

namespace CrisMAcAPI.Areas.CMA.Controllers
{
    public class CMALoginController : ApiController
    {
        ICMALoginRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();


        public CMALoginController(ICMALoginRepository repository)
        {
            this.repository = repository;
        }


        [Route("CrisMAc/AppChangePassword/")]
        [HttpPost]
        public HttpResponseMessage InsertAppChangePassword()
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
                result = repository.PasswordChangeInsertUpdateData(_mainData); // repository's InsertUpdateData() call

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

        [Route("CrisMAc/LoginAuth/{param}")]
        [HttpGet]
        public string UserAuthentication(string param)
        {
            param = objutility.DecryptString(param);

            var LstData = repository.SelectUserAuthenticationDetails(param);

            var json = new JavaScriptSerializer().Serialize(LstData[0]);
            return objutility.EnryptString(json);

        }

        [Route("CrisMAc/APP_ChangePassword/")]
        [HttpPost]
        public string APP_ChangePassword()
        {
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                //var _mainData = objutility.DecryptString(_data);
                var  result = repository.APP_ChangePasswordRepo(_data);

                string  json = JsonConvert.SerializeObject(result);
                return objutility.EnryptString(json);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}