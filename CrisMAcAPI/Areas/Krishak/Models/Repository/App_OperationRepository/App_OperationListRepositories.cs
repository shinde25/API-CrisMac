using CrisMAcAPI.Areas.CommonComponent.Models;
using System.Data;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.Krishak.Models.Repository.App_OperationRepository
{
    public class App_OperationRepository : IApp_OperationListRepositories
    {
        App_OperationModel _OperationModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        public DataSet GetBranchList(string ParaStr)
        {
            _OperationModel = new App_OperationModel();
            serializer = new JavaScriptSerializer();
            _OperationModel = serializer.Deserialize<App_OperationModel>(ParaStr);
            _DataSet = new DataSet();
            _DataSet = _OperationModel.GetBranchList().SetTableName();
            return _DataSet;
        }

        public DataSet GetVillageList(string ParaStr)
        {
            _OperationModel = new App_OperationModel();
            serializer = new JavaScriptSerializer();
            _OperationModel = serializer.Deserialize<App_OperationModel>(ParaStr);
            _DataSet = new DataSet();
            _DataSet = _OperationModel.GetVillageList().SetTableName();
            return _DataSet;
        }
    }

}