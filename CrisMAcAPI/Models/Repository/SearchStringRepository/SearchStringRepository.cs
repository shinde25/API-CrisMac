using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using CrisMAcAPI.Models.Repository.CommonInterface;

namespace CrisMAcAPI.Models.Repository.SearchStringRepository
{
    public class SearchStringRepository : ISearchStringRepository
    {
        SearchStringModel ObjSearchStringModel;
        DataSet _DataSet;
        public List<object> FetchData(string paramString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ObjSearchStringModel = new SearchStringModel();
            ObjSearchStringModel = serializer.Deserialize<SearchStringModel>(paramString);
            ObjSearchStringModel.SearchStringFetch();
            DataSet _SearchStringAuxDS = ObjSearchStringModel.ResultDataSet;
            List<object> LstObj = new List<object>();

            var Data = _SearchStringAuxDS.Tables[0].AsEnumerable().Select(x =>
              new
              {
                  StringType = x.Field<string>("StringType"),
                  CompanyIndAlt_Key = x.Field<Int16>("CompanyIndAlt_Key"),
                  IsMainTable = x.Field<string>("IsMainTable"),
                  CreatedModifiedBy = x.Field<string>("CreatedModifiedBy"),
                  AuthorisationStatus = x.Field<string>("AuthorisationStatus"),
                  D2Ktimestamp = x.Field<int>("D2Ktimestamp")
              }).Take(1).ToList();


            var News = _SearchStringAuxDS.Tables[0].AsEnumerable().Select(x =>
               new
               {
                   StringType = x.Field<string>("StringType"),
                   SearchString = x.Field<string>("SearchString"),
                   CompanyIndAlt_Key = x.Field<Int16>("CompanyIndAlt_Key")                  

               }).Where(x => x.StringType == "NW").ToList();

            var Twit = _SearchStringAuxDS.Tables[0].AsEnumerable().Select(x =>
              new
              {
                  StringType = x.Field<string>("StringType"),
                  SearchString = x.Field<string>("SearchString"),
                  CompanyIndAlt_Key = x.Field<Int16>("CompanyIndAlt_Key")
               
              }).Where(x => x.StringType == "TW").ToList();

            LstObj.Add(News);
            LstObj.Add(Twit);
            LstObj.Add(Data);

            var SearchStringModelList = ((IEnumerable<dynamic>)LstObj).ToList();
            return SearchStringModelList;
        }
        public List<object> GetAuxCustdata(string paramString)
        {
            ObjSearchStringModel = new SearchStringModel();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ObjSearchStringModel = serializer.Deserialize<SearchStringModel>(paramString);

            _DataSet = new DataSet();
            ObjSearchStringModel.SearchStringAuxCustDetails();
            _DataSet = ObjSearchStringModel.ResultDataSet;
            return _DataSet.ToList();
        }
        public List<object> GetAuxdata(string paramString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ObjSearchStringModel = new SearchStringModel();
            ObjSearchStringModel = serializer.Deserialize<SearchStringModel>(paramString);
            ObjSearchStringModel.SearchStringAux();
            DataSet _SearchStringAuxDS = ObjSearchStringModel.ResultDataSet;
            List<object> LstObj = new List<object>();

            var CmpInd = _SearchStringAuxDS.Tables[0].AsEnumerable().Select(x =>
                new
                {
                    CompanyCode = x.Field<int>("CompanyCode"),
                    CompanyName = x.Field<string>("CompanyName")

                }).ToList();

            LstObj.Add(CmpInd);
            var SearchStringModelList = ((IEnumerable<dynamic>)LstObj).ToList();
            return SearchStringModelList;
        }

        public List<object> GetMetaData()
        {
            ObjSearchStringModel = new SearchStringModel();
            ObjSearchStringModel.SearchStringMeta('Y');
            DataSet _SearchStringModelDS = ObjSearchStringModel.ResultDataSet;
            List<object> LstObj = new List<object>();

            var CmpInd = _SearchStringModelDS.Tables[0].AsEnumerable().Select(x =>
                new
                {
                    Code = x.Field<string>("Code"),
                    Description = x.Field<string>("Description"),
                    OrderKey = x.Field<int>("OrderKey")

                }).ToList();

            LstObj.Add(CmpInd);
            var SearchStringModelList = ((IEnumerable<dynamic>)LstObj).ToList();
            return SearchStringModelList;
        }

        public object KeyWordInsertUpdateData(string jsonData)
        {
            object rval = null;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SearchStringModel jSonModel = serializer.Deserialize<SearchStringModel>(jsonData);
           
            rval = jSonModel.SearchStringSave();

            return rval;

        }

        int ICommonInterface.InsertUpdateData(string jsonData)
        {
            throw new NotImplementedException();
        }
               
    }
}