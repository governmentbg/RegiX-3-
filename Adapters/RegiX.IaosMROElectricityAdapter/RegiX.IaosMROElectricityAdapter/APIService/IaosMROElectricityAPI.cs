using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROElectricityAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IaosMROElectricityAdapter.APIService
{
    [ExportFullName(typeof(IIaosMROElectricityAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosMROElectricityAPI : BaseAPIService<IIaosMROElectricityAPI>, IIaosMROElectricityAPI
    {
        public ServiceResultDataSigned<MRO_EEO_Validity_Check_Request, MRO_EEO_Validity_Check_Response> GetMRO_EEO_Validity_Check(ServiceRequestData<MRO_EEO_Validity_Check_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMROElectricityAdapter, MRO_EEO_Validity_Check_Request, MRO_EEO_Validity_Check_Response>(
                (i, r, a, o) => i.GetMRO_EEO_Validity_Check(r, a, o),
                 argument);
        }
        
        public ServiceResultDataSigned<MRO_EEO_Equipment_Category_Request, MRO_EEO_Equipment_Category_Response> GetMRO_EEO_Equipment_Category(ServiceRequestData<MRO_EEO_Equipment_Category_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROElectricityAdapter, MRO_EEO_Equipment_Category_Request, MRO_EEO_Equipment_Category_Response>(
                (i, r, a, o) => i.GetMRO_EEO_Equipment_Category(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<MRO_EEO_Execution_Type_Request, MRO_EEO_Execution_Type_Response> GetMRO_EEO_Execution_Type(ServiceRequestData<MRO_EEO_Execution_Type_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROElectricityAdapter, MRO_EEO_Execution_Type_Request, MRO_EEO_Execution_Type_Response>(
                (i, r, a, o) => i.GetMRO_EEO_Execution_Type(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<MRO_EEO_Trade_Marks_Request, MRO_EEO_Trade_Marks_Response> GetMRO_EEO_Trade_Marks(ServiceRequestData<MRO_EEO_Trade_Marks_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROElectricityAdapter, MRO_EEO_Trade_Marks_Request, MRO_EEO_Trade_Marks_Response>(
                (i, r, a, o) => i.GetMRO_EEO_Trade_Marks(r, a, o),
                 argument);
        }    
    }
}
