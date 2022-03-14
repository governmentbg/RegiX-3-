using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MVRERChAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRERChAdapter.APIService
{
    [ExportFullName(typeof(IMVRERChAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MVRERChAPI : BaseAPIService<IMVRERChAPI>, IMVRERChAPI
    {
        public ServiceResultDataSigned<ForeignIdentityInfoRequestType, ForeignIdentityInfoResponseType> GetForeignIdentity(ServiceRequestData<ForeignIdentityInfoRequestType> argument)
        {
            return  AdapterClient.Execute<IMVRERChAdapter, ForeignIdentityInfoRequestType, ForeignIdentityInfoResponseType>(
                        (i, r, a, o) => i.GetForeignIdentity(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MVRERChAdapterV2.ForeignIdentityInfoRequestType, MVRERChAdapterV2.ForeignIdentityInfoResponseType> GetForeignIdentityV2(ServiceRequestData<MVRERChAdapterV2.ForeignIdentityInfoRequestType> argument)
        {
            return AdapterClient.Execute<IMVRERChAdapter, MVRERChAdapterV2.ForeignIdentityInfoRequestType, MVRERChAdapterV2.ForeignIdentityInfoResponseType>(
                        (i, r, a, o) => i.GetForeignIdentityV2(r, a, o),
                        argument);
        }
    }
}
