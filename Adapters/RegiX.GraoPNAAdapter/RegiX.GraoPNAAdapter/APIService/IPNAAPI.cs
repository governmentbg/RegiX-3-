using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.GraoPNAAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Класификатора на настоящите и постоянните адреси")]
    public interface IPNAAPI: IAPIService
    {
        //TODO: Replace string generic arguments
        [OperationContract]
        [Description("Справка за постоянен адрес")]
        [Info(
            requestXSD: "PermanentAddressRequest.xsd", 
            responseXSD: "PermanentAddressResponse.xsd", 
            commonXSD: "PNACommon.xsd",
            requestXSLT: "PermanentAddressRequest.xslt",
            responseXSLT: "PermanentAddressResponse.xslt")]
        ServiceResultDataSigned <PermanentAddressRequestType, PermanentAddressResponseType> PermanentAddressSearch(ServiceRequestData<PermanentAddressRequestType> argument);

        [OperationContract]
        [Description("Справка за настоящ адрес")]
        [Info(
            requestXSD: "TemporaryAddressRequest.xsd", 
            responseXSD: "TemporaryAddressResponse.xsd", 
            commonXSD: "PNACommon.xsd",
            requestXSLT: "TemporaryAddressRequest.xslt",
            responseXSLT: "TemporaryAddressResponse.xslt")]
        ServiceResultDataSigned<TemporaryAddressRequestType,TemporaryAddressResponseType> TemporaryAddressSearch(ServiceRequestData<TemporaryAddressRequestType> argument);
    }
}


