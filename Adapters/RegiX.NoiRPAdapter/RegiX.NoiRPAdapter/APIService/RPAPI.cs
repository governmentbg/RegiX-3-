using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NoiRPAdapter.AdapterService;

namespace TechnoLogica.RegiX.NoiRPAdapter.APIService
{
    [ExportFullName(typeof(IRPAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class RPAPI : BaseAPIService<IRPAPI>, IRPAPI
    {
        public ServiceResultDataSigned<PensionRightRequestType, PensionRightResponseType> GetPensionRightInfoReport(ServiceRequestData<PensionRightRequestType> argument)
        {
            return  AdapterClient.Execute<IRPAdapter, PensionRightRequestType, PensionRightResponseType>(
                        (i, r, a, o) => i.GetPensionRightInfoReport(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<UP7RequestType, UP7ResponseType> GetPensionTypeAndAmountReport(ServiceRequestData<UP7RequestType> argument)
        {
            return AdapterClient.Execute<IRPAdapter, UP7RequestType, UP7ResponseType>(
                        (i, r, a, o) => i.GetPensionTypeAndAmountReport(r, a, o),
                        argument);
        }
        public ServiceResultDataSigned<UP7NewRequestType, UP7NewResponseType> GetPensionTypeAndAmountReportUP7(ServiceRequestData<UP7NewRequestType> argument)
        {
            return AdapterClient.Execute<IRPAdapter, UP7NewRequestType, UP7NewResponseType>(
                        (i, r, a, o) => i.GetPensionTypeAndAmountReportUP7(r, a, o),
                        argument);
        }
        public ServiceResultDataSigned<UP8RequestType, UP8ResponseType> GetPensionIncomeAmountReport(ServiceRequestData<UP8RequestType> argument)
        {
            return AdapterClient.Execute<IRPAdapter, UP8RequestType, UP8ResponseType>(
                        (i, r, a, o) => i.GetPensionIncomeAmountReport(r, a, o),
                        argument);
        }
    }
}
