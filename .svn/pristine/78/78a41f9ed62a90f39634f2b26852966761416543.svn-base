using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CrisMAcAPI.Models
{
    public class CustomerAnalysisModel : CommonProperties
    {

        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public int Page { get; set; }
        public string Type { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SearchKeyWord { get; set; }
        public string SourceType { get; set; }
        public string SourceData { get; set; }
        public string _CreatedModifyBy { get; set; }
        public int CustomerEntityID { get; set; }
        public string LinkType { get; set; }
        //PLOAT
        public Byte InclCompanyGrp { get; set; }
        public Byte InclFwdLinkedCompany { get; set; }
        public Byte InclBwdLinkedCompany { get; set; }
        public Byte IncPeerCompany { get; set; }
        public Char CompareWith { get; set; }
        public Char PlotPeriod { get; set; }




        public void CustomerAnalysisNewsTwitsBlogs()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@BranchCode", _BranchCode),
                new SqlParameter("@TimeKey", _TimeKey),
                new SqlParameter("@UserLoginId", _userLoginId),
                new SqlParameter("@Type", Type),
                new SqlParameter("@SearchKeyWord", SearchKeyWord),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@PageNo", Page)

                };
            spName = "[EWS].[HomeDashBoardNewsTwitsBlogs]";
            ExecuteSelectDataSet();
        }

        public void CustomerDetail()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@TimeKey", _TimeKey),
                new SqlParameter("@UserLoginId", _userLoginId)
              };
            spName = "[EWS].[CustomerDetail]";
            ExecuteSelectDataSet();
        }


        public void CustomerDetailAuxData()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@UserLoginId", _userLoginId),
                new SqlParameter("@TimeKey", _TimeKey),
                 //new SqlParameter("@UserLoginId", _userLoginId)
              };
            spName = "[EWS].[CustomerDetailAuxData]";
            ExecuteSelectDataSet();
        }
        public void CustomerDetailScore()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[DIMENSIONDETL]";
            ExecuteSelectDataSet();
        }
        public void CustomerIndustryDetail()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID),
                 new SqlParameter("@LinkedType",LinkType)
              };
            spName = "[EWS].[EXTERNALBLFL_INDUSTRY]";
            ExecuteSelectDataSet();
        }

        public void TransactionDetail()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[TransactionDetail]";
            ExecuteSelectDataSet();
        }
        public void FinancialDetail()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[FinancialDetail]";
            ExecuteSelectDataSet();
        }
        public void NonFinancialDetail()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[Non-FinancialDetail]";
            ExecuteSelectDataSet();
        }
        public void StatisticalDetail()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[StatisticalDetail]";
            ExecuteSelectDataSet();
        }
        public void ObtainedTransaction()
        {
            sqlParams = new SqlParameter[] {
                new SqlParameter("@TimeKey", _TimeKey),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[Obtained_TransactionDetail]";
            ExecuteSelectDataSet();
        }
        public void StockDetailPlot()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@CustomerEntityId",CustomerEntityID),
                 new SqlParameter("@InclCompanyGrp", InclCompanyGrp),
                 new SqlParameter("@InclFwdLinkedCompany",InclFwdLinkedCompany),
                 new SqlParameter("@InclBwdLinkedCompany", InclBwdLinkedCompany),
                 new SqlParameter("@IncPeerCompany",IncPeerCompany),//@CompareWith
                 new SqlParameter("@CompareWith",CompareWith),
                 new SqlParameter("@PlotPeriod",PlotPeriod),
                 new SqlParameter("@TimeKey", _TimeKey)

              };
            spName = "[EWS].[GetStockDetailPlot]";
            ExecuteSelectDataSet();
        }

        public void Comparison_PeersIndustryPlot()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@PlotPeriod",PlotPeriod),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[Comparison_Peers&IndustryPlot]";
            ExecuteSelectDataSet();
        }
        public void Comparison_BLindustriesIndexPlot()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@PlotPeriod",PlotPeriod),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[Comparison_BLindustries&IndexPlot]";
            ExecuteSelectDataSet();
        }
        public void Comparison_FLindustriesIndexPlot()
        {
            sqlParams = new SqlParameter[] {
                 new SqlParameter("@PlotPeriod",PlotPeriod),
                 new SqlParameter("@CustomerEntityId",CustomerEntityID)
              };
            spName = "[EWS].[Comparison_FLindustries&IndexPlot]";
            ExecuteSelectDataSet();
        }






    }
}