using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvUmAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.PvUmAdapter.APIService
{
    [ExportFullName(typeof(IPvUmAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PvUmAPI : BaseAPIService<IPvUmAPI>, IPvUmAPI
    {
        public ServiceResultDataSigned<getUtilityModelByAppNumType, PatentDetailsType> GetREG_UM_App_Number(ServiceRequestData<getUtilityModelByAppNumType> argument)
        {
            return  AdapterClient.Execute<IPvUmAdapter, getUtilityModelByAppNumType, PatentDetailsType>(
                (i, r, a, o) => i.GetREG_UM_App_Number(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getUtilityModelByNameType, PatentDetailsType> GetREG_UM_Name(ServiceRequestData<getUtilityModelByNameType> argument)
        {
            return AdapterClient.Execute<IPvUmAdapter, getUtilityModelByNameType, PatentDetailsType>(
                (i, r, a, o) => i.GetREG_UM_Name(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getUtilityModelByOwnersNameType, PatentDetailsType> GetREG_UM_Owner_Name(ServiceRequestData<getUtilityModelByOwnersNameType> argument)
        {
            return AdapterClient.Execute<IPvUmAdapter, getUtilityModelByOwnersNameType, PatentDetailsType>(
                (i, r, a, o) => i.GetREG_UM_Owner_Name(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getUtilityModelByRegNumType, PatentDetailsType> GetREG_UM_Reg_Number(ServiceRequestData<getUtilityModelByRegNumType> argument)
        {
            return AdapterClient.Execute<IPvUmAdapter, getUtilityModelByRegNumType, PatentDetailsType>(
                (i, r, a, o) => i.GetREG_UM_Reg_Number(r, a, o),
                 argument);
        }         

    }
}
