using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NHIFAdapter;
using TechnoLogica.RegiX.NHIFAdapter.AdapterService;

namespace TechnoLogica.RegiX.NHIFAdapter.Mock
{    
    public class NHIFAdapterMock : BaseAdapterServiceProxy<INHIFAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NHIFAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NHIFAdapterMock), typeof(IAdapterService))]
        public static INHIFAdapter MockExport
        {
            get
            {
                return new NHIFAdapterMock().Create();
            }
        }
    }
}

