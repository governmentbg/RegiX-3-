using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCIOORAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORAdapter.Mocks
{
    public class CRCIOORAdapterMock : BaseAdapterServiceProxy<ICRCIOORAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCIOORAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCIOORAdapterMock), typeof(IAdapterService))]
        public static ICRCIOORAdapter MockExport
        {
            get
            {
                return new CRCIOORAdapterMock().Create();
            }
        }
    }
}
