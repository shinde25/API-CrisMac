using CrisMAcAPI.Models.Repository.CommonInterface;
using System.Collections.Generic;

namespace CrisMAcAPI.Models.Repository.BranchDetailsRepository
{
    public interface IBranchRepository : ICommonInterface
    {
        //List<object> FetchDefaultBranch(string paramData);
        List<object> LastBranchInsertUpdate(string paramData);
    }
}