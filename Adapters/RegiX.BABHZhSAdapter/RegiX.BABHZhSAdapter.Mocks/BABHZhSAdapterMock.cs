using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.BABHZhSAdapter.AdapterService;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.BABHZhSAdapter.Mocks
{
    public class BABHZhSAdapterMock : BaseAdapterServiceProxy<IBABHZhSAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(BABHZhSAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(BABHZhSAdapterMock), typeof(IAdapterService))]
        public static IBABHZhSAdapter MockExport
        {
            get
            {
                return new BABHZhSAdapterMock().Create();
            }
        }
    }
}
