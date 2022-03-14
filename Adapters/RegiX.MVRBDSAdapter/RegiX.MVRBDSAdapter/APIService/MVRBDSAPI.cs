using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MVRBDSAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRBDSAdapter.APIService
{
    [ExportFullName(typeof(IMVRBDSAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MVRBDSAPI : BaseAPIService<IMVRBDSAPI>, IMVRBDSAPI
    {
        public ServiceResultDataSigned<PersonalIdentityInfoRequestType, PersonalIdentityInfoResponseType> GetPersonalIdentity(ServiceRequestData<PersonalIdentityInfoRequestType> argument)
        {
            return  AdapterClient.Execute<IMVRBDSAdapter, PersonalIdentityInfoRequestType, PersonalIdentityInfoResponseType>(
                        (i, r, a, o) => i.GetPersonalIdentity(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MVRBDSAdapterV2.PersonalIdentityInfoRequestType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType> GetPersonalIdentityV2(ServiceRequestData<MVRBDSAdapterV2.PersonalIdentityInfoRequestType> argument)
        {
            return AdapterClient.Execute<IMVRBDSAdapter, MVRBDSAdapterV2.PersonalIdentityInfoRequestType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType>(
                        (i, r, a, o) => i.GetPersonalIdentityV2(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MVRBDSAdapterV3.PersonalIdentityInfoRequestType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType> GetPersonalIdentityV3(ServiceRequestData<MVRBDSAdapterV3.PersonalIdentityInfoRequestType> argument)
        {
            return AdapterClient.Execute<IMVRBDSAdapter, MVRBDSAdapterV3.PersonalIdentityInfoRequestType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType>(
                        (i, r, a, o) => i.GetPersonalIdentityV3(r, a, o),
                        argument);
        }
    }
}
