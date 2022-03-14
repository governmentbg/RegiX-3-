using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosMROTyresAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaosMROTyresAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaosMROTyresAdapter), typeof(IAdapterService))]
    public class IaosMROTyresAdapter : WebServiceAdapterService.WebServiceBaseAdapterService, IIaosMROTyresAdapter, IAdapterService
    {
        //[Export(typeof(ParameterInfo))]
        //public static ParameterInfo<string> ServiceUrl =
        //   new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-tyres")
        //   {
        //       Key = "ServiceUrl",
        //       Description = "IaosMROTyres Web Service Url",
        //       OwnerAssembly = typeof(IaosMROTyresAdapter).Assembly
        //   };
        //public IaosMROTyresAdapter()
        //{
        //    WebServiceUrl =
        //         new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-tyres")
        //         {
        //             Key = "ServiceUrl",
        //             Description = "IaosMROTyres Web Service Url",
        //             OwnerAssembly = typeof(IaosMROTyresAdapter).Assembly
        //         };
        //}

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaosMROTyresAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-tyres")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Connection String for SOAP Web Service",
               OwnerAssembly = typeof(IaosMROTyresAdapter).Assembly
           };

        public CommonSignedResponse<MRO_TYRES_Validity_Check_Request, MRO_TYRES_Validity_Check_Response> GetMRO_TYRES_Validity_Check(MRO_TYRES_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROTyresServiceReference.MROTyresServiceClient serviceClient = new MROTyresServiceReference.MROTyresServiceClient("MROTyresServiceImplPort", WebServiceUrl.Value);
                MROTyresServiceReference.AuthorizationValidityCheck serviceResult = serviceClient.getValidityCheck(argument.EIK).Authorization;

                ObjectMapper<MROTyresServiceReference.AuthorizationValidityCheck, MRO_TYRES_Validity_Check_Response> mapper = CreateValidityCheckMapper(accessMatrix);
                MRO_TYRES_Validity_Check_Response searchResults = new MRO_TYRES_Validity_Check_Response();
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

        private static ObjectMapper<MROTyresServiceReference.AuthorizationValidityCheck, MRO_TYRES_Validity_Check_Response> CreateValidityCheckMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROTyresServiceReference.AuthorizationValidityCheck, MRO_TYRES_Validity_Check_Response> mapper = new ObjectMapper<MROTyresServiceReference.AuthorizationValidityCheck, MRO_TYRES_Validity_Check_Response>(accessMatrix);

            mapper.AddPropertyMap((o) => o.Authorization.Address, (c) => c.Address);
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            mapper.AddPropertyMap((o) => o.Authorization.DistName, (c) => c.DistName);
            mapper.AddPropertyMap((o) => o.Authorization.FirstName, (c) => c.FirstName);
            mapper.AddPropertyMap((o) => o.Authorization.LastName, (c) => c.LastName);
            mapper.AddPropertyMap((o) => o.Authorization.MidName, (c) => c.MidName);
            mapper.AddPropertyMap((o) => o.Authorization.PopName, (c) => c.PopName);
            mapper.AddPropertyMap((o) => o.Authorization.TerName, (c) => c.TerName);

            return mapper;
        }

        public CommonSignedResponse<MRO_TYRES_Execution_Type_Request, MRO_TYRES_Execution_Type_Response> GetMRO_TYRES_Execution_Type(MRO_TYRES_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROTyresServiceReference.MROTyresServiceClient serviceClient = new MROTyresServiceReference.MROTyresServiceClient("MROTyresServiceImplPort", WebServiceUrl.Value);
                MROTyresServiceReference.AuthorizationExecutionType serviceResult = serviceClient.getExecutionType(argument.EIK).Authorization;

                ObjectMapper<MROTyresServiceReference.AuthorizationExecutionType, MRO_TYRES_Execution_Type_Response> mapper = CreateExecutionTypeMapper(accessMatrix);
                MRO_TYRES_Execution_Type_Response searchResults = new MRO_TYRES_Execution_Type_Response();
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

        private static ObjectMapper<MROTyresServiceReference.AuthorizationExecutionType, MRO_TYRES_Execution_Type_Response> CreateExecutionTypeMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROTyresServiceReference.AuthorizationExecutionType, MRO_TYRES_Execution_Type_Response> mapper = new ObjectMapper<MROTyresServiceReference.AuthorizationExecutionType, MRO_TYRES_Execution_Type_Response>(accessMatrix);

            mapper.AddFunctionMap<MROTyresServiceReference.AuthorizationExecutionType, Fulfilment>((o) => o.Authorization.MroFulfillment, (c) => (Fulfilment)Enum.Parse(typeof(Fulfilment), "Item" + c.MroFulfillment));
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            mapper.AddPropertyMap((o) => o.Authorization.RecOrgNum, (c) => c.RecOrgNum);
            mapper.AddPropertyMap((o) => o.Authorization.UonName, (c) => c.UonName);

            return mapper;
        }

        public CommonSignedResponse<MRO_TYRES_Trade_Marks_Request, MRO_TYRES_Trade_Marks_Response> GetMRO_TYRES_Trade_Marks(MRO_TYRES_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROTyresServiceReference.MROTyresServiceClient serviceClient = new MROTyresServiceReference.MROTyresServiceClient("MROTyresServiceImplPort", WebServiceUrl.Value);
                MROTyresServiceReference.AuthorizationTradeMarks serviceResult = serviceClient.getTradeMarks(argument.AuthNum).Authorization;

                ObjectMapper<MROTyresServiceReference.AuthorizationTradeMarks, MRO_TYRES_Trade_Marks_Response> mapper = CreateTradeMarksMapper(accessMatrix);
                MRO_TYRES_Trade_Marks_Response searchResults = new MRO_TYRES_Trade_Marks_Response();
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

        private static ObjectMapper<MROTyresServiceReference.AuthorizationTradeMarks, MRO_TYRES_Trade_Marks_Response> CreateTradeMarksMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROTyresServiceReference.AuthorizationTradeMarks, MRO_TYRES_Trade_Marks_Response> mapper = new ObjectMapper<MROTyresServiceReference.AuthorizationTradeMarks, MRO_TYRES_Trade_Marks_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c);
            mapper.AddPropertyMap((o) => o.Authorization.EIK, (c) => c.EIK);

            mapper.AddFunctionMap<MROTyresServiceReference.AuthorizationTradeMarks, List<string>>((o) => o.Authorization.TradeMarks.TradeMark, (c) => c.TradeMark == null ? null : c.TradeMark.ToList());

            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);

            return mapper;
        }


    }
}
