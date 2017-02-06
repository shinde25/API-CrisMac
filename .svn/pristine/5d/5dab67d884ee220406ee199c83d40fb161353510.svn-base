using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Areas.LOS.Models.Repository.LOSDashBoardRepository
{
    public class LOSDashBoardRepository : ILOSDashBoardRepository
    {
        LOSDashBoardModel _LOSDashBoardModel;
       
        JavaScriptSerializer serializer;

        public JObject GetCriteriaEligibleData(string jsonData)
        {
            _LOSDashBoardModel = new LOSDashBoardModel();
            serializer = new JavaScriptSerializer();
            _LOSDashBoardModel = serializer.Deserialize<LOSDashBoardModel>(jsonData);

            JObject obj = _LOSDashBoardModel.GetCriteriaEligibleData();

            return obj;
        }
    }
}