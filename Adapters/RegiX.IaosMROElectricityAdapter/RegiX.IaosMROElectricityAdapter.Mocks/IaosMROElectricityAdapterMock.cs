using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROElectricityAdapter;
using TechnoLogica.RegiX.IaosMROElectricityAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosMROElectricityAdapter.Mock
{    
    public class IaosMROElectricityAdapterMock : BaseAdapterServiceProxy<IIaosMROElectricityAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosMROElectricityAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosMROElectricityAdapterMock), typeof(IAdapterService))]
        public static IIaosMROElectricityAdapter MockExport
        {
            get
            {
                return new IaosMROElectricityAdapterMock().Create();
            }
        }
    }
}

