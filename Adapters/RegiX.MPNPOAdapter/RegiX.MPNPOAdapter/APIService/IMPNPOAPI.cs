using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MPNPOAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с регистъра за вписани юридически лица с нестопанска цел")]
    public interface IMPNPOAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за вписани юридически лица с нестопанска цел")]
        [Info(requestXSD: "NPODetailsRequest.xsd",
            responseXSD: "NPODetailsResponse.xsd",
            requestXSLT: "NpoDetailsRequest.xslt",
            responseXSLT: "NPODetailsInfoResponse.xslt")]
        ServiceResultDataSigned<NPODetailsRequestType, NPODetailsResponseType> GetNPORegistrationInfo(ServiceRequestData<NPODetailsRequestType> argument);

        [OperationContract]
        [Description("Справка за статус на юридически лица с нестопанска цел")]
        [Info(requestXSD: "NPOStatusRequest.xsd",
            responseXSD: "NPOStatusResponse.xsd",
            requestXSLT: "NPOStatusRequest.xslt",
            responseXSLT: "NPOStatusInfoResponse.xslt")]
        ServiceResultDataSigned<NPOStatusRequestType, NPOStatusResponseType> GetNPOStatusInfo(ServiceRequestData<NPOStatusRequestType> argument);
    }
}
