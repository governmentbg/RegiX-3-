using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV2;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV3;

namespace TechnoLogica.RegiX.AVTRAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Търговски регистър")]
    public interface ITRAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за актуално състояние(v1)")]
        CommonSignedResponse<ActualStateRequestType, ActualStateResponseType> GetActualState(ActualStateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за актуално състояние за всички вписани обстоятелства(v2)")]
        CommonSignedResponse<ActualStateRequestV2, ActualStateResponseV2> GetActualStateV2(ActualStateRequestV2 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за актуално състояние за всички вписани обстоятелства по раздели")]
        CommonSignedResponse<ActualStateRequestV3, ActualStateResponseV3> GetActualStateV3(ActualStateRequestV3 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за актуално състояние на клон на търговско дружество")]
        CommonSignedResponse<GetBranchOfficeRequest, GetBranchOfficeResponse> GetBranchOffice(GetBranchOfficeRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за Валидност на ЕИК номер")]
        CommonSignedResponse<ValidUICRequestType, ValidUICResponseType> GetValidUICInfo(ValidUICRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по физическо лице за участие в търговски дружества")]
        CommonSignedResponse<SearchParticipationInCompaniesRequestType, SearchParticipationInCompaniesResponseType> PersonInCompaniesSearch(SearchParticipationInCompaniesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}
