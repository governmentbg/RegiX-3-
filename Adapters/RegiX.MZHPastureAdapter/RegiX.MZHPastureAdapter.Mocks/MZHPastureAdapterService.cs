//using FirebirdSql.Data.FirebirdClient;
//using TechnoLogica.RegiX.FirebirdSqlAdapterService;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.Linq;
//using System.Reflection;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common;

//namespace TechnoLogica.RegiX.MZHPastureAdapter.AdapterService
//{
//    public class MZHPastureAdapterService : FirebirdSqlBaseAdapterService, IMZHPastureAdapterService, IAdapterService
//    {
//        [Export(typeof(TechnoLogica.RegiX.Common.AdapterCore.ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>(@"initial catalog=D:\DataBase\DOG_PML.FDB;data source=egov;user id=sysdba;password=masterkey")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection string",
//                OwnerAssembly = typeof(MZHPastureAdapterService).Assembly
//            };

//        public CommonSignedResponse<PastureMeadowLandRequestType, PastureMeadowLandResponse> GetPastureMeadowLand(PastureMeadowLandRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PastureMeadowLandResponse result = new PastureMeadowLandResponse();
//                if (argument.BeneficiaryIdentifier.StartsWith("0"))
//                {
//                    result = (PastureMeadowLandResponse)FileUtils.ReadXml("\\XMLData\\MZHPastureAdapter.xml", typeof(PastureMeadowLandResponse));
//                }
//                else
//                {
//                    result = (PastureMeadowLandResponse)FileUtils.ReadXml("\\XMLData\\MZHPastureAdapterNON.xml", typeof(PastureMeadowLandResponse));              
//                }
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }


//        public CommonSignedResponse<PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse> GetPastureMeadowLandDetail(PastureMeadowLandDetailRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
//            try
//            {
//                PastureMeadowLandDetailResponse result = new PastureMeadowLandDetailResponse();
//                if (argument.BeneficiaryIdentifier != null)
//                {
//                    result = (PastureMeadowLandDetailResponse)FileUtils.ReadXml("\\XMLData\\MZHPastureDetailResponse.xml", typeof(PastureMeadowLandDetailResponse));
//                }
//                else
//                {
//                    result = (PastureMeadowLandDetailResponse)FileUtils.ReadXml("\\XMLData\\PastureMeadowLandDetailResponseEmpty.xml", typeof(PastureMeadowLandDetailResponse));
//                }
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }



//    }
//}
