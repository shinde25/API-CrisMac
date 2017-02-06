using CrisMAcAPI.Areas.CommonComponent.Models;

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.ReplicationRepository
{
    class CommonNewAssetRepository : ICommonNewAssetRepository
    {
        CommonNewCreateAssetModel _Model ;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        //-----------FetchData(para)
        public List<object> FetchData(string paramString)
        {
            _Model = new CommonNewCreateAssetModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.CommonNewAssetSelect();
            return _DataSet.ToList();
        }

        //-------------InsertUpdateData(para)
        public object InsertUpdateData(string jsonData)
        {
            _Model = new CommonNewCreateAssetModel();
            object rval = null;
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(jsonData);
            rval = _Model.CommonNewAssetInsertUpdate();
            return rval;
        }

        public List<object> FetchDataTxn(string paramString)
        {
            _Model = new CommonNewCreateAssetModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.CommonTxnSelect();
            return _DataSet.ToList();
        }

        public object InsertUpdateDataTxn(string jsonData)
        {
            _Model = new CommonNewCreateAssetModel();
            object rval = null;
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(jsonData);
            rval = _Model.CommonTxnInsertUpdate();
            return rval;
        }

        public List<object> CBSTxnSystem_Validation(string paramString)
        {
            _Model = new CommonNewCreateAssetModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.CBSTxn_System();
            return _DataSet.ToList();
        }

        public List<object> FetchTranHistoryData(string paramString)
        {
            _Model = new CommonNewCreateAssetModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _Model.TansactionHistory();
            return _DataSet.ToList();
        }

        public List<object> FetchInitiFreez(string paramString)
        {
            _Model = new CommonNewCreateAssetModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _Model.FetchInitiFreezSelect();
            return _DataSet.ToList();
        }

        public object InsertUpdateIntiFreezing(string jsonData)
        {
            _Model = new CommonNewCreateAssetModel();
            object rval = null;
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonNewCreateAssetModel>(jsonData);
            rval = _Model.InsertUpdateIntiFreezingModel();
            return rval;
        }
    }
}
