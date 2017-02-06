﻿using CrisMAc.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Models
{
    public class App_DashboardModel : CommonProperties
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public string UserLoginId { get; set; }
        public string SearchString { get; set; }

        public int CompanyAlt_Key { get; set; }
        public int InclCompanyGrp { get; set; }
        public int InclFwdLinkedCompany { get; set; }
        public int InclBwdLinkedCompany { get; set; }
        public int IncPeerCompany { get; set; }
        public char CompareWith { get; set; }
        public char PlotPeriod { get; set; }
        //------------------------------------------Get_CompanyList
        public void Get_CompanyList()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginId",UserLoginId),
                                               new SqlParameter("@SearchString",SearchString)
                                           };
            spName = "[EWS].[GetCompanyList]";
            ExecuteSelectDataSet();
        }


        //------------------------------------------Get_CompanyScore
        public void Get_CompanyScore()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CompanyAlt_Key",CompanyAlt_Key),
                                               new SqlParameter("@InclCompanyGrp",InclCompanyGrp),
                                               new SqlParameter("@InclFwdLinkedCompany",InclFwdLinkedCompany),
                                               new SqlParameter("@InclBwdLinkedCompany",InclBwdLinkedCompany),
                                               new SqlParameter("@IncPeerCompany",IncPeerCompany)

                                           };
            spName = "[EWS].[GetCompanyScore]";
            ExecuteSelectDataSet();
        }


        //------------------------------------------Get_CompanyDetail
        public void Get_CompanyDetail()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CompanyAlt_Key",CompanyAlt_Key),
                                               new SqlParameter("@InclCompanyGrp",InclCompanyGrp),
                                               new SqlParameter("@InclFwdLinkedCompany",InclFwdLinkedCompany),
                                               new SqlParameter("@InclBwdLinkedCompany",InclBwdLinkedCompany),
                                               new SqlParameter("@IncPeerCompany",IncPeerCompany)
                                           };
            spName = "[EWS].[GetCompanyDetail]";
            ExecuteSelectDataSet();
        }

        public void GetStandingList()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@UserLoginId",UserLoginId),
                                              
                                           };
            spName = "[EWS].[GetStandingList]";
            ExecuteSelectDataSet();
        }

        public void Get_NewsDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CompanyAlt_Key",CompanyAlt_Key),
                                               new SqlParameter("@InclCompanyGrp",InclCompanyGrp),
                                               new SqlParameter("@InclFwdLinkedCompany",InclFwdLinkedCompany),
                                               new SqlParameter("@InclBwdLinkedCompany",InclBwdLinkedCompany),
                                               new SqlParameter("@IncPeerCompany",IncPeerCompany),
                                               new SqlParameter("@CompareWith",CompareWith),
                                               new SqlParameter("@PlotPeriod",PlotPeriod)

                                           };
            spName = "[EWS].[GetNewsDetailPlot]";
            ExecuteSelectDataSet();
        }

        public void Get_TwitterDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CompanyAlt_Key",CompanyAlt_Key),
                                               new SqlParameter("@InclCompanyGrp",InclCompanyGrp),
                                               new SqlParameter("@InclFwdLinkedCompany",InclFwdLinkedCompany),
                                               new SqlParameter("@InclBwdLinkedCompany",InclBwdLinkedCompany),
                                               new SqlParameter("@IncPeerCompany",IncPeerCompany),
                                               new SqlParameter("@CompareWith",CompareWith),
                                               new SqlParameter("@PlotPeriod",PlotPeriod)

                                           };
            spName = "[EWS].[GetTwitterDetailPlot]";
            ExecuteSelectDataSet();
        }

        public void Get_StockDetails()
        {
            sqlParams = new SqlParameter[] {
                                               new SqlParameter("@CompanyAlt_Key",CompanyAlt_Key),
                                               new SqlParameter("@InclCompanyGrp",InclCompanyGrp),
                                               new SqlParameter("@InclFwdLinkedCompany",InclFwdLinkedCompany),
                                               new SqlParameter("@InclBwdLinkedCompany",InclBwdLinkedCompany),
                                               new SqlParameter("@IncPeerCompany",IncPeerCompany),
                                               new SqlParameter("@CompareWith",CompareWith),
                                               new SqlParameter("@PlotPeriod",PlotPeriod)

                                           };
            spName = "[EWS].[GetStockDetailPlot]";
            ExecuteSelectDataSet();
        }
    }
}