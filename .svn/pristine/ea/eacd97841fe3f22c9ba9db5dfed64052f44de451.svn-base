using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models;
using System.Text;
using System.Security.Cryptography;

namespace CrisMAcAPI.Areas.D2k_Inventory.Models.Repository.AppLoginRepository
{
    public class AppLoginRepository : IAppLoginRepository
    {
        AppLoginModel _AppLogin;
        DataSet _DataSet;
        JavaScriptSerializer _Serializer;

        public List<object> APPUserPwdPolicySelect()
        {
            _AppLogin = new AppLoginModel();
            _Serializer = new JavaScriptSerializer();
            // _PasswordPolicy = serializer.Deserialize<AppPasswordPolicyModel>();

            _DataSet = new DataSet();
            _AppLogin.APPUserPwdPolicySelect(); // call to model's function
            _DataSet = _AppLogin.ResultDataSet;
            return _DataSet.ToList();
        }

       

        public object PasswordChangeInsertUpdateData(string jsonData)
        {
            object rval = null;
            _AppLogin = new AppLoginModel();
            JObject job = JObject.Parse(jsonData);
            _AppLogin.UserLoginID = Convert.ToString(job["UserLoginID"].ToString());
            string password = EncrPassword(job["LoginPassword"].ToString());
            _AppLogin.LoginPassword = password;
            //_AppLogin.LoginPassword = Convert.ToString(job["TimeKey"].ToString());
            rval = _AppLogin.AppChangePasswordInsertUpdate();  // call to model's function
            return rval;
        }

        
        public List<object> SelectUserAuthenticationDetails(string paramString)
        {
            _AppLogin= new AppLoginModel();
            _Serializer = new JavaScriptSerializer();
            JObject JData = JObject.Parse(paramString);
            string password= EncrPassword(JData["Password"].ToString());
            _AppLogin.UserLoginId = JData["UserLoginId"].ToString();
            _AppLogin.Password = password;
            _AppLogin.UserAuthDetails();
            DataSet AuthDetails = _AppLogin.ResultDataSet;

            return AuthDetails.ToList();
                
            
        }

        private string EncrPassword(string _password)
        {
            UnicodeEncoding uEncode = new UnicodeEncoding();
            Byte[] bytProducts = uEncode.GetBytes(_password);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] hash = sha1.ComputeHash(bytProducts);
            return Convert.ToBase64String(hash);
        }


    }
}