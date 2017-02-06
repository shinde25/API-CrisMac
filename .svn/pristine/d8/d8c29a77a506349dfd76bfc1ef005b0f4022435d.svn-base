using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Areas.CommonComponent.Models;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.AssetTransactionMainRepository
{
    public class AssetTransactionMainRepository : IAssetTransactionMainRepository
    {
        AssetTransactionMainModel _ATMainModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public List<object> GetMetaData(string ParaStr)
        {
            _ATMainModel = new AssetTransactionMainModel();
            serializer = new JavaScriptSerializer();
            //JObject job = JObject.Parse(ParaStr);
            //_ATMainModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _ATMainModel = serializer.Deserialize<AssetTransactionMainModel>(ParaStr);
            _DataSet = new DataSet();
            _DataSet=_ATMainModel.AssetTransactionMainParmatrised();   
           // _DataSet = _ATMainModel.ResultDataSet;

            return _DataSet.ToList();
            
        }

        public List<object> FetchData(string paramString)
        {
            _ATMainModel = new AssetTransactionMainModel();
            serializer = new JavaScriptSerializer();
            _ATMainModel = serializer.Deserialize<AssetTransactionMainModel>(paramString);
            _DataSet = new DataSet();
            if (_ATMainModel.ScreenType == "Txn")
            {
                _DataSet = _ATMainModel.AssetTransactionMainSelect(); // call to model's function            
            }
            else
            {
                _DataSet = _ATMainModel.AssetTransactionEnquirySelect(); // call to model's function            
            }
            //_DataSet = _ATMainModel.AssetTransactionMainSelect(); // call to model's function            
            return _DataSet.ToList();
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }       

        public List<object> GetAuxdata(string paramString)
        {
            throw new NotImplementedException();
        }       

        
        public int InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}