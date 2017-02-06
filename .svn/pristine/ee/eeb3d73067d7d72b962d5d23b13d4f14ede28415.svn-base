using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CMA.Models.Repository.DataSync
{
    public class DataSyncRepository : IDataSyncRepository
    {
        DataSyncModel _objModel = new DataSyncModel();
        JavaScriptSerializer _Serializer = new JavaScriptSerializer();
        DataSet CommonResult;

        public DataSet GetResult()
        {
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            try
            {
                if (CommonResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    CommonResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    CommonResult.Tables.Add(dtStatus);
                }
            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                CommonResult.Tables.Add(dtStatus);
            }
            return CommonResult;
        }

        public DataSet GetCustomerDetailsSyncRepo(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _objModel.CustomerEntityID = Convert.ToString(JData["CustomerEntityID"]);
            _objModel.Get_CustomerDetailsSync();
            CommonResult = _objModel.ResultDataSet.GetTableName();
            return GetResult();
        }        

        public DataSet GetDetailsSyncRepo(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _objModel.CustomerEntityID = Convert.ToString(JData["CustomerEntityID"]);
            _objModel.Get_DetailsSync();
            CommonResult = _objModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetActionDetailsSyncRepo(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            _objModel.CustomerEntityID = Convert.ToString(JData["CustomerEntityID"]);
            _objModel.Get_ActionDetailsSync();
            CommonResult = _objModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public object UploadDataToServer(string jsonData)   //----Customer ReAllocation Update
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);

            string xml = "{UploadToServerXML:" + Convert.ToString(JData["UploadToServerXML"]) + "}";
            var doc = JsonConvert.DeserializeXmlNode(xml, "DataSet");
            
            _objModel.XMLDocument = doc.InnerXml;
            _objModel.UserLoginID = Convert.ToString(JData["UserLoginID"]);

            InsertObj = _objModel.UploadDataToServer();
            return InsertObj;
        }
    }
}