using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.D2k_Inventory.Models.Repository.AppMasterRepository
{
    public class AppInventoryRepository:IAppInventoryRepository
    {
        AppInventoryModel _MasterModel = new AppInventoryModel();

        public DataSet AppMasterInventoryDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _MasterModel.UserLoginID = JData["UserLoginId"].ToString();

            _MasterModel.Select_MasterDetails();
            DataSet LoginDetails = _MasterModel.ResultDataSet;

            
            LoginDetails = LoginDetails.GetTableName();

            return LoginDetails;
        }

        public DataSet AppSearchInventoryDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _MasterModel.SearchData = JData["SearchData"].ToString();
            _MasterModel.UserLoginID = JData["UserLoginId"].ToString();

            _MasterModel.Search_InventoryDetails();
            DataSet LoginDetails = _MasterModel.ResultDataSet;


            LoginDetails = LoginDetails.GetTableName();

            return LoginDetails;
        }

        public DataSet AppSelectInventoryDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _MasterModel.InventoryId = Convert.ToInt32(JData["InventoryId"].ToString());
          //  _MasterModel.SearchData = JData["SearchData"].ToString();
            _MasterModel.Select_InventoryDetails();
            DataSet LoginDetails = _MasterModel.ResultDataSet;


            LoginDetails = LoginDetails.GetTableName();

            return LoginDetails;
        }

        public object InsertInventoryDetails(string jsonData)
        {
            object InsertObj = null;
           
            JObject job = JObject.Parse(jsonData);
            _MasterModel.UserLoginID = Convert.ToString(job["UserLoginID"].ToString());
            _MasterModel.ClientAlt_Key = Convert.ToInt32(job["ClientAlt_Key"].ToString());
            _MasterModel.ProjectAlt_Key = Convert.ToInt32(job["ProjectAlt_Key"].ToString());
            _MasterModel.WorkTypeAlt_Key = Convert.ToInt32(job["WorkTypeAlt_Key"].ToString());
            _MasterModel.WorkDescription = Convert.ToString(job["WorkDescription"].ToString());
            _MasterModel.OriginatorOfWork = Convert.ToString(job["OriginatorOfWork"].ToString());
            _MasterModel.Attachments = Convert.ToString(job["Attachements"].ToString());
            InsertObj = _MasterModel.Insert_InventoryDetails();  // call to model's function
            return InsertObj;
        }

        public object UpdateInventoryDetails(string jsonData)
        {
            object InsertObj = null;

            JObject job = JObject.Parse(jsonData);
            _MasterModel.UserLoginID = Convert.ToString(job["UserLoginID"].ToString());
            _MasterModel.InventoryId = Convert.ToInt32(job["InventoryID"].ToString());
            _MasterModel.WorkTypeAlt_Key = Convert.ToInt32(job["WorkTypeAlt_Key"].ToString());
            _MasterModel.WorkCommencementDate = Convert.ToString(job["WorkCommencementDate"].ToString());
            _MasterModel.ParticipantsName = Convert.ToString(job["ParticipantsName"].ToString());
            _MasterModel.WorkClosureDate = Convert.ToString(job["WorkClosureDate"].ToString());
            _MasterModel.ManDaysUtilised = Convert.ToInt32(job["ManDaysUtilised"].ToString());
            InsertObj = _MasterModel.EditDelete_InventoryDetails();  // call to model's function
            return InsertObj;
        }
    }
}