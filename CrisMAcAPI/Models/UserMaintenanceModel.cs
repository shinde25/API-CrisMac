using CrisMAc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using CrisMAcAPI.Models.Utility;

namespace CrisMAcAPI.Models
{
    public class UserMaintenanceModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string LoginPassword { get; set; }
        public string EmployeeID { get; set; }
        public string IsEmployee { get; set; }
        public string DeptGroupCode { get; set; }
        public string IsChecker { get; set; }
        public string UserRole { get; set; }

        public void UserCreationParameterisedMasterData()
        {
            sqlParams = new SqlParameter[]
            {
               new SqlParameter("@UserLoginID",_userLoginId),
               new SqlParameter("@TimeKey",_TimeKey),
               new SqlParameter ("@UserCreationModification",_UtilFlag)
            };
            spName = "UserCreationParameterisedMasterData";
            ExecuteSelectDataSet();
        }
        public void UserModificationAuxSelect()
        {
            sqlParams = new SqlParameter[]
            {
               new SqlParameter("@UserLocationCode",_userLocation),
               new SqlParameter("@UserRole",_roleDesc),
               new SqlParameter("@TimeKey",_TimeKey)
            };
            spName = "UserModificationAuxSelect";
            ExecuteSelect();
        }
        public int UserCreationInsert(UserMaintenanceModel objUserMaintanance)
        {
            UtilityWebGenric objUtilityWebGen = new UtilityWebGenric("dbo.UserCreationInsert");
            objUtilityWebGen.addParam("UserLoginID", objUserMaintanance._userLoginId, 'I');
            objUtilityWebGen.addParam("EmployeeID	", objUserMaintanance.EmployeeID, 'I');
            objUtilityWebGen.addParam("IsEmployee", objUserMaintanance.IsEmployee, 'I');
            objUtilityWebGen.addParam("UserName", objUserMaintanance._userName, 'I');
            objUtilityWebGen.addParam("LoginPassword", objUserMaintanance.LoginPassword, 'I');
            objUtilityWebGen.addParam("UserLocationCode", objUserMaintanance._userLocation, 'I');
            objUtilityWebGen.addParam("UserRoleAlt_Key", objUserMaintanance._userAltKey, 'I');
            objUtilityWebGen.addParam("DeptGroupCode", objUserMaintanance.DeptGroupCode, 'I');
            objUtilityWebGen.addParam("DateCreated", objUserMaintanance._dtDateCreated, 'I');
            objUtilityWebGen.addParam("CreatedBy", objUserMaintanance._CreatedBy, 'I');
            objUtilityWebGen.addParam("Activate", objUserMaintanance._active, 'I');
            objUtilityWebGen.addParam("IsChecker", objUserMaintanance.IsChecker, 'I');
            objUtilityWebGen.addParam("EffectiveFromTimeKey", objUserMaintanance._EffectiveFromTimeKey, 'I');
            objUtilityWebGen.addParam("EffectiveToTimeKey", objUserMaintanance._userLoginId, 'I');
            objUtilityWebGen.addParam("Flag", objUserMaintanance._OperationFlag, 'I');
            objUtilityWebGen.addParam("TimeKey", objUserMaintanance._TimeKey, 'I');
            return objUtilityWebGen.ExecuteInsert();
        }
    }
}