using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using AdapterServiceReference = TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;

namespace TechnoLogica.RegiX.AVBulstat2Adapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Агенция по вписванията - Национален Регистър БУЛСТАТ")]
    public interface IAVBulstat2Adapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по код на БУЛСТАТ или по фирмено дело за актуално състояние на субект на БУЛСТАТ")]
        CommonSignedResponse<AdapterServiceReference.GetStateOfPlayRequest, AdapterServiceReference.StateOfPlay> GetStateOfPlay(AdapterServiceReference.GetStateOfPlayRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за номенклатурите на регистър БУЛСТАТ")]
        CommonSignedResponse<XMLSchemas.FetchNomenclatures, AdapterServiceReference.Nomenclatures> FetchNomenclatures(XMLSchemas.FetchNomenclatures argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за извличане на актуален УИК")]
        CommonSignedResponse<XMLSchemas.GetActualUICInfoRequestType, XMLSchemas.GetActualUICInfoResponseType> GetActualUICInfo(XMLSchemas.GetActualUICInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}
