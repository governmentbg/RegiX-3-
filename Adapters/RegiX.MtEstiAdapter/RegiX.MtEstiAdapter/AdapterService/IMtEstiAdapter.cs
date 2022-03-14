using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MtEstiAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Министерство на туризма - Единна система за туристическа информация")]
    public interface IMtEstiAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Подаване на данни към ЕСТИ за места за настаняване и икономически оператори от Национален туристически регистър")]
        CommonSignedResponse<AccomodationPlaceRequestType, AccomodationPlaceResponseType> SendInfoForAccomodationPlace(AccomodationPlaceRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Подаване на данни към ЕСТИ от местата за настаняване")]
        CommonSignedResponse<AccRegister.AccomodationRegisterRequestType, AccRegister.AccomodationRegisterResponseType> SendInfoForAccomodationRegister(AccRegister.AccomodationRegisterRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
