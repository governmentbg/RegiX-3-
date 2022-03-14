using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.AdapterService;

namespace TechnoLogica.RegiX.NCPRMedicinalProductsAdapter.Mocks
{
    public class NCPRMedicinalProductsAdapterMock : BaseAdapterServiceProxy<INCPRMedicinalProductsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NCPRMedicinalProductsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NCPRMedicinalProductsAdapterMock), typeof(IAdapterService))]
        public static INCPRMedicinalProductsAdapter MockExport
        {
            get
            {
                return new NCPRMedicinalProductsAdapterMock().Create();
            }
        }
    }
}
