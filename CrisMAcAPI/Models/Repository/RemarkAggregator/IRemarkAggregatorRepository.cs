using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models.Repository.RemarkAggregator
{
    public interface IRemarkAggregatorRepository : ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);
        new Object InsertUpdateData(string jsonData);
    }
}
