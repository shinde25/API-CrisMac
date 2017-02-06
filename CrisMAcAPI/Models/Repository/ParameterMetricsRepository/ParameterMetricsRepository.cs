using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.ParameterMetricsRepository
{
    public class ParameterMetricsRepository : IParameterMetricsRepository
    {
        ParameterMetricsModel _ParameterMetricsModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public List<object> GetMetaData(string ParaStr)
        {
            _ParameterMetricsModel = new ParameterMetricsModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _ParameterMetricsModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());

            _DataSet = new DataSet();
            _ParameterMetricsModel.ParameterMetricsParmatrised();   // call to model's function
            _DataSet = _ParameterMetricsModel.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            _ParameterMetricsModel = new ParameterMetricsModel();
            _ParameterMetricsModel = serializer.Deserialize<ParameterMetricsModel>(paramString);
            _ParameterMetricsModel.ParameterMetricsAuxSelect();        // call to model's function
            DataSet __ParameterMetricsAuxDS = _ParameterMetricsModel.ResultDataSet;
            return __ParameterMetricsAuxDS.ToList();
        }

        public List<object> FetchData(string paramString)
        {
            _ParameterMetricsModel = new ParameterMetricsModel();
            serializer = new JavaScriptSerializer();
            _ParameterMetricsModel = serializer.Deserialize<ParameterMetricsModel>(paramString);

            _DataSet = new DataSet();
            _ParameterMetricsModel.ParameterMetricsSelect(); // call to model's function
            _DataSet = _ParameterMetricsModel.ResultDataSet;
            return _DataSet.ToList();
        }

        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            _ParameterMetricsModel = new ParameterMetricsModel();

            JObject job = JObject.Parse(jsonData);
            _ParameterMetricsModel.ParameterMetricsJson = Convert.ToString(job["ParameterMetricsJson"].ToString());
            _ParameterMetricsModel._MenuID = Convert.ToInt32(job["_MenuID"].ToString());
            _ParameterMetricsModel._Remark = Convert.ToString(job["_Remark"].ToString());
            _ParameterMetricsModel._BranchCode = Convert.ToString(job["_BranchCode"].ToString());
            _ParameterMetricsModel._dateCreatedmodified = Convert.ToDateTime(job["_dateCreatedmodified"].ToString());
            _ParameterMetricsModel._CreatetedModifiedBy = Convert.ToString(job["_CreatetedModifiedBy"].ToString());
            _ParameterMetricsModel._OperationFlag = Convert.ToInt32(job["_OperationFlag"].ToString());
            _ParameterMetricsModel._AuthMode = Convert.ToString(job["_AuthMode"].ToString());
            _ParameterMetricsModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _ParameterMetricsModel._EffectiveFromTimeKey = Convert.ToInt32(job["_EffectiveFromTimeKey"].ToString());
            _ParameterMetricsModel._EffectiveToTimeKey = Convert.ToInt32(job["_EffectiveToTimeKey"].ToString());
            rval = _ParameterMetricsModel.ParameterMetricsInsertUpdate();  // call to model's function
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