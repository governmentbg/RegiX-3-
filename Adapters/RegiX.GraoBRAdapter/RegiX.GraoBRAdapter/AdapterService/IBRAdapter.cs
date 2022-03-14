using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GraoBRAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистър на актовете за граждански брак")]
    public interface IBRAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за семейно положение")]
        CommonSignedResponse<MaritalStatusRequestType, MaritalStatusResponseType> MaritalStatusSearch(MaritalStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за съпруг/съпруга")]
        CommonSignedResponse<SpouseRequestType, SpouseResponseType> SpouseSearch(SpouseRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за брак")]
        CommonSignedResponse<MarriageRequestType, MarriageResponseType> MarriageSearch(MarriageRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за семейно положение, съпруг/а и деца")]
        CommonSignedResponse<MaritalStatusSpouseChildrenRequestType, MaritalStatusSpouseChildrenResponseType> MaritalStatusSpouseChildrenSearch(MaritalStatusSpouseChildrenRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
