using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.DashBoardRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class EwsHomeDashboardController : ApiController
    {

        IEwsHomeDashboardRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();
       

        public EwsHomeDashboardController(IEwsHomeDashboardRepository repository)
        {
            this.repository = repository;
        }
        // GET: DashBoard

        [Route("CrisMAc/DashBoardAllocatedCustomer/{param}")]
        [HttpGet]
        public string DashBoardAllocatedCustomer(string param)
        {
            param = objutility.DecryptString(param);
            var objAllocatedCustDetails = repository.GetDashBoardAllocatedCustomers(param);
            var json = new JavaScriptSerializer().Serialize(objAllocatedCustDetails);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/DashBoardNewsTwitsBlogs/{param}")]
        [HttpGet]
        public string DashBoardNewsTwitsBlogs(string param)
        {
            param = objutility.DecryptString(param);
            var objBoardNewsTwitsBlogs = repository.GetDashBoardNewsTwitsBlogs(param);
            var json = new JavaScriptSerializer().Serialize(objBoardNewsTwitsBlogs);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/DashBoardPendingActions/{param}")]
        [HttpGet]
        public string DashBoardPendingActions(string param)
        {
            param = objutility.DecryptString(param);
            var objPendingActionDetails = repository.GetDashBoardPendingActions(param);
            var json = _JavaScriptSerializer.Serialize(objPendingActionDetails);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/DashBoardSelectSource/{param}")]
        [HttpGet]
        public string DashBoardSelectSource(string param)
        {
            param = objutility.DecryptString(param);
            var objPendingActionDetails = repository.GetDashBoardSelectSource(param);
            var json = _JavaScriptSerializer.Serialize(objPendingActionDetails);
            return objutility.EnryptString(json);
        }



        [Route("CrisMAc/EWSInsertUpdateSourceData/")]
        [HttpPost]
        public HttpResponseMessage UpdateSouceData()
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
                result = repository.GetInsertUpdateSourceData(_mainData);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("Result", objutility.EnryptString(result.ToString()));

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));

                return response;
            }
        }
    }
}