﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.Alert.Models.Repository
{
    public class AlertRepository : IAlertRepository
    {
        AlertModel objModel = new AlertModel();

        public List<object> FetchData(string paramString)
         {
            List<object> lst = new List<object>();
            JObject jsondata = JObject.Parse(paramString);
            objModel.fetchStr = (jsondata["_FetchKey"]).ToString();
            objModel._TimeKey = Convert.ToInt32(jsondata["_TimeKey"]);
            objModel._OperationMode = Convert.ToInt32(jsondata["_OpMode"]);
            objModel._BranchCode = (jsondata["BranchCode"]).ToString();            

            objModel.ProspectFetchSelect(objModel);
            DataSet ds = objModel.ResultDataSet;
            var column = ds.Tables[0].AsEnumerable().Select(x =>
                new
                {
                    CustomerEntityID = x.Field<int>("CustomerEntityID"),
                    ProspectID = x.Field<string>("ProspectID"),
                    CustomerName = x.Field<string>("CustomerName"),
                    DefendantID = x.Field<int>("DefendantID"),
                    DefendantName = x.Field<string>("DefendantName"),
                    LegalDefendantTypeName = x.Field<string>("LegalDefendantTypeName"),
                    CommNoticeTypeName = x.Field<string>("CommNoticeTypeName"),
                    DPD = x.Field<Int16>("DPD"),
                    ChequeDt = x.Field<string>("ChequeDt"),
                    ReturnDt = x.Field<string>("ReturnDt"),
                    Amount = x.Field<decimal>("Amount"),
                    BankName = x.Field<string>("BankName"),
                    BranchName = x.Field<string>("BranchName"),
                    NoticePrintDt = x.Field<string>("NoticePrintDt"),
                    NoticePrintConfDt = x.Field<string>("NoticePrintConfDt"),
                    NoticeSignDt = x.Field<string>("NoticeSignDt"),
                    SignatoryName = x.Field<string>("SignatoryName"),
                    DispatchDt = x.Field<string>("DispatchDt"),
                    DispatchModeAlt_Key = x.Field<Int16>("DispatchModeAlt_Key"),
                    DispatchRefNo = x.Field<string>("DispatchRefNo"),
                    DispatchProofID = x.Field<string>("DispatchProofID"),
                    DeliverStatusAlt_Key = x.Field<Int16>("DeliverStatusAlt_Key"),
                    DeliveryDt = x.Field<string>("DeliveryDt"),
                    DeliveryProofID = x.Field<string>("DeliveryProofID"),
                    NoticeReturnDt = x.Field<string>("NoticeReturnDt"),
                    NoticePublication_YN = x.Field<string>("NoticePublication_YN"),
                    D2Ktimestamp = x.Field<int>("D2Ktimestamp"),
                    ChangedField = x.Field<string>("ChangedField"),
                    CreatedModifiedBy = x.Field<string>("CreatedModifiedBy"),
                    DateCreated = x.Field<string>("DateCreated"),                   
                    DateModified = x.Field<string>("DateModified"),
                    ApprovedBy = x.Field<string>("ApprovedBy"),
                    DateApproved = x.Field<string>("DateApproved"),
                    AuthorisationStatus = x.Field<string>("AuthorisationStatus"),
                    IsMainTable = x.Field<string>("IsMainTable")

                }).ToList();

            var history = ds.Tables[1].AsEnumerable().Select(x =>
               new
               {
                   ProspectID = x.Field<string>("ProspectID"),
                   DefendantID = x.Field<int>("DefendantID"),
                   DefendantName = x.Field<string>("DefendantName"),
                   LegalDefendantTypeName = x.Field<string>("LegalDefendantTypeName"),
                   CommNoticeTypeName = x.Field<string>("CommNoticeTypeName"),
                   NoticePrintDt = x.Field<string>("NoticePrintDt"),
                   DispatchDt = x.Field<string>("DispatchDt"),
                   DeliveryStat = x.Field<string>("DeliveryStat"),                   
                   DeliveryDt = x.Field<string>("DeliveryDt"),
                   NoticeReturnDt = x.Field<string>("NoticeReturnDt")

               }).ToList();

            lst.Add(column);
            lst.Add(history);
            return lst;
        }

        public List<object> GetAuxdata(string paramString)
        {
            JObject jsondata = JObject.Parse(paramString);
            objModel.SearchStr = Convert.ToString(jsondata["searchStr"]);
            objModel.SearchedCol = Convert.ToString(jsondata["searchedCol"]);            
            objModel._MenuID = Convert.ToInt32(jsondata["_MenuID"]);
            objModel._TimeKey = Convert.ToInt32(jsondata["_TimeKey"]);
            objModel._OperationMode = Convert.ToInt32(jsondata["_OpMode"]);
            objModel._BranchCode = (jsondata["BranchCode"]).ToString();
            objModel._userLoginId = (jsondata["_userLoginId"]).ToString();

            objModel.ProspectAuxSelect(objModel);
            DataTable dt = objModel.ResultDataTable;
            var column = dt.AsEnumerable().Select(x =>
                new
                {
                    CustomerEntityID = x.Field<int>("CustomerEntityID"),
                    CustomerID = x.Field<string>("CustomerID"),
                    CustomerName = x.Field<string>("CustomerName")

                }).ToList();
            var lst = ((IEnumerable<dynamic>)column).ToList();
            return lst;
        }

        public List<object> GetMetaData()
        {
            List<object> lst = new List<object>();
            objModel.Prospect_ParameterisedMaster();
            DataSet ds = objModel.ResultDataSet;
            var DimDispatchMode = ds.Tables[0].AsEnumerable().Select(x =>
                new
                {
                    Code = x.Field<Int16>("Code"),
                    Description = x.Field<string>("Description")
                }).ToList();

            var DimDeliveryStatus = ds.Tables[1].AsEnumerable().Select(x =>
                new
                {
                    Code = x.Field<Int16>("Code"),
                    Description = x.Field<string>("Description")
                }).ToList();

            lst.Add(DimDispatchMode);
            lst.Add(DimDeliveryStatus);
            return lst;
        }

        public int InsertUpdateData(string jsonData)
        {
            int _resultvalue = 0;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            objModel = serializer.Deserialize<AlertModel>(jsonData);
            _resultvalue = objModel.InUpProspectDtls(objModel);
            return _resultvalue;
        }
    }
}