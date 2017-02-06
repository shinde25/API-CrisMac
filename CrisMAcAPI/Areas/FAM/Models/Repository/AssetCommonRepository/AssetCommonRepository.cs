using CrisMAcAPI.Areas.CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.AssetCommonRepository
{
    public class AssetCommonRepository : IAssetCommonRepository

    {

        AssetCommonModel _AssetCommonModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        public List<object> FetchData(string paramString)
        {
            _AssetCommonModel = new AssetCommonModel();
            serializer = new JavaScriptSerializer();
            _AssetCommonModel = serializer.Deserialize<AssetCommonModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _AssetCommonModel.AssetBlockSelect();
            return _DataSet.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            _AssetCommonModel = new AssetCommonModel();
            serializer = new JavaScriptSerializer();
           
            _AssetCommonModel = serializer.Deserialize<AssetCommonModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _AssetCommonModel.AssetCommonAuxFetch();
             return _DataSet.ToList();
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public object InsertUpdateDataAssetBlock(string jsonData)
        {
            try
            {
                _AssetCommonModel = new AssetCommonModel();
                object rval = null;
                serializer = new JavaScriptSerializer();
                _AssetCommonModel = serializer.Deserialize<AssetCommonModel>(jsonData);
                rval = _AssetCommonModel.AssetBlockInsertUpdate();
                return rval;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public int InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }

        

        public List<object> SubBlockFetchData(string paramString)
        {
            _AssetCommonModel = new AssetCommonModel();
            serializer = new JavaScriptSerializer();
            _AssetCommonModel = serializer.Deserialize<AssetCommonModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _AssetCommonModel.AssetSubBlockSelect();
            return _DataSet.ToList();
        }

        public object InsertUpdateDataSubAssetBlock(string jsonData)
        {
            try
            {
                _AssetCommonModel = new AssetCommonModel();
                object rval = null;
                serializer = new JavaScriptSerializer();
                _AssetCommonModel = serializer.Deserialize<AssetCommonModel>(jsonData);
                rval = _AssetCommonModel.AssetSubBlockInsertUpdate();
                return rval;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}