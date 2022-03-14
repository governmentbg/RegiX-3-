using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosMROElectricityAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО)")]
    public interface IIaosMROElectricityAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за проверка за валидност в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        CommonSignedResponse<MRO_EEO_Validity_Check_Request, MRO_EEO_Validity_Check_Response> GetMRO_EEO_Validity_Check(MRO_EEO_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за категории електрическо и електронно по ЕИК оборудване в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        CommonSignedResponse<MRO_EEO_Equipment_Category_Request, MRO_EEO_Equipment_Category_Response> GetMRO_EEO_Equipment_Category(MRO_EEO_Equipment_Category_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за начин на изпълнение в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        CommonSignedResponse<MRO_EEO_Execution_Type_Request, MRO_EEO_Execution_Type_Response> GetMRO_EEO_Execution_Type(MRO_EEO_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за търговски марки в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        CommonSignedResponse<MRO_EEO_Trade_Marks_Request, MRO_EEO_Trade_Marks_Response> GetMRO_EEO_Trade_Marks(MRO_EEO_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

