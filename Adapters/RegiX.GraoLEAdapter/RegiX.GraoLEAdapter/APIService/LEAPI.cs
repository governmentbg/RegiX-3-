using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GraoLEAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoLEAdapter.APIService
{
    [ExportFullName(typeof(ILEAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class LEAPI : BaseAPIService<ILEAPI>, ILEAPI
    {
        public ServiceResultDataSigned<LocationsRequestType, LocationsResponseType> LocationsSearch(ServiceRequestData<LocationsRequestType> argument)
        {
            return  AdapterClient.Execute<ILEAdapter, LocationsRequestType, LocationsResponseType>(
                        (i, r, a, o) => i.LocationsSearch(r, a, o),
                        argument);
        }
    }
}
