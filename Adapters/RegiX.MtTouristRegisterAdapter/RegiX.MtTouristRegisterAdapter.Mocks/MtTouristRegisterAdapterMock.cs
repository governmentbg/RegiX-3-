using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MtTouristRegisterAdapter;
using TechnoLogica.RegiX.MtTouristRegisterAdapter.AdapterService;

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter.Mock
{    
    public class MtTouristRegisterAdapterMock : BaseAdapterServiceProxy<IMtTouristRegisterAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MtTouristRegisterAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MtTouristRegisterAdapterMock), typeof(IAdapterService))]
        public static IMtTouristRegisterAdapter MockExport
        {
            get
            {
                return new MtTouristRegisterAdapterMock().Create();
            }
        }
    }
}

