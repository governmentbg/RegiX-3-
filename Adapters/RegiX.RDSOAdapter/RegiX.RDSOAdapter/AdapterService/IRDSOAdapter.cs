using System.ComponentModel;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.RDSOAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Регистъра на дипломите за средно образование и Регистъра на заверените образователни документи в МОМН")]
    public interface IRDSOAdapter: IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Извлича данни за дипломите за средно образование на определено лице")]
        CommonSignedResponse<DiplomaSearchType, DiplomaDocumentsType> GetDiplomaInfo(DiplomaSearchType diplomaSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Извлича данни за вписана в регистъра заверка на дипломите на определено лице")]
        CommonSignedResponse<CertifiedDocumentsSearchType, CertifiedDocumentsType> GetCertifiedDiplomaInfo(CertifiedDocumentsSearchType diplomaSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
