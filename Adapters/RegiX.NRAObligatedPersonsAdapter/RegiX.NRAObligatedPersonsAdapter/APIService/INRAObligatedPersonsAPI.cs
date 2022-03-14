using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("Регистър на задължените лица")]
    public interface INRAObligatedPersonsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за наличие/ липса на задължения")]
        [Info(
            requestXSD: "ObligatedPersonsRequest.xsd",
            responseXSD: "ObligatedPersonsResponse.xsd",
            commonXSD: "ObligatedPersonsCommon.xsd",
            requestXSLT: "ObligatedPersonsRequest.xslt",
            responseXSLT: "ObligatedPersonsResponse.xslt")]
        ServiceResultDataSigned<ObligationRequest, ObligationResponse> GetObligatedPersons(ServiceRequestData<ObligationRequest> argument);

        [OperationContract]
        [Description("Справка с данни за осигурените лица от подадени декларации по Наредба Н-13 към Кодекса за социално осигуряване")]
        [Info(
            requestXSD: "GetSocialSecurityDataFromDeclarationsRequest.xsd",
            responseXSD: "GetSocialSecurityDataFromDeclarationsResponse.xsd",
            commonXSD: "ObligatedPersonsCommon.xsd",
            requestXSLT: "GetSocialSecurityDataFromDeclarationsRequest.xslt",
            responseXSLT: "GetSocialSecurityDataFromDeclarationsResponse.xslt")]
        ServiceResultDataSigned<SocialSecurityDataFromDeclarationRequestType, GetSocialSecurityDataFromDeclarationsResponse> GetSocialSecurityDataFromDeclarations(ServiceRequestData<SocialSecurityDataFromDeclarationRequestType> argument);

    }
}
