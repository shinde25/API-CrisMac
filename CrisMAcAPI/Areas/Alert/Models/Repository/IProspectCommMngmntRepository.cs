using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.Alert.Models.Repository
{
    public interface IProspectCommMngmntRepository : ICommonInterface {
        List<Dictionary<string, object>> ProspectContent(string paramString);
        Task<string> customerForSMS(string paramString);
    }
}
