using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.DashBoardRepository
{
    public class EwsHomeDashboardRepository: IEwsHomeDashboardRepository
    {
        EwsHomeDashboardModel _DashBoardModel;
        JavaScriptSerializer serializer;
        DataSet _DataSet;
        public List<object> GetDashBoardAllocatedCustomers(string paramString)
        {
            _DashBoardModel = new EwsHomeDashboardModel();
            serializer = new JavaScriptSerializer();
            _DashBoardModel = serializer.Deserialize<EwsHomeDashboardModel>(paramString);

            _DataSet = new DataSet();
            _DashBoardModel.DashBoardAllocatedCustomers();
            _DataSet = _DashBoardModel.ResultDataSet;
            return _DataSet.ToList();
        }

        public List<object> GetDashBoardNewsTwitsBlogs(string paramString)
        {
            _DashBoardModel = new EwsHomeDashboardModel();
            serializer = new JavaScriptSerializer();
            _DashBoardModel = serializer.Deserialize<EwsHomeDashboardModel>(paramString);

            _DataSet = new DataSet();
            _DashBoardModel.DashBoardNewsTwitsBlogs();
            _DataSet = _DashBoardModel.ResultDataSet;
            return _DataSet.ToList();
        }

        public List<object> GetDashBoardPendingActions(string paramString)
        {
            _DashBoardModel = new EwsHomeDashboardModel();
            serializer = new JavaScriptSerializer();
            _DashBoardModel = serializer.Deserialize<EwsHomeDashboardModel>(paramString);

            _DataSet = new DataSet();
            _DashBoardModel.DashBoardPendingActions();
            _DataSet = _DashBoardModel.ResultDataSet; 
            return _DataSet.ToList();
        }

        public List<object> GetDashBoardSelectSource(string paramString)
        {
            _DashBoardModel = new EwsHomeDashboardModel();
            serializer = new JavaScriptSerializer();
            _DashBoardModel = serializer.Deserialize<EwsHomeDashboardModel>(paramString);

            _DataSet = new DataSet();
            _DashBoardModel.DashBoardSelectSources();
            _DataSet = _DashBoardModel.ResultDataSet;
            return _DataSet.ToList();
        }
        public object GetInsertUpdateSourceData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
          
            _DashBoardModel = serializer.Deserialize<EwsHomeDashboardModel>(jsonData);
            rval = _DashBoardModel.EWSInsertUpdateSourceData();
            return rval;
        }
    }
}