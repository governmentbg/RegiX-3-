using TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.GitExplosivesAdapter.APIService
{
    [ExportFullName(typeof(IGitExplosivesAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class GitExplosivesAPI : BaseAPIService<IGitExplosivesAPI>, IGitExplosivesAPI
    {
        public ServiceResultDataSigned<AuthenticityExplosivesRequestType, ValidExplosivesCertificateResponse> GetAuthenticityExplosivesCertificate(ServiceRequestData<AuthenticityExplosivesRequestType> argument)
        {
            return AdapterClient.Execute<IGitExplosivesAdapter, AuthenticityExplosivesRequestType, ValidExplosivesCertificateResponse>(
                        (i, r, a, o) => i.GetAuthenticityExplosivesCertificate(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<ValidExplosivesRequestType, ValidExplosivesCertificateResponse> GetValidExplosivesCertificate(ServiceRequestData<ValidExplosivesRequestType> argument)
        {
            return AdapterClient.Execute<IGitExplosivesAdapter, ValidExplosivesRequestType, ValidExplosivesCertificateResponse>(
                        (i, r, a, o) => i.GetValidExplosivesCertificate(r, a, o),
                        argument);
        }
    }
}
