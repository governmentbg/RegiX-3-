using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CROZAdapter.AdapterService;

namespace TechnoLogica.RegiX.CROZAdapter.Mocks
{
    public class CROZAdapterMock : BaseAdapterServiceProxy<ICROZAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CROZAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CROZAdapterMock), typeof(IAdapterService))]
        public static ICROZAdapter MockExport
        {
            get
            {
                return new CROZAdapterMock().Create();
            }
        }
    }
}
