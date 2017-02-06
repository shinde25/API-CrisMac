using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.UserMaintananceRepository
{
    public class UserMaintananceRepository : IUserMaintananceRepository
    {
        //MenuModel ObjMenu;
        UserchangedUserpwd ObjUserData;
        MetaUserFieldDetail objMeta;

        public List<object> Select_MenuLayout(string results)
        {
            MenuModel ObjMenu = new MenuModel();
            // objcommPara = (CommonProperties)Session["_result"];
            ObjMenu.userLoginId = results;
            ObjMenu.Select_MenuListDashboard();
            //  List<MenuModel> lstMenu = new List<MenuModel>();
            DataTable dt = ObjMenu.ResultDataTable;

            var lstMenu = dt.AsEnumerable().Select(x => new
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

            var lst = ((IEnumerable<dynamic>)lstMenu).ToList();
            return lst;
        }

        public List<object> Select_MenuList(string paramdata)
        {
            MenuModel objMenuModel = new MenuModel();

            JObject jsondata = JObject.Parse(paramdata);
            objMenuModel.userLoginId = jsondata["_userLoginId"].ToString();
            objMenuModel._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());

            objMenuModel.Select_MenuList();
            DataTable dtMenu = objMenuModel.ResultDataTable;
            var lstMenuModel = dtMenu.AsEnumerable().Select(x =>
             new
             {
                 EntityKey = x.Field<int>("EntityKey"),
                 MenuTitleId = x.Field<int>("MenuTitleId"),
                 DataSeq = x.Field<int>("DataSeq"),
                 MenuId = x.Field<int>("MenuId"),
                 ParentId = x.Field<int>("ParentId"),
                 MenuCaption = x.Field<string>("MenuCaption"),
                 BusFld = x.Field<string>("BusFld"),
                 EnableMakerChecker = x.Field<string>("EnableMakerChecker"),
                 ActionName = x.Field<string>("ActionName"),
                 NonAllowOperation = x.Field<string>("NonAllowOperation"),
                 AccessLevel = x.Field<string>("AccessLevel")
             }).ToList();

            var lst = ((IEnumerable<dynamic>)lstMenuModel).ToList();
            return lst;
        }

        public int GetChangepwdData(string paramdata)
        {
            int _resultvalue = 0;
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData.NewPassword = jsondata["NewPassword"].ToString();
            ObjUserData._EffectiveFromTimeKey = Convert.ToInt32(jsondata["_EffectiveFromTimeKey"].ToString());
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            ObjUserData._EffectiveToTimeKey = Convert.ToInt32(jsondata["_EffectiveToTimeKey"].ToString());
            _resultvalue = ObjUserData.GetUserChangePasswordSelect();
            //if (!ObjUserData.hasError)
            //{
            //    _resultvalue = ObjUserData.id;
            //}
            return _resultvalue;
        }

        public List<object> GetResetPwdData(string paramdata)
        {
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            ObjUserData.username = jsondata["username"].ToString();
            ObjUserData.GetUserCreationForResetPwdAuxSelect();
            DataTable dt = ObjUserData.ResultDataTable;
            var resetdata = dt.AsEnumerable().Select(x =>
              new
              {
                  userLoginId = x.Field<string>("userLoginId"),
                  //_TimeKey = x.Field<int>("_TimeKey"),
                  username = x.Field<string>("username")
              }).ToList();
            var _AttributesList = ((IEnumerable<dynamic>)resetdata).ToList();
            return _AttributesList;
        }

        public int GetResetPassUpdate(string paramdata)
        {
            int _resultvalue = 0;
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData._CreatedBy = jsondata["_CreatedBy"].ToString();
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData.DefaultPassward = jsondata["Oldpwd"].ToString();
            ObjUserData._EffectiveFromTimeKey = Convert.ToInt32(jsondata["_EffectiveFromTimeKey"].ToString());
            ObjUserData._EffectiveToTimeKey = Convert.ToInt32(jsondata["_EffectiveToTimeKey"].ToString());
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            _resultvalue = ObjUserData.SetUserResetPasswordUpdate();

            return _resultvalue;
        }
        public List<object> GetUserinformation(string paramdata)
        {
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            ObjUserData.FrmType = jsondata["FrmType"].ToString();
            ObjUserData.GetUserInfoAuxSelect();
            DataTable dt = ObjUserData.ResultDataTable;
            var GetUserInfo = dt.AsEnumerable().Select(x =>
                new
                {
                    username = x.Field<string>("UserName"),
                    userLoginId = x.Field<string>("userLoginId"),
                    Location = x.Field<string>("UserLocation"),
                    BranchCode = x.Field<string>("UserLocationCode"),
                    Userrole = x.Field<string>("RoleDescription")
                }).ToList();
            var _AttributesList = ((IEnumerable<dynamic>)GetUserInfo).ToList();
            return _AttributesList;
        }
        public List<object> GetSuspendedUser(string paramdata)
        {
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            ObjUserData.GetSuspendedUserAuxSelect();
            DataTable dt = ObjUserData.ResultDataTable;
            var GetSuspendedUserInfo = dt.AsEnumerable().Select(x =>
                    new
                    {
                        username = x.Field<string>("UserName"),
                        userLoginId = x.Field<string>("userLoginId"),
                        Location = x.Field<string>("UserLocation"),
                        BranchCode = x.Field<string>("UserLocationCode"),
                        Userrole = x.Field<string>("RoleDescription")
                    }).ToList();
            var _AttributesList = ((IEnumerable<dynamic>)GetSuspendedUserInfo).ToList();
            return _AttributesList;
        }

        public int GetUpdateSetInvokeSuspendedUser(string paramdata)
        {
            int _resultvalue = 0;
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            ObjUserData.NewPassword = jsondata["NewPassword"].ToString();
            _resultvalue = ObjUserData.SetInvokedUserSuspendUpdate();

            return _resultvalue;
        }
        public List<object> GetLoginUserInfo(string paramdata)
        {
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            ObjUserData.GetUserLoginAuxSelect();
            DataTable dt = ObjUserData.ResultDataTable;
            var GetUserInfo = dt.AsEnumerable().Select(x =>
                new
                {
                    username = x.Field<string>("UserName"),
                    userLoginId = x.Field<string>("userLoginId"),
                    Location = x.Field<string>("UserLocation"),
                    BranchCode = x.Field<string>("UserLocationCode"),
                    Userrole = x.Field<string>("RoleDescription")
                }).ToList();
            var _AttributesList = ((IEnumerable<dynamic>)GetUserInfo).ToList();
            return _AttributesList;
        }
        public int GetInvokedLoginUser(string paramdata)
        {
            int _resultvalue = 0;
            ObjUserData = new UserchangedUserpwd();
            JObject jsondata = JObject.Parse(paramdata);
            ObjUserData.userLoginId = jsondata["userLoginId"].ToString();
            ObjUserData._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            ObjUserData.NewPassword = jsondata["NewPassword"].ToString();
            _resultvalue = ObjUserData.SetUserLoginInvokeUpdate();

            return _resultvalue;
        }

        public List<object> GetUserPolicyMetaData(string paramdata)
        {
            objMeta = new MetaUserFieldDetail();
            JObject jsondata = JObject.Parse(paramdata);
            objMeta._blnFetchMasterData = jsondata["_blnFetchMasterData"].ToString();
            objMeta._blnFetchMetaData = jsondata["_blnFetchMetaData"].ToString();
            objMeta._TimeKey = Convert.ToInt32(jsondata["_TimeKey"].ToString());
            objMeta.SelectParameterisedMasterData();
            DataTable dt = objMeta.ResultDataSet.Tables[2];
            var GetMetaData = dt.AsEnumerable().Select(x =>
                new
                {
                    MsgDescription = x.Field<string>("MsgDescription"),
                    ParameterType = x.Field<string>("ParameterType"),
                    ParameterValue = x.Field<int>("ParameterValue"),
                    MinValue = x.Field<Int16>("MinValue"),
                    MaxValue = x.Field<Int16>("MaxValue")

                }).ToList();
            var _AttributesList = ((IEnumerable<dynamic>)GetMetaData).ToList();
            return _AttributesList;
        }
        public int UpdateUserParameter(string UserParaData)
        {
            int _resultvalue = 0;
            objMeta = new MetaUserFieldDetail();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            objMeta = serializer.Deserialize<MetaUserFieldDetail>(UserParaData);
            objMeta.UpdateUserParametersInsertUpdate();

            if (!objMeta.hasError)
            {
                _resultvalue = objMeta.id;
            }

            return _resultvalue;
        }
    }
}