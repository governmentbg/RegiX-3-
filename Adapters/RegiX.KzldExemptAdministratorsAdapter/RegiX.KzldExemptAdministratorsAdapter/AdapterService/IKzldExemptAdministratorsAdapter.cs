using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Комисия за защита на личните данни - Регистър на освободените от регистрация администратори на лични данни")]
    public interface IKzldExemptAdministratorsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ/ЕГН/ЛНЧ за освободен от регистрация  администратор на лични данни")]
        CommonSignedResponse<ExemptRegistrationRequestType, ExemptRegistrationAdministratorResponse> GetExemptRegistrationAdministrator(ExemptRegistrationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

