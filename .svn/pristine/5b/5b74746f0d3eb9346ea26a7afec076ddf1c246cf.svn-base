using CrisMAcAPI.Models.Repository.CommonInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using CrisMAcAPI.Areas.CommonComponent.Models;

namespace CrisMAcAPI.Models.Repository.ReportParameterRepository
{
    public class ReportParameterRepository : IReportParameterRepository
    {
        ReportParameterModel model = new ReportParameterModel();
        public List<object> FetchData(string paramString)
        {
            JObject jsonData = JObject.Parse(paramString);
            List<object> lstObj = new List<object>();

            // model._ReportID = 22800;
            //   model._ReportID = 17700;
            model._ReportID = Convert.ToInt32(jsonData["_ReportID"].ToString());
            model._TimeKey = Convert.ToInt32(jsonData["_TimeKey"].ToString());

            try
            {
                model.SelectReportParams(model._ReportID, model._TimeKey);
                DataSet _dsAux = model.ResultDataSet;

                return _dsAux.ToList();

                //var lstMetaParam = _dsAux.Tables[0].AsEnumerable().Select(x =>
                //      new
                //      {
                //          DimReportColAlt_Key = x.Field<Int16>("DimReportColAlt_Key"),
                //          ReportMenuId = x.Field<Int16>("ReportMenuId"),
                //          DisplayOrder = x.Field<Int16>("DisplayOrder"),
                //          Label = x.Field<string>("Label"),
                //          ControlType = x.Field<string>("ControlType"),
                //          DataType = x.Field<string>("DataType"),
                //          ColumnWidth = x.Field<byte>("ColumnWidth"),
                //          IsDBPull = x.Field<Boolean>("IsDBPull"),
                //          ReferenceTable = x.Field<string>("ReferenceTable"),
                //          ReferenceColumn = x.Field<string>("ReferenceColumn"),
                //          MasterTableValidCode = x.Field<string>("MasterTableValidCode"),
                //          ControlName = x.Field<string>("ControlName"),
                //          RoutineNo = x.Field<string>("RoutineNo"),
                //          RoutineArgument = x.Field<string>("RoutineArgument")
                //      }).ToList();

                //var lstFreqMst = _dsAux.Tables[1].AsEnumerable().Select(x =>
                //      new
                //      {
                //          ReportFrequencyName = x.Field<string>("ReportFrequencyName"),
                //          ReportID = x.Field<string>("ReportID"),
                //          ReportFrequencyAlt_Key = x.Field<Int16>("ReportFrequencyAlt_Key")
                //      }).ToList();


                //var lstFreqDtls = _dsAux.Tables[2].AsEnumerable().Select(x =>
                //     new
                //     {
                //         Frequency = x.Field<string>("Frequency"),
                //         SeqNo = x.Field<Int16>("SeqNo"),
                //         ReportID = x.Field<string>("ReportID"),
                //         ReportType = x.Field<string>("ReportType"),
                //         ReportRdlName = x.Field<string>("ReportRdlName"),
                //         ReportUrl = x.Field<string>("ReportUrl"),
                //         VersionNo = x.Field<string>("VersionNo"),
                //         Remark = x.Field<string>("Remark"),
                //         DeploymentDt = x.Field<string>("DeploymentDt"),
                //         Frequency_Period = x.Field<string>("Frequency_Period"),

                //         Deploy = x.Field<string>("Deploy"),
                //         Deploy_Prod = x.Field<string>("Deploy_Prod"),
                //         ReportMenuId = x.Field<int>("ReportMenuId"),
                //         ReportRdlFullName = x.Field<string>("ReportRdlFullName"),
                //         ReportFieldDisplay = x.Field<string>("ReportFieldDisplay"),
                //         DeptReportNo = x.Field<string>("DeptReportNo"),
                //         RBI_ReportNo = x.Field<string>("RBI_ReportNo"),
                //         CRisMacReportNo = x.Field<string>("CRisMacReportNo"),
                //         ReportFrequency_Key = x.Field<Int16>("ReportFrequency_Key"),
                //         ReportingDay = x.Field<string>("ReportingDay"),

                //         ReportOwnerMain = x.Field<string>("ReportOwnerMain"),
                //         ReportOwnerAlternate = x.Field<string>("ReportOwnerAlternate"),
                //         ExportReportId = x.Field<string>("ExportReportId"),
                //         ExportReportName = x.Field<string>("ExportReportName"),
                //         DeptGroupId = x.Field<string>("DeptGroupId"),
                //         PreMoc = x.Field<string>("PreMoc")
                //     }).ToList();


                //lstObj.Add(lstMetaParam);
                //lstObj.Add(lstFreqMst);
                //lstObj.Add(lstFreqDtls);

                //for (int TableCnt = 3; TableCnt < _dsAux.Tables.Count; TableCnt++)
                //{

                //    var lstMaster = _dsAux.Tables[TableCnt].AsEnumerable().Select(x =>
                //      new
                //      {
                //          TableKey = x.Field<dynamic>("TableKey"),
                //          Code = x.Field<dynamic>("Code"),
                //          Description = x.Field<dynamic>("Description")
                //      }
                //        ).ToList();
                //    lstObj.Add(lstMaster);

                //}




                //var _reportParam = ((IEnumerable<dynamic>)lstObj).ToList();
                //return _reportParam;


            }
            catch (Exception e)
            {
                throw;
            }
        }




        public List<object> GetAuxdata(string paramString)
        {
            JObject jsonData = JObject.Parse(paramString);
            List<object> lstObj = new List<object>();

            model._MenuID = 92405;
            //model._MenuID = Convert.ToInt32(jsonData["_MenuID"].ToString());            
            model._userLoginId = jsonData["_userLoginId"].ToString();
            model._userLocation = jsonData["_userLocation"].ToString();
            model._userLocationName = jsonData["_userLocationName"].ToString();
            model._userLocationCode = jsonData["_userLocationCode"].ToString();
            model.Frequency = jsonData["Frequency"].ToString();
            model.EffectiveFromTimeKey = Convert.ToInt32(jsonData["EffectiveFromTimeKey"].ToString());
            model.EffectiveToTimeKey = Convert.ToInt32(jsonData["EffectiveToTimeKey"].ToString());

            try
            {
                model.SysParameterForSummaryDtLocationSelect(model);
                DataSet _dsAux = model.ResultDataSet;

                var lstYear = _dsAux.Tables[0].AsEnumerable().Select(x =>
                      new
                      {
                          Code = x.Field<string>("Code"),
                          Description = x.Field<string>("Description")
                      }).ToList();

                var lstMnth = _dsAux.Tables[1].AsEnumerable().Select(x =>
                      new
                      {
                          Code = x.Field<string>("Code"),
                          Year = x.Field<string>("Year"),
                          Description = x.Field<string>("Description"),
                          MonthLastDate = x.Field<DateTime>("MonthLastDate"),
                          monthfirstdate = x.Field<DateTime>("monthfirstdate"),
                          MonthCaption = x.Field<string>("MonthCaption")
                      }).ToList();


                var lstDate = _dsAux.Tables[2].AsEnumerable().Select(x =>
                     new
                     {
                         Code = x.Field<Int16>("Code"),
                         Description = x.Field<string>("Description"),
                         MonthYear = x.Field<string>("MonthYear")
                     }).ToList();

                var lstAdminGrp = _dsAux.Tables[3].AsEnumerable().Select(x =>
                     new
                     {
                         DynamicGroup_Key = x.Field<Int16>("DynamicGroup_Key"),
                         DynamicGroupName = x.Field<string>("DynamicGroupName"),
                         DynamicGroupValue = x.Field<string>("DynamicGroupValue"),
                         DynamicGroupLabel = x.Field<string>("DynamicGroupLabel"),
                         MaxValue = x.Field<dynamic>("MaxValue")
                     }).ToList();

                var lstAmtIn = _dsAux.Tables[4].AsEnumerable().Select(x =>
                     new
                     {
                         Code = x.Field<string>("Code"),
                         Description = x.Field<string>("Description")
                     }).ToList();

                var lstReportType = _dsAux.Tables[6].AsEnumerable().Select(x =>
                     new
                     {
                         CustFacilityLabel = x.Field<string>("CustFacilityLabel"),
                         CustFacilityValue = x.Field<string>("CustFacilityValue")
                     }).ToList();


                lstObj.Add(lstYear);
                lstObj.Add(lstMnth);
                lstObj.Add(lstDate);
                lstObj.Add(lstAdminGrp);
                lstObj.Add(lstAmtIn);
                lstObj.Add(lstReportType);


                var _reportParam = ((IEnumerable<dynamic>)lstObj).ToList();
                return _reportParam;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<object> GetBranchMaster(string paramString)
        {
            JObject jsonData = JObject.Parse(paramString);
            List<object> lstObj = new List<object>();

            model._userLoginId = jsonData["_userLoginId"].ToString();
            model._userLocation = jsonData["_userLocation"].ToString();
            model._userLocationName = jsonData["_userLocationName"].ToString();
            model._userLocationCode = jsonData["_userLocationCode"].ToString();
            model.DynamicGrp = jsonData["DynamicGrp"].ToString();

            model._TimeKey = Convert.ToInt32(jsonData["_TimeKey"].ToString());
            model.CustFacility = "1";
            model.AdminSelectCode = 1;



            try
            {
                model.SysParameterForSummaryAdminSelect();
                DataSet _dsAux = model.ResultDataSet;

                var lstAdminLocation = _dsAux.Tables[0].AsEnumerable().Select(x =>
                      new
                      {
                          AdminValue = x.Field<dynamic>("AdminValue"),
                          AdminValueLable = x.Field<string>("AdminValueLable")
                      }).ToList();

                var _reportParam = ((IEnumerable<dynamic>)lstAdminLocation).ToList();
                return _reportParam;
            }
            catch (Exception e)
            {
                throw;
            }


        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public int InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }

        public List<object> GetDynamicMasterData(string paramString)
        {
            JObject jsonData = JObject.Parse(paramString);
            List<object> lstObj = new List<object>();
            model.DynamicReportMasterBinding(jsonData);
            DataSet _dsAux = model.ResultDataSet;

            try
            {
                //var lstDynamicMaster = _dsAux.Tables[0].AsEnumerable().Select(x =>
                //         new
                //         {
                //            // ControlKey = "Grpf",
                //             Code = x.Field<dynamic>("Code"),
                //             Description = x.Field<dynamic>("Description")
                //         }).ToList();

                //var _reportParam = ((IEnumerable<dynamic>)lstDynamicMaster).ToList();

                return _dsAux.ToList();
            }
            catch(Exception e)
            {
                return null;
            }
            //_dsAux.Tables[0].Columns.Add("ControlKey");
            //_dsAux.Tables[0].Columns["ControlKey"].DefaultValue = "Grpf";

            
        }
    }
}