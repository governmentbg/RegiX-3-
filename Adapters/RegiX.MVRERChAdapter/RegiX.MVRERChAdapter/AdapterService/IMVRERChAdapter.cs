using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MVRERChAdapter.AdapterService
{
    [ServiceContract]
    [Description("Aдаптер за връзка с Единен регистър на чужденците на МВР")]
    public interface IMVRERChAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за физическо лице – чужденец")]
        CommonSignedResponse<ForeignIdentityInfoRequestType, ForeignIdentityInfoResponseType> GetForeignIdentity(ForeignIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за физическо лице – чужденец V2")]
        CommonSignedResponse<MVRERChAdapterV2.ForeignIdentityInfoRequestType, MVRERChAdapterV2.ForeignIdentityInfoResponseType> GetForeignIdentityV2(MVRERChAdapterV2.ForeignIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
