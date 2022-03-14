using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvMarksAdapter.AdapterService;

namespace TechnoLogica.RegiX.PvMarksAdapter.Mock
{
    public class PvMarksAdapterMock : BaseAdapterServiceProxy<IPvMarksAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PvMarksAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PvMarksAdapterMock), typeof(IAdapterService))]
        public static IPvMarksAdapter MockExport
        {
            get
            {
                return new PvMarksAdapterMock().Create();
            }
        }
    }
}

