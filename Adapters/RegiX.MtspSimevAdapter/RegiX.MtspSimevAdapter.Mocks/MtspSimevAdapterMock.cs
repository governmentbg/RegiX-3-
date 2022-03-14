using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MtspSimevAdapter;
using TechnoLogica.RegiX.MtspSimevAdapter.AdapterService;

namespace TechnoLogica.RegiX.MtspSimevAdapter.Mock
{    
    public class MtspSimevAdapterMock : BaseAdapterServiceProxy<IMtspSimevAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MtspSimevAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MtspSimevAdapterMock), typeof(IAdapterService))]
        public static IMtspSimevAdapter MockExport
        {
            get
            {
                return new MtspSimevAdapterMock().Create();
            }
        }
    }
}

