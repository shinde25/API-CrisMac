using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.Alert.Models
{
    public class AlertModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int CustomerEntityID { get; set; }
        public string CustomerName { get; set; }
        public string DefendantID { get; set; }
        public string DefendantName { get; set; }
        public string LegalDefendantTypeName { get; set; }
        public string fetchStr { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }

        //SAVE MODEL
        public string ProspectID { get; set; }
        public int CommNoticeTypeAlt_Key { get; set; }
        public int DPD { get; set; }
        public string ChequeDt { get; set; }
        public string ReturnDt { get; set; }
        public decimal Amount { get; set; }
        public int BankAlt_Key { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string NoticePrintDt { get; set; }
        public string NoticePrintConfDt { get; set; }
        public string NoticeSignDt { get; set; }
        public string SignatoryName { get; set; }
        public string DispatchDt { get; set; }

        public int DispatchModeAlt_Key { get; set; }
        public string DispatchRefNo { get; set; }
        public string DispatchProofID { get; set; }
        public int DeliverStatusAlt_Key { get; set; }
        public string DeliveryDt { get; set; }
        public string DeliveryProofID { get; set; }
        public string NoticeReturnDt { get; set; }
        public string NoticePublication_YN { get; set; }
        public string DateCreateModifyApproved { get; set; }
        public string SearchStr { get; set; }
        public string SearchedCol { get; set; }

        //GET AUX DATA
        public void ProspectAuxSelect(AlertModel obj)
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@MenuID", obj._MenuID),
                                               new SqlParameter("@TimeKey", obj._TimeKey),
                                               new SqlParameter("@Mode", obj._OperationMode),
                                               new SqlParameter("@BranchCode", ""),// obj._BranchCode),
                                               new SqlParameter("@UserLoginId", _userLoginId),
                                               new SqlParameter("@SearchStr", SearchStr),
                                               new SqlParameter("@SearchedCol", SearchedCol)
                };
            spName = "ALERT.ProspectsCommAuxSelect";
            ExecuteSelect();
        }

        //GET FETCH DATA
        public void ProspectFetchSelect(AlertModel obj)
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@ProspectID", obj.fetchStr),
                                               new SqlParameter("@TimeKey", obj._TimeKey),
                                               new SqlParameter("@Mode", obj._OperationMode),
                                               new SqlParameter("@BranchCode", obj._BranchCode)
                };
            spName = "ALERT.ProspectsCommSelect";
            ExecuteSelectDataSet();
        }

        //GET MASTER DATA
        public void Prospect_ParameterisedMaster()
        {
            spName = "ALERT.ProspectsCommParameterisedMasterData";
            ExecuteSelectDataSet();
        }

        //INSERT UPDATE DATA
        public int InUpProspectDtls(AlertModel _obj)
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("ALERT.ProspectsCommInsertUpdate");
            using (command)
            {
                database.AddInParameter(command, "ProspectID", System.Data.DbType.String, _obj.ProspectID);
                database.AddInParameter(command, "DefendantID", System.Data.DbType.String, _obj.DefendantID);
                database.AddInParameter(command, "CommNoticeTypeAlt_Key", System.Data.DbType.Int32, 0);
                database.AddInParameter(command, "DPD", System.Data.DbType.Int32, _obj.DPD);
                database.AddInParameter(command, "ChequeDt", System.Data.DbType.String, _obj.ChequeDt);
                database.AddInParameter(command, "ReturnDt", System.Data.DbType.String, _obj.ReturnDt);
                database.AddInParameter(command, "Amount", System.Data.DbType.Decimal, _obj.Amount);
                database.AddInParameter(command, "BankAlt_Key", System.Data.DbType.Int16, 0);
                database.AddInParameter(command, "BranchName", System.Data.DbType.String, _obj.BranchName);
                database.AddInParameter(command, "BranchAddress", System.Data.DbType.String, _obj.BranchAddress);
                database.AddInParameter(command, "NoticePrintDt", System.Data.DbType.String, _obj.NoticePrintDt);
                database.AddInParameter(command, "NoticePrintConfDt", System.Data.DbType.String, _obj.NoticePrintConfDt);
                database.AddInParameter(command, "NoticeSignDt", System.Data.DbType.String, _obj.NoticeSignDt);
                database.AddInParameter(command, "SignatoryName", System.Data.DbType.String, _obj.SignatoryName);
                database.AddInParameter(command, "DispatchDt", System.Data.DbType.String, _obj.DispatchDt);
                database.AddInParameter(command, "DispatchModeAlt_Key", System.Data.DbType.Int32, _obj.DispatchModeAlt_Key);
                database.AddInParameter(command, "DispatchRefNo", System.Data.DbType.String, _obj.DispatchRefNo);
                database.AddInParameter(command, "DispatchProofID", System.Data.DbType.String, _obj.DispatchProofID);
                database.AddInParameter(command, "DeliverStatusAlt_Key", System.Data.DbType.Int32, _obj.DeliverStatusAlt_Key);
                database.AddInParameter(command, "DeliveryDt", System.Data.DbType.String, _obj.DeliveryDt);
                database.AddInParameter(command, "DeliveryProofID", System.Data.DbType.String, _obj.DeliveryProofID);
                database.AddInParameter(command, "NoticeReturnDt", System.Data.DbType.String, _obj.NoticeReturnDt);
                database.AddInParameter(command, "NoticePublication_YN", System.Data.DbType.String, _obj.NoticePublication_YN);

                database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _obj._MenuID);
                database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _obj._BranchCode);
                database.AddInParameter(command, "DateCreateModifyApproved", System.Data.DbType.String, _obj.DateCreateModifyApproved);
                database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _obj._CreatetedModifiedBy);                
                database.AddInParameter(command, "EntityKey", System.Data.DbType.Int32, 0);
                database.AddInParameter(command, "Remark", System.Data.DbType.String, _obj._Remark);
                database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _obj._OperationFlag);
                database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _obj._AuthMode);
                database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _obj._TimeKey);
                database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _obj._EffectiveFromTimeKey);
                database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _obj._EffectiveToTimeKey);
                database.AddInParameter(command, "ChangedFields", System.Data.DbType.String, _obj._ChangedFields);
                database.AddInParameter(command, "D2Ktimestamp", System.Data.DbType.Int32, _obj._D2Ktimestamp);
                database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                database.ExecuteNonQuery(command);
            }

            return (int)(command.Parameters)[command.Parameters.Count - 1].Value;
        }
    }
}