using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MPNPOAdapter;
using TechnoLogica.RegiX.MPNPOAdapter.AdapterService;

namespace TechnoLogica.RegiX.MPNPOAdapter.Mock
{    
    public class MPNPOAdapterMock : BaseAdapterServiceProxy<IMPNPOAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MPNPOAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MPNPOAdapterMock), typeof(IAdapterService))]
        public static IMPNPOAdapter MockExport
        {
            get
            {
                return new MPNPOAdapterMock().Create();
            }
        }
    }
}

