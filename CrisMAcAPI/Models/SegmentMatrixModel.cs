using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models
{
    public class SegmentMatrixModel:CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int EWS_SegmentAlt_Key { get; set; }
        public string SegmentMatrixJson { get; set; }


        public void SegmentMatrixParmatrised()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[SegmentMatrixParmatrised]";
            ExecuteSelectDataSet();
        }

        public void SegmentMatrixAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                                  new SqlParameter("@Mode", _OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey)

                };
            spName = "[EWS].[SegmentMatrixAuxSelect]";
            ExecuteSelectDataSet();
        }

        public void SegmentMatrixSelect()
        {
            sqlParams = new SqlParameter[] {

                                                 new SqlParameter("@EWS_SegmentAlt_Key",EWS_SegmentAlt_Key),
                                                 new SqlParameter("@TimeKey",_TimeKey),
                                                 new SqlParameter("@Mode", _OperationMode)


                };
            spName = "[EWS].[SegmentMatrixSelect]";
            ExecuteSelectDataSet();
        }

        public object SegmentMatrixInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[SegmentMatrixInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@SegmentMatrixJson", System.Data.DbType.String, SegmentMatrixJson);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@DateApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@ApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "@BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@ChangedField", System.Data.DbType.String, _EffectiveToTimeKey);
                    //database.AddInParameter(command, "@ScreenEntityId", System.Data.DbType.Int32, ScreenEntityId); 
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);

                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());

            return DBReturnResult;
        }
    }
}