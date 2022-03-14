using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService;

namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.APIService
{
    [ExportFullName(typeof(IGitPenalProvisionsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class GitPenalProvisionsAPI : BaseAPIService<IGitPenalProvisionsAPI>, IGitPenalProvisionsAPI
    {
        public ServiceResultDataSigned<PenalProvisionForPeriodRequest, PenalProvisionForPeriodResponse> GetPenalProvisionForPeriod(ServiceRequestData<PenalProvisionForPeriodRequest> argument)
        {
            return AdapterClient.Execute<IGitPenalProvisionsAdapter, PenalProvisionForPeriodRequest, PenalProvisionForPeriodResponse>(
                (i, r, a, o) => i.GetPenalProvisionForPeriod(r, a, o),
                 argument);
        }        

        public ServiceResultDataSigned<PenalProvisionMediatorActType, PenalProvisionMediatorActResponse> GetPenalProvisionMediatorAct(ServiceRequestData<PenalProvisionMediatorActType> argument)
        {
            return AdapterClient.Execute<IGitPenalProvisionsAdapter, PenalProvisionMediatorActType, PenalProvisionMediatorActResponse>(
                (i, r, a, o) => i.GetPenalProvisionMediatorAct(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PenalProvisionUnpaidFeeType, PenalProvisionUnpaidFeeResponse> GetPenalProvisionUnpaidFee(ServiceRequestData<PenalProvisionUnpaidFeeType> argument)
        {
            return AdapterClient.Execute<IGitPenalProvisionsAdapter, PenalProvisionUnpaidFeeType, PenalProvisionUnpaidFeeResponse>(
                (i, r, a, o) => i.GetPenalProvisionUnpaidFee(r, a, o),
                 argument);
        }
    }
}
