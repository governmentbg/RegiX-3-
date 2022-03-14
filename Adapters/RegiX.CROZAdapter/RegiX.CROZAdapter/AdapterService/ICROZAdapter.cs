using System.ComponentModel;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.CROZAdapter.AdapterService
{
    [ServiceContract]
    [Description("Централен регистър на особените залози")]
    public interface ICROZAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за търсене на участници по зададен идентификационен код и наименование")]
        CommonSignedResponse<ParticipantsSearchType, ParticipantsDataType> ParticipantsSearch(ParticipantsSearchType consignmentInfoSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
        
        [OperationContract]
        [Description("Справка за извличане на данни за вписванията по партида на определено лице")]
        CommonSignedResponse<ConsignmentInfoSearchType, ConsignmentDataType> GetConsignmentInfo(ConsignmentInfoSearchType consignmentInfoSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за извличане на данни за вписванията във връзка с определена сделка, запор на имущество или решение на съда по несъстоятелност")]
        CommonSignedResponse<DealInfoSearchType, DealInfoDataType> GetDealInfo(DealInfoSearchType dealInfoSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
