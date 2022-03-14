using TechnoLogica.RegiX.MFANotariesAdapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;


namespace TechnoLogica.RegiX.MFANotariesAdapter.APIService
{
    [ExportFullName(typeof(IMFANotariesAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MFANotariesAPI: BaseAPIService<IMFANotariesAPI>, IMFANotariesAPI
    {

        public ServiceResultDataSigned<SendNotaryDocumentsRequest, SendNotaryDocumentsResponse> SendNotaryDocuments(ServiceRequestData<SendNotaryDocumentsRequest> argument)
        {
            return AdapterClient.Execute<IMFANotariesAdapter, SendNotaryDocumentsRequest, SendNotaryDocumentsResponse>(
                (i, r, a, o) => i.SendNotaryDocuments(r, a, o),
                 argument);
        }
    }
}
