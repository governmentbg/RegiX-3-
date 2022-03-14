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

//namespace TechnoLogica.RegiX.IaosMROBatteriesAdapter.AdapterService
//{
//    public class IaosMROBatteriesAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosMROBatteriesAdapter, IAdapterService
//    {

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(IaosMROBatteriesAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//            new ParameterInfo<string>("https://source.gravis.bg:443/egov/services/mro-ba")
//            {
//                Key = Constants.WebServiceUrlParameterKeyName,
//                Description = "Connection String for SOAP Web Service",
//                OwnerAssembly = typeof(IaosMROBatteriesAdapter).Assembly
//            };

//        //public IaosMROBatteriesAdapter()
//        //{
//        //    WebServiceUrl =
//        //        new ParameterInfo<string>("https://source.gravis.bg:443/egov/services/mro-ba")
//        //        {
//        //            Key = "ServiceUrl",
//        //            Description = "IaosMROBatteries Web Service Url",
//        //            OwnerAssembly = typeof(IaosMROBatteriesAdapter).Assembly
//        //        };
//        //}

//        //public override ConnectionStatusInfo CheckRegisterConnection()
//        //{
//        //    return new ConnectionStatusInfo()
//        //    {
//        //        Description = "Connection is OK!",
//        //        status = ConnectionStatus.OK
//        //    };
//        //}

//        public CommonSignedResponse<MRO_BA_Validity_Check_Request, MRO_BA_Validity_Check_Response> GetMRO_BA_Validity_Check(MRO_BA_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {

//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MROBatteriesServiceReference.MROBAServiceClient serviceClient = new MROBatteriesServiceReference.MROBAServiceClient("MROBAServiceImplPort");
//                MROBatteriesServiceReference.getValidityCheckRequest req = new MROBatteriesServiceReference.getValidityCheckRequest(argument.EIK);
//                MROBatteriesServiceReference.mrobaValidityCheck serviceResult = serviceClient.getValidityCheck(req).MRO_BA_Validity_Check_Response;

//                ObjectMapper<MROBatteriesServiceReference.mrobaValidityCheck, MRO_BA_Validity_Check_Response> mapper = CreateValidityCheckMapper(accessMatrix);
//                MRO_BA_Validity_Check_Response searchResults = new MRO_BA_Validity_Check_Response();
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
//        private static ObjectMapper<MROBatteriesServiceReference.mrobaValidityCheck, MRO_BA_Validity_Check_Response> CreateValidityCheckMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MROBatteriesServiceReference.mrobaValidityCheck, MRO_BA_Validity_Check_Response> mapper = new ObjectMapper<MROBatteriesServiceReference.mrobaValidityCheck, MRO_BA_Validity_Check_Response>(accessMatrix);
//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddPropertyMap((o) => o.Authorization.Address, (c) => c.Authorization.Address);
//            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.Authorization.AuthNum);
//            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
//            mapper.AddPropertyMap((o) => o.Authorization.DistName, (c) => c.Authorization.DistName);
//            mapper.AddPropertyMap((o) => o.Authorization.FirstName, (c) => c.Authorization.FirstName);
//            mapper.AddPropertyMap((o) => o.Authorization.LastName, (c) => c.Authorization.LastName);
//            mapper.AddPropertyMap((o) => o.Authorization.MidName, (c) => c.Authorization.MidName);
//            mapper.AddPropertyMap((o) => o.Authorization.PopName, (c) => c.Authorization.PopName);
//            //todo: try parse enum
//            mapper.AddFunctionMap<MROBatteriesServiceReference.AuthorizationValidityCheck, AuthState>((o) => o.Authorization.State, (c) => (AuthState)Enum.Parse(typeof(AuthState), "Item" + c.State));
//            //mapper.AddPropertyMap((o) => o.Authorization.State, (c) => Enum.Parse(typeof(AuthState), c.MRO_BA_Validity_Check_Response.Authorization.State));
//            mapper.AddPropertyMap((o) => o.Authorization.TerName, (c) => c.Authorization.TerName);

//            return mapper;
//        }
//        public CommonSignedResponse<MRO_BA_Execution_Type_Request, MRO_BA_Execution_Type_Response> GetMRO_BA_Execution_Type(MRO_BA_Execution_Type_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {

//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MROBatteriesServiceReference.MROBAServiceClient serviceClient = new MROBatteriesServiceReference.MROBAServiceClient("MROBAServiceImplPort", WebServiceUrl.Value);
//                MROBatteriesServiceReference.getExecutionTypeRequest req = new MROBatteriesServiceReference.getExecutionTypeRequest(argument.EIK);
//                MROBatteriesServiceReference.mrobaExecutionType serviceResult = serviceClient.getExecutionType(req).MRO_BA_Execution_Type_Response;

//                ObjectMapper<MROBatteriesServiceReference.mrobaExecutionType, MRO_BA_Execution_Type_Response> mapper = CreateExecutionTypeMapper(accessMatrix);
//                MRO_BA_Execution_Type_Response searchResults = new MRO_BA_Execution_Type_Response();
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

//        private static ObjectMapper<MROBatteriesServiceReference.mrobaExecutionType, MRO_BA_Execution_Type_Response> CreateExecutionTypeMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MROBatteriesServiceReference.mrobaExecutionType, MRO_BA_Execution_Type_Response> mapper = new ObjectMapper<MROBatteriesServiceReference.mrobaExecutionType, MRO_BA_Execution_Type_Response>(accessMatrix);

//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.Authorization.AuthNum);
//            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
//            // mapper.AddPropertyMap((o) => o.Authorization.MroFulfillment, (c) => Enum.Parse(typeof(Fulfilment), c.Authorization.MroFulfillment));
//            mapper.AddFunctionMap<MROBatteriesServiceReference.AuthorizationExecutionType, Fulfilment>((o) => o.Authorization.MroFulfillment, (c) => (Fulfilment)Enum.Parse(typeof(Fulfilment), "Item" + c.MroFulfillment));
//            mapper.AddPropertyMap((o) => o.Authorization.RecOrgNum, (c) => c.Authorization.RecOrgNum);
//            mapper.AddPropertyMap((o) => o.Authorization.UonName, (c) => c.Authorization.UonName);

//            return mapper;
//        }

//        public CommonSignedResponse<MRO_BA_Trade_Marks_Request, MRO_BA_Trade_Marks_Response> GetMRO_BA_Trade_Marks(MRO_BA_Trade_Marks_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MROBatteriesServiceReference.MROBAServiceClient serviceClient = new MROBatteriesServiceReference.MROBAServiceClient("MROBAServiceImplPort", WebServiceUrl.Value);
//                MROBatteriesServiceReference.getTradeMarksRequest req = new MROBatteriesServiceReference.getTradeMarksRequest(argument.AuthNum);
//                MROBatteriesServiceReference.mrobaTradeMarks serviceResult = serviceClient.getTradeMarks(req).MRO_BA_Trade_Marks_Response;

//                ObjectMapper<MROBatteriesServiceReference.mrobaTradeMarks, MRO_BA_Trade_Marks_Response> mapper = CreateTradeMarksMapper(accessMatrix);
//                MRO_BA_Trade_Marks_Response searchResults = new MRO_BA_Trade_Marks_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     searchResults,
//                     accessMatrix,
//                     aditionalParameters
//                 ); ;
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<MROBatteriesServiceReference.mrobaTradeMarks, MRO_BA_Trade_Marks_Response> CreateTradeMarksMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MROBatteriesServiceReference.mrobaTradeMarks, MRO_BA_Trade_Marks_Response> mapper = new ObjectMapper<MROBatteriesServiceReference.mrobaTradeMarks, MRO_BA_Trade_Marks_Response>(accessMatrix);
//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddPropertyMap((o) => o.Authorization.EIK, (c) => c.Authorization.EIK);
//            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
//            //mapper.AddConstantMap((o) => o.Authorization.TradeMarks, new AuthorizationTradeMarksTradeMarks());
//            //mapper.AddCollectionMap<MROBatteriesServiceReference.mrobaTradeMarks>((o) => o.Authorization.TradeMarks.TradeMark, (c) => c.Authorization.TradeMark);
//            mapper.AddFunctionMap<MROBatteriesServiceReference.mrobaTradeMarks, List<string>>((o) => o.Authorization.TradeMarks.TradeMark, (c) => c.Authorization.TradeMark.ToList());

//            //mapper.AddPropertyMap((o) => o.Authorization.TradeMarks.TradeMark[0], (c) => c.Authorization.TradeMark[0]);

//            return mapper;
//        }
//        public CommonSignedResponse<MRO_BA_Category_Request, MRO_BA_Category_Response> GetMRO_BA_Category(MRO_BA_Category_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                MROBatteriesServiceReference.MROBAServiceClient serviceClient = new MROBatteriesServiceReference.MROBAServiceClient("MROBAServiceImplPort", WebServiceUrl.Value);
//                MROBatteriesServiceReference.getCategoryRequest req = new MROBatteriesServiceReference.getCategoryRequest(argument.EIK);
//                MROBatteriesServiceReference.mrobaCategory serviceResult = serviceClient.getCategory(req).MRO_BA_Category_Response;

//                ObjectMapper<MROBatteriesServiceReference.mrobaCategory, MRO_BA_Category_Response> mapper = CreateCategoryMapper(accessMatrix);
//                MRO_BA_Category_Response searchResults = new MRO_BA_Category_Response();
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

//        private static ObjectMapper<MROBatteriesServiceReference.mrobaCategory, MRO_BA_Category_Response> CreateCategoryMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<MROBatteriesServiceReference.mrobaCategory, MRO_BA_Category_Response> mapper = new ObjectMapper<MROBatteriesServiceReference.mrobaCategory, MRO_BA_Category_Response>(accessMatrix);
//            mapper.AddObjectMap((o) => o.Authorization, (c) => c.Authorization);
//            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.Authorization.AuthNum);
//            //mapper.AddConstantMap((o) => o.Authorization.BACategories, new AuthorizationCategoryBACategories());
//            //mapper.AddCollectionMap<MROBatteriesServiceReference.mrobaCategory>((o) => o.Authorization.BACategories.BACategory, (c) => c.Authorization.BACategory);
//            //mapper.AddPropertyMap((o) => o.Authorization.BACategories.BACategory[0], (c) => c.Authorization.BACategory[0]);
//            mapper.AddFunctionMap<MROBatteriesServiceReference.mrobaCategory, List<string>>((o) => o.Authorization.BACategories.BACategory, (c) => c.Authorization.BACategory.ToList());
//            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.Authorization.CompanyName);
//            return mapper;
//        }

//    }
//}
