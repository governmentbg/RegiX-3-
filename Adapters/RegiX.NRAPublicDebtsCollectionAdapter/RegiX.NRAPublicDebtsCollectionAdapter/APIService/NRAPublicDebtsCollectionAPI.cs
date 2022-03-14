using TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.APIService
{
    [ExportFullName(typeof(INRAPublicDebtsCollectionAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NRAPublicDebtsCollectionAPI : BaseAPIService<INRAPublicDebtsCollectionAPI>, INRAPublicDebtsCollectionAPI
    {
        //RQ01
        public ServiceResultDataSigned<SendDataForNewIOAndCollectionRequestType, SendDataForNewIOAndCollectionResponseType> SendDataForNewIOAndCollection(ServiceRequestData<SendDataForNewIOAndCollectionRequestType> argument)
        {
            return AdapterClient.Execute<INRAPublicDebtsCollectionAdapter, SendDataForNewIOAndCollectionRequestType, SendDataForNewIOAndCollectionResponseType>(
                                    (i, r, a, o) => i.SendDataForNewIOAndCollection(r, a, o), 
                                    argument);
        }

        //RQ02
        public ServiceResultDataSigned<SendDataForCollectionAdditionToIORequestType, SendDataForCollectionAdditionToIOResponseType> SendDataForCollectionAdditionToIO(ServiceRequestData<SendDataForCollectionAdditionToIORequestType> argument)
        {
            return AdapterClient.Execute<INRAPublicDebtsCollectionAdapter, SendDataForCollectionAdditionToIORequestType, SendDataForCollectionAdditionToIOResponseType>(
                                    (i, r, a, o) => i.SendDataForCollectionAdditionToIO(r, a, o),
                                    argument);
        }

        //RQ03
         public ServiceResultDataSigned<SendDataForCollectionDataCorrectionRequestType, SendDataForCollectionDataCorrectionResponseType> SendDataForCollectionDataCorrection(ServiceRequestData<SendDataForCollectionDataCorrectionRequestType> argument)
        {
            return AdapterClient.Execute<INRAPublicDebtsCollectionAdapter, SendDataForCollectionDataCorrectionRequestType, SendDataForCollectionDataCorrectionResponseType>(
                                    (i, r, a, o) => i.SendDataForCollectionDataCorrection(r, a, o),
                                    argument);
        }

        //RQ04
        public ServiceResultDataSigned<SendDataForCollectionAppealToIORequestType, SendDataForCollectionAppealToIOResponseType> SendDataForCollectionAppealToIO(ServiceRequestData<SendDataForCollectionAppealToIORequestType> argument)
        {
            return AdapterClient.Execute<INRAPublicDebtsCollectionAdapter, SendDataForCollectionAppealToIORequestType, SendDataForCollectionAppealToIOResponseType>(
                                    (i, r, a, o) => i.SendDataForCollectionAppealToIO(r, a, o),
                                    argument);
        }

        //RQ05
        public ServiceResultDataSigned<SendDataForCollectedAmountUpdateRequestType, SendDataForCollectedAmountUpdateResponseType> SendDataForCollectedAmountUpdate(ServiceRequestData<SendDataForCollectedAmountUpdateRequestType> argument)
        {
            return AdapterClient.Execute<INRAPublicDebtsCollectionAdapter, SendDataForCollectedAmountUpdateRequestType, SendDataForCollectedAmountUpdateResponseType>(
                                    (i, r, a, o) => i.SendDataForCollectedAmountUpdate(r, a, o),
                                    argument);
        }

        //RQ06
        public ServiceResultDataSigned<SendDataForCollectionProceedingsTerminationRequestType, SendDataForCollectionProceedingsTerminationResponseType> SendDataForCollectionProceedingsTermination(ServiceRequestData<SendDataForCollectionProceedingsTerminationRequestType> argument)
        {
            return AdapterClient.Execute<INRAPublicDebtsCollectionAdapter, SendDataForCollectionProceedingsTerminationRequestType, SendDataForCollectionProceedingsTerminationResponseType>(
                                    (i, r, a, o) => i.SendDataForCollectionProceedingsTermination(r, a, o),
                                    argument);
        }

        //RQ09
        public ServiceResultDataSigned<GetActualStateForIOOrCollectionRequestType, GetActualStateForIOOrCollectionResponseType> GetActualStateForIOOrCollection(ServiceRequestData<GetActualStateForIOOrCollectionRequestType> argument)
        {
            return AdapterClient.Execute<INRAPublicDebtsCollectionAdapter, GetActualStateForIOOrCollectionRequestType, GetActualStateForIOOrCollectionResponseType>(
                                    (i, r, a, o) => i.GetActualStateForIOOrCollection(r, a, o),
                                    argument);
        }
    }
}
