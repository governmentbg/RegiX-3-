using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NHIFAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с Национална здравноосигурителна каса")]
    public interface INHIFAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка по ЕГН за изписаните лекарства на пациент")]
        CommonSignedResponse<PatientRecordMedicalTreatmentsRequest, PatientRecordMedicalTreatmentsResponse> GetPatientRecordMedicalTreatments(PatientRecordMedicalTreatmentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕГН за извършените прегледи на пациент")]
        CommonSignedResponse<ReportExamsRequest, ReportExamsResponse> GetReportExams(ReportExamsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за извършените МДД на пациент")]
        CommonSignedResponse<PatientRecordLaboratoryRequest, PatientRecordLaboratoryResponse> GetPatientRecordLaboratory(PatientRecordLaboratoryRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за пролежаванията в болница на пациент")]
        CommonSignedResponse<PatientRecordHospitalizationsRequest, PatientRecordHospitalizationsResponse>GetPatientRecordHospitalizations(PatientRecordHospitalizationsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за извършената стоматологична дейност на пациент")]
        CommonSignedResponse<PatientRecordDentalRequest, PatientRecordDentalResponse> GetPatientRecordDental(PatientRecordDentalRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за извършени дейности по Клинична процедура на пациент")]
        CommonSignedResponse<PatientRecordClinicalProceduresRequest, PatientRecordClinicalProceduresResponse> GetPatientRecordClinicalProcedures(PatientRecordClinicalProceduresRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за лекарства по Клинична процедура на пациент")]
        CommonSignedResponse<PatientRecordDrugsbyClinicalProceduresRequest, PatientRecordDrugsbyClinicalProceduresResponse> GetPatientRecordDrugsbyClinicalProcedures(PatientRecordDrugsbyClinicalProceduresRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за вложените лекарства по КП на пациент")]
        CommonSignedResponse<PatientRecordDrugsByHospitalizationsRequest, PatientRecordDrugsByHospitalizationsResponse> GetPatientRecordDrugsByHospitalizations(PatientRecordDrugsByHospitalizationsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

    }
}
