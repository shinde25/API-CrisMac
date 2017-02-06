using Newtonsoft.Json.Linq;
using System.Data;

namespace CrisMAcAPI.Areas.LOS.Models.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        DataSet GetMasterData(string Parameters);
        JObject InsertQECApplication(string paramString); 
       
    }
}
