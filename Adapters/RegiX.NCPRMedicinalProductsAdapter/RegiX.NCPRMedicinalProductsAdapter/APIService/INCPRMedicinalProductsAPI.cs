using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с регистрите на НЦСРЛП")]
    public interface INCPRMedicinalProductsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за Търсене на лекарствени продукти в регистрите")]
        [Info(requestXSD: "ListMedicinalProductsRequest.xsd",
          responseXSD: "ListMedicinalProductsResponse.xsd",
          commonXSD:"NCPRCommon.xsd",
          requestXSLT: "MedProductsRequest.xslt",
          responseXSLT: "MedProductsResponse.xslt"
           )]
        ServiceResultDataSigned<ListMedicinalProductsRequestType, ListMedicinalProductsResponseType> ListMedicinalProducts(ServiceRequestData<ListMedicinalProductsRequestType> argument);

        [OperationContract]
        [Description("Справка за Търсене на заличени лекарствени продукти в регистрите")]
        [Info(requestXSD: "ListDeletedMedicinalProductsRequest.xsd",
         responseXSD: "ListDeletedMedicinalProductsResponse.xsd",
         commonXSD: "NCPRCommon.xsd",
         requestXSLT: "DeletedMedProductsRequest.xslt",
         responseXSLT: "DeletedMedProductsResponse.xslt"
         )]
        ServiceResultDataSigned<ListDeletedMedicinalProductsRequestType, ListDeletedMedicinalProductsResponseType> ListDeletedMedicinalProducts(ServiceRequestData<ListDeletedMedicinalProductsRequestType> argument);

        [OperationContract]
        [Description("Справка за Извличане на детайли за лекарствен продукт в конкретен регистър")]
        [Info(requestXSD: "GetRegisterMedicinalProductDataRequest.xsd",
        responseXSD: "GetRegisterMedicinalProductDataResponse.xsd",
        commonXSD: "NCPRCommon.xsd",
        requestXSLT: "RegMedProductDataRequest.xslt",
        responseXSLT: "RegMedProductDataResponse.xslt"
        )]
        ServiceResultDataSigned<GetRegisterMedicinalProductDataRequestType, GetRegisterMedicinalProductDataResponseType> GetRegisterMedicinalProductData(ServiceRequestData<GetRegisterMedicinalProductDataRequestType> argument);

        [OperationContract]
        [Description("Справка за Извличане на пълната информация за лекарствен продукт")]
        [Info(requestXSD: "GetMedicinalProductDataRequest.xsd",
        responseXSD: "GetMedicinalProductDataResponse.xsd",
        commonXSD: "NCPRCommon.xsd",
        requestXSLT: "MedProductDataRequest.xslt",
        responseXSLT: "MedProductDataRеsponse.xslt"
        )]
        ServiceResultDataSigned<GetMedinicalProductDataRequestType, GetMedicinalProductDataResponseType> GetMedicinalProductData(ServiceRequestData<GetMedinicalProductDataRequestType> argument);

    }
}
