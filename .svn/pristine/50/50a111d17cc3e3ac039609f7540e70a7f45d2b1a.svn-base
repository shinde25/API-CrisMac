using CrisMAc.Models.Utility;
using CrisMAcAPI.Models;
using CrisMAcAPI.Models.Repository.LoginRepository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    public class LoginController : ApiController
    {
        UtilityWeb objutility = new UtilityWeb();

        ILoginRepository repository;
        public LoginController(ILoginRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/SelectLoginDetails/{param}")]
        [HttpGet]
        public string SelectLoginDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.SelectLoginDetails(param);
            var json = new JavaScriptSerializer().Serialize(LstData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/LoginDetailsInsert/")]
        [HttpPost]
        public HttpResponseMessage LoginDetailsInsert()
        {
            string result = "";
            JObject Jobj = new JObject();
            Jobj.Add("Result", "-1");
            Jobj.Add("LastLoginOut", "");
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.InsertUserLoginHistory(_mainData);
                result = objutility.EnryptString(result.ToString());
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("result", result);
                return response;
            }
            catch (Exception e)
            {

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(Jobj.ToString()));

                return response;
            }

        }
        [Route("CrisMAc/GetCurrentTimeKey/")]
        [HttpGet]
        public string GetCurrentTimeKey()
        {
            var LstData = repository.SelectSysCurrentTimeKey();
            var json = new JavaScriptSerializer().Serialize(LstData);
            return objutility.EnryptString(json);
        }


        //[Route("CrisMAc/GetLastQtyDateKey/")]
        //[HttpGet]
        //public string GetLastQtyDateKey()
        //{
        //    var LstData = repository.SelectLastQtyKey();
        //    var json = new JavaScriptSerializer().Serialize(LstData);
        //    return objutility.EnryptString(json);
        //}

        [Route("CrisMAc/GetLastLoginDetails/{param}")]
        [HttpGet]
        public string GetLastLoginDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.SelectLastLoginDetails(param);
            var json = new JavaScriptSerializer().Serialize(LstData);
            return objutility.EnryptString(json);
        }

    }
}
