//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.Utils;

//namespace TechnoLogica.RegiX.MPNPOAdapter.AdapterService
//{
//    public class MPNPOAdapter : SQLServerAdapterService.SQLServerAdapterService, IMPNPOAdapter
//    {
//        //public MPNPOAdapter()
//        //{
//        //    ConnectionString =
//        //    new ParameterInfo<string>(@"Data Source=egov;Initial Catalog=NGO_WEB;Password=ngo;User ID=ngo")
//        //    {
//        //        Key = "ConnectionString",
//        //        Description = "Connection string",
//        //        OwnerAssembly = typeof(MPNPOAdapter).Assembly
//        //    };
//        //    }

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MPNPOAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>(@"Data Source=egov;Initial Catalog=NGO_WEB;Password=ngo;User ID=ngo")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection string",
//                OwnerAssembly = typeof(MPNPOAdapter).Assembly
//            };

//        #region IMPNPOAdapter Members

//        public CommonSignedResponse<NPODetailsRequestType, NPODetailsResponseType> GetNPORegistrationInfo(NPODetailsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                NPODetailsResponseType result = new NPODetailsResponseType();
//                if (argument.Bulstat.StartsWith("1"))
//                {
//                    result = (NPODetailsResponseType)FileUtils.ReadXml("\\XMLData\\NPODeatailsInfo.xml", typeof(NPODetailsResponseType));
//                }
//                else
//                {
//                    result = (NPODetailsResponseType)FileUtils.ReadXml("\\XMLData\\NPODeatailsInfo.xml", typeof(NPODetailsResponseType));
//                }
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        additionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<NPOStatusRequestType, NPOStatusResponseType> GetNPOStatusInfo(NPOStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                NPOStatusResponseType result = new NPOStatusResponseType();
//                if (argument.Bulstat.StartsWith("1"))
//                {
//                    result = (NPOStatusResponseType)FileUtils.ReadXml("\\XMLData\\NPOStatusInfo.xml", typeof(NPOStatusResponseType));
//                }
//                else
//                {
//                    result = (NPOStatusResponseType)FileUtils.ReadXml("\\XMLData\\NPOStatusInfo.xml", typeof(NPOStatusResponseType));
//                }
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        additionalParameters
//                    );
//            }

//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        #endregion

       
//    }
//}
