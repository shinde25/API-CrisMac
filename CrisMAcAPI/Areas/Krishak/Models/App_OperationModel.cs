using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.Krishak.Models
{
    public class App_OperationModel: CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        private SqlParameter[] sqlParams;

        public string SearchString { get; set; }
        public string BranchCode { get; set; }

        public DataSet GetBranchList()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("App_GetBranchList");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "SearchString", System.Data.DbType.String, SearchString);

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public DataSet GetVillageList()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("App_GetVillageList");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "BranchCode", System.Data.DbType.String, BranchCode);

                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
    }
}