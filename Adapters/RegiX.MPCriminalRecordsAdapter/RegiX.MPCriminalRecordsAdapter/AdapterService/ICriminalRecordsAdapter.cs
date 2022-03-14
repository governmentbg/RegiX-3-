using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MPCriminalRecordsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация със регистъра за съдимост")]
    public interface ICriminalRecordsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за свидетелство за съдимост")]
        CommonSignedResponse<BulletinSearchRequestType, BulletinSearchResponseType> BulletinSearch(BulletinSearchRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additioinalParameters);
    }
}
