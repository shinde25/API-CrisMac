using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CrisMAcAPI.Areas.CMA.Models.Repository.DataSync
{
    public interface IDataSyncRepository
    {
        DataSet GetCustomerDetailsSyncRepo(string paramString);
        DataSet GetDetailsSyncRepo(string paramString);
        DataSet GetActionDetailsSyncRepo(string paramString);
        object UploadDataToServer(string jsonData);
    }
}