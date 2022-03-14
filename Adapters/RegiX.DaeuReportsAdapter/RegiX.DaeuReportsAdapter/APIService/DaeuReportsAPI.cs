using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.DaeuReportsAdapter.AdapterService;

namespace TechnoLogica.RegiX.DaeuReportsAdapter.APIService
{
    [ExportFullName(typeof(IDaeuReportsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class DaeuReportsAPI : BaseAPIService<IDaeuReportsAPI>, IDaeuReportsAPI
    {
        public ServiceResultDataSigned<SearchByIdentifierRequestType, SearchByIdentifierResponse> SearchByIdentifier(ServiceRequestData<SearchByIdentifierRequestType> argument)
        {
            return AdapterClient.Execute<IDaeuReportsAdapter, SearchByIdentifierRequestType, SearchByIdentifierResponse>(
                (i, r, a, o) => i.SearchByIdentifier(r, a, o),
                argument);
        }
    }
}
