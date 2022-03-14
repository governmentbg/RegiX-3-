using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NRAEmploymentContractsAdapter;
using TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService;

namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter.Mock
{    
    public class NRAEmploymentContractsAdapterMock : BaseAdapterServiceProxy<INRAEmploymentContractsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NRAEmploymentContractsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NRAEmploymentContractsAdapterMock), typeof(IAdapterService))]
        public static INRAEmploymentContractsAdapter MockExport
        {
            get
            {
                return new NRAEmploymentContractsAdapterMock().Create();
            }
        }
    }
}

