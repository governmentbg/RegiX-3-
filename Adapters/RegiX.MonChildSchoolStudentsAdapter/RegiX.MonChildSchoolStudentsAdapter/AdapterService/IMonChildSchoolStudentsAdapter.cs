using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MonChildSchoolStudentsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Министерство на образованието и науката - Регистър на средните училища и детските градини")]
    public interface IMonChildSchoolStudentsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за състоянието на ученик / дете")]
        CommonSignedResponse<ChildStudentStatusRequestType, ChildStudentStatusResponse> GetChildStudentStatus(ChildStudentStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за състоянието на ученик от училище, регистриран в ИС на МОН")]
        CommonSignedResponse<SchoolStudentStatusRequestType, SchoolStudentStatusResponse> GetSchoolStudentStatus(SchoolStudentStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

