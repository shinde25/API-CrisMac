using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
namespace CrisMAcAPI.Areas.FAM.Models
{
    public class AssetCommonModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int AssetBlockAlt_key { get; set; }
        public int AssetBlockAlt { get; set; }
        public string AssetBlockName { get; set; }
        public string AssetBlockShortName { get; set; }
        public string AssetBlockValidCode { get; set; }
        public int UsefulLifeYr { get; set; }
        public decimal IT_DeprRate { get; set; }
        public decimal CL_DeprRate { get; set; }
        public decimal IFRS_DeprRate { get; set; }
        public string ScreenFlag { get; set; }
        public int AssetSubBlockAlt_key { get; set; }
        public string SearchString { get; set; }
        public string AssetSubBlockName { get; set; }
        public string AssetSubBlockShortName { get; set; }
        public string ValidCode { get; set; }
        public string AssetSubBlockValidCode { get; set; }
        public string WarrantyApplicable { get; set; }
        public string AMCApplicable { get; set; }
        public string InsuranceApplicable { get; set; }

        public string D2Ktimestamp { get; set; }


        public DataSet AssetCommonAuxFetch()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetCommonAuxFetch");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "ScreenFlag", System.Data.DbType.String, ScreenFlag);
                    database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_key);
                    database.AddInParameter(command, "AssetSubBlockAlt_Key", System.Data.DbType.Int32, AssetSubBlockAlt_key);
                    database.AddInParameter(command, "AssetSearchString", System.Data.DbType.String, SearchString);
                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public DataSet AssetBlockSelect()
        {

            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetBlockSelect");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                   
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_key);
                    database.AddInParameter(command, "Mode", System.Data.DbType.String, _OperationFlag);
                    //database.AddInParameter(command, "@D2Ktimestamp", System.Data.DbType.String, D2Ktimestamp);

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            } 
            catch (Exception ex)
            {
                return ds;
            }
        }

        public object AssetBlockInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetBlockInsertUpdate");
            try
            {
                using (command)
                {
                    
                      
                    database.AddInParameter(command, "@AssetBlockAlt_key", System.Data.DbType.Int32, AssetBlockAlt_key);
                    database.AddInParameter(command, "@AssetBlockOrder_Key", System.Data.DbType.Int32, AssetBlockAlt_key);
                    database.AddInParameter(command, "@AssetBlockName", System.Data.DbType.String, AssetBlockName);
                    database.AddInParameter(command, "@AssetBlockShortName", System.Data.DbType.String, AssetBlockShortName);
                    database.AddInParameter(command, "@AssetBlockValidCode", System.Data.DbType.String, AssetBlockValidCode);
                    database.AddInParameter(command, "@UsefulLifeYr", System.Data.DbType.Int32, UsefulLifeYr);
                    database.AddInParameter(command, "@IT_DeprRate", System.Data.DbType.Decimal, IT_DeprRate);
                    database.AddInParameter(command, "@CL_DeprRate", System.Data.DbType.Decimal, CL_DeprRate);
                    database.AddInParameter(command, "@IFRS_DeprRate", System.Data.DbType.Decimal, IFRS_DeprRate);
                  
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);                 
                 
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);                   
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
            
            return DBReturnResult;
        }

        //Asset Sub Block Model
        public DataSet AssetSubBlockSelect()
        {

            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetSubBlockSelect");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {

                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "AssetBlockAlt_Key", System.Data.DbType.Int32, AssetBlockAlt_key);
                    database.AddInParameter(command, "AssetSubBlockAlt_key", System.Data.DbType.Int32, AssetSubBlockAlt_key);
                    database.AddInParameter(command, "Mode", System.Data.DbType.Int32, _OperationFlag);


                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public object AssetSubBlockInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetSubBlockInsertUpdate");
            try
            {
                using (command)
                {


                    database.AddInParameter(command, "@AssetBlockAlt_key", System.Data.DbType.Int32, AssetBlockAlt_key);
                    database.AddInParameter(command, "@AssetSubBlockAlt_key", System.Data.DbType.Int32, AssetSubBlockAlt_key);
                    database.AddInParameter(command, "@AssetSubBlockName", System.Data.DbType.String, AssetSubBlockName);
                    database.AddInParameter(command, "@AssetSubBlockShortName", System.Data.DbType.String, AssetSubBlockShortName);
                    database.AddInParameter(command, "@AssetSubBlockValidCode", System.Data.DbType.String, AssetSubBlockValidCode);
                    database.AddInParameter(command, "@WarrantyApplicable", System.Data.DbType.String, WarrantyApplicable);
                    database.AddInParameter(command, "@AMCApplicable", System.Data.DbType.String, AMCApplicable);
                    database.AddInParameter(command, "@InsuranceApplicable", System.Data.DbType.String, InsuranceApplicable);

                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);

                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
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

            return DBReturnResult;
        }




    }
    
}