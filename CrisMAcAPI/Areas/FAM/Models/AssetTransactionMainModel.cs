﻿using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.FAM.Models
{
    public class AssetTransactionMainModel:CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();     
        public string UserLoginID { get; set; }
		public int AssetBlockAlt_Key { get; set; }
        public int AssetSubBlockAlt_Key { get; set; }
        public string Transfered { get; set; }
        public string AssetTagNo { get; set; }
        public string AssetSearchString { get; set; }
        public string TxtScreen { get; set; }
        public string ScreenType { get; set; }
        public string TxnStatus { get; set; }
        public string TxnType { get; set; }
        public string TxnDateFrom { get; set; }
        public string TxnDateTo { get; set; }
        public string PurchaseDateFrom { get; set; }
        public string PurchaseDateTo { get; set; }
        public string PurchaseAmountFrom { get; set; }
        public string PurchaseAmountTo { get; set; }



        public DataSet AssetTransactionMainParmatrised()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetTransactionMainParameterisedMasterData");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "TxtScreen", System.Data.DbType.String, TxtScreen);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public DataSet AssetTransactionMainSelect()
        {          

            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetDetailSelect");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "ScreenType", System.Data.DbType.String, TxnType);
                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_Key);
                    database.AddInParameter(command, "AssetSubBlockAlt_Key", System.Data.DbType.Int32, AssetSubBlockAlt_Key);
                    database.AddInParameter(command, "Transfered", System.Data.DbType.String, Transfered);
                    database.AddInParameter(command, "AssetTagNo", System.Data.DbType.String, AssetTagNo);
                    database.AddInParameter(command, "AssetSearchString", System.Data.DbType.String, AssetSearchString);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "PurchaseDateFrom", System.Data.DbType.String, PurchaseDateFrom);
                    database.AddInParameter(command, "PurchaseDateTo", System.Data.DbType.String, PurchaseDateTo);
                    database.AddInParameter(command, "PurchaseAmountFrom", System.Data.DbType.String, PurchaseAmountFrom);
                    database.AddInParameter(command, "PurchaseAmountTo", System.Data.DbType.String, PurchaseAmountTo);


                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        } 
        
        public DataSet AssetTransactionEnquirySelect()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetDetailSelectTxnInqry");  //AssetDetailSelectTxnInqry_Sandip
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_Key);
                    database.AddInParameter(command, "AssetSubBlockAlt_Key", System.Data.DbType.Int32, AssetSubBlockAlt_Key);
                    //database.AddInParameter(command, "Transfered", System.Data.DbType.String, Transfered);
                    database.AddInParameter(command, "AssetTagNo", System.Data.DbType.String, AssetTagNo);
                    database.AddInParameter(command, "AssetSearchString", System.Data.DbType.String, AssetSearchString);
                    database.AddInParameter(command, "TxnStatus", System.Data.DbType.String, TxnStatus);
                    database.AddInParameter(command, "TxnType", System.Data.DbType.String, TxnType);
                    database.AddInParameter(command, "TxnDateFrom", System.Data.DbType.String, TxnDateFrom);
                    database.AddInParameter(command, "TxnDateTo", System.Data.DbType.String, TxnDateTo);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }       
    }
}