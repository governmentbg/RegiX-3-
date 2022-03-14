using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.ChNTsAdapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.ChNTsAdapter.APIService
{
    [ExportFullName(typeof(IChNTsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class ChNTsAPI : BaseAPIService<IChNTsAPI>, IChNTsAPI
    {
        public ServiceResultDataSigned<ForeignerPermissionsRequestType, ForeignerPermissionsResponseType> GetForeignerPermissions(ServiceRequestData<ForeignerPermissionsRequestType> argument)
        {
            return AdapterClient.Execute<IChNTsAdapter, ForeignerPermissionsRequestType, ForeignerPermissionsResponseType>(
                        (i, r, a, o) => i.GetForeignerPermissions(r, a, o),
                        argument);
        }
    }
}
