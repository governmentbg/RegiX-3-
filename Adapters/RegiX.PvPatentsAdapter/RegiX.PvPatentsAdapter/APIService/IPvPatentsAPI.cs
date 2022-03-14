using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PvPatentsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Патентно ведомство - Държавен регистър на патентите")]
    public interface IPvPatentsAPI : IAPIService
    {
        //Справка по заявителски номер на патент
        [OperationContract]
        [Description("Справка по заявителски номер на патент")]
        [Info(
            requestXSD: "REG_PATENT_App_Number_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_PATENT_App_Number_Reuqest.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getPatentByAppNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_App_Number(ServiceRequestData<getPatentByAppNumType> argument);

        //Справка по име на патент
        [OperationContract]
        [Description("Справка по име на патент")]
        [Info(
            requestXSD: "REG_PATENT_Patent_Name_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_PATENT_Patent_Name_Request.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getPatentsByNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Name(ServiceRequestData<getPatentsByNameType> argument);

        //Справка по притежател на патент
        [OperationContract]
        [Description("Справка по притежател на патент")]
        [Info(
            requestXSD: "REG_PATENT_Patent_Owner_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_PATENT_Patent_Owner_Request.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getPatentByOwnersNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Owner(ServiceRequestData<getPatentByOwnersNameType> argument);

        //Справка по регистрационен номер на патент
        [OperationContract]
        [Description("Справка по регистрационен номер на патент")]
        [Info(
            requestXSD: "REG_PATENT_Reg_Number_Request.xsd",
            responseXSD: "REG_UM_PATENT_PatentDetails_Response.xsd",
            requestXSLT: "REG_PATENT_Reg_Number_Request.xslt",
            responseXSLT: "REG_UM_PATENT_PatentDetails_Response.xslt")]
        ServiceResultDataSigned<getPatentByRegNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Reg_Number(ServiceRequestData<getPatentByRegNumType> argument);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на патент")]
        //ServiceResultData<PatentDetailsType> GetREG_PATENT_Status_App_Date(ServiceRequestData<getPatentsByStatAppDateType> argument);


    }
}
