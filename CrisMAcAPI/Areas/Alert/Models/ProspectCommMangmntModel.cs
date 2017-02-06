﻿using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.Alert.Models
{
    public class ProspectCommMangmntModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public string CustomerName { get; set; }
        public string TabFlag { get; set; }

        public string ProspectID { get; set; }
        public int NoticeTypeAlt_Key { get; set; }
        public string PrintDate { get; set; }
        public string PrintCnfrmDate { get; set; }
        public int DispatchModeAlt_Key { get; set; }
        public string DispatchDate { get; set; }
        public string DispatchProofID { get; set; }
        public int Result { get; set; }
        public string DateCreateModifyApproved { get; set; }

        public void ProspectCommMangmentAuxSelect(ProspectCommMangmntModel obj)
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@TimeKey", obj._TimeKey),
                                               new SqlParameter("@NoticeTypeAlt_Key", obj.NoticeTypeAlt_Key),
                                               new SqlParameter("@TabFlag", obj.TabFlag),
                                               new SqlParameter("@UserLoginId", _userLoginId)
                };
            spName = "ALERT.ProspectCommMangmentAuxSelect";
            ExecuteSelect();
        }

        public int ProspectNoticePrint_InsertUpdate(ProspectCommMangmntModel _obj)
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("ALERT.ProspectNoticePrint_InsertUpdate");
            using (command)
            {
                database.AddInParameter(command, "ProspectID", System.Data.DbType.String, _obj.ProspectID);
                database.AddInParameter(command, "TabFlag", System.Data.DbType.String, _obj.TabFlag);
                database.AddInParameter(command, "NoticeTypeAlt_Key", System.Data.DbType.Int32, _obj.NoticeTypeAlt_Key);
                database.AddInParameter(command, "PrintDate", System.Data.DbType.String, _obj.PrintDate);
                database.AddInParameter(command, "PrintCnfrmDate", System.Data.DbType.String, _obj.PrintCnfrmDate);
                database.AddInParameter(command, "DispatchModeAlt_Key", System.Data.DbType.Int32, _obj.DispatchModeAlt_Key);
                database.AddInParameter(command, "DispatchDate", System.Data.DbType.String, _obj.DispatchDate);
                database.AddInParameter(command, "DispatchProofID", System.Data.DbType.String, _obj.DispatchProofID);
                database.AddInParameter(command, "DateCreateModifyApproved", System.Data.DbType.String, _obj.DateCreateModifyApproved);
                database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _obj._CreatetedModifiedBy);
                database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _obj._TimeKey);
                database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                database.ExecuteNonQuery(command);
            }
            return (int)(command.Parameters)[command.Parameters.Count - 1].Value;
        }

        public void ProspectCommMangment_ParameterisedMaster()
        {
            spName = "ALERT.ProspectCommMangment_ParameterisedMaster";
            ExecuteSelectDataSet();
        }

        public void GetProspectContent()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@ProspectID", ProspectID),
                                               new SqlParameter("@NoticeTypeAlt_Key", NoticeTypeAlt_Key),
                                               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "ALERT.GetProspectNoticeContent";
            ExecuteSelect();
        }

        public void GetCustomerForSMS()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@ProspectID", ProspectID),
                                               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "ALERT.GetCustomerForSMS";
            ExecuteSelect();
        }
    }
}