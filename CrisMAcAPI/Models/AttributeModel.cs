using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models
{
    public class AttributeModel: CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string AttributesXMLString { get; set; }
        public int SubParameterAlt_Key { get; set; }
        public int ParameterAlt_Key { get; set; }
        public int EWS_ParameterAlt_Key { get; set; }
        public int EWS_SegmentAlt_Key { get; set; }
        public string ParamType { get; set; }
        public void EWSAttributesSelect()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@EWS_SubParameterAlt_Key",SubParameterAlt_Key),
                                               new SqlParameter("@EWS_ParameterAlt_Key", ParameterAlt_Key),
                                               new SqlParameter("@EWS_SegmentAlt_Key", EWS_SegmentAlt_Key),
                                               new SqlParameter("@Mode", _OperationMode),
                                               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[AttributesSelect]";
            ExecuteSelectDataSet();
        }
        public void EWSAttributesAuxSelect()
        {
            //sqlParams = new SqlParameter[] {
            //                                   new SqlParameter("@EWS_SegmentAlt_Key",EWS_SegmentAlt_Key),
            //                                   new SqlParameter("@EWS_ParameterAlt_Key", EWS_ParameterAlt_Key),
            //                                   new SqlParameter("@Mode", _OperationMode),
            //                                   new SqlParameter("@TimeKey", _TimeKey)
            //    };
            //spName = "[EWS].[AttributesAuxSelect]";
            //ExecuteSelectDataSet();

            sqlParams = new SqlParameter[] {
                                                  new SqlParameter("@Mode", _OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey),
                                                   new SqlParameter("@ParamType", ParamType),
                                                   new SqlParameter("@EWS_SegmentAlt_Key", EWS_SegmentAlt_Key),
                                                   new SqlParameter("@EWS_ParameterAlt_Key",EWS_ParameterAlt_Key)

                };
            spName = "[EWS].[Attributes_Segment_Parameter_AuxSelect]";
            ExecuteSelectDataSet();
        }
        public void EWSAttributesParameterised(char blnYNStr)
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@blnAttributes", blnYNStr)
                };
            spName = "[EWS].[AttributesParameterised]";
            ExecuteSelectDataSet();
        }
        public int EWSAttributesInsertUpdate()
        {
            //sqlParams = new SqlParameter[] {
            //                                   new SqlParameter("@xmlDocument", AttributesXMLString),
            //                                   new SqlParameter("@MenuID", _MenuID),
            //                                   new SqlParameter("@DATECreateModifyApproved", DateTime.Now),
            //                                   new SqlParameter("@Remark", _Remark),
            //                                   new SqlParameter("@OperationFlag", _OperationFlag),
            //                                   new SqlParameter("@AuthMode", _AuthMode),
            //                                   new SqlParameter("@TimeKey", _TimeKey),
            //                                   new SqlParameter("@EffectiveFromTimeKey", _EffectiveFromTimeKey),
            //                                   new SqlParameter("@EffectiveToTimeKey", _EffectiveToTimeKey),
            //                                   new SqlParameter("@CreateModifyApprovedBy", _CreatetedModifiedBy),

            //    };
            //spName = "[EWS].[AttributesInsertUpdate]";
            //ExecuteInsert();

            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[AttributesInsertUpdate]");

            try
            {


                using (command)
                {
                    database.AddInParameter(command, "xmlDocument", System.Data.DbType.String, AttributesXMLString);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "DATECreateModifyApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                  
                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);

                    database.ExecuteNonQuery(command);
                }


            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
            return (int)(command.Parameters)[command.Parameters.Count - 1].Value;
        }

        public void SegmentParameterAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                                  new SqlParameter("@Mode", _OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey),
                                                   new SqlParameter("@ParamType", ParamType),
                                                   new SqlParameter("@EWS_SegmentAlt_Key", EWS_SegmentAlt_Key),
                                                   new SqlParameter("@EWS_ParameterAlt_Key",EWS_ParameterAlt_Key)

                };
            spName = "[EWS].[Attributes_Segment_Parameter_AuxSelect]";
            ExecuteSelectDataSet();
        }
    }
}