using CrisMAc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.CommonComponent.Models
{
    public class CheckpendingModal: CommonProperties
    {
        public void CheckpendingSelect()
        {
            sqlParams = new SqlParameter[] {

                                               new SqlParameter("@MenuId", _MenuID),
                                               new SqlParameter("@BranchCode", _BranchCode)
                };
            spName = "[SysCRisMacPendingAuthorization_New]";
            ExecuteSelectDataSet();
        }
    }
}