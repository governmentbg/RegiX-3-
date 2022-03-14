using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService;

namespace TechnoLogica.RegiX.GitExplosivesAdapter.Mocks
{
    public class GitExplosivesAdapterMock : BaseAdapterServiceProxy<IGitExplosivesAdapter>
    {
        static GitExplosivesAdapterMock()
        {
            RegisterResolver<AuthenticityExplosivesRequestType, ValidExplosivesCertificateResponse>(
                (i, r, a, o) => i.GetAuthenticityExplosivesCertificate(r, a, o),
                (r) => ResolveGetAuthenticityExplosivesCertificateFileName(r));
            RegisterResolver<ValidExplosivesRequestType, ValidExplosivesCertificateResponse>(
                (i, r, a, o) => i.GetValidExplosivesCertificate(r, a, o),
                (r) => ResolveGetValidExplosivesCertificateFileName(r));

        }

        private static string ResolveGetAuthenticityExplosivesCertificateFileName(AuthenticityExplosivesRequestType r)
        {
            if (r != null && r.Identifier != null && r.Identifier.StartsWith("9"))
            {
                return $"{DataFolder}GetAuthenticityExplosivesCertificate_Test.xml";
            }
            else
            {
                return $"{DataFolder}GetAuthenticityExplosivesCertificate_NULL_Test.xml";
            }
        }

        private static string ResolveGetValidExplosivesCertificateFileName(ValidExplosivesRequestType r)
        {
            if (r != null && r.Identifier != null && r.Identifier.StartsWith("9"))
            {
                return $"{DataFolder}GetValidExplosivesCertificate_Test.xml";
            }
            else
            {
                return $"{DataFolder}GetValidExplosivesCertificate_NULL_Test.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(GitExplosivesAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(GitExplosivesAdapterMock), typeof(IAdapterService))]
        public static IGitExplosivesAdapter MockExport
        {
            get
            {
                return new GitExplosivesAdapterMock().Create();
            }
        }
    }
}
