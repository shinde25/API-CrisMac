using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.RemarkAggregator
{
    public class RemarkAggregatorRepository : IRemarkAggregatorRepository
    {
        RemarkAggregatorModel _RemarkAggregatorModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public List<object> FetchData(string paramString)
        {
            _RemarkAggregatorModel = new RemarkAggregatorModel();
            serializer = new JavaScriptSerializer();
            _RemarkAggregatorModel = serializer.Deserialize<RemarkAggregatorModel>(paramString);

            _DataSet = new DataSet();
            _RemarkAggregatorModel.RemarkAggregatorSelect();
            _DataSet = _RemarkAggregatorModel.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            throw new NotImplementedException();
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _RemarkAggregatorModel = serializer.Deserialize<RemarkAggregatorModel>(jsonData);
            rval = _RemarkAggregatorModel.RemarkAggregatorInsertUpdate();
            return rval;
        }

        public List<object> GetMetaData(string ParaStr)
        {
            _RemarkAggregatorModel = new RemarkAggregatorModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _RemarkAggregatorModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());

            _DataSet = new DataSet();
            _RemarkAggregatorModel.RemarkAggregatorParmatrised();
            _DataSet = _RemarkAggregatorModel.ResultDataSet;

            return _DataSet.ToList();
        }

        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}
