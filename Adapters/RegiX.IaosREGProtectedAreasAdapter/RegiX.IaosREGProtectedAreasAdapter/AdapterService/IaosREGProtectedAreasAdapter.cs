using System;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaosREGProtectedAreasAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaosREGProtectedAreasAdapter), typeof(IAdapterService))]
    public class IaosREGProtectedAreasAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosREGProtectedAreasAdapter, IAdapterService
    {
        //public IaosREGProtectedAreasAdapter()
        //{
        //    WebServiceUrl =
        //       new ParameterInfo<string>("https://source.gravis.bg/egov/services/protected-area")
        //       {
        //           Key = "ServiceUrl",
        //           Description = "IaosProtectedArea Web Service Url",
        //           OwnerAssembly = typeof(IaosREGProtectedAreasAdapter).Assembly
        //       };
        //}

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaosREGProtectedAreasAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
       new ParameterInfo<string>("https://source.gravis.bg/egov/services/protected-area")
       {
           Key = Constants.WebServiceUrlParameterKeyName,
           Description = "Connection String for SOAP Web Service",
           OwnerAssembly = typeof(IaosREGProtectedAreasAdapter).Assembly
       };

        public CommonSignedResponse<REG_PAPZ_Protected_Area_Size_Request, REG_PAPZ_Protected_Area_Size_Response> GetREG_PAPZ_Protected_Area_Size(REG_PAPZ_Protected_Area_Size_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                REGProtectedAreasServiceReference.REGPapzServiceClient serviceClient = new REGProtectedAreasServiceReference.REGPapzServiceClient("REGPapzServiceImplPort", WebServiceUrl.Value);
                REGProtectedAreasServiceReference.papzProtectedAreaSize serviceResult = serviceClient.getProtectedAreaSize(argument.AreaCode, argument.AreaType);

                ObjectMapper<REGProtectedAreasServiceReference.papzProtectedAreaSize, REG_PAPZ_Protected_Area_Size_Response> mapper = CreateProtectedAreaSizeMapper(accessMatrix);
                REG_PAPZ_Protected_Area_Size_Response searchResults = new REG_PAPZ_Protected_Area_Size_Response();
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

        private static ObjectMapper<REGProtectedAreasServiceReference.papzProtectedAreaSize, REG_PAPZ_Protected_Area_Size_Response> CreateProtectedAreaSizeMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<REGProtectedAreasServiceReference.papzProtectedAreaSize, REG_PAPZ_Protected_Area_Size_Response> mapper = new ObjectMapper<REGProtectedAreasServiceReference.papzProtectedAreaSize, REG_PAPZ_Protected_Area_Size_Response>(accessMatrix);

            mapper.AddObjectMap((o) => o.ProtectedAreaSize, (c) => c.ProtectedAreaSize);
            mapper.AddPropertyMap((o) => o.ProtectedAreaSize.AreaName, (c) => c.ProtectedAreaSize.AreaName);
            mapper.AddPropertyMap((o) => o.ProtectedAreaSize.AreaSize, (c) => c.ProtectedAreaSize.AreaSize);
            mapper.AddPropertyMap((o) => o.ProtectedAreaSize.DistName, (c) => c.ProtectedAreaSize.DistName);
            mapper.AddPropertyMap((o) => o.ProtectedAreaSize.PopName, (c) => c.ProtectedAreaSize.PopName);
            mapper.AddPropertyMap((o) => o.ProtectedAreaSize.TerName, (c) => c.ProtectedAreaSize.TerName);
            return mapper;
        }

        public CommonSignedResponse<REG_PAPZ_Protected_Area_Category_Request, REG_PAPZ_Protected_Area_Category_Response> GetREG_PAPZ_Protected_Area_Category(REG_PAPZ_Protected_Area_Category_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {

            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                REGProtectedAreasServiceReference.REGPapzServiceClient serviceClient = new REGProtectedAreasServiceReference.REGPapzServiceClient("REGPapzServiceImplPort", WebServiceUrl.Value);
                REGProtectedAreasServiceReference.ProtectedAreaType[] serviceResult = serviceClient.getProtectedAreaCategory(argument.AreaType, argument.CategoryName);

                ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaType[], REG_PAPZ_Protected_Area_Category_Response> mapper = CreateProtectedAreaCategoryMapper(accessMatrix);
                REG_PAPZ_Protected_Area_Category_Response searchResults = new REG_PAPZ_Protected_Area_Category_Response();
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

        private static ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaType[], REG_PAPZ_Protected_Area_Category_Response> CreateProtectedAreaCategoryMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaType[], REG_PAPZ_Protected_Area_Category_Response> mapper = new ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaType[], REG_PAPZ_Protected_Area_Category_Response>(accessMatrix);


            mapper.AddCollectionMap<REGProtectedAreasServiceReference.ProtectedAreaType[]>((o) => o.ProtectedArea, c => c);
            // mapper.AddPropertyMap((o) => o.ProtectedAreas.ToArray(), (c) => c);
            mapper.AddPropertyMap((o) => o.ProtectedArea[0].AreaCode, (c) => c[0].AreaCode);
            mapper.AddPropertyMap((o) => o.ProtectedArea[0].AreaName, (c) => c[0].AreaName);
            mapper.AddPropertyMap((o) => o.ProtectedArea[0].DistName, (c) => c[0].DistName);
            mapper.AddPropertyMap((o) => o.ProtectedArea[0].PopName, (c) => c[0].PopName);
            mapper.AddPropertyMap((o) => o.ProtectedArea[0].RegimeDescription, (c) => c[0].RegimeDescription);
            mapper.AddPropertyMap((o) => o.ProtectedArea[0].RegimeNumber, (c) => c[0].RegimeNumber);
            mapper.AddPropertyMap((o) => o.ProtectedArea[0].TerName, (c) => c[0].TerName);
            return mapper;
        }

        public CommonSignedResponse<REG_PAPZ_Protected_Area_Location_Request, REG_PAPZ_Protected_Area_Location_Response> GetREG_PAPZ_Protected_Area_Location(REG_PAPZ_Protected_Area_Location_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                REGProtectedAreasServiceReference.REGPapzServiceClient serviceClient = new REGProtectedAreasServiceReference.REGPapzServiceClient("REGPapzServiceImplPort", WebServiceUrl.Value);
                REGProtectedAreasServiceReference.ProtectedAreaLocationType[] serviceResult = serviceClient.getProtectedAreaLocation(argument.DistName, argument.PopName, argument.TerName);
                ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaLocationType[], REG_PAPZ_Protected_Area_Location_Response> mapper = CreateProtectedAreaLocationMapper(accessMatrix);
                REG_PAPZ_Protected_Area_Location_Response searchResults = new REG_PAPZ_Protected_Area_Location_Response();
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

        private static ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaLocationType[], REG_PAPZ_Protected_Area_Location_Response> CreateProtectedAreaLocationMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaLocationType[], REG_PAPZ_Protected_Area_Location_Response> mapper = new ObjectMapper<REGProtectedAreasServiceReference.ProtectedAreaLocationType[], REG_PAPZ_Protected_Area_Location_Response>(accessMatrix);


            //mapper.AddFunctionMap<REGProtectedAreasServiceReference.AuthorizationWasteCodes, AuthorizationType>((o) => o.Authorization.AuthType, (c) => (AuthorizationType)Enum.Parse(typeof(AuthorizationType), c.AuthType));

            mapper.AddCollectionMap<REGProtectedAreasServiceReference.ProtectedAreaLocationType[]>((o) => o.ProtectedAreaLocation, (c) => c);
            //mapper.AddObjectMap((o) => o.ProtectedAreaLocation, (c) => c);
            //mapper.AddFunctionMap<ProtectedAreaLocationType[], List<ProtectedAreaLocationType>>((o) => o.ProtectedAreaLocation, (c) => c.ToList());
            mapper.AddPropertyMap((o) => o.ProtectedAreaLocation[0].AreaCode, (c) => c[0].AreaCode);
            mapper.AddPropertyMap((o) => o.ProtectedAreaLocation[0].AreaName, (c) => c[0].AreaName);
            mapper.AddPropertyMap((o) => o.ProtectedAreaLocation[0].AreaSize, (c) => c[0].AreaSize);
            mapper.AddPropertyMap((o) => o.ProtectedAreaLocation[0].AreaType, (c) => c[0].AreaType);
            mapper.AddPropertyMap((o) => o.ProtectedAreaLocation[0].RIOSV, (c) => c[0].Riosv);
            return mapper;
        }


    }
}
