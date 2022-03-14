using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.MonStudentsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Министерство на образованието и науката - Регистър на всички действащи и прекъснали студентите и докторанти")]
    public interface IMonStudentsAPI : IAPIService
    {
        //Справка за всички студенти или докторанти със статус действащ и отчислен с право на защита, по подаден идентификатор
        [OperationContract]
        [Description("Справка за всички студенти или докторанти със статус действащ и отчислен с право на защита, по подаден идентификатор")]
        [Info(requestXSD: "HigherEduStudentByStatusRequest.xsd", 
            responseXSD: "HigherEduStudentByStatusResponse.xsd",
            commonXSD: "MONCommon.xsd",
            requestXSLT: "HigherEduStudentByStatusRequest.xslt",
            responseXSLT: "HigherEduStudentByStatusResponse.xslt")]
        ServiceResultDataSigned<HigherEduStudentByStatusRequestType, HigherEduStudentByStatusResponse> GetHigherEduStudentByStatus(ServiceRequestData<HigherEduStudentByStatusRequestType> argument);

        //Справка за всички студенти или докторанти с всички статуси без ограничение, по подаден идентификатор
        [OperationContract]
        [Description("Справка за всички студенти или докторанти с всички статуси без ограничение, по подаден идентификатор")]
        [Info(requestXSD: "HigherEduStudentRequest.xsd",
            responseXSD: "HigherEduStudentResponse.xsd",
            commonXSD: "MONCommon.xsd",
            requestXSLT: "HigherEduStudentRequest.xslt",
            responseXSLT: "HigherEduStudentResponse.xslt")]
        ServiceResultDataSigned<HigherEduStudentRequestType, HigherEduStudentResponse> GetHigherEduStudent(ServiceRequestData<HigherEduStudentRequestType> argument);
    }
}
