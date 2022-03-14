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
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaosTraderBrokerAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaosTraderBrokerAdapter), typeof(IAdapterService))]
    public class IaosTraderBrokerAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosTraderBrokerAdapter, IAdapterService
    {
        //public IaosTraderBrokerAdapter()
        //{
        //    WebServiceUrl =
        //       new ParameterInfo<string>("https://source.gravis.bg/egov/services/trader-broker")
        //       {
        //           Key = "ServiceUrl",
        //           Description = "IaosTraderBroker Web Service Url",
        //           OwnerAssembly = typeof(IaosTraderBrokerAdapter).Assembly
        //       };
        //}

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaosTraderBrokerAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           new ParameterInfo<string>("https://source.gravis.bg/egov/services/trader-broker")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Connection String for SOAP Web Service",
               OwnerAssembly = typeof(IaosTraderBrokerAdapter).Assembly
           };

        public CommonSignedResponse<TRADER_BROKER_Validity_Check_Request, TRADER_BROKER_Validity_Check_Response> GetTRADER_BROKER_Validity_Check(TRADER_BROKER_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                TraderBrokerServiceReference.TraderBrokerServiceClient serviceClient = new TraderBrokerServiceReference.TraderBrokerServiceClient("TraderBrokerServiceImplPort", WebServiceUrl.Value);
                TraderBrokerServiceReference.tbValidityCheck serviceResult = serviceClient.getValidityCheck(argument.EIK);

                ObjectMapper<TraderBrokerServiceReference.tbValidityCheck, TRADER_BROKER_Validity_Check_Response> mapper = CreateValidityCheckMapper(accessMatrix);
                TRADER_BROKER_Validity_Check_Response searchResults = new TRADER_BROKER_Validity_Check_Response();
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

        private static ObjectMapper<TraderBrokerServiceReference.tbValidityCheck, TRADER_BROKER_Validity_Check_Response> CreateValidityCheckMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<TraderBrokerServiceReference.tbValidityCheck, TRADER_BROKER_Validity_Check_Response> mapper = new ObjectMapper<TraderBrokerServiceReference.tbValidityCheck, TRADER_BROKER_Validity_Check_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
            mapper.AddPropertyMap((o) => o.Authorization.AuthType, (c) => Enum.Parse(typeof(AuthorizationType), c.Authorization.AuthType));
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.Authorization.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
            mapper.AddPropertyMap((o) => o.Authorization.DistName, (c) => c.Authorization.DistName);
            mapper.AddPropertyMap((o) => o.Authorization.FirstName, (c) => c.Authorization.FirstName);
            mapper.AddPropertyMap((o) => o.Authorization.LastName, (c) => c.Authorization.LastName);
            mapper.AddPropertyMap((o) => o.Authorization.MidName, (c) => c.Authorization.MidName);
            mapper.AddPropertyMap((o) => o.Authorization.PopName, (c) => c.Authorization.PopName);
            mapper.AddFunctionMap<TraderBrokerServiceReference.AuthorizationValidityCheck, AuthState>((o) => o.Authorization.State, (c) => (AuthState)Enum.Parse(typeof(AuthState), "Item" + c.State));
            // mapper.AddPropertyMap((o) => o.Authorization.State, (c) => Enum.Parse(typeof(AuthState), c.Authorization.State));
            mapper.AddPropertyMap((o) => o.Authorization.TerName, (c) => c.Authorization.TerName);

            return mapper;
        }

        public CommonSignedResponse<TRADER_BROKER_Waste_Codes_By_EIK_Request, TRADER_BROKER_Waste_Codes_By_EIK_Response> GetTRADER_BROKER_Waste_Codes_By_EIK(TRADER_BROKER_Waste_Codes_By_EIK_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                TraderBrokerServiceReference.TraderBrokerServiceClient serviceClient = new TraderBrokerServiceReference.TraderBrokerServiceClient("TraderBrokerServiceImplPort", WebServiceUrl.Value);
                TraderBrokerServiceReference.tbWasteCodesByEIK serviceResult = serviceClient.getWasteCodesByEIK(argument.EIK);

                ObjectMapper<TraderBrokerServiceReference.tbWasteCodesByEIK, TRADER_BROKER_Waste_Codes_By_EIK_Response> mapper = CreateWasteCodesMapper(accessMatrix);
                TRADER_BROKER_Waste_Codes_By_EIK_Response searchResults = new TRADER_BROKER_Waste_Codes_By_EIK_Response();
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


        private static ObjectMapper<TraderBrokerServiceReference.tbWasteCodesByEIK, TRADER_BROKER_Waste_Codes_By_EIK_Response> CreateWasteCodesMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<TraderBrokerServiceReference.tbWasteCodesByEIK, TRADER_BROKER_Waste_Codes_By_EIK_Response> mapper = new ObjectMapper<TraderBrokerServiceReference.tbWasteCodesByEIK, TRADER_BROKER_Waste_Codes_By_EIK_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
            mapper.AddFunctionMap<TraderBrokerServiceReference.AuthorizationWasteCodes, AuthorizationType>((o) => o.Authorization.AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));

            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.Authorization.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
            mapper.AddFunctionMap<TraderBrokerServiceReference.AuthorizationWasteCodes, AuthState>((o) => o.Authorization.State, (c) => (AuthState)Enum.Parse(typeof(AuthState), "Item" + c.State));
            mapper.AddFunctionMap<TraderBrokerServiceReference.tbWasteCodesByEIK, List<string>>((o) => o.Authorization.WasteCodes.WasteCode, (c) => c.Authorization.WasteCode.ToList());

            return mapper;
        }

        public CommonSignedResponse<TRADER_BROKER_Waste_Codes_By_EIK_RequestV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2> GetTRADER_BROKER_Waste_Codes_By_EIKV2(TRADER_BROKER_Waste_Codes_By_EIK_RequestV2 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {

                TraderBrokerServiceReferenceV2.TraderBrokerServiceClient serviceClient = new TraderBrokerServiceReferenceV2.TraderBrokerServiceClient(TraderBrokerServiceReferenceV2.TraderBrokerServiceClient.EndpointConfiguration.TraderBrokerServiceImplPort, WebServiceUrl.Value);
                Task<TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Response> serviceResult = serviceClient.getWasteCodesByEIKV2Async(argument.EIK);
                Task.WaitAll();
                ObjectMapper<TraderBrokerServiceReferenceV2.tbWasteCodesByEIKV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2> mapper = CreateWasteCodesMapperV2(accessMatrix);
                TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2 searchResults = new TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2();

                //// TEST
                //string[] wasteCodes = { "code1", "code2" };
                //TraderBrokerServiceReferenceV2.WasteCodesOperations[] operationCodes = 
                //{
                //    new TraderBrokerServiceReferenceV2.WasteCodesOperations()
                //    {
                //        WasteOperation = "Operation",
                //        WasteOperationsCode = new TraderBrokerServiceReferenceV2.WasteCodesType()
                //        {
                //            WasteCode = wasteCodes
                //        }
                //    }
                //};
                //TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Response testResponse = new TraderBrokerServiceReferenceV2.getWasteCodesByEIKV2Response()
                //{
                //    TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2 = new TraderBrokerServiceReferenceV2.tbWasteCodesByEIKV2()
                //    {
                //        Authorization = new TraderBrokerServiceReferenceV2.AuthorizationWasteCodesV2()
                //        {
                //            AuthNum = "124fg5",
                //            AuthType = "TB",
                //            CompanyName = "MiroLogica",
                //            State = "02",
                //            WasteOperationsCodes = operationCodes
                //        }
                //    }
                //};
                // END
                mapper.Map(serviceResult.Result.TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2, searchResults);
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


        private static ObjectMapper<TraderBrokerServiceReferenceV2.tbWasteCodesByEIKV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2> CreateWasteCodesMapperV2(AccessMatrix accessMatrix)
        {
            ObjectMapper<TraderBrokerServiceReferenceV2.tbWasteCodesByEIKV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2> mapper = new ObjectMapper<TraderBrokerServiceReferenceV2.tbWasteCodesByEIKV2, TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
            mapper.AddFunctionMap<TraderBrokerServiceReferenceV2.AuthorizationWasteCodesV2, AuthorizationType>((o) => o.Authorization.AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));

            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.Authorization.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
            mapper.AddFunctionMap<TraderBrokerServiceReferenceV2.AuthorizationWasteCodesV2, AuthState>((o) => o.Authorization.State, (c) => (AuthState)Enum.Parse(typeof(AuthState), "Item" + c.State));

            mapper.AddObjectMap((o) => o.Authorization.WasteOperationCodes, (c) => c.Authorization.WasteOperationsCodes);

            mapper.AddCollectionMap<TraderBrokerServiceReferenceV2.WasteCodesOperations[]>((o) => o.Authorization.WasteOperationCodes.WasteOperationCode, c => c);
            mapper.AddPropertyMap((o) => o.Authorization.WasteOperationCodes.WasteOperationCode[0].WasteOperation, (c) => c.Authorization.WasteOperationsCodes[0].WasteOperation);

            mapper.AddObjectMap((o) => o.Authorization.WasteOperationCodes.WasteOperationCode[0].WasteOperationsCode, (c) => c.Authorization.WasteOperationsCodes[0].WasteOperationsCode);
            mapper.AddFunctionMap<TraderBrokerServiceReferenceV2.WasteCodesType, List<string>>((o) => o.Authorization.WasteOperationCodes.WasteOperationCode[0].WasteOperationsCode.WasteCode, d => (d.WasteCode != null ? d.WasteCode.ToList<string>() : new List<string>()));
            return mapper;
        }


    }
}
