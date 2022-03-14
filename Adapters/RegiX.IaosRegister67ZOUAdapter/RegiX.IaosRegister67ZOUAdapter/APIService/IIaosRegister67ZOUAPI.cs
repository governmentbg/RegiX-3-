using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosRegister67ZOUAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие, и регистрационните документи по чл. 78 ЗУО, в т.ч. на тези от тях с прекратено действие")]
    public interface IIaosRegister67ZOUAPI : IAPIService
    {
        //Справка по ЕИК в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка по ЕИК в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие.")]
        [Info(
            requestXSD: "REG35_Info_By_EIK_Request.xsd",
            responseXSD: "REG35_Info_By_EIK_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG35_Info_By_EIK_Request.xslt",
            responseXSLT: "REG35_Info_By_EIK_Response.xslt")]
        ServiceResultDataSigned <REG35_Info_By_EIK_Request, REG35_Info_By_EIK_Response> GetREG35_Info_By_EIK(ServiceRequestData<REG35_Info_By_EIK_Request> argument);

        //справка за проверка за валидност на решения по период в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка за проверка за валидност на решения по период в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие.")]
        [Info(
            requestXSD: "REG35_License_Validity_Check_Request.xsd",
            responseXSD: "REG35_License_Validity_Check_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG35_License_Validity_Check_Request.xslt",
            responseXSLT: "REG35_License_Validity_Check_Response.xslt")]
        ServiceResultDataSigned<REG35_License_Validity_Check_Request, REG35_License_Validity_Check_Response> GetREG35_License_Validity_Check(ServiceRequestData<REG35_License_Validity_Check_Request> argument);

        //справка за търсене на площадки по населено място в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка за търсене на площадки по населено място в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие.")]
        [Info(
            requestXSD: "REG35_Stage_Info_By_Pop_Name_Request.xsd",
            responseXSD: "REG35_Stage_Info_By_Pop_Name_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG35_Stage_Info_By_Pop_Name_Request.xslt",
            responseXSLT: "REG35_Stage_Info_By_Pop_Name_Response.xslt")]
        ServiceResultDataSigned<REG35_Stage_Info_By_Pop_Name_Request, REG35_Stage_Info_By_Pop_Name_Response> GetREG35_Stage_Info_By_Pop_Name(ServiceRequestData<REG35_Stage_Info_By_Pop_Name_Request> argument);

        //справка за извличане на информация за площадки по операция с отпадък в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка за извличане на информация за площадки по операция с отпадък в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие.")]
        [Info(
            requestXSD: "REG35_Stage_Info_By_Waste_Code_Request.xsd",
            responseXSD: "REG35_Stage_Info_By_Waste_Code_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG35_Stage_Info_By_Waste_Code_Request.xslt",
            responseXSLT: "REG35_Stage_Info_By_Waste_Code_Response.xslt")]
        ServiceResultDataSigned<REG35_Stage_Info_By_Waste_Code_Request, REG35_Stage_Info_By_Waste_Code_Response> GetREG35_Stage_Info_By_Waste_Code(ServiceRequestData<REG35_Stage_Info_By_Waste_Code_Request> argument);

        //справка за площадки по код на отпадъка в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие. Съдържа данни за входните параментри за селекция на данните.
        [OperationContract]
        [Description("Справка за площадки по код на отпадъка в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие.")]
        [Info(
            requestXSD: "REG35_Stages_By_Reg_Number_And_Waste_Code_Request.xsd",
            responseXSD: "REG35_Stages_By_Reg_Number_And_Waste_Code_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG35_Stages_By_Reg_Number_And_Waste_Code_Request.xslt",
            responseXSLT: "REG35_Stages_By_Reg_Number_And_Waste_Code_Response.xslt")]
        ServiceResultDataSigned<REG35_Stages_By_Reg_Number_And_Waste_Code_Request, REG35_Stages_By_Reg_Number_And_Waste_Code_Response> GetREG35_Stages_By_Reg_Number_And_Waste_Code(ServiceRequestData<REG35_Stages_By_Reg_Number_And_Waste_Code_Request> argument);

        //Справка за валидност по номер на документ в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие.
        [OperationContract]
        [Description("Справка за валидност по номер на документ в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие.")]
        [Info(
            requestXSD: "REG35_Validity_Check_By_Reg_Number_Request.xsd",
            responseXSD: "REG35_Validity_Check_By_Reg_Number_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG35_Validity_Check_By_Reg_Number_Request.xslt",
            responseXSLT: "REG35_Validity_Check_By_Reg_Number_Response.xslt")]
        ServiceResultDataSigned<REG35_Validity_Check_By_Reg_Number_Request, REG35_Validity_Check_By_Reg_Number_Response> GetREG35_Validity_Check_By_Reg_Number(ServiceRequestData<REG35_Validity_Check_By_Reg_Number_Request> argument);
    }
}
