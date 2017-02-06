using CrisMAc.Models.Utility;
using CrisMAcAPI.Areas.Krishak.Models.Repository.BranchSelectionReository;
using System.Web.Http;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CrisMAcAPI.Areas.Krishak.Controllers
{
    public class BranchSelectionController : ApiController
    {
        IBranchRepositories repository;
        UtilityWeb objutility = new UtilityWeb();
        public BranchSelectionController(IBranchRepositories repository)
        {
            this.repository = repository;
        }

        [Route("CrisMAc/BranchSelect/{param}")]
        [HttpGet]
        public string GetDetails(string param)
        {
            param = objutility.DecryptString(param);
            var branchResult = repository.FetchData(param);

            var json = new JavaScriptSerializer().Serialize(branchResult);
            return objutility.EnryptString(json);
        }
    }
}
