﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CommonComponent.Models
{
    public static class GlobalExtension
    {
        /// <summary>
        /// Returns instance of this datatable to Json.
        /// </summary>
        /// <param name="dtToJson"></param>
        /// <returns></returns>
        public static string ToJson(this DataTable dtToJson)
        {
            
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtToJson.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtToJson.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            //string jsonData= jsSerializer.Serialize(parentRow);
            

            JavaScriptSerializer jser = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };
            return jser.Serialize(parentRow);

        }

        /// <summary>
        /// Returns instance of this DataSet to List of Object.
        /// </summary>
        /// <param name="Dataset">The object of DataSet to convert List.</param>
        /// <returns></returns>
        public static List<object> ToList(this DataSet Dataset)
        {
            List<object> lstObject = new List<object>();

            try
            {
                for (int tableIndex = 0; tableIndex < Dataset.Tables.Count; tableIndex++)
                {
                    DataTable dtToJson = Dataset.Tables[tableIndex];
                    List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                    Dictionary<string, object> childRow;
                    foreach (DataRow row in dtToJson.Rows)
                    {
                        childRow = new Dictionary<string, object>();
                        foreach (DataColumn col in dtToJson.Columns)
                        {
                            childRow.Add(col.ColumnName, row[col]);
                        }
                        parentRow.Add(childRow);
                    }

                    //string jsonData= jsSerializer.Serialize(parentRow);
                    //  JavaScriptSerializer jser = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };
                    lstObject.Add(parentRow);

                }
                return lstObject;
            }
            catch {
                return null;
            }

            

        }

        public static int ToInteger(this string input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch {
                return 0;
            }
        }

        public static DataSet GetTableName(this DataSet DataSet)
        {
            foreach (DataTable dt in DataSet.Tables)
            {
                try
                {
                    dt.TableName = dt.Rows[0]["TableName"].ToString();
                }
                catch { }
            }

            return DataSet;
        }

        public static DataSet SetTableName(this DataSet DataSet)
        {
            for (int index = 1; index < DataSet.Tables.Count; index++)
            {
                try
                {
                    DataSet.Tables[index].TableName = DataSet.Tables[0].Rows[index-1]["TableName"].ToString();
                }
                catch { }
            }

            return DataSet;
        }

    }
}