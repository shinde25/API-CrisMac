using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.SolutionParameterRepository
{
    public class SolutionParameterRepository : ISolutionParameterRepository
    {
        SolutionParameterModel _model;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        public List<object> GetAuxdata(string paramString)
        {
            _model = new SolutionParameterModel();
            serializer = new JavaScriptSerializer();
            _model = serializer.Deserialize<SolutionParameterModel>(paramString);

            _DataSet = new DataSet();
            _model.SolutionParameterAuxSelect();
            _DataSet = _model.ResultDataSet;

            return _DataSet.ToList();
        }

        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _model = serializer.Deserialize<SolutionParameterModel>(jsonData);
            rval = _model.SolutionParameterInsertUpdate();
            return rval;
        }

    }
}