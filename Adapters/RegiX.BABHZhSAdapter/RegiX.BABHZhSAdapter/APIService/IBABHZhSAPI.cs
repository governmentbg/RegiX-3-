using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.BABHZhSAdapter.RegisteredAnimalsInOEZByCategory;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.BABHZhSAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация със Системата за идентификация на животните и регистрация на животновъдните обекти в БАБХ")]
    public interface IBABHZhSAPI : IAPIService
    {
        //Справка за идентифицирано животно

        [OperationContract]
        [Description("Справка за идентифицирано животно")]
        [Info(
            requestXSD: "AnimalIdentificationRequest.xsd",
            responseXSD: "AnimalIdentificationResponse.xsd",
            requestXSLT: "AnimalIdentificationRequest.xslt",
            responseXSLT: "AnimalIdentificationResponse.xslt")]
        ServiceResultDataSigned<AnimalIdentificationRequestType, AnimalIdentificationResponseType> GetAnimalIdentification(ServiceRequestData<AnimalIdentificationRequestType> argument);

        //Справка за издадени лицензи за кратки и продължителни пътувания при превоз на живи животни

        [OperationContract]
        [Description("Справка за издадени лицензи за кратки и продължителни пътувания при превоз на живи животни")]
        [Info(
            requestXSD: "MotorVehicleLicenceRequest.xsd",
            responseXSD: "MotorVehicleLicenceResponse.xsd",
            requestXSLT: "MotorVehicleLicenceRequest.xslt",
            responseXSLT: "MotorVehicleLicenceResponse.xslt")]
        ServiceResultDataSigned<MotorVehicleLicenceRequestType, MotorVehicleLicenceResponseType> GetMotorVehicleLicence(ServiceRequestData<MotorVehicleLicenceRequestType> argument);

        //Справка за вписани животни в животновъдни обекти по категории

        [OperationContract]
        [Description("Справка за вписани животни в животновъдни обекти по категории")]
        [Info(
            requestXSD: "RegisteredAnimalsByCategoryRequest.xsd",
            responseXSD: "RegisteredAnimalsByCategoryResponse.xsd",
            requestXSLT: "RegisteredAnimalsByCategoryRequest.xslt",
            responseXSLT: "RegisteredAnimalsByCategoryResponse.xslt")]
        ServiceResultDataSigned<RegisteredAnimalsByCategoryRequestType, RegisteredAnimalsByCategoryResponseType> GetRegisteredAnimalsByCategory(ServiceRequestData<RegisteredAnimalsByCategoryRequestType> argument);

        //Справка за животни в ОЕЗ

        [OperationContract]
        [Description("Справка за животни в ОЕЗ")]
        [Info(
            requestXSD: "RegisteredAnimalsInOEZByCategoryRequest.xsd",
            responseXSD: "RegisteredAnimalsInOEZByCategoryResponse.xsd",
            requestXSLT: "RegisteredAnimalsInOEZByCategoryRequest.xslt",
            responseXSLT: "RegisteredAnimalsInOEZByCategoryResponse.xslt")]
        ServiceResultDataSigned<RegisteredAnimalsInOEZCategoryRequestType, RegisteredAnimalsInOEZByCategoryResponseType> GetRegisteredAnimalsInOEZByCategory(ServiceRequestData<RegisteredAnimalsInOEZCategoryRequestType> argument);
    }
}
