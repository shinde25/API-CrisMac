﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models.Repository.App_DashboardRepository
{
    public interface IApp_DashboardRepository
    {
        DataSet GetCompanyList(string param);
        DataSet GetCompanyScore(string param);
        DataSet GetCompanyDetail(string param);
        DataSet GetStandingList(string param);
        DataSet GetNewsDetails(string param);
        DataSet GetTwitterDetails(string param);
        DataSet GetStockDetails(string param);
    }
}
