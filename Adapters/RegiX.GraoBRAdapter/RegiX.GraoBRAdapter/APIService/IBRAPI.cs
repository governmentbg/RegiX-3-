using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.GraoBRAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистър на актовете за граждански брак")]
    public interface IBRAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за семейно положение")]
        [Info(
            requestXSD: "MaritalStatusRequest.xsd",
            responseXSD: "MaritalStatusResponse.xsd",
            commonXSD: "BRCommon.xsd",
            sampleRequest: "MaritalStatusRequest.xml",
            sampleResponse: "MaritalStatusResponse.xml",
            requestXSLT: "MaritalStatusRequest.xslt",
            responseXSLT: "MaritalStatusResponse.xslt")]
        ServiceResultDataSigned <MaritalStatusRequestType,MaritalStatusResponseType> MaritalStatusSearch(ServiceRequestData<MaritalStatusRequestType> argument);

        [OperationContract]
        [Description("Справка за съпруг/съпруга")]
        [Info(
            requestXSD: "SpouseRequest.xsd",
            responseXSD: "SpouseResponse.xsd",
            commonXSD: "BRCommon.xsd",
            requestXSLT: "SpouseRequest.xslt",
            responseXSLT: "SpouseResponse.xslt")]
        ServiceResultDataSigned <SpouseRequestType,SpouseResponseType> SpouseSearch(ServiceRequestData<SpouseRequestType> argument);

        [OperationContract]
        [Description("Справка за брак")]
        [Info(
            requestXSD: "MarriageRequest.xsd",
            responseXSD: "MarriageResponse.xsd",
            commonXSD: "BRCommon.xsd",
            requestXSLT: "MarriageRequest.xslt",
            responseXSLT: "MarriageResponse.xslt")]
        ServiceResultDataSigned<MarriageRequestType, MarriageResponseType> MarriageSearch(ServiceRequestData<MarriageRequestType> argument);

        [OperationContract]
        [Description("Справка за семейно положение, съпруг/а и деца")]
        [Info(
            requestXSD: "MaritalStatusSpouseChildrenRequest.xsd",
            responseXSD: "MaritalStatusSpouseChildrenResponse.xsd",
            commonXSD: "BRCommon.xsd",
            sampleRequest: "MaritalStatusSpouseChildrenRequest.xml",
            sampleResponse: "MaritalStatusSpouseChildrenResponse.xml",
            requestXSLT: "MaritalStatusSpouseChildrenRequest.xslt",
            responseXSLT: "MaritalStatusSpouseChildrenResponse.xslt")]
        ServiceResultDataSigned<MaritalStatusSpouseChildrenRequestType, MaritalStatusSpouseChildrenResponseType> MaritalStatusSpouseChildrenSearch(ServiceRequestData<MaritalStatusSpouseChildrenRequestType> argument);
    }
}
