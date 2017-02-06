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

namespace CrisMAcAPI.Areas.Alert.Models
{
    public class BulkSupervisorCustomerAllocationModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();


        public string AssignmentDate { get; set; }
        public string DeAssignmentDate { get; set; }
        public string ZoneCode { get; set; }
        public string RegionCode { get; set; }
        public string BranchCode { get; set; }

        public string CustomerAllocationJson { get; set; }
        public int EmployeeRole { get; set; }
        public int AllocationCriteria { get; set; }
        public string AllocatedValue { get; set; }

        public int ExposureRange { get; set; }
        public decimal RangeValue1 { get; set; }
        public decimal RangeValue2 { get; set; }
        public string UserId { get; set; }
        public string applyToAll { get; set; }

        public void BulkSupervisorCustomerAllocationParameterisedMasterData()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey),
               new SqlParameter("@OperationFlag", _OperationMode)
                };
            spName = "ALERT.BulkSupervisorCustomerAllocationParameterisedMasterData";
            ExecuteSelectDataSet();
        }
        public void BulkSupervisorCustomerAllocationAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@EmployeeRole", EmployeeRole),
                new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "ALERT.BulkSupervisorCustomerAllocationAuxSelect";
            ExecuteSelectDataSet();
        }

        public void BulkSupervisorCustomerAllocationSelect()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@ZoneCode", ZoneCode),
                 new SqlParameter("@RegionCode", RegionCode),
                 new SqlParameter("@BranchCode", BranchCode),
                 new SqlParameter("@UserId", UserId),
                 new SqlParameter("@EmployeeRole", EmployeeRole),
                 new SqlParameter("@AllocatedValue", AllocatedValue),
                 new SqlParameter("@AllocationCriteria", AllocationCriteria),
                 new SqlParameter("@ExposureRange", ExposureRange),
                 new SqlParameter("@RangeValue1", RangeValue1),
                 new SqlParameter("@RangeValue2", RangeValue2),
                 new SqlParameter("@UserLoginID", _userLoginId),
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@Mode", _OperationMode)
                };
            spName = "[ALERT].[BulkSupervisorCustomerAllocationSelect]";
            ExecuteSelectDataSet();
        }


        public object BulkSupervisorCustomerAllocationInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[ALERT].[BulkSupervisorCustomerAllocationInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@CustomerAllocationJson", System.Data.DbType.String, CustomerAllocationJson);
                    database.AddInParameter(command, "@applyToAll", System.Data.DbType.String, applyToAll);
                    database.AddInParameter(command, "@UserId", System.Data.DbType.String, UserId);
                    database.AddInParameter(command, "@AssignmentDate", System.Data.DbType.String, AssignmentDate);
                    database.AddInParameter(command, "@DeAssignmentDate", System.Data.DbType.String, DeAssignmentDate);
                    database.AddInParameter(command, "@EmployeeRole", System.Data.DbType.Int16, EmployeeRole);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int16, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int16, _EffectiveToTimeKey);
                    database.AddInParameter(command, "@DateApproved", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "@ApprovedBy", System.Data.DbType.String, _CreatetedModifiedBy);
                    database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _OperationFlag);

                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, _BranchCode);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _AuthMode);
                    database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _MenuID);
                    database.AddInParameter(command, "Remark", System.Data.DbType.String, _Remark);
                    database.AddInParameter(command, "@ChangedField", System.Data.DbType.String, _EffectiveToTimeKey);

                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "D2Ktimestamp", System.Data.DbType.Int32, _D2Ktimestamp);

                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            JObject DBReturnResult = new JObject();
            DBReturnResult.Add("Result", (command.Parameters)[command.Parameters.Count - 2].Value.ToString());
            DBReturnResult.Add("D2Ktimestamp", (command.Parameters)[command.Parameters.Count - 1].Value.ToString());
            //DBReturnResult = new
            //{
            //    Result = (command.Parameters)[command.Parameters.Count - 1].Value,
            //    D2Ktimestamp = (command.Parameters)[command.Parameters.Count - 2].Value
            //};
            return DBReturnResult;
        }
    }
}
