using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GraoNBDAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoNBDAdapter.APIService
{
    [ExportFullName(typeof(INBDAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NBDAPI : BaseAPIService<INBDAPI>, INBDAPI
    {
        public ServiceResultDataSigned<ValidPersonRequestType, ValidPersonResponseType> ValidPersonSearch(ServiceRequestData<ValidPersonRequestType> argument)
        {
            return AdapterClient.Execute<INBDAdapter, ValidPersonRequestType, ValidPersonResponseType>(
                        (i, r, a, o) => i.ValidPersonSearch(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<RelationsRequestType, RelationsResponseType> RelationsSearch(ServiceRequestData<RelationsRequestType> argument)
        {
            return AdapterClient.Execute<INBDAdapter , RelationsRequestType, RelationsResponseType>(
                        (i, r, a, o) => i.RelationsSearch(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<PersonDataRequestType, PersonDataResponseType> PersonDataSearch(ServiceRequestData<PersonDataRequestType> argument)
        {
            return AdapterClient.Execute<INBDAdapter, PersonDataRequestType, PersonDataResponseType>(
                        (i, r, a, o) => i.PersonDataSearch(r, a, o),
                        argument);
        }
    }
}
