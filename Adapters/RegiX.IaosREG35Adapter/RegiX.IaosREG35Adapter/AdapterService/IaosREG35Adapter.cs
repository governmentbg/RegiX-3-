using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosREG35Adapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaosREG35Adapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaosREG35Adapter), typeof(IAdapterService))]
    public class IaosREG35Adapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosREG35Adapter, IAdapterService
    {
        //public IaosREG35Adapter()
        //{

        //    WebServiceUrl =
        //        // new ParameterInfo<string>("http://localhost:8078/IaosREG35AdapterMockup/REG35Service.svc"
        //     new ParameterInfo<string>("https://source.gravis.bg:443/egov/services/reg35-stages")
        //     {
        //         Key = "ServiceUrl",
        //         Description = "IaosREG35 Web Service Url",
        //         OwnerAssembly = typeof(IaosREG35Adapter).Assembly
        //     };
        //}

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaosREG35Adapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           //new ParameterInfo<string>("https://dev.aiskao.com/IaosREG35Mockup/REG35Service.svc")
           new ParameterInfo<string>("https://source.gravis.bg:443/egov/services/reg35-stages")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Connection String for SOAP Web Service",
               OwnerAssembly = typeof(IaosREG35Adapter).Assembly
           };

        public CommonSignedResponse<REG35_Stages_Validity_Period_Request, REG35_Stages_Validity_Period_Response> GetREG35_Stages_Validity_Period(REG35_Stages_Validity_Period_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                REG35ServiceReference.REG35ServiceClient serviceClient = new REG35ServiceReference.REG35ServiceClient("REG35ServiceImplPort", WebServiceUrl.Value);
                REG35ServiceReference.reg35StagesValidityPeriod serviceResult = serviceClient.getStagesValidityPeriod(argument.AuthNum, argument.DateTime, argument.StageNum);

                ObjectMapper<REG35ServiceReference.reg35StagesValidityPeriod, REG35_Stages_Validity_Period_Response> mapper = CreateStagesValidityPeriodMapper(accessMatrix);
                REG35_Stages_Validity_Period_Response searchResults = new REG35_Stages_Validity_Period_Response();
                mapper.Map(serviceResult, searchResults);
                return
                 SigningUtils.CreateAndSign(
                     argument,
                     searchResults,
                     accessMatrix,
                     aditionalParameters
                 );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static ObjectMapper<REG35ServiceReference.reg35StagesValidityPeriod, REG35_Stages_Validity_Period_Response> CreateStagesValidityPeriodMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<REG35ServiceReference.reg35StagesValidityPeriod, REG35_Stages_Validity_Period_Response> mapper = new ObjectMapper<REG35ServiceReference.reg35StagesValidityPeriod, REG35_Stages_Validity_Period_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
            mapper.AddFunctionMap<REG35ServiceReference.AuthorizationValidityPeriod, AuthorizationType>((o) => o.Authorization.AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));


            //DateFrom и DateTo са закоментирани, защото има проблем с тяхното мапване и справката гърми.
            //mapper.AddPropertyMap((o) => o.Authorization.DateFrom, (c) => DateTime.ParseExact(c.Authorization.DateFrom, "yyyy,MM,dd", CultureInfo.InvariantCulture));
            //mapper.AddPropertyMap((o) => o.Authorization.DateTo, (c) => Convert.ToDateTime(c.Authorization.DateTo));
            mapper.AddFunctionMap<REG35ServiceReference.AuthorizationValidityPeriod, AuthState35>((o) => o.Authorization.State, (c) => (AuthState35)Enum.Parse(typeof(AuthState35), "Item" + c.State));


            mapper.AddCollectionMap<REG35ServiceReference.reg35StagesValidityPeriod>((o) => o.Authorization.Waste, (c) => c.Authorization.Waste);
            mapper.AddPropertyMap((o) => o.Authorization.Waste[0].WasteCode, (c) => c.Authorization.Waste[0].WasteCode);
            mapper.AddPropertyMap((o) => o.Authorization.Waste[0].WasteType, (c) => c.Authorization.Waste[0].WasteType);

            return mapper;
        }

        public CommonSignedResponse<REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request, REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response> GetREG35_Licenses_By_EIK_Waste_Code_Waste_Operation(REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                REG35ServiceReference.REG35ServiceClient serviceClient = new REG35ServiceReference.REG35ServiceClient("REG35ServiceImplPort", WebServiceUrl.Value);
                REG35ServiceReference.AuthorizationWastes[] serviceResult = serviceClient.getLicenses(argument.EIK, argument.WasteCode, argument.WasteOperation);

                ObjectMapper<REG35ServiceReference.AuthorizationWastes[], REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response> mapper = CreateLicensesMapper(accessMatrix);
                REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response searchResults = new REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response();
                mapper.Map(serviceResult, searchResults);
                return
                 SigningUtils.CreateAndSign(
                     argument,
                     searchResults,
                     accessMatrix,
                     aditionalParameters
                 );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static ObjectMapper<REG35ServiceReference.AuthorizationWastes[], REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response> CreateLicensesMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<REG35ServiceReference.AuthorizationWastes[], REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response> mapper = new ObjectMapper<REG35ServiceReference.AuthorizationWastes[], REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response>(accessMatrix);

            mapper.AddCollectionMap<REG35ServiceReference.AuthorizationWastes[]>((o) => o.Authorization, (c) => c);
            mapper.AddPropertyMap((o) => o.Authorization[0].AuthNum, (c) => c[0].AuthNum);
            mapper.AddFunctionMap<REG35ServiceReference.AuthorizationWastes, AuthorizationType>((o) => o.Authorization[0].AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));
            //mapper.AddPropertyMap((o) => o.Authorization[0].AuthType, (c) => Enum.Parse(typeof(AuthorizationType), c[0].AuthType));

            mapper.AddCollectionMap<REG35ServiceReference.AuthorizationWastes[]>((o) => o.Authorization[0].Stage, (c) => c[0].Stage);

            mapper.AddPropertyMap((o) => o.Authorization[0].Stage[0].StageAddress, (c) => c[0].Stage[0].StageAddress);
            mapper.AddPropertyMap((o) => o.Authorization[0].Stage[0].StageNum, (c) => c[0].Stage[0].StageNum);

            mapper.AddCollectionMap<REG35ServiceReference.AuthorizationWastes[]>((o) => o.Authorization[0].Stage[0].Waste, (c) => c[0].Stage[0].Waste);
            mapper.AddPropertyMap((o) => o.Authorization[0].Stage[0].Waste[0].WasteCode, (c) => c[0].Stage[0].Waste[0].WasteCode);
            mapper.AddPropertyMap((o) => o.Authorization[0].Stage[0].Waste[0].WasteType, (c) => c[0].Stage[0].Waste[0].WasteType);

            return mapper;
        }

        public CommonSignedResponse<REG35_Stages_By_Auth_Num_Request, REG35_Stages_By_Auth_Num_Response> GetREG35_Stages_By_Auth_Num(REG35_Stages_By_Auth_Num_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                REG35ServiceReference.REG35ServiceClient serviceClient = new REG35ServiceReference.REG35ServiceClient("REG35ServiceImplPort", WebServiceUrl.Value);
                REG35ServiceReference.reg35StagesByAuthNum serviceResult = serviceClient.getStagesByAuthNum(argument.AuthNum);

                ObjectMapper<REG35ServiceReference.reg35StagesByAuthNum, REG35_Stages_By_Auth_Num_Response> mapper = CreateStagesMapper(accessMatrix);
                REG35_Stages_By_Auth_Num_Response searchResults = new REG35_Stages_By_Auth_Num_Response();
                mapper.Map(serviceResult, searchResults);
                return
                 SigningUtils.CreateAndSign(
                     argument,
                     searchResults,
                     accessMatrix,
                     aditionalParameters
                 );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
        private static ObjectMapper<REG35ServiceReference.reg35StagesByAuthNum, REG35_Stages_By_Auth_Num_Response> CreateStagesMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<REG35ServiceReference.reg35StagesByAuthNum, REG35_Stages_By_Auth_Num_Response> mapper = new ObjectMapper<REG35ServiceReference.reg35StagesByAuthNum, REG35_Stages_By_Auth_Num_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);

            mapper.AddFunctionMap<REG35ServiceReference.reg35StagesByAuthNum, AuthorizationType>((o) => o.Authorization.AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.Authorization.AuthType));
            //mapper.AddPropertyMap((o) => o.Authorization.AuthType, (c) => Enum.Parse(typeof(AuthorizationType), c.Authorization.AuthType));

            mapper.AddCollectionMap<REG35ServiceReference.reg35StagesByAuthNum>((o) => o.Authorization.Stage, (c) => c.Authorization.Stage);
            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].StageAddress, (c) => c.Authorization.Stage[0].StageAddress);
            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].StageNum, (c) => c.Authorization.Stage[0].StageNum);

            mapper.AddCollectionMap<REG35ServiceReference.reg35StagesByAuthNum>((o) => o.Authorization.Stage[0].Waste, (c) => c.Authorization.Stage[0].Waste);
            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].Waste[0].WasteCode, (c) => c.Authorization.Stage[0].Waste[0].WasteCode);
            mapper.AddPropertyMap((o) => o.Authorization.Stage[0].Waste[0].WasteType, (c) => c.Authorization.Stage[0].Waste[0].WasteType);

            mapper.AddFunctionMap<REG35ServiceReference.reg35StagesByAuthNum, AuthState35>((o) => o.Authorization.State, (c) => (AuthState35)Enum.Parse(typeof(AuthState35), c.Authorization.State));
            //mapper.AddPropertyMap((o) => o.Authorization.State, (c) => Enum.Parse(typeof(AuthState35), c.Authorization.State));

            return mapper;
        }


        public CommonSignedResponse<REG35_Allowed_Waste_Codes_Request, REG35_Allowed_Waste_Codes_Response> GetREG35_Allowed_Waste_Codes(REG35_Allowed_Waste_Codes_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                REG35ServiceReference.REG35ServiceClient serviceClient = new REG35ServiceReference.REG35ServiceClient("REG35ServiceImplPort", WebServiceUrl.Value);
                REG35ServiceReference.reg35AllowedWasteCodes serviceResult = serviceClient.getAllowedWasteCode(argument.AuthNum, argument.StageNum);

                ObjectMapper<REG35ServiceReference.reg35AllowedWasteCodes, REG35_Allowed_Waste_Codes_Response> mapper = CreateAllowedWasteCodesMapper(accessMatrix);
                REG35_Allowed_Waste_Codes_Response searchResults = new REG35_Allowed_Waste_Codes_Response();
                mapper.Map(serviceResult, searchResults);
                return
                 SigningUtils.CreateAndSign(
                     argument,
                     searchResults,
                     accessMatrix,
                     aditionalParameters
                 );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static ObjectMapper<REG35ServiceReference.reg35AllowedWasteCodes, REG35_Allowed_Waste_Codes_Response> CreateAllowedWasteCodesMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<REG35ServiceReference.reg35AllowedWasteCodes, REG35_Allowed_Waste_Codes_Response> mapper = new ObjectMapper<REG35ServiceReference.reg35AllowedWasteCodes, REG35_Allowed_Waste_Codes_Response>(accessMatrix);


            // mapper.AddCollectionMap<REG35ServiceReference.StageWastes>((o) => o.Stages.Stage, (c) => c.Stage);
            // mapper.AddConstantMap((o) => o.Stages, new REG35_Allowed_Waste_Codes_ResponseStages());
            mapper.AddObjectMap((o) => o.Stage, (c) => c.Stage);
            mapper.AddPropertyMap((o) => o.Stage.StageAddress, (c) => c.Stage.StageAddress);
            mapper.AddFunctionMap<REG35ServiceReference.StageWastes, AuthState35>((o) => o.Stage.State, (c) => (AuthState35)Enum.Parse(typeof(AuthState35), "Item" + c.State));
            mapper.AddFunctionMap<REG35ServiceReference.reg35AllowedWasteCodes, List<string>>((o) => o.Stage.WasteCode, (c) => c.Stage.WasteCode == null ? null : c.Stage.WasteCode.ToList());

            //mapper.AddCollectionMap<REG35ServiceReference.reg35AllowedWasteCodes>((o) => o.Stages.Stage[0].WasteCodes.WasteCode, (c) => c.Stage.WasteCode);
            //mapper.AddPropertyMap((o) => o.Stages.Stage[0].WasteCodes.WasteCode[0], (c) => c.Stage.WasteCode[0]);

            return mapper;
        }
    }
}
