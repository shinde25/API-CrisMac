﻿using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.DocumentUploadRepository;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
//using CrisMAcAPI.Models.Repository;
//using CrisMAcAPI.Models.Repository.DocumentUploadRepository;
//using System.Collections.Generic;
//using System.Linq;


namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class DocumentUploadController : ApiController
    {
        IDocumentUploadRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public DocumentUploadController(IDocumentUploadRepository repository)
        {
            this.repository = repository;
        }



        //      parmatrised    **************************** //
        [Route("CrisMAc/GetMetaDocumentUpload/{param}")]
        [HttpGet]
        public string GetMetaDocumentUpload(string param) 
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetMetaData(param); // repository's GetMetaData() call for paramatrised
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        //      AUX     *************************//
        [Route("CrisMAc/DocumentUploadAuxData/{param}")]
        [HttpGet]
        public string GetAuxDocumentUpload(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param); // repository's GetAuxData() call
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        //      FETCH   ************************    //
        [Route("CrisMAc/FetchDocumentUpload/{param}")]
        [HttpGet]
        public string FetchDocumentUpload(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);  // repository's FetchData() call
            var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/GetRetrieveDocumentUploadedFile/{param}")]
        [HttpGet]
        public string RetriveDocumentUploadFile(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.DocumentUploadedFileSelect(param);  // repository's FetchData() call
                                                                              //  var json = _JavaScriptSerializer.Serialize(objAuxDetail);
            if (objAuxDetail.Count != 0)
            {
                return objutility.EnryptString(objAuxDetail[0].ToString());
            }
            return "";
        }

        //      INSERT UPDATE SP    ********************  //
        [Route("CrisMAc/InsertDocumentUpload/")]
        [HttpPost]
        public HttpResponseMessage InsertDocumentUpload()
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
                result = repository.InsertUpdateData(_mainData); // repository's InsertUpdateData() call

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
        [Route("CrisMAc/InsertDocumentUpload_images/")]
        [HttpPost]
        public HttpResponseMessage InsertDocumentUpload_images()
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
                result = repository.InsertUpdateData_images(_mainData); // repository's InsertUpdateData() call

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