using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PVGeoAdapter.AdapterService;

namespace TechnoLogica.RegiX.PVGeoAdapter.Mock
{
    public class PVGeoAdapterMock : BaseAdapterServiceProxy<IPVGeoAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PVGeoAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PVGeoAdapterMock), typeof(IAdapterService))]
        public static IPVGeoAdapter MockExport
        {
            get
            {
                return new PVGeoAdapterMock().Create();
            }
        }
    }
}

