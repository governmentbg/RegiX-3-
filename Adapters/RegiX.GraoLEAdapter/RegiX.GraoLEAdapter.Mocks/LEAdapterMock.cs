using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GraoLEAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoLEAdapter.Mock
{
    public class LEAdapterMock : BaseAdapterServiceProxy<ILEAdapter>
    {
        static LEAdapterMock()
        {
            RegisterResolver<LocationsRequestType, LocationsResponseType>(
                (i, r, a, o) => i.LocationsSearch(r, a, o),
                fileNameResolver:
                    (r) => ResolveLocationsSearch(r)
            );
        }

        private static string ResolveLocationsSearch(LocationsRequestType r)
        {
            if (r != null && r.StartDate.Equals(new DateTime(1900, 1, 1)))
            {
                return $"{DataFolder}LocationsResponse.xml";
            }
            else
            {
                return $"{DataFolder}LocationsResponse2.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(LEAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(LEAdapterMock), typeof(IAdapterService))]
        public static ILEAdapter MockExport
        {
            get
            {
                return new LEAdapterMock().Create();
            }
        }
    }
}

