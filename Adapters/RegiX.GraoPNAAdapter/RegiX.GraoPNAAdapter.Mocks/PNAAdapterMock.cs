using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using System.IO;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GraoPNAAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoPNAAdapter.Mock
{
    public class PNAAdapterMock : BaseAdapterServiceProxy<IPNAAdapter>
    {
        static PNAAdapterMock()
        {
            RegisterResolver<PermanentAddressRequestType, PermanentAddressResponseType>(
                (i, r, a, o) => i.PermanentAddressSearch(r, a, o),
                fileNameResolver:
                    (r) => ResolvePermanentAddressSearchFileName(r)
            );
            RegisterResolver<TemporaryAddressRequestType, TemporaryAddressResponseType>(
                (i, r, a, o) => i.TemporaryAddressSearch(r, a, o),
                fileNameResolver:
                    (r) => ResolveTemporaryAddressSearchFileName(r)
            );
        }

        private static string ResolvePermanentAddressSearchFileName(PermanentAddressRequestType r)
        {
            if (r != null && !string.IsNullOrEmpty(r.EGN))
            {
                string fileName = $"{DataFolder}PermanentAddressResponse{r.EGN}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
            }
            return $"{DataFolder}PermanentAddressResponse.xml";
        }

        private static string ResolveTemporaryAddressSearchFileName(TemporaryAddressRequestType r)
        {
            if (r != null && !string.IsNullOrEmpty(r.EGN))
            {
                string fileName = $"{DataFolder}TemporaryAddressResponse{r.EGN}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
            }
            return $"{DataFolder}TemporaryAddressResponse.xml";
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PNAAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PNAAdapterMock), typeof(IAdapterService))]
        public static IPNAAdapter MockExport
        {
            get
            {
                return new PNAAdapterMock().Create();
            }
        }
    }
}

