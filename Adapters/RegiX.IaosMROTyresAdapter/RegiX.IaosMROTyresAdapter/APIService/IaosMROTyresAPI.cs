using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROTyresAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IaosMROTyresAdapter.APIService
{
    [ExportFullName(typeof(IIaosMROTyresAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosMROTyresAPI : BaseAPIService<IIaosMROTyresAPI>, IIaosMROTyresAPI
    {
        public ServiceResultDataSigned<MRO_TYRES_Validity_Check_Request, MRO_TYRES_Validity_Check_Response> GetMRO_TYRES_Validity_Check(ServiceRequestData<MRO_TYRES_Validity_Check_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMROTyresAdapter, MRO_TYRES_Validity_Check_Request, MRO_TYRES_Validity_Check_Response>(
                (i, r, a, o) => i.GetMRO_TYRES_Validity_Check(r, a, o),
                 argument);
        }         
        public ServiceResultDataSigned<MRO_TYRES_Execution_Type_Request, MRO_TYRES_Execution_Type_Response> GetMRO_TYRES_Execution_Type(ServiceRequestData<MRO_TYRES_Execution_Type_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMROTyresAdapter, MRO_TYRES_Execution_Type_Request, MRO_TYRES_Execution_Type_Response>(
                (i, r, a, o) => i.GetMRO_TYRES_Execution_Type(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<MRO_TYRES_Trade_Marks_Request, MRO_TYRES_Trade_Marks_Response> GetMRO_TYRES_Trade_Marks(ServiceRequestData<MRO_TYRES_Trade_Marks_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROTyresAdapter, MRO_TYRES_Trade_Marks_Request, MRO_TYRES_Trade_Marks_Response>(
                (i, r, a, o) => i.GetMRO_TYRES_Trade_Marks(r, a, o),
                 argument);
        }
    }
}
