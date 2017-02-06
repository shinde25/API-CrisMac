using CrisMAcAPI.Areas.CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.IFAM_Premises.Models.Repository.PremiseTransactionMainRepository
{
    public class PremiseTransactionMainRepository: IPremiseTransactionMainRepository
    {
        PremiseTransactionMainModel _PTMainModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public List<object> GetMetaData(string ParaStr)
        {
            _PTMainModel = new PremiseTransactionMainModel();
            serializer = new JavaScriptSerializer();
            //JObject job = JObject.Parse(ParaStr);
            //_ATMainModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _PTMainModel = serializer.Deserialize<PremiseTransactionMainModel>(ParaStr);
            _DataSet = new DataSet();
            _DataSet = _PTMainModel.PremiseTransactionMainParameterised();
            // _DataSet = _ATMainModel.ResultDataSet;

            return _DataSet.ToList();

        }

        public List<object> FetchData(string paramString)
        {
            _PTMainModel = new PremiseTransactionMainModel();
            serializer = new JavaScriptSerializer();
            _PTMainModel = serializer.Deserialize<PremiseTransactionMainModel>(paramString);
            _DataSet = new DataSet();
            if (_PTMainModel.ScreenType == "Txn")
            {
                _DataSet = _PTMainModel.PremiseTransactionMainSelect(); // call to model's function            
            }
            else
            {
                _DataSet = _PTMainModel.PremiseTransactionEnquirySelect(); // call to model's function            
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