using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IAMAVesselsAdapter;
using TechnoLogica.RegiX.IAMAVesselsAdapter.AdapterService;

namespace TechnoLogica.RegiX.IAMAVesselsAdapter.Mock
{    
    public class VesselsAdapterMock : BaseAdapterServiceProxy<IVesselsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(VesselsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(VesselsAdapterMock), typeof(IAdapterService))]
        public static IVesselsAdapter MockExport
        {
            get
            {
                return new VesselsAdapterMock().Create();
            }
        }
    }
}

