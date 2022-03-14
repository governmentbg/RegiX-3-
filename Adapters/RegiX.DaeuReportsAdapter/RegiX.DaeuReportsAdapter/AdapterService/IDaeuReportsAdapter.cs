using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.DaeuReportsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Регистър на извършваните операции в средата за междурегистров обмен - RegiX")]
    public interface IDaeuReportsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Персонална справка на физическо лице за достъп до лични данни по идентификатор и период")]
        CommonSignedResponse<SearchByIdentifierRequestType, SearchByIdentifierResponse> SearchByIdentifier(SearchByIdentifierRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}
