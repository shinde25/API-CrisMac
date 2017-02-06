using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CrisMAc.Models;

namespace CrisMAcAPI.Models
{
    public class GroupCreatParaMastDataModel:CommonProperties
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuCaption { get; set; }
        public int MenuTitled { get; set; }
        public int DataSequence { get; set; }
        public string MsgDescription { get; set; }




        public void Select_UserGrpDeptCreationData()
        {

            sqlParams = new SqlParameter[] {
                                            new SqlParameter("@TimeKey", _TimeKey)

                };
            spName = "UserGroupParameterisedMasterData";//SysCRisMacaSystemMenu
            ExecuteSelectDataSet();
        }
    }
}