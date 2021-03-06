﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CrisMAcAPI.Areas.FAM.Controllers;

namespace CrisMAcAPI.Filter
{
    public class LogFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            AddDataToSP Obj = new AddDataToSP();
            try
            {
                Obj.APIAreaName = ConfigurationManager.AppSettings["AreaName"].ToString();
                Obj.Token = filterContext.Request.Headers.Authorization.ToString();
                Obj.Response = ((System.Net.Http.ObjectContent)filterContext.Response.Content).Value.ToString().Length.ToString();
                Obj.ResponseType = filterContext.Request.Method.ToString();
                Obj.StatusCode = filterContext.Response.StatusCode.ToString();
                Obj.Port = filterContext.Response.RequestMessage.RequestUri.Port.ToString();
                Obj.AbsoluteUri = filterContext.Response.RequestMessage.RequestUri.AbsoluteUri.ToString();
                Obj.Host = filterContext.Request.RequestUri.Host.ToString();

                if (Obj.ResponseType.ToUpper() == "POST")
                {
                    Obj.Param = filterContext.Request.Content.ReadAsStringAsync().Result;
                }
                Obj.AddToLogTable();
            }
            catch (Exception)
            {

               
            }
        }
    }

    public class AddDataToSP
    {

        public string APIAreaName { get; set; }
        public string Response { get; set; }
        public string StatusCode { get; set; }
        public string Port { get; set; }
        public string AbsoluteUri { get; set; }
        public string Host { get; set; }
        public string ResponseType { get; set; }
        public string IP { get; set; }
        public string Device { get; set; }
        public string Param { get; set; }
        public string Token { get; set; }

        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public DataSet AddToLogTable()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("WebAPILogInsertUpdate");
            DataSet ds = new DataSet();
            try
            {
                using (command)
                {
                    database.AddInParameter(command, "@Status", System.Data.DbType.String, StatusCode);
                    database.AddInParameter(command, "@Port", System.Data.DbType.String, Port);
                    database.AddInParameter(command, "@Url", System.Data.DbType.String, AbsoluteUri);
                    database.AddInParameter(command, "@Response", System.Data.DbType.String, Response);
                    database.AddInParameter(command, "@ServerName", System.Data.DbType.String, Host);
                    database.AddInParameter(command, "@API", System.Data.DbType.String, APIAreaName);
                    database.AddInParameter(command, "@ResponseType", System.Data.DbType.String, ResponseType);
                    database.AddInParameter(command, "@IP", System.Data.DbType.String, IP);
                    database.AddInParameter(command, "@Device", System.Data.DbType.String, Device);
                    database.AddInParameter(command, "@Param", System.Data.DbType.String, Param);
                    database.AddInParameter(command, "@Token", System.Data.DbType.String, Token);


                    ds = database.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}