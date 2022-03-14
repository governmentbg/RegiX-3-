using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MVRBDSAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистър Български документи за самоличност на МВР")]
    public interface IMVRBDSAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за български лични документи на български граждани")]
        [Info(requestXSD: "PersonalidentityInfoRequest.xsd",
              responseXSD: "PersonalidentityInfoResponse.xsd",
              requestXSLT: "GetPersonalIdentityRequest.xslt",
              responseXSLT: "GetPersonalIdentityResponse.xslt")]
        ServiceResultDataSigned<PersonalIdentityInfoRequestType, PersonalIdentityInfoResponseType> GetPersonalIdentity(ServiceRequestData<PersonalIdentityInfoRequestType> argument);

        [OperationContract]
        [Description("Разширена справка за български лични документи на български граждани и чужденци – V2")]
        [Info(requestXSD: "PersonalIdentityInfoRequestV2.xsd",
              responseXSD: "PersonalIdentityInfoResponseV2.xsd",
              requestXSLT: "GetPersonalIdentityV2Request.xslt",
              responseXSLT: "GetPersonalIdentityV2Response.xslt")]
        ServiceResultDataSigned<MVRBDSAdapterV2.PersonalIdentityInfoRequestType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType> GetPersonalIdentityV2(ServiceRequestData<MVRBDSAdapterV2.PersonalIdentityInfoRequestType> argument);

        [OperationContract]
        [Description("Справка за документ за самоличност на български граждани по номер на документ")]
        [Info(requestXSD: "PersonalIdentityInfoRequestV3.xsd",
              responseXSD: "PersonalIdentityInfoResponseV3.xsd",
              requestXSLT: "GetPersonalIdentityV3Request.xslt",
              responseXSLT: "GetPersonalIdentityV3Response.xslt")]
        ServiceResultDataSigned<MVRBDSAdapterV3.PersonalIdentityInfoRequestType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType> GetPersonalIdentityV3(ServiceRequestData<MVRBDSAdapterV3.PersonalIdentityInfoRequestType> argument);

    }
}
