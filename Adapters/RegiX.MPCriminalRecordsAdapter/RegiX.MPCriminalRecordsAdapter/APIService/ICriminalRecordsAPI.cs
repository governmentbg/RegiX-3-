using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.MPCriminalRecordsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация със регистъра за съдимост ")]
    public interface ICriminalRecordsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за свидетелство за съдимост")]
        [Info(requestXSD: "BulletinSearchRequest.xsd", responseXSD: "BulletinSearchResponse.xsd")]
        ServiceResultDataSigned<BulletinSearchRequestType, BulletinSearchResponseType> BulletinSearch(ServiceRequestData<BulletinSearchRequestType> argument);
    }
}
