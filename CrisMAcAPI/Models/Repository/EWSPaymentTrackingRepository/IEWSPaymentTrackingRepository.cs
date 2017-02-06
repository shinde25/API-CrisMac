using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.EWSPaymentTrackingRepository
{
   public interface IEWSPaymentTrackingRepository:ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);        
        new object InsertUpdateData(string jsonData);
    }
}
