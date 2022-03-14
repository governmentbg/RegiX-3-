using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter;
using TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.AdapterService;

namespace RegiX.NRAPublicDebtsCollectionAdapter.Mocks
{
    public class NRAPublicDebtsCollectionAdapterMock : BaseAdapterServiceProxy<INRAPublicDebtsCollectionAdapter>
    {
        static NRAPublicDebtsCollectionAdapterMock()
        {
            RegisterResolver<SendDataForNewIOAndCollectionRequestType, SendDataForNewIOAndCollectionResponseType>(
               (i, r, a, o) => i.SendDataForNewIOAndCollection(r, a, o),
               (r) => $"{DataFolder}RQ01_SendDataForNewIOAndCollection.response.xml"
           );
            RegisterResolver<SendDataForCollectionAdditionToIORequestType, SendDataForCollectionAdditionToIOResponseType>(
               (i, r, a, o) => i.SendDataForCollectionAdditionToIO(r, a, o),
               (r) => $"{DataFolder}RQ02_SendDataForCollectionAdditionToIO.response.xml"
           );
            RegisterResolver<SendDataForCollectionDataCorrectionRequestType, SendDataForCollectionDataCorrectionResponseType>(
               (i, r, a, o) => i.SendDataForCollectionDataCorrection(r, a, o),
               (r) => $"{DataFolder}RQ03_SendDataForCollectionDataCorrection.response.xml"
           );
            RegisterResolver<SendDataForCollectionAppealToIORequestType, SendDataForCollectionAppealToIOResponseType>(
               (i, r, a, o) => i.SendDataForCollectionAppealToIO(r, a, o),
               (r) => $"{DataFolder}RQ04_SendDataForCollectionAppealToIO.response.xml"
           );
            RegisterResolver<SendDataForCollectedAmountUpdateRequestType, SendDataForCollectedAmountUpdateResponseType>(
               (i, r, a, o) => i.SendDataForCollectedAmountUpdate(r, a, o),
               (r) => $"{DataFolder}RQ05_SendDataForCollectedAmountUpdate.response.xml"
           );
            RegisterResolver<SendDataForCollectionProceedingsTerminationRequestType, SendDataForCollectionProceedingsTerminationResponseType>(
               (i, r, a, o) => i.SendDataForCollectionProceedingsTermination(r, a, o),
               (r) => $"{DataFolder}RQ06_SendDataForCollectionProceedings.response.xml"
           );
            RegisterResolver<GetActualStateForIOOrCollectionRequestType, GetActualStateForIOOrCollectionResponseType>(
               (i, r, a, o) => i.GetActualStateForIOOrCollection(r, a, o),
               (r) => $"{DataFolder}RQ09_GetActualStateForIOOrCollection.response.xml"
           );


        }
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NRAPublicDebtsCollectionAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NRAPublicDebtsCollectionAdapterMock), typeof(IAdapterService))]
        public static INRAPublicDebtsCollectionAdapter MockExport
        {
            get
            {
                return new NRAPublicDebtsCollectionAdapterMock().Create();
            }
        }
    }
}
