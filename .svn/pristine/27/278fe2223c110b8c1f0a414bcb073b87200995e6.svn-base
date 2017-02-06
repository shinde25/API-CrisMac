using CrisMAcAPI.Areas.CommonComponent.Models;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Mail;
using System.Configuration;
using System.Net;

namespace CrisMAcAPI.Areas.LOS.Models.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerModel _CustomerModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer; 
        public DataSet GetMasterData(string Parameters)
        {
            _CustomerModel = new CustomerModel();
            serializer = new JavaScriptSerializer();
            _CustomerModel = serializer.Deserialize<CustomerModel>(Parameters);
            _DataSet = new DataSet();
            _DataSet = _CustomerModel.GetMasterData().SetTableName();
            return _DataSet;
        }

        

        public JObject InsertQECApplication(string jsonData)
        {
            _CustomerModel = new CustomerModel();
            serializer = new JavaScriptSerializer();
            _CustomerModel = serializer.Deserialize<CustomerModel>(jsonData);

            JObject obj = _CustomerModel.InsertQECApplication();

            if (!string.IsNullOrEmpty(_CustomerModel.EmailID))
            {
                try
                {
                    string mobileNo = _CustomerModel.MobileNo;

                    string msgContent = "UserId : " + mobileNo + " Password: " + mobileNo;
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    string EmailID = ConfigurationManager.AppSettings["EmailID"].ToString();
                    string Password = ConfigurationManager.AppSettings["Password"].ToString();
                    mail.From = new MailAddress(EmailID);

                    mail.To.Add(_CustomerModel.EmailID);
                    mail.Subject = "ELS Username";
                    mail.Body = msgContent+ "  Thanks From Mobile Team D2KT";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(EmailID, Password);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {

                }
                try
                {
                    string mobileNo = _CustomerModel.MobileNo;
                   
                    string msgContent = "UserId : " + mobileNo + " Password: " + mobileNo;

                    string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=d2k@d2kindia.com:d2kd2k&senderID=TEST SMS&receipientno=" + mobileNo + "&msgtxt=" + msgContent + ""+"  Thanks From Mobile Team D2KT";

                    var request = (HttpWebRequest)WebRequest.Create(strUrl);
                    WebResponse webResp = request.GetResponse();

                    if (((HttpWebResponse)webResp).StatusCode == HttpStatusCode.OK)
                    {
                        // message sent
                    }
                    else
                    {
                        // message not sent
                    }
                }
                catch (Exception e)
                {

                }


            }
            return obj;
        }


    }
}
