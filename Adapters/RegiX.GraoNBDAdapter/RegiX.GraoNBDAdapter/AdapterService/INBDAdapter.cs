using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GraoNBDAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Национална база данни (НБД) Население")]
    //[XmlSerializerFormat]
    public interface INBDAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за валидност на физическо лице")]
        CommonSignedResponse<ValidPersonRequestType, ValidPersonResponseType> ValidPersonSearch(ValidPersonRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за родственост")]
        CommonSignedResponse<RelationsRequestType, RelationsResponseType> RelationsSearch(RelationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за физическо лице")]
        CommonSignedResponse<PersonDataRequestType, PersonDataResponseType> PersonDataSearch(PersonDataRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
        
   }
}
