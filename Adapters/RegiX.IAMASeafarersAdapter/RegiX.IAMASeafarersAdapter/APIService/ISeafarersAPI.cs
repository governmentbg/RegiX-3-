using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IAMASeafarersAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистъра на морските лица в ИАМА")]
    public interface ISeafarersAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за свидетелства за правоспособност на морските лица")]
        [Info(
            requestXSD: "IAMASeafarersLicensesRequest.xsd",
            responseXSD: "IAMASeafarersLicensesResponse.xsd",
            requestXSLT: "IAMASeafarersLicensesRequest.xslt",
            responseXSLT: "IAMASeafarersLicensesResponse.xslt")]
        ServiceResultDataSigned<SeafarersLicensesRequestType, SeafarersLicensesResponseType> SeafarersLicensesSearch(ServiceRequestData<SeafarersLicensesRequestType> argument);
    }
}
