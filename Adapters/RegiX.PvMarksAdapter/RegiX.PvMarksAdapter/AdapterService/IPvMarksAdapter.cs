using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PvMarksAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Патентно ведомство - Държавният регистър на марките")]
    public interface IPvMarksAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за статус на марка по заявителски номер")]
        CommonSignedResponse<GetMarkByAppNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_App_Number(GetMarkByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за марка по име")]
        CommonSignedResponse<GetMarksByNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Mark_Name(GetMarksByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за марки по притежател")]
        CommonSignedResponse<GetMarkByOwnersNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Owner(GetMarkByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по номер на марка")]
        CommonSignedResponse<GetMarkByRegNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Reg_Number(GetMarkByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на заявяване на марка")]
        //REG_MARKS_Stat_App_Date_Response GetREG_MARKS_Stat_App_Date(REG_MARKS_Stat_App_Date_RequestType argument, AccessMatrix accessMatrix);


    }
}

