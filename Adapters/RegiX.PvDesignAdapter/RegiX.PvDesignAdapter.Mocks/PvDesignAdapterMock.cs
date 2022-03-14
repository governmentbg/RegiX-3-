using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PvDesignAdapter.AdapterService;

namespace TechnoLogica.RegiX.PvDesignAdapter.Mock
{
    public class PvDesignAdapterMock : BaseAdapterServiceProxy<IPvDesignAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PvDesignAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PvDesignAdapterMock), typeof(IAdapterService))]
        public static IPvDesignAdapter MockExport
        {
            get
            {
                return new PvDesignAdapterMock().Create();
            }
        }
    }
}

