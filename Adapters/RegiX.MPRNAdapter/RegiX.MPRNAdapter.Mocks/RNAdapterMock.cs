using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MPRNAdapter;
using TechnoLogica.RegiX.MPRNAdapter.AdapterService;

namespace TechnoLogica.RegiX.MPRNAdapter.Mock
{    
    public class MPRNAdapterMock : BaseAdapterServiceProxy<IRNAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MPRNAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MPRNAdapterMock), typeof(IAdapterService))]
        public static IRNAdapter MockExport
        {
            get
            {
                return new MPRNAdapterMock().Create();
            }
        }
    }
}

