using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvDesignAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.PvDesignAdapter.APIService
{
    [ExportFullName(typeof(IPvDesignAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PvDesignAPI : BaseAPIService<IPvDesignAPI>, IPvDesignAPI
    {
        public ServiceResultDataSigned<GetDesignByAppNumType, DesignDetailsType> GetREG_DESIGN_App_Number(ServiceRequestData<GetDesignByAppNumType> argument)
        {
            return  AdapterClient.Execute<IPvDesignAdapter, GetDesignByAppNumType, DesignDetailsType>(
                (i, r, a, o) => i.GetREG_DESIGN_App_Number(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetDesignsByNameType, DesignDetailsType> GetREG_DESIGN_Name(ServiceRequestData<GetDesignsByNameType> argument)
        {
            return  AdapterClient.Execute<IPvDesignAdapter, GetDesignsByNameType, DesignDetailsType>(
                (i, r, a, o) => i.GetREG_DESIGN_Name(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetDesignByOwnersNameType, DesignDetailsType> GetREG_DESIGN_Owner_Name(ServiceRequestData<GetDesignByOwnersNameType> argument)
        {
            return AdapterClient.Execute<IPvDesignAdapter, GetDesignByOwnersNameType, DesignDetailsType>(
                (i, r, a, o) => i.GetREG_DESIGN_Owner_Name(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<GetDesignByRegNumType, DesignDetailsType> GetREG_DESIGN_Reg_Number(ServiceRequestData<GetDesignByRegNumType> argument)
        {
            return  AdapterClient.Execute<IPvDesignAdapter, GetDesignByRegNumType, DesignDetailsType>(
                (i, r, a, o) => i.GetREG_DESIGN_Reg_Number(r, a, o),
                 argument);
        }

        //public ServiceResultData<REG_DESIGN_Stat_App_Name_ResponseType> GetREG_DESIGN_Stat_App_Name(ServiceRequestData<REG_DESIGN_Stat_App_Name_RequestType> argument)
        //{
        //    return WorkflowClient.ExecuteSynchronous<REG_DESIGN_Stat_App_Name_RequestType, REG_DESIGN_Stat_App_Name_ResponseType>(
        //        "TechnoLogica.RegiX.PvDesignAdapter.AdapterService.IPvDesignAdapter.GetREG_DESIGN_Stat_App_Name", 
        //         argument);
        //}
    }
}
