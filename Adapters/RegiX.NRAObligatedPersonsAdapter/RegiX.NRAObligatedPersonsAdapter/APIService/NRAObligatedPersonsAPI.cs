using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter.APIService
{
    [ExportFullName(typeof(INRAObligatedPersonsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NRAObligatedPersonsAPI : BaseAPIService<INRAObligatedPersonsAPI>, INRAObligatedPersonsAPI
    {
        public ServiceResultDataSigned<ObligationRequest, ObligationResponse> GetObligatedPersons(ServiceRequestData<ObligationRequest> argument)
        {
            return  AdapterClient.Execute<INRAObligatedPersonsAdapter, ObligationRequest, ObligationResponse>(
                        (i, r, a, o) => i.GetObligatedPersons(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<SocialSecurityDataFromDeclarationRequestType, GetSocialSecurityDataFromDeclarationsResponse> GetSocialSecurityDataFromDeclarations(ServiceRequestData<SocialSecurityDataFromDeclarationRequestType> argument)
        {
            return AdapterClient.Execute<INRAObligatedPersonsAdapter, SocialSecurityDataFromDeclarationRequestType, GetSocialSecurityDataFromDeclarationsResponse>(
                        (i, r, a, o) => i.GetSocialSecurityDataFromDeclarations(r, a, o),
                        argument);
        }
    }
}
