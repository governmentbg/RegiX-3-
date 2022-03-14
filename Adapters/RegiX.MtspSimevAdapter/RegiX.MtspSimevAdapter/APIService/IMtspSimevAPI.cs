using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MtspSimevAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация със СИМЕВ - Специализиран информационен модул за електронизиране на верификацията")]
    public interface IMtspSimevAPI : IAPIService
    {
        [OperationContract]
        [Description("Изпълнява услуга за изпращане на данни към СИМЕВ на МТСП за физически лица(родител/дете) относно наличие на вписване в Регистъра на приемните семейства, Регистъра на децата в риск, регистрирано решение на ТЕЛК и данни за участие в проект за период")]
        ServiceResultDataSigned<MtspInfoFosterParentsRequest, MtspInfoFosterParentsResponse> SendInfoForFosterParents(ServiceRequestData<MtspInfoFosterParentsRequest> argument);
    }
}
