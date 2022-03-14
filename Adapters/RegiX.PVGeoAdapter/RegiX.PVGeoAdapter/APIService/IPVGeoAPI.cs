using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PVGeoAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Патентно ведомство - Държавен регистър на географските означения")]
    public interface IPVGeoAPI : IAPIService
    {
        //Справка по заявителски номер на географско означение
        [OperationContract]
        [Description("Справка по заявителски номер на географско означение")]
        [Info(
            requestXSD: "REG_GEO_App_Num_Request.xsd",
            responseXSD: "REG_GEO_GIDetails_Response.xsd",
            requestXSLT: "REG_GEO_App_Num_Request.xslt",
            responseXSLT: "REG_GEO_GIDetails_Response.xslt")]
        ServiceResultDataSigned<GetGIByAppNumType, GIDetailsType> GetREG_GEO_App_Num(ServiceRequestData<GetGIByAppNumType> argument);

        //Справка по име на географско означение
        [OperationContract]
        [Description("Справка по име на географско означение")]
        [Info(
            requestXSD: "REG_GEO_GI_Name_Request.xsd",
            responseXSD: "REG_GEO_GIDetails_Response.xsd",
            requestXSLT: "REG_GEO_GI_Name_Request.xslt",
            responseXSLT: "REG_GEO_GIDetails_Response.xslt")]
        ServiceResultDataSigned<GetGIByNameType, GIDetailsType> GetREG_GEO_GI_Name(ServiceRequestData<GetGIByNameType> argument);

        //Ссправка за географски означения по ползвател
        [OperationContract]
        [Description("Справка за географски означения по ползвател")]
        [Info(
            requestXSD: "REG_GEO_GI_User_Request.xsd",
            responseXSD: "REG_GEO_GIDetails_Response.xsd",
            requestXSLT: "REG_GEO_GI_User_Request.xslt",
            responseXSLT: "REG_GEO_GIDetails_Response.xslt")]
        ServiceResultDataSigned<GetGIByUserNameType, GIDetailsType> GetREG_GEO_GI_User(ServiceRequestData<GetGIByUserNameType> argument);

        //Справка по регистров номер на географско означение
        [OperationContract]
        [Description("Справка по регистров номер на географско означение")]
        [Info(
            requestXSD: "REG_GEO_Reg_Num_Request.xsd",
            responseXSD: "REG_GEO_GIDetails_Response.xsd",
            requestXSLT: "REG_GEO_Reg_Num_Request.xslt",
            responseXSLT: "REG_GEO_GIDetails_Response.xslt")]
        ServiceResultDataSigned<GetGIByRegNumType, GIDetailsType> GetREG_GEO_Reg_Num(ServiceRequestData<GetGIByRegNumType> argument);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на географско означение")]
        //ServiceResultData<GIDetailsType> GetREG_GEO_Stat_App_Date(ServiceRequestData<GIDetailsType> argument);
    }
}
