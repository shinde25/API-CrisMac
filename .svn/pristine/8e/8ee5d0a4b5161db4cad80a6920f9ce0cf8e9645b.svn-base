using CrisMAcAPI.Areas.CommonComponent.Models;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Mail;
using System.Configuration;

namespace CrisMAcAPI.Areas.LOS.Models.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        UserModel _UseromerModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;
        
        public JObject InsertUserProfile(string jsonData)
        {
            _UseromerModel = new UserModel();
            serializer = new JavaScriptSerializer();
            _UseromerModel = serializer.Deserialize<UserModel>(jsonData);

            JObject obj = _UseromerModel.InsertUserProfile();

            return obj;
        }
        public JObject UserAuthentication(string jsonData)
        {
            _UseromerModel = new UserModel();
            serializer = new JavaScriptSerializer();
            _UseromerModel = serializer.Deserialize<UserModel>(jsonData);

            JObject obj = _UseromerModel.UserAuthentication();

            return obj;
        }
    }
}
