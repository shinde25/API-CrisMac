using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.Common;

namespace CrisMAcAPI.Areas.LOS.Models
{
    public class AdminModel
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string Location { get; set; }
       

        public DataSet GetQECApplicationData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("GetQECApplicationData");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "Location", System.Data.DbType.String, Location);

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