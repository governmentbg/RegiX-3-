using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.DaeuReportsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("Регистър на извършваните операции в средата за междурегистров обмен - RegiX")]
    public interface IDaeuReportsAPI : IAPIService
    {
        [OperationContract]
        [Description("Персонална справка на физическо лице за достъп до лични данни по идентификатор и период")]
        ServiceResultDataSigned<SearchByIdentifierRequestType, SearchByIdentifierResponse> SearchByIdentifier(ServiceRequestData<SearchByIdentifierRequestType> argument);
    }
}
