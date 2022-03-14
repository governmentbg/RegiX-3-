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
//using Oracle.ManagedDataAccess.Client;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.OracleAdapterService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;

//namespace TechnoLogica.RegiX.KzldAdministratorsAdapter.AdapterService
//{
//    public class KzldAdministratorsAdapter : OracleBaseAdapterService, IKzldAdministratorsAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(KzldAdministratorsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection String for Oracle datatabase",
//                OwnerAssembly = typeof(KzldAdministratorsAdapter).Assembly
//            };
//        public CommonSignedResponse<RegisteredAdministratorByIDType, RegisteredAdministratorByIDResponse> GetRegisteredAdministratorByID(RegisteredAdministratorByIDType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                RegisteredAdministratorByIDResponse result = new RegisteredAdministratorByIDResponse();
//                if (argument.PersonalDataControllerID != null)
//                {
//                    result = (RegisteredAdministratorByIDResponse)FileUtils.ReadXml("\\XMLData\\GetRegisteredAdministratorByIDTest.xml", typeof(RegisteredAdministratorByIDResponse));
//                }
//                else
//                {
//                    result = (RegisteredAdministratorByIDResponse)FileUtils.ReadXml("\\XMLData\\GetRegisteredAdministratorByIDNullTest.xml", typeof(RegisteredAdministratorByIDResponse));
//                }
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     result,
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

//        public CommonSignedResponse<RegisteredAdministratorByNumberType, RegisteredAdministratorByNumberResponse> GetRegisteredAdministratorByNumber(RegisteredAdministratorByNumberType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {

//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                RegisteredAdministratorByNumberResponse result = new RegisteredAdministratorByNumberResponse();
//                if (argument.PDCRegisterNumber != null)
//                {
//                    result = (RegisteredAdministratorByNumberResponse)FileUtils.ReadXml("\\XMLData\\GetRegisteredAdministratorByNumberRESPONSE.xml", typeof(RegisteredAdministratorByNumberResponse));
//                }
//                else
//                {
//                    result = (RegisteredAdministratorByNumberResponse)FileUtils.ReadXml("\\XMLData\\GetRegisteredAdministratorByNumberNullTest.xml", typeof(RegisteredAdministratorByNumberResponse));
//                }
//                return
//                 SigningUtils.CreateAndSign(
//                     argument,
//                     result,
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

//    }
//}
