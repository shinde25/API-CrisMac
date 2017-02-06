using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.Common;
using System.Web;

namespace CrisMAcAPI.Areas.FAM.Models
{
    public class AssetDocUploadModel : CrisMAc.Models.CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int AssetEntityID { get; set; }
        public string xmlDocument { get; set; }
        public string AssetDocumentUploadEventAlt_key { get; set; }
        public string IsMainGrid { get; set; }
        public string ScreenType { get; set; }


        //public int EntityKey { get; set; }
        //public int AssetDocumentAlt_key { get; set; }
        //public int AssetDocumentUploadEventAlt_key { get; set; }
        //public int AssetDocumentNatureAlt_key { get; set; }
        //public int AssetDocumentTypeAlt_key { get; set; }
        //public string AssetDocumentTitle { get; set; }
        //public string AssetDocumentDesc { get; set; }
        //public string AssetDocumentDate { get; set; }

        //public string AssetDocumentUploadDate { get; set; }
        //public string AssetDocumentExtension { get; set; }
        //public string AssetDocumentLocation { get; set; }

        //public string ChangeFields { get; set; }

        public DataSet AssetDocDetailSelect()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetDocumentDetailSelect");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@AssetEntityID", System.Data.DbType.Int32, AssetEntityID);
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "@Mode", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "@AssetDocumentUploadEventAlt_key", System.Data.DbType.String, AssetDocumentUploadEventAlt_key);
                    database.AddInParameter(command, "@ScreenType", System.Data.DbType.String, ScreenType);

                    

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet AssetDocDetailParameterisedMasterData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("AssetDocumentDetailParameterisedMasterData");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object SaveDocumentUploadMain()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("DocumentDetailsInsertUpdate");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@AssetEntityID", System.Data.DbType.Int32, AssetEntityID);                    
                    database.AddInParameter(command, "@AssetDocumentUploadEventAlt_key", System.Data.DbType.String, AssetDocumentUploadEventAlt_key);
                    database.AddInParameter(command, "@xmlDocument", System.Data.DbType.String, xmlDocument);
                    database.AddInParameter(command, "@IsMainGrid", System.Data.DbType.String, IsMainGrid);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@CreatedModifyApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "@DateCreatedModified", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);                   
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
            return DBReturnResult;
        }
    }
}
