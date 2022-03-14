using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за достъп до регистрите на НЦСРЛП")]
    public interface INCPRMedicinalProductsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за Търсене на лекарствени продукти в регистрите")]
        CommonSignedResponse<ListMedicinalProductsRequestType, ListMedicinalProductsResponseType> ListMedicinalProducts(ListMedicinalProductsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за Търсене на заличени лекарствени продукти в регистрите")]
        CommonSignedResponse<ListDeletedMedicinalProductsRequestType, ListDeletedMedicinalProductsResponseType> ListDeletedMedicinalProducts(ListDeletedMedicinalProductsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);


        [OperationContract]
        [Description("Справка за Извличане на детайли за лекарствен продукт в конкретен регистър")]
        CommonSignedResponse<GetRegisterMedicinalProductDataRequestType, GetRegisterMedicinalProductDataResponseType> GetRegisterMedicinalProductData(GetRegisterMedicinalProductDataRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за Извличане на пълната информация за лекарствен продукт")]
        CommonSignedResponse<GetMedinicalProductDataRequestType, GetMedicinalProductDataResponseType> GetMedicinalProductData(GetMedinicalProductDataRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

    }
}
