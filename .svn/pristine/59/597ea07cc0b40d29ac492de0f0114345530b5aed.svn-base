using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.Krishak.Models.Repository.BranchSelectionReository
{
    public class BranchRepositories : IBranchRepositories
    {
        BranchSelectionModel _model;
        JavaScriptSerializer serializer;
        DataSet _DataSet;

        public List<object> FetchData(string paramData)
        {
            _model = new BranchSelectionModel();
            serializer = new JavaScriptSerializer();
            _model = serializer.Deserialize<BranchSelectionModel>(paramData);
            _DataSet = new DataSet();
            _model.Select_SysBRZDataSelect();

            _DataSet = _model.ResultDataSet;
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
        public int InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }
        //public List<object> FetchDefaultBranch(string paramData);
    }
}