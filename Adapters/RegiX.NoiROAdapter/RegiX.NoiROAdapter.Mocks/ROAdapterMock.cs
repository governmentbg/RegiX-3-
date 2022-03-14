using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NoiROAdapter;
using TechnoLogica.RegiX.NoiROAdapter.AdapterService;

namespace TechnoLogica.RegiX.NoiROAdapter.Mock
{    
    public class NoiROAdapterMock : BaseAdapterServiceProxy<IROAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NoiROAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NoiROAdapterMock), typeof(IAdapterService))]
        public static IROAdapter MockExport
        {
            get
            {
                return new NoiROAdapterMock().Create();
            }
        }
    }
}

