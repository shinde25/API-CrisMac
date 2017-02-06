using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.D2k_Inventory.Models.Repository.AppLoginRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.D2k_Inventory.Controllers
{
    public class AppLoginController : ApiController
    {
        IAppLoginRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public AppLoginController(IAppLoginRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/UserPasswordPolicy/")]
        [HttpGet]
        public string FetchDocumentUpload()
        {
            var objAuxDetail = repository.APPUserPwdPolicySelect();  // repository's FetchData() call
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);

        }

        //      INSERT UPDATE SP    ********************  //
        [Route("CrisMAc/InsertAppChangePassword/")]
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

        [Route("CrisMAc/UserLoginAuth/{param}")]
        [HttpGet]
        public string UserAuthentication(string param)
        {
            param = objutility.DecryptString(param);

            var LstData = repository.SelectUserAuthenticationDetails(param);

            var json = new JavaScriptSerializer().Serialize(LstData[0]);
            return objutility.EnryptString(json);

        }

    }
}
