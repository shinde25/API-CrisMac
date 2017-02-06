using Newtonsoft.Json.Linq;
using System.Data;

namespace CrisMAcAPI.Areas.LOS.Models.Repository.UserRepository
{
    public interface IUserRepository
    {
        
        JObject InsertUserProfile(string paramString);
        JObject UserAuthentication(string paramString);
    }
}
