using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства")]
    public interface IIaosMROBatteriesAPI : IAPIService
    {
        //справка за валидност в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства.
        [OperationContract]
        [Description("Справка за валидност в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства.")]
        [Info(requestXSD: "MRO_BA_Validity_Check_Request.xsd",
            responseXSD: "MRO_BA_Validity_Check_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_BA_Validity_Check_Request.xslt",
            responseXSLT: "MRO_BA_Validity_Check_Response.xslt")]
        ServiceResultDataSigned<MRO_BA_Validity_Check_Request, MRO_BA_Validity_Check_Response> GetMRO_BA_Validity_Check(ServiceRequestData<MRO_BA_Validity_Check_Request> argument);

        //справка за начин на изпълнение в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства
        [OperationContract]
        [Description("Справка за начин на изпълнение в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства")]
        [Info(requestXSD: "MRO_BA_Execution_Type_Request.xsd",
            responseXSD: "MRO_BA_Execution_Type_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_BA_Execution_Type_Request.xslt",
            responseXSLT: "MRO_BA_Execution_Type_Response.xslt")]
        ServiceResultDataSigned<MRO_BA_Execution_Type_Request, MRO_BA_Execution_Type_Response> GetMRO_BA_Execution_Type(ServiceRequestData<MRO_BA_Execution_Type_Request> argument);

        //справка за търговски марки в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства
        [OperationContract]
        [Description("Справка за търговски марки в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства")]
        [Info(requestXSD: "MRO_BA_Trade_Marks_Request.xsd",
            responseXSD: "MRO_BA_Trade_Marks_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_BA_Trade_Marks_Request.xslt",
            responseXSLT: "MRO_BA_Trade_Marks_Response.xslt")]
        ServiceResultDataSigned<MRO_BA_Trade_Marks_Request, MRO_BA_Trade_Marks_Response> GetMRO_BA_Trade_Marks(ServiceRequestData<MRO_BA_Trade_Marks_Request> argument);

        //справка за вид батерии и акумулатори по ЕИК в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства.
        [OperationContract]
        [Description("Справка за вид батерии и акумулатори по ЕИК в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства.")]
        [Info(requestXSD: "MRO_BA_Category_Request.xsd",
            responseXSD: "MRO_BA_Category_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_BA_Category_Request.xslt",
            responseXSLT: "MRO_BA_Category_Response.xslt")]
        ServiceResultDataSigned<MRO_BA_Category_Request, MRO_BA_Category_Response> GetMRO_BA_Category(ServiceRequestData<MRO_BA_Category_Request> argument);
    }
}
