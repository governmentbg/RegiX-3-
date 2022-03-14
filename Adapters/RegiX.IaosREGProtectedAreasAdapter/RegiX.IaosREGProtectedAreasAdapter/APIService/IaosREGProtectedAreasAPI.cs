using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.APIService
{
    [ExportFullName(typeof(IIaosREGProtectedAreasAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosREGProtectedAreasAPI : BaseAPIService<IIaosREGProtectedAreasAPI>, IIaosREGProtectedAreasAPI
    {
        public ServiceResultDataSigned<REG_PAPZ_Protected_Area_Size_Request, REG_PAPZ_Protected_Area_Size_Response> GetREG_PAPZ_Protected_Area_Size(ServiceRequestData<REG_PAPZ_Protected_Area_Size_Request> argument)
        {
            return  AdapterClient.Execute<IIaosREGProtectedAreasAdapter, REG_PAPZ_Protected_Area_Size_Request, REG_PAPZ_Protected_Area_Size_Response>(
                (i, r, a, o) => i.GetREG_PAPZ_Protected_Area_Size(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<REG_PAPZ_Protected_Area_Category_Request, REG_PAPZ_Protected_Area_Category_Response> GetREG_PAPZ_Protected_Area_Category(ServiceRequestData<REG_PAPZ_Protected_Area_Category_Request> argument)
        {
            return  AdapterClient.Execute<IIaosREGProtectedAreasAdapter, REG_PAPZ_Protected_Area_Category_Request, REG_PAPZ_Protected_Area_Category_Response>(
                (i, r, a, o) => i.GetREG_PAPZ_Protected_Area_Category(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<REG_PAPZ_Protected_Area_Location_Request, REG_PAPZ_Protected_Area_Location_Response> GetREG_PAPZ_Protected_Area_Location(ServiceRequestData<REG_PAPZ_Protected_Area_Location_Request> argument)
        {
            return AdapterClient.Execute<IIaosREGProtectedAreasAdapter, REG_PAPZ_Protected_Area_Location_Request, REG_PAPZ_Protected_Area_Location_Response>(
                (i, r, a, o) => i.GetREG_PAPZ_Protected_Area_Location(r, a, o),
                 argument);
        }
    }
}
