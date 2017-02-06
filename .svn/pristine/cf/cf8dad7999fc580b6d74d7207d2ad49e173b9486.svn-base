using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models
{
    public class CompanyListModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string UserLoginId { get; set; }
        public string SearchString { get; set; }        


        public void Get_CompanyList()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginId",UserLoginId),
                                               new SqlParameter("@SearchString",SearchString)
                                           };
            spName = "[EWS].[GetCompanyList]";
            ExecuteSelectDataSet();
        }
    }
}