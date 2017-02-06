using CrisMAc.Models;
using CrisMAcAPI.Models.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models
{
    public class UserCreationModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string LoginPassword { get; set; }
        public string EmployeeID { get; set; }
        public string IsEmployee { get; set; }
        public string DeptGroupCode { get; set; }
        public string IsChecker { get; set; }
        public string UserLocation { get; set; }
        public string Email_ID { get; set; }
        public string SecuritQsnAlt_Key { get; set; }
        public string SecurityAns { get; set; }
        public string MobileNo { get; set; }
        public string Designation { get; set; }
        public string IsCma { get; set; }

        public void UserCreationParameterisedMasterData()
        {
            sqlParams = new SqlParameter[]
            {
               new SqlParameter("@UserLoginID",_userLoginId),
               new SqlParameter("@TimeKey",_TimeKey),
               new SqlParameter ("@UserCreationModification","Y")
            };
            spName = "UserCreationParameterisedMasterData_New";
            ExecuteSelectDataSet();
        }
        public void UserModificationAuxSelect()
        {
            sqlParams = new SqlParameter[]
            {
               new SqlParameter("@UserLoginId", _userLoginId),
               new SqlParameter("@UserLocationCode",_userLocationCode),
               new SqlParameter("@UserLocation",UserLocation),
               new SqlParameter("@TimeKey",_TimeKey)
            };
            spName = "UserModificationAuxSelect_New";
            ExecuteSelect();
        }
        public int UserCreationInsert(UserCreationModel _obj)
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("dbo.UserCreationInsert_New");

            try
            {


                using (command)
                {
                    database.AddInParameter(command, "@UserLoginID", System.Data.DbType.String, _obj._userLoginId);
                    database.AddInParameter(command, "@EmployeeID", System.Data.DbType.String, _obj.EmployeeID);
                    database.AddInParameter(command, "@IsEmployee", System.Data.DbType.String, _obj.IsEmployee);
                    database.AddInParameter(command, "@UserName", System.Data.DbType.String, _obj._userName);
                    database.AddInParameter(command, "@LoginPassword", System.Data.DbType.String, _obj.LoginPassword);
                    database.AddInParameter(command, "@UserLocation", System.Data.DbType.String, _obj._userLocation);
                    database.AddInParameter(command, "@UserLocationCode", System.Data.DbType.String, _obj._userLocationCode);
                    database.AddInParameter(command, "@UserRoleAlt_Key", System.Data.DbType.Int32, _obj._userAltKey);
                    database.AddInParameter(command, "@DeptGroupCode", System.Data.DbType.String, _obj.DeptGroupCode);
                    database.AddInParameter(command, "@DateCreatedmodified", System.Data.DbType.String, _obj._dateCreatedmodified);
                    database.AddInParameter(command, "@CreatedModifiedBy", System.Data.DbType.String, _obj._CreatetedModifiedBy);
                    database.AddInParameter(command, "@Activate", System.Data.DbType.String, _obj._active);
                    database.AddInParameter(command, "@IsChecker", System.Data.DbType.String, _obj.IsChecker);

                    database.AddInParameter(command, "@DesignationAlt_Key", System.Data.DbType.Int16, _obj.Designation); //ad3
                    database.AddInParameter(command, "@IsCma", System.Data.DbType.String, _obj.IsCma);
                    database.AddInParameter(command, "@MobileNo", System.Data.DbType.String, _obj.MobileNo);
                    database.AddInParameter(command, "@Email_ID", System.Data.DbType.String, _obj.Email_ID);

                    database.AddInParameter(command, "@SecuritQsnAlt_Key", System.Data.DbType.String, _obj.SecuritQsnAlt_Key);
                    database.AddInParameter(command, "@SecurityAns", System.Data.DbType.String, _obj.SecurityAns);
                    database.AddInParameter(command, "@MenuId", System.Data.DbType.Int32, _obj._MenuID);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int32, _obj._EffectiveFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int32, _obj._EffectiveToTimeKey);
                    database.AddInParameter(command, "@Flag", System.Data.DbType.Int32, _obj._OperationMode);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _obj._TimeKey);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);

                    database.ExecuteNonQuery(command);
                }


            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
            return (int)(command.Parameters)[21].Value;
        }
    }
}