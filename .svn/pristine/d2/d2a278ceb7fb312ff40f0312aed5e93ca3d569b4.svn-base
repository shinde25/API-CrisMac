using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.Common;

namespace CrisMAcAPI.Areas.LOS.Models
{
    public class UserModel
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public string UserLoginID { get; set; }
        public string UserName  { get; set; }
        public string LoginPassword { get; set; }
        public string PasswordChanged { get; set; }
        public string PasswordChangeDate { get; set; }
        public string ChangePwdCnt { get; set; }
        public string UserLocation { get; set; }
        public string UserLocationCode { get; set; }
        public string UserRoleAlt_Key { get; set; }
        public string SuspendedUser  { get; set; }
        public string CurrentLoginDate { get; set; }
        public string ResetDate { get; set; }
        public string Activate { get; set; }
        public string UserLogged  { get; set; }
        public string UserDeletionReasonAlt_Key { get; set; }
        public string SystemLogOut { get; set; }
        public string EmployeeID  { get; set; }
        public string IsEmployee  { get; set; }
        public string IsChecker  { get; set; }
        public string RBIFLAG  { get; set; }
        public string DeptGroupCode { get; set; }
        public string Email_ID   { get; set; }
        public string SecuritQsnAlt_Key { get; set; }
        public string SecurityAns { get; set; }
        public string MenuId { get; set; }
        public string AuthorisationStatus { get; set; }
        public string EffectiveFromTimeKey{ get; set; }
        public string EffectiveToTimeKey   { get; set; }
        public string CreatedBy   { get; set; }
        public string DateCreated { get; set; }
        public string ModifyBy { get; set; }
        public string DateModified { get; set; }
        public string ApprovedBy{ get; set; }
        public string DateApproved { get; set; }
        public string MIS_APP_USR_ID  { get; set; }
        public string MIS_APP_USR_PASS { get; set; }  
        public string UserLocationExcel { get; set; }
        public string DesignationAlt_Key { get; set; }
        public string MobileNo { get; set; }
        public string IsCMA { get; set; }
        public int Result { get; set; }
        public string Password { get; set; }


        public JObject InsertUserProfile()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("UserProfilInsert");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "UserName", System.Data.DbType.String, UserName);
                    database.AddInParameter(command, "LoginPassword", System.Data.DbType.String, LoginPassword);
                    database.AddInParameter(command, "PasswordChanged", System.Data.DbType.String, PasswordChanged);
                    database.AddInParameter(command, "PasswordChangeDate", System.Data.DbType.String, PasswordChangeDate);
                    database.AddInParameter(command, "ChangePwdCnt", System.Data.DbType.String, ChangePwdCnt);
                    database.AddInParameter(command, "UserLocation", System.Data.DbType.String, UserLocation);
                    database.AddInParameter(command, "UserLocationCode", System.Data.DbType.String, UserLocationCode);
                    database.AddInParameter(command, "UserRoleAlt_Key", System.Data.DbType.String, UserRoleAlt_Key);
                    database.AddInParameter(command, "SuspendedUser", System.Data.DbType.String, SuspendedUser);
                    database.AddInParameter(command, "CurrentLoginDate", System.Data.DbType.String, CurrentLoginDate);
                    database.AddInParameter(command, "ResetDate ", System.Data.DbType.String, ResetDate);
                    database.AddInParameter(command, "Activate", System.Data.DbType.String, Activate);
                    database.AddInParameter(command, "UserLogged", System.Data.DbType.String, UserLogged);
                    database.AddInParameter(command, "UserDeletionReasonAlt_Key", System.Data.DbType.String, UserDeletionReasonAlt_Key);
                    database.AddInParameter(command, "SystemLogOut", System.Data.DbType.String, SystemLogOut);
                    database.AddInParameter(command, "EmployeeID", System.Data.DbType.String, EmployeeID);
                    database.AddInParameter(command, "IsEmployee", System.Data.DbType.String, IsEmployee);
                    database.AddInParameter(command, "IsChecker", System.Data.DbType.String, IsChecker);
                    database.AddInParameter(command, "RBIFLAG", System.Data.DbType.String, RBIFLAG);
                    database.AddInParameter(command, "DeptGroupCode", System.Data.DbType.String, DeptGroupCode);
                    database.AddInParameter(command, "Email_ID", System.Data.DbType.String, Email_ID);
                    database.AddInParameter(command, "SecuritQsnAlt_Key", System.Data.DbType.String, SecuritQsnAlt_Key);
                    database.AddInParameter(command, "SecurityAns", System.Data.DbType.String, SecurityAns);
                    database.AddInParameter(command, "MenuId", System.Data.DbType.String, MenuId);
                    database.AddInParameter(command, "AuthorisationStatus", System.Data.DbType.String, AuthorisationStatus);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.String, EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.String, EffectiveToTimeKey);
                    database.AddInParameter(command, "CreatedBy", System.Data.DbType.String, CreatedBy);
                    database.AddInParameter(command, "DateCreated", System.Data.DbType.String, DateCreated);
                    database.AddInParameter(command, "ModifyBy", System.Data.DbType.String, ModifyBy);
                    database.AddInParameter(command, "DateModified", System.Data.DbType.DateTime, DateModified);
                    database.AddInParameter(command, "ApprovedBy", System.Data.DbType.String, ApprovedBy);
                    database.AddInParameter(command, "DateApproved", System.Data.DbType.String, DateApproved);
                    database.AddInParameter(command, "MIS_APP_USR_ID", System.Data.DbType.String, MIS_APP_USR_ID);
                    database.AddInParameter(command, "MIS_APP_USR_PASS", System.Data.DbType.String, MIS_APP_USR_PASS);
                    database.AddInParameter(command, "UserLocationExcel", System.Data.DbType.String, UserLocationExcel);
                    database.AddInParameter(command, "DesignationAlt_Key", System.Data.DbType.String, DesignationAlt_Key);
                    database.AddInParameter(command, "MobileNo", System.Data.DbType.String, MobileNo);
                    database.AddInParameter(command, "IsCMA", System.Data.DbType.String, IsCMA);
                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, Result);
                    database.ExecuteNonQuery(command);
                }
                JObject DBReturnResult = new JObject();
                DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
                return DBReturnResult;
            }
            catch (Exception ex)
            {
                JObject DBReturnResult = new JObject();
                DBReturnResult.Add("Result", ex.Message);
                return DBReturnResult;
            }

        }
        public JObject UserAuthentication()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("UserAuthentication");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "UserLoginId", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "Password", System.Data.DbType.String, Password);
                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, Result);
                    database.ExecuteNonQuery(command);
                }
                JObject DBReturnResult = new JObject();
                DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
                return DBReturnResult;
            }
            catch (Exception ex)
            {
                JObject DBReturnResult = new JObject();
                DBReturnResult.Add("Result", ex.Message);
                return DBReturnResult;
            }

        }
    }
}