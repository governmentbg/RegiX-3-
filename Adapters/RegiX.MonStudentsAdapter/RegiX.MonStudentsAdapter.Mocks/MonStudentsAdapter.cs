//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Data;
//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.WebServiceAdapterService;

//namespace TechnoLogica.RegiX.MonStudentsAdapter.AdapterService
//{
//    public class MonStudentsAdapter : SoapServiceBaseAdapterService, IMonStudentsAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MonStudentsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MonAdapterMockup/MonService.svc")
//                           {
//                               Key = Constants.WebServiceUrlParameterKeyName,
//                               Description = "Web Service Url",
//                               OwnerAssembly = typeof(MonStudentsAdapter).Assembly
//                           };


//        public CommonSignedResponse<HigherEduStudentByStatusRequestType, HigherEduStudentByStatusResponse> GetHigherEduStudentByStatus(HigherEduStudentByStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MonServiceReference.wsSoapClient serviceClient = new MonServiceReference.wsSoapClient("wsSoap", WebServiceUrl.Value);
//                int intStatus = Convert.ToInt32(argument.StudentStatus);
//                MonServiceReference.StudentData[] serviceResult = serviceClient.getHigherEduStudentByStatus(argument.StudentIdentifier, intStatus);

//                ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentByStatusResponse> mapper = CreateHigherEduStudentByStatusMapper(accessMatrix);
//                HigherEduStudentByStatusResponse searchResults = new HigherEduStudentByStatusResponse();
//                mapper.Map(serviceResult, searchResults);
//                return
//                     SigningUtils.CreateAndSign(
//                         argument,
//                         searchResults,
//                         accessMatrix,
//                         aditionalParameters
//                     );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        //TODO: ������� ������ � ServiceReference -> HigherSchoolLoaction  �  Subject.
//        private static ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentByStatusResponse> CreateHigherEduStudentByStatusMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentByStatusResponse> mapper = new ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentByStatusResponse>(accessMatrix);

//            mapper.AddCollectionMap<MonServiceReference.StudentData[]>(o => o.StudentData, c => c);
//            mapper.AddPropertyMap((o) => o.StudentData[0].AcquiredDegree, (c) => c[0].AcquiredDegree);
//            mapper.AddPropertyMap((o) => o.StudentData[0].EducationalCourse, (c) => c[0].EducationalCourse);
//            mapper.AddPropertyMap((o) => o.StudentData[0].EducationalForm, (c) => c[0].EducationalForm);
//            mapper.AddFunctionMap<MonServiceReference.StudentData[], int>((o) => o.StudentData[0].EducationalYear, c => ((c[0].EducationalYear != null) ? int.Parse(c[0].EducationalYear) : 0));
//            mapper.AddPropertyMap((o) => o.StudentData[0].FacultyName, (c) => c[0].FacultyName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].FacultyNumber, (c) => c[0].FacultyNumber);
//            mapper.AddPropertyMap((o) => o.StudentData[0].FirstName, (c) => c[0].FirstName);
//            //mapper.AddPropertyMap((o) => o.StudentData[0].HigherSchollLocation, (c) => c[0].);
//            mapper.AddPropertyMap((o) => o.StudentData[0].HigherSchoolName, (c) => c[0].HigherSchoolName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].LastName, (c) => c[0].LastName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].MiddleName, (c) => c[0].MiddleName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].Nationality, (c) => c[0].Nationality);
//            mapper.AddPropertyMap((o) => o.StudentData[0].ProfessionalField, (c) => c[0].ProfessionalField);
//            mapper.AddPropertyMap((o) => o.StudentData[0].Semester, (c) => c[0].Semester);
//            mapper.AddPropertyMap((o) => o.StudentData[0].StudentIdentifier, (c) => c[0].StudentIdentifier);
//            mapper.AddPropertyMap((o) => o.StudentData[0].StudentStatus, (c) => c[0].StudentStatus);
//            //mapper.AddPropertyMap((o) => o.StudentData[0].Subject, (c) => c[0].);
//            mapper.AddPropertyMap((o) => o.StudentData[0].UpdateDate, (c) => c[0].UpdateDate);
//            return mapper;
//        }


//        public CommonSignedResponse<HigherEduStudentRequestType, HigherEduStudentResponse> GetHigherEduStudent(HigherEduStudentRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MonServiceReference.wsSoapClient serviceClient = new MonServiceReference.wsSoapClient("wsSoap", WebServiceUrl.Value);
//                MonServiceReference.StudentData[] serviceResult = serviceClient.getHigherEduStudent(argument.StudentIdentifier);

//                ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentResponse> mapper = CreateHigherEduStudentMapper(accessMatrix);
//                HigherEduStudentResponse searchResults = new HigherEduStudentResponse();
//                mapper.Map(serviceResult, searchResults);
//                return
//                     SigningUtils.CreateAndSign(
//                         argument,
//                         searchResults,
//                         accessMatrix,
//                         aditionalParameters
//                     );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        //TODO: ������� ������ � ServiceReference -> HigherSchoolLoaction  �  Subject.
//        private static ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentResponse> CreateHigherEduStudentMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentResponse> mapper = new ObjectMapper<MonServiceReference.StudentData[], HigherEduStudentResponse>(accessMatrix);

//            mapper.AddCollectionMap<MonServiceReference.StudentData[]>(o => o.StudentData, c => c);
//            mapper.AddPropertyMap((o) => o.StudentData[0].AcquiredDegree, (c) => c[0].AcquiredDegree);
//            mapper.AddPropertyMap((o) => o.StudentData[0].EducationalCourse, (c) => c[0].EducationalCourse);
//            mapper.AddPropertyMap((o) => o.StudentData[0].EducationalForm, (c) => c[0].EducationalForm);
//            mapper.AddFunctionMap<MonServiceReference.StudentData[], int>((o) => o.StudentData[0].EducationalYear, c => ((c[0].EducationalYear != null) ? int.Parse(c[0].EducationalYear) : 0));
//            mapper.AddPropertyMap((o) => o.StudentData[0].FacultyName, (c) => c[0].FacultyName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].FacultyNumber, (c) => c[0].FacultyNumber);
//            mapper.AddPropertyMap((o) => o.StudentData[0].FirstName, (c) => c[0].FirstName);
//            //mapper.AddPropertyMap((o) => o.StudentData[0].HigherSchollLocation, (c) => c[0].);
//            mapper.AddPropertyMap((o) => o.StudentData[0].HigherSchoolName, (c) => c[0].HigherSchoolName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].LastName, (c) => c[0].LastName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].MiddleName, (c) => c[0].MiddleName);
//            mapper.AddPropertyMap((o) => o.StudentData[0].Nationality, (c) => c[0].Nationality);
//            mapper.AddPropertyMap((o) => o.StudentData[0].ProfessionalField, (c) => c[0].ProfessionalField);
//            mapper.AddPropertyMap((o) => o.StudentData[0].Semester, (c) => c[0].Semester);
//            mapper.AddPropertyMap((o) => o.StudentData[0].StudentIdentifier, (c) => c[0].StudentIdentifier);
//            mapper.AddPropertyMap((o) => o.StudentData[0].StudentStatus, (c) => c[0].StudentStatus);
//            //mapper.AddPropertyMap((o) => o.StudentData[0].Subject, (c) => c[0].);
//            mapper.AddPropertyMap((o) => o.StudentData[0].UpdateDate, (c) => c[0].UpdateDate);
//            return mapper;
//        }

//    }
//}
