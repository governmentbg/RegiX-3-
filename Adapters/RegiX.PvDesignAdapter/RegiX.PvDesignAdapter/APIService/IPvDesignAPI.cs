using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PvDesignAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Патентно ведомство - Държавен регистър на промишлените дизайни")]
    public interface IPvDesignAPI : IAPIService
    {
        //Справка по регистрационен номер на промишлен дизайн
        [OperationContract]
        [Description("Справка по регистрационен номер на промишлен дизайн")]
        [Info(
            requestXSD: "REG_DESIGN_App_Number_Request.xsd",
            responseXSD: "REG_DESIGN_DesignDetails_Response.xsd",
            requestXSLT: "REG_DESIGN_App_Number_Request.xslt",
            responseXSLT: "REG_DESIGN_DesignDetails_Response.xslt")]
        ServiceResultDataSigned<GetDesignByAppNumType, DesignDetailsType> GetREG_DESIGN_App_Number(ServiceRequestData<GetDesignByAppNumType> argument);

        //Справка по име на промишлен дизайн
        [OperationContract]
        [Description("Справка по име на промишлен дизайн")]
        [Info(
            requestXSD: "REG_DESIGN_Name_Request.xsd",
            responseXSD: "REG_DESIGN_DesignDetails_Response.xsd",
            requestXSLT: "REG_DESIGN_Name_Request.xslt",
            responseXSLT: "REG_DESIGN_DesignDetails_Response.xslt")]
        ServiceResultDataSigned<GetDesignsByNameType, DesignDetailsType> GetREG_DESIGN_Name(ServiceRequestData<GetDesignsByNameType> argument);

        //Справка по притежател на промишлен дизайн
        [OperationContract]
        [Description("Справка по притежател на промишлен дизайн")]
        [Info(
            requestXSD: "REG_DESIGN_Owner_Name_Request.xsd",
            responseXSD: "REG_DESIGN_DesignDetails_Response.xsd",
            requestXSLT: "REG_DESIGN_Owner_Name_Reuqest.xslt",
            responseXSLT: "REG_DESIGN_DesignDetails_Response.xslt")]
        ServiceResultDataSigned<GetDesignByOwnersNameType, DesignDetailsType> GetREG_DESIGN_Owner_Name(ServiceRequestData<GetDesignByOwnersNameType> argument);
 
        //Справка по регистрационен номер на промишлен дизайн
        [OperationContract]
        [Description("Справка по регистрационен номер на промишлен дизайн")]
        [Info(
            requestXSD: "REG_DESIGN_Reg_Number_Request.xsd",
            responseXSD: "REG_DESIGN_DesignDetails_Response.xsd",
            requestXSLT: "REG_DESIGN_Reg_Number_Request.xslt",
            responseXSLT: "REG_DESIGN_DesignDetails_Response.xslt")]
        ServiceResultDataSigned<GetDesignByRegNumType, DesignDetailsType> GetREG_DESIGN_Reg_Number(ServiceRequestData<GetDesignByRegNumType> argument);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на промишлен дизайн")]
        //ServiceResultData<REG_DESIGN_Stat_App_Name_ResponseType> GetREG_DESIGN_Stat_App_Name(ServiceRequestData<REG_DESIGN_Stat_App_Name_RequestType> argument);


    }
}
