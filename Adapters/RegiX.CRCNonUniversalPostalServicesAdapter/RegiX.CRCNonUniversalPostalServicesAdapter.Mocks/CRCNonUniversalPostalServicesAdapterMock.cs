using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.Mocks
{
    public class CRCNonUniversalPostalServicesAdapterMock : BaseAdapterServiceProxy<ICRCNonUniversalPostalServicesAdapter>
    {
        static CRCNonUniversalPostalServicesAdapterMock()
        {
            RegisterResolver<GetNonUniversalOperatorsInfoRequest, GetNonUniversalOperatorsInfoResponseType>(
               (i, r, a, o) => i.GetNonUniversalOperatorsInfo(r, a, o),
               (r) => $"{DataFolder}GetNonUniversalOperatorsInfo.response.xml"
           );
        }
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(CRCNonUniversalPostalServicesAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(CRCNonUniversalPostalServicesAdapterMock), typeof(IAdapterService))]
        public static ICRCNonUniversalPostalServicesAdapter MockExport
        {
            get
            {
                return new CRCNonUniversalPostalServicesAdapterMock().Create();
            }
        }
    }
}
