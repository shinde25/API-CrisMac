using CrisMAcAPI.Areas.CommonComponent.Models;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Mail;
using System.Configuration;

namespace CrisMAcAPI.Areas.LOS.Models.Repository.ScreenRepository
{
    public class ScreenRepository : IScreenRepository
    {
       ScreenModel _ScreenModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public DataSet GetScreenPreviousNextData(string Parameters)
        {
            _ScreenModel = new ScreenModel();
            serializer = new JavaScriptSerializer();
            _ScreenModel = serializer.Deserialize<ScreenModel>(Parameters);
            _DataSet = new DataSet();
            _DataSet = _ScreenModel.GetScreenPreviousNextData().SetTableName();
            return _DataSet;
        }

        
    }
}
