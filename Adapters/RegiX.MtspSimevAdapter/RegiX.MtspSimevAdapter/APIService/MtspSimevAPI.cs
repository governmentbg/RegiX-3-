using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MtspSimevAdapter.AdapterService;

namespace TechnoLogica.RegiX.MtspSimevAdapter.APIService
{
    [ExportFullName(typeof(IMtspSimevAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MtspSimevAPI : BaseAPIService<IMtspSimevAPI>, IMtspSimevAPI
    {
        public ServiceResultDataSigned<MtspInfoFosterParentsRequest, MtspInfoFosterParentsResponse> SendInfoForFosterParents(ServiceRequestData<MtspInfoFosterParentsRequest> argument)
        {
            return  AdapterClient.Execute<IMtspSimevAdapter, MtspInfoFosterParentsRequest, MtspInfoFosterParentsResponse>(
                (i, r, a, o) => i.SendInfoForFosterParents(r, a, o),
                 argument);
        }
    }
}
