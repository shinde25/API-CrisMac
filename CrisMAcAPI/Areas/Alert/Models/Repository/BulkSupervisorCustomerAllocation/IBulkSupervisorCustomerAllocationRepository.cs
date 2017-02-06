using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.Alert.Models.Repository.BulkSupervisorCustomerAllocationRepository
{
    public interface IBulkSupervisorCustomerAllocationRepository : ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);
        new Object InsertUpdateData(string jsonData);
    }
}
