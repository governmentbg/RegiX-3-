using TechnoLogica.RegiX.MtEstiAdapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;

namespace TechnoLogica.RegiX.MtEstiAdapter.APIService
{
    [ExportFullName(typeof(IMtEstiAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MtEstiAPI : BaseAPIService<IMtEstiAPI>, IMtEstiAPI
    {
        public ServiceResultDataSigned<AccomodationPlaceRequestType, AccomodationPlaceResponseType> SendInfoForAccomodationPlace(ServiceRequestData<AccomodationPlaceRequestType> argument)
        {
            return  AdapterClient.Execute<IMtEstiAdapter, AccomodationPlaceRequestType, AccomodationPlaceResponseType>(
                (i, r, a, o) => i.SendInfoForAccomodationPlace(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<AccRegister.AccomodationRegisterRequestType, AccRegister.AccomodationRegisterResponseType> SendInfoForAccomodationRegister(ServiceRequestData<AccRegister.AccomodationRegisterRequestType> argument)
        {
            return AdapterClient.Execute<IMtEstiAdapter, AccRegister.AccomodationRegisterRequestType, AccRegister.AccomodationRegisterResponseType>(
                (i, r, a, o) => i.SendInfoForAccomodationRegister(r, a, o),
                 argument);
        }

        public override string GetMetaDataXML(string operationName)
        {
            return "---";
        }
    }
}
