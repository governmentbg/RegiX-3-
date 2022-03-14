using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GraoNMAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Класификатор на населените места")]
    public interface INMAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка на населени места")]
        CommonSignedResponse<SettlementPlacesRequestType,SettlementPlacesResponseType> SettlementPlacesSearch(
            SettlementPlacesRequestType argument,
            AccessMatrix accessMatrix, 
            AdapterAdditionalParameters aditionalParameters);
    }
}
