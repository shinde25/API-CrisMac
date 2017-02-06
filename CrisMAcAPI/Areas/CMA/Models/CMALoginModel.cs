using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data.SqlClient;
using CrisMAc.Models;
using Newtonsoft.Json.Linq;
using System.Data.Common;

namespace CrisMAcAPI.Areas.CMA.Models
{
    public class CMALoginModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string ParameterType { get; set; }
        public string ShortNameEnum { get; set; }
        public int ParameterValue { get; set; }
        public string UserLoginID { get; set; }
        public string LoginPassword { get; set; }

        public string UserLoginId { get; set; }
        public string Password { get; set; }

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public int TimeKey { get; set; }


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
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, 9999);
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
                                               new SqlParameter("@UserLoginId",UserLoginID),
                                               new SqlParameter("@Password", Password)
                };
            spName = "[CMA].[UserAuthentication]";
            ExecuteSelectDataSet();
        }


        public object ChangePassword()      //----ChangePassword
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[UserResetPasswordUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "@CurrentPassword", System.Data.DbType.String, CurrentPassword);
                    database.AddInParameter(command, "@NewPassword", System.Data.DbType.String, NewPassword);
                   // database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, TimeKey);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
            }
            JObject DBReturnResult = new JObject();
            //DBReturnResult.Add("Result", command.Parameters["@Result"].Value.ToString());            
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            return DBReturnResult;
        }
    }
}