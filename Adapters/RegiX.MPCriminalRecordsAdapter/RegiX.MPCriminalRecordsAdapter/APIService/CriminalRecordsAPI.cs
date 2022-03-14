using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MPCriminalRecordsAdapter.AdapterService;

namespace TechnoLogica.RegiX.MPCriminalRecordsAdapter.APIService
{
    [ExportFullName(typeof(ICriminalRecordsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class CriminalRecordsAPI : BaseAPIService<ICriminalRecordsAPI>, ICriminalRecordsAPI 
    {
        public ServiceResultDataSigned<BulletinSearchRequestType, BulletinSearchResponseType> BulletinSearch(ServiceRequestData<BulletinSearchRequestType> argument)
        {
            return  AdapterClient.Execute<ICriminalRecordsAdapter, BulletinSearchRequestType, BulletinSearchResponseType>(
                        (i, r, a, o) => i.BulletinSearch(r, a, o),
                        argument);
        }

        public override string GetMetaDataXML(string operationName)
        {
            return "---";
        }
    }
}
