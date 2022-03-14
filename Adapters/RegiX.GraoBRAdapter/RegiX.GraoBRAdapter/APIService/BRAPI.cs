using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GraoBRAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoBRAdapter.APIService
{
    [ExportFullName(typeof(IBRAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class BRAPI : BaseAPIService<IBRAPI>, IBRAPI
    {
        public ServiceResultDataSigned<MaritalStatusRequestType, MaritalStatusResponseType> MaritalStatusSearch(ServiceRequestData<MaritalStatusRequestType> argument)
        {
            return AdapterClient.Execute<IBRAdapter, MaritalStatusRequestType, MaritalStatusResponseType>(
                        (i, r, a, o) => i.MaritalStatusSearch(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<SpouseRequestType, SpouseResponseType> SpouseSearch(ServiceRequestData<SpouseRequestType> argument)
        {
            return AdapterClient.Execute<IBRAdapter, SpouseRequestType, SpouseResponseType>(
                        (i, r, a, o) => i.SpouseSearch(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MarriageRequestType, MarriageResponseType> MarriageSearch(ServiceRequestData<MarriageRequestType> argument)
        {
            return AdapterClient.Execute<IBRAdapter, MarriageRequestType, MarriageResponseType>(
                        (i, r, a, o) => i.MarriageSearch(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MaritalStatusSpouseChildrenRequestType, MaritalStatusSpouseChildrenResponseType> MaritalStatusSpouseChildrenSearch(ServiceRequestData<MaritalStatusSpouseChildrenRequestType> argument)
        {
            return AdapterClient.Execute<IBRAdapter, MaritalStatusSpouseChildrenRequestType, MaritalStatusSpouseChildrenResponseType>(
                        (i, r, a, o) => i.MaritalStatusSpouseChildrenSearch(r, a, o),
                        argument);
        }
    }
}
