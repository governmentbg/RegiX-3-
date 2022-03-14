using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GvaAircraftsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Главна дирекция Гражданска въздухоплавателна администрация - Регистър на гражданските въздухоплавателни средства на Република България")]
    public interface IGvaAircraftsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по сериен номер на въздухоплавателно средство за вписани в регистъра обстоятелства")]
        CommonSignedResponse<AircraftsByMSNType, AircraftsResponse> GetAircraftsByMSN(AircraftsByMSNType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за вписани на името на лицето въздухоплавателни средства")]
        CommonSignedResponse<AircraftsByOwnerType, AircraftsResponse> GetAircraftsByOwner(AircraftsByOwnerType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

