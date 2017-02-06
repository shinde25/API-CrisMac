using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.App_DashboardRepository
{
    public class App_DashboardRepository : IApp_DashboardRepository
    {
        JavaScriptSerializer _Serializer = new JavaScriptSerializer();
        DataSet CompanyResult;
        App_DashboardModel objModel = new App_DashboardModel();

        public DataSet GetResult()
        {
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            try
            {
                if (CompanyResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    CompanyResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    CompanyResult.Tables.Add(dtStatus);
                }
            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                CompanyResult.Tables.Add(dtStatus);
            }
            return CompanyResult;
        }


        public DataSet GetCompanyList(string param)
        {
            JObject JData = JObject.Parse(param);
            objModel.UserLoginId = JData["UserLoginId"].ToString();
            objModel.SearchString = JData["SearchString"].ToString();
            objModel.Get_CompanyList();
            CompanyResult = objModel.ResultDataSet.GetTableName();
            return GetResult();
        }


        public DataSet GetCompanyScore(string param)
        {
            JObject JData = JObject.Parse(param);
            objModel.CompanyAlt_Key = Convert.ToInt16(JData["CompanyAlt_Key"]);
            objModel.InclCompanyGrp = Convert.ToInt16(JData["InclCompanyGrp"]);
            objModel.InclFwdLinkedCompany = Convert.ToInt16(JData["InclFwdLinkedCompany"]);
            objModel.InclBwdLinkedCompany = Convert.ToInt16(JData["InclBwdLinkedCompany"]);
            objModel.IncPeerCompany = Convert.ToInt16(JData["IncPeerCompany"]);
            objModel.Get_CompanyScore();
            CompanyResult = objModel.ResultDataSet.GetTableName();
            return GetResult();
        }


        public DataSet GetCompanyDetail(string param)
        {
            JObject JData = JObject.Parse(param);
            objModel.CompanyAlt_Key = Convert.ToInt16(JData["CompanyAlt_Key"]);
            objModel.InclCompanyGrp = Convert.ToInt16(JData["InclCompanyGrp"]);
            objModel.InclFwdLinkedCompany = Convert.ToInt16(JData["InclFwdLinkedCompany"]);
            objModel.InclBwdLinkedCompany = Convert.ToInt16(JData["InclBwdLinkedCompany"]);
            objModel.IncPeerCompany = Convert.ToInt16(JData["IncPeerCompany"]);
            objModel.Get_CompanyDetail();
            CompanyResult = objModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetStandingList(string param)
        {
            JObject JData = JObject.Parse(param);
            objModel.UserLoginId = JData["UserLoginId"].ToString();
            objModel.GetStandingList();
            CompanyResult = objModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetNewsDetails(string param)
        {
            JObject JData = JObject.Parse(param);
            objModel.CompanyAlt_Key = Convert.ToInt16(JData["CompanyAlt_Key"]);
            objModel.InclCompanyGrp = Convert.ToInt16(JData["InclCompanyGrp"]);
            objModel.InclFwdLinkedCompany = Convert.ToInt16(JData["InclFwdLinkedCompany"]);
            objModel.InclBwdLinkedCompany = Convert.ToInt16(JData["InclBwdLinkedCompany"]);
            objModel.IncPeerCompany = Convert.ToInt16(JData["IncPeerCompany"]);
            objModel.CompareWith = Convert.ToChar(JData["CompareWith"]);
            objModel.PlotPeriod = Convert.ToChar(JData["PlotPeriod"]);
            objModel.Get_NewsDetails();
            CompanyResult = objModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetTwitterDetails(string param)
        {
            JObject JData = JObject.Parse(param);
            objModel.CompanyAlt_Key = Convert.ToInt16(JData["CompanyAlt_Key"]);
            objModel.InclCompanyGrp = Convert.ToInt16(JData["InclCompanyGrp"]);
            objModel.InclFwdLinkedCompany = Convert.ToInt16(JData["InclFwdLinkedCompany"]);
            objModel.InclBwdLinkedCompany = Convert.ToInt16(JData["InclBwdLinkedCompany"]);
            objModel.IncPeerCompany = Convert.ToInt16(JData["IncPeerCompany"]);
            objModel.CompareWith = Convert.ToChar(JData["CompareWith"]);
            objModel.PlotPeriod = Convert.ToChar(JData["PlotPeriod"]);
            objModel.Get_TwitterDetails();
            CompanyResult = objModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public DataSet GetStockDetails(string param)
        {
            JObject JData = JObject.Parse(param);
            objModel.CompanyAlt_Key = Convert.ToInt16(JData["CompanyAlt_Key"]);
            objModel.InclCompanyGrp = Convert.ToInt16(JData["InclCompanyGrp"]);
            objModel.InclFwdLinkedCompany = Convert.ToInt16(JData["InclFwdLinkedCompany"]);
            objModel.InclBwdLinkedCompany = Convert.ToInt16(JData["InclBwdLinkedCompany"]);
            objModel.IncPeerCompany = Convert.ToInt16(JData["IncPeerCompany"]);
            objModel.CompareWith = Convert.ToChar(JData["CompareWith"]);
            objModel.PlotPeriod = Convert.ToChar(JData["PlotPeriod"]);
            objModel.Get_StockDetails();
            CompanyResult = objModel.ResultDataSet.GetTableName();
            return GetResult();
        }
    }
}