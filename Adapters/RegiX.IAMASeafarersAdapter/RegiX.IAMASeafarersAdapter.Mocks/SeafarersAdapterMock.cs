using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IAMASeafarersAdapter;
using TechnoLogica.RegiX.IAMASeafarersAdapter.AdapterService;

namespace TechnoLogica.RegiX.IAMASeafarersAdapter.Mock
{    
    public class SeafarersAdapterMock : BaseAdapterServiceProxy<ISeafarersAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(SeafarersAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(SeafarersAdapterMock), typeof(IAdapterService))]
        public static ISeafarersAdapter MockExport
        {
            get
            {
                return new SeafarersAdapterMock().Create();
            }
        }
    }
}

