using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models;
using System.Text;
using System.Security.Cryptography;

namespace CrisMAcAPI.Areas.CMA.Models.Repository.AppLoginRepository
{
    public class CMALoginRepository : ICMALoginRepository
    {
        CMALoginModel _AppLogin;
        DataSet _DataSet;
        JavaScriptSerializer _Serializer;


        public object PasswordChangeInsertUpdateData(string jsonData)
        {
            object rval = null;
            _AppLogin = new CMALoginModel();
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
            _AppLogin = new CMALoginModel();
            _Serializer = new JavaScriptSerializer();
            JObject JData = JObject.Parse(paramString);
            //string password = EncrPassword(JData["Password"].ToString());
            _AppLogin.UserLoginID = JData["UserLoginID"].ToString();
            //_AppLogin.Password = JData["Password"].ToString();
            _AppLogin.Password = EncrPassword(JData["Password"].ToString());
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

        public object APP_ChangePasswordRepo(string jsonData)
        {
            object rval = null;
            _AppLogin = new CMALoginModel();
            JObject job = JObject.Parse(jsonData);
            _AppLogin.UserLoginID = Convert.ToString(job["UserLoginID"].ToString());
            string password = EncrPassword(job["CurrentPassword"].ToString());
            _AppLogin.CurrentPassword = password;
            string passwordNew = EncrPassword(job["NewPassword"].ToString());
            _AppLogin.NewPassword = passwordNew;
          //  _AppLogin.TimeKey = Convert.ToInt32(job["TimeKey"].ToString());
            rval = _AppLogin.ChangePassword();
            return rval;
        }
    }
}