using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROTyresAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosMROTyresAdapter.Mock
{
    public class IaosMROTyresAdapterMock : BaseAdapterServiceProxy<IIaosMROTyresAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosMROTyresAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosMROTyresAdapterMock), typeof(IAdapterService))]
        public static IIaosMROTyresAdapter MockExport
        {
            get
            {
                return new IaosMROTyresAdapterMock().Create();
            }
        }
    }
}

