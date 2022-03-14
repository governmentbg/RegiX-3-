using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.REZMAAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистър Задължения към митническата администрация")]
    public interface IREZMAAPI: IAPIService
    {
        [OperationContract]
        [Description("Справка за митнически задължения")]
        [Info(requestXSD: "CustomsObligationsRequest.xsd",
              responseXSD: "CustomsObligationsResponse.xsd",
              commonXSD: "REZMACommon.xsd",
              requestXSLT: "CustomsObligationsRequest.xslt",
              responseXSLT: "CustomsObligationsResponse.xslt")]
        ServiceResultDataSigned<CustomsObligationsRequestType, CustomsObligationsResponseType> GetCustomsObligations(ServiceRequestData<CustomsObligationsRequestType> argument);
        
        [OperationContract]
        [Description("Справка за акцизни задължения")]
        [Info(requestXSD: "ExciseObligationsRequest.xsd",
              responseXSD: "ExciseObligationsResponse.xsd",
              commonXSD: "REZMACommon.xsd",
              requestXSLT: "ExciseObligationsRequest.xslt",
              responseXSLT: "ExciseObligationsResponse.xslt")]
        ServiceResultDataSigned<ExciseObligationsRequestType, ExciseObligationsResponseType> GetExciseObligations(ServiceRequestData<ExciseObligationsRequestType> argument);
        
        [OperationContract]
        [Description("Справка за наличие/липса на задължения")]
        [Info(requestXSD: "CheckObligationsRequest.xsd",
              responseXSD: "CheckObligationsResponse.xsd",
              commonXSD: "REZMACommon.xsd",
              requestXSLT: "CheckObligationsRequest.xslt",
              responseXSLT: "CheckObligationsResponse.xslt")]
        ServiceResultDataSigned<CheckObligationsRequestType, CheckObligationsResponseType> CheckObligations(ServiceRequestData<CheckObligationsRequestType> argument);
    }
}


