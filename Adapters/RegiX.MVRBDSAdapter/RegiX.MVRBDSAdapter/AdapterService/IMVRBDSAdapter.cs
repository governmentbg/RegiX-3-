using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MVRBDSAdapter.AdapterService
{
    [ServiceContract]
    [Description("Aдаптер за връзка с Регистър Български документи за самоличност на МВР")]
    public interface IMVRBDSAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за български лични документи на български граждани")]
        CommonSignedResponse<PersonalIdentityInfoRequestType, PersonalIdentityInfoResponseType> GetPersonalIdentity(PersonalIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Разширена справка за български лични документи на български граждани и чужденци – V2")]
        CommonSignedResponse<MVRBDSAdapterV2.PersonalIdentityInfoRequestType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType> GetPersonalIdentityV2(MVRBDSAdapterV2.PersonalIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за документ за самоличност на български граждани по номер на документ")]
        CommonSignedResponse<MVRBDSAdapterV3.PersonalIdentityInfoRequestType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType> GetPersonalIdentityV3(MVRBDSAdapterV3.PersonalIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
