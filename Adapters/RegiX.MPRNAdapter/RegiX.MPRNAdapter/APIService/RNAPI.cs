using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MPRNAdapter.AdapterService;

namespace TechnoLogica.RegiX.MPRNAdapter.APIService
{
    [ExportFullName(typeof(IRNAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class RNAPI : BaseAPIService<IRNAPI>, IRNAPI
    {
        public ServiceResultDataSigned<RNSearchRequestType, RNSearchResponseType> RegisterOfInsolvenciesSearch(ServiceRequestData<RNSearchRequestType> argument)
        {
            return  AdapterClient.Execute<IRNAdapter, RNSearchRequestType, RNSearchResponseType>(
                        (i, r, a, o) => i.RegisterOfInsolvenciesSearch(r, a, o),
                        argument);
        }
    }
}
