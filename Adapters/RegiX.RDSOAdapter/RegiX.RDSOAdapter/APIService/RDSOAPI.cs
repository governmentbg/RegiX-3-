using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.RDSOAdapter.AdapterService;

namespace TechnoLogica.RegiX.RDSOAdapter.APIService
{
    [ExportFullName(typeof(IRDSOAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class RDSOAPI: BaseAPIService<IRDSOAPI>, IRDSOAPI
    {
        public  ServiceResultDataSigned<DiplomaSearchType, DiplomaDocumentsType> GetDiplomaInfo(ServiceRequestData<DiplomaSearchType> argument)
        {
            return  AdapterClient.Execute<IRDSOAdapter, DiplomaSearchType, DiplomaDocumentsType>(
                        (i, r, a, o) => i.GetDiplomaInfo(r, a,o),
                        argument);
        }

        public ServiceResultDataSigned<CertifiedDocumentsSearchType, CertifiedDocumentsType> GetCertifiedDiplomaInfo(ServiceRequestData<CertifiedDocumentsSearchType> argument)
        {
            return AdapterClient.Execute<IRDSOAdapter, CertifiedDocumentsSearchType, CertifiedDocumentsType>(
                        (i, r, a, o) => i.GetCertifiedDiplomaInfo(r, a, o),
                        argument);
        }
    }
}
