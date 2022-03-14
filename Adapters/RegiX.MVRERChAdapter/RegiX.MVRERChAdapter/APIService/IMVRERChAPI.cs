using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MVRERChAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Единния регистър за чужденци на МВР")]
    public interface IMVRERChAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за физическо лице – чужденец")]
        [Info(requestXSD: "ForeignIdentityInfoRequest.xsd",
            responseXSD: "ForeignIdentityInfoResponse.xsd",
            requestXSLT: "ForeignIdentityInfoRequest.xslt",
            responseXSLT: "ForeignIdentityInfoResponse.xslt")]
        ServiceResultDataSigned<ForeignIdentityInfoRequestType, ForeignIdentityInfoResponseType> GetForeignIdentity(ServiceRequestData<ForeignIdentityInfoRequestType> argument);

        [OperationContract]
        [Description("Справка за физическо лице – чужденец V2")]
        [Info(requestXSD: "ForeignIdentityInfoRequestV2.xsd",
            responseXSD: "ForeignIdentityInfoResponseV2.xsd",
            requestXSLT: "ForeignIdentityInfoRequestV2.xslt",
            responseXSLT: "ForeignIdentityInfoResponseV2.xslt")]
        ServiceResultDataSigned<MVRERChAdapterV2.ForeignIdentityInfoRequestType, MVRERChAdapterV2.ForeignIdentityInfoResponseType> GetForeignIdentityV2(ServiceRequestData<MVRERChAdapterV2.ForeignIdentityInfoRequestType> argument);
    }
}