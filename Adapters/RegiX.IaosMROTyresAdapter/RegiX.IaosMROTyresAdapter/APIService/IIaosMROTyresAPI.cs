using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosMROTyresAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара гуми;")]
    public interface IIaosMROTyresAPI : IAPIService
    {
        //Справка за валидност в Регистъра на лицата, които пускат на пазара гуми.
        [OperationContract]
        [Description("Справка за валидност в Регистъра на лицата, които пускат на пазара гуми.")]
        [Info(
            requestXSD: "MRO_TYRES_Validity_Check_Request.xsd",
            responseXSD: "MRO_TYRES_Validity_Check_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_TYRES_Validity_Check_Request.xslt",
            responseXSLT: "MRO_TYRES_Validity_Check_Response.xslt")]
        ServiceResultDataSigned<MRO_TYRES_Validity_Check_Request, MRO_TYRES_Validity_Check_Response> GetMRO_TYRES_Validity_Check(ServiceRequestData<MRO_TYRES_Validity_Check_Request> argument);

        //справка за начин на изпълнение на задълженията в Регистъра на лицата, които пускат на пазара гуми.
        [OperationContract]
        [Description("Справка за начин на изпълнение на задълженията в Регистъра на лицата, които пускат на пазара гуми.")]
        [Info(
            requestXSD: "MRO_TYRES_Execution_Type_Request.xsd",
            responseXSD: "MRO_TYRES_Execution_Type_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_TYRES_Execution_Type_Request.xslt",
            responseXSLT: "MRO_TYRES_Execution_Type_Response.xslt")]
        ServiceResultDataSigned<MRO_TYRES_Execution_Type_Request, MRO_TYRES_Execution_Type_Response> GetMRO_TYRES_Execution_Type(ServiceRequestData<MRO_TYRES_Execution_Type_Request> argument);
        
        //Справка за търговски марки в Регистъра на лицата, които пускат на пазара гуми.
        [OperationContract]
        [Description("Справка за търговски марки в Регистъра на лицата, които пускат на пазара гуми.")]
        [Info(
            requestXSD: "MRO_TYRES_Trade_Marks_Request.xsd",
            responseXSD: "MRO_TYRES_Trade_Marks_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_TYRES_Trade_Marks_Request.xslt",
            responseXSLT: "MRO_TYRES_Trade_Marks_Response.xslt")]
        ServiceResultDataSigned<MRO_TYRES_Trade_Marks_Request, MRO_TYRES_Trade_Marks_Response> GetMRO_TYRES_Trade_Marks(ServiceRequestData<MRO_TYRES_Trade_Marks_Request> argument);
    }
}
