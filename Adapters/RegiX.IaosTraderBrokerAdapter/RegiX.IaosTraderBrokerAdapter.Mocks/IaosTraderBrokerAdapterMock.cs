using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosTraderBrokerAdapter;
using TechnoLogica.RegiX.IaosTraderBrokerAdapter.AdapterService;

namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter.Mock
{    
    public class IaosTraderBrokerAdapterMock : BaseAdapterServiceProxy<IIaosTraderBrokerAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(IaosTraderBrokerAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(IaosTraderBrokerAdapterMock), typeof(IAdapterService))]
        public static IIaosTraderBrokerAdapter MockExport
        {
            get
            {
                return new IaosTraderBrokerAdapterMock().Create();
            }
        }
    }
}

