using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MVRTouristRegisterAdapter;
using TechnoLogica.RegiX.MVRTouristRegisterAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRTouristRegisterAdapter.Mock
{    
    public class MVRTouristRegisterAdapterMock : BaseAdapterServiceProxy<IMVRTouristRegisterAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MVRTouristRegisterAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MVRTouristRegisterAdapterMock), typeof(IAdapterService))]
        public static IMVRTouristRegisterAdapter MockExport
        {
            get
            {
                return new MVRTouristRegisterAdapterMock().Create();
            }
        }
    }
}

