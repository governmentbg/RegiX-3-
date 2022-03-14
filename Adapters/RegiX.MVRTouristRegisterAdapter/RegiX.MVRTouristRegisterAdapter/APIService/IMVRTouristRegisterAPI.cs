using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MVRTouristRegisterAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за получаване на данни за туристическа регистрация към Министерство на вътрешните работи")]
    public interface IMVRTouristRegisterAPI : IAPIService
    {
        [OperationContract]
        [Description("Изпълнява услуга за Подаване на данни към МВР за места за настаняване и икономически оператори от ЕСТИ")]
        [Info(requestXSD: "MvrAccomodationPlaceRequest.xsd",
            responseXSD: "MvrAccomodationPlaceResponse.xsd")]
        ServiceResultDataSigned<MvrAccomodationPlaceRequestType, MvrAccomodationPlaceResponseType> SendInfoForEstiAccomodationPlace(ServiceRequestData<MvrAccomodationPlaceRequestType> argument);

        [OperationContract]
        [Description("Изпълнява услуга за подаване на данни към МВР за туристическа регистрация")]
        [Info(requestXSD: "TouristRegisterRequest.xsd",
            responseXSD: "TouristRegisterResponse.xsd")]
        ServiceResultDataSigned<TouristRegisterRequestType, TouristRegisterResponseType> SendInfoForTouristRegister(ServiceRequestData<TouristRegisterRequestType> argument);
    }
}
