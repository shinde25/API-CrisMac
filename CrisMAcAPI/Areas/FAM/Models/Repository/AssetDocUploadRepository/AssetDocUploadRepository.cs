using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Data;
using CrisMAcAPI.Models;
using CrisMAcAPI.Areas.FAM.Models;
using CrisMAcAPI.Areas.FAM.Models.Repository;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.AssetDocUploadRepository
{
    class AssetDocUploadRepository : IAssetDocUploadRepository
    {
        AssetDocUploadModel _Model;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        //-----------FetchData from Aux(para)
        public List<object> GetMetaDataForDocumentUpload(string paramString)
        {
            _Model = new AssetDocUploadModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<AssetDocUploadModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.AssetDocDetailParameterisedMasterData();
            return _DataSet.ToList();

        }

        public List<object> FetchData(string paramString)
        {
            _Model = new AssetDocUploadModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<AssetDocUploadModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.AssetDocDetailSelect();
            return _DataSet.ToList();
        }       

        public object SaveDocumentUploadMain(string jsonData)
        {
            try
            {
                _Model = new AssetDocUploadModel();
                object rval = null;
                serializer = new JavaScriptSerializer();
                _Model = serializer.Deserialize<AssetDocUploadModel>(jsonData);
                rval = _Model.SaveDocumentUploadMain();
                return rval;
            }
            catch (Exception e)
            {

                throw e;
            }
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
    }
}




