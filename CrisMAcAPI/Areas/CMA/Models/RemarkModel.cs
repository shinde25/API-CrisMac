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
    public class RemarkModel:CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int CustomerEntityId { get; set; }
        public int RemarkID { get; set; }
        public int AccountEntityID { get; set; }
        public int AssignActionID { get; set; }
        public string UserLoginID { get; set; }
        public string Remark { get; set; }
        public string WhatIsToBeDone { get; set; }
        public string ByWhen { get; set; }
        public string ByWhome { get; set; }
        public string CommencementRemark { get; set; }
        public string ClosureRemark { get; set; }
        public int Status { get; set; }
        public string CommencementDt { get; set; }
        public string ClosureDt { get; set; }

        public string AssignActionData { get; set; }
        public int EventID { get; set; }


        public string PriActionStakeHolders { get; set; }
        public string SecActionStakeHolders { get; set; }
        public string InfoActionStakeHolders { get; set; }


        public void Get_AssignAction()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityId",CustomerEntityId),
                                               //new SqlParameter("@AccountEntityId",AccountEntityID)
                                               new SqlParameter("@RemarkID",RemarkID)
                                              };
            spName = "[CMA].[GetAssignAction]";
            ExecuteSelectDataSet();
        }

        public object Insert_RemarkDetails()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[RemarkInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@CustomerEntityId", System.Data.DbType.Int32, CustomerEntityId);
                    database.AddInParameter(command, "@AccountEntityID", System.Data.DbType.Int32, AccountEntityID);
                    database.AddInParameter(command, "@UserLoginID", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "@Remark", System.Data.DbType.String, Remark);
                    //database.AddInParameter(command, "@AssignActionData", System.Data.DbType.String, AssignActionData);
                    database.AddOutParameter(command, "@RemarkID", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("RemarkID", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            return DBReturnResult;
        }

        public object Insert_ActionableRemark()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[ActionalbeRemarkInsert]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@RemarkID", System.Data.DbType.Int32, RemarkID);
                    database.AddInParameter(command, "@CustomerEntityId", System.Data.DbType.Int32, CustomerEntityId);
                    database.AddInParameter(command, "@AccountEntityID", System.Data.DbType.Int32, AccountEntityID);
                    database.AddInParameter(command, "@WhatIsToBeDone", System.Data.DbType.String, WhatIsToBeDone);
                    database.AddInParameter(command, "@ByWhen", System.Data.DbType.String, ByWhen);
                    database.AddInParameter(command, "@ByWhome", System.Data.DbType.String, ByWhome);
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

        public object Action_EventUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[ActionEventUpdate]");
            try
            {
                using (command)
                {
                   
                    database.AddInParameter(command, "@RemarkID", System.Data.DbType.Int32, RemarkID);
                    database.AddInParameter(command, "@EventID", System.Data.DbType.Int32, EventID);
                    database.AddInParameter(command, "@Status", System.Data.DbType.Int32, Status);
                    database.AddInParameter(command, "@CommencementDt", System.Data.DbType.String, CommencementDt);
                    database.AddInParameter(command, "@CommencementRemark", System.Data.DbType.String, CommencementRemark);
                    database.AddInParameter(command, "@ClosureDt", System.Data.DbType.String, ClosureDt);
                    database.AddInParameter(command, "@ClosureRemark", System.Data.DbType.String, ClosureRemark);
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


        public void GetPreviousRemark()
        {
            sqlParams = new SqlParameter[] {
            
                                          new SqlParameter("@CustomerEntityId",CustomerEntityId),
                                          new SqlParameter("@AccountEntityID",AccountEntityID)
            };

            spName = "[CMA].[GetPreviousRemark]";
            ExecuteSelectDataSet();

        }
        
        public void GetActionEventDiaryDetails()
        {
            sqlParams = new SqlParameter[] {

                                          new SqlParameter("@RemarkId",RemarkID)
            };

            spName = "[CMA].[GetActionEventDiaryDetails]";
            ExecuteSelectDataSet();

        }
        
        public void GetDefaultStatus()
        {

            spName = "[CMA].[GetDefaultStatus]";
            ExecuteSelectDataSet();
        }
        
        public void GetStakeHolderList()
        {
            sqlParams = new SqlParameter[] {
                                          new SqlParameter("@UserLoginId",UserLoginID),
                                          new SqlParameter("@CustomerEntityId",CustomerEntityId)
            };

            spName = "[CMA].[GetStakeHolderList]";
            ExecuteSelectDataSet();

        }
        
        //public object CustomerReAllocationUpdate()
        //{
        //    Database database = factory.Create("ConnStringDecr");
        //    DbCommand command = database.GetStoredProcCommand("[CMA].[CustomerReAllocationUpdate]");
        //    try
        //    {
        //        using (command)
        //        {
        //            database.AddInParameter(command, "@CustomerEntityId", System.Data.DbType.Int32, CustomerEntityId);
        //            database.AddInParameter(command, "@PriActionStakeHolders", System.Data.DbType.String, PriActionStakeHolders);
        //            database.AddInParameter(command, "@SecActionStakeHolders", System.Data.DbType.String, SecActionStakeHolders);
        //            database.AddInParameter(command, "@InfoActionStakeHolders", System.Data.DbType.String, InfoActionStakeHolders);
        //            database.AddOutParameter(command, "@Result", System.Data.DbType.Int32, -1);
        //            database.ExecuteNonQuery(command);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    JObject DBReturnResult = new JObject();
        //    DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
        //    return DBReturnResult;
        //}

        public void GetActionEventDiaryList()
        {
            sqlParams = new SqlParameter[] {

                                          new SqlParameter("@CustomerEntityId",CustomerEntityId),
                                          new SqlParameter("@AccountEntityID",AccountEntityID)
            };

            spName = "[CMA].[GetActionEventDiaryList]";
            ExecuteSelectDataSet();

        }

        public void GetRemarkList()
        {
            sqlParams = new SqlParameter[] {

                                          new SqlParameter("@CustomerEntityId",CustomerEntityId),
                                          new SqlParameter("@AccountEntityID",AccountEntityID),
                                          new SqlParameter("@UserLoginId",UserLoginID)
            };

            spName = "[CMA].[GetRemarkList]"; 
            ExecuteSelectDataSet();
        }

        public object AssignActionInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[AssignActionInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@RemarkID", System.Data.DbType.Int32, RemarkID);
                    database.AddInParameter(command, "@AssignActionID", System.Data.DbType.Int32, AssignActionID);                    
                    database.AddInParameter(command, "@ByWhen", System.Data.DbType.String, ByWhen);
                    database.AddInParameter(command, "@WhatIsToBeDone", System.Data.DbType.String, WhatIsToBeDone);
                    database.AddInParameter(command, "@PrimaryActionStakeHolder", System.Data.DbType.String, PriActionStakeHolders);
                    database.AddInParameter(command, "@SecondaryActionStakeHolder", System.Data.DbType.String, SecActionStakeHolders);
                    database.AddInParameter(command, "@InfoStakeHolder", System.Data.DbType.String, InfoActionStakeHolders);
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