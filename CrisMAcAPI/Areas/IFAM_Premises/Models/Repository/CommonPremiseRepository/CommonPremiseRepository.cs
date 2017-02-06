﻿using CrisMAcAPI.Areas.CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.IFAM_Premises.Models.Repository.CommonPremiseRepository
{
    public class CommonPremiseRepository : ICommonPremiseRepository
    {
        CommonPremiseModel _Model;
        PremiseTransactionMainModel /*_PUModel,*/ _PTMainModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        //public List<object> GetAssetBlockandSubBlockData(string ParaStr)
        //{
        //    _Model = new CommonPremiseModel();
        //    serializer = new JavaScriptSerializer();
        //    _Model = serializer.Deserialize<CommonPremiseModel>(ParaStr);
        //    _DataSet = new DataSet();
        //    _DataSet = _Model.PremisePurchaseAssetBlockSubBlockParmatrised();
        //    return _DataSet.ToList();
        //}

        ////-----------FetchData(para)
        public List<object> FetchData(string paramString)
        {
            _Model = new CommonPremiseModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonPremiseModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.CommonNewAssetSelect();
            return _DataSet.ToList();
        }

        //-------------InsertUpdateData(para)
        public object InsertUpdateData(string jsonData)
        {
            _Model = new CommonPremiseModel();
            object rval = null;
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonPremiseModel>(jsonData);
            rval = _Model.CommonNewAssetInsertUpdate();
            return rval;
        }

        public List<object> FetchDataTxn(string paramString)
        {
            _Model = new CommonPremiseModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonPremiseModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.CommonTxnSelect();
            return _DataSet.ToList();
        }

        public object InsertUpdateDataTxn(string jsonData)
        {
            _Model = new CommonPremiseModel();
            object rval = null;
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonPremiseModel>(jsonData);
            rval = _Model.CommonTxnInsertUpdate();
            return rval;
        }

        public List<object> CBSTxnSystem_Validation(string paramString)
        {
            _Model = new CommonPremiseModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonPremiseModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _Model.CBSTxn_System();
            return _DataSet.ToList();
        }

        public List<object> FetchTranHistoryData(string paramString)
        {
            _Model = new CommonPremiseModel();
            serializer = new JavaScriptSerializer();
            _Model = serializer.Deserialize<CommonPremiseModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _Model.TransactionHistory();
            return _DataSet.ToList();
        }
        //public List<object> PremiseDisplayGridDataFetch(string paramString)
        //{
        //    _PTMainModel = new PremiseTransactionMainModel();
        //    serializer = new JavaScriptSerializer();
        //    _PTMainModel = serializer.Deserialize<PremiseTransactionMainModel>(paramString);
        //    _DataSet = new DataSet();
        //    if (_PTMainModel.ScreenType == "Txn")
        //    {
        //        _DataSet = _PTMainModel.PremiseTransactionMainSelect(); // call to model's function            
        //    }
        //    else
        //    {
        //        _DataSet = _PTMainModel.PremiseTransactionEnquirySelect(); // call to model's function            
        //    }
        //    //_DataSet = _ATMainModel.AssetTransactionMainSelect(); // call to model's function            
        //    return _DataSet.ToList();
        //}

    }
}
