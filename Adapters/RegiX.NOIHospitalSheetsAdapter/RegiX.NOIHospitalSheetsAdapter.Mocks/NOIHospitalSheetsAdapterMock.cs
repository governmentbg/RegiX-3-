using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService;

namespace TechnoLogica.RegiX.NOIHospitalSheetsAdapter.Mocks
{
    public class NOIHospitalSheetsAdapterMock: BaseAdapterServiceProxy<INOIHospitalSheetsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NOIHospitalSheetsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NOIHospitalSheetsAdapterMock), typeof(IAdapterService))]
        public static INOIHospitalSheetsAdapter MockExport
        {
            get
            {
                return new NOIHospitalSheetsAdapterMock().Create();
            }
        }
    }
}
