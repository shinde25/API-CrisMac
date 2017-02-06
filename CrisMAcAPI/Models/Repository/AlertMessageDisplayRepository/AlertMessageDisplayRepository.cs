using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.AlertMessageDisplayRepository
{
    public class AlertMessageDisplayRepository:IAlertMessageDisplayRepository
    {
        AlertMessageDisplayModel _AlertMessageDisplayModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        public List<object> GetAlertMessageList(string paramString)
        {
            _AlertMessageDisplayModel = new AlertMessageDisplayModel();
            serializer = new JavaScriptSerializer();
            _AlertMessageDisplayModel = serializer.Deserialize<AlertMessageDisplayModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _AlertMessageDisplayModel.Get_AlertMessageList();
            return _DataSet.ToList();
        }


    }
}