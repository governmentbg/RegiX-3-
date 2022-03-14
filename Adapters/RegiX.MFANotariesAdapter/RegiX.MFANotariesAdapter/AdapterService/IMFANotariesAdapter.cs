using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MFANotariesAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Автоматизирана Информационна Система на МВнР")]
    public interface IMFANotariesAdapter: IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Удостоверяване на заверки")]
        CommonSignedResponse<SendNotaryDocumentsRequest, SendNotaryDocumentsResponse> SendNotaryDocuments(SendNotaryDocumentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
