using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.GraoCivilStatusActsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Регистър на съставените актове за гражданско състояние")]
    public interface IGraoCivilStatusActsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за сключен граждански брак")]
        CommonSignedResponse<MarriageCertificateRequestType, MarriageCertificateResponseType> GetMarriageCertificate(MarriageCertificateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}
