﻿using CrisMAc.Models;
using CrisMAc.Models.Utility;
using CrisMAcAPI.Models.Utility;
using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace CrisMAcAPI.Models
{

    public class StockStatementDetail_M : CommonProperties
    {
        //private string dueDate;  // the name field
        // public string DueDate { get { return dueDate; } set { dueDate = value; } }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string AccountId { get; set; }
        public int EntityKey { get; set; }
        public Nullable<int> CustomerEntityId { get; set; }
        public string DueDate { get; set; }
        public string DtofStockStatement { get; set; }
        public string InspectorName { get; set; }
        public string Periodicity { get; set; }
        public string InspectionRemark { get; set; }
        public string DtofSubmission { get; set; }
        public string DtofInspection { get; set; }
        public Nullable<decimal> OS_RawMaterial { get; set; }
        public Nullable<decimal> OS_SemiFinishedDoods { get; set; }
        public Nullable<decimal> OS_FinishedGoods { get; set; }
        public Nullable<decimal> Purchase_Rowmaterial { get; set; }
        public Nullable<decimal> Purchase_SemiFinishedDoods { get; set; }
        public Nullable<decimal> Purchase_FinishedGoods { get; set; }
        public Nullable<decimal> Sales_Rowmaterial { get; set; }
        public Nullable<decimal> Sales_SemiFinishedDoods { get; set; }
        public Nullable<decimal> Sales_FinishedGoods { get; set; }
        public Nullable<decimal> Obsolete_Rowmaterial { get; set; }
        public Nullable<decimal> Obsolete_SemiFinishedDoods { get; set; }
        public Nullable<decimal> Obsolete_FinishedGoods { get; set; }
        public Nullable<decimal> OB_SundryDebtors { get; set; }
        public Nullable<decimal> Sales_SundryDebtors { get; set; }
        public Nullable<decimal> Collection_SundryDebtors { get; set; }
        public Nullable<decimal> BadDebts_SundryDebtors { get; set; }
        public Nullable<decimal> OB_SundryCreditors { get; set; }
        public Nullable<decimal> Purchases_SundryCreditors { get; set; }
        public Nullable<decimal> Payment_SundryCreditors { get; set; }
        public Nullable<decimal> LessMarginPercentage { get; set; }
        public Nullable<decimal> ExcessLmt { get; set; }
        public Nullable<decimal> AvailableLmt { get; set; }
        public string AuthorisationStatus { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<System.DateTime> DateApproved { get; set; }
        public string ChangedFields { get; set; }
        public Nullable<decimal> closingStockRawMat { get; set; }
        public Nullable<decimal> closingSemiFurnished { get; set; }
        public Nullable<decimal> closingFurnished { get; set; }
        public Nullable<decimal> closingTotalStock { get; set; }
        public Nullable<decimal> TotalOS { get; set; }
        public Nullable<decimal> TotalPurchased { get; set; }
        public Nullable<decimal> TotalSale { get; set; }
        public Nullable<decimal> TotalObsolute { get; set; }
        public Nullable<decimal> SundryDebtors { get; set; }
        public Nullable<decimal> SundryCreditor { get; set; }
        public int mode { get; set; }
        public string CustomerACID { get; set; }
        public int AccountEntityId { get; set; }
        public int TimeKey { get; set; }
        public void Select_AdvacStockStatement()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityID", CustomerEntityId),
                                               new SqlParameter("@AccountEntityID", _AccountEntityId),
                                               new SqlParameter("@BranchCode", _BranchCode),
                                               new SqlParameter("@Mode", _OperationFlag),
                                               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "EWS.StockStatementSelect";
            ExecuteSelect();
        }
        public void Insert_AdvacStockStatement()
        {
            //UtilityWebGenric objUtilityWebGen = new UtilityWebGenric("EWS.StockStatementInsertUpdate");
            //objUtilityWebGen.addParam("EntityKey", EntityKey, 'I');
            //objUtilityWebGen.addParam("CustomerEntityID	", CustomerEntityId, 'I');
            //objUtilityWebGen.addParam("IsEmployee", objUserMaintanance.IsEmployee, 'I');
            //objUtilityWebGen.addParam("UserName", objUserMaintanance._userName, 'I');
            //objUtilityWebGen.addParam("UserLoginID", objUserMaintanance._userLoginId, 'I');
            //objUtilityWebGen.addParam("EmployeeID	", objUserMaintanance.EmployeeID, 'I');
            //objUtilityWebGen.addParam("IsEmployee", objUserMaintanance.IsEmployee, 'I');
            //objUtilityWebGen.addParam("UserName", objUserMaintanance._userName, 'I');
            //objUtilityWebGen.addParam("UserLoginID", objUserMaintanance._userLoginId, 'I');
            //objUtilityWebGen.addParam("EmployeeID	", objUserMaintanance.EmployeeID, 'I');
            //objUtilityWebGen.addParam("IsEmployee", objUserMaintanance.IsEmployee, 'I');
            //objUtilityWebGen.addParam("UserName", objUserMaintanance._userName, 'I');

            sqlParams = new SqlParameter[] {
                                 new SqlParameter("@EntityKey", EntityKey),
                                new SqlParameter("@CustomerEntityID", CustomerEntityId),
                                new SqlParameter("@AccountEntityID ",AccountEntityId),
                                new SqlParameter("@Periodicity",Periodicity),
                                new SqlParameter("@DueDate",DueDate),
                                new SqlParameter("@DtofStockStatement",DtofStockStatement),
                                new SqlParameter("@DtofSubmission",DtofSubmission),
                                new SqlParameter("@DtofInspection",DtofInspection),
                                new SqlParameter("@OS_RawMaterial",OS_RawMaterial),
                                new SqlParameter("@OS_SemiFinishedDoods",OS_SemiFinishedDoods),
                                new SqlParameter("@OS_FinishedGoods",OS_FinishedGoods),
                                new SqlParameter("@Purchase_Rowmaterial",Purchase_Rowmaterial),
                                new SqlParameter("@Purchase_SemiFinishedDoods",Purchase_SemiFinishedDoods),
                                new SqlParameter("@Purchase_FinishedGoods",Purchase_FinishedGoods),
                                new SqlParameter("@Sales_Rowmaterial",Sales_Rowmaterial),
                                new SqlParameter("@Sales_SemiFinishedDoods",Sales_SemiFinishedDoods),
                                new SqlParameter("@Sales_FinishedGoods",Sales_FinishedGoods),
                                new SqlParameter("@Obsolete_Rowmaterial",Obsolete_Rowmaterial),
                                new SqlParameter("@Obsolete_SemiFinishedDoods",Obsolete_SemiFinishedDoods),
                                new SqlParameter("@Obsolete_FinishedGoods",Obsolete_FinishedGoods),
                                new SqlParameter("@OB_SundryDebtors",OB_SundryDebtors),
                                new SqlParameter("@Sales_SundryDebtors",Sales_SundryDebtors),
                                new SqlParameter("@Collection_SundryDebtors",Collection_SundryDebtors),
                                new SqlParameter("@BadDebts_SundryDebtors",BadDebts_SundryDebtors),
                                new SqlParameter("@OB_SundryCreditors",OB_SundryCreditors),
                                new SqlParameter("@Purchases_SundryCreditors", Purchases_SundryCreditors ),
                                new SqlParameter("@Payment_SundryCreditors", Payment_SundryCreditors),
                                new SqlParameter("@LessMarginPercentage",LessMarginPercentage),
                                new SqlParameter("@ExcessLmt",ExcessLmt),
                                new SqlParameter("@AvailableLmt",AvailableLmt),
                                new SqlParameter("@InspectionBy",InspectorName),
                                new SqlParameter("@InspectionRemark",InspectionRemark),
                                new SqlParameter("@EffectiveFromTimeKey",_EffectiveFromTimeKey),
                                new SqlParameter("@EffectiveToTimeKey",_EffectiveToTimeKey),
                                new SqlParameter("@DateApproved", DateApproved),
                                new SqlParameter("@ApprovedBy",_ApprovedBy ),
                                new SqlParameter("@OperationFlag", _OperationFlag),
                                new SqlParameter("@D2Ktimestamp",_D2Ktimestamp),
                                new SqlParameter("@BranchCode",_BranchCode),
                                new SqlParameter("@TimeKey",_TimeKey),
                                new SqlParameter("@AuthMode",_AuthMode),
                                new SqlParameter("@MenuID",_MenuID ),
                                new SqlParameter("@Remark",_Remark),
                                new SqlParameter("@ChangedField",ChangedFields),
                                new SqlParameter("@ScreenEntityId", "")
            };

            spName = "EWS.StockStatementInsertUpdate";
            ExecuteInsert();
        }
        public void Select_StockStatementAux()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@BranchCode", _BranchCode ),
                                               new SqlParameter("@Mode", _OperationFlag ),
                                               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "EWS.StockStatementAuxSelect";
            ExecuteSelect();
        }
        public void Select_StockStatementParameterised(char blnYNStr)
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@blnAttributes", blnYNStr)
                };
            spName = "[EWS].[StockStatementParmatrised]";
            ExecuteSelectDataSet();
        }
    }
}