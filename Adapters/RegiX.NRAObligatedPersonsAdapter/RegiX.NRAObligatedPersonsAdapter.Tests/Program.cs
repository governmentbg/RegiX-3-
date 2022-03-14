//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.NRAObligatedPersonsAdapter;
//using TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService;

//using TechnoLogica.RegiX.Common.Utils;
//using System.Net;
//using System.ServiceModel;
//using TechnoLogica.RegiX.NRAEmploymentContractsAdapter;
//using TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService;

//namespace Regix.NRAObligatedPersonsAdapterTests
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Identifier:");
//            string identifier = Console.ReadLine();
//            Console.Write("IdentifierType");
//            string identifierType = Console.ReadLine();
//            Console.Write("Threshold");
//            string threshold = Console.ReadLine();
//            if (TestNRAObligatedPersonsAdapterTests(identifier, identifierType, Convert.ToInt32(threshold)))
//            {
//                Console.WriteLine("NRAObligatedPersonsAdapterTests Done!");
//            }
//            else
//            {
//                Console.WriteLine("NRAObligatedPersonsAdapterTests Done with errors! See file GetObligatedPersonsTestErrors.txt");
//            }
//            if (TestNRAEmploymentContractsAdapterTests(identifier, identifierType))
//            {
//                Console.WriteLine("NRAEmploymentContractsAdapterTests Done!");
//            }
//            else
//            {
//                Console.WriteLine("NRAEmploymentContractsAdapterTests Done with errors! See file GetEmploymentContractsTestErrors.txt");
//            }

//            Console.ReadLine();
//        }

//        private static bool TestNRAObligatedPersonsAdapterTests(string identifier, string type, int threshold)
//        {
//            bool haserror = false;
//            // NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(ObligationResponse));
//            TechnoLogica.RegiX.NRAObligatedPersonsAdapter.EikTypeTypeRequest eiktype;

//            try
//            {
//                eiktype = (TechnoLogica.RegiX.NRAObligatedPersonsAdapter.EikTypeTypeRequest)Enum.Parse(typeof(TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType), type);
//            }
//            catch
//            {
//                eiktype = TechnoLogica.RegiX.NRAObligatedPersonsAdapter.EikTypeTypeRequest.EGN;
//            }

//            TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest()
//            {
//                ID = identifier,
//                TYPE = eiktype
//            };
//            ObligationRequest searchCriteria = new ObligationRequest() { Identity = parameters, Threshold = (ushort)threshold, ThresholdSpecified = true };
//            TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters aparams = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters();
//            aparams.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            aparams.ClientIPAddress = System.Net.Dns.GetHostAddresses(Dns.GetHostName())[0].ToString();
//            aparams.EmployeeEGN = "8310188539";
//            try
//            {
//                //ObligationResponse result = adapter.GetObligatedPersons(searchCriteria, accessMatrix, aparams);
//                using (ChannelFactory<INRAObligatedPersonsAdapter> channelFactory = new ChannelFactory<INRAObligatedPersonsAdapter>("INRAObligatedPersonsAdapter"))
//                {
//                    var adapter = channelFactory.CreateChannel();

//                    var adapterResult = adapter.GetObligatedPersons(searchCriteria, accessMatrix, aparams);
//                    using (StreamWriter outfile = new StreamWriter("GetObligatedPersonsTest.xml", false, System.Text.Encoding.UTF8))
//                    {
//                        outfile.Write(adapterResult.XmlSerialize());
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                using (StreamWriter outfile = new StreamWriter("GetObligatedPersonsTestErrors.txt", false, System.Text.Encoding.UTF8))
//                {
//                    outfile.Write(GetMessage(ex));
//                    haserror = true;
//                }
//            }
//            return !haserror;

//        }

//        private static bool TestNRAEmploymentContractsAdapterTests(string identifier, string type)
//        {
//            bool haserror = false;
//            // NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentContractsResponse));
//            TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType eiktype;

//            try
//            {
//                eiktype = (TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType)Enum.Parse(typeof(TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType), type);
//            }
//            catch
//            {
//                eiktype = TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType.EGN;
//            }

//            TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest()
//            {
//                ID = identifier,
//                TYPE = eiktype
//            };
//            EmploymentContractsRequest searchCriteria = new EmploymentContractsRequest() { Identity = parameters };
//            TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters aparams = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters();
//            aparams.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            aparams.ClientIPAddress = System.Net.Dns.GetHostAddresses(Dns.GetHostName())[0].ToString();
//            aparams.EmployeeEGN = "8310188539";
//            try
//            {
//                //ObligationResponse result = adapter.GetObligatedPersons(searchCriteria, accessMatrix, aparams);
//                using (ChannelFactory<INRAEmploymentContractsAdapter> channelFactory = new ChannelFactory<INRAEmploymentContractsAdapter>("INRAEmploymentContractsAdapter"))
//                {
//                    var adapter = channelFactory.CreateChannel();

//                    var adapterResult = adapter.GetEmploymentContracts(searchCriteria, accessMatrix, aparams);
//                    using (StreamWriter outfile = new StreamWriter("GetEmploymentContractsTest.xml", false, System.Text.Encoding.UTF8))
//                    {
//                        outfile.Write(adapterResult.XmlSerialize());
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                using (StreamWriter outfile = new StreamWriter("GetEmploymentContractsTestErrors.txt", false, System.Text.Encoding.UTF8))
//                {
//                    outfile.Write(GetMessage(ex));
//                    haserror = true;
//                }
//            }
//            return !haserror;

//        }


//        private static string GetMessage(Exception ex)
//        {
//            if (ex != null)
//            {
//                return "Message: " + ex.Message + "StackTrace: " + ex.StackTrace + GetMessage(ex.InnerException);
//            }
//            return string.Empty;
//        }

//    }
//}
