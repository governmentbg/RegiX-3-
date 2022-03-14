using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GraoPNAAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoPNAAdapter.APIService
{
    [ExportFullName(typeof(IPNAAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PNAAPI: BaseAPIService<IPNAAPI>, IPNAAPI
    {
        public ServiceResultDataSigned<PermanentAddressRequestType, PermanentAddressResponseType> PermanentAddressSearch(ServiceRequestData<PermanentAddressRequestType> argument)
        {
            return  AdapterClient.Execute<IPNAAdapter, PermanentAddressRequestType, PermanentAddressResponseType>(
                        (i, r, a, o) => i.PermanentAddressSearch(r, a, o),
                        argument);
        }
        public ServiceResultDataSigned<TemporaryAddressRequestType, TemporaryAddressResponseType> TemporaryAddressSearch(ServiceRequestData<TemporaryAddressRequestType> argument)
        {
            return  AdapterClient.Execute<IPNAAdapter, TemporaryAddressRequestType, TemporaryAddressResponseType>(
                        (i, r, a, o) => i.TemporaryAddressSearch(r, a, o),
                        argument);
        }
    }
}


