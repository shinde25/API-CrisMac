using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace CrisMAcAPI.Models
{
    public class CustomerRemarkModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public int CustomerEntityId { get; set; }
        public int AccountEntityId { get; set; }
        public int RemarkByAlt_Key { get; set; }
        public int RemarkTypeAlt_Key { get; set; }
        public string RemarkDt { get; set; }
        public string RemarkText { get; set; }
        public string RemarkBy { get; set; }
        public int ActionableVerbAlt_Key { get; set; }
        public string WhatIsToBeDone { get; set; }
        public string BywhenDt { get; set; }
        public int RemarkId { get; set; }

        public string ActionableWordJson { get; set; }

        public void CustomerRemarkParameterised()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[CustomerRemarkParameterised]";
            ExecuteSelectDataSet();
        }
        public void CustomerRemarkAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),
                new SqlParameter("@Mode", _OperationMode),
                new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[CustomerRemarkAuxSelect]";
            ExecuteSelectDataSet();
        }

        public void CustomerRemarkSelect()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@RemarkId", RemarkId),
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@AccountEntityId", AccountEntityId),
                 new SqlParameter("@CustomerEntityId", CustomerEntityId),
                 new SqlParameter("@BranchCode", _BranchCode),
                 new SqlParameter("@Mode", _OperationMode),
                 new SqlParameter("@UserLocationCode", _userLocationCode)
                };
            spName = "[EWS].[CustomerRemarkSelect]";
            ExecuteSelectDataSet();
        }

        public void CustomerRemark_getAccountId()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId", CustomerEntityId),
                 new SqlParameter("@BranchCode", _BranchCode),
                 new SqlParameter("@Mode", _OperationMode),
                 new SqlParameter("@UserLocationCode", _userLocationCode)
                };
            spName = "[EWS].[CustomerRemark_getAccountId]";
            ExecuteSelectDataSet();
        }

        public object CustomerRemarkInsertUpdate()
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
                    database.AddInParameter(command, "@BywhenDt", System.Data.DbType.String, BywhenDt);
                    database.AddInParameter(command, "@RemarkText", System.Data.DbType.String, RemarkText);
                    database.AddInParameter(command, "@ActionableVerbAlt_Key", System.Data.DbType.Int16, ActionableVerbAlt_Key);
                    database.AddInParameter(command, "@WhatIsToBeDone", System.Data.DbType.String, WhatIsToBeDone);
                    database.AddInParameter(command, "@ActionableWordJson", System.Data.DbType.String, ActionableWordJson);

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
            //DBReturnResult = new
            //{
            //    Result = (command.Parameters)[command.Parameters.Count - 1].Value,
            //    D2Ktimestamp = (command.Parameters)[command.Parameters.Count - 2].Value
            //};
            return DBReturnResult;
        }
        public void AuxCustomerRemarkListSelect()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@CustomerEntityId", CustomerEntityId),
                new SqlParameter("@AccountEntityId", AccountEntityId),
                new SqlParameter("@Mode", _OperationMode),
                new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[CustomerRemarkListSelect]";
            ExecuteSelectDataSet();
        }
    }
}