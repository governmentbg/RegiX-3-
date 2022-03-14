using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
namespace TechnoLogica.RegiX.IAMASeafarersAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистъра на морските лица в ИАМА")]
    public interface ISeafarersAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за свидетелства за правоспособност на морските лица")]
        CommonSignedResponse<SeafarersLicensesRequestType, SeafarersLicensesResponseType> SeafarersLicensesSearch(SeafarersLicensesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
