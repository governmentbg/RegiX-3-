using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.ZADSAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.ZADSAdapter.APIService
{
    [ExportFullName(typeof(IZADSAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class ZADSAPI : BaseAPIService<IZADSAPI>, IZADSAPI
    {
        public ServiceResultDataSigned<RegistrationInfoRequestType, RegistrationInfoResponseType> GetRegistrationInfo(ServiceRequestData<RegistrationInfoRequestType> argument)
        {
            return  AdapterClient.Execute<IZADSAdapter, RegistrationInfoRequestType, RegistrationInfoResponseType>(
                        (i, r, a, o) => i.GetRegistrationInfo(r, a, o),
                        argument);
        }
    }
}
