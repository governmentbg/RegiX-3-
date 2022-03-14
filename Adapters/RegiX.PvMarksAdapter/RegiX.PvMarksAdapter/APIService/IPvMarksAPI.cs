using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PvMarksAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Патентно ведомство - Държавният регистър на марките")]
    public interface IPvMarksAPI : IAPIService
    {
        //Справка по заявителски номер на марка
        [OperationContract]
        [Description("Справка по заявителски номер на марка")]
        [Info(
            requestXSD: "REG_MARKS_App_Number_Request.xsd",
            responseXSD: "REG_MARKS_TradeMarkDetails_Response.xsd",
            requestXSLT: "REG_MARKS_App_Number_Request.xslt",
            responseXSLT: "REG_MARKS_TradeMarkDetails_Response.xslt")]
        ServiceResultDataSigned <GetMarkByAppNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_App_Number(ServiceRequestData<GetMarkByAppNumType> argument);

        //Справка по име на марка
        [OperationContract]
        [Description("Справка по име на марка")]
        [Info(
            requestXSD: "REG_MARKS_Mark_Name_Request.xsd",
            responseXSD: "REG_MARKS_TradeMarkDetails_Response.xsd",
            requestXSLT: "REG_MARKS_Mark_Name_Reuqest.xslt",
            responseXSLT: "REG_MARKS_TradeMarkDetails_Response.xslt")]
        ServiceResultDataSigned<GetMarksByNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Mark_Name(ServiceRequestData<GetMarksByNameType> argument);

        //Справка по притежател на марка
        [OperationContract]
        [Description("Справка по притежател на марка")]
        [Info(
            requestXSD: "REG_MARKS_Owner_Request.xsd",
            responseXSD: "REG_MARKS_TradeMarkDetails_Response.xsd",
            requestXSLT: "REG_MARKS_Owner_Request.xslt",
            responseXSLT: "REG_MARKS_TradeMarkDetails_Response.xslt")]
        ServiceResultDataSigned<GetMarkByOwnersNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Owner(ServiceRequestData<GetMarkByOwnersNameType> argument);

        //Справка по номер на марка
        [OperationContract]
        [Description("Справка по номер на марка")]
        [Info(
            requestXSD: "REG_MARKS_Reg_Number_Request.xsd",
            responseXSD: "REG_MARKS_TradeMarkDetails_Response.xsd",
            requestXSLT: "REG_MARKS_Reg_Number_Request.xslt",
            responseXSLT: "REG_MARKS_TradeMarkDetails_Response.xslt")]
        ServiceResultDataSigned<GetMarkByRegNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Reg_Number(ServiceRequestData<GetMarkByRegNumType> argument);


        //[OperationContract]
        //[Description("Справка по правен статус и дата на заявяване на марка")]
        //ServiceResultData<REG_MARKS_Stat_App_Date_ResponseType> GetREG_MARKS_Stat_App_Date(ServiceRequestData<REG_MARKS_Stat_App_Date_RequestType> argument);
    }
}
