using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCTransferredRightsAdapter.Mocks
{
    public class CRCTransferredRightsAdapterMock : BaseAdapterServiceProxy<ICRCTransferredRightsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCTransferredRightsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCTransferredRightsAdapterMock), typeof(IAdapterService))]
        public static ICRCTransferredRightsAdapter MockExport
        {
            get
            {
                return new CRCTransferredRightsAdapterMock().Create();
            }
        }
    }
}
