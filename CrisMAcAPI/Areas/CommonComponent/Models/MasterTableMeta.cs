using System.Data.SqlClient;
using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace CrisMAcAPI.Areas.CommonMaster.Models
{
    public class CommonMasterModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public string FieldCaption { get; set; }
        public int MasterCode { get; set; }

        public string ColumnName { get; set; }
        public string DataValue { get; set; }
        public string ColumnName_DataValue { get; set; }
        public int Code { get; set; }
        public string DateCreateModifyApproved { get; set; }


        public void Select_MasterMeta()
        {

            sqlParams = new SqlParameter[]{
                        new SqlParameter("@MenuId",_MenuID),
                        new SqlParameter("@MasterCode",MasterCode ),
                        new SqlParameter("@TimeKey", _TimeKey),
                        new SqlParameter ("@Mode",_OperationMode)
            };

             spName = "dbo.CommonMasterMaintainenceSelect";
          //  spName = "[dbo].[CommonGapData_MasterSelect]";
            ExecuteSelectDataSet();
        }

        public void GetAuxData()
        {
            sqlParams = new SqlParameter[]{
                        new SqlParameter("@MenuId",_MenuID),
                        new SqlParameter("@TimeKey", _TimeKey),
                        new SqlParameter("@Mode", _OperationMode),
            };

              spName = "dbo.CommonMasterMaintainenceAuxSelect";
           // spName = "[dbo].[CommonGapData_MasterAuxSelect]";
            ExecuteSelectDataSet();
        }

        public int CommonMasterMaintainenceInsertUpdate(CommonMasterModel _obj)
        {
            Database database = factory.Create("ConnStringDecr");

            ///////////////////////////////////////// CODE FOR SQL //////////////////////////////////////////////////

            DbCommand command = database.GetStoredProcCommand("dbo.CommonMasterMaintainenceInsertUpdate");
           // DbCommand command = database.GetStoredProcCommand("[dbo].[CommonGapData_MasterInsertUpdate]");

            using (command)
            {
                database.AddInParameter(command, "ColumnName", System.Data.DbType.String, _obj.ColumnName);
                database.AddInParameter(command, "DataValue", System.Data.DbType.String, _obj.DataValue);
                database.AddInParameter(command, "ColumnName_DataValue", System.Data.DbType.String, _obj.ColumnName_DataValue);
                database.AddInParameter(command, "Code", System.Data.DbType.Int16, _obj.Code);
                database.AddInParameter(command, "EffectiveFromTimeKey", System.Data.DbType.Int32, _obj._EffectiveFromTimeKey);
                database.AddInParameter(command, "EffectiveToTimeKey", System.Data.DbType.Int32, _obj._EffectiveToTimeKey);
                //database.AddInParameter(command, "DateCreateModifyApproved", System.Data.DbType.String, _obj.DateCreateModifyApproved);
                database.AddInParameter(command, "CreateModifyApprovedBy", System.Data.DbType.String, _obj._CreatedBy);
                database.AddInParameter(command, "OperationFlag", System.Data.DbType.Int32, _obj._OperationFlag);
                database.AddOutParameter(command, "D2Ktimestamp", System.Data.DbType.Int32, _obj._D2Ktimestamp);
                database.AddInParameter(command, "TimeKey", System.Data.DbType.Int32, _obj._TimeKey);
                database.AddInParameter(command, "AuthMode", System.Data.DbType.String, _obj._AuthMode);
                database.AddInParameter(command, "MenuID", System.Data.DbType.Int32, _obj._MenuID);
                database.AddInParameter(command, "Remark", System.Data.DbType.String, _obj._Remark);
                database.AddOutParameter(command, "Result", System.Data.DbType.Int32, -1);

                database.ExecuteNonQuery(command);
            }

            return (int)(command.Parameters)[13].Value;

            ///////////////////////////////////////////////////////////////////////////////////////



            ///////////////////////////////////// CODE FOR ORACLE  //////////////////////////////////////////////////
            //Dictionary<string, dynamic> saveLst = new Dictionary<string, dynamic>();
            //UtilityWebGenric ug = new UtilityWebGenric("TEST_INSERT");
            //ug.addParam("id", _obj.CustomerEntityId,'I');
            //ug.addParam("fNAME", _obj.FinYear, 'I');
            //ug.addParam("LnAME", _obj.Periodicity, 'I');


            //ug.ExecuteInsert();
            ///////////////////////////////////////////////////////////////////////////////////////




            ////////////////////////CODE FOR MYSQL  ///////////////////////////////////////////////////////////////
            //Dictionary<string, dynamic> saveLst = new Dictionary<string, dynamic>();
            //saveLst.Add("p_id", _obj.CustomerEntityId);
            //saveLst.Add("p_fname", _obj.FinYear);
            //saveLst.Add("p_lname", _obj.Periodicity);

            //UtilityWebGenric ug = new UtilityWebGenric();
            //ug.ExecuteInsert("sp_test_INSERT", saveLst);
            ///////////////////////////////////////////////////////////////////////////////////////
        }
    }
}