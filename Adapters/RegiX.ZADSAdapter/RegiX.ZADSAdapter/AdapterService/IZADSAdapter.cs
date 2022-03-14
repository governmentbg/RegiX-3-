using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.ZADSAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с регистъра за вписани лица по ЗАДС")]
    public interface IZADSAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за статут на лице по ЗАДС")]
        CommonSignedResponse<RegistrationInfoRequestType, RegistrationInfoResponseType> GetRegistrationInfo(
            RegistrationInfoRequestType argument,
            AccessMatrix accessMatrix,
            AdapterAdditionalParameters aditionalParameters);
    }
}

