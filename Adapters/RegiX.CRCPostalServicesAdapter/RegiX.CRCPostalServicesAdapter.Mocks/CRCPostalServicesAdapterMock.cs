using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCPostalServicesAdapter.Mocks
{
    public class CRCPostalServicesAdapterMock : BaseAdapterServiceProxy<ICRCPostalServicesAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCPostalServicesAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCPostalServicesAdapterMock), typeof(IAdapterService))]
        public static ICRCPostalServicesAdapter MockExport
        {
            get
            {
                return new CRCPostalServicesAdapterMock().Create();
            }
        }
    }
}
