using CrisMAcAPI.Areas.CommonMaster.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Areas.CommonComponent.Models.Repository.CommonMetaMasterRepository
{
    public class CommonMetaMasterRepository : ICommonMetaMasterRepository
    {
        CommonMetaMasterModel objMaster = new CommonMetaMasterModel();
        public List<object> FetchData(string paramString)
        {
            List<object> lst = new List<object>();
            JObject jsondata = JObject.Parse(paramString);

            objMaster._MenuID = Convert.ToInt32(jsondata["menuID"]);
            objMaster.MasterCode = jsondata["masterCode"].ToString();
            objMaster._TimeKey = Convert.ToInt32(jsondata["timeKey"]);
            objMaster._OperationMode = Convert.ToInt32(jsondata["opMode"]);

            objMaster.Select_MasterMeta();
            DataSet ds = objMaster.ResultDataSet;
            //var column = ds.Tables[0].AsEnumerable().Select(x =>
            //    new
            //    {
            //        FieldName = x.Field<string>("FieldName"),
            //        FieldCaption = x.Field<string>("FieldCaption"),
            //        FieldMessage = x.Field<string>("FieldMessage"),
            //        DataType = x.Field<string>("DataType"),
            //        ISDBPull = x.Field<bool>("ISDBPull"),
            //        MasterTableFilter = x.Field<string>("MasterTableFilter"),
            //        ReferenceTable = x.Field<string>("ReferenceTable"),
            //        ReferenceColumn = x.Field<string>("ReferenceColumn"),
            //        ReferenceValue = x.Field<string>("ReferenceValue"),
            //        ColumnType = x.Field<string>("ColumnType"),
            //        ColumnLength = x.Field<dynamic>("ColumnLength"),
            //        DataLength = x.Field<Int16>("DataLength"),
            //        DataMinLength = x.Field<Int16>("DataMinLength"),
            //        DataMaxLength = x.Field<Int16>("DataMaxLength"),
            //        ControlName = x.Field<string>("ControlName"),

            //        IsMandatory = x.Field<bool>("IsMandatory"),
            //        IsVisible = x.Field<bool>("IsVisible"),
            //        IsEditable = x.Field<bool>("IsEditable"),
            //        IsUpper = x.Field<bool>("IsUpper"),
            //        IsLower = x.Field<bool>("IsLower"),

            //        DisAllowedChar = x.Field<string>("DisAllowedChar"),
            //        AllowedChar = x.Field<string>("AllowedChar"),

            //        OnBlur = x.Field<string>("OnBlur"),
            //        OnBlurParameter = x.Field<string>("OnBlurParameter"),

            //        OnClick = x.Field<string>("OnClick"),
            //        OnClickParameter = x.Field<string>("OnClickParameter"),
            //        OnChange = x.Field<string>("OnChange"),
            //        OnChangeParameter = x.Field<string>("OnChangeParameter"),
            //        OnKeyPress = x.Field<string>("OnKeyPress"),
            //        OnKeyPressParameter = x.Field<string>("OnKeyPressParameter"),
            //        OnFormLoad = x.Field<string>("OnFormLoad"),
            //        OnFormLoadParameter = x.Field<string>("OnFormLoadParameter"),
            //        DefaultValue = x.Field<string>("DefaultValue"),

            //        DisplayRowOrder = x.Field<Int16>("DisplayRowOrder"),

            //        SkipColumnInQuery = x.Field<string>("SkipColumnInQuery"),

            //        TableColAlt_Key = x.Field<Int16>("MasterTableColAlt_Key"),
            //        AuthorisationStatus = x.Field<string>("AuthorisationStatus"),
            //        DataValue = x.Field<string>("DataValue"),
            //        IsMainTable = x.Field<string>("IsMainTable"),
            //        CreatedModifiedBy = x.Field<string>("CreatedModifiedBy"),
            //        IsF2Button = x.Field<bool>("IsF2Button"),
            //        IsCloseButton = x.Field<bool>("IsCloseButton"),
            //        IsExtraButton = x.Field<bool>("IsExtraButton"),
            //        ExtraButtonName = x.Field<string>("ExtraButtonName"),
            //        ExtraButtonClick = x.Field<string>("ExtraButtonClick"),
            //        ExtraButtonClickParameter = x.Field<string>("ExtraButtonClickParameter")


            //    }).ToList();


            //var F2Table = ds.Tables[1].AsEnumerable().Select(x =>
            //     new
            //     {
            //         MasterTableFilter = x.Field<string>("MasterTableFilter"),
            //         RefTableName = x.Field<string>("RefTableName"),
            //         Description = x.Field<string>("Description"),
            //         Code = x.Field<dynamic>("Code")

            //     }).ToList();

            //lst.Add(column);
            //lst.Add(F2Table);

            //if (ds.Tables.Count == 3)
            //{
            //    var groupTbl = ds.Tables[2].AsEnumerable().Select(x =>
            //      new
            //      {
            //          MasterGroup = x.Field<string>("MasterGroup"),
            //          MasterSubGroup = x.Field<string>("MasterSubGroup"),
            //          Code = x.Field<short>("Code"),
            //          ColType = x.Field<string>("ColType")

            //      }).ToList();

            //    lst.Add(groupTbl);
            //}

           List<object> lsttemp = ds.ToList();

            return lsttemp;
        }
        public List<object> GetAuxMasterdata(string paramString)
        {
            JObject jsondata = JObject.Parse(paramString);

            objMaster._MenuID = Convert.ToInt32(jsondata["menuID"]);
            objMaster._TimeKey = Convert.ToInt32(jsondata["timekey"]);
            objMaster._OperationMode = Convert.ToInt32(jsondata["opMode"]);
            objMaster.SearchStr = jsondata["_SearchStr"].ToString();
            objMaster.TableColAlt_Key = Convert.ToInt32(jsondata["TableColAlt_Key"]);
            objMaster._userLoginId = Convert.ToString(jsondata["_userLoginId"]);
            objMaster.GetAuxData();
            DataSet ds = objMaster.ResultDataSet;


            //string jsonData= jsSerializer.Serialize(parentRow);

            return ds.ToList();
        }
        public int InsertUpdateData(string jsonData)
        {
            int _resultvalue = 0;
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                objMaster = serializer.Deserialize<CommonMetaMasterModel>(jsonData);
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

        List<Dictionary<string, object>> ICommonMetaMasterRepository.FetchData_CheckPending(string paramString)
        {
            throw new NotImplementedException();
        }

        List<object> ICommonInterface.GetAuxdata(string paramString)
        {
            throw new NotImplementedException();
        }

        public List<object> GetEventTemplate(string paramString)
        {
            JObject jsondata = JObject.Parse(paramString);

            objMaster._MenuID = Convert.ToInt32(jsondata["menuID"]);
            objMaster.MasterCode = jsondata["masterCode"].ToString();
            objMaster._TimeKey = Convert.ToInt32(jsondata["timeKey"]);
            objMaster._OperationMode = Convert.ToInt32(jsondata["opMode"]);

            objMaster.GetEventTemplate();
            DataSet ds = objMaster.ResultDataSet;

            

            return ds.ToList();
        }
    }
}