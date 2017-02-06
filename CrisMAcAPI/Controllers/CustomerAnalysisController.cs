using CrisMAc.Models.Utility;
using CrisMAcAPI.Models.Repository.CustomerAnalysis;
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
    public class CustomerAnalysisController : ApiController
    {
        ICustomerAnalysisRepository repository;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };
        UtilityWeb objutility = new UtilityWeb();

        public CustomerAnalysisController(ICustomerAnalysisRepository repository)
        {
            this.repository = repository;
        }
        // GET: DashBoard


        [Route("CrisMAc/CustomerNewsBlogsTweets/{param}")]
        [HttpGet]
        public string CustomerNewsBlogsTweets(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetCustomerNewsBlogsTweets(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/CustomerDetails/{param}")]
        [HttpGet]
        public string CustomerDetails(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetCustomerDetailAuxData(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/CustomerDetailsAuxData/{param}")]
        [HttpGet]
        public string CustomerDetailsAuxData(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetCustomerDetailAuxData(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/CustomerScore/{param}")]
        [HttpGet]
        public string CustomerDetailsScore(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetCustomerDetailScore(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/IndustryDetail/{param}")]
        [HttpGet]
        public string CustomerIndustryDetail(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetCustomerIndustryDetail(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/TransactionDetail/{param}")]
        [HttpGet]
        public string TransactionDetail(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetTransactionDetail(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/FinancialDetail/{param}")]
        [HttpGet]
        public string FinancialDetail(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetFinancialDetail(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/NonFinancialDetail/{param}")]
        [HttpGet]
        public string NonFinancialDetail(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetFinancialDetail(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/StatisticalDetail/{param}")]
        [HttpGet]
        public string StatisticalDetail(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetStatisticalDetail(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/ObtainedTransaction/{param}")]
        [HttpGet]
        public string ObtainedTransaction(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetObtainedTransaction(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/StockDetailPlot/{param}")]
        [HttpGet]
        public string StockDetailPlot(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetStockDetailPlot(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }


        [Route("CrisMAc/PeersIndustry/{param}")]
        [HttpGet]
        public string Comparison_PeersIndustryPlot(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetComparison_PeersIndustryPlot(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }
        [Route("CrisMAc/BLindustries/{param}")]
        [HttpGet]
        public string Comparison_BLindustriesIndexPlot(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetComparison_BLindustriesIndexPlot(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAc/FLindustriesIndex/{param}")]
        [HttpGet]
        public string FLindustriesIndex(string param)
        {
            param = objutility.DecryptString(param);
            var objCustomerAnalysis = repository.GetComparison_FLindustriesIndexPlot(param);
            var json = new JavaScriptSerializer().Serialize(objCustomerAnalysis);
            return objutility.EnryptString(json);
        }

    }
}