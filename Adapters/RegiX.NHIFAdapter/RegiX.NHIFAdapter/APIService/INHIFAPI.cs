using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NHIFAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Национална здравноосигурителна каса")]
    public interface INHIFAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка по ЕГН за изписаните лекарства на пациент")]
        [Info(
            requestXSD: "PatientRecordMedicalTreatmentsRequest.xsd",
            responseXSD: "PatientRecordMedicalTreatmentsResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned <PatientRecordMedicalTreatmentsRequest, PatientRecordMedicalTreatmentsResponse> GetPatientRecordMedicalTreatments(ServiceRequestData<PatientRecordMedicalTreatmentsRequest> argument);

        [OperationContract]
        [Description("Справка по ЕГН за извършените прегледи на пациент")]
        [Info(
            requestXSD: "ReportExamsRequest.xsd",
            responseXSD: "ReportExamsResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned<ReportExamsRequest, ReportExamsResponse> GetReportExams(ServiceRequestData<ReportExamsRequest> argument);

        [OperationContract]
        [Description("Справка за извършените МДД на пациент")]
        [Info(
            requestXSD: "PatientRecordLaboratoryRequest.xsd",
            responseXSD: "PatientRecordLaboratoryResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned<PatientRecordLaboratoryRequest, PatientRecordLaboratoryResponse> GetPatientRecordLaboratory(ServiceRequestData<PatientRecordLaboratoryRequest> argument);

        [OperationContract]
        [Description("Справка за пролежаванията в болница на пациент")]
        [Info(
            requestXSD: "PatientRecordHospitalizationsRequest.xsd",
            responseXSD: "PatientRecordHospitalizationsResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned<PatientRecordHospitalizationsRequest, PatientRecordHospitalizationsResponse> GetPatientRecordHospitalizations(ServiceRequestData<PatientRecordHospitalizationsRequest> argument);

        [OperationContract]
        [Description("Справка за извършената стоматологична дейност на пациент")]
        [Info(
            requestXSD: "PatientRecordDentalRequest.xsd",
            responseXSD: "PatientRecordDentalResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned<PatientRecordDentalRequest, PatientRecordDentalResponse> GetPatientRecordDental(ServiceRequestData<PatientRecordDentalRequest> argument);

        [OperationContract]
        [Description("Справка за извършени дейности по Клинична процедура на пациент")]
        [Info(
            requestXSD: "PatientRecordClinicalProceduresRequest.xsd",
            responseXSD: "PatientRecordClinicalProceduresResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned<PatientRecordClinicalProceduresRequest, PatientRecordClinicalProceduresResponse> GetPatientRecordClinicalProcedures(ServiceRequestData<PatientRecordClinicalProceduresRequest> argument);

        [OperationContract]
        [Description("Справка за лекарства по Клинична процедура на пациент")]
        [Info(
            requestXSD: "PatientRecordDrugsbyClinicalProceduresRequest.xsd",
            responseXSD: "PatientRecordDrugsbyClinicalProceduresResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned<PatientRecordDrugsbyClinicalProceduresRequest, PatientRecordDrugsbyClinicalProceduresResponse> GetPatientRecordDrugsbyClinicalProcedures(ServiceRequestData<PatientRecordDrugsbyClinicalProceduresRequest> argument);

        [OperationContract]
        [Description("Справка за вложените лекарства по КП на пациент")]
        [Info(
            requestXSD: "PatientRecordDrugsByHospitalizationsRequest.xsd",
            responseXSD: "PatientRecordDrugsByHospitalizationsResponse.xsd",
            commonXSD: "NHIFCommon.xsd")]
        ServiceResultDataSigned<PatientRecordDrugsByHospitalizationsRequest, PatientRecordDrugsByHospitalizationsResponse> GetPatientRecordDrugsByHospitalizations(ServiceRequestData<PatientRecordDrugsByHospitalizationsRequest> argument);
    }
}
