using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци.(Публични регистри по чл. 26, ал. 1, т.1, чл. 26, ал. 1,т. 4, чл. 26, ал. 2 и чл. 72, ал. 3 от Закона за управление на отпадъците към 2011 г.)")]
    public interface IIaosTraderBrokerAPI : IAPIService
    {
        //справка за валидност в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци.
        [OperationContract]
        [Description("Справка за валидност в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци.")]
        [Info(
            requestXSD: "TRADER_BROKER_Validity_Check_Request.xsd",
            responseXSD: "TRADER_BROKER_Validity_Check_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "TRADER_BROKER_Validity_Check_Request.xslt",
            responseXSLT: "TRADER_BROKER_Validity_Check_Response.xslt")]
        ServiceResultDataSigned <TRADER_BROKER_Validity_Check_Request, TRADER_BROKER_Validity_Check_Response> GetTRADER_BROKER_Validity_Check(ServiceRequestData<TRADER_BROKER_Validity_Check_Request> argument);

        //справка за кодове на отпадъци в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци.
        [OperationContract]
        [Description("Справка за кодове на отпадъци в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци.")]
        [Info(
            requestXSD: "TRADER_BROKER_Waste_Codes_By_EIK_Request.xsd",
            responseXSD: "TRADER_BROKER_Waste_Codes_By_EIK_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "TRADER_BROKER_Waste_Codes_By_EIK_Request.xslt",
            responseXSLT: "TRADER_BROKER_Waste_Codes_By_EIK_Response.xslt")]
        ServiceResultDataSigned<TRADER_BROKER_Waste_Codes_By_EIK_Request, TRADER_BROKER_Waste_Codes_By_EIK_Response> GetTRADER_BROKER_Waste_Codes_By_EIK(ServiceRequestData<TRADER_BROKER_Waste_Codes_By_EIK_Request> argument);

        //справка за кодове на отпадъци в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци (версия 2).
        [OperationContract]
        [Description("Справка за кодове на отпадъци в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци (версия 2).")]
        [Info(
            requestXSD: "TRADER_BROKER_Waste_Codes_By_EIK_RequestV2.xsd",
            responseXSD: "TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "TRADER_BROKER_Waste_Codes_By_EIK_RequestV2.xslt",
            responseXSLT: "TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2.xslt")]
        ServiceResultDataSigned<TRADER_BROKER_Waste_Codes_By_EIK_RequestV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2> GetTRADER_BROKER_Waste_Codes_By_EIKV2(ServiceRequestData<TRADER_BROKER_Waste_Codes_By_EIK_RequestV2> argument);

    }
}
