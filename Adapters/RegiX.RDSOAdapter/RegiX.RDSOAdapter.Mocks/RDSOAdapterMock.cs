using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.RDSOAdapter.AdapterService;

namespace TechnoLogica.RegiX.RDSOAdapter.Mock
{
    public class RDSOAdapterMock : BaseAdapterServiceProxy<IRDSOAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(RDSOAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(RDSOAdapterMock), typeof(IAdapterService))]
        public static IRDSOAdapter MockExport
        {
            get
            {
                return new RDSOAdapterMock().Create();
            }
        }
    }
}

