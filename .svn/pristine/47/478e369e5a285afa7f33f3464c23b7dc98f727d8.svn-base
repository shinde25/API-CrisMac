using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrisMAcAPI.Models.Repository.CommonInterface;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace CrisMAcAPI.Models.Repository.CustomerRemarkRepository
{
    class CustomerRemarkRepository : ICustomerRemarkRepository
    {
        CustomerRemarkModel _RemarkModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        //-----------FetchData(para)
        public List<object> FetchData(string paramString)
        {
            _RemarkModel = new CustomerRemarkModel();
            serializer = new JavaScriptSerializer();
            _RemarkModel = serializer.Deserialize<CustomerRemarkModel>(paramString);

            _DataSet = new DataSet();
            _RemarkModel.CustomerRemarkSelect();
            _DataSet = _RemarkModel.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> GetAuxCustomerRemarkListSelect(string paramString)
        {
            _RemarkModel = new CustomerRemarkModel();
            serializer = new JavaScriptSerializer();
            _RemarkModel = serializer.Deserialize<CustomerRemarkModel>(paramString);

            _DataSet = new DataSet();
            _RemarkModel.CustomerRemark_getAccountId();
            _DataSet = _RemarkModel.ResultDataSet;

            return _DataSet.ToList();
        }


        public List<object> GetAuxdata(string paramString)
        {
            _RemarkModel = new CustomerRemarkModel();
            serializer = new JavaScriptSerializer();
            _RemarkModel = serializer.Deserialize<CustomerRemarkModel>(paramString);

            _DataSet = new DataSet();
            _RemarkModel.CustomerRemarkAuxSelect();
            _DataSet = _RemarkModel.ResultDataSet;

            return _DataSet.ToList();
        }

        //-------------GetMetaData()
        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }


        //-------------InsertUpdateData(para)
        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _RemarkModel = serializer.Deserialize<CustomerRemarkModel>(jsonData);
            rval = _RemarkModel.CustomerRemarkInsertUpdate();
            return rval;
        }

        //-------------InsertUpdateData(para)
        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }

        //--------------GetMeataData(para)
        public List<object> GetMetaData(string ParaStr)
        {
            _RemarkModel = new CustomerRemarkModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _RemarkModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());

            _DataSet = new DataSet();
            _RemarkModel.CustomerRemarkParameterised();
            _DataSet = _RemarkModel.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> FetchData_AccIds(string paramString)
        {
            _RemarkModel = new CustomerRemarkModel();
            serializer = new JavaScriptSerializer();
            _RemarkModel = serializer.Deserialize<CustomerRemarkModel>(paramString);

            _DataSet = new DataSet();
            _RemarkModel.CustomerRemark_getAccountId();
            _DataSet = _RemarkModel.ResultDataSet;

            return _DataSet.ToList();
        }
        public List<object> GetCustomerRemarkListSelect(string paramString)
        {
            _RemarkModel = new CustomerRemarkModel();
            serializer = new JavaScriptSerializer();
            _RemarkModel = serializer.Deserialize<CustomerRemarkModel>(paramString);

            _DataSet = new DataSet();
            _RemarkModel.AuxCustomerRemarkListSelect();
            _DataSet = _RemarkModel.ResultDataSet;

            return _DataSet.ToList();
        }

    }
}
