using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace CrisMAcAPI.Models
{
    public class BalanceSheetModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string AsOnDate { get; set; }
        public string Customer_Company { get; set; }
        public string SearchString { get; set; }
        public string CompanyAlt_Key { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int32 CustomerEntityId { get; set; }
        public string FinYear { get; set; }
        public string Audited { get; set; }
        public string Periodicity { get; set; }
        public string QuaterEnding { get; set; }
        public string DueDate { get; set; }
        public string DtofSubmission { get; set; }
        public string xmlData { get; set; }
        public Int32 MenuID { get; set; }
        public string BranchCode { get; set; }
        public string DateCreateModifyApproved { get; set; }
        public string CreateModifyApprovedBy { get; set; }
        public Int32 EntityKey { get; set; }
        public string Remark { get; set; }
        public Int32 OperationFlag { get; set; }
        public string AuthMode { get; set; }
        public Int32 TimeKey { get; set; }
        public Int32 EffectiveFromTimeKey { get; set; }
        public Int32 EffectiveToTimeKey { get; set; }
        public string ChangedFields { get; set; }
        public Int32 D2Ktimestamp { get; set; }
        public string EWS_BS_SegmentSubGroup { get; set; }
        public string Particulars { get; set; }
        public string InputCategory { get; set; }
        public decimal Amount { get; set; }
        public Int32 EWS_BS_ItemsAlt_Key { get; set; }
        public int InputCategoryAlt_Key { get; set; }

        public void BalanceSheetDetailSelectParameterised()
        {
            spName = "EWS.BalanceSheetDetailSelectParameterised";
            ExecuteSelectDataSet();
        }

        public void BalanceSheetDetailSelect(string Customer_Company, string AsOnDate, string QuaterEnding,
            string Periodicity, string Audited, string FinYear, int _CustomerEntityID)
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@FinYear",FinYear),
                                               new SqlParameter("@Audited", Audited),
                                               new SqlParameter("@Periodicity", Periodicity),
                                               new SqlParameter("@QuaterEnding", QuaterEnding),
                                               new SqlParameter("@AsOnDate", AsOnDate),
                                               new SqlParameter("@Customer_Company", Customer_Company),
                                               new SqlParameter("@BranchCode", _BranchCode),
                                               new SqlParameter("@TimeKey",_TimeKey),
                                               new SqlParameter("@CustomerCompanyID", _CustomerEntityID),
                                               new SqlParameter("@Mode", _OperationFlag)
                };

            spName = "EWS.BalanceSheetDetailSelect";
            ExecuteSelectDataSet();
        }

        public void BalanceSheetDetailAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@BranchCode", _BranchCode),
                                               new SqlParameter("@Mode", _OperationFlag),
                                               new SqlParameter("@TimeKey", _TimeKey),
                                               new SqlParameter("@CustomerCompany", Customer_Company),
                                               new SqlParameter("@CoSearchString", SearchString)
                };

            spName = "EWS.BalanceSheetDetailAuxSelect";
            ExecuteSelectDataSet();
        }


        public int Call_BalanceSheetDetailInsertUpdate(BalanceSheetModel _obj)
        {
            Database database = factory.Create("ConnStringDecr");
            //Database database = factory.Create("ConnStringOracle");

            ///////////////////////////////////////// CODE FOR SQL //////////////////////////////////////////////////

            DbCommand command = database.GetStoredProcCommand("EWS.BalanceSheetDetailInsertUpdate");

            using (command)
            {
                database.AddInParameter(command, "CustomerEntityId", System.Data.DbType.Int32, _obj.CustomerEntityId);
                database.AddInParameter(command, "CompanyAlt_Key", System.Data.DbType.Int32, _obj.CompanyAlt_Key);
                database.AddInParameter(command, "FinYear", System.Data.DbType.String, _obj.FinYear);
                database.AddInParameter(command, "Audited", System.Data.DbType.String, _obj.Audited);
                database.AddInParameter(command, "Periodicity", System.Data.DbType.String, _obj.Periodicity);
                database.AddInParameter(command, "QuaterEnding", System.Data.DbType.String, _obj.QuaterEnding);
                database.AddInParameter(command, "AsOnDate", System.Data.DbType.String, _obj.DueDate);
                database.AddInParameter(command, "Customer_Company", System.Data.DbType.String, _obj.Customer_Company);
                //database.AddInParameter(command, "DtofSubmission", System.Data.DbType.String, _obj.DtofSubmission);
                database.AddInParameter(command, "xmlData", System.Data.DbType.String, _obj.xmlData);
                database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _obj.MenuID);
                database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _obj.BranchCode);
                database.AddInParameter(command, "DateCreateModifyApproved", System.Data.DbType.String, _obj.DateCreateModifyApproved);
                database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _obj.CreateModifyApprovedBy);
                database.AddInParameter(command, "EntityKey", System.Data.DbType.Int32, _obj.EntityKey);
                database.AddInParameter(command, "Remark", System.Data.DbType.String, _obj.Remark);
                database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _obj.OperationFlag);
                database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _obj.AuthMode);
                database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _obj.TimeKey);
                database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _obj.EffectiveFromTimeKey);
                database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _obj.EffectiveToTimeKey);
                database.AddInParameter(command, "ChangedFields", System.Data.DbType.String, _obj.ChangedFields);
                database.AddOutParameter(command, "D2Ktimestamp", System.Data.DbType.Int32, _obj.D2Ktimestamp);
                database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);

                database.ExecuteNonQuery(command);
            }

            return (int)(command.Parameters)[command.Parameters.Count - 1].Value;

            ///////////////////////////////////////////////////////////////////////////////////////



            ///////////////////////////////////// CODE FOR ORACLE  //////////////////////////////////////////////////
            //Dictionary<string, dynamic> saveLst = new Dictionary<string, dynamic>();
            //UtilityWebGenric ug = new UtilityWebGenric("TEST_INSERT");
            //ug.addParam("id", _obj.CustomerEntityId,'I');
            //ug.addParam("fNAME", _obj.FinYear, 'I');
            //ug.addParam("LnAME", _obj.Periodicity, 'I');


            //ug.ExecuteInsert();
            ///////////////////////////////////////////////////////////////////////////////////////




            ////////////////////////CODE FOR MYSQL  ///////////////////////////////////////////////////////////////
            //Dictionary<string, dynamic> saveLst = new Dictionary<string, dynamic>();
            //saveLst.Add("p_id", _obj.CustomerEntityId);
            //saveLst.Add("p_fname", _obj.FinYear);
            //saveLst.Add("p_lname", _obj.Periodicity);

            //UtilityWebGenric ug = new UtilityWebGenric();
            //ug.ExecuteInsert("sp_test_INSERT", saveLst);
            ///////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
