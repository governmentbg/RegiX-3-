using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GraoPNAAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Класификатор на настоящите и постоянните адреси")]
    public interface IPNAAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за постоянен адрес")]
        CommonSignedResponse<PermanentAddressRequestType, PermanentAddressResponseType> PermanentAddressSearch(
            PermanentAddressRequestType argument,
            AccessMatrix accessMatrix,
            AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за настоящ адрес")]
        CommonSignedResponse<TemporaryAddressRequestType, TemporaryAddressResponseType> TemporaryAddressSearch(
            TemporaryAddressRequestType argument,
            AccessMatrix accessMatrix,
            AdapterAdditionalParameters aditionalParameters);
    }
}

