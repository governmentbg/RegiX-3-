using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MZHPastureAdapter.AdapterService;

namespace TechnoLogica.RegiX.MZHPastureAdapter.APIService
{
    [ExportFullName(typeof(IMZHPastureAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MZHPastureAPI : BaseAPIService<IMZHPastureAPI>, IMZHPastureAPI
    {
        public ServiceResultDataSigned<PastureMeadowLandRequestType, PastureMeadowLandResponse> GetPastureMeadowLand(ServiceRequestData<PastureMeadowLandRequestType> argument)
        {
            return AdapterClient.Execute<IMZHPastureAdapterService, PastureMeadowLandRequestType, PastureMeadowLandResponse>(
                (i, r, a, o) => i.GetPastureMeadowLand(r, a, o),
                argument);
        }

        public ServiceResultDataSigned<PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse> GetPastureMeadowLandDetail(ServiceRequestData<PastureMeadowLandDetailRequestType> argument)
        {
            return AdapterClient.Execute<IMZHPastureAdapterService, PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse>(
                (i, r, a, o) => i.GetPastureMeadowLandDetail(r, a, o),
                argument);
        }
    }
}
