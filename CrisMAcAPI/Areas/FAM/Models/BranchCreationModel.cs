﻿using CrisMAc.Models;
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
    public class BranchCreationModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string BranchCode { get; set; }
        public string TempBranchCode { get; set; }
        public string BranchName { get; set; }
        public string ASolId { get; set; }
        public string RSolId { get; set; }
        public int RegionAlt_Key { get; set; }
        public string RegionName { get; set; }
        public string ZoneAlt_Key { get; set; }
        public string ZoneName { get; set; }
        public int BranchAreaCategoryAlt_Key { get; set; }
        public string BranchAreaCategory { get; set; }
        public int BranchStateAlt_Key { get; set; }
        public string BranchStateName { get; set; }
        public int BranchDistrictAlt_Key { get; set; }
        public string BranchDistrictName { get; set; }
        public string Add_1 { get; set; }
        public string Add_2 { get; set; }
        public string Place { get; set; }
        public string PinCode { get; set; }
        public string CityAlt_Key { get; set; }
        public string CityName { get; set; }
        public string RBI_LicenceNo { get; set; }
        public string RBI_LicenceDt { get; set; }
        public string AuthorisationNo { get; set; }
        public string AuthorisationDt { get; set; }
        public string RBI_Part_1 { get; set; }
        public string RBI_Part_2 { get; set; }
        public string BranchOpenDt { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string NonWorkingDay { get; set; }
        public string NonBankingDay { get; set; }
        public string Assgn_SolID { get; set; }
        public string ApplicableSolId { get; set; }
        public string ReAssgn_SolID { get; set; }
        public string ScreenFlag { get; set; }
        public string BranchSearchString { get; set; }
        public int flag { get; set; }

        //Aux
        public DataSet BranchAuxData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("BranchAuxData");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, BranchCode);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "@ScreenFlag", System.Data.DbType.String, ScreenFlag);
                    database.AddInParameter(command, "@RegionAlt_Key", System.Data.DbType.Int32, RegionAlt_Key);
                    database.AddInParameter(command, "@ZoneAlt_Key", System.Data.DbType.Int32, ZoneAlt_Key);
                    database.AddInParameter(command, "@BranchSearchString", System.Data.DbType.String, BranchSearchString);
                    database.AddInParameter(command, "@flag", System.Data.DbType.Int32, flag);
                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Select fetch
        public DataSet FetchBranchDetails()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("BranchSelectData");
            DataSet ds = new DataSet();

            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, BranchCode);
                    database.AddInParameter(command, "@TempBranchCode", System.Data.DbType.String, TempBranchCode);
                    database.AddInParameter(command, "@ZoneAlt_Key", System.Data.DbType.Int32, ZoneAlt_Key);
                    database.AddInParameter(command, "@RegionAlt_Key", System.Data.DbType.Int32, RegionAlt_Key);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "@Mode", System.Data.DbType.String, _OperationFlag);
                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //InsertUpdate
        public object BranchInsertUpdateData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("BranchInsertUpdateData");
            DataSet ds = new DataSet();

            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, BranchCode);
                    database.AddInParameter(command, "@TempBranchCode", System.Data.DbType.String, TempBranchCode);
                    database.AddInParameter(command, "@BranchName", System.Data.DbType.String, BranchName);
                    database.AddInParameter(command, "@ApplicableSolId", System.Data.DbType.String, ApplicableSolId);
                    database.AddInParameter(command, "@ASolId", System.Data.DbType.String, ASolId);
                    database.AddInParameter(command, "@RSolId", System.Data.DbType.String, RSolId);
                    database.AddInParameter(command, "@BranchRegionAlt_Key", System.Data.DbType.Int32, RegionAlt_Key);
                    database.AddInParameter(command, "@BranchRegion", System.Data.DbType.String, RegionName);
                    database.AddInParameter(command, "@BranchZoneAlt_Key", System.Data.DbType.String, ZoneAlt_Key);
                    database.AddInParameter(command, "@BranchZone", System.Data.DbType.String, ZoneName);
                    database.AddInParameter(command, "@BranchAreaCategoryAlt_Key", System.Data.DbType.Int32, BranchAreaCategoryAlt_Key);
                    database.AddInParameter(command, "@BranchAreaCategory", System.Data.DbType.String, BranchAreaCategory);
                    database.AddInParameter(command, "@BranchStateAlt_Key", System.Data.DbType.Int32, BranchStateAlt_Key);
                    database.AddInParameter(command, "@BranchStateName", System.Data.DbType.String, BranchStateName);
                    database.AddInParameter(command, "@BranchDistrictAlt_Key", System.Data.DbType.Int32, BranchDistrictAlt_Key);
                    database.AddInParameter(command, "@BranchDistrictName", System.Data.DbType.String, BranchDistrictName);
                    database.AddInParameter(command, "@Address1", System.Data.DbType.String, Add_1);
                    database.AddInParameter(command, "@Address2", System.Data.DbType.String, Add_2);
                    database.AddInParameter(command, "@Place", System.Data.DbType.String, Place);
                    database.AddInParameter(command, "@PinCode", System.Data.DbType.String, PinCode);
                    database.AddInParameter(command, "@CityAlt_Key", System.Data.DbType.String, CityAlt_Key);
                    database.AddInParameter(command, "@RBILicenseNo", System.Data.DbType.String, RBI_LicenceNo);
                    database.AddInParameter(command, "@RBILicenseDate", System.Data.DbType.String, RBI_LicenceDt);
                    database.AddInParameter(command, "@AuthorizationNo ", System.Data.DbType.String, AuthorisationNo);
                    database.AddInParameter(command, "@AuthorizationDate ", System.Data.DbType.String, AuthorisationDt);
                    database.AddInParameter(command, "@RBIPart1 ", System.Data.DbType.String, RBI_Part_1);
                    database.AddInParameter(command, "@RBIPart2 ", System.Data.DbType.String, RBI_Part_2);
                    database.AddInParameter(command, "@BranchOpenDate ", System.Data.DbType.String, BranchOpenDt);
                    database.AddInParameter(command, "@OpenTime ", System.Data.DbType.String, OpenTime);
                    database.AddInParameter(command, "@CloseTime ", System.Data.DbType.String, CloseTime);
                    database.AddInParameter(command, "@NonWorkingDay ", System.Data.DbType.String, NonWorkingDay);
                    database.AddInParameter(command, "@NonBankingDay ", System.Data.DbType.String, NonBankingDay);
                    database.AddInParameter(command, "@Assgn_SolID ", System.Data.DbType.String, Assgn_SolID);
                    database.AddInParameter(command, "@ReAssgn_SolID ", System.Data.DbType.String, ReAssgn_SolID);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
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
                    //ds = database.ExecuteDataSet(command);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());

            return DBReturnResult;
        }
        //sol id assign
        public DataSet SolidAuxData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("BranchSOLIDFetch");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                   // database.AddInParameter(command, "@screenFlag", System.Data.DbType.String, ScreenFlag);
                    database.AddInParameter(command, "@UserLoginId", System.Data.DbType.String, _userLoginId);

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}