using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителна агенция Главна инспекция по труда - Регистър на заверените свидетелства за работа с взривни материали")]
    public interface IGitExplosivesAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за автентичност на свидетелство за работа с взривни материали")]
        CommonSignedResponse<AuthenticityExplosivesRequestType, ValidExplosivesCertificateResponse> GetAuthenticityExplosivesCertificate(AuthenticityExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за валидни свидетелства за работа с взривни материали")]
        CommonSignedResponse<ValidExplosivesRequestType, ValidExplosivesCertificateResponse> GetValidExplosivesCertificate(ValidExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

