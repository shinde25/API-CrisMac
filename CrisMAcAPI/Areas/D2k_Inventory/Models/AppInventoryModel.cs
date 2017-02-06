using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.D2k_Inventory.Models
{
    public class AppInventoryModel: CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string UserLoginID { get; set; }
        public string SearchData { get; set; }
        public int InventoryId { get; set; }
        public int ClientAlt_Key { get; set; }
        public int ProjectAlt_Key { get; set; }
        public string WorkCommencementDate { get; set; }
        public string ParticipantsName { get; set; }
        public string WorkClosureDate { get; set; }
        public int ManDaysUtilised { get; set; }
        public int WorkTypeAlt_Key { get; set; }
        public string WorkDescription { get; set; }
        public string OriginatorOfWork { get; set; }
        public string Attachments { get; set; }
       

        public void Select_MasterDetails()
        {
            sqlParams = new SqlParameter[] {
                                              new SqlParameter("@TimeKey",9999),
                                               new SqlParameter("@UserLoginID",UserLoginID)
                                           };
            spName = "[dbo].[InventoryDetailParameterised]";
            ExecuteSelectDataSet();
        }

        public void Search_InventoryDetails()
        {
            sqlParams = new SqlParameter[] {
                                              new SqlParameter("@SearchString",SearchData),
                                               new SqlParameter("@UserLoginId",UserLoginID),
                                                new SqlParameter("@TimeKey",9999)
                                           };
            spName = "[dbo].[InventoryDetailSearch]";
            ExecuteSelectDataSet();
        }

        public void Select_InventoryDetails()
        {
            sqlParams = new SqlParameter[] {
                                              new SqlParameter("@InventoryId",InventoryId)//,
                                              // new SqlParameter("@SearchString",SearchData)
                                           };
            spName = "[dbo].[InventoryDetailSelect]";
            ExecuteSelectDataSet();
        }

        public object Insert_InventoryDetails()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[dbo].[InventoryDetailInsert]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@ClientAlt_Key", System.Data.DbType.Int32, ClientAlt_Key);
                    database.AddInParameter(command, "@ProjectAlt_Key", System.Data.DbType.Int32, ProjectAlt_Key);
                    database.AddInParameter(command, "@WorkTypeAlt_Key", System.Data.DbType.Int32, WorkTypeAlt_Key);
                    database.AddInParameter(command, "@WorkDescription", System.Data.DbType.String, WorkDescription);
                    database.AddInParameter(command, "@OriginatorOfWork", System.Data.DbType.String, OriginatorOfWork);
                    database.AddInParameter(command, "@Attachments", System.Data.DbType.String, Attachments);
                    database.AddInParameter(command, "@UserLoginId", System.Data.DbType.String, UserLoginID);
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

        public object EditDelete_InventoryDetails()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[dbo].[InventoryDetailEditDelete]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@InventoryID", System.Data.DbType.Int32, InventoryId);
                    database.AddInParameter(command, "@WorkTypeAlt_Key", System.Data.DbType.Int32, WorkTypeAlt_Key);
                    database.AddInParameter(command, "@WorkCommencementDate", System.Data.DbType.Date, WorkCommencementDate);
                    database.AddInParameter(command, "@ParticipantsName", System.Data.DbType.String, ParticipantsName);
                    database.AddInParameter(command, "@WorkClosureDate", System.Data.DbType.Date, WorkClosureDate);
                    database.AddInParameter(command, "@ManDaysUtilised", System.Data.DbType.Int32, ManDaysUtilised);
                    database.AddInParameter(command, "@UserLoginId", System.Data.DbType.String, UserLoginID);
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