using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROOilAdapter;
using TechnoLogica.RegiX.IaosMROOilAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosMROOilAdapter.Mock
{    
    public class IaosMROOilAdapterMock : BaseAdapterServiceProxy<IIaosMROOilAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosMROOilAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosMROOilAdapterMock), typeof(IAdapterService))]
        public static IIaosMROOilAdapter MockExport
        {
            get
            {
                return new IaosMROOilAdapterMock().Create();
            }
        }
    }
}

