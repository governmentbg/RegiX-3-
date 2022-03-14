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
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.FirebirdSqlAdapterService;

//namespace TechnoLogica.RegiX.MZHAdapter.AdapterService
//{
//    public class MZHAdapter : NpgsqlAdapterService.NpgsqlBaseAdapterService, IMZHAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MZHAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>("Server=egov;Port=5432;Database=drive;UserId=postgres;Password=admin;Timeout=1024")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection string",
//                OwnerAssembly = typeof(MZHAdapter).Assembly
//            };

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MZHAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> SchemaName =
//            new ParameterInfo<string>("MZH")
//            {
//                Key = "SchemaName",
//                Description = "Name of the schema in database",
//                OwnerAssembly = typeof(MZHAdapter).Assembly
//            };

//        public CommonSignedResponse<FarmerSearchParametersType, FarmerType> FarmerDetailsSearch(FarmerSearchParametersType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                FarmerType result = new FarmerType();
//                if (argument.Parameter.StartsWith("1"))
//                {
//                    result = (FarmerType)FileUtils.ReadXml("\\XMLData\\MZH.xml", typeof(FarmerType));
//                }
//                else
//                {
//                    result = (FarmerType)FileUtils.ReadXml("\\XMLData\\MZH1.xml", typeof(FarmerType));
//                }
//                return
//                    SigningUtils.CreateAndSign(
//                    argument,
//                    result,
//                    accessMatrix,
//                    aditionalParameters
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