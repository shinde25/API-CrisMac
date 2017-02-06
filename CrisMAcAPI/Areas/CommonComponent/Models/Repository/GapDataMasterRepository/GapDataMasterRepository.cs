using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CommonComponent.Models.Repository.GapDataMasterRepository
{
    class GapDataMasterRepository : IGapDataMasterRepository
    {
        GapDataMasterModel objMaster = new GapDataMasterModel();
        public List<object> FetchData(string paramString)
        {

            List<object> lst = new List<object>();
            JObject jsondata = JObject.Parse(paramString);

            objMaster._MenuID = Convert.ToInt32(jsondata["menuID"]);
            objMaster.MasterCode = Convert.ToInt32(jsondata["masterCode"]);
            objMaster._TimeKey = Convert.ToInt32(jsondata["timeKey"]);
            objMaster._OperationMode = Convert.ToInt32(jsondata["opMode"]);

            objMaster.Select_MasterMeta();
            DataSet ds = objMaster.ResultDataSet;
            var column = ds.Tables[0].AsEnumerable().Select(x =>
                new
                {
                    FieldName = x.Field<string>("FieldName"),
                    FieldCaption = x.Field<string>("FieldCaption"),
                    FieldMessage = x.Field<string>("FieldMessage"),
                    DataType = x.Field<string>("DataType"),
                    ISDBPull = x.Field<bool>("ISDBPull"),
                    ReferenceTable = x.Field<string>("ReferenceTable"),
                    ReferenceColumn = x.Field<string>("ReferenceColumn"),
                    ReferenceValue = x.Field<string>("ReferenceValue"),
                    ColumnType = x.Field<string>("ColumnType"),
                    ColumnLength = x.Field<dynamic>("ColumnLength"),
                    DataLength = x.Field<Int16>("DataLength"),
                    DataMinLength = x.Field<Int16>("DataMinLength"),
                    DataMaxLength = x.Field<Int16>("DataMaxLength"),
                    ControlName = x.Field<string>("ControlName"),

                    IsMandatory = x.Field<bool>("IsMandatory"),
                    IsVisible = x.Field<bool>("IsVisible"),
                    IsEditable = x.Field<bool>("IsEditable"),
                    IsUpper = x.Field<bool>("IsUpper"),
                    IsLower = x.Field<bool>("IsLower"),

                    DisAllowedChar = x.Field<string>("DisAllowedChar"),
                    AllowedChar = x.Field<string>("AllowedChar"),

                    OnBlur = x.Field<string>("OnBlur"),
                    OnBlurParameter = x.Field<string>("OnBlurParameter"),

                    OnClick = x.Field<string>("OnClick"),
                    OnClickParameter = x.Field<string>("OnClickParameter"),
                    OnChange = x.Field<string>("OnChange"),
                    OnChangeParameter = x.Field<string>("OnChangeParameter"),
                    OnKeyPress = x.Field<string>("OnKeyPress"),
                    OnKeyPressParameter = x.Field<string>("OnKeyPressParameter"),
                    OnFormLoad = x.Field<string>("OnFormLoad"),
                    OnFormLoadParameter = x.Field<string>("OnFormLoadParameter"),
                    DefaultValue = x.Field<string>("DefaultValue"),

                    DisplayRowOrder = x.Field<Int16>("DisplayRowOrder"),

                    SkipColumnInQuery = x.Field<string>("SkipColumnInQuery"),

                    TableColAlt_Key = x.Field<Int16>("TableColAlt_Key"),
                    AuthorisationStatus = x.Field<string>("AuthorisationStatus"),
                    DataValue= x.Field<string>("DataValue"),
                    IsMainTable = x.Field<string>("IsMainTable"),
                    CreatedModifiedBy = x.Field<string>("CreatedModifiedBy"),
                    IsF2Button = x.Field<bool>("IsF2Button"),
                    IsCloseButton = x.Field<bool>("IsCloseButton")
                }).ToList();

            var F2Table = ds.Tables[1].AsEnumerable().Select(x =>
                 new
                 {
                     RefTableName = x.Field<string>("RefTableName"),
                     Description = x.Field<string>("Description"),
                     Code = x.Field<string>("Code")

                 }).ToList();

            lst.Add(column);
            lst.Add(F2Table);

            if (ds.Tables.Count == 3)
            {
                var groupTbl = ds.Tables[2].AsEnumerable().Select(x =>
                  new
                  {
                      MasterGroup = x.Field<string>("MasterGroup"),
                      MasterSubGroup = x.Field<string>("MasterSubGroup"),
                      Code = x.Field<short>("Code"),
                      ColType = x.Field<string>("ColType")

                  }).ToList();

                lst.Add(groupTbl);
            }

            return lst;
        }
        public List<object> GetAuxMasterdata(string paramString)
        {
            JObject jsondata = JObject.Parse(paramString);

            objMaster._MenuID = Convert.ToInt32(jsondata["menuID"]);
            objMaster._TimeKey = Convert.ToInt32(jsondata["timekey"]);
            objMaster._OperationMode = Convert.ToInt32(jsondata["opMode"]);
            objMaster.SearchStr = jsondata["_SearchStr"].ToString();
            objMaster.TableColAlt_Key= Convert.ToInt32(jsondata["TableColAlt_Key"]);
            objMaster.GetAuxData();
            DataSet ds = objMaster.ResultDataSet;
            //var auxData = ds.Tables[0].AsEnumerable().Select(x =>
            //    new
            //    {
            //        Code = x.Field<dynamic>("Code"),
            //        Description = x.Field<string>("Description"),
            //        CustomerID = x.Field<dynamic>("CustomerID"),
            //        CustomerName = x.Field<string>("CustomerName")
            //    }).ToList();

            //var dns = new List<dynamic>();

            //foreach (var item in ds.Tables[0].AsEnumerable())
            //{
            //    // Expando objects are IDictionary<string, object>
            //    IDictionary<string, object> dn = new ExpandoObject();

            //    foreach (var column in ds.Tables[0].Columns.Cast<DataColumn>())
            //    {
            //        dn[column.ColumnName] = item[column];
            //    }

            //    dns.Add(dn);
            //}

            //var lstAux = ((IEnumerable<dynamic>)auxData).ToList();

            //var adsasd = (dns).ToList();


            //JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            //List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            //Dictionary<string, object> childRow;
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    childRow = new Dictionary<string, object>();
            //    foreach (DataColumn col in ds.Tables[0].Columns)
            //    {
            //        childRow.Add(col.ColumnName, row[col]);
            //    }
            //    parentRow.Add(childRow);
            //}

            //string jsonData = jsSerializer.Serialize(parentRow);

            return ds.ToList();
        }
        public int InsertUpdateData(string jsonData)
        {
            int _resultvalue = 0;
            try
            {
                
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                objMaster = serializer.Deserialize<GapDataMasterModel>(jsonData);
                _resultvalue = objMaster.CommonMasterMaintainenceInsertUpdate(objMaster);
            }
            catch (Exception e)
            {
                _resultvalue = -1;
            }
            return _resultvalue;
        }
        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public List<object> GetAuxdata(string paramString)
        {
            throw new NotImplementedException();
        }
    }
}
