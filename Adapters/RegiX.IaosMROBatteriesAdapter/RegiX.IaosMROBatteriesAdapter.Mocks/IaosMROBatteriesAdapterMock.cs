using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosMROBatteriesAdapter;
using TechnoLogica.RegiX.IaosMROBatteriesAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter.Mock
{    
    public class IaosMROBatteriesAdapterMock : BaseAdapterServiceProxy<IIaosMROBatteriesAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosMROBatteriesAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosMROBatteriesAdapterMock), typeof(IAdapterService))]
        public static IIaosMROBatteriesAdapter MockExport
        {
            get
            {
                return new IaosMROBatteriesAdapterMock().Create();
            }
        }
    }
}

