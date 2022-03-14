using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.DataContracts;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистър на задължените лица")]
    public interface INRAObligatedPersonsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за наличие/ липса на задължения")]
        CommonSignedResponse<ObligationRequest, ObligationResponse> GetObligatedPersons(ObligationRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка с данни за осигурените лица от подадени декларации по Наредба Н-13 към Кодекса за социално осигуряване")]
        CommonSignedResponse<SocialSecurityDataFromDeclarationRequestType, GetSocialSecurityDataFromDeclarationsResponse> GetSocialSecurityDataFromDeclarations(SocialSecurityDataFromDeclarationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}
