//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.MPRNAdapter.ISPNService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.WebServiceAdapterService;

//namespace TechnoLogica.RegiX.MPRNAdapter.AdapterService
//{
//    public class RNAdapter : SoapServiceBaseAdapterService, IRNAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(RNAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/RegiX.MPRNAdapterMockup/MPRNServiceImplServiceInterfaces.svc")
//                           {
//                               Key = Constants.WebServiceUrlParameterKeyName,
//                               Description = "Web Service Url",
//                               OwnerAssembly = typeof(RNAdapter).Assembly
//                           };


//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(RNAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ServiceUser =
//            new ParameterInfo<string>("TechnoLogica SOAP/MoJ")
//            {
//                Key = "ServiceUser",
//                Description = "Register Of InsolvenciesWeb Service User",
//                OwnerAssembly = typeof(RNAdapter).Assembly
//            };

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(RNAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ServicePassword =
//            new ParameterInfo<string>("tLogica1357")
//            {
//                Key = "ServicePassword",
//                Description = "Register Of InsolvenciesWeb Service Password",
//                OwnerAssembly = typeof(RNAdapter).Assembly
//            };

//        public CommonSignedResponse<RNSearchRequestType, RNSearchResponseType> RegisterOfInsolvenciesSearch(RNSearchRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {

//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                ISPNService.ispnClient serviceClient = new ispnClient("Domino", WebServiceUrl.Value);
//                RESPONSE resp = serviceClient.LOGIN(ServiceUser.Value, ServicePassword.Value);
//                if (resp.TYPE.Value == 10)
//                {
//                    string sessionId = resp.SESSION.ID;
//                    int involvmentID = argument.InvolvеmentIDSpecified == false ? 0 : argument.InvolvеmentID;
//                    RESPONSE serviceResult = serviceClient.QUERY(sessionId, argument.Identifier, involvmentID, "");

//                    ObjectMapper<RESPONSE, RNSearchResponseType> mapper = CreateRegisterOfInsolvenciesMapper(accessMatrix);
//                    RNSearchResponseType searchResults = new RNSearchResponseType();
//                    mapper.Map(serviceResult, searchResults);
//                    return
//                     SigningUtils.CreateAndSign(
//                         argument,
//                         searchResults,
//                         accessMatrix,
//                         additionalParameters
//                     );
//                }
//                else
//                {
//                    new ApplicationException(resp.ERROR.ID + "-" + resp.ERROR.DESCRIPTION);
//                    return null;
//                }
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }


//        private static ObjectMapper<RESPONSE, RNSearchResponseType> CreateRegisterOfInsolvenciesMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<RESPONSE, RNSearchResponseType> mapper = new ObjectMapper<RESPONSE, RNSearchResponseType>(accessMatrix);

//            mapper.AddCollectionMap<RESPONSE>((o) => o.Cases, c => c.RESULTSET.RESULTS);

//            mapper.AddPropertyMap((o) => o.Cases[0].LastUpdated, (c) => c.RESULTSET.RESULTS[0].LASTUPDATE);

//            mapper.AddObjectMap((o) => o.Cases[0].CaseInfo, (c) => c.RESULTSET.RESULTS[0].CASE);
//            mapper.AddPropertyMap((o) => o.Cases[0].CaseInfo.Court, (c) => c.RESULTSET.RESULTS[0].CASE.COURT);
//            mapper.AddPropertyMap((o) => o.Cases[0].CaseInfo.CourtName, (c) => c.RESULTSET.RESULTS[0].CASE.COURTNAME);
//            mapper.AddPropertyMap((o) => o.Cases[0].CaseInfo.Date, (c) => c.RESULTSET.RESULTS[0].CASE.DATE);
//            mapper.AddPropertyMap((o) => o.Cases[0].CaseInfo.LastUpdate, (c) => c.RESULTSET.RESULTS[0].CASE.LASTUPDATE);
//            mapper.AddPropertyMap((o) => o.Cases[0].CaseInfo.Number, (c) => c.RESULTSET.RESULTS[0].CASE.NUMBER);
//            mapper.AddPropertyMap((o) => o.Cases[0].CaseInfo.Year, (c) => c.RESULTSET.RESULTS[0].CASE.YEAR);



//            mapper.AddObjectMap((o) => o.Cases[0].SideInfo, (c) => c.RESULTSET.RESULTS[0].SIDE);

//            mapper.AddFunctionMap<ISPNSIDE, string>((o) => o.Cases[0].SideInfo.EGN, (so) => (so.ISPERSON) ? so.STATENUMBER : null);
//            mapper.AddFunctionMap<ISPNSIDE, string>((o) => o.Cases[0].SideInfo.Bulstat, (so) => (!so.ISPERSON) ? so.STATENUMBER : null);
//            mapper.AddPropertyMap((o) => o.Cases[0].SideInfo.Involvement, (c) => c.RESULTSET.RESULTS[0].SIDE.INVOLVEMENT);
//            mapper.AddPropertyMap((o) => o.Cases[0].SideInfo.InvolvementText, (c) => c.RESULTSET.RESULTS[0].SIDE.INVOLVEMENTTEXT);
//            mapper.AddPropertyMap((o) => o.Cases[0].SideInfo.IsPerson, (c) => c.RESULTSET.RESULTS[0].SIDE.ISPERSON);
//            mapper.AddPropertyMap((o) => o.Cases[0].SideInfo.LastUpdate, (c) => c.RESULTSET.RESULTS[0].SIDE.LASTUPDATE);
//            mapper.AddPropertyMap((o) => o.Cases[0].SideInfo.Name, (c) => c.RESULTSET.RESULTS[0].SIDE.NAME);

//            return mapper;
//        }
//    }
//}
