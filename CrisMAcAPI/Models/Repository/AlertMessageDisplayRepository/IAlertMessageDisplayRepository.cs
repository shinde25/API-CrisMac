using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models.Repository.AlertMessageDisplayRepository
{
   public interface IAlertMessageDisplayRepository
    {
        List<object> GetAlertMessageList(string paramString);
      
    }
}
