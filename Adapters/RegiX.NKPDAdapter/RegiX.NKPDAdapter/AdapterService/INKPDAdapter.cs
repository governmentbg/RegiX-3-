using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.DataContracts;
using System.ComponentModel;

namespace TechnoLogica.RegiX.NKPDAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с класификатора НКПД")]
    public interface INKPDAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за търсене на целия класификатор НКПД")]
        CommonSignedResponse<AllNKPDDataSearchType, AllNKPDDataType> GetNKPDAllData(AllNKPDDataSearchType allNkpdSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за търсене на данни от класификатор НКПД по зададени критерии")]
        CommonSignedResponse<NKPDDataSearchType, NKPDDataType> GetNKPDData(NKPDDataSearchType nkpdSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

    }
}
