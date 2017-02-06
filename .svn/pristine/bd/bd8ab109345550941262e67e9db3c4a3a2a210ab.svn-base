using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.UserGroupDeptRepository
{
    public class UserGroupDeptRepository : IUserGroupDeptRepository
    {
        UserGroupDeptModel objMasterData;
        public List<object> getParameterisedMasterData(string paramdata)
        {
            objMasterData = new UserGroupDeptModel();
            JObject jobj = JObject.Parse(paramdata);
            objMasterData._TimeKey = Convert.ToInt32(jobj["TimeKey"].ToString());
            objMasterData.UserGroupDeptParameterisedMasterData();
            DataTable dt = objMasterData.ResultDataSet.Tables[0];
            var UserGroupDeptMasterData = dt.AsEnumerable().Select(x =>
            new
            {
                CtrlName = x.Field<string>("CtrlName"),
                FldName = x.Field<string>("FldName"),
                FldCaption = x.Field<string>("FldCaption"),
                FldDataType = x.Field<string>("FldDataType"),
                FldLength = x.Field<string>("FldLength"),
                DataSeq = x.Field<Int16?>("DataSeq"),
                MsgFlag = x.Field<string>("MsgFlag"),
                ReportFieldNo = x.Field<int?>("ReportFieldNo"),
                ScreenFieldNo = x.Field<int?>("ScreenFieldNo"),
                ViableForSCD2 = x.Field<string>("ViableForSCD2"),
                MsgDescription = x.Field<string>("MsgDescription")
            }).ToList();
            DataTable dt1 = objMasterData.ResultDataSet.Tables[1];
            var UserGroupDeptMenuData = dt1.AsEnumerable().Select(x =>
            new
            {
                EntityKey = x.Field<int>("EntityKey"),
                MenuTitleId = x.Field<int>("MenuTitleId"),
                DataSeq = x.Field<int>("DataSeq"),
                MenuId = x.Field<int>("MenuId"),
                ParentId = x.Field<int>("ParentId"),
                MenuCaption = x.Field<string>("MenuCaption"),
                BusFld = x.Field<string>("BusFld"),
                ActionName = x.Field<string>("ActionName")
            }).ToList();
            List<object> lst = new List<object>();
            lst.Add(UserGroupDeptMasterData);
            lst.Add(UserGroupDeptMenuData);
            return lst;
        }
        public List<object> GetAuxdata(string paramData)
        {
            objMasterData = new UserGroupDeptModel();
            JObject jobj = JObject.Parse(paramData);
            objMasterData._TimeKey = Convert.ToInt32(jobj["TimeKey"].ToString());
            objMasterData.UserGroupsAuxSelect();
            DataTable dt = objMasterData.ResultDataTable;
            var lstUserGroupAuxData = dt.AsEnumerable().Select(x => new
            {
                EntityKey = x.Field<Int16>("EntityKey"),
                DeptGroupName = x.Field<string>("DeptGroupName"),
                DeptGroupDesc = x.Field<string>("DeptGroupDesc"),
                Menus = x.Field<string>("Menus"),
                DeptGroupId = x.Field<Int16>("DeptGroupId")
            }).ToList();
            var lstData = ((IEnumerable<dynamic>)lstUserGroupAuxData).ToList();
            return lstData;
        }
        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }
        public List<object> FetchData(string paramString)
        {
            throw new NotImplementedException();
        }

        public int InsertUpdateData(string paramString)
        {
            
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            objMasterData = new UserGroupDeptModel();
            objMasterData = serializer.Deserialize<UserGroupDeptModel>(paramString);
            int Rval = objMasterData.UserGroupInsertUpdate();                       

            return Rval;
        }
    }
}