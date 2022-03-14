using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCIOORNumbersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORNumbersAdapter.Mocks
{
    public class CRCIOORNumbersAdapterMock : BaseAdapterServiceProxy<ICRCIOORNumbersAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCIOORNumbersAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCIOORNumbersAdapterMock), typeof(IAdapterService))]
        public static ICRCIOORNumbersAdapter MockExport
        {
            get
            {
                return new CRCIOORNumbersAdapterMock().Create();
            }
        }
    }
}
