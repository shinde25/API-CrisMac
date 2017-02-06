﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrisMAc.Models;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;

namespace CrisMAcAPI.Models
{
    public class CompanyWiseExchSymbolModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string xmlDocument { get; set; }
        public string Company_Industry_Name { get; set; }
        public int Comp_Cust_Altkey { get; set; }
        public int CompAltKey { get; set; }
        public int CustAltKey { get; set; }
        public string CustomerCompany { get; set; }
        public void CompanyWiseExchSymbolAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                                new SqlParameter("@SearchString", Company_Industry_Name),
                                                new SqlParameter("@BranchCode", _BranchCode),
                                                new SqlParameter("@Mode", _OperationFlag),
                                                new SqlParameter("@TimeKey",_TimeKey),
                                                new SqlParameter("@CustomerCompany",CustomerCompany)
                                               
                                           };

            spName = "EWS.CompanyWiseExchSymbolAuxSelect";
            ExecuteSelectDataSet();
        }

        public void CompanyWiseExchSymbolFetch()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerCompanyID", Comp_Cust_Altkey),
                                               new SqlParameter("@BranchCode", _BranchCode),
                                               new SqlParameter("@Mode", _OperationFlag),
                                               new SqlParameter("@TimeKey", _TimeKey),
                                               new SqlParameter("@CustomerCompany",CustomerCompany)
                };
            spName = "[EWS].[CompanyWiseExchSymbolSelect]";
            ExecuteSelectDataSet();
        }

        public object CompanyWiseExchSymbolSave()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[CompanyWiseExchSymbolInsertUpdate]");

            try
            {
                using (command)
                {
                    database.AddInParameter(command, "xmlDocument", System.Data.DbType.String, xmlDocument);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "DATECreateModifyApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "CustomerCompany", System.Data.DbType.String, CustomerCompany);
                    database.AddInParameter(command, "CustomerEntityId", System.Data.DbType.Int32, CustAltKey);
                    database.AddInParameter(command, "CompanyAlt_Key", System.Data.DbType.Int32, CompAltKey);
                    database.AddOutParameter(command, "_D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
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