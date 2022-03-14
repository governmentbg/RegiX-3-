using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Изпълнителната агенция по околна среда - Регистър на защитените територии и защитените зони в България")]
    public interface IIaosREGProtectedAreasAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за площ на защитена територия/зона")]
        CommonSignedResponse<REG_PAPZ_Protected_Area_Size_Request, REG_PAPZ_Protected_Area_Size_Response> GetREG_PAPZ_Protected_Area_Size(REG_PAPZ_Protected_Area_Size_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по категория на защитена територия/зона")]
        CommonSignedResponse<REG_PAPZ_Protected_Area_Category_Request, REG_PAPZ_Protected_Area_Category_Response> GetREG_PAPZ_Protected_Area_Category(REG_PAPZ_Protected_Area_Category_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по местонахождение")]
        CommonSignedResponse<REG_PAPZ_Protected_Area_Location_Request, REG_PAPZ_Protected_Area_Location_Response> GetREG_PAPZ_Protected_Area_Location(REG_PAPZ_Protected_Area_Location_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

