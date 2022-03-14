using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PvDesignAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Патентно ведомство - Държавен регистър на промишлените дизайни")]
    public interface IPvDesignAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за статус на промишлен дизайн по заявителски номер")]
        CommonSignedResponse<GetDesignByAppNumType, DesignDetailsType> GetREG_DESIGN_App_Number(GetDesignByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за дизайни по наименование")]
        CommonSignedResponse<GetDesignsByNameType, DesignDetailsType> GetREG_DESIGN_Name(GetDesignsByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за дизайни по притежател")]
        CommonSignedResponse<GetDesignByOwnersNameType, DesignDetailsType> GetREG_DESIGN_Owner_Name(GetDesignByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка по номер на дизайн")]
        CommonSignedResponse<GetDesignByRegNumType, DesignDetailsType> GetREG_DESIGN_Reg_Number(GetDesignByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на промишлен дизайн")]
        //REG_DESIGN_Stat_App_Name_Response GetREG_DESIGN_Stat_App_Name(REG_DESIGN_Stat_App_Name_RequestType argument, AccessMatrix accessMatrix);
    }
}

