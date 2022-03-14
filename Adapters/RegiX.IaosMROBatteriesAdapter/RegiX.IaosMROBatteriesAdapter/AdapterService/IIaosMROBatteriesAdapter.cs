using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства")]
    public interface IIaosMROBatteriesAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за валидност в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства.")]
        CommonSignedResponse<MRO_BA_Validity_Check_Request, MRO_BA_Validity_Check_Response> GetMRO_BA_Validity_Check(MRO_BA_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
        
        [OperationContract]
        [Description("справка за начин на изпълнение в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства")]
        CommonSignedResponse<MRO_BA_Execution_Type_Request, MRO_BA_Execution_Type_Response>  GetMRO_BA_Execution_Type(MRO_BA_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за търговски марки в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства")]
        CommonSignedResponse<MRO_BA_Trade_Marks_Request, MRO_BA_Trade_Marks_Response> GetMRO_BA_Trade_Marks(MRO_BA_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за вид батерии и акумулатори по ЕИК в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства")]
        CommonSignedResponse<MRO_BA_Category_Request, MRO_BA_Category_Response> GetMRO_BA_Category(MRO_BA_Category_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

