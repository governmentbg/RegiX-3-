//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Data;
//using Oracle.ManagedDataAccess.Client;
//using System.ComponentModel.Composition;
//using System.Data.SqlClient;
//using System.Security.Cryptography.Xml;
//using System.Security.Cryptography;
//using System.Xml;

//using System.Security.Cryptography.X509Certificates;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.OracleAdapterService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;

//namespace TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.AdapterService
//{
//    public class KzldExemptAdministratorsAdapter : OracleAdapterService.OracleBaseAdapterService, IKzldExemptAdministratorsAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(KzldExemptAdministratorsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection String for Oracle datatabase",
//                OwnerAssembly = typeof(KzldExemptAdministratorsAdapter).Assembly
//            };

//        public CommonSignedResponse<ExemptRegistrationRequestType, ExemptRegistrationAdministratorResponse> GetExemptRegistrationAdministrator(ExemptRegistrationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                ExemptRegistrationAdministratorResponse result = new ExemptRegistrationAdministratorResponse();
//                if (argument.PersonalDataControllerID != null)
//                {
//                    result = (ExemptRegistrationAdministratorResponse)FileUtils.ReadXml("\\XMLData\\GetExemptRegistrationAdministratorTest.xml", typeof(ExemptRegistrationAdministratorResponse));
//                }
//                else
//                {
//                    result = (ExemptRegistrationAdministratorResponse)FileUtils.ReadXml("\\XMLData\\GetExemptRegistrationAdministratorNullTest.xml", typeof(ExemptRegistrationAdministratorResponse));
//                }
//                return SigningUtils.CreateAndSign(
//                    argument,
//                    result,
//                    accessMatrix,
//                    aditionalParameters
//                );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }
//    }
//}
