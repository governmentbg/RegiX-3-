using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MtEstiAdapter;
using TechnoLogica.RegiX.MtEstiAdapter.AdapterService;

namespace TechnoLogica.RegiX.MtEstiAdapter.Mock
{    
    public class MtEstiAdapterMock : BaseAdapterServiceProxy<IMtEstiAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MtEstiAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MtEstiAdapterMock), typeof(IAdapterService))]
        public static IMtEstiAdapter MockExport
        {
            get
            {
                return new MtEstiAdapterMock().Create();
            }
        }
    }
}

