using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosMROOilAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара масла по смисъла на § 1, т. 7 от ДР на Наредбата за отработените масла и отпадъчните нефтопродукти, приета с ПМС № 352 от 2012 г. (ДВ, бр. 2 от 2013 г.);")]
    public interface IIaosMROOilAPI : IAPIService
    {
        //Справка за валидност в Регистъра на лицата, които пускат на пазара масла.
        [OperationContract]
        [Description("Справка за валидност в Регистъра на лицата, които пускат на пазара масла.")]
        [Info(
            requestXSD: "MRO_OIL_Validity_Check_Request.xsd",
            responseXSD: "MRO_OIL_Validity_Check_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_OIL_Validity_Check_Request.xslt",
            responseXSLT: "MRO_OIL_Validity_Check_Response.xslt")]
        ServiceResultDataSigned<MRO_OIL_Validity_Check_Request, MRO_OIL_Validity_Check_Response> GetMRO_OIL_Validity_Check(ServiceRequestData<MRO_OIL_Validity_Check_Request> argument);

        //Справка за начин на изпълнение на задълженията в Регистъра на лицата, които пускат на пазара масла.
        [OperationContract]
        [Description("Справка за начин на изпълнение на задълженията в Регистъра на лицата, които пускат на пазара масла.")]
        [Info(
            requestXSD: "MRO_OIL_Execution_Type_Request.xsd",
            responseXSD: "MRO_OIL_Execution_Type_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_OIL_Execution_Type_Request.xslt",
            responseXSLT: "MRO_OIL_Execution_Type_Response.xslt")]
        ServiceResultDataSigned<MRO_OIL_Execution_Type_Request, MRO_OIL_Execution_Type_Response> GetMRO_OIL_Execution_Type(ServiceRequestData<MRO_OIL_Execution_Type_Request> argument);

        //Справка за търговски марки в Регистъра на лицата, които пускат на пазара масла.
        [OperationContract]
        [Description("Справка за търговски марки в Регистъра на лицата, които пускат на пазара масла.")]
        [Info(
            requestXSD: "MRO_OIL_Trade_Marks_Request.xsd",
            responseXSD: "MRO_OIL_Trade_Marks_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_OIL_Trade_Marks_Request.xslt",
            responseXSLT: "MRO_OIL_Trade_Marks_Response.xslt")]
        ServiceResultDataSigned<MRO_OIL_Trade_Marks_Request, MRO_OIL_Trade_Marks_Response> GetMRO_OIL_Trade_Marks(ServiceRequestData<MRO_OIL_Trade_Marks_Request> argument);
    }
}
