using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.ChNTsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистър на разрешенията за извършване на дейност с нестопанска цел в Република България")]
    public interface IChNTsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за издадени/отказани разрешения за извършване на дейност с нестопанска цел в РБ")]
        [Info(
            requestXSD: "ForeignerPermissionsRequest.xsd",
            responseXSD: "ForeignerPermissionsResponse.xsd",
            sampleRequest: "GetForeignerPermissionsRequest.xml",
            sampleResponse: "GetForeignerPermissionsResponse.xml",
            requestXSLT: "ForeignerPermissionsRequest.xslt",
            responseXSLT: "ForeignerPermissionsResponse.xslt")]
        ServiceResultDataSigned<ForeignerPermissionsRequestType, ForeignerPermissionsResponseType> GetForeignerPermissions(ServiceRequestData<ForeignerPermissionsRequestType> argument);
    }
}
