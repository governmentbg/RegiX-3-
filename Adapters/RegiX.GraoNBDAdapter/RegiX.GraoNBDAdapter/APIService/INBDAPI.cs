using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.GraoNBDAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Национална база данни (НБД) Население")]
    public interface INBDAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за валидност на физическо лице")]
        [Info(requestXSD: "ValidPersonRequest.xsd",
            responseXSD: "ValidPersonResponse.xsd", 
            commonXSD: "NBDCommon.xsd",
            requestXSLT: "ValidPersonRequest.xslt",
            responseXSLT: "ValidPersonResponse.xslt")]
        ServiceResultDataSigned<ValidPersonRequestType, ValidPersonResponseType> ValidPersonSearch(ServiceRequestData<ValidPersonRequestType> argument);

        [OperationContract]
        [Description("Справка за родственост")]
        [Info(requestXSD: "RelationsRequest.xsd",
            responseXSD: "RelationsResponse.xsd",
            commonXSD: "NBDCommon.xsd",
            requestXSLT: "RelationsRequest.xslt",
            responseXSLT: "RelationsResponse.xslt")]
        ServiceResultDataSigned<RelationsRequestType, RelationsResponseType> RelationsSearch(ServiceRequestData<RelationsRequestType> argument);

        [OperationContract]
        [Description("Справка за физическо лице")]
        [Info(requestXSD: "PersonDataRequest.xsd",
            responseXSD: "PersonDataResponse.xsd",
            commonXSD: "NBDCommon.xsd",
            requestXSLT: "PersonDataRequest.xslt",
            responseXSLT: "PersonDataResponse.xslt")]
        ServiceResultDataSigned<PersonDataRequestType, PersonDataResponseType> PersonDataSearch(ServiceRequestData<PersonDataRequestType> argument);
    }
}
