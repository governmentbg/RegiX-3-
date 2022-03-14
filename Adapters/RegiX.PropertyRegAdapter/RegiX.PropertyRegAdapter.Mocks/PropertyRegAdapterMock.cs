using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using System.IO;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PropertyRegAdapter.AdapterService;

namespace TechnoLogica.RegiX.PropertyRegAdapter.Mock
{
    public class PropertyRegAdapterMock : BaseAdapterServiceProxy<IPropertyRegAdapter>
    {
        static PropertyRegAdapterMock()
        {
            RegisterResolver<EntityInfoRequestType, EntityInfoResponseType>(
                (i,r,a,o) => i.GetEntityInfo(r, a, o),
                (r) => ResolveGetEntityInfoFileName(r)
                );
            RegisterResolver<EntityInfoV2RequestType, EntityInfoV2ResponseType>(
                (i, r, a, o) => i.GetEntityInfoV2(r, a, o),
                (r) => ResolveGetEntityInfoV2FileName(r)
                );
            RegisterResolver<PersonInfoRequestType, PersonInfoResponseType>(
                (i, r, a, o) => i.GetPersonInfo(r, a, o),
                (r) => ResolveGetPersonInfoFileName(r)
                );
            RegisterResolver<PersonInfoV2RequestType, PersonInfoV2ResponseType>(
                (i, r, a, o) => i.GetPersonInfoV2(r, a, o),
                (r) => ResolveGetPersonInfoV2FileName(r)
                );
            RegisterResolver<PropertyInfoRequestType, PropertyInfoResponseType>(
                (i, r, a, o) => i.GetPropertyInfo(r, a, o),
                (r) => ResolveGetPropertyInfoFileName(r)
                );
            RegisterResolver<PropertyInfoV2RequestType, PropertyInfoV2ResponseType>(
                (i, r, a, o) => i.GetPropertyInfoV2(r, a, o),
                (r) => ResolveGetPropertyInfoV2FileName(r)
                );
            RegisterResolver<PropertySearchRequestType, PropertySearchResponseType>(
                (i, r, a, o) => i.PropertySearch(r, a, o),
                (r) => ResolvePropertySearchFileName(r)
                );
            RegisterResolver<GetSitesRequestType, GetSitesResponseType>(
                (i, r, a, o) => i.GetSites(r, a, o),
                (r) => ResolveGetSitesFileName(r)
                );
        }

        private static string ResolveGetEntityInfoFileName(EntityInfoRequestType r)
        {
            string fileName = $"{DataFolder}GetEntityInfo{Path.DirectorySeparatorChar}{r?.EIK}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetEntityInfo{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetEntityInfoV2FileName(EntityInfoV2RequestType r)
        {
            string fileName = $"{DataFolder}GetEntityInfoV2{Path.DirectorySeparatorChar}{r?.EIK}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetEntityInfoV2{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetPersonInfoFileName(PersonInfoRequestType r)
        {
            string fileName = $"{DataFolder}GetPersonInfo{Path.DirectorySeparatorChar}{r?.EGN}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetPersonInfo{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetPersonInfoV2FileName(PersonInfoV2RequestType r)
        {
            string fileName = $"{DataFolder}GetPersonInfoV2{Path.DirectorySeparatorChar}{r?.EGN}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetPersonInfoV2{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetPropertyInfoFileName(PropertyInfoRequestType r)
        {
            string fileName = $"{DataFolder}GetPropertyInfo{Path.DirectorySeparatorChar}{r?.PropertyID}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetPropertyInfo{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetPropertyInfoV2FileName(PropertyInfoV2RequestType r)
        {
            string fileName = $"{DataFolder}GetPropertyInfoV2{Path.DirectorySeparatorChar}{r?.PropertyID}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetPropertyInfoV2{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolvePropertySearchFileName(PropertySearchRequestType r)
        {
            string fileName = $"{DataFolder}PropertySearch{Path.DirectorySeparatorChar}{r?.PropertyLot}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}PropertySearch{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetSitesFileName(GetSitesRequestType r)
        {
            return $"{DataFolder}GetSites{Path.DirectorySeparatorChar}default.xml";
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PropertyRegAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PropertyRegAdapterMock), typeof(IAdapterService))]
        public static IPropertyRegAdapter MockExport
        {
            get
            {
                return new PropertyRegAdapterMock().Create();
            }
        }
    }
}

