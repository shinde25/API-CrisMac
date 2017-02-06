using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models
{
    public class SolutionParameterModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public int parameteralt_key { get; set; }
        public string paraName { get; set; }
        public string paravalue { get; set; }
        public string changedDate { get; set; }
        public string oldNew { get; set; }

        public int MenuID { get; set; }
        public string AuthMode { get; set; }
        //AuthMode
        public void SolutionParameterAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                                  new SqlParameter("@Mode", _OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey)
                                                   //,new SqlParameter("@UserLoginId", UserLoginId)
                };
            spName = "[dbo].[SolutionParameterAuxData]";
            ExecuteSelectDataSet();
        }

        public object SolutionParameterInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[dbo].[SolutionParameterInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@parameteralt_key", System.Data.DbType.Int32, parameteralt_key);
                    database.AddInParameter(command, "@parametername", System.Data.DbType.String, paraName);
                    database.AddInParameter(command, "@parametervalue", System.Data.DbType.String, paravalue);
                    database.AddInParameter(command, "@changeEffectiveFrom", System.Data.DbType.String, changedDate);
                    database.AddInParameter(command, "@OldNew", System.Data.DbType.String, oldNew);

                    database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, MenuID);
                    database.AddInParameter(command, "@ApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@DateApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, AuthMode);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    //database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.String, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@ChangedField", System.Data.DbType.String, _ChangedFields);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            return DBReturnResult;
        }
    }
}