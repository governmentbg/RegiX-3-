using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PDVOAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистъра на признатите дипломи за придобито висше образование в чужбина, поддържан в НАЦИД")]
    public interface IPDVOAPI : IAPIService
    {
        //Справка за академично признаване на придобито висше образование в чужбина
        [OperationContract]
        [Description("Справка за академично признаване на придобито висше образование в чужбина")]
        [Info(requestXSD: "AcademicRecognitionRequest.xsd",
            responseXSD: "AcademicRecognitionResponse.xsd",
            requestXSLT: "AcademicRecognitionRequest.xslt",
            responseXSLT: "AcademicRecognitionResponse.xslt")]
        ServiceResultDataSigned<AcademicRecognitionRequestType, AcademicRecognitionResponseType> GetAcademicRecognition(ServiceRequestData<AcademicRecognitionRequestType> argument);
    }
}
