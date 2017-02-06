using CrisMAcAPI.Areas.Alert.Models.Repository.BulkSupervisorCustomerAllocationRepository;
using CrisMAcAPI.Areas.CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;
using Newtonsoft.Json.Linq;

namespace CrisMAcAPI.Areas.Alert.Models.Repository.BulkSupervisorCustomerAllocation
{
    public class BulkSupervisorCustomerAllocationRepository : IBulkSupervisorCustomerAllocationRepository
    {
        BulkSupervisorCustomerAllocationModel _CustomerAllocationModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        //-----------FetchData(para)
        public List<object> FetchData(string paramString)
        {
            _CustomerAllocationModel = new BulkSupervisorCustomerAllocationModel();
            //serializer = new JavaScriptSerializer();
            //_CustomerAllocationModel = serializer.Deserialize<BulkSupervisorCustomerAllocationModel>(paramString);
            string[] ObjArr = paramString.Split(',');
            _CustomerAllocationModel.UserId = Convert.ToString(ObjArr[0]);
            _CustomerAllocationModel.ZoneCode = Convert.ToString(ObjArr[1]);
            _CustomerAllocationModel.RegionCode = Convert.ToString(ObjArr[2]);
            _CustomerAllocationModel.AllocatedValue = Convert.ToString(ObjArr[3]);
            _CustomerAllocationModel.AllocationCriteria = Convert.ToInt32(ObjArr[4]);
            _CustomerAllocationModel.ExposureRange = Convert.ToInt32(ObjArr[5]);
            _CustomerAllocationModel.RangeValue1 = Convert.ToInt32(ObjArr[6]);
            _CustomerAllocationModel.RangeValue2 = Convert.ToInt32(ObjArr[7]);
            _CustomerAllocationModel.BranchCode = Convert.ToString(ObjArr[8]);
            _CustomerAllocationModel._userLoginId = Convert.ToString(ObjArr[9]);
            _CustomerAllocationModel._TimeKey = Convert.ToInt32(ObjArr[10]);
            _CustomerAllocationModel._OperationMode = Convert.ToInt32(ObjArr[11]);
            _CustomerAllocationModel.EmployeeRole = Convert.ToInt32(ObjArr[12]);
            _DataSet = new DataSet();
            _CustomerAllocationModel.BulkSupervisorCustomerAllocationSelect();
            _DataSet = _CustomerAllocationModel.ResultDataSet;

            return _DataSet.ToList();
        }

        public List<object> GetAuxdata(string paramString)
        {
            _CustomerAllocationModel = new BulkSupervisorCustomerAllocationModel();
            serializer = new JavaScriptSerializer();
            _CustomerAllocationModel = serializer.Deserialize<BulkSupervisorCustomerAllocationModel>(paramString);

            _DataSet = new DataSet();
            _CustomerAllocationModel.BulkSupervisorCustomerAllocationAuxSelect();
            _DataSet = _CustomerAllocationModel.ResultDataSet;

            return _DataSet.ToList();
        }

        //-------------GetMetaData()
        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }
        //-------------InsertUpdateData(para)
        public object InsertUpdateData(string jsonData)
        {
            object rval = null;
            serializer = new JavaScriptSerializer();
            _CustomerAllocationModel = serializer.Deserialize<BulkSupervisorCustomerAllocationModel>(jsonData);
            rval = _CustomerAllocationModel.BulkSupervisorCustomerAllocationInsertUpdate();
            return rval;
        }

        //-------------InsertUpdateData(para)
        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }

        //--------------GetMeataData(para)
        public List<object> GetMetaData(string ParaStr)
        {
            _CustomerAllocationModel = new BulkSupervisorCustomerAllocationModel();
            serializer = new JavaScriptSerializer();
            JObject job = JObject.Parse(ParaStr);
            _CustomerAllocationModel._TimeKey = Convert.ToInt32(job["_TimeKey"].ToString());
            _CustomerAllocationModel._OperationMode = Convert.ToInt32(job["_OperationMode"].ToString());
            _DataSet = new DataSet();
            _CustomerAllocationModel.BulkSupervisorCustomerAllocationParameterisedMasterData();
            _DataSet = _CustomerAllocationModel.ResultDataSet;

            return _DataSet.ToList();
        }

    }
}
