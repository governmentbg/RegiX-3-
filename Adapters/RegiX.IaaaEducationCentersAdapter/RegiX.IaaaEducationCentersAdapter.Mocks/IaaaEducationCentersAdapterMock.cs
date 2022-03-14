using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaaaEducationCentersAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaaaEducationCentersAdapter.Mock
{
    public class IaaaEducationCentersAdapterMock : BaseAdapterServiceProxy<IIaaaEducationCentersAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaaaEducationCentersAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaaaEducationCentersAdapterMock), typeof(IAdapterService))]
        public static IIaaaEducationCentersAdapter MockExport
        {
            get
            {
                return new IaaaEducationCentersAdapterMock().Create();
            }
        }
    }
}

