using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.RTSAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.RTSAdapter.APIService
{
    [ExportFullName(typeof(IRTSAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class RTSAPI : BaseAPIService<IRTSAPI>, IRTSAPI
    {
        public ServiceResultDataSigned<RoutesSearch, RoutesResponse> GetRoutesTimeTable(ServiceRequestData<RoutesSearch> argument)
        {
            return  AdapterClient.Execute<IRTSAdapter, RoutesSearch, RoutesResponse>(
                        (i, r, a, o) => i.GetRoutesTimeTable(r, a,o),
                        argument);
        }
    }
}
