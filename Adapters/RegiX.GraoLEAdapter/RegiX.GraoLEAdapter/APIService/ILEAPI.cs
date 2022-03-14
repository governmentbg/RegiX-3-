using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.GraoLEAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Класификатор на локализационните единици ")]
    public interface ILEAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за локализационни единици")]
        [Info(requestXSD: "LocationsRequest.xsd",
            responseXSD: "LocationsResponse.xsd",
            commonXSD: "LECommon.xsd",
            requestXSLT: "LocationsRequest.xslt",
            responseXSLT: "LocationsResponse.xslt")]
        ServiceResultDataSigned<LocationsRequestType, LocationsResponseType> LocationsSearch(ServiceRequestData<LocationsRequestType> argument);
    }
}
