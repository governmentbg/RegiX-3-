using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.ChNTsAdapter.AdapterService;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.ChNTsAdapter.Mocks
{
    public class ChNTsAdapterMock : BaseAdapterServiceProxy<IChNTsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(ChNTsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(ChNTsAdapterMock), typeof(IAdapterService))]
        public static IChNTsAdapter MockExport
        {
            get
            {
                return new ChNTsAdapterMock().Create();
            }
        }
    }
}
