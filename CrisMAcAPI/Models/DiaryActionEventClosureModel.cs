using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System.Data.Common;
using System.Data.SqlClient;

namespace CrisMAcAPI.Models
{
    public class DiaryActionEventClosureModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        
        public int RemarkId { get; set; }
        public int ActionableWordAlt_Key { get; set; }
        public int Status { get; set; }
        public string CommenceDate { get; set; }
        public string CommenceRemark { get; set; }
        public string DateExecuted { get; set; }
        public string ClosureRemark { get; set; }
        public string CustomerEntityId { get; set; }
        public string ScreenEntityId { get; set; }
        public string EventType { get; set; }
        public string AlertType { get; set; }

        public void DiaryActionEventClosureParameterised()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[DiaryActionEventClosureParmatrised]";
            ExecuteSelectDataSet();
        }

        public void DiaryActionEventClosureAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),
                new SqlParameter("@Mode", _OperationMode),
                new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[DiaryActionEventClosureAuxSelect]";
            ExecuteSelectDataSet();
        }

        public void DiaryActionEventClosureSelect() //--select
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@CustomerEntityId", CustomerEntityId),
                new SqlParameter("@Mode", _OperationMode),
                new SqlParameter("@TimeKey", _TimeKey)

                 //new SqlParameter("@Mode", AccountEntityId),
                 //  new SqlParameter("@", CustomerEntityId),
                 //new SqlParameter("@BranchCode", _BranchCode),                 
                 //new SqlParameter("@UserLocationCode", _userLocationCode)
                };
            spName = "[EWS].[DiaryActionEventClosureSelect]";
            ExecuteSelectDataSet();
        }
        public void GetEmailData() //--select
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@RemakrId", RemarkId),
                new SqlParameter("@EventType", EventType),
                new SqlParameter("@AlertType", AlertType),
                new SqlParameter("@TimeKey", _TimeKey)
                
                };
            spName = "[EWS].[GetEmailSMSData]";
            ExecuteSelectDataSet();
        }
        public object DiaryActionEventClosureInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[DiaryActionEventClosureInsertUpdate]");
            try
            {
                using (command)
                {
                    
                    database.AddInParameter(command, "@RemarkId", System.Data.DbType.Int32, RemarkId);
                    database.AddInParameter(command, "@ActionableWordAlt_Key", System.Data.DbType.Int16, ActionableWordAlt_Key);
                    database.AddInParameter(command, "@RemarkStatusAlt_Key", System.Data.DbType.Int16, Status);
                    database.AddInParameter(command, "@CommencementDate", System.Data.DbType.String, CommenceDate);
                    database.AddInParameter(command, "@CommencementRemark", System.Data.DbType.String, CommenceRemark);
                    database.AddInParameter(command, "@ExecutedDate", System.Data.DbType.String, DateExecuted);
                    database.AddInParameter(command, "@ClosureRemark", System.Data.DbType.String, ClosureRemark);

                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int16, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);                   
                    database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "@ChangedField", System.Data.DbType.String, _ChangedFields);
                    database.AddInParameter(command, "@ScreenEntityId", System.Data.DbType.Int32, ScreenEntityId); //ScreenEntityId
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);

                    //database.AddInParameter(command, "ChangedFields", System.Data.DbType.String, _EffectiveToTimeKey);
                    //database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);


                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            JObject DBReturnResult = new JObject();            
            DBReturnResult.Add("Result", '1');  //(command.Parameters)[command.Parameters.Count - 8].Value.ToString()
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());

            //DBReturnResult = new
            //{
            //    Result = (command.Parameters)[command.Parameters.Count - 1].Value,
            //    D2Ktimestamp = (command.Parameters)[command.Parameters.Count - 2].Value
            //};

            return DBReturnResult;
        }
    }
}