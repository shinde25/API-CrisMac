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
    public class BranchMergeModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public string FromBranch { get; set; }
        public string ToBranchCode { get; set; }
        public string CloseBranchChk { get; set; }

        public string FromBranchCode { get; set; }


        public DataSet FetchBranchDetails()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("BranchMergeSelectData");
            DataSet ds = new DataSet();

            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@UserLoginID", System.Data.DbType.String, _userLoginId);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.String, _TimeKey);
                    database.AddInParameter(command, "@FromBranchCode", System.Data.DbType.String, FromBranchCode);
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

        public DataSet FetchBranchClose()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("BranchMergeClosedDataSelect");
            DataSet ds = new DataSet();

            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, FromBranchCode);
                    database.AddInParameter(command, "@IsBranchClosed", System.Data.DbType.String, CloseBranchChk);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "@UserId", System.Data.DbType.String, _userLoginId);
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
        public object BranchMergeInsertUpdateData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("BranchMergeInsertUpdate");
            DataSet ds = new DataSet();

            try
            {
                using (command)
                {

                    database.AddInParameter(command, "FromBranchCode", System.Data.DbType.String, FromBranchCode);
                    database.AddInParameter(command, "ToBranchCode", System.Data.DbType.String, ToBranchCode);
                    database.AddInParameter(command, "IsBranchClosed", System.Data.DbType.String, CloseBranchChk);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    //database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
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

    }
}