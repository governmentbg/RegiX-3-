using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MPNPOAdapter.AdapterService;

namespace TechnoLogica.RegiX.MPNPOAdapter.APIService
{
    [ExportFullName(typeof(IMPNPOAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MPNPOAPI : BaseAPIService<IMPNPOAPI>, IMPNPOAPI
    {
        public ServiceResultDataSigned<NPODetailsRequestType, NPODetailsResponseType> GetNPORegistrationInfo(ServiceRequestData<NPODetailsRequestType> argument)
        {
            return  AdapterClient.Execute<IMPNPOAdapter, NPODetailsRequestType, NPODetailsResponseType>(
                        (i, r, a, o) => i.GetNPORegistrationInfo(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<NPOStatusRequestType, NPOStatusResponseType> GetNPOStatusInfo(ServiceRequestData<NPOStatusRequestType> argument)
        {
            return AdapterClient.Execute<IMPNPOAdapter, NPOStatusRequestType, NPOStatusResponseType>(
                        (i, r, a, o) => i.GetNPOStatusInfo(r, a, o),
                        argument);
        }
    }
}
