using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CrisMAc.Models;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CrisMAcAPI.Models
{
    public class UserGroupDeptModel: CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuCaption { get; set; }
        public int MenuTitled { get; set; }
        public int DataSequence { get; set; }
        public string MsgDescription { get; set; }
        public int EntityKey { get; set; }
        public int DeptGroupId { get; set; }
        public string DeptGroupName { get; set; }
        public string DeptGroupDesc { get; set; }
        public string AvailableFor { get; set; }

        public void UserGroupDeptParameterisedMasterData()
        {

            sqlParams = new SqlParameter[] {
                                            new SqlParameter("@TimeKey", _TimeKey)

                };
            spName = "UserGroupParameterisedMasterData";//SysCRisMacaSystemMenu
            ExecuteSelectDataSet();
        }

        public void UserGroupsAuxSelect()
        {
            sqlParams = new SqlParameter[]
            {
                new SqlParameter("@TimeKey", _TimeKey)
            };
            spName = "UserGroupsAuxSelect";
            ExecuteSelect();
        }
        public int UserGroupInsertUpdate()
        {

            Database database = factory.Create("ConnStringDecr");
            DbCommand command = database.GetStoredProcCommand("dbo.UserGroupInsertUpdate");
            using (command)
            {
                database.AddInParameter(command, "EntityKey", System.Data.DbType.Int32, EntityKey);
                database.AddInParameter(command, "DeptGroupId", System.Data.DbType.Int32, DeptGroupId);
                database.AddInParameter(command, "DeptGroupName", System.Data.DbType.String, DeptGroupName);
                database.AddInParameter(command, "DeptGroupDesc", System.Data.DbType.String, DeptGroupDesc);
                database.AddInParameter(command, "MenuId", System.Data.DbType.String, MenuId);
                database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _EffectiveFromTimeKey);
                database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _EffectiveToTimeKey);
                database.AddInParameter(command, "CreatedBy", System.Data.DbType.String, _CreatedBy);
                database.AddInParameter(command, "timekey", System.Data.DbType.Int32, _TimeKey);
                database.AddInParameter(command, "flag", System.Data.DbType.Int32, _OperationFlag);
                database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);
                database.ExecuteNonQuery(command);
            }

            return (int)(command.Parameters)[command.Parameters.Count - 1].Value;

            //sqlParams = new SqlParameter[]
            //{
            //      new SqlParameter("@EntityKey",EntityKey),
            //      new SqlParameter("@DeptGroupId", DeptGroupId),
            //      new SqlParameter("@DeptGroupName", DeptGroupName),
            //      new SqlParameter("@DeptGroupDesc",DeptGroupDesc),
            //      new SqlParameter("@MenuId",MenuId),
            //      new SqlParameter("@EffectiveFromTimeKey", _EffectiveFromTimeKey),
            //      new SqlParameter("@EffectiveToTimeKey", _EffectiveToTimeKey),
            //      new SqlParameter("@CreatedBy", _CreatedBy),
            //      new SqlParameter("@timekey", _TimeKey),
            //       new SqlParameter("@flag",_OperationFlag)                                    					
            //};
            //spName = "UserGroupInsertUpdate";
            //ExecuteInsert();
        }
    }
}