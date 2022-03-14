using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.BABHZhSAdapter.RegisteredAnimalsInOEZByCategory;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;


namespace TechnoLogica.RegiX.BABHZhSAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация със Системата за идентификация на животните и регистрация на животновъдните обекти в БАБХ")]
    public interface IBABHZhSAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за идентифицирано животно")]
        CommonSignedResponse<AnimalIdentificationRequestType, AnimalIdentificationResponseType> GetAnimalIdentification(AnimalIdentificationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за издадени лицензи за кратки и продължителни пътувания при превоз на живи животни")]
        CommonSignedResponse<MotorVehicleLicenceRequestType, MotorVehicleLicenceResponseType> GetMotorVehicleLicence(MotorVehicleLicenceRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за вписани животни в животновъдни обекти по категории")]
        CommonSignedResponse<RegisteredAnimalsByCategoryRequestType, RegisteredAnimalsByCategoryResponseType> GetRegisteredAnimalsByCategory(RegisteredAnimalsByCategoryRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за животни в ОЕЗ")]
        CommonSignedResponse<RegisteredAnimalsInOEZCategoryRequestType, RegisteredAnimalsInOEZByCategoryResponseType> GetRegisteredAnimalsInOEZByCategory(RegisteredAnimalsInOEZCategoryRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);


    }
}
