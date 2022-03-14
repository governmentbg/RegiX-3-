using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.MonChildSchoolStudentsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Министерство на образованието и науката - Регистър на средните училища и детските градини")]
    public interface IMonChildSchoolStudentsAPI : IAPIService
    {
        //Справка за състоянието на ученик / дете
        [OperationContract]
        [Description("Справка за състоянието на ученик / дете")]
        [Info(requestXSD: "ChildStudentStatusRequest.xsd",
            responseXSD: "ChildStudentStatusResponse.xsd",
            commonXSD: "MONSchoolsCommon.xsd",
            requestXSLT: "ChildStudentStatusRequest.xslt",
            responseXSLT: "ChildStudentStatusResponse.xslt")]
        ServiceResultDataSigned<ChildStudentStatusRequestType, ChildStudentStatusResponse> GetChildStudentStatus(ServiceRequestData<ChildStudentStatusRequestType> argument);

        //Справка за състоянието на ученик от училище, регистриран в ИС на МОН
        [OperationContract]
        [Description("Справка за състоянието на ученик от училище, регистриран в ИС на МОН")]
        [Info(requestXSD: "SchoolStudentStatusRequest.xsd",
            responseXSD: "SchoolStudentStatusResponse.xsd", 
            commonXSD: "MONSchoolsCommon.xsd",
            requestXSLT: "SchoolStudentStatusRequest.xslt",
            responseXSLT: "SchoolStudentStatusResponse.xslt")]
        ServiceResultDataSigned<SchoolStudentStatusRequestType, SchoolStudentStatusResponse> GetSchoolStudentStatus(ServiceRequestData<SchoolStudentStatusRequestType> argument);
    }
}
