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
    public class DocumentUploadModel : CommonProperties
    {

        DatabaseProviderFactory factory = new DatabaseProviderFactory();


        //public int RemarkTypeAlt_Key { get; set; }
        //public DateTime RemarkDt { get; set; }
        //public int AccountEntityId { get; set; }
        public string DocDate { get; set; }//for date
        public int CustomerEntityId { get; set; }
        public int DocDateAlt_Key { get; set; }
        public string DocName { get; set; }
        public int DocumentTypeAlt_Key { get; set; }
        public byte[] DocData { get; set; }
        public int ScreenEntityId { get; set; }
        public int EntityKey { get; set; }
        public string FileType { get; set; }
        public string PdfToImageData { get; set; }
        public int DocumentID { get; set; }
        public int PageNo { get; set; }
        public byte[] ImgData { get; set; }
        public string ImgType { get; set; }

        //      PARAMETERIZED       //
        public void DocumentUploadParmatrised()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[DocumentUploadParmatrised]";
            ExecuteSelectDataSet();
        }



        //          AUX         //
        public void DocumentUploadAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                               //new SqlParameter("@SearchString", Company_Industry_Name),
                                                 new SqlParameter("@BranchCode", _BranchCode),
                                                  new SqlParameter("@Mode", OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey)

                };
            spName = "[EWS].[DocumentUploadAuxSelect]";
            ExecuteSelectDataSet();
        }



        //          FETCH       //
        public void DocumentUploadSelect()
        {
            sqlParams = new SqlParameter[] {
                                                new SqlParameter("@CustomerEntityId", CustomerEntityId),
                                                //new SqlParameter("@BranchCode", _BranchCode),
                                                new SqlParameter("@Mode", _OperationFlag),
                                                new SqlParameter("@TimeKey", _TimeKey)



                };
            spName = "[EWS].[DocumentUploadSelect]";
            ExecuteSelectDataSet();
        }

        //Get Uploaded File From DB
        public void DocumentUploadedFileSelect()
        {
            sqlParams = new SqlParameter[] {
                                                new SqlParameter("@DocumentId", DocumentID),
                                                //new SqlParameter("@BranchCode", _BranchCode),
                                                new SqlParameter("@Mode", _OperationFlag),
                                                new SqlParameter("@TimeKey", _TimeKey)



                };
            spName = "[EWS].[DocumentUploadedFileSelect]";
            ExecuteSelectDataSet();
        }


        //          INSERT UPDATE       //
        public object DocumentUploadInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[DocumentUploadInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@DocumentId", System.Data.DbType.Int32, DocumentID);
                    database.AddInParameter(command, "@CustomerEntityID", System.Data.DbType.Int32, CustomerEntityId); // smallint
                    database.AddInParameter(command, "@DocDate", System.Data.DbType.String, DocDate);
                    database.AddInParameter(command, "@DocumentTypeAlt_Key", System.Data.DbType.Int32, DocumentTypeAlt_Key);
                    database.AddInParameter(command, "@DocName", System.Data.DbType.String, DocName);
                    database.AddInParameter(command, "@FileType", System.Data.DbType.String, FileType);
                    database.AddInParameter(command, "@DocData", System.Data.DbType.Binary, DocData); //VarBinary(Max)                  
                    //database.AddInParameter(command, "@DocDateAlt_Key", System.Data.DbType.Int16, DocDateAlt_Key);

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

        public object DocumentUploadInsertUpdate_Images()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[DocumentUploadInsertUpdate_Images]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@DocumentId", System.Data.DbType.Int32, DocumentID);
                    database.AddInParameter(command, "@PageNo", System.Data.DbType.Int32, PageNo); // smallint
                    database.AddInParameter(command, "@ImgData", System.Data.DbType.Binary, ImgData);
                    database.AddInParameter(command, "@ImgType", System.Data.DbType.String, ImgType);    

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
