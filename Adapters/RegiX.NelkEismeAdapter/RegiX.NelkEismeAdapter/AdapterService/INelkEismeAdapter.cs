using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.NelkEismeAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.NelkEismeAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Национална експертна лекарска комисия (НЕЛК) - Единна информационна система на медицинската експертиза")]
    public interface INelkEismeAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за всички експертни решения на лице")]
        CommonSignedResponse<GetAllExpertDecisionsByIdentifierRequest, ExpertDecisionsResponse> GetAllExpertDecisionsByIdentifier(GetAllExpertDecisionsByIdentifierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за последното експертно решение на лице")]
        CommonSignedResponse<GetLastExpertDecisionByIdentifierRequest, ExpertDecisionsResponse> GetLastExpertDecisionByIdentifier(GetLastExpertDecisionByIdentifierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за всички експертни решения, издадени за период")]
        CommonSignedResponse<GetAllExpertDecisionsByPeriodRequest, ExpertDesisionShortInfoForPeriodList> GetAllExpertDecisionsByPeriod(GetAllExpertDecisionsByPeriodRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
