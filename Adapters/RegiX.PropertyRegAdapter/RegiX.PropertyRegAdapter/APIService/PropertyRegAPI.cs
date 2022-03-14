using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.PropertyRegAdapter.AdapterService;

namespace TechnoLogica.RegiX.PropertyRegAdapter.APIService
{
    [ExportFullName(typeof(IPropertyRegAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PropertyRegAPI : BaseAPIService<IPropertyRegAPI>, IPropertyRegAPI
    {
        public ServiceResultDataSigned<EntityInfoRequestType, EntityInfoResponseType> GetEntityInfo(ServiceRequestData<EntityInfoRequestType> argument)
        {
            return  AdapterClient.Execute<IPropertyRegAdapter, EntityInfoRequestType, EntityInfoResponseType>(
                        (i, r, a, o) => i.GetEntityInfo(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<EntityInfoV2RequestType, EntityInfoV2ResponseType> GetEntityInfoV2(ServiceRequestData<EntityInfoV2RequestType> argument)
        {
            return AdapterClient.Execute<IPropertyRegAdapter, EntityInfoV2RequestType, EntityInfoV2ResponseType>(
                        (i, r, a, o) => i.GetEntityInfoV2(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<PersonInfoRequestType, PersonInfoResponseType> GetPersonInfo(ServiceRequestData<PersonInfoRequestType> argument)
        {
            return AdapterClient.Execute<IPropertyRegAdapter, PersonInfoRequestType, PersonInfoResponseType>(
                        (i, r, a, o) => i.GetPersonInfo(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<PersonInfoV2RequestType, PersonInfoV2ResponseType> GetPersonInfoV2(ServiceRequestData<PersonInfoV2RequestType> argument)
        {
            return AdapterClient.Execute<IPropertyRegAdapter, PersonInfoV2RequestType, PersonInfoV2ResponseType>(
                        (i, r, a, o) => i.GetPersonInfoV2(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<PropertyInfoRequestType, PropertyInfoResponseType> GetPropertyInfo(ServiceRequestData<PropertyInfoRequestType> argument)
        {
            return  AdapterClient.Execute<IPropertyRegAdapter, PropertyInfoRequestType, PropertyInfoResponseType>(
                        (i, r, a, o) => i.GetPropertyInfo(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<PropertyInfoV2RequestType, PropertyInfoV2ResponseType> GetPropertyInfoV2(ServiceRequestData<PropertyInfoV2RequestType> argument)
        {
            return AdapterClient.Execute<IPropertyRegAdapter, PropertyInfoV2RequestType, PropertyInfoV2ResponseType>(
                        (i, r, a, o) => i.GetPropertyInfoV2(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<PropertySearchRequestType, PropertySearchResponseType> PropertySearch(ServiceRequestData<PropertySearchRequestType> argument)
        {
            return  AdapterClient.Execute<IPropertyRegAdapter, PropertySearchRequestType, PropertySearchResponseType>(
                        (i, r, a, o) => i.PropertySearch(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<GetSitesRequestType, GetSitesResponseType> GetSites(ServiceRequestData<GetSitesRequestType> argument)
        {
            return AdapterClient.Execute<IPropertyRegAdapter, GetSitesRequestType, GetSitesResponseType>(
                        (i, r, a, o) => i.GetSites(r, a, o),
                        argument);
        }
    }
}
