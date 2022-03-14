using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.AdapterService;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.GraoCivilStatusActsAdapter.APIService
{
    [ExportFullName(typeof(IGraoCivilStatusActsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class GraoCivilStatusActsAPI : BaseAPIService<IGraoCivilStatusActsAPI>, IGraoCivilStatusActsAPI
    {
        public ServiceResultDataSigned<MarriageCertificateRequestType, MarriageCertificateResponseType> GetMarriageCertificate(ServiceRequestData<MarriageCertificateRequestType> argument)
        {
            return  AdapterClient.Execute<IGraoCivilStatusActsAdapter, MarriageCertificateRequestType, MarriageCertificateResponseType>(
               (i, r, a, o) => i.GetMarriageCertificate(r, a, o),
                argument);
        }
    }
}
