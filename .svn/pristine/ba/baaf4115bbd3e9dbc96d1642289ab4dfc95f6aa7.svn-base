using CrisMAc.Models.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models.Utility
{
    public class UtilityWebGenric
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        Database database;
        DbCommand command;
        public UtilityWebGenric(string spName)
        {
             database = factory.Create("ConnStringOracle");
             command = database.GetStoredProcCommand(spName);
        }

        public void addParam(string paramName , dynamic paramVal, char paramType)
        {
            string dataType = paramVal.GetType().Name;
            System.Data.DbType Dtype = System.Data.DbType.String;
            switch (dataType)
            {
                case "Int32":
                    Dtype = System.Data.DbType.Int32;
                    break;
                case "String":
                    Dtype = System.Data.DbType.String;
                    break;
                default:
                    break;
            }
            //using (command) {
                if (paramType == 'I')
                    database.AddInParameter(command, paramName, Dtype, paramVal);
                else
                    database.AddOutParameter(command, paramName, Dtype, paramVal);

            //}
                
        }

        public int ExecuteInsert()
        {

            //command.Connection.ConnectionString = "";

            //using (command)
            //{
            //    foreach (var item in _obj)
            //    {
            //        string dataType = item.Value.GetType().Name;
            //        System.Data.DbType Dtype = System.Data.DbType.String;
            //        switch (dataType)
            //        {
            //            case "Int32":
            //                Dtype = System.Data.DbType.Int32;
            //                break;
            //            case "String":
            //                Dtype = System.Data.DbType.String;
            //                break;
            //            default:
            //                break;
            //        } 

            //        database.AddInParameter(command, item.Key, Dtype, item.Value);
            //    }
            using (command)
                database.ExecuteNonQuery(command);

               return (int)(command.Parameters)[command.Parameters.Count - 1].Value;
           // }
        }
    }
}