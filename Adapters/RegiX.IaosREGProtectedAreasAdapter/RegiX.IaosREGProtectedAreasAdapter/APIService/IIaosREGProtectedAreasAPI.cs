using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на защитените територии и защитените зони в България")]
    public interface IIaosREGProtectedAreasAPI : IAPIService
    {
        //справка за извличане на площ на защитена територия/ зона в Регистър на защитените територии и зони в България.
        [OperationContract]
        [Description("Справка за извличане на площ на защитена територия/ зона в Регистър на защитените територии и зони в България.")]
        [Info(
            requestXSD: "REG_PAPZ_Protected_Area_Size_Request.xsd",
            responseXSD: "REG_PAPZ_Protected_Area_Size_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG_PAPZ_Protected_Area_Size_Request.xslt",
            responseXSLT: "REG_PAPZ_Protected_Area_Size_Responce.xslt")]
        ServiceResultDataSigned<REG_PAPZ_Protected_Area_Size_Request, REG_PAPZ_Protected_Area_Size_Response> GetREG_PAPZ_Protected_Area_Size(ServiceRequestData<REG_PAPZ_Protected_Area_Size_Request> argument);

        //справка по категория на защитена територия/зона в Регистър на защитените територии и зони в България.
        [OperationContract]
        [Description("Справка по категория на защитена територия/зона в Регистър на защитените територии и зони в България.")]
        [Info(
            requestXSD: "REG_PAPZ_Protected_Area_Category_Request.xsd",
            responseXSD: "REG_PAPZ_Protected_Area_Category_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG_PAPZ_Protected_Area_Category_Request.xslt",
            responseXSLT: "REG_PAPZ_Protected_Area_Category_Responce.xslt")]
        ServiceResultDataSigned<REG_PAPZ_Protected_Area_Category_Request, REG_PAPZ_Protected_Area_Category_Response> GetREG_PAPZ_Protected_Area_Category(ServiceRequestData<REG_PAPZ_Protected_Area_Category_Request> argument);

        //справка местонахождение в Регистър на защитените територии и зони в България.
        [OperationContract]
        [Description("Справка местонахождение в Регистър на защитените територии и зони в България.")]
        [Info(
            requestXSD: "REG_PAPZ_Protected_Area_Location_Request.xsd",
            responseXSD: "REG_PAPZ_Protected_Area_Location_Response.xsd",
            commonXSD: "common_types.xsd",
            requestXSLT: "REG_PAPZ_Protected_Area_Location_Request.xslt",
            responseXSLT: "REG_PAPZ_Protected_Area_Location_Responce.xslt")]
        ServiceResultDataSigned<REG_PAPZ_Protected_Area_Location_Request, REG_PAPZ_Protected_Area_Location_Response> GetREG_PAPZ_Protected_Area_Location(ServiceRequestData<REG_PAPZ_Protected_Area_Location_Request> argument);
    }
}
