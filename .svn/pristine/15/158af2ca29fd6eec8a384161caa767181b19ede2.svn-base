using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrisMAc.Models.Utility;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.UserMaintananceRepository;
using System;
using CrisMAcAPI.Filter;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class UserMaintananceController : ApiController
    {
        IUserMaintananceRepository repository;
        //List<MenuModel> lst;
        public UserMaintananceController(IUserMaintananceRepository repository)
        {
            this.repository = repository;
        }
        UtilityWeb objutility = new UtilityWeb();

        [Route("CrisMAc/GetmenuDetails/{param}")]
        [HttpGet]
        public string GetmenuDetails(string param)
        {
            param = objutility.DecryptString(param);
            var lst = repository.Select_MenuLayout(param);
            var json = new JavaScriptSerializer().Serialize(lst);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/GetmenuList/{param}")]
        [HttpGet]
        public string GetmenuList(string param)
        {
            param = objutility.DecryptString(param);
            var lst = repository.Select_MenuList(param);
            var json = new JavaScriptSerializer().Serialize(lst);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/ChangePwd/")]
        [HttpPost]
        public HttpResponseMessage ChangePassward()
        {
            int result = -1;

            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.GetChangepwdData(_mainData);

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
        [Route("CrisMAc/ResetPwdAuxSele/{param}")]
        [HttpGet]
        public string ResetPwdAuxSele(string param)
        {
            param = objutility.DecryptString(param);
            var objUserData = repository.GetResetPwdData(param);
            var json = new JavaScriptSerializer().Serialize(objUserData);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/ResetPassUpdate/")]
        [HttpPost]
        public HttpResponseMessage ResetPassUpdate()
        {
            int result = -1;
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.GetResetPassUpdate(_mainData);

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
        [Route("CrisMAc/GetUserInformation/{param}")]
        [HttpGet]
        public string GetUserInformation(string param)
        {
            param = objutility.DecryptString(param);
            var objUserData = repository.GetUserinformation(param);
            var json = new JavaScriptSerializer().Serialize(objUserData);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/GetSuspendedUser/{param}")]
        [HttpGet]
        public string GetSuspendedUser(string param)
        {
            param = objutility.DecryptString(param);
            var objUserData = repository.GetSuspendedUser(param);
            var json = new JavaScriptSerializer().Serialize(objUserData);
            return objutility.EnryptString(json);
        }
        [Route("CrisMac/InvokedUserSuspendUpdate/")]
        [HttpPost]
        public HttpResponseMessage InvokedUserSuspendUpdate()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            var _mainData = objutility.DecryptString(_data);
            int result = repository.GetUpdateSetInvokeSuspendedUser(_mainData);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Add("result", result.ToString());
            return response;
        }
        [Route("CrisMac/UserLoginAuxSelect/{param}")]
        [HttpGet]
        public string UserLoginAuxSelect(string param)
        {
            param = objutility.DecryptString(param);
            var objUserData = repository.GetLoginUserInfo(param);
            var json = new JavaScriptSerializer().Serialize(objUserData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/UserLoginInvokeUpdate/")]
        [HttpPost]
        public HttpResponseMessage UserLoginInvokeUpdate()
        {
            int result = -1;
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.GetInvokedLoginUser(_mainData);

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
        [Route("CrisMAc/UserPolicyMasterData/{param}")]
        [HttpGet]
        public string UserPolicyMasterData(string param)
        {
            param = objutility.DecryptString(param);
            var objUserData = repository.GetUserPolicyMetaData(param);
            var json = new JavaScriptSerializer().Serialize(objUserData);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/UserPolicySavedata/")]
        [HttpPost]
        public HttpResponseMessage InsertAttribute()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            var _mainData = objutility.DecryptString(_data);
            int result = repository.UpdateUserParameter(_mainData);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            return response;
        }
        //[Route("CrisMAc/UserMainGrpDeptCreation/{param}")]
        //[HttpGet]
        //public string UserMainGrpDeptCreation(string param)
        //{
        //    param = objutility.DecryptString(param);
        //    var objUserData = repository.GetUserGrpDeptCreationData(param);
        //    var json = new JavaScriptSerializer().Serialize(objUserData);
        //    return objutility.EnryptString(json);

        //}
    }
}
