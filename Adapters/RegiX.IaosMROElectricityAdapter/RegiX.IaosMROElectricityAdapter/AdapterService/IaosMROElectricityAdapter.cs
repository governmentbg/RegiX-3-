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

namespace TechnoLogica.RegiX.IaosMROElectricityAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaosMROElectricityAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaosMROElectricityAdapter), typeof(IAdapterService))]
    public class IaosMROElectricityAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosMROElectricityAdapter, IAdapterService
    {
        //[Export(typeof(ParameterInfo))]
        //public static ParameterInfo<string> ServiceUrl =
        //    new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-eeo")
        //    {
        //        Key = "ServiceUrl",
        //        Description = "IaosMROElectricity Web Service Url",
        //        OwnerAssembly = typeof(IaosMROElectricityAdapter).Assembly
        //    };
        //public IaosMROElectricityAdapter()
        //{
        //    WebServiceUrl =
        //        new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-eeo")
        //        {
        //            Key = "ServiceUrl",
        //            Description = "IaosMROElectricity Web Service Url",
        //            OwnerAssembly = typeof(IaosMROElectricityAdapter).Assembly
        //        };
        //}
        //public override ConnectionStatusInfo CheckRegisterConnection()
        //{
        //    return new ConnectionStatusInfo()
        //    {
        //        Description = "Connection is OK!",
        //        status = ConnectionStatus.OK
        //    };
        //}

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaosMROElectricityAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-eeo")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Connection String for SOAP Web Service",
               OwnerAssembly = typeof(IaosMROElectricityAdapter).Assembly
           };

        public CommonSignedResponse<MRO_EEO_Validity_Check_Request, MRO_EEO_Validity_Check_Response> GetMRO_EEO_Validity_Check(MRO_EEO_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROElectricityServiceReference.MROEEOServiceClient serviceClient = new MROElectricityServiceReference.MROEEOServiceClient("MROEEOServiceImplPort", WebServiceUrl.Value);
                MROElectricityServiceReference.AuthorizationValidityCheck serviceResult = serviceClient.getValidityCheck(argument.EIK).Authorization;

                ObjectMapper<MROElectricityServiceReference.AuthorizationValidityCheck, MRO_EEO_Validity_Check_Response> mapper = CreateValidityCheckMapper(accessMatrix);
                MRO_EEO_Validity_Check_Response searchResults = new MRO_EEO_Validity_Check_Response();
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

        private static ObjectMapper<MROElectricityServiceReference.AuthorizationValidityCheck, MRO_EEO_Validity_Check_Response> CreateValidityCheckMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROElectricityServiceReference.AuthorizationValidityCheck, MRO_EEO_Validity_Check_Response> mapper = new ObjectMapper<MROElectricityServiceReference.AuthorizationValidityCheck, MRO_EEO_Validity_Check_Response>(accessMatrix);

            mapper.AddPropertyMap((o) => o.Authorization.Address, (c) => c.Address);
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            mapper.AddPropertyMap((o) => o.Authorization.DistName, (c) => c.DistName);
            mapper.AddPropertyMap((o) => o.Authorization.FirstName, (c) => c.FirstName);
            mapper.AddPropertyMap((o) => o.Authorization.LastName, (c) => c.LastName);
            mapper.AddPropertyMap((o) => o.Authorization.MidName, (c) => c.MidName);
            mapper.AddPropertyMap((o) => o.Authorization.PopName, (c) => c.PopName);
            //todo: try parse enum
            //mapper.AddObjectMap((o) => o.Authorization.State, (c) => c.State);
            mapper.AddFunctionMap<MROElectricityServiceReference.AuthorizationValidityCheck, AuthState>((o) => o.Authorization.State, (c) => (AuthState)Enum.Parse(typeof(AuthState), "Item" + c.State));
            //mapper.AddPropertyMap((o) => o.Authorization.State, (c) => (AuthState)Enum.Parse(typeof(AuthState), "Item" +  c.State));
            mapper.AddPropertyMap((o) => o.Authorization.TerName, (c) => c.TerName);

            return mapper;
        }

        public CommonSignedResponse<MRO_EEO_Equipment_Category_Request, MRO_EEO_Equipment_Category_Response> GetMRO_EEO_Equipment_Category(MRO_EEO_Equipment_Category_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROElectricityServiceReference.MROEEOServiceClient serviceClient = new MROElectricityServiceReference.MROEEOServiceClient("MROEEOServiceImplPort", WebServiceUrl.Value);
                MROElectricityServiceReference.Authorization serviceResult = serviceClient.getEquipmentCategory(argument.EIK).Authorization;

                ObjectMapper<MROElectricityServiceReference.Authorization, MRO_EEO_Equipment_Category_Response> mapper = CreateEquipmentCategoryMapper(accessMatrix);
                MRO_EEO_Equipment_Category_Response searchResults = new MRO_EEO_Equipment_Category_Response();
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

        private static ObjectMapper<MROElectricityServiceReference.Authorization, MRO_EEO_Equipment_Category_Response> CreateEquipmentCategoryMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROElectricityServiceReference.Authorization, MRO_EEO_Equipment_Category_Response> mapper = new ObjectMapper<MROElectricityServiceReference.Authorization, MRO_EEO_Equipment_Category_Response>(accessMatrix);

            //TODO:
            //mapper.AddCollectionMap<MROElectricityServiceReference.Authorization>((o) => o.Authorization.EEOCategories.EEOCategory, (c) => c.EEOCategory);
            //mapper.AddObjectMap((o) => o.Authorization.EEOCategories.EEOCategory, (c) => c.EEOCategory);
            //mapper.AddPropertyMap((o) => o.Authorization.EEOCategories.EEOCategory[0], (c) => Enum.Parse(typeof(List<string>), c.EEOCategory[0]));
            mapper.AddFunctionMap<MROElectricityServiceReference.Authorization, List<string>>((o) => o.Authorization.EEOCategories.EEOCategory, (c) => c.EEOCategory == null ? null : c.EEOCategory.ToList());
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);

            return mapper;
        }
        public CommonSignedResponse<MRO_EEO_Execution_Type_Request, MRO_EEO_Execution_Type_Response> GetMRO_EEO_Execution_Type(MRO_EEO_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROElectricityServiceReference.MROEEOServiceClient serviceClient = new MROElectricityServiceReference.MROEEOServiceClient("MROEEOServiceImplPort", WebServiceUrl.Value);
                MROElectricityServiceReference.AuthorizationExecutionType serviceResult = serviceClient.getExecutionType(argument.EIK).Authorization;

                ObjectMapper<MROElectricityServiceReference.AuthorizationExecutionType, MRO_EEO_Execution_Type_Response> mapper = CreateExecutionTypeMapper(accessMatrix);
                MRO_EEO_Execution_Type_Response searchResults = new MRO_EEO_Execution_Type_Response();
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

        private static ObjectMapper<MROElectricityServiceReference.AuthorizationExecutionType, MRO_EEO_Execution_Type_Response> CreateExecutionTypeMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROElectricityServiceReference.AuthorizationExecutionType, MRO_EEO_Execution_Type_Response> mapper = new ObjectMapper<MROElectricityServiceReference.AuthorizationExecutionType, MRO_EEO_Execution_Type_Response>(accessMatrix);

            //TODO: try parse enum
            mapper.AddFunctionMap<MROElectricityServiceReference.AuthorizationExecutionType, Fulfilment>((o) => o.Authorization.MroFulfillment, (c) => (Fulfilment)Enum.Parse(typeof(Fulfilment), "Item" + c.MroFulfillment));
            mapper.AddPropertyMap((o) => o.Authorization.RecOrgNum, (c) => c.RecOrgNum);
            mapper.AddPropertyMap((o) => o.Authorization.UonName, (c) => c.UonName);
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);

            return mapper;
        }

        public CommonSignedResponse<MRO_EEO_Trade_Marks_Request, MRO_EEO_Trade_Marks_Response> GetMRO_EEO_Trade_Marks(MRO_EEO_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROElectricityServiceReference.MROEEOServiceClient serviceClient = new MROElectricityServiceReference.MROEEOServiceClient("MROEEOServiceImplPort", WebServiceUrl.Value);
                MROElectricityServiceReference.AuthorizationTradeMarks serviceResult = serviceClient.getTradeMarks(argument.AuthNum).Authorization;

                ObjectMapper<MROElectricityServiceReference.AuthorizationTradeMarks, MRO_EEO_Trade_Marks_Response> mapper = CreateTradeMarksMapper(accessMatrix);
                MRO_EEO_Trade_Marks_Response searchResults = new MRO_EEO_Trade_Marks_Response();
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

        private static ObjectMapper<MROElectricityServiceReference.AuthorizationTradeMarks, MRO_EEO_Trade_Marks_Response> CreateTradeMarksMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROElectricityServiceReference.AuthorizationTradeMarks, MRO_EEO_Trade_Marks_Response> mapper = new ObjectMapper<MROElectricityServiceReference.AuthorizationTradeMarks, MRO_EEO_Trade_Marks_Response>(accessMatrix);

            mapper.AddObjectMap((o) => o.Authorization, (c) => c);
            mapper.AddPropertyMap((o) => o.Authorization.EIK, (c) => c.EIK);
            mapper.AddFunctionMap<MROElectricityServiceReference.AuthorizationTradeMarks, List<string>>((o) => o.Authorization.TradeMarks.TradeMark, (c) => c.TradeMark == null ? null : c.TradeMark.ToList());
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);

            return mapper;
        }

    }
}
