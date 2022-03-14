using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvPatentsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.PvPatentsAdapter.APIService
{
    [ExportFullName(typeof(IPvPatentsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PvPatentsAPI : BaseAPIService<IPvPatentsAPI>, IPvPatentsAPI
    {
        public ServiceResultDataSigned<getPatentByAppNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_App_Number(ServiceRequestData<getPatentByAppNumType> argument)
        {
            return  AdapterClient.Execute<IPvPatentsAdapter, getPatentByAppNumType, REG_UM_PATENT_PatentDetails_Response>(
                (i, r, a, o) => i.GetREG_PATENT_App_Number(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getPatentsByNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Name(ServiceRequestData<getPatentsByNameType> argument)
        {
            return AdapterClient.Execute<IPvPatentsAdapter, getPatentsByNameType, REG_UM_PATENT_PatentDetails_Response>(
                (i, r, a, o) => i.GetREG_PATENT_Patent_Name(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getPatentByOwnersNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Owner(ServiceRequestData<getPatentByOwnersNameType> argument)
        {
            return AdapterClient.Execute<IPvPatentsAdapter, getPatentByOwnersNameType, REG_UM_PATENT_PatentDetails_Response>(
                (i, r, a, o) => i.GetREG_PATENT_Patent_Owner(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<getPatentByRegNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Reg_Number(ServiceRequestData<getPatentByRegNumType> argument)
        {
            return  AdapterClient.Execute<IPvPatentsAdapter, getPatentByRegNumType, REG_UM_PATENT_PatentDetails_Response>(
                (i, r, a, o) => i.GetREG_PATENT_Reg_Number(r, a, o),
                 argument);
        }

        //public ServiceResultData<PatentDetailsType> GetREG_PATENT_Status_App_Date(ServiceRequestData<getPatentsByStatAppDateType> argument)
        //{
        //    return  AdapterClient.Execute<IPvPatentsAdapter, getPatentsByStatAppDateType, getPatentsByStatAppDateType>(
        //        (i, r, a, o) => i.GetREG_PATENT_Status_App_Date(r, a),
        //         argument);
        //}
    }
}
