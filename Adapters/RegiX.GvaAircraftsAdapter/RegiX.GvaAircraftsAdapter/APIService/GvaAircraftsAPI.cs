using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GvaAircraftsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.GvaAircraftsAdapter.APIService
{
    [ExportFullName(typeof(IGvaAircraftsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class GvaAircraftsAPI : BaseAPIService<IGvaAircraftsAPI>, IGvaAircraftsAPI
    {
        public ServiceResultDataSigned<AircraftsByMSNType, AircraftsResponse> GetAircraftsByMSN(ServiceRequestData<AircraftsByMSNType> argument)
        {
            return  AdapterClient.Execute<IGvaAircraftsAdapter, AircraftsByMSNType, AircraftsResponse>(
                (i, r, a, o) => i.GetAircraftsByMSN(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<AircraftsByOwnerType, AircraftsResponse> GetAircraftsByOwner(ServiceRequestData<AircraftsByOwnerType> argument)
        {
            return  AdapterClient.Execute<IGvaAircraftsAdapter, AircraftsByOwnerType, AircraftsResponse>(
                (i, r, a, o) => i.GetAircraftsByOwner(r, a, o),
                 argument);
        }
    }
}
