using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosMRABagsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на лицата, които пускат на пазара полимерни торбички")]
    public interface IIaosMRABagsAPI : IAPIService
    {
        //Справка по регистрационен номер в Регистъра на лицата, които пускат на пазара полимерни торбички
        [OperationContract]
        [Description("Справка по регистрационен номер в Регистъра на лицата, които пускат на пазара полимерни торбички")]
        [Info(
            requestXSD: "MRO_BAGS_Reg_Number_Date_Request.xsd",
            responseXSD: "MRO_BAGS_Reg_Number_Date_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_BAGS_Reg_Number_Date_Request.xslt",
            responseXSLT: "MRO_BAGS_Reg_Number_Date_Response.xslt")]
        ServiceResultDataSigned <MRO_BAGS_Reg_Number_Date_Request, MRO_BAGS_Reg_Number_Date_Response> GetMRA_BAGS_Reg_Number_Date(ServiceRequestData<MRO_BAGS_Reg_Number_Date_Request> argument);

        //Справка за валидност в Регистъра на лицата, които пускат на пазара полимерни торбички
        [OperationContract]
        [Description("Справка за валидност в Регистъра на лицата, които пускат на пазара полимерни торбички")]
        [Info(
            requestXSD: "MRO_BAGS_Validity_Check_Request.xsd",
            responseXSD: "MRO_BAGS_Validity_Check_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_BAGS_Validity_Check_Request.xslt",
            responseXSLT: "MRO_BAGS_Validity_Check_Response.xslt")]
        ServiceResultDataSigned<MRO_BAGS_Validity_Check_Request, MRO_BAGS_Validity_Check_Response> GetMRO_BAGS_Validity_Check(ServiceRequestData<MRO_BAGS_Validity_Check_Request> argument);


        //Справка по регистрационен номер в Регистъра на лицата, които пускат на пазара полимерни торбички
        [OperationContract]
        [Description("Справка по регистрационен номер в Регистъра на лицата, които пускат на пазара полимерни торбички")]
        [Info(
            requestXSD: "MRO_BAGS_Reg_Number_Request.xsd",
            responseXSD: "MRO_BAGS_Reg_Number_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "MRO_BAGS_Reg_Number_Request.xslt",
            responseXSLT: "MRO_BAGS_Reg_Number_Response.xslt")]
        ServiceResultDataSigned<MRO_BAGS_Reg_Number_Request, MRO_BAGS_Reg_Number_Response> GetMRO_BAGS_Reg_Number (ServiceRequestData<MRO_BAGS_Reg_Number_Request> argument);
    }
}
