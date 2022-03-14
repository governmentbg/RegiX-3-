using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MonStudentsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Министерство на образованието и науката - Регистър на всички действащи и прекъснали студентите и докторанти")]
    public interface IMonStudentsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за всички студенти или докторанти със статус 'действащ' и 'отчислен с право на защита', по подаден идентификатор")]
        CommonSignedResponse<HigherEduStudentByStatusRequestType, HigherEduStudentByStatusResponse> GetHigherEduStudentByStatus(HigherEduStudentByStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за всички студенти или докторанти с всички статуси без ограничение, по подаден идентификатор")]
        CommonSignedResponse<HigherEduStudentRequestType, HigherEduStudentResponse> GetHigherEduStudent(HigherEduStudentRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

