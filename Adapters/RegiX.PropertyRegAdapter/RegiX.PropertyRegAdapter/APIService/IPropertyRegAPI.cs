using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.PropertyRegAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Имотния регистър (Агенция по вписвания)")]
    public interface IPropertyRegAPI : IAPIService
    {
        // Справка по персонална партида на юридическо лице
        [OperationContract]
        [Description("Справка по персонална партида на юридическо лице")]
        [Info(
            requestXSD: "EntityInfoRequest.xsd",
            responseXSD: "EntityInfoResponse.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "EntityInfoRequest.xslt",
            responseXSLT: "EntityInfoResponse.xslt")]
        ServiceResultDataSigned<EntityInfoRequestType, EntityInfoResponseType> GetEntityInfo(ServiceRequestData<EntityInfoRequestType> argument);

        // Справка по персонална партида на юридическо лице - V2
        [OperationContract]
        [Description("Справка по персонална партида на юридическо лице - V2")]
        [Info(
            requestXSD: "EntityInfoV2Request.xsd",
            responseXSD: "EntityInfoV2Response.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "EntityInfoV2Request.xslt",
            responseXSLT: "EntityInfoV2Response.xslt")]
        ServiceResultDataSigned<EntityInfoV2RequestType, EntityInfoV2ResponseType> GetEntityInfoV2(ServiceRequestData<EntityInfoV2RequestType> argument);

        // Справка по персонална партида на физическо лице
        [OperationContract]
        [Description("Справка по персонална партида на физическо лице")]
        [Info(
            requestXSD: "PersonInfoRequest.xsd",
            responseXSD: "PersonInfoResponse.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "PersonInfoRequest.xslt",
            responseXSLT: "PersonInfoResponse.xslt")]
        ServiceResultDataSigned<PersonInfoRequestType, PersonInfoResponseType> GetPersonInfo(ServiceRequestData<PersonInfoRequestType> argument);

        // Справка по персонална партида на физическо лице - V2
        [OperationContract]
        [Description("Справка по персонална партида на физическо лице - V2")]
        [Info(
            requestXSD: "PersonInfoV2Request.xsd",
            responseXSD: "PersonInfoV2Response.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "PersonInfoV2Request.xslt",
            responseXSLT: "PersonInfoV2Response.xslt")]
        ServiceResultDataSigned<PersonInfoV2RequestType, PersonInfoV2ResponseType> GetPersonInfoV2(ServiceRequestData<PersonInfoV2RequestType> argument);

        // Справка по партида на имот
        [OperationContract]
        [Description("Справка по партида на имот")]
        [Info(
            requestXSD: "PropertyInfoRequest.xsd",
            responseXSD: "PropertyInfoResponse.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "PropertyInfoRequest.xslt",
            responseXSLT: "PropertyInfoResponse.xslt")]
        ServiceResultDataSigned<PropertyInfoRequestType, PropertyInfoResponseType> GetPropertyInfo(ServiceRequestData<PropertyInfoRequestType> argument);

        // Справка по партида на имот - V2
        [OperationContract]
        [Description("Справка по партида на имот - V2")]
        [Info(
            requestXSD: "PropertyInfoV2Request.xsd",
            responseXSD: "PropertyInfoV2Response.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "PropertyInfoV2Request.xslt",
            responseXSLT: "PropertyInfoV2Response.xslt")]
        ServiceResultDataSigned<PropertyInfoV2RequestType, PropertyInfoV2ResponseType> GetPropertyInfoV2(ServiceRequestData<PropertyInfoV2RequestType> argument);


        // Търсене на имот
        [OperationContract]
        [Description("Търсене на имот")]
        [Info(
            requestXSD: "PropertySearchRequest.xsd",
            responseXSD: "PropertySearchResponse.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "PropertySearchRequest.xslt",
            responseXSLT: "PropertySearchResponse.xslt")]
        ServiceResultDataSigned<PropertySearchRequestType, PropertySearchResponseType> PropertySearch(ServiceRequestData<PropertySearchRequestType> argument);

        // Справка за службите по вписвания
        [OperationContract]
        [Description("Справка на агенциите по вписвания")]
        [Info(
            requestXSD: "GetSitesRequest.xsd",
            responseXSD: "GetSitesResponse.xsd",
            commonXSD: "PropertyRegCommon.xsd",
            requestXSLT: "GetSitesRequest.xslt",
            responseXSLT: "GetSitesResponse.xslt")]
        ServiceResultDataSigned<GetSitesRequestType, GetSitesResponseType> GetSites(ServiceRequestData<GetSitesRequestType> argument);
    }
}
