using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models.Repository.IrregularityRepository
{
    public interface IIrregularityDetailRepository
    {
        List<object> GetAuxdata(string paramString);
        List<object> FetchData(string paramString);
        object InsertUpdateData(string jsonData);
    }
}
