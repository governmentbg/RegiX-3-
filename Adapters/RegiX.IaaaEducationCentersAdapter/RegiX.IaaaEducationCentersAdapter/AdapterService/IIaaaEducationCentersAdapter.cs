using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaaaEducationCentersAdapter.AdapterService
{
    [ServiceContract]
    [Description("Регистър за издадените удостоверения за регистрация за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.")]
    public interface IIaaaEducationCentersAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕИК за регистрация на фирма.")]
        CommonSignedResponse<PermitsRequestType, PermitResponse> GetReport1Permit(PermitsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК за регистрирани преподаватели.")]
        CommonSignedResponse<PermitsRequestType, PermitInstructorsResponse> GetReport2PermitInstructors(PermitsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК за регистрирани учебни ППС.")]
        CommonSignedResponse<PermitsRequestType, PermitVehiclesResponse> GetReport3PermitVehicles(PermitsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по лице за вписвания в разрешителни за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им")]
        CommonSignedResponse<PermitsInstructorsRequestType, PermitsInstructorsResponse> GetReport4InstructorPermitsDetails(PermitsInstructorsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК и период за брой обучени лица в център за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.")]
        CommonSignedResponse<PermitsExamPeopleCountRequestType, PermitsExamPeopleCountResponse> GetReport5PermitsExamPeopleCount(PermitsExamPeopleCountRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН/ЛНЧ за придобити категории за управление на ППС.")]
        CommonSignedResponse<SubjectOwnedCategoriesRequestType, SubjectOwnedCategoriesResponse> GetReport6SubjectOwnedCategories(SubjectOwnedCategoriesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

