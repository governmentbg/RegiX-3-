using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MZHAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с регистъра на земеделските производители")]
    public interface IMZHAPI : IAPIService
    {
        //Справка за земеделски производител
        [OperationContract]
        [Description("Справка за земеделски производител")]
        [Info(
            requestXSD: "FarmerSearchRequest.xsd",
            responseXSD: "FarmerSearchResponse.xsd",
            commonXSD: "MZHCommon.xsd",
            requestXSLT: "FarmerSearchRequest.xslt",
            responseXSLT: "")]
        ServiceResultDataSigned<FarmerSearchParametersType, FarmerType> FarmerDetailsSearch(ServiceRequestData<FarmerSearchParametersType> argument);
    }
}
