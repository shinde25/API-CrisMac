using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.ReplicationRepository
{
   public interface ICommonNewAssetRepository
    {
        List<object> FetchData(string paramString);
        Object InsertUpdateData(string jsonData);
        List<object> FetchDataTxn(string paramString);
        List<object> CBSTxnSystem_Validation(string paramString);

        object InsertUpdateIntiFreezing(string paramString);

        List<object> FetchTranHistoryData(string paramString);

        List<object> FetchInitiFreez(string paramString);
     
        Object InsertUpdateDataTxn(string jsonData);
    }
}
