using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.RTSAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("Републиканска транспортна схема")]
    public interface IRTSAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за маршрутни разписания")]
        [Info(requestXSD: "RoutesSearch.xsd",
              responseXSD: "routesSchema.xsd",
              requestXSLT: "RoutesSearch.xslt",
              responseXSLT: "RoutesResponse.xslt")]
        ServiceResultDataSigned<RoutesSearch, RoutesResponse> GetRoutesTimeTable(ServiceRequestData<RoutesSearch> argument);
    }
}
