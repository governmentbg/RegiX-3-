using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NoiRPAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на aдаптер за комуникация с Регистър на пенсионерите")]
    public interface IRPAPI : IAPIService
    {
        //Справка за наличието на упражнено право на пенсия за осигурителен стаж и възраст
        [OperationContract]
        [Description("Справка за наличието на упражнено право на пенсия за осигурителен стаж и възраст")]
        [Info(
            requestXSD: "PensionRightRequest.xsd",
            responseXSD: "PensionRightResponse.xsd",
            commonXSD: "RPCommon.xsd",
            requestXSLT: "PensionRightRequest.xslt",
            responseXSLT: "PensionRightResponse.xslt")]
        ServiceResultDataSigned<PensionRightRequestType, PensionRightResponseType> GetPensionRightInfoReport(ServiceRequestData<PensionRightRequestType> argument);

        //Справка за размер и вид на пенсия и добавка (УП-7)"
        [OperationContract]
        [Description("Справка за размер и вид на пенсия и добавка")]
        [Info(
            requestXSD: "UP7Request.xsd",
            responseXSD: "UP7Response.xsd",
            commonXSD: "RPCommon.xsd",
            requestXSLT: "UP7Request.xslt",
            responseXSLT: "UP7Response.xslt")]
        ServiceResultDataSigned<UP7RequestType, UP7ResponseType> GetPensionTypeAndAmountReport(ServiceRequestData<UP7RequestType> argument);

        //Справка за размер и вид на пенсия и добавка (УП-7)"
        [OperationContract]
        [Info(
            requestXSD: "UP7NewRequest.xsd",
            responseXSD: "UP7NewResponse.xsd",
            commonXSD: "RPCommon.xsd",
            requestXSLT: "UP7NewRequest.xslt",
            responseXSLT: "UP7NewResponse.xslt")]
        [Description("Справка за размер и вид на пенсия и добавка (УП-7)")]
        ServiceResultDataSigned<UP7NewRequestType, UP7NewResponseType> GetPensionTypeAndAmountReportUP7(ServiceRequestData<UP7NewRequestType> argument);

        //Справка за доход от пенсия и добавка (УП-8)
        [OperationContract]
        [Description("Справка за доход от пенсия и добавка (УП-8)")]
        [Info(
            requestXSD: "UP8Request.xsd",
            responseXSD: "UP8Response.xsd",
            commonXSD: "RPCommon.xsd",
            requestXSLT: "UP8Request.xslt",
            responseXSLT: "UP8Response.xslt")]
        ServiceResultDataSigned<UP8RequestType, UP8ResponseType> GetPensionIncomeAmountReport(ServiceRequestData<UP8RequestType> argument);
    }
}
