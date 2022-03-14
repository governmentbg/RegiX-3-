using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.Mocks
{
    public class CRCIOORGeoPositionAdapterMock : BaseAdapterServiceProxy<ICRCIOORGeoPositionAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCIOORGeoPositionAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCIOORGeoPositionAdapterMock), typeof(IAdapterService))]
        public static ICRCIOORGeoPositionAdapter MockExport
        {
            get
            {
                return new CRCIOORGeoPositionAdapterMock().Create();
            }
        }
    }
}
