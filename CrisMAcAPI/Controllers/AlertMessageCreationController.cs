using CrisMAc.Models.Utility;
using CrisMAcAPI.Models.Repository.AlertMessageCreationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    public class AlertMessageCreationController : ApiController
    {
        IAlertMessageCreationRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();


        public AlertMessageCreationController(IAlertMessageCreationRepository repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/AlertMessageAuxData/{param}")]
        [HttpGet]
        //Aux Data
        public string AuxAlertMessage(string param)
        {


            param = objutility.DecryptString(param);
            var objAuxDetail = repository.AuxAlertMessageData(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/MetadataAlertMessage/{param}")]
        [HttpGet]
        // MetaData
        public string MetadataAlertMessage(string param)
        {


            param = objutility.DecryptString(param);
            var objAuxDetail = repository.MetadataAlertMessage(param);
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }



        [Route("CrisMAc/FetchAlertMessageDetails/{param}")]
        [HttpGet]
        //Fetch Branch details
        public string FetchAlertMessageDetails(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchAlertMessageData(param);

            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/InsertUpdateAlertMessage/")]
        [HttpPost]
        //Insert Update details
        public HttpResponseMessage InsertUpdateAlertMessage()
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
                result = repository.InsertUpdateAlertMessageData(_mainData);

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


    }
}
