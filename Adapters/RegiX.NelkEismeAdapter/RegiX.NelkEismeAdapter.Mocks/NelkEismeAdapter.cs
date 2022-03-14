//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.NelkEismeAdapter.XMLSchemas;
//using TechnoLogica.RegiX.WebServiceAdapterService;

//namespace TechnoLogica.RegiX.NelkEismeAdapter.AdapterService
//{
//    public class NelkEismeAdapter : SoapServiceBaseAdapterService, INelkEismeAdapter, IAdapterService
//    {
//        public override string CheckRegisterConnection()
//        {
//            return Constants.ConnectionOk;
//        }

//        public CommonSignedResponse<GetAllExpertDecisionsByIdentifierRequest, ExpertDecisionsResponse> GetAllExpertDecisionsByIdentifier(GetAllExpertDecisionsByIdentifierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
//            try
//            {
//                ExpertDecisionsResponse searchResults = new ExpertDecisionsResponse();
//                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\GetAllExpertDecisionsByIdentifier\\" + argument.Identifier + ".xml";

//                if (File.Exists(fileName))
//                {
//                    searchResults = (ExpertDecisionsResponse)FileUtils.ReadXml("\\XMLData\\GetAllExpertDecisionsByIdentifier\\" + argument.Identifier + ".xml", typeof(ExpertDecisionsResponse));
//                }
//                else
//                {
//                    searchResults = (ExpertDecisionsResponse)FileUtils.ReadXml("\\XMLData\\GetAllExpertDecisionsByIdentifier\\default.xml", typeof(ExpertDecisionsResponse));
//                }
                
//                return
//                        SigningUtils.CreateAndSign(
//                            argument,
//                            searchResults,
//                            accessMatrix,
//                            aditionalParameters
//                        );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }
//        public CommonSignedResponse<GetLastExpertDecisionByIdentifierRequest, ExpertDecisionsResponse> GetLastExpertDecisionByIdentifier(GetLastExpertDecisionByIdentifierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
//            try
//            {
//                ExpertDecisionsResponse searchResults = new ExpertDecisionsResponse();
//                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\GetLastExpertDecisionByIdentifier\\" + argument.Identifier + ".xml";

//                if (File.Exists(fileName))
//                {
//                    searchResults = (ExpertDecisionsResponse)FileUtils.ReadXml("\\XMLData\\GetLastExpertDecisionByIdentifier\\" + argument.Identifier + ".xml", typeof(ExpertDecisionsResponse));
//                }
//                else
//                {
//                    searchResults = (ExpertDecisionsResponse)FileUtils.ReadXml("\\XMLData\\GetLastExpertDecisionByIdentifier\\default.xml", typeof(ExpertDecisionsResponse));
//                }
//                return
//                        SigningUtils.CreateAndSign(
//                            argument,
//                            searchResults,
//                            accessMatrix,
//                            aditionalParameters
//                        );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<GetAllExpertDecisionsByPeriodRequest, ExpertDesisionShortInfoForPeriodList> GetAllExpertDecisionsByPeriod(GetAllExpertDecisionsByPeriodRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
//            try
//            {
//                ExpertDesisionShortInfoForPeriodList searchResults = new ExpertDesisionShortInfoForPeriodList();
//                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\GetAllExpertDecisionsByPeriod\\" + argument.DateFrom.ToString("yyyy-MM-dd") + ".xml";

//                if (File.Exists(fileName))
//                {
//                    searchResults = (ExpertDesisionShortInfoForPeriodList)FileUtils.ReadXml("\\XMLData\\GetAllExpertDecisionsByPeriod\\" + argument.DateFrom.ToString("yyyy-MM-dd") + ".xml", typeof(ExpertDesisionShortInfoForPeriodList));
//                }
//                else
//                {
//                    searchResults = (ExpertDesisionShortInfoForPeriodList)FileUtils.ReadXml("\\XMLData\\GetAllExpertDecisionsByPeriod\\default.xml", typeof(ExpertDesisionShortInfoForPeriodList));
//                }
//                return
//                        SigningUtils.CreateAndSign(
//                            argument,
//                            searchResults,
//                            accessMatrix,
//                            aditionalParameters
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
