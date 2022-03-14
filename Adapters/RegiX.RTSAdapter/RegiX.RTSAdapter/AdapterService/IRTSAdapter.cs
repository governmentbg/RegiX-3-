using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.RTSAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с регистъра на автомобилната администрация")]
    public interface IRTSAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за маршрутни разписания")]
        CommonSignedResponse<RoutesSearch, RoutesResponse> GetRoutesTimeTable(RoutesSearch routesSearch, AccessMatrix acessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
