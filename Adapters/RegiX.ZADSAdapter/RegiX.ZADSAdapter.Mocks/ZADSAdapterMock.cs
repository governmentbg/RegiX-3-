using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.ZADSAdapter;
using TechnoLogica.RegiX.ZADSAdapter.AdapterService;

namespace TechnoLogica.RegiX.ZADSAdapter.Mock
{    
    public class ZADSAdapterMock : BaseAdapterServiceProxy<IZADSAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(ZADSAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(ZADSAdapterMock), typeof(IAdapterService))]
        public static IZADSAdapter MockExport
        {
            get
            {
                return new ZADSAdapterMock().Create();
            }
        }

        static ZADSAdapterMock()
        {
            RegisterResolver<RegistrationInfoRequestType, RegistrationInfoResponseType>(
                (i, r, a, o) => i.GetRegistrationInfo(r, a, o),
                (r) => ResolveGetExemptRegistrationAdministratorFileName(r));
        }

        private static string ResolveGetExemptRegistrationAdministratorFileName(RegistrationInfoRequestType r)
        {
            if (r != null && !r.EIK.StartsWith("1"))
            {
                return $"{DataFolder}ZADSRegistrationInfo.xml";
            }
            else
            {
                return $"{DataFolder}ZADSRegistrationInfo1.xml";
            }
        }

    }


}

