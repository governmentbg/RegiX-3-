using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.APIService
{
    [ExportFullName(typeof(IKzldDeniedAdministratorsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class KzldDeniedAdministratorsAPI : BaseAPIService<IKzldDeniedAdministratorsAPI>, IKzldDeniedAdministratorsAPI
    {
        public ServiceResultDataSigned<DeniedEntryAdministratorRequestType, DeniedEntryAdministratorResponse> GetRegisteredAdministratorByID(ServiceRequestData<DeniedEntryAdministratorRequestType> argument)
        {
            return  AdapterClient.Execute<IKzldDeniedAdministratorsAdapter, DeniedEntryAdministratorRequestType, DeniedEntryAdministratorResponse>(
                (i, r, a, o) => i.GetRegisteredAdministratorByID(r, a ,o ),
                 argument);
        }
    }
}
