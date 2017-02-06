using CrisMAcAPI.Areas.CommonMaster.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.CommonComponent.Models.Repository.CommonMasterRepository
{
    public class CommonMasterRepository : ICommonMasterRepository
    {
        CommonMasterModel objMaster = new CommonMasterModel();
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = 100 };

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
                    FieldCaption = x.Field<string>("FieldCaption"),
                    DataValue = x.Field<string>("DataValue"),
                    DataType = x.Field<string>("DataType"),
                    FieldName = x.Field<string>("FieldName"),
                    DataLength = x.Field<short>("DataLength"),
                    ColumnWidth = x.Field<short>("ColumnWidth"),
                    DisplayRowOrder = x.Field<short>("DisplayRowOrder"),
                    ReferenceTable = x.Field<string>("ReferenceTable"),
                    ReferenceColumn = x.Field<string>("ReferenceColumn"),
                    FieldMessage = x.Field<string>("FieldMessage"),
                    IsMandatory = x.Field<string>("IsMandatory"),
                    IsMainTable = x.Field<string>("IsMainTable"),
                    IsYesNo = x.Field<string>("IsYesNo"),
                    CreatedModifiedBy = x.Field<string>("CreatedModifiedBy"),
                    Condition = x.Field<string>("Condition"),
                    ValidationCol_Data = x.Field<string>("ValidationCol_Data"),
                    MasterTableName = x.Field<string>("MasterTableName"),
                    AuthorisationStatus = x.Field<string>("AuthorisationStatus")
                }).ToList();


            var F2Table = ds.Tables[1].AsEnumerable().Select(x =>
                 new
                 {
                     RefTableName = x.Field<string>("RefTableName"),
                     RefColumnName = x.Field<string>("RefColumnName"),
                     Code = x.Field<short>("Code")

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
        public List<object> GetAuxdata(string paramString)
        {
            JObject jsondata = JObject.Parse(paramString);

            objMaster._MenuID = Convert.ToInt32(jsondata["menuID"]);
            objMaster._TimeKey = Convert.ToInt32(jsondata["timekey"]);
            objMaster._OperationMode = Convert.ToInt32(jsondata["opMode"]);

            objMaster.GetAuxData();
            DataSet ds = objMaster.ResultDataSet;
            var auxData = ds.Tables[0].AsEnumerable().Select(x =>
                new
                {
                    Code = x.Field<short>("Code"),
                    Description = x.Field<string>("Description"),
                    EntityKey = x.Field<int>("EntityKey")
                }).ToList();

            var lstAux = ((IEnumerable<dynamic>)auxData).ToList();
            return lstAux;
        }
        public int InsertUpdateData(string jsonData)
        {
            int _resultvalue = 0;
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                objMaster = serializer.Deserialize<CommonMasterModel>(jsonData);
                _resultvalue = objMaster.CommonMasterMaintainenceInsertUpdate(objMaster);
            }
            catch (Exception e)
            {

            }
            return _resultvalue;
        }
        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public List<object> FetchData_CheckPending(string paramString)
        {
            try
            {
                CheckpendingModal _CheckpendingModal = new CheckpendingModal();
                JObject jsondata = JObject.Parse(paramString);
                _CheckpendingModal._MenuID = Convert.ToInt32(jsondata["_menuId"].ToString());
                _CheckpendingModal._BranchCode = jsondata["_branchCode"].ToString();
                //objMaster._TimeKey= Convert.ToInt32(jsondata["_TimeKey"].ToString());
                //objMaster._OperationFlag= Convert.ToInt32(jsondata["_OperationFlag"].ToString());
                _CheckpendingModal.CheckpendingSelect();
                DataTable dt = _CheckpendingModal.ResultDataTable;

                var column = dt.AsEnumerable().Select(x =>
                    new
                    {
                        BranchCode = x.Field<string>("BranchCode"),
                        MenuID = x.Field<int>("MenuID"),
                        ReferenceID = x.Field<string>("ReferenceID"),
                        MenuCaption = x.Field<string>("MenuCaption"),
                        LogCreationStatus = x.Field<string>("LogCreationStatus"),
                        LogCreatedBy = x.Field<string>("LogCreatedBy"),
                        LogCreatedDt = x.Field<string>("LogCreatedDt"),
                        Remark = x.Field<string>("Remark"),
                        SNO = x.Field<Int64>("SNO"),
                        EntityKey = x.Field<int>("EntityKey")

                    }).ToList();
                var lst = ((IEnumerable<dynamic>)column).ToList();
                return lst;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public List<object> FetchReportData(string paramString)
        {
            try
            {
                ReportModel _CheckpendingModal = new ReportModel();
                JObject jsondata = JObject.Parse(paramString);
                _CheckpendingModal.ReportMenuId = Convert.ToInt32(jsondata["ReportMenuId"].ToString());
                //_CheckpendingModal._BranchCode = jsondata["_branchCode"].ToString();
                //objMaster._TimeKey= Convert.ToInt32(jsondata["_TimeKey"].ToString());
                //objMaster._OperationFlag= Convert.ToInt32(jsondata["_OperationFlag"].ToString());
                _CheckpendingModal.ReportDataSelect();
                DataTable dt = _CheckpendingModal.ResultDataTable;

                var column = dt.AsEnumerable().Select(x =>
                    new
                    {
                        //ReportID = x.Field<int>("ReportID"),
                        //ReportType = x.Field<int>("ReportType"),
                        //ReportRdlName = x.Field<string>("ReportRdlName"),
                        ReportUrl = x.Field<string>("ReportUrl"),
                        ReportRdlName = x.Field<string>("ReportRdlName"),
                        //ReportRdlFullName = x.Field<string>("ReportRdlFullName"),
                        //LogCreatedDt = x.Field<string>("LogCreatedDt"),
                        //Remark = x.Field<string>("Remark"),
                        //SNO = x.Field<Int64>("SNO"),
                        //EntityKey = x.Field<int>("EntityKey")

                    }).ToList();
                var lst = ((IEnumerable<dynamic>)column).ToList();
                return lst;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}