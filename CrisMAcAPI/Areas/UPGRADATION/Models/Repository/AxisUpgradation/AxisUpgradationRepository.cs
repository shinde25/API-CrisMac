﻿using CrisMAcAPI.Areas.CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.UPGRADATION.Models.Repository
{
    public class AxisUpgradationRepository : IAxisUpgradationRepository
    {
        AxisUpgradationModel _AxisUpgradationModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;


        //------TldlRepaySchSelectRepo----
        public List<object> TldlRepaySchSelectRepo(string ParaStr)
        {
            _AxisUpgradationModel = new AxisUpgradationModel();
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(ParaStr);

            _DataSet = new DataSet();
            //_AxisUpgradationModel.TldlRepaySchSelect();
            //_DataSet = _AxisUpgradationModel.ResultDataSet;

            _DataSet= _AxisUpgradationModel.TldlRepaySchSelect();


            return _DataSet.ToList();
        }


        //------BillDetailSelectRepo----
        public List<object> BillDetailSelectRepo(string ParaStr)
        {
            _AxisUpgradationModel = new AxisUpgradationModel();
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(ParaStr);

            _DataSet = new DataSet();
            //_AxisUpgradationModel.BillDetailSelect();
            //_DataSet = _AxisUpgradationModel.ResultDataSet;
            _DataSet = _AxisUpgradationModel.BillDetailSelect();

            return _DataSet.ToList();
        }

        //------CcodDetailSelectRepo----
        public List<object> CcodDetailSelectRepo(string ParaStr)
        {
            _AxisUpgradationModel = new AxisUpgradationModel();
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(ParaStr);

            _DataSet = new DataSet();
            //_AxisUpgradationModel.CcodDetailSelect();
            //_DataSet = _AxisUpgradationModel.ResultDataSet;

            _DataSet = _AxisUpgradationModel.CcodDetailSelect();

            return _DataSet.ToList();
        }


        //------Parameter Select Repo----
        public List<object> UpgradationParameterSelectRepo(string ParaStr)
        {
            _AxisUpgradationModel = new AxisUpgradationModel();
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(ParaStr);

            _DataSet = new DataSet();
            //_AxisUpgradationModel.UpgradationParameterSelect();
            //_DataSet = _AxisUpgradationModel.ResultDataSet;

            _DataSet = _AxisUpgradationModel.UpgradationParameterSelect();

            return _DataSet.ToList();
        }

        //------Parameter Insert Repo----
        public object UpgradationParameterInsertUpdateRepo(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(jsonData);
            rval = _AxisUpgradationModel.UpgradationParameterInsertUpdate();
            return rval;
        }

        public List<object> MarkUpgradationcycleSelectRepo(string ParaStr)
        {
            _AxisUpgradationModel = new AxisUpgradationModel();
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(ParaStr);

            _DataSet = new DataSet();
            //_AxisUpgradationModel.MarkUpgradationcycleSelect();
            //_DataSet = _AxisUpgradationModel.ResultDataSet;

            _DataSet = _AxisUpgradationModel.MarkUpgradationcycleSelect();

            return _DataSet.ToList();


        }
        public object MarkInsertUpdateData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(jsonData);
            rval = _AxisUpgradationModel.MarkUpgradationcycleInsertUpdate();
            return rval;
        }

        #region Updrade Approval Auth
        public List<object> UpgradeAuthSelect(string ParaStr)
        {
            _AxisUpgradationModel = new AxisUpgradationModel();
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(ParaStr);

            _DataSet = new DataSet();
            //_AxisUpgradationModel.UpgradeAuth_Select();
            //_DataSet = _AxisUpgradationModel.ResultDataSet;

            _DataSet = _AxisUpgradationModel.UpgradeAuth_Select();

            return _DataSet.ToList();
        }
        public object UpgradeAuthInsertUpdate(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _AxisUpgradationModel = serializer.Deserialize<AxisUpgradationModel>(jsonData);
            rval = _AxisUpgradationModel.UpgradeAuth_InsertUpdate();
            return rval;
        }
        #endregion Updrade Approval Auth
    }
}
