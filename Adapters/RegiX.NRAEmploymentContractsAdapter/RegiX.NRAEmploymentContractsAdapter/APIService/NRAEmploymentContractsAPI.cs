using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter.APIService
{
    [ExportFullName(typeof(INRAEmploymentContractsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NRAEmploymentContractsAPI : BaseAPIService<INRAEmploymentContractsAPI>, INRAEmploymentContractsAPI
    {
        public ServiceResultDataSigned<EmploymentContractsRequest, EmploymentContractsResponse> GetEmploymentContracts(ServiceRequestData<EmploymentContractsRequest> argument)
        {
            return  AdapterClient.Execute<INRAEmploymentContractsAdapter, EmploymentContractsRequest, EmploymentContractsResponse>(
                        (i, r, a, o) => i.GetEmploymentContracts(r, a, o),
                        argument);
        }
    }
}