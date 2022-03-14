using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MPCriminalRecordsAdapter.AdapterService;

namespace TechnoLogica.RegiX.MPCriminalRecordsAdapter.Mock
{
    public class MPCriminalRecordsAdapterMock : BaseAdapterServiceProxy<ICriminalRecordsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MPCriminalRecordsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MPCriminalRecordsAdapterMock), typeof(IAdapterService))]
        public static ICriminalRecordsAdapter MockExport
        {
            get
            {
                return new MPCriminalRecordsAdapterMock().Create();
            }
        }
    }
}

