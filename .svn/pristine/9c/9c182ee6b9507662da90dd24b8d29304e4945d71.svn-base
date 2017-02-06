using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CMA.Models.Repository.CMA_CommonRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerModel _CommonModel = new CustomerModel();
        JavaScriptSerializer _Serializer = new JavaScriptSerializer();
        DataSet CommonResult;

        public DataSet GetResult()
        {
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            try
            {
              if (CommonResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    CommonResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    CommonResult.Tables.Add(dtStatus);
                }
            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                CommonResult.Tables.Add(dtStatus);
            }
            return CommonResult;
        }

        public DataSet GetBranchList(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.UserLoginId = JData["UserLoginId"].ToString();
            _CommonModel.SearchString = JData["SearchString"].ToString();
            _CommonModel.Get_BranchList();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }
        public DataSet GetCustomeList(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.BranchCode = JData["BranchCode"].ToString();
            _CommonModel.SearchString = JData["SearchString"].ToString();
            _CommonModel.Get_CustomerList();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetCustomeDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
           _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.Get_CustomerDetails();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetLoanDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.Get_LoanDetails();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetRecoveryDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.Get_RecoveryDetails();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetSecurityDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.Get_SecurityDetails();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();

            return GetResult();
        }

        public DataSet GetCoBorrGuar(string paramString)
        {
           JObject JData = JObject.Parse(paramString);
           _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.Get_CoBorrGuar();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetSecurityFurtherDetails(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.Get_SecurityFurtherDetails();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public object APP_CustomerReAllocationUpdateRepo(string jsonData)   //----Customer ReAllocation Update
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);

            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"].ToString());
            _CommonModel.PriActionStakeHolders = Convert.ToString(JData["PriActionStakeHolders"].ToString());
            _CommonModel.SecActionStakeHolders = JData["SecActionStakeHolders"].ToString();
            _CommonModel.InfoActionStakeHolders = Convert.ToString(JData["InfoActionStakeHolders"].ToString());
            InsertObj = _CommonModel.CustomerReAllocationUpdate();
            return InsertObj;
        }

        public DataSet GetSecurityVehicleDetail(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.UserLoginID = Convert.ToString(JData["UserLoginID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.Get_SecurityVehicleDetail();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetSecurityGoldDetail(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.UserLoginID = Convert.ToString(JData["UserLoginID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.Get_SecurityGoldDetail();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public object APP_SecurityVehicleDetailInsertUpdateRepo(string jsonData)
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);

            _CommonModel.UserLoginID = JData["UserLoginID"].ToString();
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.VehicleEntityID = Convert.ToInt32(JData["VehicleEntityID"]);

            _CommonModel.Make = JData["Make"].ToString();
            _CommonModel.Model = JData["Model"].ToString();
            _CommonModel.Type = JData["Type"].ToString();
            _CommonModel.VehicleNo = JData["VehicleNo"].ToString();
            _CommonModel.InsuranceCompany = JData["InsuranceCompany"].ToString();
           // _CommonModel.HOSecurityAlt_Key = Convert.ToInt32(JData["HOSecurityAlt_Key"].ToString());
           // _CommonModel.OperationFlag = Convert.ToInt32(JData["OperationFlag"].ToString());            
            InsertObj = _CommonModel.SecurityVehicleDetailInsertUpdate();
            return InsertObj;
        }

        
        public DataSet GetSecurityShareDetail(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.UserLoginID = Convert.ToString(JData["UserLoginID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.Get_SecurityShareDetail();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        
        public DataSet GetSecurityPropertyDetail(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.UserLoginID = Convert.ToString(JData["UserLoginID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.Get_SecurityPropertyDetail();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public object APP_SecurityGoldDetailInsertUpdateRepo(string jsonData)
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);

            _CommonModel.UserLoginID = JData["UserLoginID"].ToString();
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.CRMEntityID = Convert.ToInt32(JData["CRMEntityID"]);

            _CommonModel.Quantity = JData["Quantity"].ToString();
            _CommonModel.Karat = JData["Karat"].ToString();
            _CommonModel.Margin = JData["Margin"].ToString();            
            _CommonModel.OperationFlag = Convert.ToInt32(JData["OperationFlag"]);           
            InsertObj = _CommonModel.SecurityGoldDetailInsertUpdate();
            return InsertObj;
        }


        public object APP_SecurityShareDetailInsertUpdateRepo(string jsonData)
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);
            
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.CRMEntityID = Convert.ToInt32(JData["CRMEntityID"]);

            _CommonModel.NoOfUnit = JData["NoOfUnit"].ToString();
            _CommonModel.CurrentValue = JData["CurrentValue"].ToString();
            _CommonModel.HOSecurityAlt_Key = Convert.ToInt32(JData["HOSecurityAlt_Key"]);
            _CommonModel.UserLoginID = JData["UserLoginID"].ToString();
            _CommonModel.OperationFlag = Convert.ToInt32(JData["OperationFlag"]);
            InsertObj = _CommonModel.SecurityShareDetailInsertUpdate();
            return InsertObj;
        }

        public object APP_SecurityPropertyDetailInsertUpdateRepo(string jsonData)
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);

            _CommonModel.UserLoginID = JData["UserLoginID"].ToString();
            _CommonModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            _CommonModel.CustomerEntityID = Convert.ToInt32(JData["CustomerEntityID"]);
            _CommonModel.SecurityEntityID = Convert.ToInt32(JData["SecurityEntityID"]);
            _CommonModel.PropertyEntityID = Convert.ToInt32(JData["PropertyEntityID"]);

            _CommonModel.InsuranceCompany = JData["InsuranceCompany"].ToString();
            _CommonModel.ValidUpTo = JData["ValidUpTo"].ToString();
            _CommonModel.Add1 = JData["Add1"].ToString();
            _CommonModel.Add2 = JData["Add2"].ToString();
            _CommonModel.Add3 = JData["Add3"].ToString();
            _CommonModel.Pincode = JData["Pincode"].ToString();
            _CommonModel.Landmark = JData["Landmark"].ToString();

            
            // _CommonModel.HOSecurityAlt_Key = Convert.ToInt32(JData["HOSecurityAlt_Key"].ToString());
            // _CommonModel.OperationFlag = Convert.ToInt32(JData["OperationFlag"].ToString());            
            InsertObj = _CommonModel.SecurityPropertyDetailInsertUpdate();
            return InsertObj;
        }


        public DataSet GetInsuranceCompanyList(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _CommonModel.UserLoginId = JData["UserLoginId"].ToString();
            _CommonModel.SearchString = JData["SearchString"].ToString();
            _CommonModel.GetInsuranceCompanyList();
            CommonResult = _CommonModel.ResultDataSet.GetTableName();
            return GetResult();
        }
    }
}