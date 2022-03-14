using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PvUmAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Патентно ведомство - Държавен регистър на сертификатите за допълнителна закрила")]
    public interface IPvUmAPI : IAPIService
    {
        //Справка по заявителски номер на полезен модел
        [OperationContract]
        [Description("Справка по заявителски номер на полезен модел")]
        [Info(
            requestXSD: "REG_UM_App_Number_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_UM_App_Number_Request.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getUtilityModelByAppNumType, PatentDetailsType> GetREG_UM_App_Number(ServiceRequestData<getUtilityModelByAppNumType> argument);

        //Справка по име на полезен модел
        [OperationContract]
        [Description("Справка по име на полезен модел")]
        [Info(
            requestXSD: "REG_UM_Name_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_UM_Name_Reuquest.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getUtilityModelByNameType, PatentDetailsType> GetREG_UM_Name(ServiceRequestData<getUtilityModelByNameType> argument);

        //Справка по притежател на полезен модел
        [OperationContract]
        [Description("Справка по притежател на полезен модел")]
        [Info(
            requestXSD: "REG_UM_Owner_Name_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_UM_Owner_Name_Request.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getUtilityModelByOwnersNameType, PatentDetailsType> GetREG_UM_Owner_Name(ServiceRequestData<getUtilityModelByOwnersNameType> argument);

        //Справка по регистрационен номер на полезен модел
        [OperationContract]
        [Description("Справка по регистрационен номер на полезен модел")]
        [Info(
            requestXSD: "REG_UM_Reg_Number_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_UM_Reg_Number_Request.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getUtilityModelByRegNumType, PatentDetailsType> GetREG_UM_Reg_Number(ServiceRequestData<getUtilityModelByRegNumType> argument);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на полезен модел")]
        //ServiceResultData<getUtilityModelByRegNumType> GetREG_UM_Stat_App_Date(ServiceRequestData<PvUmServiceReference.getUtilityModelByRegNumType> argument);
    }
}
