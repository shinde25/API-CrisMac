using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;

namespace CrisMAcAPI.Areas.Alert.Models.Repository.ProspectMiscInfo
{
    public interface IProspectMiscInfoRepository : ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);
        new Object InsertUpdateData(string jsonData);
    }
}
