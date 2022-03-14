using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.ASPFosterParentsAdapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.ASPFosterParentsAdapter.APIService
{
    [ExportFullName(typeof(IASPFosterParentsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class ASPFosterParentsAPI : BaseAPIService<IASPFosterParentsAPI>, IASPFosterParentsAPI
    {
        public ServiceResultDataSigned<AspFosterParentsRequest, AspFosterParentsResponse> SendRequestForFosterParents(ServiceRequestData<AspFosterParentsRequest> argument)
        {
            return AdapterClient.Execute<IASPFosterParentsAdapter, AspFosterParentsRequest, AspFosterParentsResponse>(
                (i, r, a, o) => i.SendRequestForFosterParents(r, a, o),
                 argument);
        }
    }
}
