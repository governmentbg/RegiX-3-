using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvMarksAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.PvMarksAdapter.APIService
{
    [ExportFullName(typeof(IPvMarksAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PvMarksAPI : BaseAPIService<IPvMarksAPI>, IPvMarksAPI
    {
        public ServiceResultDataSigned<GetMarkByAppNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_App_Number(ServiceRequestData<GetMarkByAppNumType> argument)
        {
            return  AdapterClient.Execute<IPvMarksAdapter, GetMarkByAppNumType, REG_MARKS_TradeMarkDetails_Response>(
                (i, r, a, o) => i.GetREG_MARKS_App_Number(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetMarksByNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Mark_Name(ServiceRequestData<GetMarksByNameType> argument)
        {
            return AdapterClient.Execute<IPvMarksAdapter, GetMarksByNameType, REG_MARKS_TradeMarkDetails_Response>(
                (i, r, a, o) => i.GetREG_MARKS_Mark_Name(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetMarkByOwnersNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Owner(ServiceRequestData<GetMarkByOwnersNameType> argument)
        {
            return AdapterClient.Execute<IPvMarksAdapter, GetMarkByOwnersNameType, REG_MARKS_TradeMarkDetails_Response>(
                (i, r, a, o) => i.GetREG_MARKS_Owner(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<GetMarkByRegNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Reg_Number(ServiceRequestData<GetMarkByRegNumType> argument)
        {
            return AdapterClient.Execute<IPvMarksAdapter, GetMarkByRegNumType, REG_MARKS_TradeMarkDetails_Response>(
                (i, r, a, o) => i.GetREG_MARKS_Reg_Number(r, a, o),
                 argument);
        }
    }
}
