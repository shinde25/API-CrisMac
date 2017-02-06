using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.CMA.Models.Repository.RemarkRepository
{
   public interface IRemarkRepository
    {
        object RemarkInsertUpdate(string paramString);
        object ActionableRemarkInsert(string jsonData);
        object ActionEventUpdate(string jsonData);
        DataSet GetAssignAction(string paramString);
        DataSet GetPreviousRemark(string paramString);

        DataSet APP_GetActionEventDiaryDetailsRepo(string paramString);
        DataSet APP_DefaultStatusRepo();
        DataSet APP_StakeHolderListRepo(string paramString);
        //object APP_CustomerReAllocationUpdateRepo(string paramString);
        DataSet APP_ActionEventDiaryListRepo(string paramString);
        DataSet APP_GetRemarkListRepo(string paramString);
        object AssignActionInsertUpdateRepo(string paramString);
    }
}
