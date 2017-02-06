using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data.SqlClient;
using CrisMAc.Models;
using Newtonsoft.Json.Linq;
using System.Data.Common;

namespace CrisMAcAPI.Areas.D2k_Inventory.Models
{
    public class AppLoginModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string ParameterType { get; set; }
        public string ShortNameEnum { get; set; }
        public int ParameterValue { get; set; }
        public string UserLoginID { get; set; }
        public string LoginPassword { get; set; }

        public string UserLoginId { get; set; }
        public string Password { get; set; }

        public void APPUserPwdPolicySelect()
        {
            spName = "[dbo].[APP_UserPwdPolicySelect]";
            ExecuteSelectDataSet();
        }

        public object AppChangePasswordInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[dbo].[APP_UserPwdChange]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "@LoginPassword", System.Data.DbType.String, LoginPassword);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32,9999);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
           

            return DBReturnResult;
        }


        public void UserAuthDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginId",UserLoginId),
                                               new SqlParameter("@Password", Password)
                };
            spName = "APP_UserAuthentication";
            ExecuteSelectDataSet();
        }

    }
}