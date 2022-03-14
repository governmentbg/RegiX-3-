using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Комисия за защита на личните данни - Регистър на администратори на лични данни с отказана регистрация")]
    public interface IKzldDeniedAdministratorsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за администратор на лични данни с отказана регистрация")]
        CommonSignedResponse<DeniedEntryAdministratorRequestType, DeniedEntryAdministratorResponse> GetRegisteredAdministratorByID(DeniedEntryAdministratorRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

