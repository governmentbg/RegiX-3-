using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosMRABagsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара полимерни торбички")]
    public interface IIaosMRABagsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по регистрационен номер в Регистъра на лицата, които пускат на пазара полимерни торбички")]
        CommonSignedResponse<MRO_BAGS_Reg_Number_Date_Request, MRO_BAGS_Reg_Number_Date_Response> GetMRA_BAGS_Reg_Number_Date(MRO_BAGS_Reg_Number_Date_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за валидност в Регистъра на лицата, които пускат на пазара полимерни торбички")]
        CommonSignedResponse<MRO_BAGS_Validity_Check_Request, MRO_BAGS_Validity_Check_Response> GetMRO_BAGS_Validity_Check(MRO_BAGS_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по регистрационен номер в Регистъра на лицата, които пускат на пазара полимерни торбички")]
        CommonSignedResponse<MRO_BAGS_Reg_Number_Request, MRO_BAGS_Reg_Number_Response> GetMRO_BAGS_Reg_Number(MRO_BAGS_Reg_Number_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);


    }
}

