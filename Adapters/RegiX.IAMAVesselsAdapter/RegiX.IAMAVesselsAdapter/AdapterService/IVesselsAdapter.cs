using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IAMAVesselsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистъра на корабите в ИАМА")]
    public interface IVesselsAdapter: IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за регистрация на кораб по данни на собственик")]
        CommonSignedResponse<Ships.ShipsByOwnerRequest, Ships.ShipsResponse> RegistrationSearchByOwner(Ships.ShipsByOwnerRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за регистрация на кораб по характеристики на кораб")]
        CommonSignedResponse<Ships.ShipsByCharacteristicsRequest, Ships.ShipsResponse> RegistrationByCharacteristicsSearch(Ships.ShipsByCharacteristicsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Номенклатури за характеристики на кораб")]
        CommonSignedResponse<Ships.NomenclaturesRequest, Ships.NomenclatureResponse> GetNomenclatures(Ships.NomenclaturesRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
  
    }
}
