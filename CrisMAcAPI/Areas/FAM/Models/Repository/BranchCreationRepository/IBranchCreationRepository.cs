﻿using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.BranchCreationRepository
{
    public interface IBranchCreationRepository : ICommonInterface
    {
        List<object> AuxBranchData();
        List<object> GetSolIddata(string paramString);
        List<object> FetchBranchData(string paramString);
        object InsertUpdateBranchData(string jsonData);
       
    }
}
