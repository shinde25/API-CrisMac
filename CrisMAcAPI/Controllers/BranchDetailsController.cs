using CrisMAc.Models.Utility;
using CrisMAcAPI.Filter;
using CrisMAcAPI.Models.Repository.BranchDetailsRepository;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Controllers
{
    [Authorize]
    [LogFilter]
    public class BranchDetailsController : ApiController
    {
        IBranchRepository repository;
        UtilityWeb objutility = new UtilityWeb();
        public BranchDetailsController(IBranchRepository repository)
        {
            this.repository = repository;
        }
        
        [Route("CrisMAc/Branch/{param}")]
        [HttpGet]
        public string GetDetails(string param)
        {
            param = objutility.DecryptString(param);
            var branchResult = repository.FetchData(param);

            var serializer = new JavaScriptSerializer() { MaxJsonLength = 86753090 };
            var jsonResult = serializer.Serialize(branchResult);
            
            return objutility.EnryptString(jsonResult);
        }

        [Route("CrisMAc/LastBranchSelectUpdate/{param}")]
        [HttpGet]
        public string LastBranchSelectUpdate(string param)
        {
            param = objutility.DecryptString(param);
            var objBranch = repository.LastBranchInsertUpdate(param);
            var serializer = new JavaScriptSerializer().Serialize(objBranch);
            return objutility.EnryptString(serializer);
        }


    }
}
