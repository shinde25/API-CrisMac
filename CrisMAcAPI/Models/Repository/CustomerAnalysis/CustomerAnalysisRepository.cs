using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.CustomerAnalysis
{
    public class CustomerAnalysisRepository : ICustomerAnalysisRepository
    {
        CustomerAnalysisModel _CustomerAnalysis;
        JavaScriptSerializer serializer;
        DataSet _DataSet;

        public List<object> GetCustomerNewsBlogsTweets(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.CustomerAnalysisNewsTwitsBlogs();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }

        public List<object> GetCustomerDetail(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.CustomerDetail();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetCustomerDetailAuxData(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.CustomerDetailAuxData();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetCustomerDetailScore(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.CustomerDetailScore();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetCustomerIndustryDetail(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.CustomerIndustryDetail();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }

        public List<object> GetTransactionDetail(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.TransactionDetail();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetFinancialDetail(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.FinancialDetail();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetNonFinancialDetail(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.NonFinancialDetail();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetStatisticalDetail(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.StatisticalDetail();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetObtainedTransaction(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.ObtainedTransaction();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }

        public List<object> GetStockDetailPlot(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.StockDetailPlot();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetComparison_PeersIndustryPlot(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.StockDetailPlot();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetComparison_BLindustriesIndexPlot(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.StockDetailPlot();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetComparison_FLindustriesIndexPlot(string paramString)
        {
            _CustomerAnalysis = new CustomerAnalysisModel();
            serializer = new JavaScriptSerializer();
            _CustomerAnalysis = serializer.Deserialize<CustomerAnalysisModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAnalysis.StockDetailPlot();
            _DataSet = _CustomerAnalysis.ResultDataSet;
            return _DataSet.ToList();
        }

    }
}