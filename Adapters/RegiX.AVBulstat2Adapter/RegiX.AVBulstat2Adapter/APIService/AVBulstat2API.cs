using TechnoLogica.RegiX.AVBulstat2Adapter.AdapterService;
using TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;
using AdapterServiceReference = TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.AVBulstat2Adapter.APIService
{
    [ExportFullName(typeof(IAVBulstat2API), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class AVBulstat2API : BaseAPIService<IAVBulstat2API>, IAVBulstat2API
    {
        public ServiceResultDataSigned<AdapterServiceReference.GetStateOfPlayRequest, AdapterServiceReference.StateOfPlay> GetStateOfPlay(ServiceRequestData<GetStateOfPlayRequest> argument)
        {
            return AdapterClient.Execute<IAVBulstat2Adapter, AdapterServiceReference.GetStateOfPlayRequest, AdapterServiceReference.StateOfPlay>(
                (i, r, a, o) => i.GetStateOfPlay(r, a, o),
                argument);
        }        

        public ServiceResultDataSigned<XMLSchemas.FetchNomenclatures, Nomenclatures> FetchNomenclatures(ServiceRequestData<XMLSchemas.FetchNomenclatures> argument)
        {
            return AdapterClient.Execute<IAVBulstat2Adapter, XMLSchemas.FetchNomenclatures, Nomenclatures>(
                (i, r, a, o) => i.FetchNomenclatures(r, a, o),
                argument);
        }

        public ServiceResultDataSigned<XMLSchemas.GetActualUICInfoRequestType, XMLSchemas.GetActualUICInfoResponseType> GetActualUICInfo(ServiceRequestData<XMLSchemas.GetActualUICInfoRequestType> argument)
        {
            return AdapterClient.Execute<IAVBulstat2Adapter, XMLSchemas.GetActualUICInfoRequestType, XMLSchemas.GetActualUICInfoResponseType>(
                (i, r, a, o) => i.GetActualUICInfo(r, a, o),
                argument);
        }
    }
}
