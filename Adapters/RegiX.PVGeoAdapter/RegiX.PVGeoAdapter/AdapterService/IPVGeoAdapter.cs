using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PVGeoAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Патентно ведомство - Държавен регистър на географските означения")]
    public interface IPVGeoAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за статус на географско означение по заявителски номер")]
        CommonSignedResponse<GetGIByAppNumType, GIDetailsType> GetREG_GEO_App_Num(GetGIByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за географско означение по име")]
        CommonSignedResponse<GetGIByNameType, GIDetailsType> GetREG_GEO_GI_Name(GetGIByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка за географски означения по ползвател")]
        CommonSignedResponse<GetGIByUserNameType, GIDetailsType> GetREG_GEO_GI_User(GetGIByUserNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Справка по регистров номер на географско означение")]
        CommonSignedResponse<GetGIByRegNumType, GIDetailsType> GetREG_GEO_Reg_Num(GetGIByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        //[OperationContract]
        //[Description("Справка по правен статус и дата на географско означение")]
        //GIDetailsType GetREG_GEO_Stat_App_Date(GIDetailsType argument, AccessMatrix accessMatrix);


    }
}

