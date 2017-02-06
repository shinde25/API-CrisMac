using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.UserGroupDeptRepository;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class UserGroupDeptController : ApiController
    {
        IUserGroupDeptRepository repository;
  
        public UserGroupDeptController(IUserGroupDeptRepository repository)
        {
            this.repository = repository;
        }
        UtilityWeb objutility = new UtilityWeb();

        [Route("CrisMAc/UserGroupDeptMasterData/{param}")]
        [HttpGet]
        public string userGroupDeptParameterisedMasterData(string param)
        {
            param = objutility.DecryptString(param);
            var objUserData = repository.getParameterisedMasterData(param);
            var json = new JavaScriptSerializer().Serialize(objUserData);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/UserGroupDeptAuxData/{param}")]       
        [HttpGet]
        public string userGroupsAuxSelect(string param)
        {
            param = objutility.DecryptString(param);
            var objAux = repository.GetAuxdata(param);
            var jsonAux = new JavaScriptSerializer().Serialize(objAux);
            return objutility.EnryptString(jsonAux);
        }
        [Route("CrisMAc/UserGroupDeptInsertUpdate/")]
        [HttpPost]
        public HttpResponseMessage userGroupInsertUpdate()
        {
            string dataGrpInsertUpdt = Request.Content.ReadAsStringAsync().Result;
            var mainDecry = objutility.DecryptString(dataGrpInsertUpdt);
            int result = repository.InsertUpdateData(mainDecry);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Add("result", result.ToString());
            return response;
        }

    }
}
