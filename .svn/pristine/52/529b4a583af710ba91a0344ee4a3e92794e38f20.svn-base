using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.CMA.Models.Repository.CMA_CommonRepository;
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
    public class CustomerController : ApiController
    {
        ICustomerRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/App_GetBranchList/{param}")]
        [HttpGet]
        public string App_GetBranchList(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetBranchList(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetCustomeList/{param}")]
        [HttpGet]
        public string APP_GetCustomeList(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetCustomeList(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetCustomeDetails/{param}")]
        [HttpGet]
        public string APP_GetCustomeDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetCustomeDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetLoanDetails/{param}")]
        [HttpGet]
        public string APP_GetLoanDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetLoanDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetRecoveryDetails/{param}")]
        [HttpGet]
        public string APP_GetRecoveryDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetRecoveryDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetSecurityDetails/{param}")]
        [HttpGet]
        public string APP_GetSecurityDetails(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetSecurityDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetCoBorrGuar/{param}")]
        [HttpGet]
        public string APP_GetCoBorrGuar(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetCoBorrGuar(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetSecurityFutherDetail/{param}")]
        [HttpGet]
        public string APP_GetSecurityFutherDetail(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetSecurityFurtherDetails(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_CustomerReAllocationUpdate/")]  //----Customer ReAllocation Update
        [HttpPost]
        public string APP_CustomerReAllocationUpdate()     
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            //var _mainData = objutility.DecryptString(_data);
            var ResultData = repository.APP_CustomerReAllocationUpdateRepo(_data);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);
            
        }

        
        [Route("CrisMAc/APP_GetSecurityVehicleDetail/{param}")]
        [HttpGet]
        public string APP_GetSecurityVehicleDetail(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetSecurityVehicleDetail(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetSecurityGoldDetail/{param}")]
        [HttpGet]
        public string APP_GetSecurityGoldDetail(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetSecurityGoldDetail(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        } 
                
        [Route("CrisMAc/APP_SecurityVehicleDetailInsertUpdate/")]  
        [HttpPost]
        public string APP_SecurityVehicleDetailInsertUpdate()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            //var _mainData = objutility.DecryptString(_data);
            var ResultData = repository.APP_SecurityVehicleDetailInsertUpdateRepo(_data);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);

        }

        [Route("CrisMAc/APP_GetSecurityShareDetail/{param}")]
        [HttpGet]
        public string APP_GetSecurityShareDetail(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetSecurityShareDetail(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_GetSecurityPropertyDetail/{param}")]
        [HttpGet]
        public string APP_GetSecurityPropertyDetail(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetSecurityPropertyDetail(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/APP_SecurityGoldDetailInsertUpdate/")]
        [HttpPost]
        public string APP_SecurityGoldDetailInsertUpdate()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            //var _mainData = objutility.DecryptString(_data);
            var ResultData = repository.APP_SecurityGoldDetailInsertUpdateRepo(_data);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);

        }


        [Route("CrisMAc/APP_SecurityShareDetailInsertUpdate/")]
        [HttpPost]
        public string APP_SecurityShareDetailInsertUpdate()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            //var _mainData = objutility.DecryptString(_data);
            var ResultData = repository.APP_SecurityShareDetailInsertUpdateRepo(_data);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);

        }

        [Route("CrisMAc/APP_SecurityPropertyDetailInsertUpdate/")]
        [HttpPost]
        public string APP_SecurityPropertyDetailInsertUpdate()
        {
            string _data = Request.Content.ReadAsStringAsync().Result;
            //var _mainData = objutility.DecryptString(_data);
            var ResultData = repository.APP_SecurityPropertyDetailInsertUpdateRepo(_data);
            var json = JsonConvert.SerializeObject(ResultData);
            return objutility.EnryptString(json);

        }

        [Route("CrisMAc/App_GetInsuranceCompanyList/{param}")]
        [HttpGet]
        public string App_GetInsuranceCompanyList(string param)
        {
            param = objutility.DecryptString(param);
            var LstData = repository.GetInsuranceCompanyList(param);
            var json = JsonConvert.SerializeObject(LstData, Formatting.Indented);
            return objutility.EnryptString(json);
        }

    }
}
