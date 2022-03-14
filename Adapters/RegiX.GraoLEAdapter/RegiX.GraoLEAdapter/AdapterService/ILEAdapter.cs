using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GraoLEAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Класификатор на локализационните единици")]
    public interface ILEAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за локализационни единици")]
        CommonSignedResponse<LocationsRequestType, LocationsResponseType> LocationsSearch(LocationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
