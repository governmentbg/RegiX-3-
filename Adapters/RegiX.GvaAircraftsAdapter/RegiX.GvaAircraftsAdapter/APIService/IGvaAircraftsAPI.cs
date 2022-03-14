using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.GvaAircraftsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Главна дирекция Гражданска въздухоплавателна администрация - Регистър на гражданските въздухоплавателни средства на Република България")]
    public interface IGvaAircraftsAPI : IAPIService
    {
        //Справка по сериен номер на въздухоплавателно средство за вписани в регистъра обстоятелства
        [OperationContract]
        [Description("Справка по сериен номер на въздухоплавателно средство за вписани в регистъра обстоятелства")]
        [Info(requestXSD: "AircraftsByMSNRequest.xsd",
            responseXSD: "AircraftsResponse.xsd",
            requestXSLT: "AircraftsByMSNRequest.xslt",
            responseXSLT: "AircraftsResponse.xslt")]
        ServiceResultDataSigned<AircraftsByMSNType, AircraftsResponse> GetAircraftsByMSN(ServiceRequestData<AircraftsByMSNType> argument);

        //Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за вписани на името на лицето въздухоплавателни средства
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за вписани на името на лицето въздухоплавателни средства")]
        [Info(requestXSD: "AircraftsByOwnerRequest.xsd",
            responseXSD: "AircraftsResponse.xsd",
            requestXSLT: "AircraftsByOwnerRequest.xslt",
            responseXSLT: "AircraftsResponse.xslt")]
        ServiceResultDataSigned<AircraftsByOwnerType, AircraftsResponse> GetAircraftsByOwner(ServiceRequestData<AircraftsByOwnerType> argument);
    }
}
