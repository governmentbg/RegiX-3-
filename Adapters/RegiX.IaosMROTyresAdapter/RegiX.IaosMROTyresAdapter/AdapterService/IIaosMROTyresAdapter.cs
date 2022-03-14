using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosMROTyresAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара гуми")]
    public interface IIaosMROTyresAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за валидност в Регистъра на лицата, които пускат на пазара гуми.")]
        CommonSignedResponse<MRO_TYRES_Validity_Check_Request, MRO_TYRES_Validity_Check_Response> GetMRO_TYRES_Validity_Check(MRO_TYRES_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за начин на изпълнение на задълженията в Регистъра на лицата, които пускат на пазара гуми.")]
        CommonSignedResponse<MRO_TYRES_Execution_Type_Request, MRO_TYRES_Execution_Type_Response> GetMRO_TYRES_Execution_Type(MRO_TYRES_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за търговски марки в Регистъра на лицата, които пускат на пазара гуми.")]
        CommonSignedResponse<MRO_TYRES_Trade_Marks_Request, MRO_TYRES_Trade_Marks_Response> GetMRO_TYRES_Trade_Marks(MRO_TYRES_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

