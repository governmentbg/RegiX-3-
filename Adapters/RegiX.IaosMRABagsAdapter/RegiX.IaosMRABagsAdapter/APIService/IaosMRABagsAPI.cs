using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMRABagsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IaosMRABagsAdapter.APIService
{
    [ExportFullName(typeof(IIaosMRABagsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosMRABagsAPI : BaseAPIService<IIaosMRABagsAPI>, IIaosMRABagsAPI
    {
        public ServiceResultDataSigned<MRO_BAGS_Reg_Number_Date_Request, MRO_BAGS_Reg_Number_Date_Response> GetMRA_BAGS_Reg_Number_Date(ServiceRequestData<MRO_BAGS_Reg_Number_Date_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMRABagsAdapter, MRO_BAGS_Reg_Number_Date_Request, MRO_BAGS_Reg_Number_Date_Response>(
                (i, r, a, o) => i.GetMRA_BAGS_Reg_Number_Date(r, a, o),
                 argument);
        }
        public ServiceResultDataSigned<MRO_BAGS_Validity_Check_Request, MRO_BAGS_Validity_Check_Response> GetMRO_BAGS_Validity_Check(ServiceRequestData<MRO_BAGS_Validity_Check_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMRABagsAdapter, MRO_BAGS_Validity_Check_Request, MRO_BAGS_Validity_Check_Response>(
                (i, r, a, o) => i.GetMRO_BAGS_Validity_Check(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<MRO_BAGS_Reg_Number_Request, MRO_BAGS_Reg_Number_Response> GetMRO_BAGS_Reg_Number(ServiceRequestData<MRO_BAGS_Reg_Number_Request> argument)
        {
            return AdapterClient.Execute<IIaosMRABagsAdapter, MRO_BAGS_Reg_Number_Request, MRO_BAGS_Reg_Number_Response>(
                (i, r, a, o) => i.GetMRO_BAGS_Reg_Number(r, a, o),
                 argument);
        }
    }
}
