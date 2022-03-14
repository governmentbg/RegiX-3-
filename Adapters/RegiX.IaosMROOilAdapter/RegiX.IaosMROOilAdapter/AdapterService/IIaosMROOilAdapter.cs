using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosMROOilAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара масла по смисъла на § 1, т. 7 от ДР на Наредбата за отработените масла и отпадъчните нефтопродукти, приета с ПМС № 352 от 2012 г. (ДВ, бр. 2 от 2013 г.);")]
    public interface IIaosMROOilAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за валидност в Регистъра на лицата, които пускат на пазара масла.")]
        CommonSignedResponse<MRO_OIL_Validity_Check_Request, MRO_OIL_Validity_Check_Response> GetMRO_OIL_Validity_Check(MRO_OIL_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за начин на изпълнение на задълженията в Регистъра на лицата, които пускат на пазара масла.")]
        CommonSignedResponse<MRO_OIL_Execution_Type_Request, MRO_OIL_Execution_Type_Response> GetMRO_OIL_Execution_Type(MRO_OIL_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за търговски марки в Регистъра на лицата, които пускат на пазара масла.")]
        CommonSignedResponse<MRO_OIL_Trade_Marks_Request, MRO_OIL_Trade_Marks_Response> GetMRO_OIL_Trade_Marks(MRO_OIL_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

