using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;


namespace TechnoLogica.RegiX.MZHAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с регистъра на земеделските производители")]
    public interface IMZHAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за земеделски производител")]
        CommonSignedResponse<FarmerSearchParametersType,FarmerType> FarmerDetailsSearch(FarmerSearchParametersType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
