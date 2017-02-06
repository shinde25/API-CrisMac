using System.Web.Http;
using CrisMAc.Models.Utility;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net;
using CrisMAcAPI.Models.Repository.ReportRepository;

namespace CrisMAcAPI.Controllers
{
    public class ReportController : ApiController
    {
        IReportRepository  repository;

        public ReportController(IReportRepository repository)
        {
            this.repository = repository;
        }

        UtilityWeb objutility = new UtilityWeb();
        [Route("CrisMAc/ReportDetail/{param}")]
        [HttpGet]
        public string GetMasterMetaData(string param)
        {
            param = objutility.DecryptString(param);
            var objFetchData = repository.FetchData(param);
            var json = new JavaScriptSerializer().Serialize(objFetchData);
            return objutility.EnryptString(json);
        }
    }

    
}
