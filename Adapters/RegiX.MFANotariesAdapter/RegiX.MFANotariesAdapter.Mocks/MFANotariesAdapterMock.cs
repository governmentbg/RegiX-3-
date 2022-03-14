using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MFANotariesAdapter.AdapterService;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Mocks
{
    public class MFANotariesAdapterMock: BaseAdapterServiceProxy<IMFANotariesAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MFANotariesAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MFANotariesAdapterMock), typeof(IAdapterService))]
        public static IMFANotariesAdapter MockExport
        {
            get
            {
                return new MFANotariesAdapterMock().Create();
            }
        }
    }
}
