using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.BranchMergeRepository
{
    public interface IBranchMergeRepository : ICommonInterface
    {
        List<object> FetchBranchData(string paramString);
        List<object> FetchBranchClose(string paramString);
        object InsertUpdateBranchMerge(string jsonData);
    }
}