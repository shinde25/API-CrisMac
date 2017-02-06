﻿using CrisMAcAPI.Areas.CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.BranchCreationRepository
{
    public class BranchCreationRepository : IBranchCreationRepository
    {


        BranchCreationModel _BranchCreationModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;


        //---------------
        //Aux Branch data
        public List<object> GetAuxdata(string paramString)
        {
            _BranchCreationModel = new BranchCreationModel();
            serializer = new JavaScriptSerializer();

            _BranchCreationModel = serializer.Deserialize<BranchCreationModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _BranchCreationModel.BranchAuxData();
            return _DataSet.ToList();
        }

        //-----------------
        //Select/Fetch Data
        public List<object> FetchBranchData(string paramString)
        {
            _BranchCreationModel = new BranchCreationModel();
            serializer = new JavaScriptSerializer();

            _BranchCreationModel = serializer.Deserialize<BranchCreationModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _BranchCreationModel.FetchBranchDetails();
            return _DataSet.ToList();
        }

        //---------------------------
        //Insert Update Branch Data
        public object InsertUpdateBranchData(string jsonData)
        {
            _BranchCreationModel = new BranchCreationModel();
            object obj = null;
            serializer = new JavaScriptSerializer();
            _BranchCreationModel = serializer.Deserialize<BranchCreationModel>(jsonData);
            obj = _BranchCreationModel.BranchInsertUpdateData();
            return obj;
        }
        //SolId Assign  data
        public List<object> GetSolIddata(string paramString)
        {
            _BranchCreationModel = new BranchCreationModel();
            serializer = new JavaScriptSerializer();

            _BranchCreationModel = serializer.Deserialize<BranchCreationModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _BranchCreationModel.SolidAuxData();
            return _DataSet.ToList();
        }

        public List<object> AuxBranchData()
        {
            throw new NotImplementedException();
        }

        public List<object> FetchData(string paramString)
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