using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GitActualDeclarationAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителна агенция Главна инспекция по труда - Публичен регистър на годишните декларации по чл. 15 от ЗЗБУТ")]
    public interface IGitActualDeclarationAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕГН/ЕИК за актуална декларация")]
        CommonSignedResponse<AuthenticityExplosivesRequestType, RZZBUTDeclaration> GetActualDeclaration(AuthenticityExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}