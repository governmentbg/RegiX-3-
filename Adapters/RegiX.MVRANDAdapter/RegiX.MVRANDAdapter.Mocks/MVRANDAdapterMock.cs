using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MVRANDAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRANDAdapter.Mock
{
    public class MVRANDAdapterMock : BaseAdapterServiceProxy<IMVRANDAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MVRANDAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MVRANDAdapterMock), typeof(IAdapterService))]
        public static IMVRANDAdapter MockExport
        {
            get
            {
                return new MVRANDAdapterMock().Create();
            }
        }
    }
}

