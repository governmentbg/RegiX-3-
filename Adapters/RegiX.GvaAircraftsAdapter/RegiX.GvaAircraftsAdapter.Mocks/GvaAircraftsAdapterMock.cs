using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using System.IO;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GvaAircraftsAdapter.AdapterService;

namespace TechnoLogica.RegiX.GvaAircraftsAdapter.Mock
{
    public class GvaAircraftsAdapterMock : BaseAdapterServiceProxy<IGvaAircraftsAdapter>
    {
        static GvaAircraftsAdapterMock()
        {


            RegisterResolver<AircraftsByMSNType, AircraftsResponse>(
                (i, r, a, o) => i.GetAircraftsByMSN(r, a, o),
                fileNameResolver:
                    (r) => ResolveGetAircraftsByMSNFileName(r)
            );

            RegisterResolver<AircraftsByOwnerType, AircraftsResponse>(
                (i, r, a, o) => i.GetAircraftsByOwner(r, a, o),
                fileNameResolver:
                    (r) => ResolveGetAircraftsByOwnerFileName(r)
            );

        }


        private static string ResolveGetAircraftsByMSNFileName(AircraftsByMSNType r)
        {
            string argument = r?.MSN ?? "default";
            string fileName = $"{DataFolder}{argument}.xml";
            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}default.xml";
            }
        }

        private static string ResolveGetAircraftsByOwnerFileName(AircraftsByOwnerType r)
        {
            string argument = r?.OwnerID ?? "default";
            string fileName = $"{DataFolder}{argument}.xml";
            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}default.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(GvaAircraftsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(GvaAircraftsAdapterMock), typeof(IAdapterService))]
        public static IGvaAircraftsAdapter MockExport
        {
            get
            {
                return new GvaAircraftsAdapterMock().Create();
            }
        }
    }
}

