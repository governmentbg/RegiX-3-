using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MtEstiAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Министерство на туризма - Единна система за туристическа информация")]
    public interface IMtEstiAPI : IAPIService
    {
        [OperationContract]
        [Description("Подаване на данни към ЕСТИ за места за настаняване и икономически оператори от Национален туристически регистър")]
        [Info(
            requestXSD: "AccomodationPlaceRequest.xsd",
            responseXSD: "AccomodationPlaceResponse.xsd")]
        ServiceResultDataSigned<AccomodationPlaceRequestType, AccomodationPlaceResponseType> SendInfoForAccomodationPlace(ServiceRequestData<AccomodationPlaceRequestType> argument);
        
        [OperationContract]
        [Description("Подаване на данни към ЕСТИ от местата за настаняване")]
        [Info(
            requestXSD: "AccomodationRegisterRequest.xsd",
            responseXSD: "AccomodationRegisterResponse.xsd")]
        ServiceResultDataSigned<AccRegister.AccomodationRegisterRequestType, AccRegister.AccomodationRegisterResponseType> SendInfoForAccomodationRegister(ServiceRequestData<AccRegister.AccomodationRegisterRequestType> argument);
    }
}
