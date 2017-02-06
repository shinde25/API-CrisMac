using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.Krishak.Models.Repository.App_OperationRepository;
using Newtonsoft.Json;
using System.Web.Http;

namespace CrisMAcAPI.Areas.Krishak.Controllers
{
    public class App_OperationController : ApiController
    {
        IApp_OperationListRepositories repository;
        UtilityWeb objutility = new UtilityWeb();
        public App_OperationController(IApp_OperationListRepositories repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAcKrishak/App_GetBranchList/{param}")]
        [HttpGet]
        public string GetBranchList(string param)
        {
            param = objutility.DecryptString(param);
            var branchResult = repository.GetBranchList(param);

            var json = JsonConvert.SerializeObject(branchResult, Formatting.Indented);
            return objutility.EnryptString(json);
        }

        [Route("CrisMAcKrishak/App_GetVillageList/{param}")]
        [HttpGet]
        public string GetVillageList(string param)
        {
            param = objutility.DecryptString(param);
            var villageResult = repository.GetVillageList(param);

            var json = JsonConvert.SerializeObject(villageResult, Formatting.Indented);
            return objutility.EnryptString(json);
        }
    }
}
