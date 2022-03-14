using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaaaEducationCentersAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("Регистър за издадените удостоверения за регистрация за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.")]
    public interface IIaaaEducationCentersAPI : IAPIService
    {
        //Справка по ЕИК за регистрация на фирма
        [OperationContract]
        [Description("Справка по ЕИК за регистрация на фирма")]
        [Info(
            requestXSD: "Report1_permitsRequest.xsd",
            responseXSD: "Report1_permitResponse.xsd",
            commonXSD: "REDUCommon.xsd",
            requestXSLT: "Report1_permitsRequest.xslt",
            responseXSLT: "Report1_permitResponse.xslt")]
        ServiceResultDataSigned<PermitsRequestType, PermitResponse> GetReport1Permit(ServiceRequestData<PermitsRequestType> argument);

        //Справка по ЕИК за регистрирани преподаватели
        [OperationContract]
        [Description("Справка по ЕИК за регистрирани преподаватели")]
        [Info(
            requestXSD: "Report1_permitsRequest.xsd",
            responseXSD: "Report2_permitResponseInstructors.xsd",
            commonXSD: "REDUCommon.xsd",
            requestXSLT: "Report1_permitsRequest.xslt",
            responseXSLT: "Report2_permitResponseInstructors.xslt")]
        ServiceResultDataSigned<PermitsRequestType, PermitInstructorsResponse> GetReport2PermitInstructors(ServiceRequestData<PermitsRequestType> argument);

        //Справка по ЕИК за регистрирани учебни ППС
        [OperationContract]
        [Description("Справка по ЕИК за регистрирани учебни ППС")]
        [Info(
            requestXSD: "Report1_permitsRequest.xsd",
            responseXSD: "Report3_permitResponseVehicles.xsd",
            commonXSD: "REDUCommon.xsd",
            requestXSLT: "Report1_permitsRequest.xslt",
            responseXSLT: "Report3_permitResponseVehicles.xslt")]
        ServiceResultDataSigned<PermitsRequestType, PermitVehiclesResponse> GetReport3PermitVehicles(ServiceRequestData<PermitsRequestType> argument);

        //Справка по лице за вписвания в разрешителни за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.
        [OperationContract]
        [Description("Справка по лице за вписвания в разрешителни за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.")]
        [Info(
            requestXSD: "Report4_instructorPermitsDetailsRequest.xsd",
            responseXSD: "Report4_instructorPermitsDetailsResponse.xsd",
            commonXSD: "REDUCommon.xsd",
            requestXSLT: "Report4_instructorPermitsDetailsRequest.xslt",
            responseXSLT: "Report4_instructorPermitsDetailsResponse.xslt")]
        ServiceResultDataSigned<PermitsInstructorsRequestType, PermitsInstructorsResponse> GetReport4InstructorPermitsDetails(ServiceRequestData<PermitsInstructorsRequestType> argument);

        //Справка по ЕИК и период за брой обучени лица в център за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.
        [OperationContract]
        [Description("Справка по ЕИК и период за брой обучени лица в център за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.")]
        [Info(
            requestXSD: "Report5_permitsExamPeopleCountRequest.xsd",
            responseXSD: "Report5_permitsExamPeopleCountResponse.xsd",
            commonXSD: "REDUCommon.xsd",
            requestXSLT: "Report5_permitsExamPeopleCountRequest.xslt",
            responseXSLT: "Report5_permitsExamPeopleCountResponse.xslt")]
        ServiceResultDataSigned<PermitsExamPeopleCountRequestType, PermitsExamPeopleCountResponse> GetReport5PermitsExamPeopleCount(ServiceRequestData<PermitsExamPeopleCountRequestType> argument);

        //Справка по ЕГН/ЛНЧ за придобити категории за управление на ППС.
        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за придобити категории за управление на ППС.")]
        [Info(
            requestXSD: "Report6_subjectOwnedCategoriesRequest.xsd",
            responseXSD: "Report6_subjectOwnedCategoriesResponse.xsd",
            commonXSD: "REDUCommon.xsd",
            requestXSLT: "Report6_subjectOwnedCategoriesRequest.xslt",
            responseXSLT: "Report6_subjectOwnedCategoriesResponse.xslt")]
        ServiceResultDataSigned<SubjectOwnedCategoriesRequestType, SubjectOwnedCategoriesResponse> GetReport6SubjectOwnedCategories(ServiceRequestData<SubjectOwnedCategoriesRequestType> argument);
    }
}
