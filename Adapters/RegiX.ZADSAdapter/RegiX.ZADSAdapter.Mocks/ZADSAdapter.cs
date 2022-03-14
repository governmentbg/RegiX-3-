//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.ComponentModel.Composition;
//using IBM.Data.Informix;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.DataContracts;

//namespace TechnoLogica.RegiX.ZADSAdapter.AdapterService
//{
//    public class ZADSAdapter : InformixAdapterService.InformixBaseAdapterService, IZADSAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(ZADSAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>("Database=zads;Host=egov;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection string for Informix",
//                OwnerAssembly = typeof(ZADSAdapter).Assembly
//            };

//        //[Export(typeof(HealthInfo))]
//        //public static HealthInfoWithFunction CheckDBConnection =
//        //    new HealthInfoWithFunction()
//        //    {
//        //        Key = "CheckDBConnection",
//        //        Name = "Проверява връзката към базата",
//        //        Description = "Проверява връзката към базата",
//        //        CheckFunction =
//        //        () =>
//        //        {
//        //            using (IfxConnection connection = new IfxConnection(ConnectionString.Value))
//        //            {
//        //                connection.Open();
//        //                return "ZADSAdapter Connection - OK";
//        //            }
//        //        }
//        //    };


//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(ZADSAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> SchemaName =
//            new ParameterInfo<string>("zads")
//            {
//                Key = "SchemaName",
//                Description = "Name of the schema in database",
//                OwnerAssembly = typeof(ZADSAdapter).Assembly
//            };

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(ZADSAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WhereStatement =
//            new ParameterInfo<string>(@"and version = (select max(version) from customerinfo WHERE customerkey = ?)
//                                        and not history")
//            {
//                Key = "WhereStatement",
//                Description = "Condition for valid customer",
//                OwnerAssembly = typeof(ZADSAdapter).Assembly
//            };

//        public CommonSignedResponse<RegistrationInfoRequestType, RegistrationInfoResponseType> GetRegistrationInfo(
//            RegistrationInfoRequestType argument,
//            AccessMatrix accessMatrix,
//            AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                RegistrationInfoResponseType result = new RegistrationInfoResponseType();
//                if (!argument.EIK.StartsWith("1"))
//                {
//                    result = (RegistrationInfoResponseType)FileUtils.ReadXml("\\XMLData\\ZADSRegistrationInfo.xml", typeof(RegistrationInfoResponseType));
//                }
//                else
//                {
//                    result = (RegistrationInfoResponseType)FileUtils.ReadXml("\\XMLData\\ZADSRegistrationInfo1.xml", typeof(RegistrationInfoResponseType));
//                }
//                return SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                        );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }
//    }
//}
