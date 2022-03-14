using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PvPatentsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Патентно ведомство - Държавен регистър на патентите")]
    public interface IPvPatentsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по заявителски номер на патент")]
        CommonSignedResponse<getPatentByAppNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_App_Number(getPatentByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по име на патент")]
        CommonSignedResponse<getPatentsByNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Name(getPatentsByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по притежател на патент")]
        CommonSignedResponse<getPatentByOwnersNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Owner(getPatentByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по регистрационен номер на патент")]
        CommonSignedResponse<getPatentByRegNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Reg_Number(getPatentByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на патент")]
        //PatentDetailsType GetREG_PATENT_Status_App_Date(getPatentsByStatAppDateType argument, AccessMatrix accessMatrix);
    }
}

