using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителна агенция Главна инспекция по труда - Регистър на наказателните постановления")]
    public interface IGitPenalProvisionsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за наказателни постановления за период")]
        CommonSignedResponse<PenalProvisionForPeriodRequest, PenalProvisionForPeriodResponse> GetPenalProvisionForPeriod(PenalProvisionForPeriodRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за наказателни постановления във връзка с посредническа дейност за период")]
        CommonSignedResponse<PenalProvisionMediatorActType, PenalProvisionMediatorActResponse> GetPenalProvisionMediatorAct(PenalProvisionMediatorActType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК/БУЛСТАТ за наказателни постановления на основание неплатени трудови възнаграждения за период")]
        CommonSignedResponse<PenalProvisionUnpaidFeeType, PenalProvisionUnpaidFeeResponse> GetPenalProvisionUnpaidFee(PenalProvisionUnpaidFeeType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);


    }
}

