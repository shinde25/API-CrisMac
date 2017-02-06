﻿using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.IFAM_Premises.Models
{
    public class CommonPremiseModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public string ScreenType { get;  set; }
        public string UserLoginID { get; set; }
        public int AssetBlockAlt_Key { get;  set; }
        public string TxnType { get; set; }
        public int AssetSubBlockAlt_Key { get; set; }
        public string AssetSearchString { get; set; }
        public string AssetLocation { get; set; }
        public object TxnStatus { get; private set; }
        public object TxnDateFrom { get; private set; }
        public object TxnDateTo { get; private set; }
        public string AssetGrid { get; set; }
        public int AssetEntityId { get; set; }
        public int ParentAssetEntityId { get; set; }
       // public string DateCreateModifyApproved { get; set; }
      //  public string AssetTagAutoGen { get; set; }



        


        public DataSet CommonNewAssetSelect()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("PrmsAssetPurchaseSelect");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                  //  database.AddInParameter(command, "ScreenType", System.Data.DbType.String, ScreenType);
                  //  database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
            
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "AssetEntityId", System.Data.DbType.Int32, AssetEntityId);
                    database.AddInParameter(command, "TxnType", System.Data.DbType.String, TxnType);
                    database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, _userLoginId);
                    database.AddInParameter(command, "Mode", System.Data.DbType.String, _OperationMode);
                    database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.String, AssetBlockAlt_Key);

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet CommonTxnSelect()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("PrmsAssetTxnSelect");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "AssetEntityId", System.Data.DbType.Int32, AssetEntityId);
                    database.AddInParameter(command, "TxnType", System.Data.DbType.String, TxnType);
                    database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, _userLoginId);
                    database.AddInParameter(command, "Mode", System.Data.DbType.String, _OperationMode);
                  //  database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_Key);
                   // database.AddInParameter(command, "AssetSubBlockAlt_Key", System.Data.DbType.Int32, AssetSubBlockAlt_Key);
                   // database.AddInParameter(command, "AssetSearchString", System.Data.DbType.String, AssetSearchString);
                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        //public DataSet CommonTxnSelect()
        //{
        //    Database database = factory.Create("ConnStringDecr");
        //    DbCommand command = database.GetStoredProcCommand("PrmsAssetDetailSelect");
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (command)
        //        {
        //            database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
        //            database.AddInParameter(command, "AssetEntityId", System.Data.DbType.Int32, AssetEntityId);
        //            database.AddInParameter(command, "TxnType", System.Data.DbType.String, TxnType);
        //            database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, _userLoginId);
        //            database.AddInParameter(command, "Mode", System.Data.DbType.String, _OperationMode);
        //            ds = database.ExecuteDataSet(command);
        //        }
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public DataSet CBSTxn_System()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("SystemTxnIdValidate");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    //database.AddInParameter(command, "@TxnIdData1", System.Data.DbType.String, ValidationString);
                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet TransactionHistory()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("TransactionHistorySelect");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
                    //database.AddInParameter(command, "AssetEntityID ", System.Data.DbType.String, AssetEntityId);
                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //iNSEDRT UPDATE FOR ADDITION, PURCHASE AND REPLICATION
        public object CommonNewAssetInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("PrmsAssetPurchaseInsertUpdate");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@xmlDocument", System.Data.DbType.String, AssetGrid);
                    database.AddInParameter(command, "@AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_Key);
                    database.AddInParameter(command, "@AssetSubBlockAlt_Key", System.Data.DbType.Int32, AssetSubBlockAlt_Key);
                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "@TxnType", System.Data.DbType.String, TxnType);
                    database.AddInParameter(command, "@AssetEntityId", System.Data.DbType.Int32, AssetEntityId);
                    database.AddInParameter(command, "@ParentAssetEntityId", System.Data.DbType.Int32, ParentAssetEntityId);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@DATECreateModifyApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    
                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
                    database.AddOutParameter(command, "@AssetTagAutoGen", System.Data.DbType.String, 100);
                    //database.AddParameter(command, "@AssetTagAutoGen", System.Data.DbType.String, ParameterDirection.InputOutput, AssetTagAutoGen, DataRowVersion.Current, AssetTagAutoGen);
                    

                    database.ExecuteNonQuery(command);

                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("AssetTagAutoGen", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 3].Value.ToString());
            //DBReturnResult = new
            //{
            //    Result = (command.Parameters)[command.Parameters.Count - 1].Value,
            //    D2Ktimestamp = (command.Parameters)[command.Parameters.Count - 2].Value
            //};
            return DBReturnResult;
        }

        public object CommonTxnInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetTxnInsertUpdate");
            try
            {
                using (command)
                {
                    //database.AddInParameter(command, "@AssetEntityId", System.Data.DbType.Int32, AssetEntityId);
                    database.AddInParameter(command, "@TxnType", System.Data.DbType.String, TxnType);
                    //database.AddInParameter(command, "@TxnRefNo", System.Data.DbType.String, TxnRefNo);
                    //database.AddInParameter(command, "@TransporModeAlt_Key", System.Data.DbType.Int16, TransporModeAlt_Key);
                    //database.AddInParameter(command, "@DisposalReasonAlt_Key", System.Data.DbType.Int16, DisposalReasonAlt_Key);
                    //database.AddInParameter(command, "@DisposalTo", System.Data.DbType.String, DisposalTo);
                    //database.AddInParameter(command, "@ProfitOrLoss", System.Data.DbType.String, ProfitOrLoss);
                    //database.AddInParameter(command, "@TxnDate", System.Data.DbType.String, TxnDate);
                    //database.AddInParameter(command, "@TxnBranch", System.Data.DbType.String, TxnBranch);
                    //database.AddInParameter(command, "@RCTxnBranch", System.Data.DbType.String, RCTxnBranch);
                    //database.AddInParameter(command, "@TxnAmount", System.Data.DbType.Decimal, TxnAmount);
                    //database.AddInParameter(command, "@TxnSysTxnId", System.Data.DbType.String, TxnSysTxnId);
                    //database.AddInParameter(command, "@TxnSysTotalDeprId", System.Data.DbType.String, TxnSysTotalDeprId);
                    //
                    //database.AddInParameter(command, "@ContactPersonName", System.Data.DbType.String, ContactPersonName);
                    //database.AddInParameter(command, "@ContactPersonEmail", System.Data.DbType.String, ContactPersonEmail);
                    //database.AddInParameter(command, "@ContactPersonMobile", System.Data.DbType.String, ContactPersonMobile);

                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "ChangedField", System.Data.DbType.String, _ChangedFields);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddOutParameter(command, "AssetTagAutoGen", System.Data.DbType.String, 100);
                    database.AddOutParameter(command, "D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("AssetTagAutoGen", (command.Parameters)[command.Parameters.Count - 3].Value.ToString());
            //DBReturnResult = new
            //{
            //    Result = (command.Parameters)[command.Parameters.Count - 1].Value,
            //    D2Ktimestamp = (command.Parameters)[command.Parameters.Count - 2].Value
            //};
            return DBReturnResult;
        }


        //public DataSet PremiseAssetTransactionMainSelect()
        //{
                   
        //    Database database = factory.Create("ConnStringDecr");
        //    DbCommand command = database.GetStoredProcCommand("PrmsAssetTxnSelect");
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (command)
        //        {
        //            database.AddInParameter(command, "ScreenType", System.Data.DbType.String, TxnType);
        //            database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
        //            database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, _userLoginId);
        //            database.AddInParameter(command, "Mode", System.Data.DbType.String, _OperationMode);
        //            database.AddInParameter(command, "AssetEntityId", System.Data.DbType.Int32, AssetEntityId);
        //            database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_Key);
        //            database.AddInParameter(command, "AssetSubBlockAlt_Key", System.Data.DbType.Int32, AssetSubBlockAlt_Key);
        //          //  database.AddInParameter(command, "AssetSearchString", System.Data.DbType.String, AssetSearchString);
        //          //  database.AddInParameter(command, "AssetLocation", System.Data.DbType.String, AssetLocation);
        //            database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);


        //            ds = database.ExecuteDataSet(command);
        //        }
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ds;
        //    }
        //}



    }
}