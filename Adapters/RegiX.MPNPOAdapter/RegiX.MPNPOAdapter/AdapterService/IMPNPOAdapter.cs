using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MPNPOAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с регистъра за вписани юридически лица с нестопанска цел")]
    public interface IMPNPOAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за вписано юридическо лице с нестопанска цел")]
        CommonSignedResponse<NPODetailsRequestType, NPODetailsResponseType> GetNPORegistrationInfo(NPODetailsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за статус на юридическо лице с нестопанска цел")]
        CommonSignedResponse<NPOStatusRequestType, NPOStatusResponseType> GetNPOStatusInfo(NPOStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
