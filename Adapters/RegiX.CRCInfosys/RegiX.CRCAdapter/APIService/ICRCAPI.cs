using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace Infosys.RegiX.CRCAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с 'Механизъм за измерване на качеството на УДИ' на Комисия за регулиране на съобщенията")]
    public interface ICRCAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за извършени измервания на качеството на УДИ")]        
        ServiceResultDataSigned<CRCFindAllRequestType, CRCFindAllResponseType> FindAllMeasurements(ServiceRequestData<CRCFindAllRequestType> argument);
    }
}
