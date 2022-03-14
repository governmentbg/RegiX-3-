using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMRABagsAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosMRABagsAdapter.Mock
{
    public class IaosMRABagsAdapterMock : BaseAdapterServiceProxy<IIaosMRABagsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosMRABagsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosMRABagsAdapterMock), typeof(IAdapterService))]
        public static IIaosMRABagsAdapter MockExport
        {
            get
            {
                return new IaosMRABagsAdapterMock().Create();
            }
        }
    }
}

