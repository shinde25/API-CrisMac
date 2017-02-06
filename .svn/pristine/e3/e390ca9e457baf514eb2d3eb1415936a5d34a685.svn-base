using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Script.Serialization;
using System;
using Newtonsoft.Json.Linq;

namespace CrisMAcAPI.Models.Repository.ReportRepository
{
    public class ReportRepository : IReportRepository
    {
        

        ReportModel objRpt;
        public List<object> FetchData(string Param)
        {

            objRpt = new ReportModel();
            JObject jsondata = JObject.Parse(Param);
            objRpt.ReportMenuId = Convert.ToInt32(jsondata["ReportMenuId"]);
            objRpt._TimeKey = Convert.ToInt32(jsondata["TimeKey"]);

            objRpt.Select_ReportDetails(objRpt);
            DataTable dt = objRpt.ResultDataTable;
            var column = dt.AsEnumerable().Select(x =>
                new
                {ReportUrl = x.Field<string>("ReportUrl"),
                }).ToList();
            var lst = ((IEnumerable<dynamic>)column).ToList();
            return lst;
     
         }

        public List<object> GetAuxdata(string paramString)
        {
            throw new NotImplementedException();
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public int InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
    }