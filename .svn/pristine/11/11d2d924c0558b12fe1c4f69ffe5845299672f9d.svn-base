using CrisMAc.Models;
using CrisMAc.Models.Utility;
using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;


namespace CrisMAcAPI.Models
{
    public class MenuModel:CommonProperties
    {
      
        public int EntityKey { get; set; }
        public Nullable<int> MenuTitleId { get; set; }
        public Nullable<int> DataSeq { get; set; }
        public Nullable<int> MenuId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string MenuCaption { get; set; }
        public string BusFld { get; set; }
        public string ThirdGroup { get; set; }
        public string ApplicableFor { get; set; }
        public bool Visible { get; set; }
        public string ReportId { get; set; }
        public string AvailableFor { get; set; }
        public string NonAllowOperation { get; set; }
        public string DeptGroupCode { get; set; }
        public string EnableMakerChecker { get; set; }
        public string ResponseTimeDisplay { get; set; }
        public string Deptartment { get; set; }
        public string SaveWithCER { get; set; }
        public string ExecutionCer { get; set; }
        public string ActionName { get; set; }
        public string userLoginId { get; set; }

        public void Select_MenuList()
        {

            //sqlParams = new SqlParameter[]{
            //};

            //spName = "EWS.EWSMenu_Select_Temp";
            //ExecuteSelect();

            sqlParams = new SqlParameter[]{
                new SqlParameter("@UserLoginID", userLoginId),
                new SqlParameter("@TimeKey", _TimeKey)

            };
            spName = "SysCrisMAcModuleMenu_mvc";
            ExecuteSelect();
        }

        public void Select_MenuListDashboard()
        {

            sqlParams = new SqlParameter[] {
                                              new SqlParameter("@UserLoginID",userLoginId)

                };
            spName = "SysCRisMacaSystemMenu";//SysCRisMacaSystemMenu
            ExecuteSelect();
        }
    }
}