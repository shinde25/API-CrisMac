﻿using System;
using System.Web.Http;
using CrisMAc.Models.Utility;
using CrisMAcAPI.Models.Repository.CompanyWiseExchSymbolRepository;
using System.Web.Script.Serialization;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using CrisMAcAPI.Filter;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class companyWiseExchSymbolController : ApiController
    {
        ICompanyWiseExchSymbolRepository  repository;
        UtilityWeb objutility = new UtilityWeb();

        public companyWiseExchSymbolController(ICompanyWiseExchSymbolRepository repository)
        {
            this.repository = repository;
        }


        [Route("CrisMAc/CompanyWiseExchSymbolAuxData/{param}")]
        [HttpGet]
        public string GetAuxDetails(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.GetAuxdata(param);

            //FOR BIG DATA
            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var json = serializer.Serialize(objAuxDetail);

            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/CompanyWiseExchSymbolData/{param}")]
        [HttpGet]
        public string GetCompanyWiseExchsymbol(string param)
        {
            param = objutility.DecryptString(param);
            var objAuxDetail = repository.FetchData(param);
            var json = new JavaScriptSerializer().Serialize(objAuxDetail);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/AddCompanyWiseExchSymbolData/")]
        [HttpPost]
        public HttpResponseMessage InsertUpdateCompanyWiseActivity()
        {
            object result = null;

            JObject result1 = new JObject();
            result1.Add("Result", "-1");
            result1.Add("D2Ktimestamp", "0");

            try
            {
                string _data = Request.Content.ReadAsStringAsync().Result;
                var _mainData = objutility.DecryptString(_data);
                result = repository.CompanyWiseExchSymbolInsertUpdateData(_mainData);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("result", objutility.EnryptString(result.ToString()));

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified);
                response.Headers.Add("result", objutility.EnryptString(result1.ToString()));

                return response;
            }
        }
    }
}
