using CrisMAcAPI.Areas.CommonComponent.Models.Repository.CommonMasterRepository;
using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.CommonComponent.Models.Repository.GapDataMasterRepository
{
    public  interface IGapDataMasterRepository : ICommonInterface
    {
        List<object> GetAuxMasterdata(string paramString);
    }
}
