using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.FAM.Models.Repository.AssetDocUploadRepository
{
    public interface IAssetDocUploadRepository:ICommonInterface    {
       
        List<object> GetMetaDataForDocumentUpload(string paramString);
        Object SaveDocumentUploadMain(string jsonData);
    }
}



