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
//using System.Globalization;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.WebServiceAdapterService;
//using TechnoLogica.RegiX.Common.TransportObject;

//namespace TechnoLogica.RegiX.MonChildSchoolStudentsAdapter.AdapterService
//{
//    public class MonChildSchoolStudentsAdapter : SoapServiceBaseAdapterService, IMonChildSchoolStudentsAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MonChildSchoolStudentsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MonAdapterMockup/MonService.svc")
//                           {
//                               Key = Constants.WebServiceUrlParameterKeyName,
//                               Description = "Web Service Url",
//                               OwnerAssembly = typeof(MonChildSchoolStudentsAdapter).Assembly
//                           };


//        public CommonSignedResponse<ChildStudentStatusRequestType, ChildStudentStatusResponse> GetChildStudentStatus(ChildStudentStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MonServiceReference.wsSoapClient serviceClient = new MonServiceReference.wsSoapClient("wsSoap", WebServiceUrl.Value);
//                MonServiceReference.ChildStudentData[] serviceResult = serviceClient.getChildStudentStatus(argument.ChildIdentifier);

//                ObjectMapper<MonServiceReference.ChildStudentData[], ChildStudentStatusResponse> mapper = CreateMapper(accessMatrix);
//                ChildStudentStatusResponse searchResults = new ChildStudentStatusResponse();
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

//        private static ObjectMapper<MonServiceReference.ChildStudentData[], ChildStudentStatusResponse> CreateMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MonServiceReference.ChildStudentData[], ChildStudentStatusResponse> mapper = new ObjectMapper<MonServiceReference.ChildStudentData[], ChildStudentStatusResponse>(accessMatrix);

//            mapper.AddCollectionMap<MonServiceReference.ChildStudentData[]>(o => o.ChildStudentData, c => c);

//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].ChildIdentifier, (c) => c[0].ChildIdentifier);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].ChildStatus, (c) => c[0].ChildStatus);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].ClassType, (c) => c[0].ClassType);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].DistrictName, (c) => c[0].DistrictName);
//            mapper.AddFunctionMap<MonServiceReference.ChildStudentData[], int>((o) => o.ChildStudentData[0].EducationalYear, c => ((c[0].EducationalYear != null) ? int.Parse(c[0].EducationalYear) : 0));
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EducationForm, (c) => c[0].EducationForm);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EKATTEDistrictCode, (c) => c[0].EKATTEDistrictCode);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EKATTELocationCode, (c) => c[0].EKATTELocationCode);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EKATTEMunicipalityCode, (c) => c[0].EKATTEMunicipalityCode);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].FirstName, (c) => c[0].FirstName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].Grade, (c) => c[0].Grade);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].LastName, (c) => c[0].LastName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].LocationName, (c) => c[0].LocationName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].MiddleName, (c) => c[0].MiddleName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].MunicipalityName, (c) => c[0].MunicipalityName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].SchoolKindergartenName, (c) => c[0].SchoolKindergartenName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].SchoolKindergartenType, (c) => c[0].SchoolKindergartenType);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].UpdateDate, (c) => c[0].UpdateDate);
//            //mapper.AddFunctionMap<MonServiceReference.ChildStudentData[], DateTime?>((o) => o.ChildStudentData[0].UpdateDate, (c) => 
//            //    {
//            //        DateTime date;
//            //        if (DateTime.TryParse(c[0].UpdateDate, out date))
//            //        {
//            //            return date;
//            //        }
//            //        else
//            //        {
//            //            return null;
//            //        }
//            //    });

//            return mapper;
//        }

//        public CommonSignedResponse<SchoolStudentStatusRequestType, SchoolStudentStatusResponse> GetSchoolStudentStatus(SchoolStudentStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MonServiceReference.wsSoapClient serviceClient = new MonServiceReference.wsSoapClient("wsSoap", WebServiceUrl.Value);
//                MonServiceReference.ChildStudentData[] serviceResult = serviceClient.getSchoolStudentStatus(argument.StudentIdentifier);

//                ObjectMapper<MonServiceReference.ChildStudentData[], SchoolStudentStatusResponse> mapper = CreateSchoolMapper(accessMatrix);
//                SchoolStudentStatusResponse searchResults = new SchoolStudentStatusResponse();
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

//        private static ObjectMapper<MonServiceReference.ChildStudentData[], SchoolStudentStatusResponse> CreateSchoolMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MonServiceReference.ChildStudentData[], SchoolStudentStatusResponse> mapper = new ObjectMapper<MonServiceReference.ChildStudentData[], SchoolStudentStatusResponse>(accessMatrix);

//            mapper.AddCollectionMap<MonServiceReference.ChildStudentData[]>(o => o.ChildStudentData, c => c);

//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].ChildIdentifier, (c) => c[0].ChildIdentifier);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].ChildStatus, (c) => c[0].ChildStatus);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].ClassType, (c) => c[0].ClassType);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].DistrictName, (c) => c[0].DistrictName);
//            mapper.AddFunctionMap<MonServiceReference.ChildStudentData[], int>((o) => o.ChildStudentData[0].EducationalYear, c => ((c[0].EducationalYear != null) ? int.Parse(c[0].EducationalYear) : 0));
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EducationForm, (c) => c[0].EducationForm);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EKATTEDistrictCode, (c) => c[0].EKATTEDistrictCode);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EKATTELocationCode, (c) => c[0].EKATTELocationCode);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].EKATTEMunicipalityCode, (c) => c[0].EKATTEMunicipalityCode);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].FirstName, (c) => c[0].FirstName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].Grade, (c) => c[0].Grade);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].LastName, (c) => c[0].LastName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].LocationName, (c) => c[0].LocationName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].MiddleName, (c) => c[0].MiddleName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].MunicipalityName, (c) => c[0].MunicipalityName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].SchoolKindergartenName, (c) => c[0].SchoolKindergartenName);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].SchoolKindergartenType, (c) => c[0].SchoolKindergartenType);
//            mapper.AddPropertyMap((o) => o.ChildStudentData[0].UpdateDate, (c) => c[0].UpdateDate);
//            //mapper.AddFunctionMap<MonServiceReference.ChildStudentData[], DateTime?>((o) => o.ChildStudentData[0].UpdateDate, (c) =>
//            //{
//            //    DateTime date;
//            //    if (DateTime.TryParse(c[0].UpdateDate, out date))
//            //    {
//            //        return date;
//            //    }
//            //    else
//            //    {
//            //        return null;
//            //    }
//            //});
//            return mapper;
//        }
//    }
//}
