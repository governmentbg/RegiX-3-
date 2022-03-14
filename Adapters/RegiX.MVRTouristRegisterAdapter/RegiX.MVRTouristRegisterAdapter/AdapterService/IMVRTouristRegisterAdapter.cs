using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MVRTouristRegisterAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за получаване на данни за туристическа регистрация към Министерство на вътрешните работи")]
    public interface IMVRTouristRegisterAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Подаване на данни към МВР за места за настаняване и икономически оператори от ЕСТИ")]
        CommonSignedResponse<MvrAccomodationPlaceRequestType, MvrAccomodationPlaceResponseType> SendInfoForEstiAccomodationPlace(MvrAccomodationPlaceRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Подаване на данни към МВР за туристическа регистрация")]
        CommonSignedResponse<TouristRegisterRequestType, TouristRegisterResponseType> SendInfoForTouristRegister(TouristRegisterRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
