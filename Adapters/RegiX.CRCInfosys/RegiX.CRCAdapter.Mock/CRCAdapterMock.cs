using Infosys.RegiX.CRCAdapter.AdapterService;
using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;

namespace RegiX.CRCAdapter.Mock
{
    public class CRCAdapterMock : BaseAdapterServiceProxy<ICRCAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCAdapterMock), typeof(IAdapterService))]
        public static ICRCAdapter MockExport
        {
            get
            {
                return new CRCAdapterMock().Create();
            }
        }
    }
}
