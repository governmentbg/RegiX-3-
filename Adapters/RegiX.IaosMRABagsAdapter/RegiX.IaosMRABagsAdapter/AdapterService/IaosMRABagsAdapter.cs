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

namespace TechnoLogica.RegiX.IaosMRABagsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaosMRABagsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaosMRABagsAdapter), typeof(IAdapterService))]
    public class IaosMRABagsAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, IIaosMRABagsAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaosMRABagsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-bags")
            {
                Key = Constants.WebServiceUrlParameterKeyName,
                Description = "Connection String for SOAP Web Service",
                OwnerAssembly = typeof(IaosMRABagsAdapter).Assembly
            };

        //public IaosMRABagsAdapter()
        //{
        //    WebServiceUrl =
        //        new ParameterInfo<string>("https://source.gravis.bg/egov/services/mro-bags")
        //        {
        //            Key = "ServiceUrl",
        //            Description = "IaosMROBags Web Service Url",
        //            OwnerAssembly = typeof(IaosMRABagsAdapter).Assembly
        //        };
        //}



        public CommonSignedResponse<MRO_BAGS_Reg_Number_Date_Request, MRO_BAGS_Reg_Number_Date_Response> GetMRA_BAGS_Reg_Number_Date(MRO_BAGS_Reg_Number_Date_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {

                MROBagsServiceReference.MROBagsServiceClient serviceClient = new MROBagsServiceReference.MROBagsServiceClient("MROBagsServiceImplPort", WebServiceUrl.Value);
                MROBagsServiceReference.AuthorizationRegNumDate serviceResult = serviceClient.getRegNumberDate(argument.DateTime, argument.EIK).Authorization;
                ObjectMapper<MROBagsServiceReference.AuthorizationRegNumDate, MRO_BAGS_Reg_Number_Date_Response> mapper = CreateRegNumberDateMapper(accessMatrix);
                MRO_BAGS_Reg_Number_Date_Response searchResults = new MRO_BAGS_Reg_Number_Date_Response();
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

        private static ObjectMapper<MROBagsServiceReference.AuthorizationRegNumDate, MRO_BAGS_Reg_Number_Date_Response> CreateRegNumberDateMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROBagsServiceReference.AuthorizationRegNumDate, MRO_BAGS_Reg_Number_Date_Response> mapper = new ObjectMapper<MROBagsServiceReference.AuthorizationRegNumDate, MRO_BAGS_Reg_Number_Date_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c);
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            mapper.AddPropertyMap((o) => o.Authorization.DateFrom, (c) => c.DateFrom);
            mapper.AddPropertyMap((o) => o.Authorization.DateTo, (c) => c.DateTo);
            mapper.AddFunctionMap<MROBagsServiceReference.AuthorizationRegNumDate, AuthState>((o) => o.Authorization.State, (c) => (AuthState)Enum.Parse(typeof(AuthState), "Item" + c.State));
            // mapper.AddPropertyMap((o) => o.Authorization.State, (c) => Enum.Parse(typeof(AuthState), c.State));
            return mapper;
        }

        public CommonSignedResponse<MRO_BAGS_Validity_Check_Request, MRO_BAGS_Validity_Check_Response> GetMRO_BAGS_Validity_Check(MRO_BAGS_Validity_Check_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROBagsServiceReference.MROBagsServiceClient serviceClient = new MROBagsServiceReference.MROBagsServiceClient("MROBagsServiceImplPort", WebServiceUrl.Value);
                MROBagsServiceReference.AuthorizationValidityCheck serviceResult = serviceClient.getValidityCheck(argument.EIK).Authorization;
                ObjectMapper<MROBagsServiceReference.AuthorizationValidityCheck, MRO_BAGS_Validity_Check_Response> mapper = CreateValidityCheckMapper(accessMatrix);
                MRO_BAGS_Validity_Check_Response searchResults = new MRO_BAGS_Validity_Check_Response();
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

        private static ObjectMapper<MROBagsServiceReference.AuthorizationValidityCheck, MRO_BAGS_Validity_Check_Response> CreateValidityCheckMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROBagsServiceReference.AuthorizationValidityCheck, MRO_BAGS_Validity_Check_Response> mapper = new ObjectMapper<MROBagsServiceReference.AuthorizationValidityCheck, MRO_BAGS_Validity_Check_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c);
            mapper.AddPropertyMap((o) => o.Authorization.AuthNum, (c) => c.AuthNum);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            mapper.AddPropertyMap((o) => o.Authorization.Address, (c) => c.Address);
            mapper.AddPropertyMap((o) => o.Authorization.DistName, (c) => c.DistName);
            mapper.AddPropertyMap((o) => o.Authorization.FirstName, (c) => c.FirstName);
            mapper.AddPropertyMap((o) => o.Authorization.LastName, (c) => c.LastName);
            mapper.AddPropertyMap((o) => o.Authorization.PopName, (c) => c.PopName);
            mapper.AddPropertyMap((o) => o.Authorization.TerName, (c) => c.TerName);

            return mapper;
        }

        public CommonSignedResponse<MRO_BAGS_Reg_Number_Request, MRO_BAGS_Reg_Number_Response> GetMRO_BAGS_Reg_Number(MRO_BAGS_Reg_Number_Request argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                MROBagsServiceReference.MROBagsServiceClient serviceClient = new MROBagsServiceReference.MROBagsServiceClient("MROBagsServiceImplPort", WebServiceUrl.Value);
                MROBagsServiceReference.AuthorizationRegNum serviceResult = serviceClient.getRegNumber(argument.AuthNum).Authorization;
                ObjectMapper<MROBagsServiceReference.AuthorizationRegNum, MRO_BAGS_Reg_Number_Response> mapper = CreateRegNumberMapper(accessMatrix);
                MRO_BAGS_Reg_Number_Response searchResults = new MRO_BAGS_Reg_Number_Response();
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

        private static ObjectMapper<MROBagsServiceReference.AuthorizationRegNum, MRO_BAGS_Reg_Number_Response> CreateRegNumberMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MROBagsServiceReference.AuthorizationRegNum, MRO_BAGS_Reg_Number_Response> mapper = new ObjectMapper<MROBagsServiceReference.AuthorizationRegNum, MRO_BAGS_Reg_Number_Response>(accessMatrix);
            mapper.AddObjectMap((o) => o.Authorization, (c) => c);
            mapper.AddPropertyMap((o) => o.Authorization.Address, (c) => c.Address);
            mapper.AddPropertyMap((o) => o.Authorization.CompanyName, (c) => c.CompanyName);
            mapper.AddPropertyMap((o) => o.Authorization.DistName, (c) => c.DistName);
            mapper.AddPropertyMap((o) => o.Authorization.EIK, (c) => c.EIK);
            mapper.AddPropertyMap((o) => o.Authorization.FirstName, (c) => c.FirstName);
            mapper.AddPropertyMap((o) => o.Authorization.LastName, (c) => c.LastName);
            mapper.AddPropertyMap((o) => o.Authorization.MidName, (c) => c.MidName);
            mapper.AddPropertyMap((o) => o.Authorization.PopName, (c) => c.PopName);
            mapper.AddPropertyMap((o) => o.Authorization.TerName, (c) => c.TerName);

            return mapper;
        }

    }
}
