using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PvUmAdapter.AdapterService
{
    [ServiceContract]
    [Description("������� �� ����������� � �������� ��������� - �������� �������� �� ������������� �� ������������ �������")]
    public interface IPvUmAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("������� �� ����������� ����� �� ������� �����")]
        CommonSignedResponse<getUtilityModelByAppNumType, PatentDetailsType> GetREG_UM_App_Number(getUtilityModelByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("������� �� ��� �� ������� �����")]
        CommonSignedResponse<getUtilityModelByNameType, PatentDetailsType> GetREG_UM_Name(getUtilityModelByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("������� �� ���������� �� ������� �����")]
        CommonSignedResponse<getUtilityModelByOwnersNameType, PatentDetailsType> GetREG_UM_Owner_Name(getUtilityModelByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("������� �� �������������� ����� �� ������� �����")]
        CommonSignedResponse<getUtilityModelByRegNumType, PatentDetailsType> GetREG_UM_Reg_Number(getUtilityModelByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        //[OperationContract]
        //[Description("������� �� ������ ������ � ���� �� ������� �����")]
        //getUtilityModelByRegNumType GetREG_UM_Stat_App_Date(getUtilityModelByRegNumType argument, AccessMatrix accessMatrix);


    }
}

