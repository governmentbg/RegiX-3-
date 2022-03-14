using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Министерство на туризма - Национален туристически регистър")]
    public interface IMtTouristRegisterAPI : IAPIService
    {  
        //Справка по ЕИК/БУЛСТАТ за категоризация на заведения за хранене и развлечение - справката връща списък със заведения за хранене и развлечение с тяхната категоризация
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за категоризация на заведения за хранене и развлечение - справката връща списък със заведения за хранене и развлечение с тяхната категоризация")]
        [Info(requestXSD: "TOTA_REG_BAR_RESTAURANT_CATEGORY_By_EIK_Request.xsd",
            responseXSD: "TOTA_REG_BAR_RESTAURANT_CATEGORY_By_EIK_Response.xsd",
            commonXSD: "CommonTypes.xsd",
            requestXSLT: "TOTA_REG_BAR_RESTAURANT_CATEGORY_By_EIK_Request.xslt",
            responseXSLT: "TOTA_REG_BAR_RESTAURANT_CATEGORY_By_EIK_Response.xslt")]
        ServiceResultDataSigned<BarRestaurantCategoryByEIKRequestType, TouristEntertainmentObjectArray> GetTotaRegBarRestaurantCategoryByEIK(ServiceRequestData<BarRestaurantCategoryByEIKRequestType> argument);

        //Справка по ЕИК/БУЛСТАТ за категоризация на обекти - справката връща списък с туристически обекти с тяхната категоризация;
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за категоризация на обекти - справката връща списък с туристически обекти с тяхната категоризация.")]
        [Info(requestXSD: "TOTA_REG_CATEGORY_By_EIK_Request.xsd",
            responseXSD: "TOTA_REG_CATEGORY_By_EIK_Response.xsd",
            commonXSD: "CommonTypes.xsd",
            requestXSLT: "TOTA_REG_CATEGORY_By_EIK_Request.xslt",
            responseXSLT: "TOTA_REG_CATEGORY_By_EIK_Response.xslt")]
        ServiceResultDataSigned<ObjectCategoryByEIKRequestType, TouristObjectArray> GetTotaRegCategoryByEIK(ServiceRequestData<ObjectCategoryByEIKRequestType> argument);

        //Справка по ЕИК/БУЛСТАТ за сключена застраховка за туроператор - справката връща списък с актуални (валидни) сключени застраховки;
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за сключена застраховка за туроператор - справката връща списък с актуални (валидни) сключени застраховки.")]
        [Info(requestXSD: "TOTA_REG_TO_INSURANCE_By_EIK_Request.xsd",
            responseXSD: "TOTA_REG_TO_INSURANCE_By_EIK_Response.xsd",
            commonXSD: "CommonTypes.xsd",
            requestXSLT: "TOTA_REG_TO_INSURANCE_By_EIK_Request.xslt",
            responseXSLT: "TOTA_REG_TO_INSURANCE_By_EIK_Response.xslt")]
        ServiceResultDataSigned<TOInsuranceByEIKRequestType, InsuranceArray> GetTotaRegToInsuranceByEIK(ServiceRequestData<TOInsuranceByEIKRequestType> argument);


        //Справка по ЕИК/БУЛСТАТ за регистрация на туроператор/туристически агент - справката връща списък с удостоверения за актуалната регистрация на лицето като туристически агент и/или туроператор;
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за регистрация на туроператор/туристически агент - справката връща списък с удостоверения за актуалната регистрация на лицето като туристически агент и/или туроператор.")]
        [Info(requestXSD: "TOTA_REG_TOTA_By_EIK_Request.xsd",
            responseXSD: "TOTA_REG_TOTA_By_EIK_Response.xsd",
            commonXSD: "CommonTypes.xsd",
            requestXSLT: "TOTA_REG_TOTA_By_EIK_Request.xslt",
            responseXSLT: "TOTA_REG_TOTA_By_EIK_Response.xslt")]
        ServiceResultDataSigned<TOTAByEIKRequestType, Tota> GetTotaRegTotaByEIK(ServiceRequestData<TOTAByEIKRequestType> argument);
    }
}
