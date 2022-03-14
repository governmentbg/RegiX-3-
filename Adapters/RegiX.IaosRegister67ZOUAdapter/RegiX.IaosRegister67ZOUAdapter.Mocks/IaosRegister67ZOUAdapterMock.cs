using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosRegister67ZOUAdapter;
using TechnoLogica.RegiX.IaosRegister67ZOUAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosRegister67ZOUAdapter.Mock
{    
    public class IaosRegister67ZOUAdapterMock : BaseAdapterServiceProxy<IIaosRegister67ZOUAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosRegister67ZOUAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosRegister67ZOUAdapterMock), typeof(IAdapterService))]
        public static IIaosRegister67ZOUAdapter MockExport
        {
            get
            {
                return new IaosRegister67ZOUAdapterMock().Create();
            }
        }
    }
}

