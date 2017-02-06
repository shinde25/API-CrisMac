using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CrisMAcAPI.Models.Repository.AlertMessageCreationRepository
{
    public class AlertMessageCreationRepository : IAlertMessageCreationRepository
    {
        AlertMessageCreationModel _AlertMessageCreationModel;
        DataSet _DataSet;
        JavaScriptSerializer serializer;

        #region AuxAlertMessageData
        public List<object> AuxAlertMessageData(string paramString)
        {
            _AlertMessageCreationModel = new AlertMessageCreationModel();
            serializer = new JavaScriptSerializer();

            _AlertMessageCreationModel = serializer.Deserialize<AlertMessageCreationModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _AlertMessageCreationModel.AlertMessageAuxData();
            return _DataSet.ToList();
        }
        #endregion

        #region MetadataAlertMessage

        public List<object> MetadataAlertMessage(string paramString)
        {
            _AlertMessageCreationModel = new AlertMessageCreationModel();
            serializer = new JavaScriptSerializer();

            _AlertMessageCreationModel = serializer.Deserialize<AlertMessageCreationModel>(paramString);
            _DataSet = new DataSet();
            _DataSet = _AlertMessageCreationModel.AlertMessageMetaData();
            return _DataSet.ToList();
            //throw new NotImplementedException();
        }
        #endregion

        #region FetchAlertMessageData
        public List<object> FetchAlertMessageData(string paramString)
        {
            _AlertMessageCreationModel = new AlertMessageCreationModel();
            serializer = new JavaScriptSerializer();

            _AlertMessageCreationModel = serializer.Deserialize<AlertMessageCreationModel>(paramString);
            _DataSet = new DataSet();

            _DataSet = _AlertMessageCreationModel.FetchAlertMessageDetails();
            return _DataSet.ToList();
        }
        #endregion

        #region InsertUpdateAlertMessageData
        public object InsertUpdateAlertMessageData(string jsonData)
        {
            _AlertMessageCreationModel = new AlertMessageCreationModel();
            object obj = null;
            serializer = new JavaScriptSerializer();
            _AlertMessageCreationModel = serializer.Deserialize<AlertMessageCreationModel>(jsonData);
            obj = _AlertMessageCreationModel.InsertUpdateAlertMessageDetails();
            return obj;

        }

       
        #endregion
    }
}