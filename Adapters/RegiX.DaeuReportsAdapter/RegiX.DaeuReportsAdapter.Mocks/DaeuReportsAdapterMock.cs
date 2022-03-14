using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.DaeuReportsAdapter.AdapterService;

namespace TechnoLogica.RegiX.DaeuReportsAdapter.Mocks
{
    public class DaeuReportsAdapterMock : BaseAdapterServiceProxy<IDaeuReportsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(DaeuReportsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(DaeuReportsAdapterMock), typeof(IAdapterService))]
        public static IDaeuReportsAdapter MockExport
        {
            get
            {
                return new DaeuReportsAdapterMock().Create();
            }
        }
    }
}
