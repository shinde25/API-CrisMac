﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace CrisMAcAPI.Models
{
    public class MetaUserFieldDetail : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string UserID { get; set; }
        public string MsgDescription { get; set; }
        public string ParameterType { get; set; }
        public int ParameterValue { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string _blnFetchMetaData { get; set; }
        public string _blnFetchMasterData { get; set; }
        public int _SeqNo { get; set; }
        public int NONUSE { get; set; }
        public int PWDCHNG { get; set; }
        public int PWDLEN { get; set; }
        public int PWDNUM { get; set; }
        public int PWDREUSE { get; set; }
        public int UNLOGON { get; set; }
        public int USERIDALP { get; set; }
        public int USERIDLEN { get; set; }
        public int USERIDLENMAX { get; set; }
        public int PWDLENMAX { get; set; }
        public int PWDALPHA { get; set; }
        public int USERHOMAX { get; set; }
        public int USERROMAX { get; set; }
        public int USERBOMAX { get; set; }
        public string Flag { get; set; }





        public void SelectParameterisedMasterData()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@blnFetchMetaData",_blnFetchMetaData),
                                               new SqlParameter("@TimeKey", _TimeKey),
                                               new SqlParameter("@blnFetchMasterData ",_blnFetchMasterData)

                };
            spName = "UserParameterParameterisedMasterData";
            ExecuteSelectDataSet();
        }

        public int UpdateUserParametersInsertUpdate()
        {
            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("dbo.UserParametersInsertUpdate");
            try
            {
                              
                using (command)
                {
                    database.AddInParameter(command, "CreatedBy", System.Data.DbType.String, _CreatedBy);
                    database.AddInParameter(command, "CreatedDate", System.Data.DbType.DateTime, DateTime.Now);
                    database.AddInParameter(command, "NONUSE", System.Data.DbType.Int32, NONUSE);
                    database.AddInParameter(command, "PWDCHNG", System.Data.DbType.Int32, PWDCHNG);
                    database.AddInParameter(command, "PWDLEN", System.Data.DbType.Int32, PWDLEN);
                    database.AddInParameter(command, "PWDNUM", System.Data.DbType.Int32, PWDNUM);
                    database.AddInParameter(command, "PWDREUSE", System.Data.DbType.Int32, PWDREUSE);
                    database.AddInParameter(command, "UNLOGON", System.Data.DbType.Int32, UNLOGON);
                    database.AddInParameter(command, "USERIDALP", System.Data.DbType.Int32, USERIDALP);
                    database.AddInParameter(command, "USERIDLEN", System.Data.DbType.Int32, USERIDLEN);
                    database.AddInParameter(command, "USERIDLENMAX", System.Data.DbType.Int32, USERIDLENMAX);
                    database.AddInParameter(command, "PWDLENMAX", System.Data.DbType.Int32, PWDLENMAX);
                    database.AddInParameter(command, "PWDALPHA", System.Data.DbType.Int32, PWDALPHA);
                    database.AddInParameter(command, "USERSHOMAX", System.Data.DbType.Int32, USERHOMAX);
                    database.AddInParameter(command, "USERSROMAX", System.Data.DbType.Int32, USERROMAX);
                    database.AddInParameter(command, "USERSBOMAX", System.Data.DbType.Int32, USERBOMAX);
                    database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                    database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                    database.AddInParameter(command, "Flag", System.Data.DbType.String, _OperationFlag);
                    database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _TimeKey);
                    database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);

                    database.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return (int)(command.Parameters)[command.Parameters.Count - 1].Value;

        }
    }
}