using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MVRMPSAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRMPSAdapter.Mock
{
    public class MVRMPSAdapterMock : BaseAdapterServiceProxy<IMVRMPSAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MVRMPSAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MVRMPSAdapterMock), typeof(IAdapterService))]
        public static IMVRMPSAdapter MockExport
        {
            get
            {
                return new MVRMPSAdapterMock().Create();
            }
        }
    }
}

