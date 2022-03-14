using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosTraderBrokerAdapter.AdapterService;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;

namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter.APIService
{
    [ExportFullName(typeof(IIaosTraderBrokerAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosTraderBrokerAPI : BaseAPIService<IIaosTraderBrokerAPI>, IIaosTraderBrokerAPI
    {
        public ServiceResultDataSigned<TRADER_BROKER_Validity_Check_Request, TRADER_BROKER_Validity_Check_Response> GetTRADER_BROKER_Validity_Check(ServiceRequestData<TRADER_BROKER_Validity_Check_Request> argument)
        {
            return  AdapterClient.Execute<IIaosTraderBrokerAdapter, TRADER_BROKER_Validity_Check_Request, TRADER_BROKER_Validity_Check_Response>(
                (i, r, a, o) => i.GetTRADER_BROKER_Validity_Check(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<TRADER_BROKER_Waste_Codes_By_EIK_Request, TRADER_BROKER_Waste_Codes_By_EIK_Response> GetTRADER_BROKER_Waste_Codes_By_EIK(ServiceRequestData<TRADER_BROKER_Waste_Codes_By_EIK_Request> argument)
        {
            return AdapterClient.Execute<IIaosTraderBrokerAdapter, TRADER_BROKER_Waste_Codes_By_EIK_Request, TRADER_BROKER_Waste_Codes_By_EIK_Response>(
                (i, r, a, o) => i.GetTRADER_BROKER_Waste_Codes_By_EIK(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<TRADER_BROKER_Waste_Codes_By_EIK_RequestV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2> GetTRADER_BROKER_Waste_Codes_By_EIKV2(ServiceRequestData<TRADER_BROKER_Waste_Codes_By_EIK_RequestV2> argument)
        {
            return AdapterClient.Execute<IIaosTraderBrokerAdapter, TRADER_BROKER_Waste_Codes_By_EIK_RequestV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2>(
                (i, r, a, o) => i.GetTRADER_BROKER_Waste_Codes_By_EIKV2(r, a, o),
                 argument);
        }
    }
}
