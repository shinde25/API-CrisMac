using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Web;

namespace CrisMAc.Models.Utility
{
    public class UtilityWeb 
    {
        #region --Constructor--
        protected string ConnectionString;
        protected SqlParameter[] sqlParams;
        public UtilityWeb()
        {
            string ConnectionType = ConfigurationManager.AppSettings["connectionType"].ToString();
            if(ConnectionType == "SQL")
                ConnectionString = DecryptString(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            if (ConnectionType == "Oracle")
                ConnectionString = DecryptString(ConfigurationManager.ConnectionStrings["ConnStringOracle"].ConnectionString);
        }
        #endregion

        #region --object properties--

        private string m_spName;
        protected string spName
        {
            set { m_spName = value; }
        }
        public Int32 id { get; set; }
        public DataTable ResultDataTable { get; set; }
        public DataSet ResultDataSet { get; set; }
        public bool hasError { get; set; }
        public string ErrorCode { get; set; }
        protected string m_Message = "";
        public string Message
        {
            get { return m_Message; }
        }
        public string RetVal { get; set; }
        private object Result;
        private string strResult;
        #endregion

        #region --Methods--
        protected void ExecuteInsert()
        {
            try
            {
                Result = SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, m_spName, sqlParams);
                if (Result == null)
                    strResult = "0";
                else
                    strResult = Result.ToString();

                if (strResult.Contains("ErrorMsg:"))
                {
                    hasError = true;
                    m_Message = strResult.Substring("ErrorMsg:".Length);
                }
                else if (strResult.Contains("StepNo:"))
                {
                    hasError = true;
                    m_Message = strResult;
                }
                else
                {
                    //id = Convert.ToInt32(strResult);
                    RetVal = strResult;
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                ErrorCode = "1004";//sql error occure
                m_Message = ex.Message;
            }
            finally
            {

            }
        }
        protected void ExecuteSelect()
        {
            try
            {
                ResultDataTable = new DataTable();
                ResultDataSet = new DataSet();
                SqlDataReader rdr = SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, m_spName, sqlParams);
                ResultDataTable.Load(rdr);
                ResultDataSet.Tables.Add(ResultDataTable);
            }
            catch (Exception ex)
            {
                hasError = true;
                ErrorCode = "1004";//sql error occure
                m_Message = ex.Message;
            }
            finally
            {
            }
        }
        protected void ExecuteScalarSelect()
        {
            try
            {
                strResult = SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, m_spName, sqlParams).ToString();
                if (strResult.Contains("ErrorMsg:"))
                {
                    hasError = true;
                    m_Message = strResult.Substring("ErrorMsg:".Length);
                }
                else
                {
                    id = Convert.ToInt32(strResult);
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                ErrorCode = "1004";//sql error occure
                m_Message = ex.Message;
            }
            finally
            {

            }
        }
        protected void ExecuteUpdate()
        {
            try
            {
                strResult = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, m_spName, sqlParams).ToString();
                if (strResult.Contains("ErrorMsg:"))
                {
                    hasError = true;
                    m_Message = strResult.Substring("ErrorMsg:".Length);
                }
                else
                {
                    id = Convert.ToInt32(strResult);
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                ErrorCode = "1004";//sql error occure
                m_Message = ex.Message;
            }
            finally
            {

            }
        }
        protected void ExecuteSelectDataSet()
        {
            try
            {
                ResultDataTable = new DataTable();
                ResultDataSet = new DataSet();
                ResultDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, m_spName, sqlParams);
                ResultDataTable = ResultDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                hasError = true;
                ErrorCode = "1004";//sql error occure
                m_Message = ex.Message;
            }
            finally
            {
            }
        }
        protected void ExecuteDelete()
        {
            try
            {

                strResult = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, m_spName, sqlParams).ToString();
                if (strResult.Contains("ErrorMsg:"))
                {
                    hasError = true;
                    m_Message = strResult.Substring("ErrorMsg:".Length);
                }
                else
                {
                    id = Convert.ToInt32(strResult);
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                ErrorCode = "1004";//sql error occure
                m_Message = ex.Message;
            }
            finally
            {

            }
        }
        protected void ExecuteSearch()
        {
            try
            {
                ResultDataTable = new DataTable();
                ResultDataSet = new DataSet();
                ResultDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, m_spName, sqlParams);
                ResultDataTable = ResultDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                hasError = true;
                ErrorCode = "1004";//sql error occure
                m_Message = ex.Message;
            }
            finally
            {
            }
        }

        #endregion

        #region PasswordEncry_Decrypt
        public string EnryptString(string strEncrypted)
        {
            try
            {
                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
                string encryptedConnectionString = Convert.ToBase64String(b);
                return encryptedConnectionString;
            }
            catch
            {
                throw;
            }
        }
        public string DecryptString(string encrString)
        {
            try
            {
                byte[] b = Convert.FromBase64String(encrString);
                string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(b);
                return decryptedConnectionString;
            }
            catch
            {
                throw;
            }
        }
        public string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }

        #endregion

        #region JsonEncry_Decrypt

        public byte[] JsonCompressData(System.Collections.Generic.List<object> _json)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream gz = new GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
            StreamWriter sw = new StreamWriter(gz);
            sw.WriteLine(_json);
            sw.Close();
            return ms.ToArray();

        }

        #endregion

       
    }
}