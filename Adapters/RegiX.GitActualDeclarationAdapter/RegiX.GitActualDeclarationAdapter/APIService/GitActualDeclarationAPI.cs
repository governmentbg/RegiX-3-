using TechnoLogica.RegiX.GitActualDeclarationAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.GitActualDeclarationAdapter.APIService
{
    [ExportFullName(typeof(IGitActualDeclarationAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class GitActualDeclarationAPI : BaseAPIService<IGitActualDeclarationAPI>, IGitActualDeclarationAPI
    {
        public ServiceResultDataSigned<AuthenticityExplosivesRequestType, RZZBUTDeclaration> GetActualDeclaration(ServiceRequestData<AuthenticityExplosivesRequestType> argument)
        {
            return AdapterClient.Execute<IGitActualDeclarationAdapter, AuthenticityExplosivesRequestType, RZZBUTDeclaration>(
                (i, r, a, o) => i.GetActualDeclaration(r, a, o),
                 argument);
        }
    }
}
