using CrisMAcAPI.Models.Repository.CommonInterface;
using System.Collections.Generic;

namespace CrisMAcAPI.Models.Repository.UserGroupDeptRepository
{
    public interface IUserGroupDeptRepository : ICommonInterface
    {     
        List<object> getParameterisedMasterData(string paramdata);
        
    }
}