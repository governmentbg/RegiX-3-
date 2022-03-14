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

namespace TechnoLogica.RegiX.IaosMROOilAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaosMROOilAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaosMROOilAdapter), typeof(IAdapterService))]
    public class IaosMROOilAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosMROOilAdapter, IAdapterService
    {
        // [Export(typeof(ParameterInfo))]
        // [ExportFullName(typeof(IaosMROOilAdapter), typeof(ParameterInfo))]
        //public static ParameterInfo<string> ServiceUrl =
        //   new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-oil")
        //   {
        //       Key = "ServiceUrl",
        //       Description = "IaosMROOil Web Service Url",
        //       OwnerAssembly = typeof(IaosMROOilAdapter).Assembly
        //   };



        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaosMROOilAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
               new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-oil")
               {
                   Key = Constants.WebServiceUrlParameterKeyName,
                   Description = "Connection String for SOAP Web Service",
                   OwnerAssembly = typeof(IaosMROOilAdapter).Assembly
               };

        public CommonSignedResponse<MRO_OIL_Validity_Check_Request, MRO_OIL_Validity_Check_Response> GetMRO_OIL_Validity_Check(MRO_OIL_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROOilServiceReference.MROOilServiceClient serviceClient = new MROOilServiceReference.MROOilServiceClient("MROOilServiceImplPort", WebServiceUrl.Value);
                MROOilServiceReference.AuthorizationValidityCheck serviceResult = serviceClient.getValidityCheck(argument.EIK).Authorization;

                ObjectMapper<MROOilServiceReference.AuthorizationValidityCheck, MRO_OIL_Validity_Check_Response> mapper = CreateValidityCheckMapper(accessMatrix);
                MRO_OIL_Validity_Check_Response searchResults = new MRO_OIL_Validity_Check_Response();
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
        private static ObjectMapper<MROOilServiceReference.AuthorizationValidityCheck, MRO_OIL_Validity_Check_Response> CreateValidityCheckMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROOilServiceReference.AuthorizationValidityCheck, MRO_OIL_Validity_Check_Response> mapper = new ObjectMapper<MROOilServiceReference.AuthorizationValidityCheck, MRO_OIL_Validity_Check_Response>(accessMatrix);

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

        public CommonSignedResponse<MRO_OIL_Execution_Type_Request, MRO_OIL_Execution_Type_Response> GetMRO_OIL_Execution_Type(MRO_OIL_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROOilServiceReference.MROOilServiceClient serviceClient = new MROOilServiceReference.MROOilServiceClient("MROOilServiceImplPort", WebServiceUrl.Value);
                MROOilServiceReference.AuthorizationExecutionType serviceResult = serviceClient.getExecutionType(argument.EIK).Authorization;

                ObjectMapper<MROOilServiceReference.AuthorizationExecutionType, MRO_OIL_Execution_Type_Response> mapper = CreateExecutionTypeMapper(accessMatrix);
                MRO_OIL_Execution_Type_Response searchResults = new MRO_OIL_Execution_Type_Response();
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

        private static ObjectMapper<MROOilServiceReference.AuthorizationExecutionType, MRO_OIL_Execution_Type_Response> CreateExecutionTypeMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROOilServiceReference.AuthorizationExecutionType, MRO_OIL_Execution_Type_Response> mapper = new ObjectMapper<MROOilServiceReference.AuthorizationExecutionType, MRO_OIL_Execution_Type_Response>(accessMatrix);

            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            mapper.AddFunctionMap<MROOilServiceReference.AuthorizationExecutionType, Fulfilment>((o) => o.Authorization.MroFulfillment, (c) => (Fulfilment)Enum.Parse(typeof(Fulfilment), "Item" + c.MroFulfillment));
            mapper.AddPropertyMap((o) => o.Authorization.RecOrgNum, (c) => c.RecOrgNum);
            mapper.AddPropertyMap((o) => o.Authorization.UonName, (c) => c.UonName);

            return mapper;
        }

        public CommonSignedResponse<MRO_OIL_Trade_Marks_Request, MRO_OIL_Trade_Marks_Response> GetMRO_OIL_Trade_Marks(MRO_OIL_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROOilServiceReference.MROOilServiceClient serviceClient = new MROOilServiceReference.MROOilServiceClient("MROOilServiceImplPort", WebServiceUrl.Value);
                MROOilServiceReference.AuthorizationTradeMarks serviceResult = serviceClient.getTradeMarks(argument.AuthNum).Authorization;

                ObjectMapper<MROOilServiceReference.AuthorizationTradeMarks, MRO_OIL_Trade_Marks_Response> mapper = CreateTradeMarksMapper(accessMatrix);
                MRO_OIL_Trade_Marks_Response searchResults = new MRO_OIL_Trade_Marks_Response();
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

        private static ObjectMapper<MROOilServiceReference.AuthorizationTradeMarks, MRO_OIL_Trade_Marks_Response> CreateTradeMarksMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROOilServiceReference.AuthorizationTradeMarks, MRO_OIL_Trade_Marks_Response> mapper = new ObjectMapper<MROOilServiceReference.AuthorizationTradeMarks, MRO_OIL_Trade_Marks_Response>(accessMatrix);

            mapper.AddPropertyMap((o) => o.Authorization.EIK, (c) => c.EIK);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            //mapper.AddConstantMap((o) => o.Authorization.TradeMarks, new AuthorizationTradeMarksTradeMarks());
            mapper.AddFunctionMap<MROOilServiceReference.AuthorizationTradeMarks, List<string>>((o) => o.Authorization.TradeMarks.TradeMark, (c) => c.TradeMark == null ? null : c.TradeMark.ToList());
            //mapper.AddCollectionMap<MROOilServiceReference.AuthorizationTradeMarks>((o) => o.Authorization.TradeMarks.TradeMark, c => c.TradeMark);
            //mapper.AddPropertyMap((o) => o.Authorization.TradeMarks.TradeMark[0], (c) => c.TradeMark[0]);
            return mapper;
        }


        public CommonSignedResponse<MRO_OIL_Validity_Check_Request, MRO_OIL_Validity_Check_Response> GetMRO_OIL_Validity_Check(MRO_OIL_Validity_Check_Request argument, AccessMatrix accessMatrix)
        {
            throw new NotImplementedException();
        }

        public CommonSignedResponse<MRO_OIL_Execution_Type_Request, MRO_OIL_Execution_Type_Response> GetMRO_OIL_Execution_Type(MRO_OIL_Execution_Type_Request argument, AccessMatrix accessMatrix)
        {
            throw new NotImplementedException();
        }

        public CommonSignedResponse<MRO_OIL_Trade_Marks_Request, MRO_OIL_Trade_Marks_Response> GetMRO_OIL_Trade_Marks(MRO_OIL_Trade_Marks_Request argument, AccessMatrix accessMatrix)
        {
            throw new NotImplementedException();
        }
    }
}
