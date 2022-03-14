using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.MPRNAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистъра на производствата по несъстоятелност")]
    public interface IRNAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за вписани обстоятелства в Регистъра на производствата по несъстоятелност")]
        [Info(requestXSD: "RNSearchRequest.xsd",
            responseXSD: "RNSearchResponse.xsd",
            requestXSLT: "RNSearchRequest.xslt",
            responseXSLT: "RNSearchResponse.xslt")]
        ServiceResultDataSigned<RNSearchRequestType, RNSearchResponseType> RegisterOfInsolvenciesSearch(ServiceRequestData<RNSearchRequestType> argument);
    }
}
