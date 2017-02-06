using CrisMAc.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models
{
    public class ReportParameterModel : CommonProperties
    {
        public int _ReportID { get; set; }
        public int DimReportColAlt_Key { get; set; }
        public int ReportMenuId { get; set; }
        public int DisplayOrder { get; set; }
        public string Label { get; set; }
        public string ControlType { get; set; }
        public string DataType { get; set; }
        public int ColumnWidth { get; set; }
        public string ReferenceTable { get; set; }
        public string ReferenceColumn { get; set; }
        public string MasterTableValidCode { get; set; }
        public string Frequency { get; set; }
        public int EffectiveFromTimeKey { get; set; }
        public int EffectiveToTimeKey { get; set; }
        public string DynamicGrp { get; set; }
        public string CustFacility { get; set; }
        public int AdminSelectCode { get; set; }


        public void SelectReportParams(int _ReportID, int _Timekey)
        {
            sqlParams = new SqlParameter[] {
                                                new SqlParameter("@ReportID", _ReportID),
                                                new SqlParameter("@TimeKey",_Timekey)
                                           };

            spName = "DBO.SelectReportParams";
            ExecuteSelectDataSet();
        }

        public void SysParameterForSummaryDtLocationSelect(ReportParameterModel model)
        {
            sqlParams = new SqlParameter[] {
                                                new SqlParameter("@MenuID", model._MenuID),
                                                new SqlParameter("@UserLoginId",model._userLoginId),
                                                new SqlParameter("@UserLocation",model._userLocationName),
                                                new SqlParameter("@UserLocCode",model._userLocationCode),
                                                new SqlParameter("@Frequency",model.Frequency),
                                                new SqlParameter("@EffectiveFromTimeKey",model.EffectiveFromTimeKey),
                                                new SqlParameter("@EffectiveToTimeKey",model.EffectiveToTimeKey)
            };

            spName = "DBO.SysParameterForSummaryDtLocationSelect";
            ExecuteSelectDataSet();
        }

        public void SysParameterForSummaryAdminSelect()
        {
            sqlParams = new SqlParameter[] {
                                               
                                                new SqlParameter("@UserLoginId",_userLoginId),
                                                new SqlParameter("@DynamicGrp",DynamicGrp),
                                                new SqlParameter("@TimeKey",_TimeKey),
                                                new SqlParameter("@ReportType",_ReportID),
                                                new SqlParameter("@CustFacility",null),
                                                new SqlParameter("@Code",AdminSelectCode)
            };

            spName = "DBO.SysParameterForSummaryAdminSelect";
            ExecuteSelectDataSet();
        }

        public void DynamicReportMasterBinding(JObject parameterList)
        {
            SqlParameter[] spParaList = new SqlParameter[parameterList.Count-1];

            int cnt = 0;
            foreach (var spParameter in parameterList)
            {
                if (spParameter.Key.ToUpper() != "SPNAME")
                {
                    spParaList[cnt] = new SqlParameter("@" + spParameter.Key, spParameter.Value.ToString());
                    cnt++;
                }
                else
                    spName = spParameter.Value.ToString();
            }

            sqlParams = spParaList;
            ExecuteSelectDataSet();

        }
        
    }
}