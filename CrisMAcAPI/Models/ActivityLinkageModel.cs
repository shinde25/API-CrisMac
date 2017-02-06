using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace CrisMAcAPI.Models
{
    public class ActivityLinkageModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int ActivityLinkage_Key { get; set; }
        public int ActivityLinkageAlt_Key { get; set; }
        public int ActivityAlt_Key { get; set; }
        public string LinkageType { get; set; }
        public int LinkedActivityAlt_Key { get; set; }
        public decimal DependencyWt { get; set; }
        public string DateCreateModifyApproved { get; set; }
        public string CreateModifyApprovedBy { get; set; }
        public string xmlDocumentFL { get; set; }
        public string xmlDocumentBL { get; set; }

        public void ActivityLinkageAuxSelect(int _mode, int _Timekey)
        {
            sqlParams = new SqlParameter[] {
                                                new SqlParameter("@Mode", _mode),
                                                new SqlParameter("@TimeKey",_Timekey)
                                           };

            spName = "EWS.ActivityLinkageAuxSelect";
            ExecuteSelectDataSet();
        }

        public int ActivityLinkageInsertUpdate(ActivityLinkageModel _obj)
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("EWS.ActivityLinkageInsertUpdate");
            using (command)
            {
                database.AddInParameter(command, "ActivityAlt_Key", System.Data.DbType.Int32, ActivityAlt_Key);
                database.AddInParameter(command, "xmlDocumentFL", System.Data.DbType.String, xmlDocumentFL);
                database.AddInParameter(command, "xmlDocumentBL", System.Data.DbType.String, xmlDocumentBL);
                database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _obj._MenuID);
                database.AddInParameter(command, "DateCreateModifyApproved", System.Data.DbType.String, _obj.DateCreateModifyApproved);
                database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _obj.CreateModifyApprovedBy);
                database.AddInParameter(command, "Remark", System.Data.DbType.String, _obj._Remark);
                database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _obj._OperationFlag);
                database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _obj._AuthMode);
                database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _obj._TimeKey);
                database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _obj._EffectiveFromTimeKey);
                database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _obj._EffectiveToTimeKey);                
                database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                database.ExecuteNonQuery(command);
            }

            return (int)(command.Parameters)[command.Parameters.Count - 1].Value;          
        }
    }   
}