using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNumbersAdapter.Mocks
{
    public class CRCNumbersAdapterMock : BaseAdapterServiceProxy<ICRCNumbersAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCNumbersAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCNumbersAdapterMock), typeof(IAdapterService))]
        public static ICRCNumbersAdapter MockExport
        {
            get
            {
                return new CRCNumbersAdapterMock().Create();
            }
        }
    }
}
