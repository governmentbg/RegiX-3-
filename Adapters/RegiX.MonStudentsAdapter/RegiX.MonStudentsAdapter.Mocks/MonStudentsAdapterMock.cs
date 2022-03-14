using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MonStudentsAdapter;
using TechnoLogica.RegiX.MonStudentsAdapter.AdapterService;

namespace TechnoLogica.RegiX.MonStudentsAdapter.Mock
{    
    public class MonStudentsAdapterMock : BaseAdapterServiceProxy<IMonStudentsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MonStudentsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MonStudentsAdapterMock), typeof(IAdapterService))]
        public static IMonStudentsAdapter MockExport
        {
            get
            {
                return new MonStudentsAdapterMock().Create();
            }
        }
    }
}

