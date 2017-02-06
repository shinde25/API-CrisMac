using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.AssetCommonRepository
{
   public interface IAssetCommonRepository: ICommonInterface
    {
        Object InsertUpdateDataAssetBlock(string jsonData);
        
        List<object> SubBlockFetchData(string paramString);
        Object InsertUpdateDataSubAssetBlock(string jsonData);
    }
}
