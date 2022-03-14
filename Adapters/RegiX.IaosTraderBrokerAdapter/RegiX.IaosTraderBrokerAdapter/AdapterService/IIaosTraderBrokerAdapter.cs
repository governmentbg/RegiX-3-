using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци.(Публични регистри по чл. 26, ал. 1, т.1, чл. 26, ал. 1,т. 4, чл. 26, ал. 2 и чл. 72, ал. 3 от Закона за управление на отпадъците към 2011 г.)")]
    public interface IIaosTraderBrokerAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за валидност")]
        CommonSignedResponse<TRADER_BROKER_Validity_Check_Request, TRADER_BROKER_Validity_Check_Response> GetTRADER_BROKER_Validity_Check(TRADER_BROKER_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за кодове на отпадъци")]
        CommonSignedResponse<TRADER_BROKER_Waste_Codes_By_EIK_Request, TRADER_BROKER_Waste_Codes_By_EIK_Response> GetTRADER_BROKER_Waste_Codes_By_EIK(TRADER_BROKER_Waste_Codes_By_EIK_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за кодове на отпадъци - V2")]
        CommonSignedResponse<TRADER_BROKER_Waste_Codes_By_EIK_RequestV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2> GetTRADER_BROKER_Waste_Codes_By_EIKV2(TRADER_BROKER_Waste_Codes_By_EIK_RequestV2 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}

