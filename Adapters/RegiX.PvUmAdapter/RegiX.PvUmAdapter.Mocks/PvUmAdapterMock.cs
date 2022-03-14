using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvUmAdapter.AdapterService;

namespace TechnoLogica.RegiX.PvUmAdapter.Mock
{
    public class PvUmAdapterMock : BaseAdapterServiceProxy<IPvUmAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PvUmAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PvUmAdapterMock), typeof(IAdapterService))]
        public static IPvUmAdapter MockExport
        {
            get
            {
                return new PvUmAdapterMock().Create();
            }
        }
    }
}

