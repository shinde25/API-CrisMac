using CrisMAc.Models;
using System;
using System.Data.SqlClient;

namespace CrisMAcAPI.Models
{
    public class BranchSelection : CommonProperties
    {
        public Nullable<short> ZoneAltKey { get; set; }
        public string BranchBusinessCategory { get; set; }
        public string BranchCode2 { get; set; }
        public string ShowValue { get; set; }
        public string PrevLevelMoc { get; set; }
        public string CurrLevelMoc { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string MonthCaption { get; set; }
        public string Condition { get; set; }
        public int? Top { get; set; }

        public string BranchCode { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public void Select_SysBRZDataSelect_Moc()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@Condition",Condition),
                                               new SqlParameter("@Code", Code),
                                               new SqlParameter("@Top", Top)
                };
            spName = "[SysBRZDataSelect_Moc_mvc]";
            ExecuteSelectDataSet();
        }
        public void LastBranchSelectUpdate()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@userLoginId",UserId),
                                               new SqlParameter("@Type", Type),
                                               new SqlParameter("@BranchCode", BranchCode)
                };
            spName = "dbo.LastLoginBranchSelectUpdate";
            ExecuteSelectDataSet();
        }
    }

}