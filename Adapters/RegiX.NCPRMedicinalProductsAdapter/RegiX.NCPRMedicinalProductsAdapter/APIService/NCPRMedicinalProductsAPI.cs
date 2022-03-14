using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService;

namespace TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.APIService
{
    [Export(typeof(IAPIService))]
    [ExportFullName(typeof(INCPRMedicinalProductsAPI), typeof(IAPIService))]
    public class NCPRMedicinalProductsAPI : BaseAPIService<INCPRMedicinalProductsAPI>, INCPRMedicinalProductsAPI
    {
        public ServiceResultDataSigned<GetMedinicalProductDataRequestType, GetMedicinalProductDataResponseType> GetMedicinalProductData(ServiceRequestData<GetMedinicalProductDataRequestType> argument)
        {
            return AdapterClient.Execute<INCPRMedicinalProductsAdapter, GetMedinicalProductDataRequestType, GetMedicinalProductDataResponseType>(
                       (i, r, a, o) => i.GetMedicinalProductData(r, a, o),
                       argument);
        }

        public ServiceResultDataSigned<GetRegisterMedicinalProductDataRequestType, GetRegisterMedicinalProductDataResponseType> GetRegisterMedicinalProductData(ServiceRequestData<GetRegisterMedicinalProductDataRequestType> argument)
        {
            return AdapterClient.Execute<INCPRMedicinalProductsAdapter, GetRegisterMedicinalProductDataRequestType, GetRegisterMedicinalProductDataResponseType>(
                       (i, r, a, o) => i.GetRegisterMedicinalProductData(r, a, o),
                       argument);
        }

        public ServiceResultDataSigned<ListDeletedMedicinalProductsRequestType, ListDeletedMedicinalProductsResponseType> ListDeletedMedicinalProducts(ServiceRequestData<ListDeletedMedicinalProductsRequestType> argument)
        {
            return AdapterClient.Execute<INCPRMedicinalProductsAdapter, ListDeletedMedicinalProductsRequestType, ListDeletedMedicinalProductsResponseType>(
                       (i, r, a, o) => i.ListDeletedMedicinalProducts(r, a, o),
                       argument);
        }

        public ServiceResultDataSigned<ListMedicinalProductsRequestType, ListMedicinalProductsResponseType> ListMedicinalProducts(ServiceRequestData<ListMedicinalProductsRequestType> argument)
        {
            return AdapterClient.Execute<INCPRMedicinalProductsAdapter, ListMedicinalProductsRequestType, ListMedicinalProductsResponseType>(
                       (i, r, a, o) => i.ListMedicinalProducts(r, a, o),
                       argument);
        }
    }
}
