using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.Axis_MOC.Models
{
    public class CustAccountMocModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public string CustomerEntityID { get; set; }
        public string XmlData { get; set; }
        public int AssetClassAlt_key { get; set; }
        public string NPADt { get; set; }
        public Decimal SecurityValue { get; set; }
        public Decimal AddlProvPer { get; set; }
        public Char MOCType = 'C';
        public int _MocFromTimeKey { get; set; }
        public int ScreenEntitiyId { get; set; }
        public string fetchDate { get; set; }
        public string selectFlg { get; set; }
        public string AbInitio { get; set; }

        public DateTime dateCreatedmodified { get; set; }
        //public string CustomerId { get; set; } dateCreatedmodified



        #region Incorporation

        public void Incorporation()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@Customer_ID",CustomerEntityID),
                                               new SqlParameter("@TimeKey",_LastQtrDateKey),
                                               new SqlParameter("@Mode",_OperationMode)

                                              };
            spName = "[dbo].[CustAccountMocSelect]";
            ExecuteSelectDataSet();
        }

        public void Parametrice()
        {
            sqlParams = new SqlParameter[] {

                                               new SqlParameter("@TimeKey",_LastQtrDateKey)
                                              };
            spName = "[dbo].[ParametericSP]";
            ExecuteSelectDataSet();
        }

        public void CustAccountGrid()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@TimeKey", _LastQtrDateKey)
                                              };
            spName = "[dbo].[AssetClassMeta]";
            ExecuteSelectDataSet();
        }

        public object CustAccountMOCInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[dbo].[CustAccountMocInsertUpdate]");
            try
            {
                using (command)
                {

                    database.AddInParameter(command, "@CustomerId", System.Data.DbType.String, CustomerEntityID);
                    database.AddInParameter(command, "@AssetClassAlt_key", System.Data.DbType.Int32, AssetClassAlt_key);
                    database.AddInParameter(command, "@NPADt", System.Data.DbType.String, NPADt);
                    database.AddInParameter(command, "@SecurityValue", System.Data.DbType.Decimal, SecurityValue);
                    database.AddInParameter(command, "@AddlProvPer", System.Data.DbType.Decimal, AddlProvPer);
                    database.AddInParameter(command, "@AbInitio", System.Data.DbType.String, AbInitio);
                    database.AddInParameter(command, "@AccountData", System.Data.DbType.String, XmlData);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int16, _MocFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.DateTime, dateCreatedmodified);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
                    database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _LastQtrDateKey);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);

                    //database.AddInParameter(command, "@EffectChangeFromDate", System.Data.DbType.String, _MocFromTimeKey);

                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            return DBReturnResult;
        }
        #endregion


        //-------------------------------- Customer Excel Upload
        #region CustomerExcelUpload

        /*public void LastQtrDateModel()
        {
            sqlParams = new SqlParameter[]  { new SqlParameter("@TimeKey",_LastQtrDateKey) };
            spName = "[dbo].[CustAcQtrDateSelect]";
            ExecuteSelectDataSet();
        }*/

        public void ValidateExcelModel()
        {
            sqlParams = new SqlParameter[] {

                                               new SqlParameter("@MocType","C"),
                                               new SqlParameter("@XmlData",XmlData),
                                               new SqlParameter("@EffectiveFromTimeKey",_MocFromTimeKey),
                                               new SqlParameter("@EffectiveToTimeKey",_EffectiveToTimeKey),
                                               new SqlParameter("@CreateModifyApprovedBy",_CreatetedModifiedBy),
                                               new SqlParameter("@DateCreatedModifiedApproved",_dateCreatedmodified),
                                               new SqlParameter("@OperationFlag",_OperationFlag),
                                               new SqlParameter("@D2Ktimestamp",_D2Ktimestamp),
                                               new SqlParameter("@AuthMode",_AuthMode),
                                               new SqlParameter("@MenuID",_MenuID),
                                               new SqlParameter("@Remark",_Remark),
                                               new SqlParameter("@TimeKey",_LastQtrDateKey),
                                               new SqlParameter("@Result",-1)
                                              };
            spName = "[dbo].[CustAcMocUploadValidation]";
            ExecuteSelectDataSet();
        }

        public object CustExcelUploadInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[dbo].[CustMocInsertUpdate_Upld]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@XmlData", System.Data.DbType.String, XmlData);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int16, _MocFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.String, _dateCreatedmodified);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
                    database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@ScreenEntityId", System.Data.DbType.String, ScreenEntitiyId);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _LastQtrDateKey);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    //database.AddInParameter(command, "@EffectChangeFromDate", System.Data.DbType.String, _EffectiveFromTimeKey);

                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            return DBReturnResult;
        }

        public void GetExcelDataModel()
        {
            sqlParams = new SqlParameter[]   {
                        new SqlParameter("@selectFlg",selectFlg),
                        new SqlParameter("@fetchDate",fetchDate),
                        new SqlParameter("@TimeKey",_LastQtrDateKey),
                        new SqlParameter("@Mode",_OperationMode)
                                              };
            spName = "[dbo].[CustMocUploadSelect]";
            ExecuteSelectDataSet();
        }

        #endregion CustomerExcelUpload


        //----------------------------------  Account Excel Upload
        #region Account Excel Upload        

        public void ValidateAccExcelModel()
        {
            sqlParams = new SqlParameter[] {

                                               new SqlParameter("@MocType","A"),
                                               new SqlParameter("@XmlData",XmlData),
                                               new SqlParameter("@EffectiveFromTimeKey",_MocFromTimeKey),
                                               new SqlParameter("@EffectiveToTimeKey",_EffectiveToTimeKey),
                                               new SqlParameter("@CreateModifyApprovedBy",_CreatetedModifiedBy),
                                               new SqlParameter("@DateCreatedModifiedApproved",_dateCreatedmodified),
                                               new SqlParameter("@OperationFlag",_OperationFlag),
                                               new SqlParameter("@D2Ktimestamp",_D2Ktimestamp),
                                               new SqlParameter("@AuthMode",_AuthMode),
                                               new SqlParameter("@MenuID",_MenuID),
                                               new SqlParameter("@Remark",_Remark),
                                               new SqlParameter("@TimeKey",_LastQtrDateKey),
                                               new SqlParameter("@Result",-1)
                                              };
            spName = "[dbo].[CustAcMocUploadValidation]";
            ExecuteSelectDataSet();
        }

        public object AccExcelUploadInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr"); 
             DbCommand command = database.GetStoredProcCommand("[dbo].[AccountMocInsertUpdate_Upld]"); 
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@CustomerId", System.Data.DbType.String, null);
                    database.AddInParameter(command, "@AccountData", System.Data.DbType.String, XmlData);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int16, _MocFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
                    database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@ScreenEntityId", System.Data.DbType.String, ScreenEntitiyId);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _LastQtrDateKey);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    //database.AddInParameter(command, "@EffectChangeFromDate", System.Data.DbType.String, _MocFromTimeKey);

                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            return DBReturnResult;
        }

        public void GetAccExcelDataModel()
        {
            sqlParams = new SqlParameter[]   {
                        new SqlParameter("@selectFlg",selectFlg),
                        new SqlParameter("@fetchDate",fetchDate),
                        new SqlParameter("@TimeKey",_LastQtrDateKey),
                        new SqlParameter("@Mode",_OperationMode)
                                              };
            spName = "[dbo].[AcMocUploadSelect]";
            ExecuteSelectDataSet();
        }




        #endregion

        //public void CustAccountExcelUpload()
        //{
        //    Database database = factory.Create("ConnStringDecr");
        //    DbCommand command = database.GetStoredProcCommand("[dbo].[CustAcMocUploadValidation]");
        //    try
        //    {
        //        using (command)
        //        {

        //            database.AddInParameter(command, "@MocType", System.Data.DbType.String, MOCType);
        //            database.AddInParameter(command, "@XmlData", System.Data.DbType.String,XmlData);
        //            database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int16, _MocFromTimeKey);
        //            database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
        //            database.AddInParameter(command, "@CreateModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
        //            database.AddInParameter(command, "@DateCreatedModifiedApproved", System.Data.DbType.String, _dateCreatedmodified);
        //            database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
        //            database.AddOutParameter(command, "@D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);
        //            database.AddInParameter(command, "@AuthMode", System.Data.DbType.String, _AuthMode);
        //            database.AddInParameter(command, "@MenuID", System.Data.DbType.Int32, _MenuID);
        //            database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
        //            database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _LastQtrDateKey);
        //            database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);

        //            //database.AddInParameter(command, "@EffectChangeFromDate", System.Data.DbType.String, _MocFromTimeKey);
        //            database.ExecuteDataSet(command);
        //            //database.ExecuteNonQuery(command);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    ExecuteSelectDataSet();

        //    //JObject DBReturnResult = new JObject();

        //    //DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
        //    //DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());

        //    //return DBReturnResult;


        //}

    }
}