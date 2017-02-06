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
    public class IrregularityDetailModel:CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int RemarkId { get; set; }
        public string Remark { get; set; }
        public int CustomerEntityId { get; set;}
        public int AccountEntityId { get; set; }
        public int RemarkByAlt_Key { get; set; }
        public int RemarkTypeAlt_Key { get; set; }
        public string RemarkDt { get; set; }
        public string RemarkText { get; set; }
        public string RemarkBy { get; set; }
        public int ActionableVerbAlt_Key { get; set; }
        public string WhatIsToBeDone { get; set; }
        public string BywhenDt { get; set; }
        public string ActionableWordJson { get; set; }
        public int AuditorAlt_Key { get; set; }
        public string XmlData { get; set; }

        public void IrregularityAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),
                new SqlParameter("@Mode", _OperationMode),
                new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[IrregularityDetailAuxSelect]";
            ExecuteSelectDataSet();
        }

        public void IrregularitySelect()
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
            spName = "[EWS].[IrregularityDetailSelect]";
            ExecuteSelectDataSet();
        }

        public object IrregularityInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[IrregularityDetailInsertUpdate]");
            try
            {
                using (command)
                {
                    //database.AddInParameter(command, "@RemarkId", System.Data.DbType.Int32, RemarkId);
                    database.AddInParameter(command, "@CustomerEntityId", System.Data.DbType.Int32, CustomerEntityId);
                    database.AddInParameter(command, "@AccountEntityId", System.Data.DbType.Int32, AccountEntityId);
                    database.AddInParameter(command, "@AuditorAlt_Key", System.Data.DbType.Int16,AuditorAlt_Key);
                    database.AddInParameter(command, "@XmlData", System.Data.DbType.String, XmlData);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String,_Remark);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int16, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
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
            
            return DBReturnResult;
        }
    }
}