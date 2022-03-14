using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROBatteriesAdapter.AdapterService;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;

namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter.APIService
{
    [ExportFullName(typeof(IIaosMROBatteriesAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosMROBatteriesAPI : BaseAPIService<IIaosMROBatteriesAPI>, IIaosMROBatteriesAPI
    {
        public ServiceResultDataSigned<MRO_BA_Validity_Check_Request, MRO_BA_Validity_Check_Response> GetMRO_BA_Validity_Check(ServiceRequestData<MRO_BA_Validity_Check_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMROBatteriesAdapter, MRO_BA_Validity_Check_Request, MRO_BA_Validity_Check_Response>(
                (i, r, a, o) => i.GetMRO_BA_Validity_Check(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<MRO_BA_Execution_Type_Request, MRO_BA_Execution_Type_Response> GetMRO_BA_Execution_Type(ServiceRequestData<MRO_BA_Execution_Type_Request> argument)
        {
            return  AdapterClient.Execute<IIaosMROBatteriesAdapter, MRO_BA_Execution_Type_Request, MRO_BA_Execution_Type_Response>(
                (i, r, a, o) => i.GetMRO_BA_Execution_Type(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<MRO_BA_Trade_Marks_Request, MRO_BA_Trade_Marks_Response> GetMRO_BA_Trade_Marks(ServiceRequestData<MRO_BA_Trade_Marks_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROBatteriesAdapter, MRO_BA_Trade_Marks_Request, MRO_BA_Trade_Marks_Response>(
                (i, r, a, o) => i.GetMRO_BA_Trade_Marks(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<MRO_BA_Category_Request, MRO_BA_Category_Response> GetMRO_BA_Category(ServiceRequestData<MRO_BA_Category_Request> argument)
        {
            return AdapterClient.Execute<IIaosMROBatteriesAdapter, MRO_BA_Category_Request, MRO_BA_Category_Response>(
                (i, r, a, o) => i.GetMRO_BA_Category(r, a, o),
                 argument);
        }
    }
}
