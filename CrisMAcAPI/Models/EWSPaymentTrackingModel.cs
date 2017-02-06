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
    public class EWSPaymentTrackingModel:CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int CustomerEntityId { get; set; }
        public string CustomerId { get; set; }
        public int AccountEntityId { get; set; }
        public string CustomerACID { get; set; }        
        public string CaseNo { get; set; }
        public string DraweeACID { get; set; }
        public string DraweeBranchCode { get; set; }
        public string ChqNo { get; set; }
        public decimal AmtOfChq { get; set; }
        public string DraweeName { get; set; }
        public string DrawerName { get; set; }
        public string DrawerACID { get; set; }
        public string DrawerBranch { get; set; }
        public string PresentingBank { get; set; }
        public string Status { get; set; }
        public string PossibleReason { get; set; }
        public string Decision { get; set; }
        public string AuthorisationCode { get; set; }
        public string EWSPaymentTrackingJson { get; set; }
        public string UserLoginId { get; set; }


        public void EWSPaymentTrackingParmatrised()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[EWSPaymentTrackingParmatrised]";
            ExecuteSelectDataSet();
        }

        public void EWSPaymentTrackingAuxSelect()
        {
            sqlParams = new SqlParameter[] {                                                 
                                                  new SqlParameter("@Mode", _OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey),
                                                   new SqlParameter("@UserLoginId", UserLoginId)

                };
            spName = "[EWS].[EWSPaymentTrackingAuxSelect]";
            ExecuteSelectDataSet();
        }       

        public void EWSPaymentTrackingSelect()
        {
            sqlParams = new SqlParameter[] {

                                                 new SqlParameter("@Mode", _OperationMode),
                                                 new SqlParameter("@TimeKey",_TimeKey),
                                                 new SqlParameter("@CaseNo",CaseNo)
                                                 //new SqlParameter("@CustomerEntityId",CustomerEntityId),
                                                 //new SqlParameter("@CustomerId", CustomerId),
                                                 //new SqlParameter("@AccountEntityId",AccountEntityId),
                                                 //new SqlParameter("@CustomerACID",CustomerACID),
                                                 //new SqlParameter("@DraweeACID", DraweeACID),
                                                 //new SqlParameter("@DraweeBranchCode", DraweeBranchCode),
                                                 //new SqlParameter("@ChqNo",ChqNo),
                                                 //new SqlParameter("@AmtOfChq", AmtOfChq),
                                                 //new SqlParameter("@DraweeName", DraweeName),
                                                 //new SqlParameter("@DrawerName",DrawerName),
                                                 //new SqlParameter("@DrawerACID", DrawerACID),
                                                 //new SqlParameter("@DrawerBranch", DrawerBranch),
                                                 //new SqlParameter("@PresentingBank", PresentingBank),
                                                 //new SqlParameter("@Status", Status),
                                                 //new SqlParameter("@PossibleReason", PossibleReason),
                                                 //new SqlParameter("@Decision", Decision),
                                                 //new SqlParameter("@AuthorisationCode", AuthorisationCode)                                                 

                };
            spName = "[EWS].[EWSPaymentTrackingSelectNew]";
            ExecuteSelectDataSet();
        }

        public object EWSPaymentTrackingInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[EWSPaymentTrackingInsertUpdate]");
            try
            {
                using (command)
                {
                    //database.AddInParameter(command, "@CaseNo", System.Data.DbType.String, CaseNo);
                    //database.AddInParameter(command, "@CustomerEntityId", System.Data.DbType.Int32, CustomerEntityId);
                    //database.AddInParameter(command, "@CustomerId", System.Data.DbType.String, CustomerId);
                    //database.AddInParameter(command, "@AccountEntityId", System.Data.DbType.Int32, AccountEntityId);
                    //database.AddInParameter(command, "@CustomerACID", System.Data.DbType.String, CustomerACID);
                    //database.AddInParameter(command, "@DraweeACID", System.Data.DbType.String, DraweeACID);
                    //database.AddInParameter(command, "@DraweeBranchCode", System.Data.DbType.String, DraweeBranchCode);
                    //database.AddInParameter(command, "@ChqNo", System.Data.DbType.String, ChqNo);
                    //database.AddInParameter(command, "@AmtOfChq", System.Data.DbType.Decimal, AmtOfChq);
                    //database.AddInParameter(command, "@DraweeName", System.Data.DbType.String, DraweeName);
                    //database.AddInParameter(command, "@DrawerName", System.Data.DbType.String, DrawerName);
                    //database.AddInParameter(command, "@DrawerACID", System.Data.DbType.String, DrawerACID);
                    //database.AddInParameter(command, "@DrawerBranch", System.Data.DbType.String, DrawerBranch);
                    //database.AddInParameter(command, "@PresentingBank", System.Data.DbType.String, PresentingBank);
                    //database.AddInParameter(command, "@Status", System.Data.DbType.String, Status);
                    //database.AddInParameter(command, "@PossibleReason", System.Data.DbType.String, PossibleReason);
                    //database.AddInParameter(command, "@Decision", System.Data.DbType.String, Decision);
                    //database.AddInParameter(command, "@AuthorisationCode", System.Data.DbType.String, AuthorisationCode);
                    database.AddInParameter(command, "@EWSPaymentTrackingJson", System.Data.DbType.String, EWSPaymentTrackingJson);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@DateApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@ApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@ChangedField", System.Data.DbType.String, _EffectiveToTimeKey);
                    //database.AddInParameter(command, "@ScreenEntityId", System.Data.DbType.Int32, ScreenEntityId); 
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);

                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());

            return DBReturnResult;
        }
    }
}