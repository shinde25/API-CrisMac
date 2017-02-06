using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.ActivityLinkageRepository
{
    public class ActivityLinkageRepository : IActivityLinkageRepository
    {
        ActivityLinkageModel model = new ActivityLinkageModel();

        public List<object> FetchData(string paramString)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAuxdata(string paramString)
        {
            List<object> lst = new List<object>();
            try
            {
                JObject jsonData = JObject.Parse(paramString);

                model._OperationFlag = Convert.ToInt32(jsonData["_OperationFlag"].ToString());
                model._TimeKey = Convert.ToInt32(jsonData["_TimeKey"].ToString());

                model.ActivityLinkageAuxSelect(model._OperationFlag, model._TimeKey);
                DataSet _dsAux = model.ResultDataSet;

                var lstAux = _dsAux.Tables[0].AsEnumerable().Select(x =>
                      new
                      {
                          Group = x.Field<string>("ActivityGroup"),
                          ActivityAlt_Key = x.Field<int>("ActivityAlt_Key"),
                          Name = x.Field<int>("LinkedActivityAlt_Key") +" - "+ x.Field<string>("ActivityName"),
                          Industry = x.Field<string>("EWSIndustryName"),
                          LinkageType = x.Field<string>("LinkageType"),
                          Code = x.Field<int>("LinkedActivityAlt_Key"),
                          DependancyWt = x.Field<int>("DependencyWt"),
                          AuthorisationStatus = x.Field<string>("AuthorisationStatus"),
                          IsMainTable = x.Field<string>("IsMainTable"),
                          CreatedModifiedBy = x.Field<string>("CreatedModifiedBy")
                      }).ToList();

                var lstActivityGrp = _dsAux.Tables[1].AsEnumerable().Select(x =>
                      new
                      {
                          ActivityGroup = x.Field<string>("ActivityGroup"),
                      }).ToList();

                var lstActivityName = _dsAux.Tables[2].AsEnumerable().Select(x =>
                      new
                      {
                          ActivityAlt_Key = x.Field<Int16>("ActivityAlt_Key"),
                          ActivityName = x.Field<string>("ActivityName"),
                          ActivityGroup = x.Field<string>("ActivityGroup"),
                          IndustryName = x.Field<string>("IndustryName")
                      }).ToList();

                var lstIndustryName = _dsAux.Tables[3].AsEnumerable().Select(x =>
                      new
                      {
                          EWSIndustryName = x.Field<string>("EWSIndustryName"),
                          ActivityGroup = x.Field<string>("ActivityGroup")
                      }).ToList();

                lst.Add(lstAux);
                lst.Add(lstActivityGrp);
                lst.Add(lstActivityName);
                lst.Add(lstIndustryName);
            }
            catch (Exception e)
            {
                throw;
            }

            var _AuxData = ((IEnumerable<dynamic>)lst).ToList();
            return _AuxData;
        }

        public List<object> GetMetaData()
        {
            throw new NotImplementedException();
        }

        public int InsertUpdateData(string jsonData)
        {
            int _resultvalue = 0;
            // var results = JsonConvert.DeserializeObject<dynamic>(res);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            model = serializer.Deserialize<ActivityLinkageModel>(jsonData);
            _resultvalue = model.ActivityLinkageInsertUpdate(model);

            return _resultvalue;
        }
    }
}