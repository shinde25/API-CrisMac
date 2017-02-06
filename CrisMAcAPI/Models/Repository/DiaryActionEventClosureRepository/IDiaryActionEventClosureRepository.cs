using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models.Repository.DiaryActionEventClosureRepository
{
    public interface IDiaryActionEventClosureRepository: ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);
        List<object> GetEmailSMSData(string ParaStr);
        new Object InsertUpdateData(string jsonData);
    }
}
