using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.ASPFosterParentsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с АСП - Регистър на приемните семейства и Регистър на децата в риск")]
    public interface IASPFosterParentsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Заявка за извличане на данни за физически лица(родител/дете) от ИИС на АСП относно наличие на вписване в Регистъра на приемните семейства, Регистъра на децата в риск, регистрирано решение на ТЕЛК и данни за участие в проект за период")]
        CommonSignedResponse<AspFosterParentsRequest, AspFosterParentsResponse> SendRequestForFosterParents(AspFosterParentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
