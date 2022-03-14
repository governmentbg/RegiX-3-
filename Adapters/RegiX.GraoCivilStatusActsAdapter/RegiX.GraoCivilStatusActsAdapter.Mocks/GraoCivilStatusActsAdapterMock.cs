using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.AdapterService;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.GraoCivilStatusActsAdapter.Mock
{    
    public class GraoCivilStatusActsAdapterMock : BaseAdapterServiceProxy<IGraoCivilStatusActsAdapter>
    {
        static GraoCivilStatusActsAdapterMock()
        {
            RegisterResolver<MarriageCertificateRequestType, MarriageCertificateResponseType>(
                (i, r, a, o) => i.GetMarriageCertificate(r, a, o),
                fileNameResolver:
                    (r) => ResolveMarriageCertificate(r),
                augmentActionResolver:
                    (r) => AugmentMarriageCertificate(r)
            );
        }

        private static string ResolveMarriageCertificate(MarriageCertificateRequestType r)
        {
            if (r != null && !string.IsNullOrEmpty(r.Egn) && r.Egn.StartsWith("0"))
            {
                return $"{DataFolder}empty.xml";
            }
            else
            {
                string fileName = $"{DataFolder}{r?.Egn}.xml";
                if (File.Exists(fileName))
                {
                    return fileName;
                }
                else
                {
                    return $"{DataFolder}default.xml";
                }
            }
        }

        private static void AugmentMarriageCertificate(MarriageCertificateResponseType r)
        {
            r.ReportDate = DateTime.Now;
            r.ReportDateSpecified = true;
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(GraoCivilStatusActsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(GraoCivilStatusActsAdapterMock), typeof(IAdapterService))]
        public static IGraoCivilStatusActsAdapter MockExport
        {
            get
            {
                return new GraoCivilStatusActsAdapterMock().Create();
            }
        }
    }
}

