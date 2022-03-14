using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MtspSimevAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация със СИМЕВ - Специализиран информационен модул за електронизиране на верификацията")]
    public interface IMtspSimevAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Изпращане на данни към СИМЕВ на МТСП за физически лица(родител/дете) относно наличие на вписване в Регистъра на приемните семейства, Регистъра на децата в риск, регистрирано решение на ТЕЛК и данни за участие в проект за период")]
        [Info(requestXSD: "SendInfoForFosterParentsRequest.xsd", responseXSD: "SendInfoForFosterParentsResponse.xsd")]
        CommonSignedResponse<MtspInfoFosterParentsRequest, MtspInfoFosterParentsResponse> SendInfoForFosterParents(MtspInfoFosterParentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
