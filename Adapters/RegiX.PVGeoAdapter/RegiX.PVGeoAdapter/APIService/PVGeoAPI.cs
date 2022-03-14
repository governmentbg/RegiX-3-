using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PVGeoAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.PVGeoAdapter.APIService
{
    [ExportFullName(typeof(IPVGeoAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PVGeoAPI : BaseAPIService<IPVGeoAPI>, IPVGeoAPI
    {
        public ServiceResultDataSigned<GetGIByAppNumType, GIDetailsType> GetREG_GEO_App_Num(ServiceRequestData<GetGIByAppNumType> argument)
        {
            return  AdapterClient.Execute<IPVGeoAdapter, GetGIByAppNumType, GIDetailsType>(
                (i, r, a, o) => i.GetREG_GEO_App_Num(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetGIByNameType, GIDetailsType> GetREG_GEO_GI_Name(ServiceRequestData<GetGIByNameType> argument)
        {
            return  AdapterClient.Execute<IPVGeoAdapter, GetGIByNameType, GIDetailsType>(
                (i, r, a, o) => i.GetREG_GEO_GI_Name(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetGIByUserNameType, GIDetailsType> GetREG_GEO_GI_User(ServiceRequestData<GetGIByUserNameType> argument)
        {
            return  AdapterClient.Execute<IPVGeoAdapter, GetGIByUserNameType, GIDetailsType>(
                (i, r, a, o) => i.GetREG_GEO_GI_User(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetGIByRegNumType, GIDetailsType> GetREG_GEO_Reg_Num(ServiceRequestData<GetGIByRegNumType> argument)
        {
            return AdapterClient.Execute<IPVGeoAdapter, GetGIByRegNumType, GIDetailsType>(
                (i, r, a, o) => i.GetREG_GEO_Reg_Num(r, a, o),
                 argument);
        }

        //public ServiceResultData<GIDetailsType> GetREG_GEO_Stat_App_Date(ServiceRequestData<GIDetailsType> argument)
        //{
        //    return  AdapterClient.Execute<IPVGeoAdapter, GIDetailsType, GIDetailsType>(
        //        (i, r, a, o) => i.GetREG_GEO_Stat_App_Date(r, a),
        //         argument);
        //}
    }
}
