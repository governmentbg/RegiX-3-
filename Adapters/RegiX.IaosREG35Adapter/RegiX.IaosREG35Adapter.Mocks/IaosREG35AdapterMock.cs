using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosREG35Adapter;
using TechnoLogica.RegiX.IaosREG35Adapter.AdapterService;

namespace TechnoLogica.RegiX.IaosREG35Adapter.Mock
{    
    public class IaosREG35AdapterMock : BaseAdapterServiceProxy<IIaosREG35Adapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosREG35AdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosREG35AdapterMock), typeof(IAdapterService))]
        public static IIaosREG35Adapter MockExport
        {
            get
            {
                return new IaosREG35AdapterMock().Create();
            }
        }
    }
}

