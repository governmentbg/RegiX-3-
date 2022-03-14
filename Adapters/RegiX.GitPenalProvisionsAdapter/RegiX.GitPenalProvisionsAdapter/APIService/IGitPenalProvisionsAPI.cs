using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителна агенция Главна инспекция по труда - Регистър на наказателните постановления")]
    public interface IGitPenalProvisionsAPI : IAPIService
    {
        //Справка по ЕИК/БУЛСТАТ за наказателни постановления за период
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за наказателни постановления за период")]
        [Info(
            requestXSD: "PenalProvisionForPeriodRequest.xsd",
            responseXSD: "PenalProvisionForPeriodResponse.xsd",
            commonXSD: "RNPCommon.xsd",
            requestXSLT: "PenalProvisionForPeriodRequest.xslt",
            responseXSLT: "PenalProvisionForPeriodResponse.xslt")]
        ServiceResultDataSigned<PenalProvisionForPeriodRequest, PenalProvisionForPeriodResponse> GetPenalProvisionForPeriod(ServiceRequestData<PenalProvisionForPeriodRequest> argument);

        //Справка по ЕИК/БУЛСТАТ за наказателни постановления във връзка с посредническа дейност за период
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за наказателни постановления във връзка с посредническа дейност за период")]
        [Info(
            requestXSD: "PenalProvisionMediatorActRequest.xsd",
            responseXSD: "PenalProvisionMediatorActResponse.xsd",
            commonXSD: "RNPCommon.xsd",
            requestXSLT: "PenalProvisionMediatorActRequest.xslt",
            responseXSLT: "PenalProvisionMediatorActResponse.xslt")]
        ServiceResultDataSigned<PenalProvisionMediatorActType, PenalProvisionMediatorActResponse> GetPenalProvisionMediatorAct(ServiceRequestData<PenalProvisionMediatorActType> argument);

        //Справка по ЕИК/БУЛСТАТ за наказателни постановления на основание неплатени трудови възнаграждения за период
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за наказателни постановления на основание неплатени трудови възнаграждения за период")]
        [Info(
            requestXSD: "PenalProvisionUnpaidFeeRequest.xsd",
            responseXSD: "PenalProvisionUnpaidFeeResponse.xsd",
            commonXSD: "RNPCommon.xsd",
            requestXSLT: "PenalProvisionUnpaidFeeRequest.xslt",
            responseXSLT: "PenalProvisionUnpaidFeeResponse.xslt")]
        ServiceResultDataSigned<PenalProvisionUnpaidFeeType, PenalProvisionUnpaidFeeResponse> GetPenalProvisionUnpaidFee(ServiceRequestData<PenalProvisionUnpaidFeeType> argument);
    }
}
