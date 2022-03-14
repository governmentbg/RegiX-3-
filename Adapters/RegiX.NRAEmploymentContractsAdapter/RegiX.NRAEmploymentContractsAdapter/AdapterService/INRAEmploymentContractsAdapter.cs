using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.DataContracts;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с НАП - Регистър на уведомленията за трудовите договори и уведомления за промяна на работодател")]
    public interface INRAEmploymentContractsAdapter: IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за сключване, изменение или прекратяване на трудовите договори и уведомления за промяна на работодател")]
        CommonSignedResponse<EmploymentContractsRequest, EmploymentContractsResponse> GetEmploymentContracts(EmploymentContractsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

