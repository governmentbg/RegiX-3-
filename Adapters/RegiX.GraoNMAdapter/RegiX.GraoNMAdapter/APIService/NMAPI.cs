using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GraoNMAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoNMAdapter.APIService
{
    [ExportFullName(typeof(INMAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NMAPI : BaseAPIService<INMAPI>, INMAPI
    {
        public ServiceResultDataSigned<SettlementPlacesRequestType, SettlementPlacesResponseType> SettlementPlacesSearch(ServiceRequestData<SettlementPlacesRequestType> argument)
        {
            return  AdapterClient.Execute<INMAdapter, SettlementPlacesRequestType, SettlementPlacesResponseType>(
                        (i, r, a, o) => i.SettlementPlacesSearch(r, a, o),
                        argument);
        }
    }
}
