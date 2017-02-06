using CrisMAcAPI.Areas.CommonComponent.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace CrisMAcAPI.Areas.CMA.Models.Repository.RemarkRepository
{
    public class RemarkRepository : IRemarkRepository
    {
        RemarkModel objRemarkModel = new RemarkModel();
        JavaScriptSerializer _Serializer = new JavaScriptSerializer();
        DataSet objResult;
        DataSet CommonResult;
        DataTable dtStatus = new DataTable();

        public DataSet GetResult()
        {
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            try
            {
                if (CommonResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    CommonResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    CommonResult.Tables.Add(dtStatus);
                }
            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                CommonResult.Tables.Add(dtStatus);
            }
            return CommonResult;
        }

        public object RemarkInsertUpdate(string jsonData)
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);
            objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"].ToString());
            objRemarkModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"].ToString());
            objRemarkModel.UserLoginID = JData["UserLoginID"].ToString();
            objRemarkModel.Remark = JData["Remark"].ToString();
            // xml conversion
            //string JsonData = "{GridJsonData:" + Convert.ToString(JData["AssignActionData"]) + "}";
            //XmlDocument RemarkXml = JsonConvert.DeserializeXmlNode(Convert.ToString(JData["AssignActionData"]), "DataSet");
            //JData["AssignActionData"] = RemarkXml.InnerXml;
            //objRemarkModel.AssignActionData = JData["AssignActionData"].ToString();

            InsertObj = objRemarkModel.Insert_RemarkDetails();
            return InsertObj;
        }

        public object ActionableRemarkInsert(string jsonData)
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);
            objRemarkModel.RemarkID = Convert.ToInt32(JData["RemarkID"].ToString());
            objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"].ToString());
            objRemarkModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"].ToString());
            objRemarkModel.WhatIsToBeDone = JData["WhatIsToBeDone"].ToString();
            objRemarkModel.ByWhen = JData["ByWhen"].ToString();
            objRemarkModel.ByWhome = JData["ByWhome"].ToString();
            InsertObj = objRemarkModel.Insert_ActionableRemark();
            return InsertObj;
        }

        public object ActionEventUpdate(string jsonData)
        {
            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);
            
                
            objRemarkModel.RemarkID = Convert.ToInt32(JData["RemarkID"].ToString());
            objRemarkModel.EventID = Convert.ToInt32(JData["EventID"].ToString());
            objRemarkModel.Status = Convert.ToInt32(JData["Status"].ToString());
            objRemarkModel.CommencementDt = JData["CommencementDt"].ToString();
            objRemarkModel.CommencementRemark = JData["CommencementRemark"].ToString();
            objRemarkModel.ClosureDt = JData["ClosureDt"].ToString();
            objRemarkModel.ClosureRemark = JData["ClosureRemark"].ToString();
            objRemarkModel.UserLoginID = JData["UserLoginID"].ToString();

            InsertObj = objRemarkModel.Action_EventUpdate();
            return InsertObj;
        }

        public DataSet GetAssignAction(string paramString)
        {

            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            JObject JData = JObject.Parse(paramString);
            try
            {
                objRemarkModel.RemarkID = Convert.ToInt32(JData["RemarkID"]);
                objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"]);
                //objRemarkModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
                objRemarkModel.Get_AssignAction();

                objResult = objRemarkModel.ResultDataSet.GetTableName();
                if (objResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    objResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    objResult.Tables.Add(dtStatus);
                }
            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                objResult.Tables.Add(dtStatus);

            }
            return objResult;
        }

        public DataSet GetPreviousRemark(string paramString)
        {
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            JObject JData = JObject.Parse(paramString);

            try
            {
                objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"]);
                objRemarkModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
                objRemarkModel.GetPreviousRemark();
                objResult = objRemarkModel.ResultDataSet.GetTableName();
                if (objResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    objResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    objResult.Tables.Add(dtStatus);
                }

            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                objResult.Tables.Add(dtStatus);

            }
            return objResult;
        }


        public DataSet APP_GetActionEventDiaryDetailsRepo(string paramString)
        {
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            JObject JData = JObject.Parse(paramString);

            try
            {
                objRemarkModel.RemarkID = Convert.ToInt32(JData["RemarkID"]);
                objRemarkModel.GetActionEventDiaryDetails();

                objResult = objRemarkModel.ResultDataSet.GetTableName();
                if (objResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    objResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    objResult.Tables.Add(dtStatus);
                }

            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                objResult.Tables.Add(dtStatus);

            }
            return objResult;
        }



        public DataSet APP_DefaultStatusRepo()
        {
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            //JObject JData = JObject.Parse(paramString);

            try
            {
                objRemarkModel.GetDefaultStatus();

                objResult = objRemarkModel.ResultDataSet.GetTableName();
                if (objResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    objResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    objResult.Tables.Add(dtStatus);
                }

            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                objResult.Tables.Add(dtStatus);

            }
            return objResult;
        }

        public DataSet APP_StakeHolderListRepo(string paramString)
        {
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            JObject JData = JObject.Parse(paramString);

            try
            {
                objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"]);
                objRemarkModel.UserLoginID = Convert.ToString(JData["UserLoginID"]);
                objRemarkModel.CustomerEntityId = Convert.ToInt16(JData["CustomerEntityID"].ToString());
                objRemarkModel.GetStakeHolderList();

                objResult = objRemarkModel.ResultDataSet.GetTableName();
                if (objResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    objResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    objResult.Tables.Add(dtStatus);
                }
            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                objResult.Tables.Add(dtStatus);

            }
            return objResult;
        }


        //public object APP_CustomerReAllocationUpdateRepo(string jsonData)
        //{
        //    object InsertObj = null;
        //    JObject JData = JObject.Parse(jsonData);
        //    objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"].ToString());
        //    objRemarkModel.PriActionStakeHolders = Convert.ToString(JData["PriActionStakeHolders"].ToString());
        //    objRemarkModel.SecActionStakeHolders = JData["SecActionStakeHolders"].ToString();
        //    objRemarkModel.InfoActionStakeHolders = Convert.ToString(JData["InfoActionStakeHolders"].ToString());
        //    InsertObj = objRemarkModel.CustomerReAllocationUpdate();
        //    return InsertObj;
        //}


        public DataSet APP_ActionEventDiaryListRepo(string paramString) //----------APP_ActionEventDiaryListRepo
        {
            dtStatus.Columns.Add("StatusCode", typeof(int));
            dtStatus.Columns.Add("StatusMsg", typeof(string));
            dtStatus.TableName = "StatusTable";
            JObject JData = JObject.Parse(paramString);

            try
            {
                objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"]);
                objRemarkModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
                objRemarkModel.GetActionEventDiaryList();

                objResult = objRemarkModel.ResultDataSet.GetTableName();
                if (objResult.Tables.Count != 0)
                {
                    dtStatus.Rows.Add(1, "Success");
                    objResult.Tables.Add(dtStatus);
                }
                else
                {
                    dtStatus.Rows.Add(0, "Failure");
                    dtStatus.TableName = "StatusTable";
                    objResult.Tables.Add(dtStatus);
                }

            }
            catch
            {
                dtStatus.Rows.Add(0, "Failure");
                dtStatus.TableName = "StatusTable";
                objResult.Tables.Add(dtStatus);

            }
            return objResult;
        }

        public DataSet APP_GetRemarkListRepo(string paramString)
        {
            JObject JData = JObject.Parse(paramString);
            objRemarkModel.CustomerEntityId = Convert.ToInt32(JData["CustomerEntityID"]);
            objRemarkModel.AccountEntityID = Convert.ToInt32(JData["AccountEntityID"]);
            objRemarkModel.UserLoginID = Convert.ToString(JData["UserLoginID"]);
            objRemarkModel.GetRemarkList();
            CommonResult = objRemarkModel.ResultDataSet.GetTableName();
            return GetResult();
        }

        public object AssignActionInsertUpdateRepo(string jsonData)
        {

            object InsertObj = null;
            JObject JData = JObject.Parse(jsonData);

            objRemarkModel.RemarkID = Convert.ToInt32(JData["RemarkID"].ToString());
            objRemarkModel.AssignActionID = Convert.ToInt32(JData["AssignActionID"].ToString());
            objRemarkModel.ByWhen = JData["ByWhen"].ToString();
            objRemarkModel.WhatIsToBeDone = JData["WhatIsToBeDone"].ToString();
            objRemarkModel.PriActionStakeHolders = JData["PrimaryActionStakeHolder"].ToString();
            objRemarkModel.SecActionStakeHolders= JData["SecondaryActionStakeHolder"].ToString();
            objRemarkModel.InfoActionStakeHolders = JData["InfoStakeHolder"].ToString();

            InsertObj = objRemarkModel.AssignActionInsertUpdate();
            return InsertObj;
        }
    }
}