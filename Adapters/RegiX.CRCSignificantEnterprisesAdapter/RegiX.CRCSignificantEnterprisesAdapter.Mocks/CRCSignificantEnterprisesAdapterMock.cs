using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.Mocks
{
    public class CRCSignificantEnterprisesAdapterMock : BaseAdapterServiceProxy<ICRCSignificantEnterprisesAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCSignificantEnterprisesAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCSignificantEnterprisesAdapterMock), typeof(IAdapterService))]
        public static ICRCSignificantEnterprisesAdapter MockExport
        {
            get
            {
                return new CRCSignificantEnterprisesAdapterMock().Create();
            }
        }
    }
}
