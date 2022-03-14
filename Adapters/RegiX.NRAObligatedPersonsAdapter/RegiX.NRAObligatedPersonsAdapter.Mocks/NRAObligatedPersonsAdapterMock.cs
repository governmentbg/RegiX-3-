using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService;

namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter.Mock
{
    public class NRAObligatedPersonsAdapterMock : BaseAdapterServiceProxy<INRAObligatedPersonsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NRAObligatedPersonsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NRAObligatedPersonsAdapterMock), typeof(IAdapterService))]
        public static INRAObligatedPersonsAdapter MockExport
        {
            get
            {
                return new NRAObligatedPersonsAdapterMock().Create();
            }
        }
    }
}

