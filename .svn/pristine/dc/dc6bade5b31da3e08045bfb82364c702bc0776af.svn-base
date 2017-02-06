using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.IFAM_Premises.Models.Repository.CommonPremiseRepository
{
    public interface ICommonPremiseRepository
    {
        //List<object> GetAssetBlockandSubBlockData(string ParaStr);

        List<object> FetchData(string paramString);
        Object InsertUpdateData(string jsonData);
        List<object> FetchDataTxn(string paramString);
        List<object> CBSTxnSystem_Validation(string paramString);
        List<object> FetchTranHistoryData(string paramString);

        Object InsertUpdateDataTxn(string jsonData);
        //List<object> PremiseDisplayGridDataFetch(string paramString);

    }
}
