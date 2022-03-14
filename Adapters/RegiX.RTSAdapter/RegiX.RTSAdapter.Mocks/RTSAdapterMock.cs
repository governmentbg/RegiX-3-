using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.RTSAdapter;
using TechnoLogica.RegiX.RTSAdapter.AdapterService;

namespace TechnoLogica.RegiX.RTSAdapter.Mock
{    
    public class RTSAdapterMock : BaseAdapterServiceProxy<IRTSAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(RTSAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(RTSAdapterMock), typeof(IAdapterService))]
        public static IRTSAdapter MockExport
        {
            get
            {
                return new RTSAdapterMock().Create();
            }
        }
        static RTSAdapterMock()
        {
            RegisterResolver<RoutesSearch, RoutesResponse>(
                (i, r, a, o) => i.GetRoutesTimeTable(r, a, o),
                (r) => ResolveGetExemptRegistrationAdministratorFileName(r));
        }

        private static string ResolveGetExemptRegistrationAdministratorFileName(RoutesSearch r)
        {
            if (r?.ForwardFirstStopMunicipality != null &&
                r?.BackwardFirstStopMunicipality != null)
            {
                string fileName = $"{DataFolder}" + r.ForwardFirstStopMunicipality.ToUpper() + r.BackwardFirstStopMunicipality.ToLower() + ".xml";
                if (File.Exists(fileName))
                {
                    return $"{DataFolder}" + r.ForwardFirstStopMunicipality.ToUpper() + r.BackwardFirstStopMunicipality.ToLower() + ".xml";
                }
            }
            return $"{DataFolder}default.xml";
        }

    }
}

