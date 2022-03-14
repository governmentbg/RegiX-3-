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
//using TechnoLogica.RegiX.WebServiceAdapterService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;

//namespace TechnoLogica.RegiX.IaosRegister67ZOUAdapter.AdapterService
//{
//    public class IaosRegister67ZOUAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosRegister67ZOUAdapter, IAdapterService
//    {
//        //public IaosRegister67ZOUAdapter()
//        //{
//        //    WebServiceUrl =
//        //        // new ParameterInfo<string>("http://localhost:8078/IaosRegister67ZUOAdapterMockup/Register67ZUOService.svc"
//        //       new ParameterInfo<string>("https://source.gravis.bg/egov/services/reg35-registration")
//        //       {
//        //           Key = "ServiceUrl",
//        //           Description = "IaosRegister67ZOU Web Service Url",
//        //           OwnerAssembly = typeof(IaosRegister67ZOUAdapter).Assembly
//        //       };
//        //}

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(IaosRegister67ZOUAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//               new ParameterInfo<string>("https://source.gravis.bg/egov/services/reg35-registration")
//               {
//                   Key = Constants.WebServiceUrlParameterKeyName,
//                   Description = "Connection String for SOAP Web Service",
//                   OwnerAssembly = typeof(IaosRegister67ZOUAdapter).Assembly
//               };



//        public CommonSignedResponse<REG35_Info_By_EIK_Request, REG35_Info_By_EIK_Response> GetREG35_Info_By_EIK(REG35_Info_By_EIK_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                REG35RegServiceReference.REG35RegServiceClient serviceClient = new REG35RegServiceReference.REG35RegServiceClient("REG35RegServiceImplPort", WebServiceUrl.Value);
//                REG35RegServiceReference.AuthorizationRegInfo[] serviceResult = serviceClient.getInfoByEIK(argument.EIK);

//                ObjectMapper<REG35RegServiceReference.AuthorizationRegInfo[], REG35_Info_By_EIK_Response> mapper = CreateInfoByEIKMapper(accessMatrix);
//                REG35_Info_By_EIK_Response searchResults = new REG35_Info_By_EIK_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     searchResults,
//                     accessMatrix,
//                     aditionalParameters
//                 );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }
//        private static ObjectMapper<REG35RegServiceReference.AuthorizationRegInfo[], REG35_Info_By_EIK_Response> CreateInfoByEIKMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<REG35RegServiceReference.AuthorizationRegInfo[], REG35_Info_By_EIK_Response> mapper = new ObjectMapper<REG35RegServiceReference.AuthorizationRegInfo[], REG35_Info_By_EIK_Response>(accessMatrix);
//            mapper.AddCollectionMap<REG35RegServiceReference.AuthorizationRegInfo[]>((o) => o.Authorization, (c) => c);
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationRegInfo, AuthState35>((o) => o.Authorization[0].State, (c) => (AuthState35)Enum.Parse(typeof(AuthState35), "Item" + c.State));
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationRegInfo, AuthorizationType>((o) => o.Authorization[0].AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));
//            mapper.AddPropertyMap((o) => o.Authorization[0].AuthNum, (c) => c[0].AuthNum);
//            mapper.AddPropertyMap((o) => o.Authorization[0].Riosv, (c) => c[0].Riosv);
//            return mapper;
//        }


//        public CommonSignedResponse<REG35_License_Validity_Check_Request, REG35_License_Validity_Check_Response> GetREG35_License_Validity_Check(REG35_License_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                REG35RegServiceReference.REG35RegServiceClient serviceClient = new REG35RegServiceReference.REG35RegServiceClient("REG35RegServiceImplPort", WebServiceUrl.Value);
//                REG35RegServiceReference.reg35LicenseValidityCheck serviceResult = serviceClient.getLicenseValidityCheck(argument.AuthNum, argument.Date);

//                ObjectMapper<REG35RegServiceReference.reg35LicenseValidityCheck, REG35_License_Validity_Check_Response> mapper = CreateLicenseValidityCheckMapper(accessMatrix);
//                REG35_License_Validity_Check_Response searchResults = new REG35_License_Validity_Check_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     searchResults,
//                     accessMatrix,
//                     aditionalParameters
//                 );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<REG35RegServiceReference.reg35LicenseValidityCheck, REG35_License_Validity_Check_Response> CreateLicenseValidityCheckMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<REG35RegServiceReference.reg35LicenseValidityCheck, REG35_License_Validity_Check_Response> mapper =
//                new ObjectMapper<REG35RegServiceReference.reg35LicenseValidityCheck, REG35_License_Validity_Check_Response>(accessMatrix);
//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationValidityCheckByDate, AuthState35>((o) => o.Authorization.State, (c) => (AuthState35)Enum.Parse(typeof(AuthState35), "Item" + c.State));
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationValidityCheckByDate, AuthorizationType>((o) => o.Authorization.AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));

//            // mapper.AddPropertyMap((o) => o.Authorization.AuthType, (c) => Enum.Parse(typeof(AuthorizationType), c.Authorization.AuthType));
//            // mapper.AddPropertyMap((o) => o.Authorization.State, (c) => Enum.Parse(typeof(AuthState35), c.Authorization.State));
//            mapper.AddPropertyMap((o) => o.Authorization.DateFrom, (c) => c.Authorization.DateFrom);
//            mapper.AddPropertyMap((o) => o.Authorization.DateTo, (c) => c.Authorization.DateTo);
//            mapper.AddPropertyMap((o) => o.Authorization.RIOSV, (c) => c.Authorization.RIOSV);

//            return mapper;
//        }

//        public CommonSignedResponse<REG35_Stage_Info_By_Pop_Name_Request, REG35_Stage_Info_By_Pop_Name_Response> GetREG35_Stage_Info_By_Pop_Name(REG35_Stage_Info_By_Pop_Name_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                REG35RegServiceReference.REG35RegServiceClient serviceClient = new REG35RegServiceReference.REG35RegServiceClient("REG35RegServiceImplPort", WebServiceUrl.Value);
//                REG35RegServiceReference.reg35StageInfoByPopName serviceResult = serviceClient.getStageInfoByPopName(argument.AuthNum, argument.PopName);

//                ObjectMapper<REG35RegServiceReference.reg35StageInfoByPopName, REG35_Stage_Info_By_Pop_Name_Response> mapper = CreateStageInfoMapper(accessMatrix);
//                REG35_Stage_Info_By_Pop_Name_Response searchResults = new REG35_Stage_Info_By_Pop_Name_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     searchResults,
//                     accessMatrix,
//                     aditionalParameters
//                 );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<REG35RegServiceReference.reg35StageInfoByPopName, REG35_Stage_Info_By_Pop_Name_Response> CreateStageInfoMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<REG35RegServiceReference.reg35StageInfoByPopName, REG35_Stage_Info_By_Pop_Name_Response> mapper = new ObjectMapper<REG35RegServiceReference.reg35StageInfoByPopName, REG35_Stage_Info_By_Pop_Name_Response>(accessMatrix);
//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddPropertyMap((o) => o.Authorization.ContactPerson, (c) => c.Authorization.ContactPerson);
//            mapper.AddPropertyMap((o) => o.Authorization.Phone, (c) => c.Authorization.Phone);
//            mapper.AddCollectionMap<REG35RegServiceReference.reg35StageInfoByPopName>((o) => o.Authorization.Stage, (c) => c.Authorization.Stage);
//            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].StageAddress, (c) => c.Authorization.Stage[0].StageAddress);
//            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].StageNum, (c) => c.Authorization.Stage[0].StageNum);
//            //(c) -> WasteCodes missing
//            //mapper.AddPropertyMap((o) => o.Authorization.Stages.Stage[0].WasteCodes, (c) => c.Authorization.Stage[0].WasteCodes);


//            return mapper;
//        }

//        public CommonSignedResponse<REG35_Stage_Info_By_Waste_Code_Request, REG35_Stage_Info_By_Waste_Code_Response> GetREG35_Stage_Info_By_Waste_Code(REG35_Stage_Info_By_Waste_Code_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                REG35RegServiceReference.REG35RegServiceClient serviceClient = new REG35RegServiceReference.REG35RegServiceClient("REG35RegServiceImplPort", WebServiceUrl.Value);
//                REG35RegServiceReference.AuthorizationByWasteCode[] serviceResult = serviceClient.getStageInfoByWasteCode(argument.EIK, argument.WasteOperation);

//                ObjectMapper<REG35RegServiceReference.AuthorizationByWasteCode[], REG35_Stage_Info_By_Waste_Code_Response> mapper = CreateStageInfoByWasteCodeMapper(accessMatrix);
//                REG35_Stage_Info_By_Waste_Code_Response searchResults = new REG35_Stage_Info_By_Waste_Code_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     searchResults,
//                     accessMatrix,
//                     aditionalParameters
//                 );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<REG35RegServiceReference.AuthorizationByWasteCode[], REG35_Stage_Info_By_Waste_Code_Response> CreateStageInfoByWasteCodeMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<REG35RegServiceReference.AuthorizationByWasteCode[], REG35_Stage_Info_By_Waste_Code_Response> mapper = new ObjectMapper<REG35RegServiceReference.AuthorizationByWasteCode[], REG35_Stage_Info_By_Waste_Code_Response>(accessMatrix);

//            mapper.AddCollectionMap<REG35RegServiceReference.AuthorizationByWasteCode[]>((o) => o.Authorization, (c) => c);
//            mapper.AddPropertyMap((o) => o.Authorization[0].AuthNum, (c) => c[0].AuthNum);
//            //mapper.AddPropertyMap((o) => o.Authorization[0].AuthType, (c) => Enum.Parse(typeof(AuthorizationType), c[0].AuthType));
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationByWasteCode, AuthorizationType>((o) => o.Authorization[0].AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));
//            mapper.AddPropertyMap((o) => o.Authorization[0].ContactPerson, (c) => c[0].ContactPerson);
//            mapper.AddPropertyMap((o) => o.Authorization[0].Phone, (c) => c[0].Phone);


//            mapper.AddCollectionMap<REG35RegServiceReference.AuthorizationByWasteCode[]>((o) => o.Authorization[0].Stage, (c) => c[0].Stage);
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationByWasteCode, List<string>>((o) => o.Authorization[0].Stage[0].WasteCode, (c) => c.Stage[0].WasteCode.ToList());
//            //mapper.AddPropertyMap((o) => o.Authorization[0].Stage[0].WasteCode[0], (c) => c[0].Stage[0].WasteCode[0]);
//            mapper.AddPropertyMap((o) => o.Authorization[0].Stage[0].StageNum, (c) => c[0].Stage[0].StageNum);
//            mapper.AddPropertyMap((o) => o.Authorization[0].Stage[0].StageAddress, (c) => c[0].Stage[0].StageAddress);


//            return mapper;
//        }

//        public CommonSignedResponse<REG35_Stages_By_Reg_Number_And_Waste_Code_Request, REG35_Stages_By_Reg_Number_And_Waste_Code_Response> GetREG35_Stages_By_Reg_Number_And_Waste_Code(REG35_Stages_By_Reg_Number_And_Waste_Code_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                REG35RegServiceReference.REG35RegServiceClient serviceClient = new REG35RegServiceReference.REG35RegServiceClient("REG35RegServiceImplPort", WebServiceUrl.Value);
//                REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode serviceResult = serviceClient.getStagesByRegNumberAndWasteCode(argument.AuthNum, argument.WasteCode);

//                ObjectMapper<REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode, REG35_Stages_By_Reg_Number_And_Waste_Code_Response> mapper = CreateStagesByRegNumberAndWasteCodeMapper(accessMatrix);
//                REG35_Stages_By_Reg_Number_And_Waste_Code_Response searchResults = new REG35_Stages_By_Reg_Number_And_Waste_Code_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     searchResults,
//                     accessMatrix,
//                     aditionalParameters
//                 );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode, REG35_Stages_By_Reg_Number_And_Waste_Code_Response> CreateStagesByRegNumberAndWasteCodeMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode, REG35_Stages_By_Reg_Number_And_Waste_Code_Response> mapper = new ObjectMapper<REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode, REG35_Stages_By_Reg_Number_And_Waste_Code_Response>(accessMatrix);

//            //??
//            //Òðÿáâà â xsd äà èìà îòäåëíè string åëåìåíòè çà StageAddress, StageNum, WasteCode
//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddCollectionMap<REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode>((o) => o.Authorization.Stage, (c) => c.Authorization.Stage);
//            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].StageAddress, (c) => c.Authorization.Stage[0].StageAddress);
//            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].StageNum, (c) => c.Authorization.Stage[0].StageNum);

//            mapper.AddFunctionMap<REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode, List<string>>((o) => o.Authorization.Stage[0].WasteCode, (c) => c.Authorization.Stage[0].WasteCode.ToList());

//            // mapper.AddCollectionMap<REG35RegServiceReference.reg35StagesByRegNumberAndWasteCode>((o) => o.Authorization.Stages.Stage[0].WasteCodes.WasteCode, (c) => c.Authorization.Stage[0].WasteCode);
//            //mapper.AddPropertyMap((o) => o.Authorization.Stages.Stage[0].WasteCodes.WasteCode[0], (c) => c.Authorization.Stage[0].WasteCode[0]);

//            mapper.AddPropertyMap((o) => o.Authorization.ContactPerson, (c) => c.Authorization.ContactPerson);
//            mapper.AddPropertyMap((o) => o.Authorization.Phone, (c) => c.Authorization.Phone);


//            return mapper;
//        }




//        public CommonSignedResponse<REG35_Validity_Check_By_Reg_Number_Request, REG35_Validity_Check_By_Reg_Number_Response> GetREG35_Validity_Check_By_Reg_Number(REG35_Validity_Check_By_Reg_Number_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                REG35RegServiceReference.REG35RegServiceClient serviceClient = new REG35RegServiceReference.REG35RegServiceClient("REG35RegServiceImplPort", WebServiceUrl.Value);
//                REG35RegServiceReference.reg35ValidityCheckByRegNumber serviceResult = serviceClient.getValidityCheckByRegNum(argument.AuthNum);

//                ObjectMapper<REG35RegServiceReference.reg35ValidityCheckByRegNumber, REG35_Validity_Check_By_Reg_Number_Response> mapper = CreateValidityCheckMapper(accessMatrix);
//                REG35_Validity_Check_By_Reg_Number_Response searchResults = new REG35_Validity_Check_By_Reg_Number_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     searchResults,
//                     accessMatrix,
//                     aditionalParameters
//                 );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<REG35RegServiceReference.reg35ValidityCheckByRegNumber, REG35_Validity_Check_By_Reg_Number_Response> CreateValidityCheckMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<REG35RegServiceReference.reg35ValidityCheckByRegNumber, REG35_Validity_Check_By_Reg_Number_Response> mapper = new ObjectMapper<REG35RegServiceReference.reg35ValidityCheckByRegNumber, REG35_Validity_Check_By_Reg_Number_Response>(accessMatrix);
//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationValidityCheck, AuthState35>((o) => o.Authorization.State, (c) => (AuthState35)Enum.Parse(typeof(AuthState35), "Item" + c.State));
//            mapper.AddFunctionMap<REG35RegServiceReference.AuthorizationValidityCheck, AuthorizationType>((o) => o.Authorization.AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));


//            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
//            mapper.AddPropertyMap((o) => o.Authorization.DateIssued, (c) => c.Authorization.DateIssued);
//            mapper.AddPropertyMap((o) => o.Authorization.EIK, (c) => c.Authorization.EIK);


//            return mapper;
//        }
//    }
//}
