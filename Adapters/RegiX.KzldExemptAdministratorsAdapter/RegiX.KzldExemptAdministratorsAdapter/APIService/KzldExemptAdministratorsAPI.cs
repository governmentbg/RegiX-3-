using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.APIService
{
    [ExportFullName(typeof(IKzldExemptAdministratorsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class KzldExemptAdministratorsAPI : BaseAPIService<IKzldExemptAdministratorsAPI>, IKzldExemptAdministratorsAPI
    {
        public ServiceResultDataSigned<ExemptRegistrationRequestType, ExemptRegistrationAdministratorResponse> GetExemptRegistrationAdministrator(ServiceRequestData<ExemptRegistrationRequestType> argument)
        {
            return  AdapterClient.Execute<IKzldExemptAdministratorsAdapter, ExemptRegistrationRequestType, ExemptRegistrationAdministratorResponse>(
                (i, r, a, o) => i.GetExemptRegistrationAdministrator(r, a, o),
                 argument);
        }
    }
}
