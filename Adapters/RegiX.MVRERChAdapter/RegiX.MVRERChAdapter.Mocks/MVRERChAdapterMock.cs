using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MVRERChAdapter;
using TechnoLogica.RegiX.MVRERChAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRERChAdapter.Mock
{    
    public class MVRERChAdapterMock : BaseAdapterServiceProxy<IMVRERChAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MVRERChAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MVRERChAdapterMock), typeof(IAdapterService))]
        public static IMVRERChAdapter MockExport
        {
            get
            {
                return new MVRERChAdapterMock().Create();
            }
        }
    }
}

