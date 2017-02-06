using CrisMAc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.CommonComponent.Models
{
    public class ReportModel : CommonProperties
    {

        public int ReportMenuId { get; set; }
        public void ReportDataSelect()
        {
            sqlParams = new SqlParameter[] {

                                               new SqlParameter("@ReportID", ReportMenuId),
                                              // new SqlParameter("@BranchCode", _BranchCode)
                };
            spName = "[dbo].[SelectReportData]";
            ExecuteSelectDataSet();
        }
    }
}