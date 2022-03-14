using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosREG35Adapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА;")]
    public interface IIaosREG35API : IAPIService
    {
        //справка за проверка за период на валидност на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА по РИОСВ в Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка за проверка за период на валидност на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА по РИОСВ в Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА.")]
        [Info(requestXSD: "REG35_Stages_Validity_Period_Request.xsd",
              responseXSD: "REG35_Stages_Validity_Period_Response.xsd",
              commonXSD: "common_types.xsd",
              requestXSLT: "REG35_Stages_Validity_Period_Request.xslt",
              responseXSLT: "REG35_Stages_Validity_Period_Response.xslt")]
        ServiceResultDataSigned<REG35_Stages_Validity_Period_Request, REG35_Stages_Validity_Period_Response> GetREG35_Stages_Validity_Period(ServiceRequestData<REG35_Stages_Validity_Period_Request> argument);

        //справка за разрешени кодове на отпадъци от дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка за разрешени кодове на отпадъци от дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА.")]
        [Info(requestXSD: "REG35_Allowed_Waste_Codes_Request.xsd", 
              responseXSD: "REG35_Allowed_Waste_Codes_Response.xsd",
              commonXSD: "common_types.xsd",
              requestXSLT: "REG35_Allowed_Waste_Codes_Request.xslt",
              responseXSLT: "REG35_Allowed_Waste_Codes_Response.xslt")]
        ServiceResultDataSigned <REG35_Allowed_Waste_Codes_Request, REG35_Allowed_Waste_Codes_Response> GetREG35_Allowed_Waste_Codes(ServiceRequestData<REG35_Allowed_Waste_Codes_Request> argument);

        //справка по код на отпадък и операция с отпадък на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА в Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка по код на отпадък и операция с отпадък на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА в Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА.")]
        [Info(requestXSD: "REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request.xsd",
              responseXSD: "REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response.xsd",
              commonXSD: "common_types.xsd",
              requestXSLT: "REG35_Licenses_By_EIK_Waste_Operation_Request.xslt",
              responseXSLT: "REG35_Licenses_By_EIK_Waste_Operation_Response.xslt")]
        ServiceResultDataSigned <REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request,REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response> GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation(ServiceRequestData<REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request> argument);

        //Справка за търсене на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА в Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА
        [OperationContract]
        [Description("Справка за търсене на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА в Регистър на площадки за дейности с ОЧЦМ, ИУЕЕО, ИУМПС и НУБА")]
        [Info(requestXSD: "REG35_Stages_By_Auth_Num_Request.xsd",
              responseXSD: "REG35_Stages_By_Auth_Num_Response.xsd",
              commonXSD: "common_types.xsd",
              requestXSLT: "REG35_Stages_By_Auth_Num_Request.xslt",
              responseXSLT: "REG35_Stages_By_Auth_Num_Response.xslt")]
        ServiceResultDataSigned<REG35_Stages_By_Auth_Num_Request, REG35_Stages_By_Auth_Num_Response> GetREG35_Stages_By_Auth_Num(ServiceRequestData<REG35_Stages_By_Auth_Num_Request> argument);
    }
}
