using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NoiROAdapter.AdapterService;

namespace TechnoLogica.RegiX.NoiROAdapter.APIService
{
    [ExportFullName(typeof(IROAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class ROAPI : BaseAPIService<IROAPI>, IROAPI
    {
        public ServiceResultDataSigned<POVNPOBRequestType, POVNPOBResponseType> SearchDisabilityCompensationByCompensationPeriod(ServiceRequestData<POVNPOBRequestType> argument)
        {
            return  AdapterClient.Execute<IROAdapter, POVNPOBRequestType, POVNPOBResponseType>(
                        (i, r, a, o) => i.SearchDisabilityCompensationByCompensationPeriod(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<POVNVEDRequestType, POVNVEDResponseType> SearchDisabilityCompensationByPaymentPeriod(ServiceRequestData<POVNVEDRequestType> argument)
        {
            return AdapterClient.Execute<IROAdapter, POVNVEDRequestType, POVNVEDResponseType>(
                        (i, r, a, o) => i.SearchDisabilityCompensationByPaymentPeriod(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<POBPOBRequestType, POBPOBResponseType> SearchUnemploymentCompensationByCompensationPeriod(ServiceRequestData<POBPOBRequestType> argument)
        {
            return AdapterClient.Execute<IROAdapter, POBPOBRequestType, POBPOBResponseType>(
                        (i, r, a, o) => i.SearchUnemploymentCompensationByCompensationPeriod(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<POBVEDRequestType, POBVEDResponseType> SearchUnemploymentCompensationByPaymentPeriod(ServiceRequestData<POBVEDRequestType> argument)
        {
            return  AdapterClient.Execute<IROAdapter, POBVEDRequestType, POBVEDResponseType>(
                        (i, r, a, o) => i.SearchUnemploymentCompensationByPaymentPeriod(r, a, o),
                        argument);
        }
    }
}