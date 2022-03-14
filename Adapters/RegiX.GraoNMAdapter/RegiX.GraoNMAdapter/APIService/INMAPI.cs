using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.GraoNMAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Класификатор на населените места")]
    public interface INMAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка на населени места")]
        [Info(requestXSD: "SettlementPlacesRequest.xsd",
            responseXSD: "SettlementPlacesResponse.xsd",
            commonXSD: "NMCommon.xsd",
            requestXSLT: "SettlementPlacesRequest.xslt",
            responseXSLT: "SettlementPlacesResponse.xslt")]
        ServiceResultDataSigned <SettlementPlacesRequestType,SettlementPlacesResponseType> SettlementPlacesSearch(ServiceRequestData<SettlementPlacesRequestType> argument);
    }
}
