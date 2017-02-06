using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models
{
    public class EwsHomeDashboardModel: CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public int Page { get; set; }
        public string Type { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SearchKeyWord { get; set; }
        public string SourceType { get; set; }
        public string SourceData { get; set; }
        public string _CreatedModifyBy { get; set; }





        public void DashBoardAllocatedCustomers()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),
                new SqlParameter("@TimeKey", _TimeKey),
                new SqlParameter("@UserLoginId", _userLoginId),
                new SqlParameter("@PageNo", Page)
                };
            spName = "[EWS].[HomeDashBoardAllocatedCustomer]";
            ExecuteSelectDataSet();
        }

        public void DashBoardNewsTwitsBlogs()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),
                new SqlParameter("@TimeKey", _TimeKey),
                new SqlParameter("@UserLoginId", _userLoginId),
                new SqlParameter("@Type", Type),
                new SqlParameter("@SearchKeyWord", SearchKeyWord),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@PageNo", Page)
       
                };
            spName = "[EWS].[HomeDashBoardNewsTwitsBlogs]";
            ExecuteSelectDataSet();
        }

        public void DashBoardPendingActions()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),//_BranchCode
                new SqlParameter("@TimeKey",_TimeKey),//_TimeKey
                new SqlParameter("@UserLoginId",_userLoginId),//_userLoginId
                new SqlParameter("@PageNo", Page)
                };
            spName = "[EWS].[HomeDashBoardPendingActions]";
            ExecuteSelectDataSet();
        }


        //we can chage Know
        public void DashBoardSelectSources()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@SourceType", SourceType),//_BranchCode
                new SqlParameter("@TimeKey",_TimeKey),//_TimeKey
                new SqlParameter("@UserLoginId",_userLoginId),//_userLoginId
                
                };
            spName = "[EWS].[NewsBlogsSourceSelect]";
            ExecuteSelectDataSet();
        }
        public object EWSInsertUpdateSourceData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[NewsBlogsSourceInsertUpdate]");
            try
            {
                using (command)
                {

                    database.AddInParameter(command, "@SourceData", System.Data.DbType.String, SourceData);
                    

                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, _OperationFlag);
                  
                    database.AddInParameter(command, "@TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "@EffectiveFromTimeKey", System.Data.DbType.Int16, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "@EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@CreatedModifyBy", System.Data.DbType.String, _CreatedModifyBy);
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