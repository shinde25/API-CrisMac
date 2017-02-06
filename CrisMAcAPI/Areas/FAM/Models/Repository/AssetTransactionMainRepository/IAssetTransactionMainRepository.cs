using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.AssetTransactionMainRepository
{
    public interface IAssetTransactionMainRepository:ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);
    }
}
