using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvSpcAdapter.AdapterService;

namespace TechnoLogica.RegiX.PvSpcAdapter.Mock
{
    public class PvSpcAdapterMock : BaseAdapterServiceProxy<IPvSpcAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PvSpcAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PvSpcAdapterMock), typeof(IAdapterService))]
        public static IPvSpcAdapter MockExport
        {
            get
            {
                return new PvSpcAdapterMock().Create();
            }
        }
    }
}

