using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NHIFAdapter.AdapterService;

namespace TechnoLogica.RegiX.NHIFAdapter.APIService
{
    [ExportFullName(typeof(INHIFAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NHIFAPI : BaseAPIService<INHIFAPI>, INHIFAPI
    {
        public ServiceResultDataSigned<PatientRecordMedicalTreatmentsRequest, PatientRecordMedicalTreatmentsResponse> GetPatientRecordMedicalTreatments(ServiceRequestData<PatientRecordMedicalTreatmentsRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, PatientRecordMedicalTreatmentsRequest, PatientRecordMedicalTreatmentsResponse>(
                (i, r, a, o) => i.GetPatientRecordMedicalTreatments(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<ReportExamsRequest, ReportExamsResponse> GetReportExams(ServiceRequestData<ReportExamsRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, ReportExamsRequest, ReportExamsResponse>(
                (i, r, a, o) => i.GetReportExams(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PatientRecordLaboratoryRequest, PatientRecordLaboratoryResponse> GetPatientRecordLaboratory(ServiceRequestData<PatientRecordLaboratoryRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, PatientRecordLaboratoryRequest, PatientRecordLaboratoryResponse>(
                (i, r, a, o) => i.GetPatientRecordLaboratory(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PatientRecordHospitalizationsRequest, PatientRecordHospitalizationsResponse> GetPatientRecordHospitalizations(ServiceRequestData<PatientRecordHospitalizationsRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, PatientRecordHospitalizationsRequest, PatientRecordHospitalizationsResponse>(
                (i, r, a, o) => i.GetPatientRecordHospitalizations(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PatientRecordDentalRequest, PatientRecordDentalResponse> GetPatientRecordDental(ServiceRequestData<PatientRecordDentalRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, PatientRecordDentalRequest, PatientRecordDentalResponse>(
                (i, r, a, o) => i.GetPatientRecordDental(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PatientRecordClinicalProceduresRequest, PatientRecordClinicalProceduresResponse> GetPatientRecordClinicalProcedures(ServiceRequestData<PatientRecordClinicalProceduresRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, PatientRecordClinicalProceduresRequest, PatientRecordClinicalProceduresResponse>(
                (i, r, a, o) => i.GetPatientRecordClinicalProcedures(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PatientRecordDrugsbyClinicalProceduresRequest, PatientRecordDrugsbyClinicalProceduresResponse> GetPatientRecordDrugsbyClinicalProcedures(ServiceRequestData<PatientRecordDrugsbyClinicalProceduresRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, PatientRecordDrugsbyClinicalProceduresRequest, PatientRecordDrugsbyClinicalProceduresResponse>(
                (i, r, a, o) => i.GetPatientRecordDrugsbyClinicalProcedures(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PatientRecordDrugsByHospitalizationsRequest, PatientRecordDrugsByHospitalizationsResponse> GetPatientRecordDrugsByHospitalizations(ServiceRequestData<PatientRecordDrugsByHospitalizationsRequest> argument)
        {
            return AdapterClient.Execute<INHIFAdapter, PatientRecordDrugsByHospitalizationsRequest, PatientRecordDrugsByHospitalizationsResponse>(
                (i, r, a, o) => i.GetPatientRecordDrugsByHospitalizations(r, a, o),
                 argument);
        }

        public override string GetMetaDataXML(string operationName)
        {
            return "---";
        }
    }
}
