using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.Common;

namespace CrisMAcAPI.Areas.LOS.Models
{
    public class ScreenModel
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string LoanType { get; set; }
        

        public DataSet GetScreenPreviousNextData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("GetScreenPreviousNextData");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "LoanType", System.Data.DbType.String, LoanType);
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