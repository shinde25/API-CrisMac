using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.UserCreationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class UserCreationController : ApiController
    {
        IUserCreationRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        public UserCreationController(IUserCreationRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/UserCreationParamatrised/{param}")]
        [HttpGet]
        public string UserCreationParamatrisedMasterData(string param)
        {
            param = objutility.DecryptString(param);
            var lst = repository.FetchData(param);
            var json = new JavaScriptSerializer().Serialize(lst);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/UserCreationModificationAuxSelect/{param}")]
        [HttpGet]
        public string UserModificationAuxSelect(string param)
        {
            param = objutility.DecryptString(param);
            var lst = repository.GetAuxdata(param);
            var json = new JavaScriptSerializer().Serialize(lst);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/UserCreationInsert/")]
        [HttpPost]
        public HttpResponseMessage UserCreationInsert()
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
