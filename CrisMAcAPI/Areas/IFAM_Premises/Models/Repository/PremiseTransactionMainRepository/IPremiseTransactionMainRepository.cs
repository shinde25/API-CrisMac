using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.IFAM_Premises.Models.Repository.PremiseTransactionMainRepository
{
    public interface IPremiseTransactionMainRepository : ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);
    }
}
