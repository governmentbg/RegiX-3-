using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaosRegister67ZOUAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IaosRegister67ZOUAdapter.APIService
{
    [ExportFullName(typeof(IIaosRegister67ZOUAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaosRegister67ZOUAPI : BaseAPIService<IIaosRegister67ZOUAPI>, IIaosRegister67ZOUAPI
    {
        public ServiceResultDataSigned<REG35_Info_By_EIK_Request, REG35_Info_By_EIK_Response> GetREG35_Info_By_EIK(ServiceRequestData<REG35_Info_By_EIK_Request> argument)
        {
            return  AdapterClient.Execute<IIaosRegister67ZOUAdapter, REG35_Info_By_EIK_Request, REG35_Info_By_EIK_Response>(
                (i, r, a, o) => i.GetREG35_Info_By_EIK(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<REG35_License_Validity_Check_Request, REG35_License_Validity_Check_Response> GetREG35_License_Validity_Check(ServiceRequestData<REG35_License_Validity_Check_Request> argument)
        {
            return AdapterClient.Execute<IIaosRegister67ZOUAdapter, REG35_License_Validity_Check_Request, REG35_License_Validity_Check_Response>(
                (i, r, a, o) => i.GetREG35_License_Validity_Check(r, a, o),
                 argument);
        }        

        public ServiceResultDataSigned<REG35_Stage_Info_By_Pop_Name_Request, REG35_Stage_Info_By_Pop_Name_Response> GetREG35_Stage_Info_By_Pop_Name(ServiceRequestData<REG35_Stage_Info_By_Pop_Name_Request> argument)
        {
            return AdapterClient.Execute<IIaosRegister67ZOUAdapter, REG35_Stage_Info_By_Pop_Name_Request, REG35_Stage_Info_By_Pop_Name_Response>(
                (i, r, a, o) => i.GetREG35_Stage_Info_By_Pop_Name(r, a, o),
                 argument);
        }
         
        public ServiceResultDataSigned<REG35_Stage_Info_By_Waste_Code_Request, REG35_Stage_Info_By_Waste_Code_Response> GetREG35_Stage_Info_By_Waste_Code(ServiceRequestData<REG35_Stage_Info_By_Waste_Code_Request> argument)
        {
            return AdapterClient.Execute<IIaosRegister67ZOUAdapter, REG35_Stage_Info_By_Waste_Code_Request, REG35_Stage_Info_By_Waste_Code_Response>(
                (i, r, a, o) => i.GetREG35_Stage_Info_By_Waste_Code(r, a, o),
                 argument);
        }
         
        public ServiceResultDataSigned<REG35_Stages_By_Reg_Number_And_Waste_Code_Request, REG35_Stages_By_Reg_Number_And_Waste_Code_Response> GetREG35_Stages_By_Reg_Number_And_Waste_Code(ServiceRequestData<REG35_Stages_By_Reg_Number_And_Waste_Code_Request> argument)
        {
            return AdapterClient.Execute<IIaosRegister67ZOUAdapter, REG35_Stages_By_Reg_Number_And_Waste_Code_Request, REG35_Stages_By_Reg_Number_And_Waste_Code_Response>(
                (i, r, a, o) => i.GetREG35_Stages_By_Reg_Number_And_Waste_Code(r, a, o),
                 argument);
        }
         
        public ServiceResultDataSigned<REG35_Validity_Check_By_Reg_Number_Request, REG35_Validity_Check_By_Reg_Number_Response> GetREG35_Validity_Check_By_Reg_Number(ServiceRequestData<REG35_Validity_Check_By_Reg_Number_Request> argument)
        {
            return AdapterClient.Execute<IIaosRegister67ZOUAdapter, REG35_Validity_Check_By_Reg_Number_Request, REG35_Validity_Check_By_Reg_Number_Response>(
                (i, r, a, o) => i.GetREG35_Validity_Check_By_Reg_Number(r, a, o),
                 argument);
        }
    }
}
