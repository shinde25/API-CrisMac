using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.EWSPaymentTrackingRepository
{
    public class EWSPaymentTrackingRepository : IEWSPaymentTrackingRepository
    {
        EWSPaymentTrackingModel _PaymentTrackingModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public List<object> GetMetaData(string ParaStr)
        {
            _PaymentTrackingModel = new EWSPaymentTrackingModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _PaymentTrackingModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            //_PaymentTrackingModel.UserLoginId = job["UserLoginId"].ToString();

            _DataSet = new DataSet();
            _PaymentTrackingModel.EWSPaymentTrackingParmatrised();   // call to model's function
            _DataSet = _PaymentTrackingModel.ResultDataSet;

            return _DataSet.ToList();
        }      

        public List<object> GetAuxdata(string paramString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            _PaymentTrackingModel = new EWSPaymentTrackingModel();
            //JObject job = JObject.Parse(paramString);           
            _PaymentTrackingModel = serializer.Deserialize<EWSPaymentTrackingModel>(paramString);
            _PaymentTrackingModel.EWSPaymentTrackingAuxSelect();         // call to model's function
            DataSet __PaymentTrackingAuxDS = _PaymentTrackingModel.ResultDataSet;
            return __PaymentTrackingAuxDS.ToList();
        }

        public List<object> FetchData(string paramString)
        {
            _PaymentTrackingModel = new EWSPaymentTrackingModel();
            serializer = new JavaScriptSerializer();
            _PaymentTrackingModel = serializer.Deserialize<EWSPaymentTrackingModel>(paramString);

            _DataSet = new DataSet();
            _PaymentTrackingModel.EWSPaymentTrackingSelect(); // call to model's function
            _DataSet = _PaymentTrackingModel.ResultDataSet;           
            return _DataSet.ToList();
        }

        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            _PaymentTrackingModel = new EWSPaymentTrackingModel();

            JObject job = JObject.Parse(jsonData);
            _PaymentTrackingModel.EWSPaymentTrackingJson = Convert.ToString(job["EWSPaymentTrackingJson"].ToString());
            _PaymentTrackingModel._MenuID = Convert.ToInt32(job["_MenuID"].ToString());
            //_PaymentTrackingModel._Remark = Convert.ToString(job["_Remark"].ToString());
            _PaymentTrackingModel._BranchCode = Convert.ToString(job["_BranchCode"].ToString());
            _PaymentTrackingModel._dateCreatedmodified = Convert.ToDateTime(job["_dateCreatedmodified"].ToString());
            _PaymentTrackingModel._CreatetedModifiedBy = Convert.ToString(job["_CreatetedModifiedBy"].ToString());
            _PaymentTrackingModel._OperationFlag = Convert.ToInt32(job["_OperationFlag"].ToString());
            _PaymentTrackingModel._AuthMode = Convert.ToString(job["_AuthMode"].ToString());
            _PaymentTrackingModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _PaymentTrackingModel._EffectiveFromTimeKey = Convert.ToInt32(job["_EffectiveFromTimeKey"].ToString());
            _PaymentTrackingModel._EffectiveToTimeKey = Convert.ToInt32(job["_EffectiveToTimeKey"].ToString());
            rval = _PaymentTrackingModel.EWSPaymentTrackingInsertUpdate();  // call to model's function
            return rval;
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