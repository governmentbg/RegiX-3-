using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.REZMAAdapter.AdapterService;

namespace TechnoLogica.RegiX.REZMAAdapter.APIService
{
    [ExportFullName(typeof(IREZMAAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class REZMAAPI: BaseAPIService<IREZMAAPI>, IREZMAAPI
    {
        //CustomsObligations
        public ServiceResultDataSigned<CustomsObligationsRequestType, CustomsObligationsResponseType> GetCustomsObligations(ServiceRequestData<CustomsObligationsRequestType> argument)
        {
            return  AdapterClient.Execute<IREZMAAdapter, CustomsObligationsRequestType, CustomsObligationsResponseType>(
                        (i, r, a, o) => i.GetCustomsObligations(r, a,o),
                        argument);
        }

        //ExciseObligations
        public ServiceResultDataSigned<ExciseObligationsRequestType, ExciseObligationsResponseType> GetExciseObligations(ServiceRequestData<ExciseObligationsRequestType> argument)
        {
            return AdapterClient.Execute<IREZMAAdapter, ExciseObligationsRequestType, ExciseObligationsResponseType>(
                        (i, r, a, o) => i.GetExciseObligations(r, a, o),
                        argument);
        }

        //CheckObligations
        public ServiceResultDataSigned<CheckObligationsRequestType, CheckObligationsResponseType> CheckObligations(ServiceRequestData<CheckObligationsRequestType> argument)
        {
            return AdapterClient.Execute<IREZMAAdapter, CheckObligationsRequestType, CheckObligationsResponseType>(
                        (i, r, a, o) => i.CheckObligations(r, a, o),
                        argument);
        }
    }
}
