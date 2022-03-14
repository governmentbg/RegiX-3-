using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.ASPFosterParentsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с АСП - Регистър на приемните семейства и Регистър на децата в риск")]
    public interface IASPFosterParentsAPI : IAPIService
    {
        [OperationContract]
        [Description("Изпълнява услуга за извличане на данни за физически лица(родител/дете) от ИИС на АСП относно наличие на вписване в Регистъра на приемните семейства, Регистъра на децата в риск, регистрирано решение на ТЕЛК и данни за участие в проект за период")]
        [Info(
            requestXSD: "SendRequestForFosterParentsRequest.xsd",
            responseXSD: "SendRequestForFosterParentsResponse.xsd",
            requestXSLT: "SendRequestForFosterParentsRequest.xslt",
            responseXSLT: "SendRequestForFosterParentsResponse.xslt")]
        ServiceResultDataSigned<AspFosterParentsRequest, AspFosterParentsResponse> SendRequestForFosterParents(ServiceRequestData<AspFosterParentsRequest> argument);
    }
}
