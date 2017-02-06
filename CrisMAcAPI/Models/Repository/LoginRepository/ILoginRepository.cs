using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models.Repository.LoginRepository
{
   public interface ILoginRepository
    {
        List<object> SelectLoginDetails(string paramString);
        List<object> SelectLastLoginDetails(string paramString);
        List<object> SelectSysCurrentTimeKey();
        //List<object> SelectLastQtyKey();

        string InsertUserLoginHistory(string jsonData);
    }
}
