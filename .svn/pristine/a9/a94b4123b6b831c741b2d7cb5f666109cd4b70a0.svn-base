using CrisMAc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.Krishak.Models
{
    public class BranchSelectionModel : CommonProperties
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

        public void Select_SysBRZDataSelect()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@Condition",Condition),
                                               new SqlParameter("@Code", Code)
                                               //,new SqlParameter("@Top", Top)
                };
            spName = "[dbo].[BRZDataTemp]";
            ExecuteSelectDataSet();
        }
    }
}