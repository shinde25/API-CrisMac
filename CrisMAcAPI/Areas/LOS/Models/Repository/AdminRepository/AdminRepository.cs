using CrisMAcAPI.Areas.CommonComponent.Models;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Mail;
using System.Configuration;

namespace CrisMAcAPI.Areas.LOS.Models.Repository.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        AdminModel _AdminModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        public DataSet GetQECApplicationData(string Parameters)
        {
            _AdminModel = new AdminModel();
            serializer = new JavaScriptSerializer();
            _AdminModel = serializer.Deserialize<AdminModel>(Parameters);
            _DataSet = new DataSet();
            _DataSet = _AdminModel.GetQECApplicationData().SetTableName();
            return _DataSet;
        }


     


    }
}
