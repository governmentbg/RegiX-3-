using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.Mock
{
    public class IaaaVehicleInspectionsAdapterMock : BaseAdapterServiceProxy<IIaaaVehicleInspectionsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaaaVehicleInspectionsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapterMock), typeof(IAdapterService))]
        public static IIaaaVehicleInspectionsAdapter MockExport
        {
            get
            {
                return new IaaaVehicleInspectionsAdapterMock().Create();
            }
        }
    }
}

