using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosRegister67ZOUAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие, и регистрационните документи по чл. 78 ЗУО, в т.ч. на тези от тях с прекратено действие")]
    public interface IIaosRegister67ZOUAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК в регистъра на разрешенията по чл. 67 ЗУО и регистрационните документи по чл. 78 от ЗУО")]
        CommonSignedResponse<REG35_Info_By_EIK_Request, REG35_Info_By_EIK_Response> GetREG35_Info_By_EIK(REG35_Info_By_EIK_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за валидност на разрешения към дата в регистъра на разрешенията по чл. 67 ЗУО и регистрационните документи по чл. 78 от ЗУО")]
        CommonSignedResponse<REG35_License_Validity_Check_Request, REG35_License_Validity_Check_Response> GetREG35_License_Validity_Check(REG35_License_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по населено място в регистъра на разрешенията по чл. 67 ЗУО и регистрационните документи по чл. 78 от ЗУО")]
        CommonSignedResponse<REG35_Stage_Info_By_Pop_Name_Request, REG35_Stage_Info_By_Pop_Name_Response> GetREG35_Stage_Info_By_Pop_Name(REG35_Stage_Info_By_Pop_Name_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за площадки по операция с отпадък в регистъра на разрешенията по чл. 67 ЗУО и регистрационните документи по чл. 78 от ЗУО")]
        CommonSignedResponse<REG35_Stage_Info_By_Waste_Code_Request, REG35_Stage_Info_By_Waste_Code_Response> GetREG35_Stage_Info_By_Waste_Code(REG35_Stage_Info_By_Waste_Code_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по код на отпадък в регистъра на разрешенията по чл. 67 ЗУО и регистрационните документи по чл. 78 от ЗУО")]
        CommonSignedResponse<REG35_Stages_By_Reg_Number_And_Waste_Code_Request, REG35_Stages_By_Reg_Number_And_Waste_Code_Response> GetREG35_Stages_By_Reg_Number_And_Waste_Code(REG35_Stages_By_Reg_Number_And_Waste_Code_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по регистрационен номер в регистъра на разрешенията по чл. 67 ЗУО и регистрационните документи по чл. 78 от ЗУО")]
        CommonSignedResponse<REG35_Validity_Check_By_Reg_Number_Request, REG35_Validity_Check_By_Reg_Number_Response> GetREG35_Validity_Check_By_Reg_Number(REG35_Validity_Check_By_Reg_Number_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

