using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.SubParameterMatrixRepository
{
    public class SubParameterMatrixRepository:ISubParameterMatrixRepository
    {
        SubParameterMatrixModel _SubParameterMatrixModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public List<object> GetMetaData(string ParaStr)
        {
            _SubParameterMatrixModel = new SubParameterMatrixModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _SubParameterMatrixModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());

            _DataSet = new DataSet();
            _SubParameterMatrixModel.SubParameterMatrixParmatrised();   // call to model's function
            _DataSet = _SubParameterMatrixModel.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            _SubParameterMatrixModel = new SubParameterMatrixModel();
            _SubParameterMatrixModel = serializer.Deserialize<SubParameterMatrixModel>(paramString);
            _SubParameterMatrixModel.SubParameterMatrixAuxSelect();        // call to model's function
            DataSet __SubParameterMatrixAuxDS = _SubParameterMatrixModel.ResultDataSet;
            return __SubParameterMatrixAuxDS.ToList();
        }

        public List<object> FetchData(string paramString)
        {
            _SubParameterMatrixModel = new SubParameterMatrixModel();
            serializer = new JavaScriptSerializer();
            _SubParameterMatrixModel = serializer.Deserialize<SubParameterMatrixModel>(paramString);

            _DataSet = new DataSet();
            _SubParameterMatrixModel.SubParameterMatrixSelect(); // call to model's function
            _DataSet = _SubParameterMatrixModel.ResultDataSet;
            return _DataSet.ToList();
        }

        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            _SubParameterMatrixModel = new SubParameterMatrixModel();

            JObject job = JObject.Parse(jsonData);
            _SubParameterMatrixModel.SubParameterMatrixJson = Convert.ToString(job["ParameterMetricsJson"].ToString());
            _SubParameterMatrixModel._MenuID = Convert.ToInt32(job["_MenuID"].ToString());
            _SubParameterMatrixModel._Remark = Convert.ToString(job["_Remark"].ToString());
            _SubParameterMatrixModel._BranchCode = Convert.ToString(job["_BranchCode"].ToString());
            _SubParameterMatrixModel._dateCreatedmodified = Convert.ToDateTime(job["_dateCreatedmodified"].ToString());
            _SubParameterMatrixModel._CreatetedModifiedBy = Convert.ToString(job["_CreatetedModifiedBy"].ToString());
            _SubParameterMatrixModel._OperationFlag = Convert.ToInt32(job["_OperationFlag"].ToString());
            _SubParameterMatrixModel._AuthMode = Convert.ToString(job["_AuthMode"].ToString());
            _SubParameterMatrixModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _SubParameterMatrixModel._EffectiveFromTimeKey = Convert.ToInt32(job["_EffectiveFromTimeKey"].ToString());
            _SubParameterMatrixModel._EffectiveToTimeKey = Convert.ToInt32(job["_EffectiveToTimeKey"].ToString());
            rval = _SubParameterMatrixModel.SubParameterMatrixInsertUpdate();  // call to model's function
            return rval;
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}