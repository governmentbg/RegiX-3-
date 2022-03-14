using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PvSpcAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Патентно ведомство - Държавен регистър на сертификатите за допълнителна закрила")]
    public interface IPvSpcAPI : IAPIService
    {
        //Справка по заявителски номер на сертификат за допълнителна закрила
        [OperationContract]
        [Description("Справка по заявителски номер на сертификат за допълнителна закрила")]
        [Info(
            requestXSD: "REG_SPC_App_Number_Request.xsd",
            responseXSD: "REG_SPC_Details_Response.xsd",
            requestXSLT: "REG_SPC_App_Number_Request.xslt",
            responseXSLT: "REG_SPC_Details_Response.xslt")]
        ServiceResultDataSigned<getSPCByPatentAppNumType, SPCDetailsType> GetREG_SPC_App_Number(ServiceRequestData<getSPCByPatentAppNumType> argument);

        //Справка по притежател на сертификат за допълнителна закрила
        [OperationContract]
        [Description("Справка по притежател на сертификат за допълнителна закрила")]
        [Info(
            requestXSD: "REG_SPC_Owner_Request.xsd",
            responseXSD: "REG_SPC_Details_Response.xsd",
            requestXSLT: "REG_SPC_Owner_Request.xslt",
            responseXSLT: "REG_SPC_Details_Response.xslt")]
        ServiceResultDataSigned<getSPCByOwnersNameType, SPCDetailsType> GetREG_SPC_Owner(ServiceRequestData<getSPCByOwnersNameType> argument);

        [OperationContract]
        [Description("Справка по регистрационен номер на сертификат за допълнителна закрила")]
        [Info(
            requestXSD: "REG_SPC_Reg_Number_Request.xsd",
            responseXSD: "REG_SPC_Details_Response.xsd",
            requestXSLT: "REG_SPC_Reg_Number_Request.xslt",
            responseXSLT: "REG_SPC_Details_Response.xslt")]
        ServiceResultDataSigned<getSPCByAppNumType, SPCDetailsType> GetREG_SPC_Reg_Number(ServiceRequestData<getSPCByAppNumType> argument);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на сертификат за допълнителна закрила")]
        //ServiceResultData<SPCDetailsType> GetREG_SPC_Stat_App_Date(ServiceRequestData<SPCDetailsType> argument);
    }
}
