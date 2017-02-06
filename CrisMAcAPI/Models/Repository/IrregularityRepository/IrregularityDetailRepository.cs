using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.IrregularityRepository
{
    public class IrregularityDetailRepository : IIrregularityDetailRepository
    {
        IrregularityDetailModel _IrregularityModel;
        JavaScriptSerializer serializer;
        DataSet _DataSet;
        public List<object>GetAuxdata(string paramString)
        {
            _IrregularityModel = new IrregularityDetailModel();
            serializer = new JavaScriptSerializer();
            _IrregularityModel = serializer.Deserialize<IrregularityDetailModel>(paramString);

            _DataSet = new DataSet();
            _IrregularityModel.IrregularityAuxSelect();
            _DataSet = _IrregularityModel.ResultDataSet;
             return _DataSet.ToList();
        }

        public List<object> FetchData(string paramString)
        {
            _IrregularityModel = new IrregularityDetailModel();
            serializer = new JavaScriptSerializer();
            _IrregularityModel = serializer.Deserialize<IrregularityDetailModel>(paramString);

            _DataSet = new DataSet();
            _IrregularityModel.IrregularitySelect();
            _DataSet = _IrregularityModel.ResultDataSet;

            return _DataSet.ToList();
        }
        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _IrregularityModel = serializer.Deserialize<IrregularityDetailModel>(jsonData);
            rval = _IrregularityModel.IrregularityInsertUpdate();
            return rval;
        }
    }
}