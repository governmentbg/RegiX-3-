using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROOilAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IaosMROOilAdapter.APIService
{
    [ExportFullName(typeof(IIaosMROOilAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosMROOilAPI : BaseAPIService<IIaosMROOilAPI>, IIaosMROOilAPI
    {
        public ServiceResultDataSigned<MRO_OIL_Validity_Check_Request, MRO_OIL_Validity_Check_Response> GetMRO_OIL_Validity_Check(ServiceRequestData<MRO_OIL_Validity_Check_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMROOilAdapter, MRO_OIL_Validity_Check_Request, MRO_OIL_Validity_Check_Response>(
                (i, r, a, o) => i.GetMRO_OIL_Validity_Check(r, a, o),
                 argument);
        }
        
        //-----------------------------

        public ServiceResultDataSigned<MRO_OIL_Execution_Type_Request, MRO_OIL_Execution_Type_Response> GetMRO_OIL_Execution_Type(ServiceRequestData<MRO_OIL_Execution_Type_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROOilAdapter, MRO_OIL_Execution_Type_Request, MRO_OIL_Execution_Type_Response>(
                (i, r, a, o) => i.GetMRO_OIL_Execution_Type(r, a, o),
                 argument);
        }
        //--------------------------

        public ServiceResultDataSigned<MRO_OIL_Trade_Marks_Request, MRO_OIL_Trade_Marks_Response> GetMRO_OIL_Trade_Marks(ServiceRequestData<MRO_OIL_Trade_Marks_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROOilAdapter, MRO_OIL_Trade_Marks_Request, MRO_OIL_Trade_Marks_Response>(
                (i, r, a, o) => i.GetMRO_OIL_Trade_Marks(r, a, o),
                 argument);
        }

    }
}
