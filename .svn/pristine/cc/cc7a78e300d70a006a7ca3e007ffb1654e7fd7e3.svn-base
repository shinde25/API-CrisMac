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
    public class CustomerModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string UserLoginId { get; set; }
        public string BranchCode { get; set; }
        public string CustomerID { get; set; }
        public string SearchString { get; set; }
        public int CustomerEntityID { get; set; }
        public int AccountEntityID { get; set; }

        public string PriActionStakeHolders { get; set; }
        public string SecActionStakeHolders { get; set; }
        public string InfoActionStakeHolders { get; set; }

        public string UserLoginID { get; set; }
        public int SecurityEntityID { get; set; }
        public int VehicleEntityID { get; set; }
        
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int CRMEntityID { get; set; }
        public string VehicleNo { get; set; }
        public int OperationFlag { get; set; }
        public int CRMSecurityAlt_Key { get; set; }
        public string Quantity { get; set; }
        public string Karat { get; set; }
        public string Margin { get; set; }
        public string NoOfUnit { get; set; }
        public string CurrentValue { get; set; }
        public int HOSecurityAlt_Key { get; set; }

        public int PropertyEntityID { get; set; }
        public string InsuranceCompany { get; set; }
        public string ValidUpTo { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string Pincode { get; set; }
        public string Landmark { get; set; }

        public void Get_BranchList()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginId",UserLoginId),
                                               new SqlParameter("@SearchString",SearchString)
                                              };
            spName = "[CMA].[GetBranchList]";
            ExecuteSelectDataSet();
        }

        public void Get_CustomerList()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@BranchCode",BranchCode),
                                                new SqlParameter("@SearchString",SearchString)
                                              };
            spName = "[CMA].[GetCustomerList]";
            ExecuteSelectDataSet();
        }

        public void Get_CustomerDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityId",CustomerEntityID),
                                              };
            spName = "[CMA].[GetCustomeDetails]";
            ExecuteSelectDataSet();
        }

        public void Get_LoanDetails()
        {
            sqlParams = new SqlParameter[] {
                                                new SqlParameter("@CustomerEntityId",CustomerEntityID),
                                               new SqlParameter("@AccountEntityId",AccountEntityID)
                                              };
            spName = "[CMA].[GetLoanDetails]";
            ExecuteSelectDataSet();
        }

        public void Get_RecoveryDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityId",CustomerEntityID),
                                               new SqlParameter("@AccountEntityID",AccountEntityID)

                                              };
            // spName = "[CMA].[GetRecoveryDetails]";
            spName = "[CMA].[GetRecoveryDetails]";
            ExecuteSelectDataSet();
        }

        public void Get_SecurityDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityId",CustomerEntityID),
                                               new SqlParameter("@AccountEntityID",AccountEntityID)
                                              };
            spName = "[CMA].[GetSecurityDetail]";
            ExecuteSelectDataSet();
        }

        public void Get_CoBorrGuar()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityId",CustomerEntityID),
                                               new SqlParameter("@AccountEntityID",AccountEntityID)
                                          };
            spName = "[CMA].[GetCoBorrGuar]";
            ExecuteSelectDataSet();
        }

        public void Get_SecurityFurtherDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CustomerEntityId",CustomerEntityID),
                                               new SqlParameter("@AccountEntityID",AccountEntityID)

                                              };
            spName = "[CMA].[GetSecurityFurtherDetails]";
            ExecuteSelectDataSet();
        }

        public object CustomerReAllocationUpdate()      //----Customer ReAllocation Update
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[CustomerReAllocationUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@CustomerEntityId", System.Data.DbType.Int32, CustomerEntityID);
                    database.AddInParameter(command, "@PriActionStakeHolders", System.Data.DbType.String, PriActionStakeHolders);
                    database.AddInParameter(command, "@SecActionStakeHolders", System.Data.DbType.String, SecActionStakeHolders);
                    database.AddInParameter(command, "@InfoActionStakeHolders", System.Data.DbType.String, InfoActionStakeHolders);
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

        public void Get_SecurityVehicleDetail()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginID",UserLoginID),
                                               new SqlParameter("@SecurityEntityID",SecurityEntityID)

                                              };
            spName = "[CMA].[SelectSecurityVehicleDetail]";
            ExecuteSelectDataSet();
        }

        public void Get_SecurityGoldDetail()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginID",UserLoginID),
                                               new SqlParameter("@SecurityEntityID",SecurityEntityID)

                                              };
            spName = "[CMA].[SelectSecurityGoldDetail]";
            ExecuteSelectDataSet();
        }

        public object SecurityVehicleDetailInsertUpdate()      //----SecurityVehicleDetailInsertUpdate
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[SecurityVehicleDetailInsertUpdate]");
            try
            {
                using (command)
                {

                    database.AddInParameter(command, "@CreatedModifyBy", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "@AccountEntityID", System.Data.DbType.Int32, AccountEntityID);
                    database.AddInParameter(command, "@CustomerEntityID", System.Data.DbType.Int32, CustomerEntityID);
                    database.AddInParameter(command, "@SecurityEntityID", System.Data.DbType.Int32, SecurityEntityID);
                    database.AddInParameter(command, "@VehicleEntityID", System.Data.DbType.Int32, VehicleEntityID);

                    database.AddInParameter(command, "@Make", System.Data.DbType.String, Make);
                    database.AddInParameter(command, "@Model", System.Data.DbType.String, Model);
                    database.AddInParameter(command, "@Type", System.Data.DbType.String, Type);
                    database.AddInParameter(command, "@VehicleNo", System.Data.DbType.String, VehicleNo);
                    database.AddInParameter(command, "@InsuranceCompany", System.Data.DbType.String, InsuranceCompany);

                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, OperationFlag);

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



        public void Get_SecurityShareDetail()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginID",UserLoginID),
                                               new SqlParameter("@SecurityEntityID",SecurityEntityID)

                                              };
            spName = "[CMA].[SelectSecurityShareDetail]";
            ExecuteSelectDataSet();
        }


        public void Get_SecurityPropertyDetail()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginID",UserLoginID),
                                               new SqlParameter("@SecurityEntityID",SecurityEntityID)

                                              };
            spName = "[CMA].[SelectSecurityPropertyDetail]";
            ExecuteSelectDataSet();
        }


        public object SecurityGoldDetailInsertUpdate()      //----SecurityGoldDetailInsertUpdate
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[SecurityGoldDetailInsertUpdate]");
            try
            {
                using (command)
                {

                    database.AddInParameter(command, "@CreatedModifyBy", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "@AccountEntityID", System.Data.DbType.Int32, AccountEntityID);
                    database.AddInParameter(command, "@CustomerEntityID", System.Data.DbType.Int32, CustomerEntityID);
                    database.AddInParameter(command, "@SecurityEntityID", System.Data.DbType.Int32, SecurityEntityID);
                    database.AddInParameter(command, "@CRMEntityID", System.Data.DbType.Int32, CRMEntityID);

                    database.AddInParameter(command, "@Quantity", System.Data.DbType.String, Quantity);
                    database.AddInParameter(command, "@Karat", System.Data.DbType.String, Karat);
                    database.AddInParameter(command, "@Margin", System.Data.DbType.String, Margin);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, OperationFlag);

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


        public object SecurityShareDetailInsertUpdate()      //----SecurityGoldDetailInsertUpdate
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[SecurityShareDetailInsertUpdate]");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@AccountEntityID", System.Data.DbType.Int32, AccountEntityID);
                    database.AddInParameter(command, "@CustomerEntityID", System.Data.DbType.Int32, CustomerEntityID);
                    database.AddInParameter(command, "@SecurityEntityID", System.Data.DbType.Int32, SecurityEntityID);
                    database.AddInParameter(command, "@CRMEntityID", System.Data.DbType.Int32, CRMEntityID);

                    database.AddInParameter(command, "@NoOfUnit", System.Data.DbType.String, NoOfUnit);
                    database.AddInParameter(command, "@CurrentValue", System.Data.DbType.String, CurrentValue);
                    database.AddInParameter(command, "@HOSecurityAlt_Key", System.Data.DbType.Int32, HOSecurityAlt_Key);
                    database.AddInParameter(command, "@CreatedModifyBy", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "@OperationFlag", System.Data.DbType.Int32, OperationFlag);

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

        public object SecurityPropertyDetailInsertUpdate()      //----SecurityVehicleDetailInsertUpdate
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("[CMA].[SecurityPropertyDetailInsertUpdate]");
            try
            {
                using (command)
                {

                    database.AddInParameter(command, "@CreatedModifyBy", System.Data.DbType.String, UserLoginID);
                    database.AddInParameter(command, "@AccountEntityID", System.Data.DbType.Int32, AccountEntityID);
                    database.AddInParameter(command, "@CustomerEntityID", System.Data.DbType.Int32, CustomerEntityID);
                    database.AddInParameter(command, "@SecurityEntityID", System.Data.DbType.Int32, SecurityEntityID);
                    database.AddInParameter(command, "@PropertyEntityID", System.Data.DbType.Int32, PropertyEntityID);

                    database.AddInParameter(command, "@InsuranceCompany", System.Data.DbType.String, InsuranceCompany);
                    database.AddInParameter(command, "@ValidUpTo", System.Data.DbType.String, ValidUpTo);
                    database.AddInParameter(command, "@Add1", System.Data.DbType.String, Add1);
                    database.AddInParameter(command, "@Add2", System.Data.DbType.String, Add2);
                    database.AddInParameter(command, "@Add3", System.Data.DbType.String, Add3);
                    database.AddInParameter(command, "@Pincode", System.Data.DbType.String, Pincode);
                    database.AddInParameter(command, "@Landmark", System.Data.DbType.String, Landmark);


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

        public void GetInsuranceCompanyList()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginId",UserLoginId),
                                               new SqlParameter("@SearchString",SearchString)
                                              };
            spName = "[CMA].[GetInsuranceCompany]";
            ExecuteSelectDataSet();
        }

    }
}