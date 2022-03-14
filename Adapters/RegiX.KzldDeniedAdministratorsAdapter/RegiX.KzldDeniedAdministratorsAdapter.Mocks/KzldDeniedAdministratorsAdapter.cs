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

//namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.AdapterService
//{
//    public class KzldDeniedAdministratorsAdapter : OracleAdapterService.OracleBaseAdapterService, IKzldDeniedAdministratorsAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(KzldDeniedAdministratorsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection String for Oracle datatabase",
//                OwnerAssembly = typeof(KzldDeniedAdministratorsAdapter).Assembly
//            };

//        public CommonSignedResponse<DeniedEntryAdministratorRequestType, DeniedEntryAdministratorResponse> GetRegisteredAdministratorByID(DeniedEntryAdministratorRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                DeniedEntryAdministratorResponse result = new DeniedEntryAdministratorResponse();
//                if (argument.PersonalDataControllerID != null)
//                {
//                    result = (DeniedEntryAdministratorResponse)FileUtils.ReadXml("\\XMLData\\GetRegisteredAdministratorByIDTest.xml", typeof(DeniedEntryAdministratorResponse));
//                }
//                else
//                {
//                    result = (DeniedEntryAdministratorResponse)FileUtils.ReadXml("\\XMLData\\GetRegisteredAdministratorByIDNullTest.xml", typeof(DeniedEntryAdministratorResponse));
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
