using CrisMAcAPI.Areas.CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


namespace CrisMAcAPI.Areas.FAM.Models.Repository.BranchMergeRepository
{
    public class BranchMergeRepository : IBranchMergeRepository
    {
        BranchMergeModel _BranchMergeModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;


        public List<object> FetchBranchData(string paramString)
        {
            _BranchMergeModel = new BranchMergeModel();
            serializer = new JavaScriptSerializer();

            _BranchMergeModel = serializer.Deserialize<BranchMergeModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _BranchMergeModel.FetchBranchDetails();
            return _DataSet.ToList();
        }


        public List<object> FetchBranchClose(string paramString)
        {
            _BranchMergeModel = new BranchMergeModel();
            serializer = new JavaScriptSerializer();

            _BranchMergeModel = serializer.Deserialize<BranchMergeModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _BranchMergeModel.FetchBranchClose();
            return _DataSet.ToList();
        }

        public object InsertUpdateBranchMerge(string jsonData)
        {
            _BranchMergeModel = new BranchMergeModel();
            object obj = null;
            serializer = new JavaScriptSerializer();
            _BranchMergeModel = serializer.Deserialize<BranchMergeModel>(jsonData);
            obj = _BranchMergeModel.BranchMergeInsertUpdateData();
            return obj;
        }

        public List<object> GetAuxdata(string paramString)
        {
            throw new NotImplementedException();
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public List<object> FetchData(string paramString)
        {
            throw new NotImplementedException();
        }

        public int InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}