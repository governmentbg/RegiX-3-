using RegiX.CPCProcurementDossierAdapter.AdapterService;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CPCProcurementDossierAdapter;

namespace RegiX.CPCProcurementDossierAdapter.APIService
{
    [ExportFullName(typeof(ICPCProcurementDossierAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class CPCProcurementDossierAPI : BaseAPIService<ICPCProcurementDossierAPI>, ICPCProcurementDossierAPI
    {
        public ServiceResultDataSigned<GetProcurementDossierRequest, GetProcurementDossierResponse> GetProcurementDossier(ServiceRequestData<GetProcurementDossierRequest> argument)
        {
            return AdapterClient.Execute<ICPCProcurementDossierAdapter, GetProcurementDossierRequest, GetProcurementDossierResponse>(
                        (i, r, a, o) => i.GetProcurementDossier(r, a, o),
                        argument);
        }
    }
}
