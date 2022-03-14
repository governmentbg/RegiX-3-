using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GitActualDeclarationAdapter.AdapterService;

namespace TechnoLogica.RegiX.GitActualDeclarationAdapter.Mocks
{
    public class GitActualDeclarationAdapterMock : BaseAdapterServiceProxy<IGitActualDeclarationAdapter>
    {
        static GitActualDeclarationAdapterMock()
        {
            RegisterResolver<AuthenticityExplosivesRequestType, RZZBUTDeclaration>(
                (i, r, a, o) => i.GetActualDeclaration(r, a, o),
                (r) => ResolveGetActualDeclarationFileName(r));
        }

        private static string ResolveGetActualDeclarationFileName(AuthenticityExplosivesRequestType r)
        {
            if (r?.DeclaratorIdentifier != null)
            {
                return $"{DataFolder}test.xml";
            }
            else
            {
                return $"{DataFolder}empty.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(GitActualDeclarationAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(GitActualDeclarationAdapterMock), typeof(IAdapterService))]
        public static IGitActualDeclarationAdapter MockExport
        {
            get
            {
                return new GitActualDeclarationAdapterMock().Create();
            }
        }
    }
}
