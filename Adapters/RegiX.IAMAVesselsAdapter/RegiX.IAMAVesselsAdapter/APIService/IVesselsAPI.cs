using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.IAMAVesselsAdapter.Ships;

namespace TechnoLogica.RegiX.IAMAVesselsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистъра на корабите в ИАМА")]
    public interface IVesselsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за регистрация на кораб по данни на собственик")]
        [Info(
            requestXSD: "RegistrationInfoByOwnerRequest.xsd",
            responseXSD: "Ships.xsd",
            commonXSD: "VesselsCommon.xsd",
            requestXSLT: "RegistrationInfoByOwnerRequest.xslt",
            responseXSLT: "RegistrationInfoByOwnerResponse.xslt")]
        ServiceResultDataSigned<ShipsByOwnerRequest, ShipsResponse> RegistrationSearchByOwner(ServiceRequestData<ShipsByOwnerRequest> argument);

        [OperationContract]
        [Description("Справка за регистрация на кораб по характеристики на кораб")]
        [Info(
            requestXSD: "RegistrationInfoByCharacteristicsRequest.xsd",
            responseXSD: "Ships.xsd",
            commonXSD: "VesselsCommon.xsd",
            requestXSLT: "RegistrationInfoByCharacteristicsRequest.xslt",
            responseXSLT: "RegistrationInfoByCharacteristicsResponse.xslt")]
        ServiceResultDataSigned<ShipsByCharacteristicsRequest, ShipsResponse> RegistrationByCharacteristicsSearch(ServiceRequestData<ShipsByCharacteristicsRequest> argument);

        [OperationContract]
        [Description("Номенклатури за характеристики на кораб")]
        [Info(
            requestXSD: "Ships.xsd",
            responseXSD: "Ships.xsd",
            commonXSD: "VesselsCommon.xsd",
            requestXSLT: "GetNomenclaturesRequest.xslt",
            responseXSLT: "NomenclaturesResponse.xslt")]
        ServiceResultDataSigned<NomenclaturesRequest, NomenclatureResponse> GetNomenclatures(ServiceRequestData<NomenclaturesRequest> argument);
    }
}

