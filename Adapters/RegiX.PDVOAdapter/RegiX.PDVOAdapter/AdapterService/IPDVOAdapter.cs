using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.PDVOAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистъра на признатите дипломи за придобито висше образование в чужбина, поддържан в НАЦИД")]
    public interface IPDVOAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Извлича справка за академично признаване на придобито висше образование в чужбина")]
        CommonSignedResponse<AcademicRecognitionRequestType, AcademicRecognitionResponseType> GetAcademicRecognition(AcademicRecognitionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}
