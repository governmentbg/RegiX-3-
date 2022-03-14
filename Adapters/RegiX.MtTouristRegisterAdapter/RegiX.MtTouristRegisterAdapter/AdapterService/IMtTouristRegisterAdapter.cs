using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Министерство на туризма - Национален туристически регистър")]
    public interface IMtTouristRegisterAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за категоризация на заведения за хранене и развлечение")]
        CommonSignedResponse<BarRestaurantCategoryByEIKRequestType, TouristEntertainmentObjectArray> GetTotaRegBarRestaurantCategoryByEIK(BarRestaurantCategoryByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за категоризация на обекти")]
        CommonSignedResponse<ObjectCategoryByEIKRequestType, TouristObjectArray> GetTotaRegCategoryByEIK(ObjectCategoryByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за сключена застраховка за туроператор")]
        CommonSignedResponse<TOInsuranceByEIKRequestType, InsuranceArray> GetTotaRegToInsuranceByEIK(TOInsuranceByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за регистрация на туроператор/туристически агент")]
        CommonSignedResponse<TOTAByEIKRequestType, Tota> GetTotaRegTotaByEIK(TOTAByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

