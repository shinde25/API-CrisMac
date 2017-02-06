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
    public class CustomerAllocationModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string CustomerEntityId { get; set; }
        public string PriActionStakeHolder { get; set; }
        public string SecActionStakeHolder { get; set; }
        public string InfoStakeHolder { get; set; }
        public int StackHolder { get; set; }
        public string StackHolderAndOr { get; set; }
        public int AllocationCriteria { get; set; }
        public string AllocatedValue { get; set; }
        public string AllocationCriteriaAndOr { get; set; }
        public int ExposureRange { get; set; }
        public decimal RangeValue1 { get; set; }
        public decimal RangeValue2 { get; set; }
        public string UserId { get; set; }

        public void CustomerAllocationParmatrised()
        {
            sqlParams = new SqlParameter[] {
               new SqlParameter("@TimeKey", _TimeKey)
                };
            spName = "[EWS].[CustomerAllocationParmatrised]";
            ExecuteSelectDataSet();
        }

        public void CustomerAllocationAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                                 new SqlParameter("@BranchCode", _BranchCode),
                                                  new SqlParameter("@Mode", _OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey)

                };
            spName = "[EWS].[CustomerAllocationAuxSelect]";
            ExecuteSelectDataSet();
        }

        public void UserAllocationAuxSelect()
        {
            sqlParams = new SqlParameter[] {
                                                 new SqlParameter("@UserLoginID",_userLoginId),
                                                 new SqlParameter("@UserLocation",_userLocation),
                                                 new SqlParameter("@Mode", OperationMode),
                                                   new SqlParameter("@TimeKey", _TimeKey)

                };
            spName = "[EWS].[UserAllocationSelect]";
            ExecuteSelectDataSet();
        }
       
        public void CustomerAllocationSelect()
        {
            sqlParams = new SqlParameter[] {
                                                 new SqlParameter("@CustomerEntityId",CustomerEntityId),
                                                 new SqlParameter("@StackHolder", StackHolder),
                                                 new SqlParameter("@UserId", UserId),
                                                 new SqlParameter("@StackHolderAndOr", StackHolderAndOr),
                                                 new SqlParameter("@AllocationCriteria",AllocationCriteria),
                                                 new SqlParameter("@AllocatedValue", AllocatedValue),
                                                 new SqlParameter("@AllocationCriteriaAndOr", AllocationCriteriaAndOr),
                                                 new SqlParameter("@ExposureRange",ExposureRange),
                                                 new SqlParameter("@RangeValue1", RangeValue1),
                                                 new SqlParameter("@RangeValue2", RangeValue2),
                                                 new SqlParameter("@UserLoginID",_userLoginId),
                                                 new SqlParameter("@BranchCode", _BranchCode),
                                                 new SqlParameter("@TimeKey",_TimeKey),
                                                 new SqlParameter("@Mode", _OperationMode)


                };
            spName = "[EWS].[CustomerAllocationSelect]";
            ExecuteSelectDataSet();
        }

        public object CustomerAllocationInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[EWS].[CustomerAllocationInsertUpdate]");
            try
            {
                using (command)
                {
                    //database.AddInParameter(command, "@CustomerEntityID", System.Data.DbType.Int32, CustomerEntityId);
                    //database.AddInParameter(command, "@PriActionStakeHolder", System.Data.DbType.String, PriActionStakeHolder); // smallint
                    //database.AddInParameter(command, "@SecActionStakeHolder", System.Data.DbType.String, SecActionStakeHolder);
                    //database.AddInParameter(command, "@InfoStakeHolder", System.Data.DbType.String, InfoStakeHolder);
                    database.AddInParameter(command, "@CustomerAllocationJson", System.Data.DbType.String, InfoStakeHolder);
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
