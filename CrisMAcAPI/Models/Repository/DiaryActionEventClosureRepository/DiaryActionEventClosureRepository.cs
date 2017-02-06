﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.DiaryActionEventClosureRepository
{
    public class DiaryActionEventClosureRepository : IDiaryActionEventClosureRepository
    {
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        DiaryActionEventClosureModel _DiaryActionEventClosureModel;

        //---------- select Repo
        public List<object> FetchData(string paramString) //--select
        {
            _DiaryActionEventClosureModel = new DiaryActionEventClosureModel();
            serializer = new JavaScriptSerializer();
            _DiaryActionEventClosureModel = serializer.Deserialize<DiaryActionEventClosureModel>(paramString);

            _DataSet = new DataSet();
            _DiaryActionEventClosureModel.DiaryActionEventClosureSelect(); 
            _DataSet = _DiaryActionEventClosureModel.ResultDataSet;

            return _DataSet.ToList();
        }

        //---------- Aux Repo
        public List<object> GetAuxdata(string paramString)
        {
            _DiaryActionEventClosureModel = new DiaryActionEventClosureModel();
            serializer = new JavaScriptSerializer();
            _DiaryActionEventClosureModel = serializer.Deserialize<DiaryActionEventClosureModel>(paramString);

            _DataSet = new DataSet();
            _DiaryActionEventClosureModel.DiaryActionEventClosureAuxSelect();
            _DataSet = _DiaryActionEventClosureModel.ResultDataSet;

            return _DataSet.ToList();
        }


        //---------- Meta Repo
        public List<object> GetMetaData(string ParaStr)
        {
            _DiaryActionEventClosureModel = new DiaryActionEventClosureModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _DiaryActionEventClosureModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());

            _DataSet = new DataSet();
            _DiaryActionEventClosureModel.DiaryActionEventClosureParameterised();
            _DataSet = _DiaryActionEventClosureModel.ResultDataSet;

            return _DataSet.ToList();
        }

        //---------- insert Repo
        public object InsertUpdateData(string jsonData)
        {
            try
            {
                object rval = null;
                serializer = new JavaScriptSerializer();
                _DiaryActionEventClosureModel = serializer.Deserialize<DiaryActionEventClosureModel>(jsonData);
                rval = _DiaryActionEventClosureModel.DiaryActionEventClosureInsertUpdate();
                return rval;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }

        public List<object> GetEmailSMSData(string ParaStr)
        {
            _DiaryActionEventClosureModel = new DiaryActionEventClosureModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _DiaryActionEventClosureModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _DiaryActionEventClosureModel.RemarkId = Convert.ToInt32(job["RemarkId"].ToString());
            _DiaryActionEventClosureModel.EventType = Convert.ToString(job["EventType"]);
            _DiaryActionEventClosureModel.AlertType = Convert.ToString(job["AlertType"]);

            _DataSet = new DataSet();
            _DiaryActionEventClosureModel.GetEmailData();
            _DataSet = _DiaryActionEventClosureModel.ResultDataSet;

            return _DataSet.ToList();
        }
    }
}