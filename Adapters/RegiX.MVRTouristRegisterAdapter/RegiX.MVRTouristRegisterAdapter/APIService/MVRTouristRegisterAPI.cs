using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MVRTouristRegisterAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRTouristRegisterAdapter.APIService
{
    [ExportFullName(typeof(IMVRTouristRegisterAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MVRTouristRegisterAPI : BaseAPIService<IMVRTouristRegisterAPI>, IMVRTouristRegisterAPI
    {
        public ServiceResultDataSigned<MvrAccomodationPlaceRequestType, MvrAccomodationPlaceResponseType> SendInfoForEstiAccomodationPlace(ServiceRequestData<MvrAccomodationPlaceRequestType> argument)
        {
            return AdapterClient.Execute<IMVRTouristRegisterAdapter, MvrAccomodationPlaceRequestType, MvrAccomodationPlaceResponseType>(
                (i, r, a, o) => i.SendInfoForEstiAccomodationPlace(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<TouristRegisterRequestType, TouristRegisterResponseType> SendInfoForTouristRegister(ServiceRequestData<TouristRegisterRequestType> argument)
        {
            return AdapterClient.Execute<IMVRTouristRegisterAdapter, TouristRegisterRequestType, TouristRegisterResponseType>(
                (i, r, a, o) => i.SendInfoForTouristRegister(r, a, o),
                 argument);
        }

        public override string GetMetaDataXML(string operationName)
        {
            return "---";
        }
    }
}
