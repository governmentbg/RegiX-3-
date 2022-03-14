using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MVRANDAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRANDAdapter.APIService
{
    [ExportFullName(typeof(IMVRANDAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MVRANDAPI : BaseAPIService<IMVRANDAPI>, IMVRANDAPI
    {
        public ServiceResultDataSigned<ObligationDocumentsRequestType, ObligationDocumentsResponseType> GetObligationDocuments(ServiceRequestData<ObligationDocumentsRequestType> argument)
        {
            return AdapterClient.Execute<IMVRANDAdapter, ObligationDocumentsRequestType, ObligationDocumentsResponseType>(
                        (i, r, a, o) => i.GetObligationDocuments(r, a, o),
                        argument);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------
       
        public ServiceResultDataSigned<SendPaymentNotificationRequestType, SendPaymentNotificationResponseType> SendPaymentNotification(ServiceRequestData<SendPaymentNotificationRequestType> argument)
        {
            return AdapterClient.Execute<IMVRANDAdapter, SendPaymentNotificationRequestType, SendPaymentNotificationResponseType>(
                        (i, r, a, o) => i.SendPaymentNotification(r, a, o),
                        argument);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        public ServiceResultDataSigned<GetObligationDocumentsByEGNRequestType, GetObligationDocumentsByEGNResponseType> GetObligationDocumentsByEGN(ServiceRequestData<GetObligationDocumentsByEGNRequestType> argument)
        {
            return AdapterClient.Execute<IMVRANDAdapter, GetObligationDocumentsByEGNRequestType, GetObligationDocumentsByEGNResponseType>(
                        (i, r, a, o) => i.GetObligationDocumentsByEGN(r, a, o),
                        argument);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------
  
        public ServiceResultDataSigned<GetObligationDocumentsByLicenceNumRequestType, GetObligationDocumentsByLicenceNumResponseType> GetObligationDocumentsByLicenceNum(ServiceRequestData<GetObligationDocumentsByLicenceNumRequestType> argument)
        {
            return AdapterClient.Execute<IMVRANDAdapter, GetObligationDocumentsByLicenceNumRequestType, GetObligationDocumentsByLicenceNumResponseType>(
                        (i, r, a, o) => i.GetObligationDocumentsByLicenceNum(r, a, o),
                        argument);
        }
    }
}
