//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.Data;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.XMLSchemas;
////using TechnoLogica.RegiX.GraoCommon;
//using TechnoLogica.RegiX.SQLServerAdapterService;

//namespace TechnoLogica.RegiX.GraoCivilStatusActsAdapter.AdapterService
//{
//    public class GraoCivilStatusActsAdapter : SQLServerAdapterService.SQLServerAdapterService, IGraoCivilStatusActsAdapter, IAdapterService
//    {
//        public override string CheckRegisterConnection()
//        {
//            return Constants.ConnectionOk;
//        }

//        public CommonSignedResponse<MarriageCertificateRequestType, MarriageCertificateResponseType> GetMarriageCertificate(MarriageCertificateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
//            try
//            {
//                MarriageCertificateResponseType result = new MarriageCertificateResponseType();

//                if (argument.Egn.StartsWith("0"))
//                {
//                    result = (MarriageCertificateResponseType)FileUtils.ReadXml("\\XMLData\\empty.xml", typeof(MarriageCertificateResponseType));
//                }

//                else
//                {
//                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\" + argument.Egn + ".xml";

//                    if (File.Exists(fileName))
//                    {
//                        result = (MarriageCertificateResponseType)FileUtils.ReadXml("\\XMLData\\" + argument.Egn + ".xml", typeof(MarriageCertificateResponseType));
//                    }
//                    else
//                    {
//                        result = (MarriageCertificateResponseType)FileUtils.ReadXml("\\XMLData\\default.xml", typeof(MarriageCertificateResponseType));
//                    }
//                }
                
//                result.ReportDate = DateTime.Now;
//                result.ReportDateSpecified = true;

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
