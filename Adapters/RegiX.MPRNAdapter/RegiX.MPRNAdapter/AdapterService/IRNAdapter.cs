using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MPRNAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация със Регистъра на производствата по несъстоятелност")]
    public interface IRNAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за вписани обстоятелства в Регистъра на производствата по несъстоятелност")]
        CommonSignedResponse<RNSearchRequestType, RNSearchResponseType> RegisterOfInsolvenciesSearch(RNSearchRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
