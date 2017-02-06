using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.CMA.Models
{
    public class DataSyncModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string UserLoginID { get; set; }
        public string CustomerEntityID { get; set; }
        public string XMLDocument { get; set; }

        public void Get_CustomerDetailsSync()
        {
            sqlParams = new SqlParameter[] {                                               
                                               new SqlParameter("@CustomerEntityID",CustomerEntityID)
                                           };
            spName = "[CMA].[GetCustomerDetailsSync]";
            ExecuteSelectDataSet();
        }

        public void Get_DetailsSync()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityID",CustomerEntityID)
                                           };
            spName = "[CMA].[GetDetailsSync]";
            ExecuteSelectDataSet();
        }

        public void Get_ActionDetailsSync()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityID",CustomerEntityID)
                                           };
            spName = "[CMA].[GetActionDetailsSync]";
            ExecuteSelectDataSet();
        }

        public object UploadDataToServer()      //----Customer ReAllocation Update
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[SyncUploadToServer]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@xmlDocument", System.Data.DbType.String, XMLDocument);
                    database.AddInParameter(command, "@UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            return DBReturnResult;
        }
    }
}