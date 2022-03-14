using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCSubscribersAdapter.Mocks
{
    public class CRCSubscribersAdapterMock : BaseAdapterServiceProxy<ICRCSubscribersAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCSubscribersAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCSubscribersAdapterMock), typeof(IAdapterService))]
        public static ICRCSubscribersAdapter MockExport
        {
            get
            {
                return new CRCSubscribersAdapterMock().Create();
            }
        }
    }
}
