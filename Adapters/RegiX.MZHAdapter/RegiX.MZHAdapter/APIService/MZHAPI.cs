using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MZHAdapter.AdapterService;

namespace TechnoLogica.RegiX.MZHAdapter.APIService
{
    [ExportFullName(typeof(IMZHAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MZHAPI : BaseAPIService<IMZHAPI>, IMZHAPI
    {
        public ServiceResultDataSigned<FarmerSearchParametersType, FarmerType> FarmerDetailsSearch(ServiceRequestData<FarmerSearchParametersType> argument)
        {
            return  AdapterClient.Execute<IMZHAdapter, FarmerSearchParametersType, FarmerType>(
                        (i, r, a, o) => i.FarmerDetailsSearch(r, a,o),
                        argument);
        }
    }
}
