using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.PropertyRegAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Имотен регистър")]
    public interface IPropertyRegAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по персонална партида на юридическо лице")]
        CommonSignedResponse<EntityInfoRequestType, EntityInfoResponseType> GetEntityInfo(EntityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по персонална партида на юридическо лице - V2")]
        CommonSignedResponse<EntityInfoV2RequestType, EntityInfoV2ResponseType> GetEntityInfoV2(EntityInfoV2RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по персонална партида на физическо лице")]
        CommonSignedResponse<PersonInfoRequestType, PersonInfoResponseType> GetPersonInfo(PersonInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по персонална партида на физическо лице - V2")]
        CommonSignedResponse<PersonInfoV2RequestType, PersonInfoV2ResponseType> GetPersonInfoV2(PersonInfoV2RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по партида на имот")]
        CommonSignedResponse<PropertyInfoRequestType, PropertyInfoResponseType> GetPropertyInfo(PropertyInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по партида на имот - V2")]
        CommonSignedResponse<PropertyInfoV2RequestType, PropertyInfoV2ResponseType> GetPropertyInfoV2(PropertyInfoV2RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Търсене на имот")]
        CommonSignedResponse<PropertySearchRequestType, PropertySearchResponseType> PropertySearch(PropertySearchRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка на агенциите по вписвания")]
        CommonSignedResponse<GetSitesRequestType, GetSitesResponseType> GetSites(GetSitesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
