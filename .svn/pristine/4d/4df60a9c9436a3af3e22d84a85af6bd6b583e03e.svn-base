using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.CompanyListRepository
{
    public class CompanyListRepository : ICompanyListRepository
    {
        JavaScriptSerializer _Serializer = new JavaScriptSerializer();
        DataSet CompanyResult;
        CompanyListModel objModel = new CompanyListModel();

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
            CompanyResult= objModel.ResultDataSet.GetTableName();
            return GetResult();
        }
        
    }
}