using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NKPDAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common;

namespace TechnoLogica.RegiX.NKPDAdapter.APIService
{
    [ExportFullName(typeof(INKPDAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NKPDAPI: BaseAPIService<INKPDAPI>, INKPDAPI
    {
        // Справка за търсене на целия класификатор НКПД
        public ServiceResultDataSigned<AllNKPDDataSearchType, AllNKPDDataType> GetNKPDAllData(ServiceRequestData<AllNKPDDataSearchType> argument)
        {
            return  AdapterClient.Execute<INKPDAdapter, AllNKPDDataSearchType, AllNKPDDataType>(
                        (i, r, a, o) => i.GetNKPDAllData(r, a, o),
                        argument);
        }

        //Справка за търсене на данни от класификатор НКПД по зададени критерии
        public ServiceResultDataSigned<NKPDDataSearchType, NKPDDataType> GetNKPDData(ServiceRequestData<NKPDDataSearchType> argument)
        {
            return  AdapterClient.Execute<INKPDAdapter, NKPDDataSearchType, NKPDDataType>(
                        (i, r, a, o) => i.GetNKPDData(r, a, o),
                        argument);
        }
    }
}
