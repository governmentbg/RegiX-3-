using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PvSpcAdapter.AdapterService
{
    [ServiceContract]
    [Description("������� �� ����������� � �������� ��������� - �������� �������� �� ������������� �� ������������ �������")]
    public interface IPvSpcAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("������� �� ����������� ����� �� ���������� �� ������������ �������")]
        CommonSignedResponse<getSPCByPatentAppNumType, SPCDetailsType> GetREG_SPC_App_Number(getSPCByPatentAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("������� �� ���������� �� ���������� �� ������������ �������")]
        CommonSignedResponse<getSPCByOwnersNameType, SPCDetailsType> GetREG_SPC_Owner(getSPCByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("������� �� �������������� ����� �� ���������� �� ������������ �������")]
        CommonSignedResponse<getSPCByAppNumType, SPCDetailsType> GetREG_SPC_Reg_Number(getSPCByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        //[OperationContract]
        //[Description("������� �� ������ ������ � ���� �� ���������� �� ������������ �������")]
        //SPCDetailsType GetREG_SPC_Stat_App_Date(SPCDetailsType argument, AccessMatrix accessMatrix);
    }
}

