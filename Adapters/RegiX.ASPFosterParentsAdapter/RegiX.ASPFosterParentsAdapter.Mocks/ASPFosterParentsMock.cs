using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.ASPFosterParentsAdapter.AdapterService;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.ASPFosterParentsAdapter.Mocks
{
    public class ASPFosterParentsMock : BaseAdapterServiceProxy<IASPFosterParentsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(ASPFosterParentsMock), typeof(IAdapterService))]
        [ExportFullName(typeof(ASPFosterParentsMock), typeof(IAdapterService))]
        public static IASPFosterParentsAdapter MockExport
        {
            get
            {
                return new ASPFosterParentsMock().Create();
            }
        }
    }
}
