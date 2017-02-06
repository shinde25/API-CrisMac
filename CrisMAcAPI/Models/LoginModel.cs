             using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models
{
    class LoginModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string userName { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string LoginSucceeded { get; set; }
        public void Select_LoginDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginID",userName),
                                               new SqlParameter("@LoginPassword", Password)
                };
            spName = "UserAuthentication_new";
            ExecuteSelectDataSet();
        }
        public string Insert_UserLoginHistory()
        {
            //sqlParams = new SqlParameter[] {
            //                                   new SqlParameter("@UserID",userName),
            //                                   new SqlParameter("@IPAdress",IpAddress),
            //                                   new SqlParameter("@LoginTime",LoginTime),
            //                                   new SqlParameter("@LogoutTime",LogoutTime),
            //                                   new SqlParameter("@LoginSucceeded",LoginSucceeded)
            //    };
            //spName = "UserLoginHistoryInsert";
            //ExecuteInsert();

            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("dbo.UserLoginHistoryInsert_new");
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "UserID", System.Data.DbType.String, userName);
                    database.AddInParameter(command, "IPAdress", System.Data.DbType.String, IpAddress);
                    database.AddInParameter(command, "LoginTime", System.Data.DbType.DateTime, LoginTime);
                    database.AddInParameter(command, "LogoutTime", System.Data.DbType.DateTime, LogoutTime);
                    database.AddInParameter(command, "LoginSucceeded", System.Data.DbType.String, LoginSucceeded);
                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                    database.AddOutParameter(command, "LastLoginOut", System.Data.DbType.String, 50);
                }
                database.ExecuteNonQuery(command);
                JObject Jobj = new JObject();
                Jobj.Add("Result", (int)((command.Parameters)[command.Parameters.Count - 2].Value.ToString() == "" ? 0 : (command.Parameters)[command.Parameters.Count - 2].Value));
                Jobj.Add("LastLoginOut", (string)(command.Parameters)[command.Parameters.Count - 1].Value);


                return Jobj.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Select_LastLoginDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserID",userName)
                };
            spName = "GetLastLoginDetails_Result";
            ExecuteSelect();
        }
        public void Select_SysCurrentTimeKey()
        {
            sqlParams = new SqlParameter[] {
                };
            spName = "SysCurrentTimeKey";
            ExecuteSelect();
        }
        public void Select_SelectLastQtyKey()
        {
            sqlParams = new SqlParameter[] {
                };
            spName = "SysCMOCTimeKey";
            ExecuteSelect();
        }
        public static DataSet DecompressData(byte[] data)
        {
            DataSet ds;
            MemoryStream memStream = new MemoryStream(data);
            GZipStream unzipStream = new GZipStream(memStream, CompressionMode.Decompress);
            ds = new DataSet();
            ds.ReadXml(unzipStream, XmlReadMode.ReadSchema);
            unzipStream.Close();
            memStream.Close();
            return ds;
        }
        public static byte[] CompressData(DataSet ds)
        {
            byte[] data;
            MemoryStream memStream = new System.IO.MemoryStream();
            GZipStream zipStream = new System.IO.Compression.GZipStream(memStream, CompressionMode.Compress);
            ds.WriteXml(zipStream, XmlWriteMode.WriteSchema);
            zipStream.Close();
            data = memStream.ToArray();
            memStream.Close();
            return data;

        }

    }

}

