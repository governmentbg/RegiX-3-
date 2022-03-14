using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvPatentsAdapter.AdapterService;

namespace TechnoLogica.RegiX.PvPatentsAdapter.Mock
{
    public class PvPatentsAdapterMock : BaseAdapterServiceProxy<IPvPatentsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PvPatentsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PvPatentsAdapterMock), typeof(IAdapterService))]
        public static IPvPatentsAdapter MockExport
        {
            get
            {
                return new PvPatentsAdapterMock().Create();
            }
        }
    }
}

