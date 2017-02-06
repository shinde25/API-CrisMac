﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.Script.Serialization;
using CrisMAcAPI.Areas.CommonComponent.Models;
using CrisMAcAPI.Models.Repository.CommonInterface;
using Newtonsoft.Json.Linq;

namespace CrisMAcAPI.Areas.Alert.Models.Repository.ProspectMiscInfo
{
    public class ProspectMiscInfoRepository : IProspectMiscInfoRepository
    {
        ProspectMiscInfoModel ProspectMiscInfoObj;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        public List<object> FetchData(string paramString)
        {
            ProspectMiscInfoObj = new ProspectMiscInfoModel();
            //serializer = new JavaScriptSerializer();
            //ProspectMiscInfoObj = serializer.Deserialize<BulkSupervisorCustomerAllocationModel>(paramString);
            string[] ObjArr = paramString.Split(',');
            ProspectMiscInfoObj.UserId = Convert.ToString(ObjArr[0]);
            ProspectMiscInfoObj.ZoneCode = Convert.ToString(ObjArr[1]);
            ProspectMiscInfoObj.RegionCode = Convert.ToString(ObjArr[2]);
            ProspectMiscInfoObj.AllocatedValue = Convert.ToString(ObjArr[3]);
            ProspectMiscInfoObj.AllocationCriteria = Convert.ToInt32(ObjArr[4]);
            ProspectMiscInfoObj.ExposureRange = Convert.ToInt32(ObjArr[5]);
            ProspectMiscInfoObj.RangeValue1 = Convert.ToInt32(ObjArr[6]);
            ProspectMiscInfoObj.RangeValue2 = Convert.ToInt32(ObjArr[7]);
            ProspectMiscInfoObj.BranchCode = Convert.ToString(ObjArr[8]);
            ProspectMiscInfoObj._userLoginId = Convert.ToString(ObjArr[9]);
            ProspectMiscInfoObj._TimeKey = Convert.ToInt32(ObjArr[10]);
            ProspectMiscInfoObj._OperationMode = Convert.ToInt32(ObjArr[11]);
            ProspectMiscInfoObj.EmployeeRole = Convert.ToInt32(ObjArr[12]);
            _DataSet = new DataSet();
            ProspectMiscInfoObj.ProspectMiscInfoSelect();
            _DataSet = ProspectMiscInfoObj.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            ProspectMiscInfoObj = new ProspectMiscInfoModel();
            serializer = new JavaScriptSerializer();
            ProspectMiscInfoObj = serializer.Deserialize<ProspectMiscInfoModel>(paramString);

            _DataSet = new DataSet();
            ProspectMiscInfoObj.ProspectMiscInfoAuxSelect();
            _DataSet = ProspectMiscInfoObj.ResultDataSet;

            return _DataSet.ToList();
        }

        //-------------GetMetaData()
        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }
        //-------------InsertUpdateData(para)
        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            ProspectMiscInfoObj = serializer.Deserialize<ProspectMiscInfoModel>(jsonData);
            rval = ProspectMiscInfoObj.BulkSupervisorCustomerAllocationInsertUpdate();
            return rval;
        }

        //-------------InsertUpdateData(para)
        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }

        //--------------GetMeataData(para)
        public List<object> GetMetaData(string ParaStr)
        {
            ProspectMiscInfoObj = new ProspectMiscInfoModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            ProspectMiscInfoObj._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            ProspectMiscInfoObj._OperationMode = Convert.ToInt32(job["_OperationMode"].ToString());
            _DataSet = new DataSet();
            ProspectMiscInfoObj.ProspectMiscInfoParameterisedMasterData();
            _DataSet = ProspectMiscInfoObj.ResultDataSet;

            return _DataSet.ToList();
        }

    }
}
