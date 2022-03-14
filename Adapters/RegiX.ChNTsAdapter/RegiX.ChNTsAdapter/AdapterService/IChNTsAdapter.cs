using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.ChNTsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистър на разрешенията за извършване на дейност с нестопанска цел в Република България")]
    public interface IChNTsAdapter: IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за издадени/отказани разрешения за извършване на дейност с нестопанска цел в РБ")]
        CommonSignedResponse<ForeignerPermissionsRequestType, ForeignerPermissionsResponseType> GetForeignerPermissions(ForeignerPermissionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
  
    }
}
