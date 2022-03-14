using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.KzldAdministratorsAdapter.AdapterService;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;

namespace TechnoLogica.RegiX.KzldAdministratorsAdapter.APIService
{
    [ExportFullName(typeof(IKzldAdministratorsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class KzldAdministratorsAPI : BaseAPIService<IKzldAdministratorsAPI>, IKzldAdministratorsAPI
    {
        public ServiceResultDataSigned<RegisteredAdministratorByIDType, RegisteredAdministratorByIDResponse> GetRegisteredAdministratorByID(ServiceRequestData<RegisteredAdministratorByIDType> argument)
        {
            return  AdapterClient.Execute<IKzldAdministratorsAdapter, RegisteredAdministratorByIDType, RegisteredAdministratorByIDResponse>(
                (i, r, a, o) => i.GetRegisteredAdministratorByID(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<RegisteredAdministratorByNumberType, RegisteredAdministratorByNumberResponse> GetRegisteredAdministratorByNumber(ServiceRequestData<RegisteredAdministratorByNumberType> argument)
        {
            return AdapterClient.Execute<IKzldAdministratorsAdapter, RegisteredAdministratorByNumberType, RegisteredAdministratorByNumberResponse>(
                (i, r, a, o) => i.GetRegisteredAdministratorByNumber(r, a, o),
                 argument);
        }
    }
}
