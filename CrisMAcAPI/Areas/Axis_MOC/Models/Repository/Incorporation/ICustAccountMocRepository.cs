using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.Axis_MOC.Models.Repository.Incorporation
{
    public  interface ICustAccountMocRepository
    {
        List<object> GetIncorporation(string paramString);
        List<object> GetParametriceMeta(string paramString);
        List<object> GetCustAccountGrid(string paramString);
        object GetCustAccountInsertUpdate(string jsonData);

        
        //List<object> LastQtrDateRepo(string paramString);
        List<object> ValidateExcelRepo(string jsonData);
        object CustExcelUpload(string jsonData);
        List<object> GetExcelData(string paramString);        
        
        List<object> ValidateAccExcelRepo(string jsonData);
        object AccExcelUpload(string jsonData);
        List<object> GetAccExcelData(string paramString);



    }
}
