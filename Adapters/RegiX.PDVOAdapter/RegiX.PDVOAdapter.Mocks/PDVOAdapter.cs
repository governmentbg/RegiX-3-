//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.ComponentModel.Composition;
//using System.Data;
//using Npgsql;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.DataContracts;

//namespace TechnoLogica.RegiX.PDVOAdapter.AdapterService
//{
//    public class PDVOAdapter : NpgsqlAdapterService.NpgsqlBaseAdapterService, IPDVOAdapter, IAdapterService
//    {
//        //public PDVOAdapter()
//        //{
//        //    ConnectionString =
//        //        new ParameterInfo<string>("Server=egov;Port=5432;Database=drive;UserId=;Password=;Timeout=1024")
//        //        {
//        //            Key = "ConnectionString",
//        //            Description = "Connection string",
//        //            OwnerAssembly = typeof(PDVOAdapter).Assembly
//        //        };
//        //}

//        [Export(typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>("Server=egov;Port=5432;Database=drive;UserId=;Password=;Timeout=1024")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection string",
//                OwnerAssembly = typeof(PDVOAdapter).Assembly
//            };

//        [Export(typeof(ParameterInfo))]
//        public static ParameterInfo<string> SchemaName =
//            new ParameterInfo<string>("PDVO")
//            {
//                Key = "SchemaName",
//                Description = "Name of the schema in database",
//                OwnerAssembly = typeof(PDVOAdapter).Assembly
//            };

//        public CommonSignedResponse<AcademicRecognitionRequestType, AcademicRecognitionResponseType> GetAcademicRecognition(AcademicRecognitionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                AcademicRecognitionResponseType result = new AcademicRecognitionResponseType();
//                if (argument.InternalAppNum.StartsWith("6"))
//                {
//                    result = (AcademicRecognitionResponseType)FileUtils.ReadXml("\\XMLData\\GetAcademicRecognition.xml", typeof(AcademicRecognitionResponseType));
//                }
//                else
//                {
//                    result = (AcademicRecognitionResponseType)FileUtils.ReadXml("\\XMLData\\GetAcademicRecognition.xml", typeof(AcademicRecognitionResponseType));
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
