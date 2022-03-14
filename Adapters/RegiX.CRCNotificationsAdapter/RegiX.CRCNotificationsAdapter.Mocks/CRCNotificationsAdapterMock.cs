using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNotificationsAdapter.Mocks
{
    public class CRCNotificationsAdapterMock : BaseAdapterServiceProxy<ICRCNotificationsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCNotificationsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCNotificationsAdapterMock), typeof(IAdapterService))]
        public static ICRCNotificationsAdapter MockExport
        {
            get
            {
                return new CRCNotificationsAdapterMock().Create();
            }
        }
    }
}
