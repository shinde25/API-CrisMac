using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.SegmentMatrixRepository
{
    public class SegmentMatrixRepository : ISegmentMatrixRepository
    {
        SegmentMatrixModel _SegmentMatrixModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public List<object> GetMetaData(string ParaStr)
        {
            _SegmentMatrixModel = new SegmentMatrixModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _SegmentMatrixModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());

            _DataSet = new DataSet();
            _SegmentMatrixModel.SegmentMatrixParmatrised();  // call to model's function
            _DataSet = _SegmentMatrixModel.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            _SegmentMatrixModel = new SegmentMatrixModel();
            _SegmentMatrixModel = serializer.Deserialize<SegmentMatrixModel>(paramString);
            _SegmentMatrixModel.SegmentMatrixAuxSelect();       // call to model's function
            DataSet __SegmentMatrixAuxDS = _SegmentMatrixModel.ResultDataSet;
            return __SegmentMatrixAuxDS.ToList();
        }

        public List<object> FetchData(string paramString)
        {
            _SegmentMatrixModel = new SegmentMatrixModel();
            serializer = new JavaScriptSerializer();
            _SegmentMatrixModel = serializer.Deserialize<SegmentMatrixModel>(paramString);

            _DataSet = new DataSet();
            _SegmentMatrixModel.SegmentMatrixSelect(); // call to model's function
            _DataSet = _SegmentMatrixModel.ResultDataSet;
            return _DataSet.ToList();
        }

        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            _SegmentMatrixModel = new SegmentMatrixModel();

            JObject job = JObject.Parse(jsonData);
            _SegmentMatrixModel.SegmentMatrixJson = Convert.ToString(job["SegmentMatrixJson"].ToString());
            _SegmentMatrixModel._MenuID = Convert.ToInt32(job["_MenuID"].ToString());
            _SegmentMatrixModel._Remark = Convert.ToString(job["_Remark"].ToString());
            _SegmentMatrixModel._BranchCode = Convert.ToString(job["_BranchCode"].ToString());
            _SegmentMatrixModel._dateCreatedmodified = Convert.ToDateTime(job["_dateCreatedmodified"].ToString());
            _SegmentMatrixModel._CreatetedModifiedBy = Convert.ToString(job["_CreatetedModifiedBy"].ToString());
            _SegmentMatrixModel._OperationFlag = Convert.ToInt32(job["_OperationFlag"].ToString());
            _SegmentMatrixModel._AuthMode = Convert.ToString(job["_AuthMode"].ToString());
            _SegmentMatrixModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _SegmentMatrixModel._EffectiveFromTimeKey = Convert.ToInt32(job["_EffectiveFromTimeKey"].ToString());
            _SegmentMatrixModel._EffectiveToTimeKey = Convert.ToInt32(job["_EffectiveToTimeKey"].ToString());
            rval = _SegmentMatrixModel.SegmentMatrixInsertUpdate();  // call to model's function
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