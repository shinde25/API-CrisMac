﻿using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Script.Serialization;
using System;
using Newtonsoft.Json.Linq;

namespace CrisMAcAPI.Models.Repository.StockStatementRepository
{
    public class StockStatementRepository : IStockStatementRepository
    {
        StockStatementDetail_M objStckstat;
        public List<object> GetAuxdata(string paramData)
        {

            objStckstat = new StockStatementDetail_M();
            JObject jsonData = JObject.Parse(paramData);
            objStckstat._BranchCode = jsonData["_BranchCode"].ToString();
            objStckstat._OperationFlag = Convert.ToInt16(jsonData["_OperationFlag"]);
            objStckstat._TimeKey = Convert.ToInt32(jsonData["_TimeKey"]);
            objStckstat.Select_StockStatementAux();
            //List<object> lstStock = new List<object>();
            var lstStck = objStckstat.ResultDataTable.AsEnumerable().Select(x =>
            new
            {
                AccountEntityId = x.Field<int>("AccountEntityId"),
                CustomerEntityId = x.Field<int>("CustomerEntityId"),
                CustomerACID = x.Field<string>("CustomerACID"),
                CustomerID = x.Field<string>("CustomerID"),
                CustomerName = x.Field<string>("CustomerName"),
                OriginalLimit = x.Field<decimal>("OriginalLimit")
            }).ToList();

            var lst = ((IEnumerable<dynamic>)lstStck).ToList();
            return lst;
        }

        public int InsertUpdateData(string results)
        {
            int _resultvalue = 0;
            // var results = JsonConvert.DeserializeObject<dynamic>(res);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            objStckstat = new StockStatementDetail_M();
            objStckstat = serializer.Deserialize<StockStatementDetail_M>(results);
            objStckstat.Insert_AdvacStockStatement();

            if (!objStckstat.hasError)
            {
                _resultvalue = objStckstat.id;
            }

            return _resultvalue;
        }

        public List<object> FetchData(string paramData)
        {
            List<object> lst = new List<object>();
            objStckstat = new StockStatementDetail_M();
            JObject jsonData = JObject.Parse(paramData);

            objStckstat.CustomerEntityId = Convert.ToInt32(jsonData["CustomerEntityId"]);
            objStckstat._AccountEntityId = Convert.ToInt32(jsonData["_AccountEntityId"]);
            objStckstat._BranchCode = Convert.ToString(jsonData["_BranchCode"]);
            objStckstat._OperationFlag = Convert.ToInt32(jsonData["OperationFlag"]);
            objStckstat._TimeKey = Convert.ToInt32(jsonData["_TimeKey"]);
            objStckstat.AccountId = Convert.ToString(jsonData["AccountId"]);
            objStckstat.CustomerID = Convert.ToString(jsonData["CustomerID"]);
            objStckstat.CustomerName = Convert.ToString(jsonData["CustomerName"]);

            objStckstat.Select_AdvacStockStatement();
            DataTable dt = objStckstat.ResultDataTable;

            var lstssD = dt.AsEnumerable().Select(x =>
               new
               {
                   CustomerEntityID = objStckstat.CustomerEntityId,
                   _AccountEntityID = objStckstat._AccountEntityId,
                   CustomerACID = objStckstat.AccountId,
                   CustomerID = objStckstat.CustomerID,
                   CustomerName = objStckstat.CustomerName,
                   DueDate = x.Field<string>("DueDate"),
                   DtofSubmission =x.Field<string>("DtofSubmission"),
                   DtofInspection = x.Field<string>("DtofInspection"),
                   OS_RawMaterial = x.Field<decimal>("OS_RawMaterial"),
                   Purchase_Rowmaterial = x.Field<decimal>("Purchase_Rowmaterial"),
                   Sales_Rowmaterial = x.Field<decimal>("Sales_Rowmaterial"),
                   Obsolete_Rowmaterial = x.Field<decimal>("Obsolete_Rowmaterial"),
                   OS_SemiFinishedDoods = x.Field<decimal>("OS_SemiFinishedDoods"),
                   Purchase_SemiFinishedDoods = x.Field<decimal>("Purchase_SemiFinishedDoods"),
                   Sales_SemiFinishedDoods = x.Field<decimal>("Sales_SemiFinishedDoods"),
                   Obsolete_SemiFinishedDoods = x.Field<decimal>("Obsolete_SemiFinishedDoods"),
                   OS_FinishedGoods = x.Field<decimal>("OS_FinishedGoods"),
                   Purchase_FinishedGoods = x.Field<decimal>("Purchase_FinishedGoods"),
                   Sales_FinishedGoods = x.Field<decimal>("Sales_FinishedGoods"),
                   Obsolete_FinishedGoods = x.Field<decimal>("Obsolete_FinishedGoods"),
                   OB_SundryDebtors = x.Field<decimal>("OB_SundryDebtors"),
                   Sales_SundryDebtors = x.Field<decimal>("Sales_SundryDebtors"),
                   Collection_SundryDebtors = x.Field<decimal>("Collection_SundryDebtors"),
                   BadDebts_SundryDebtors = x.Field<decimal>("BadDebts_SundryDebtors"),
                   OB_SundryCreditors = x.Field<decimal>("OB_SundryCreditors"),
                   Purchases_SundryCreditors = x.Field<decimal>("Purchases_SundryCreditors"),
                   Payment_SundryCreditors = x.Field<decimal>("Payment_SundryCreditors"),
                   LessMarginPercentage = x.Field<decimal>("LessMarginPercentage"),
                   ExcessLmt = x.Field<decimal>("ExcessLmt"),
                   AvailableLmt = x.Field<decimal>("AvailableLmt"),
                   closingStockRawMat = x.Field<decimal>("closingStockRawMat"),
                   closingSemiFurnished = x.Field<decimal>("closingSemiFurnished"),
                   closingFurnished = x.Field<decimal>("closingFurnished"),
                   TotalOS = x.Field<decimal>("TotalOS"),
                   TotalPurchased = x.Field<decimal>("TotalPurchased"),
                   TotalSale = x.Field<decimal>("TotalSale"),
                   TotalObsolute = x.Field<decimal>("TotalObsolute"),
                   closingTotalStock = x.Field<decimal>("closingTotalStock"),
                   SundryDebtors = x.Field<decimal>("SundryDebtors"),
                   SundryCreditor = x.Field<decimal>("SundryCreditor"),
                   CalCulationClosCreDeb = (x.Field<decimal>("closingTotalStock") + x.Field<decimal>("SundryDebtors")) - x.Field<decimal>("SundryCreditor"),
                   InspectorName = x.Field<string>("InspectionBy"),
                   InspectionRemark = x.Field<string>("InspectionRemark"),
                   AuthorisationStatus = x.Field<string>("AuthorisationStatus"),
                   DtofStockStatement = x.Field<string>("DtofStockStatement"),
                   _D2Ktimestamp = x.Field<Int32>("D2Ktimestamp"),
                   _EffectiveFromTimeKey = objStckstat._TimeKey,
                   _EffectiveToTimeKey = 9999,
                  //DateApproved = "",
                  Periodicity = x.Field<string>("Periodicity"),
                  //_OperationFlag = objStckstat._OperationFlag,
                  //_BranchCode = objStckstat._BranchCode,
                  _TimeKey = objStckstat._TimeKey,
                  //_AuthMode = 'Y',
                  //_MenuID = 2,
                  //_Remark = "",
                  ChangedFields = x.Field<string>("ChangedFields")
               }).ToList();


            var CreatedModifiedBy = dt.Rows[0]["CreatedModifiedBy"] == null ? "" : dt.Rows[0]["CreatedModifiedBy"].ToString();
            var IsMainTable = dt.Rows[0]["IsMainTable"] == null ? "" : dt.Rows[0]["IsMainTable"].ToString();

            var listValidations = new { CreatedModifiedBy = CreatedModifiedBy, IsMainTable = IsMainTable };
            lst.Add(lstssD);
            lst.Add(listValidations);
            return ((IEnumerable<dynamic>)lst).ToList();
        }
        public List<object> GetMetaData()
        {
            objStckstat = new StockStatementDetail_M();
            objStckstat.Select_StockStatementParameterised('Y');
            DataSet _AttributesDS = objStckstat.ResultDataSet;
            List<object> LstObj = new List<object>();

            var _Attributes = _AttributesDS.Tables[0].AsEnumerable().Select(x =>
               new
               {
                   FrmName = x.Field<string>("FrmName"),
                   CtrlName = x.Field<string>("CtrlName"),
                   FldCaption = x.Field<string>("FldCaption"),
                   FldDataType = x.Field<string>("FldDataType"),
                   MinLength = x.Field<Int16>("MinLength"),
                   MaxLength = x.Field<Int16>("MaxLength"),
                   FldGrdWidth = x.Field<Int16>("FldGrdWidth"),
                   FldSearch = x.Field<string>("FldSearch"),
                   ErrorCheck = x.Field<string>("ErrorCheck"),
                   DataSeq = x.Field<Int16>("DataSeq"),
                   FldGridView = x.Field<string>("FldGridView"),
                   CriticalErrorType = x.Field<string>("CriticalErrorType"),
                   MsgFlag = x.Field<string>("MsgFlag"),
                   MsgDescription = x.Field<string>("MsgDescription"),
                   ScreenFieldNo = x.Field<int>("ScreenFieldNo"),
                   ViableForSCD2 = x.Field<string>("ViableForSCD2"),
                   Editable = x.Field<string>("Editable"),
                   Hide = x.Field<string>("Hide"),
                   AllowToolTip = x.Field<string>("AllowToolTip"),
                   ReferenceColumnName = x.Field<string>("ReferenceColumnName"),
                   ReferenceTableName = x.Field<string>("ReferenceTableName"),
                   IsAmount = x.Field<string>("IsAmount"),
                   MOC_Flag = x.Field<string>("MOC_Flag")
               }).ToList();

            var Periodicity = _AttributesDS.Tables[1].AsEnumerable().Select(x =>
                 new
                 {
                     Code = x.Field<string>("Code"),
                     Description = x.Field<string>("Description"),
                     Para = x.Field<int>("Para")

                 }).ToList();
            LstObj.Add(_Attributes);
            LstObj.Add(Periodicity);

            var AttributesList = ((IEnumerable<dynamic>)LstObj).ToList();
            return AttributesList;
        }
    }
}