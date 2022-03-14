using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NoiRPAdapter.AdapterService;

namespace TechnoLogica.RegiX.NoiRPAdapter.Mock
{
    public class NoiRPAdapterMock : BaseAdapterServiceProxy<IRPAdapter>
    {
        static NoiRPAdapterMock()
        {
            RegisterResolver<UP7NewRequestType, UP7NewResponseType>(
               (i, r, a, o) => i.GetPensionTypeAndAmountReportUP7(r, a, o),
               (r) => $"{DataFolder}IRPAdapter.GetPensionTypeAndAmountUP7.response.xml"
           );
        }
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NoiRPAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NoiRPAdapterMock), typeof(IAdapterService))]
        public static IRPAdapter MockExport
        {
            get
            {
                return new NoiRPAdapterMock().Create();
            }
        }
    }
}

