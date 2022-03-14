using RegiX.Adapters.Mocks;
using RegiX.CPCProcurementDossierAdapter.AdapterService;
using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;

namespace RegiX.CPCProcurementDossierAdapter.Mocks
{
    public class CPCProcurementDossierAdapterMock : BaseAdapterServiceProxy<ICPCProcurementDossierAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CPCProcurementDossierAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CPCProcurementDossierAdapterMock), typeof(IAdapterService))]
        public static ICPCProcurementDossierAdapter MockExport
        {
            get
            {
                return new CPCProcurementDossierAdapterMock().Create();
            }
        }
    }
}
