using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosREGProtectedAreasAdapter;
using TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.Mock
{    
    public class IaosREGProtectedAreasAdapterMock : BaseAdapterServiceProxy<IIaosREGProtectedAreasAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosREGProtectedAreasAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosREGProtectedAreasAdapterMock), typeof(IAdapterService))]
        public static IIaosREGProtectedAreasAdapter MockExport
        {
            get
            {
                return new IaosREGProtectedAreasAdapterMock().Create();
            }
        }
    }
}

