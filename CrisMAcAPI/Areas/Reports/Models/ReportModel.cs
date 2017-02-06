using CrisMAc.Models;
using CrisMAc.Models.Utility;
using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace CrisMAcAPI.Models
{
    
    public class ReportModel : CommonProperties
    {
 
        public int ReportMenuId { get; set; }
        public string ReportUrl { get; set; }
        public void Select_ReportDetails(ReportModel obj)
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@ReportMenuId", obj.ReportMenuId),
                                               new SqlParameter("@TimeKey", obj._TimeKey)
                };
            spName = "DBO.Select_ReportDetail";
            ExecuteSelect();
        }

    }
}