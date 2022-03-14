using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvSpcAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.PvSpcAdapter.APIService
{
    [ExportFullName(typeof(IPvSpcAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PvSpcAPI : BaseAPIService<IPvSpcAPI>, IPvSpcAPI
    {
        public ServiceResultDataSigned<getSPCByPatentAppNumType, SPCDetailsType> GetREG_SPC_App_Number(ServiceRequestData<getSPCByPatentAppNumType> argument)
        {
            return  AdapterClient.Execute<IPvSpcAdapter, getSPCByPatentAppNumType, SPCDetailsType>(
                (i, r, a, o) => i.GetREG_SPC_App_Number(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getSPCByOwnersNameType, SPCDetailsType> GetREG_SPC_Owner(ServiceRequestData<getSPCByOwnersNameType> argument)
        {
            return AdapterClient.Execute<IPvSpcAdapter, getSPCByOwnersNameType, SPCDetailsType>(
                (i, r, a, o) => i.GetREG_SPC_Owner(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getSPCByAppNumType, SPCDetailsType> GetREG_SPC_Reg_Number(ServiceRequestData<getSPCByAppNumType> argument)
        {
            return  AdapterClient.Execute<IPvSpcAdapter, getSPCByAppNumType, SPCDetailsType>(
                (i, r, a, o) => i.GetREG_SPC_Reg_Number(r, a, o),
                 argument);
        }

        //public ServiceResultData<SPCDetailsType> GetREG_SPC_Stat_App_Date(ServiceRequestData<SPCDetailsType> argument)
        //{
        //    return  AdapterClient.Execute<IPvSpcAdapter, SPCDetailsType, SPCDetailsType>(
        //        (i, r, a, o) => i.GetREG_SPC_Stat_App_Date(r, a),
        //         argument);
        //}
    }
}
