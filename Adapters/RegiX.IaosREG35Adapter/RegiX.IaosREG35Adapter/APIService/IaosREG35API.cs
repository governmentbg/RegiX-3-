using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosREG35Adapter.AdapterService;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;

namespace TechnoLogica.RegiX.IaosREG35Adapter.APIService
{
    [ExportFullName(typeof(IIaosREG35API), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosREG35API : BaseAPIService<IIaosREG35API>, IIaosREG35API
    {
        public ServiceResultDataSigned<REG35_Stages_Validity_Period_Request, REG35_Stages_Validity_Period_Response> GetREG35_Stages_Validity_Period(ServiceRequestData<REG35_Stages_Validity_Period_Request> argument)
        {
            return  AdapterClient.Execute<IIaosREG35Adapter, REG35_Stages_Validity_Period_Request, REG35_Stages_Validity_Period_Response>(
                (i, r, a, o) => i.GetREG35_Stages_Validity_Period(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<REG35_Allowed_Waste_Codes_Request, REG35_Allowed_Waste_Codes_Response> GetREG35_Allowed_Waste_Codes(ServiceRequestData<REG35_Allowed_Waste_Codes_Request> argument)
        {
            return  AdapterClient.Execute<IIaosREG35Adapter, REG35_Allowed_Waste_Codes_Request, REG35_Allowed_Waste_Codes_Response>(
                (i, r, a, o) => i.GetREG35_Allowed_Waste_Codes(r, a, o),
                
                argument);
        }

        public ServiceResultDataSigned<REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request, REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response> GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation(ServiceRequestData<REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request> argument)
        {
            return AdapterClient.Execute<IIaosREG35Adapter, REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request, REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response>(
                (i, r, a, o) => i.GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<REG35_Stages_By_Auth_Num_Request, REG35_Stages_By_Auth_Num_Response> GetREG35_Stages_By_Auth_Num(ServiceRequestData<REG35_Stages_By_Auth_Num_Request> argument)
        {
            return AdapterClient.Execute<IIaosREG35Adapter, REG35_Stages_By_Auth_Num_Request, REG35_Stages_By_Auth_Num_Response>(
                (i, r, a, o) => i.GetREG35_Stages_By_Auth_Num(r, a, o),
                 argument);
        }
    }
}
