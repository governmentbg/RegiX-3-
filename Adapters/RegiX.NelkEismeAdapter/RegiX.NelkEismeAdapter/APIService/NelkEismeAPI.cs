using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NelkEismeAdapter.AdapterService;
using TechnoLogica.RegiX.NelkEismeAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.NelkEismeAdapter.APIService
{
    [ExportFullName(typeof(INelkEismeAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NelkEismeAPI : BaseAPIService<INelkEismeAPI>, INelkEismeAPI
    {
        public ServiceResultDataSigned<GetAllExpertDecisionsByIdentifierRequest, ExpertDecisionsResponse> GetAllExpertDecisionsByIdentifier(ServiceRequestData<GetAllExpertDecisionsByIdentifierRequest> argument)
        {
            return  AdapterClient.Execute<INelkEismeAdapter, GetAllExpertDecisionsByIdentifierRequest, ExpertDecisionsResponse>(
                (i, r, a, o) => i.GetAllExpertDecisionsByIdentifier(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetLastExpertDecisionByIdentifierRequest, ExpertDecisionsResponse> GetLastExpertDecisionByIdentifier(ServiceRequestData<GetLastExpertDecisionByIdentifierRequest> argument)
        {
            return AdapterClient.Execute<INelkEismeAdapter, GetLastExpertDecisionByIdentifierRequest, ExpertDecisionsResponse>(
                (i, r, a, o) => i.GetLastExpertDecisionByIdentifier(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetAllExpertDecisionsByPeriodRequest, ExpertDesisionShortInfoForPeriodList> GetAllExpertDecisionsByPeriod(ServiceRequestData<GetAllExpertDecisionsByPeriodRequest> argument)
        {
            return AdapterClient.Execute<INelkEismeAdapter, GetAllExpertDecisionsByPeriodRequest, ExpertDesisionShortInfoForPeriodList>(
                (i, r, a, o) => i.GetAllExpertDecisionsByPeriod(r, a, o),
                 argument);
        }
    }
}
