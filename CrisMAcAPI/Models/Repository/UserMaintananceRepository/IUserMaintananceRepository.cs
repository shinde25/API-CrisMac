using System.Collections.Generic;

namespace CrisMAcAPI.Models.Repository.UserMaintananceRepository
{
    public interface IUserMaintananceRepository
    {
        int GetChangepwdData(string paramdata);
        int GetInvokedLoginUser(string paramdata);
        List<object> GetLoginUserInfo(string paramdata);
        int GetResetPassUpdate(string paramdata);
        List<object> GetResetPwdData(string paramdata);
        List<object> GetSuspendedUser(string paramdata);
        int GetUpdateSetInvokeSuspendedUser(string paramdata);
        List<object> GetUserinformation(string paramdata);
        List<object> GetUserPolicyMetaData(string paramdata);
        List<object> Select_MenuLayout(string results);
        List<object> Select_MenuList(string results);
        int UpdateUserParameter(string UserParaData);
    }
}