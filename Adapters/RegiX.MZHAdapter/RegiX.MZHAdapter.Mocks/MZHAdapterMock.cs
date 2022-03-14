using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MZHAdapter.AdapterService;

namespace TechnoLogica.RegiX.MZHAdapter.Mock
{
    public class MZHAdapterMock : BaseAdapterServiceProxy<IMZHAdapter>
    {
        static MZHAdapterMock()
        {
            RegisterResolver<FarmerSearchParametersType, FarmerType>(
                (i,r,a,o) => i.FarmerDetailsSearch(r,a,o),
                (r) => ResolveFarmerDetailsSearchFileName(r));
        }

        private static string ResolveFarmerDetailsSearchFileName(FarmerSearchParametersType r)
        {
            if (r != null && r.Parameter != null && r.Parameter.StartsWith("1"))
            {
                return $"{DataFolder}MZH.xml";
            }
            else
            {
                return $"{DataFolder}MZH1.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MZHAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MZHAdapterMock), typeof(IAdapterService))]
        public static IMZHAdapter MockExport
        {
            get
            {
                return new MZHAdapterMock().Create();
            }
        }
    }
}

