using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosMROElectricityAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО)")]
    public interface IIaosMROElectricityAPI : IAPIService
    {
        //справка за проверка за валидност в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).
        [OperationContract]
        [Description("Справка за проверка за валидност в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        [Info(requestXSD: "MRO_EEO_Validity_Check_Request.xsd",
            responseXSD: "MRO_EEO_Validity_Check_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_EEO_Validity_Check_Request.xslt",
            responseXSLT: "MRO_EEO_Validity_Check_Response.xslt")]
        ServiceResultDataSigned<MRO_EEO_Validity_Check_Request, MRO_EEO_Validity_Check_Response> GetMRO_EEO_Validity_Check(ServiceRequestData<MRO_EEO_Validity_Check_Request> argument);

        //справка за категории електрическо и електронно по ЕИК оборудване в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).
        [OperationContract]
        [Description("Справка за категории електрическо и електронно по ЕИК оборудване в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        [Info(requestXSD: "MRO_EEO_Equipment_Category_Request.xsd",
            responseXSD: "MRO_EEO_Equipment_Category_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_EEO_Equipment_Category_Request.xslt",
            responseXSLT: "MRO_EEO_Equipment_Category_Response.xslt")]
        ServiceResultDataSigned<MRO_EEO_Equipment_Category_Request,MRO_EEO_Equipment_Category_Response> GetMRO_EEO_Equipment_Category(ServiceRequestData<MRO_EEO_Equipment_Category_Request> argument);

        //справка за начин на изпълнение в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).
        [OperationContract]
        [Description("Справка за начин на изпълнение в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        [Info(requestXSD: "MRO_EEO_Execution_Type_Request.xsd",
            responseXSD: "MRO_EEO_Execution_Type_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_EEO_Execution_Type_Request.xslt",
            responseXSLT: "MRO_EEO_Execution_Type_Response.xslt")]
        ServiceResultDataSigned<MRO_EEO_Execution_Type_Request, MRO_EEO_Execution_Type_Response> GetMRO_EEO_Execution_Type(ServiceRequestData<MRO_EEO_Execution_Type_Request> argument);

        //справка за търговски марки в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).
        [OperationContract]
        [Description("Справка за търговски марки в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО).")]
        [Info(requestXSD: "MRO_EEO_Trade_Marks_Request.xsd",
            responseXSD: "MRO_EEO_Trade_Marks_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_EEO_Trade_Marks_Request.xslt",
            responseXSLT: "MRO_EEO_Trade_Marks_Response.xslt")]
        ServiceResultDataSigned<MRO_EEO_Trade_Marks_Request,MRO_EEO_Trade_Marks_Response> GetMRO_EEO_Trade_Marks(ServiceRequestData<MRO_EEO_Trade_Marks_Request> argument);
    }
}
