using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.UserCreationRepository
{
    public class UserCreationRepository : IUserCreationRepository
    {
        UserCreationModel objUserMaintanance = new UserCreationModel();

        public List<object> FetchData(string paramdata)
        {
            JObject jobj = JObject.Parse(paramdata);
            objUserMaintanance._userLoginId = jobj["userLoginId"].ToString();
            objUserMaintanance._TimeKey = Convert.ToInt32(jobj["TimeKey"].ToString());
           // objUserMaintanance._UtilFlag = jobj["UtilFlag"].ToString();
            objUserMaintanance.UserCreationParameterisedMasterData();
            DataSet ds = objUserMaintanance.ResultDataSet;
            var locationData = ds.Tables[0].AsEnumerable().Select(x => new
            {
                UserLocationAlt_Key = x.Field<Int16>("UserLocationAlt_Key"),
                LocationShortName = x.Field<string>("LocationShortName"),
                LocationDescription = x.Field<string>("LocationDescription")
            }).ToList();
            var branchaInfo = ds.Tables[1].AsEnumerable().Select(x => new
            {
                Branch_Key = x.Field<Int16?>("Branch_Key"),
                LocationCode = x.Field<string>("BranchCode"),
                LocationName = x.Field<string>("BranchName"),
                BranchZoneAlt_Key = x.Field<Int16?>("BranchZoneAlt_Key")
            }).ToList();
            var regionInfo = ds.Tables[2].AsEnumerable().Select(x => new
            {
                LocationCode = x.Field<string>("RegionAlt_Key"),
                LocationName = x.Field<string>("RegionName")
            }).ToList();
            var zoneName = ds.Tables[3].AsEnumerable().Select(x => new
            {
                LocationCode = x.Field<string>("ZoneAlt_Key"),
                LocationName = x.Field<string>("ZoneName")
            }).ToList();
            var branchName = ds.Tables[4].AsEnumerable().Select(x => new
            {
                LocationCode = x.Field<string>("BranchType"),
                LocationName = x.Field<string>("BranchName")

            }).ToList();
            var roleData = ds.Tables[5].AsEnumerable().Select(x => new
            {
                UserRoleAlt_Key = x.Field<Int16?>("UserRoleAlt_Key"),
                RoleDescription = x.Field<string>("RoleDescription")
            }).ToList();
            var objMetaData = ds.Tables[6].AsEnumerable().Select(x => new
            {
                FrmName = x.Field<string>("FrmName"),
                CODE = x.Field<int>("CODE"),
                CtrlName = x.Field<string>("CtrlName"),
                FldName = x.Field<string>("FldName"),
                FldCaption = x.Field<string>("FldCaption"),
                FldLength = x.Field<string>("FldLength"),
                FldGrdWidth = x.Field<string>("FldGrdWidth"),
                FldSearch = x.Field<string>("FldSearch"),
                FldDataType = x.Field<string>("FldDataType"),
                ErrorCheck = x.Field<string>("ErrorCheck"),
                DataSeq = x.Field<Int16?>("DataSeq"),
                FldGridView = x.Field<string>("FldGridView"),
                CriticalErrorType = x.Field<string>("CriticalErrorType"),
                MsgFlag = x.Field<string>("MsgFlag"),
                MsgDescription = x.Field<string>("MsgDescription"),
                RptCaption = x.Field<string>("RptCaption")
            }).ToList();
            var objMasterData = ds.Tables[7].AsEnumerable().Select(x => new
            {
                SeqNo = x.Field<Int16?>("SeqNo"),
                ParameterType = x.Field<string>("ParameterType"),
                EntityKey = x.Field<Int16?>("EntityKey"),
                ShortNameEnum = x.Field<string>("ShortNameEnum"),
                ParameterValue = x.Field<int?>("ParameterValue"),
                MinValue = x.Field<Int16?>("MinValue"),
                MaxValue = x.Field<Int16?>("MaxValue"),
                AuthorisationStatus = x.Field<string>("AuthorisationStatus")
            }).ToList();
            var objDescriptionData = ds.Tables[8].AsEnumerable().Select(x => new
            {
                Description = x.Field<string>("Description"),
                Code = x.Field<int>("Code")
            }).ToList();
            var objDeptGroup = ds.Tables[9].AsEnumerable().Select(x => new
            {
                //EntityKey = x.Field<Int16>("EntityKey"),
                DeptGroupName = x.Field<string>("DeptGroupName"),
                DeptGroupDesc = x.Field<string>("DeptGroupDesc"),
                Menus = x.Field<string>("Menus"),
                DeptGroupId = x.Field<Int16>("DeptGroupId")
            }).ToList();
            var objMenusList = ds.Tables[10].AsEnumerable().Select(x => new
            {
                //EntityKey = x.Field<int?>("EntityKey"),
                //MenuTitleId = x.Field<int?>("MenuTitleId"),
                //DataSeq = x.Field<decimal>("DataSequence"),
                //MenuId = x.Field<int?>("MenuId"),
                //ParentId = x.Field<int?>("ParentId"),
                //MenuCaption = x.Field<string>("MenuCaption"),
                //BusFld = x.Field<string>("BusFld")
                //ActionName = x.Field<string>("ActionName")
                EntityKey = x.Field<int>("EntityKey"),
                MenuTitleId = x.Field<int>("MenuTitleId"),
                DataSeq = x.Field<int>("DataSeq"),
                MenuId = x.Field<int>("MenuId"),
                ParentId = x.Field<int>("ParentId"),
                MenuCaption = x.Field<string>("MenuCaption"),
                BusFld = x.Field<string>("BusFld"),
                ActionName = x.Field<string>("ActionName")

            }).ToList();
            var objUserDescription = ds.Tables[11].AsEnumerable().Select(x => new
            {
                Code = x.Field<Int16?>("Code"),
                Description = x.Field<string>("Description"),
                UserDeletionReason_Key = x.Field<Int16?>("UserDeletionReason_Key"),
                _Group = x.Field<string>("_Group"),
                SubGroup = x.Field<string>("SubGroup"),
                Segment = x.Field<string>("Segment"),
                ShortName = x.Field<string>("ShortName"),
                ShortNameEnum = x.Field<string>("ShortNameEnum")
            }).ToList();
            var objParameter = ds.Tables[12].AsEnumerable().Select(x => new
            {
                ParameterValue = x.Field<string>("ParameterValue")
            }).ToList();
            var objDesignation = ds.Tables[13].AsEnumerable().Select(x => new
            {
                DesignationAlt_Key = x.Field<Int16>("DesignationAlt_Key"),
                DesignationName = x.Field<string>("DesignationName"),
                DesignationShortName = x.Field<string>("DesignationShortName")
            }).ToList();
            List<object> lst = new List<object>();
            lst.Add(locationData);
            lst.Add(branchaInfo);
            lst.Add(regionInfo);
            lst.Add(zoneName);
            lst.Add(branchName);
            lst.Add(roleData);
            lst.Add(objMetaData);
            lst.Add(objMasterData);
            lst.Add(objDescriptionData);
            lst.Add(objDeptGroup);
            lst.Add(objMenusList);
            lst.Add(objUserDescription);
            lst.Add(objParameter);
            lst.Add(objDesignation);
            return lst;
        }
        public List<object> GetAuxdata(string paramString)
        {
            JObject jsonData = JObject.Parse(paramString);
            objUserMaintanance._userLoginId = jsonData["UserLoginId"].ToString();
            objUserMaintanance._userLocationCode = jsonData["userLocationCode"].ToString();
            objUserMaintanance.UserLocation = jsonData["UserLocation"].ToString();
            objUserMaintanance._TimeKey = Convert.ToInt32(jsonData["TimeKey"].ToString());
            objUserMaintanance.UserModificationAuxSelect();
            DataTable dt = objUserMaintanance.ResultDataTable;
            var auxData = dt.AsEnumerable().Select(x => new
            {
                UserLoginID = x.Field<string>("UserLoginID"),
                UserName = x.Field<string>("UserName"),
                LoginPassword = x.Field<string>("LoginPassword"),
                UserLocation = x.Field<string>("UserLocation"),
                UserLocationName = x.Field<string>("UserLocationName"),
                UserLocationCode = x.Field<string>("UserLocationCode"),
                UserRoleAlt_Key = x.Field<Int16>("UserRoleAlt_Key"),
                RoleDescription = x.Field<string>("RoleDescription"),
                Activate = x.Field<string>("Activate"),
                PasswordChanged = x.Field<string>("PasswordChanged"),
                IsEmployee = x.Field<string>("IsEmployee"),
                SUSPEND = x.Field<string>("SUSPEND"),
                ExpiredUser = x.Field<string>("ExpiredUser"),
                IsChecker = x.Field<string>("IsChecker"),
                DeptGroupCode = x.Field<string>("DeptGroupCode"),
                EmployeeID = x.Field<string>("EmployeeID")
            }).ToList();
            var lst = ((IEnumerable<dynamic>)auxData).ToList();
            return lst;
        }
        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }
        public int InsertUpdateData(string jsonData)
        {
            int _resultvalue = 0;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            objUserMaintanance = serializer.Deserialize<UserCreationModel>(jsonData);
            _resultvalue = objUserMaintanance.UserCreationInsert(objUserMaintanance);
            //if (!objUserMaintanance.hasError)
            //{
            //    _resultvalue = objUserMaintanance.id;
            //}
            return _resultvalue;
        }
    }
}