using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NoiROAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистър на обезщетенията по болест, майчинство и безработица")]
    public interface IROAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за изплатено парично обезщетение при временна неработоспособност, трудоустрояване и майчинство и/или помощ по период на обезщетението")]
        CommonSignedResponse<POVNPOBRequestType, POVNPOBResponseType> SearchDisabilityCompensationByCompensationPeriod(POVNPOBRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
       
        [OperationContract]
        [Description("Справка за изплатено парично обезщетение при временна неработоспособност, трудоустрояване и майчинство и/или помощ по период на дата на ведомост /дата на плащане")]
        CommonSignedResponse<POVNVEDRequestType, POVNVEDResponseType> SearchDisabilityCompensationByPaymentPeriod(POVNVEDRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за изплатено парично обезщетение за безработица по период на обезщетението")]
        CommonSignedResponse<POBPOBRequestType, POBPOBResponseType> SearchUnemploymentCompensationByCompensationPeriod(POBPOBRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за изплатено парично обезщетение за безработица по период на дата на ведомост /дата на плащане")]
        CommonSignedResponse<POBVEDRequestType, POBVEDResponseType> SearchUnemploymentCompensationByPaymentPeriod(POBVEDRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
 
    }
}
