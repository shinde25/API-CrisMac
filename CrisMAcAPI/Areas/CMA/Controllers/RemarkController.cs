using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.CMA.Models.Repository.RemarkRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CMA.Controllers
{
    public class RemarkController : ApiController
    {
        IRemarkRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

        public RemarkController(IRemarkRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/APP_RemarkInsertUpdate/{param}")]
        [HttpGet]
        public string APP_RemarkInsertUpdate(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.RemarkInsertUpdate(param);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_ActionalbeRemarkInsert/{param}")]
        [HttpGet]
        public string APP_ActionalbeRemarkInsert(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.ActionableRemarkInsert(param);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_ActionEventUpdate/{param}")]
        [HttpGet]
        public string APP_ActionEventUpdate(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.ActionEventUpdate(param);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);
        }
       
        [Route("CrisMAc/APP_GetPreviousRemark/{param}")]        // getactioneventdiary
        [HttpGet]
        public string APP_GetPreviousRemark(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetPreviousRemark(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetAssignAction/{param}")]
        [HttpGet]
        public string APP_GetAssignAction(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.GetAssignAction(param);
            var json = JsonConvert.SerializeObject(ResultData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        //------------------------------------------------------------------------------

        [Route("CrisMAc/APP_GetActionEventDiaryDetails/{param}")]               
        [HttpGet]
        public string APP_GetActionEventDiaryDetails(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.APP_GetActionEventDiaryDetailsRepo(param);
            var json = JsonConvert.SerializeObject(ResultData, Formatting.Indented);
            return objutility.EnryptString(json);
        }
                
        [Route("CrisMAc/APP_DefaultStatus/")]                            
        [HttpGet]
        public string APP_DefaultStatus()
        {
            //param = objutility.DecryptString(param);
            var ResultData = repository.APP_DefaultStatusRepo();
            var json = JsonConvert.SerializeObject(ResultData, Formatting.Indented);
            return objutility.EnryptString(json);
        }
                
        [Route("CrisMAc/APP_StakeHolderList/{param}")]                          
        [HttpGet]
        public string APP_StakeHolderList(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.APP_StakeHolderListRepo(param);
            var json = JsonConvert.SerializeObject(ResultData, Formatting.Indented);
            return objutility.EnryptString(json);
        }


        //[Route("CrisMAc/APP_CustomerReAllocationUpdate/{param}")]
        //[HttpGet]
        //public string APP_CustomerReAllocationUpdate(string param)      //--- insert
        //{
        //    param = objutility.DecryptString(param);
        //    var ResultData = repository.APP_CustomerReAllocationUpdateRepo(param);
        //    var json = JsonConvert.SerializeObject(ResultData);
        //    return objutility.EnryptString(json);
        //}

        [Route("CrisMAc/APP_GetActionEventDiaryList/{param}")]
        [HttpGet]
        public string APP_GetActionEventDiaryList(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.APP_ActionEventDiaryListRepo(param);
            var json = JsonConvert.SerializeObject(ResultData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetRemarkList/{param}")]
        [HttpGet]
        public string APP_GetRemarkList(string param)
        {
            param = objutility.DecryptString(param);
            var ResultData = repository.APP_GetRemarkListRepo(param);
            var json = JsonConvert.SerializeObject(ResultData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_AssignActionInsertUpdate/")]
        [HttpPost]
        public string APP_AssignActionInsertUpdate()
        {
            try {
                string _data = Request.Content.ReadAsStringAsync().Result;
              //  var _mainData = objutility.DecryptString(_data); ;
                var ResultData = repository.AssignActionInsertUpdateRepo(_data);
                var json = JsonConvert.SerializeObject(ResultData);
                return objutility.EnryptString(json);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("CrisMAc/APP_test")]
        [HttpPost]
        public string APP_Test()
        {
            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                return _data;
            }
            catch (Exception)
            {
                return "0";
            }
        }

    }
}
