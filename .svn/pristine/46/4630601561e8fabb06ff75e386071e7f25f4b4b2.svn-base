using CrisMAcAPI.Models.Repository.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Models.Repository.DocumentUploadRepository
{
    public interface IDocumentUploadRepository: ICommonInterface
    {
        List<object> GetMetaData(string ParaStr);
        List<object> DocumentUploadedFileSelect(string paramString);//upload file
        new Object InsertUpdateData(string jsonData);
        new Object InsertUpdateData_images(string jsonData);
    }
}
