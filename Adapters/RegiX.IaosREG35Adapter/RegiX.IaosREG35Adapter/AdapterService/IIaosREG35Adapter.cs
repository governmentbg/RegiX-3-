using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosREG35Adapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА")]
    public interface IIaosREG35Adapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за валидност на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА")]
        CommonSignedResponse<REG35_Stages_Validity_Period_Request, REG35_Stages_Validity_Period_Response> GetREG35_Stages_Validity_Period(REG35_Stages_Validity_Period_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за разрешени кодове на отпадъци от дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА")]
        CommonSignedResponse<REG35_Allowed_Waste_Codes_Request, REG35_Allowed_Waste_Codes_Response> GetREG35_Allowed_Waste_Codes(REG35_Allowed_Waste_Codes_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за дейности с отпадъци в Регистъра на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА")]
        CommonSignedResponse<REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request, REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response> GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation(REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по регистрационен номер в Регистъра на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА")]
        CommonSignedResponse<REG35_Stages_By_Auth_Num_Request, REG35_Stages_By_Auth_Num_Response> GetREG35_Stages_By_Auth_Num(REG35_Stages_By_Auth_Num_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

