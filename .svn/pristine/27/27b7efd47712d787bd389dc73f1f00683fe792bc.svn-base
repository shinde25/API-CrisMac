using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.CustomerAllocationRepository
{
    public class CustomerAllocationRepository : ICustomerAllocationRepository
    {
        CustomerAllocationModel _CustomerAllocationModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        public List<object> FetchData(string paramString)
        {
            _CustomerAllocationModel = new CustomerAllocationModel();
            serializer = new JavaScriptSerializer();
            _CustomerAllocationModel = serializer.Deserialize<CustomerAllocationModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAllocationModel.CustomerAllocationSelect(); // call to model's function
            _DataSet = _CustomerAllocationModel.ResultDataSet;
            //List<object> LstObj = new List<object>();

            //var Data = _DataSet.Tables[0].AsEnumerable().Select(x =>
            //  new
            //  {
            //      DocDate= x.Field<object>("DocDate"),
            //      DocumentTypeAlt_Key = x.Field<int>("DocumentTypeAlt_Key"),
            //      DocName = x.Field<string>("DocName"),
            //      FileType = x.Field<string>("FileType"),                               
            //  }).ToList();

            //LstObj.Add(Data);
            return _DataSet.ToList();
        }

        public List<object> GetUserInfoFetch(string ParaStr)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            _CustomerAllocationModel = new CustomerAllocationModel();
            _CustomerAllocationModel = serializer.Deserialize<CustomerAllocationModel>(ParaStr);
            _CustomerAllocationModel.UserAllocationAuxSelect();         // call to model's function
            DataSet __CustomerAllocationAuxDS = _CustomerAllocationModel.ResultDataSet;
            List<object> LstObj = new List<object>();

            //var CmpInd = _DocumentUploadAuxDS.Tables[0].AsEnumerable().Select(x =>
            //    new
            //    {
            //        CompanyCode = x.Field<int>("CompanyCode"),
            //        CompanyName = x.Field<string>("CompanyName")

            //    }).ToList();

            //LstObj.Add(CmpInd);
            //var DocumentUploadModelList = ((IEnumerable<dynamic>)LstObj).ToList();
            return __CustomerAllocationAuxDS.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            _CustomerAllocationModel = new CustomerAllocationModel();
            _CustomerAllocationModel = serializer.Deserialize<CustomerAllocationModel>(paramString);
            _CustomerAllocationModel.CustomerAllocationAuxSelect();         // call to model's function
            DataSet __CustomerAllocationAuxDS = _CustomerAllocationModel.ResultDataSet;           
            return __CustomerAllocationAuxDS.ToList();
        }
       

        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            _CustomerAllocationModel = new CustomerAllocationModel();           

            JObject job = JObject.Parse(jsonData);

            //_CustomerAllocationModel.CustomerEntityId = Convert.ToInt32(job["CustomerEntityId"].ToString());
            //_CustomerAllocationModel.PriActionStakeHolder = Convert.ToString(job["PriActionStakeHolder"].ToString());
            //_CustomerAllocationModel.SecActionStakeHolder = Convert.ToString(job["SecActionStakeHolder"].ToString());
            //_CustomerAllocationModel.InfoStakeHolder = Convert.ToString(job["InfoStakeHolder"].ToString());
            _CustomerAllocationModel.InfoStakeHolder = Convert.ToString(job["CustomerAllocationJson"].ToString());
            _CustomerAllocationModel._MenuID = Convert.ToInt32(job["_MenuID"].ToString());
            _CustomerAllocationModel._Remark= Convert.ToString(job["_Remark"].ToString()); 
            _CustomerAllocationModel._BranchCode = Convert.ToString(job["_BranchCode"].ToString());
            _CustomerAllocationModel._dateCreatedmodified = Convert.ToDateTime(job["_dateCreatedmodified"].ToString());
            _CustomerAllocationModel._CreatetedModifiedBy = Convert.ToString(job["_CreatetedModifiedBy"].ToString());
            _CustomerAllocationModel._OperationFlag = Convert.ToInt32(job["_OperationFlag"].ToString());
            _CustomerAllocationModel._AuthMode = Convert.ToString(job["_AuthMode"].ToString());
            _CustomerAllocationModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _CustomerAllocationModel._EffectiveFromTimeKey = Convert.ToInt32(job["_EffectiveFromTimeKey"].ToString());
            _CustomerAllocationModel._EffectiveToTimeKey = Convert.ToInt32(job["_EffectiveToTimeKey"].ToString());
            rval = _CustomerAllocationModel.CustomerAllocationInsertUpdate();  // call to model's function
            return rval;
        }

        public List<object> GetMetaData(string ParaStr)
        {
            _CustomerAllocationModel = new CustomerAllocationModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _CustomerAllocationModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());

            _DataSet = new DataSet();
            _CustomerAllocationModel.CustomerAllocationParmatrised();   // call to model's function
            _DataSet = _CustomerAllocationModel.ResultDataSet;

            return _DataSet.ToList();
        }

        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }
        
    }
}