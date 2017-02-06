using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models
{
    public class RemarkAggregatorModel : CommonProperties
    {

        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public int CustomerEntityId { get; set; }
        public int AccountEntityId { get; set; }
        public int RemarkByAlt_Key { get; set; }
        public int RemarkId { get; set; }
        public int RemarkTypeAlt_Key { get; set; }
        public string RemarkDt { get; set; }
        public string RemarkText { get; set; }
        public string RemarkBy { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public void RemarkAggregatorParmatrised()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[RemarkAggregatorParmatrised]";
            ExecuteSelectDataSet();
        }
        public void RemarkAggregatorAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),
                new SqlParameter("@Mode", _OperationFlag),
                new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[RemarkAggregatorAuxSelect]";
            ExecuteSelectDataSet();
        }
        public void RemarkAggregatorSelect()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId", CustomerEntityId),
                 new SqlParameter("@RemarkBy", RemarkBy),
                 new SqlParameter("@DateFrom", FromDate),
                 new SqlParameter("@DateTo", ToDate)
                };
            spName = "[EWS].[RemarkAggregatorSelect]";
            ExecuteSelectDataSet();
        }
        public object RemarkAggregatorInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[CustomerRemarkInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@RemarkId", System.Data.DbType.Int32, RemarkId);
                   database.AddInParameter(command, "@CustomerEntityId", System.Data.DbType.Int32, CustomerEntityId);
                    database.AddInParameter(command, "@AccountEntityId", System.Data.DbType.Int32, AccountEntityId);
                    database.AddInParameter(command, "@RemarkByAlt_Key", System.Data.DbType.Int16, RemarkByAlt_Key);
                    database.AddInParameter(command, "@RemarkTypeAlt_Key", System.Data.DbType.Int16, RemarkTypeAlt_Key);
                    database.AddInParameter(command, "@RemarkDt", System.Data.DbType.String, RemarkDt);
                    database.AddInParameter(command, "@RemarkText", System.Data.DbType.String, RemarkText);

                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "DATECreateModifyApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int16, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "ChangedFields", System.Data.DbType.String, _EffectiveToTimeKey);

                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
             //       database.AddOutParameter(command, "TMPERRORMSG", System.Data.DbType.String,100);
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
         //   DBReturnResult.Add("TMPERRORMSG", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            //DBReturnResult = new
            //DBReturnResult = new
            //{
            //    Result = (command.Parameters)[command.Parameters.Count - 1].Value,
            //    D2Ktimestamp = (command.Parameters)[command.Parameters.Count - 2].Value
            //};
            return DBReturnResult;
        }
    }
}
