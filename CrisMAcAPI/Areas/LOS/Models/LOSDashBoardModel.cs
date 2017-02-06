using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.LOS.Models
{
    public class LOSDashBoardModel
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string LoanType { get; set; }

        public int DataCount { get; set; }

        public JObject GetCriteriaEligibleData()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("GetCriteriaEligibleData");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "LoanType", System.Data.DbType.String, LoanType);
                   
                    database.AddOutParameter(command, "DataCount", System.Data.DbType.Int32, DataCount);
                    database.ExecuteNonQuery(command);
                }
                JObject DBReturnResult = new JObject();
                DBReturnResult.Add("DataCount", (command.Parameters)[command.Parameters.Count-1].Value.ToString());
                return DBReturnResult;
            }
            catch (Exception ex)
            {
                JObject DBReturnResult = new JObject();
                DBReturnResult.Add("DataCount", ex.Message);
                return DBReturnResult;
            }

        }
    }
}