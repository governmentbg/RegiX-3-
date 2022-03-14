using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GraoNMAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoNMAdapter.Mock
{
    public class NMAdapterMock : BaseAdapterServiceProxy<INMAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NMAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NMAdapterMock), typeof(IAdapterService))]
        public static INMAdapter MockExport
        {
            get
            {
                return new NMAdapterMock().Create();
            }
        }
    }
}

