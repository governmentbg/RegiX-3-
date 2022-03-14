using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.DummyAdapter;

namespace RegiX.Adapters.Mocks.Tests
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Тестов регистър за примерни данни и тестване")]
    public interface IDummyTestAdapterServiceNETCore : IAdapterServiceNETCore
    {
        [OperationContract]
        [Description("Тестова операция 1")]
        CommonSignedResponse<string, ExampleResponse> ExampleOperation(string argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Тестова операция 2")]
        CommonSignedResponse<string, ExampleResponse> ExampleOperation2(string argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Тестова операция 2")]
        CommonSignedResponse<ExampleRequestType, ExampleResponse> CustomResponse(ExampleRequestType ExampleRequestType, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Тестова операция - допълване на отговор")]
        CommonSignedResponse<ExampleRequestType, ExampleResponse> Augmented(ExampleRequestType ExampleRequestType, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
