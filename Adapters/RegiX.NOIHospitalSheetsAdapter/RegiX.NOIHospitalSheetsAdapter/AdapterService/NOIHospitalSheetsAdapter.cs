using NOIServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.NOIHospotalSheetsAdapter;
using TechnoLogica.RegiX.WebServiceAdapterService;

namespace TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NOIHospitalSheetsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NOIHospitalSheetsAdapter), typeof(IAdapterService))]
    public class NOIHospitalSheetsAdapter : SoapServiceBaseAdapterService, INOIHospitalSheetsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NOIHospitalSheetsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                          new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com:8078/")
                          {
                              Key = Constants.WebServiceUrlParameterKeyName,
                              Description = "Web Service Url",
                              OwnerAssembly = typeof(NOIHospitalSheetsAdapter).Assembly
                          };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NOIHospitalSheetsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> Username =
                         new ParameterInfo<string>("DAEU")
                         {
                             Key = "Username",
                             Description = "Username",
                             OwnerAssembly = typeof(NOIHospitalSheetsAdapter).Assembly
                         };
        public CommonSignedResponse<GetHospitalSheetsDataRequestType, GetHospitalSheetsDataResponseType> GetHospitalSheetsData(GetHospitalSheetsDataRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                var endpointConfig = NOIServiceReference.ePCReportEGNSoapClient.EndpointConfiguration.ePCReportEGNSoap;
                NOIServiceReference.ePCReportEGNSoapClient client = new NOIServiceReference.ePCReportEGNSoapClient(endpointConfig, WebServiceUrl.Value);

                string flagEgnParameter = ConvertIdentifierType(argument.IdentifierType);
                Task<NOIServiceReference.GetDataForEGNResponse> serviceResult = client.GetDataForEGNAsync(argument.Identifier, flagEgnParameter, Username.Value);
                Task.WaitAll();
                //string testServiceResult = ReadFile("C:\\Users\\mmarinov\\Desktop\\НОИ - Болнични листове\\Report_ePC_DAEU2.xml");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(serviceResult.Result.Body.GetDataForEGNResult);
                //xmlDocument.LoadXml(testServiceResult);

                //File.AppendAllText("C://RegiX//RegiX.NoiAdapters//log_errors.txt", xmlDocument.InnerXml);
                GetHospitalSheetsDataResponseType result = new GetHospitalSheetsDataResponseType();
                XPathMapper<GetHospitalSheetsDataResponseType> mapper = CreateProcurementDossierMapper(accessMatrix);
                mapper.Map(xmlDocument, result);

                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    additionalParameters
                );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                File.AppendAllText("C://RegiX//RegiX.NoiAdapters//log_errors.txt", GetFullExceptionDetails(ex, true));

                throw;
            }
        }

        private XPathMapper<GetHospitalSheetsDataResponseType> CreateProcurementDossierMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<GetHospitalSheetsDataResponseType> mapper = new XPathMapper<GetHospitalSheetsDataResponseType>(accessMatrix);          
            //Title
            mapper.AddPropertyMap(d => d.Title.Name, "./*[local-name()='Report']/*[local-name()='Title']/*[local-name()='Name']");
            mapper.AddPropertyMap(d => d.Title.NamesEGN, "./*[local-name()='Report']/*[local-name()='Title']/*[local-name()='NamesEGN']");
            mapper.AddFunctionMap(d => d.Title.ReportDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='Report']/*[local-name()='Title']/*[local-name()='Date']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    var format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff";
                    DateTime date;
                    CultureInfo culture = new CultureInfo("bg-BG");
                    DateTime.TryParseExact(dateNode.InnerText, format, culture, DateTimeStyles.None, out date);
                    return date;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Title.FlagEGN, "./*[local-name()='Report']/*[local-name()='Title']/*[local-name()='FlagEGN']");
            mapper.AddPropertyMap(d => d.Title.EGN, "./*[local-name()='Report']/*[local-name()='Title']/*[local-name()='EGN']");
            //ePCCharts            
            mapper.AddCollectionMap(d => d.ePatCharts.ePatChart, "./*[local-name()='Report']/*[local-name()='ePatChart']");
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].CanceledHospitalSheetNumber, "./*[local-name()='delpc']");
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].HospitalSheetIssueDate, "./*[local-name()='datai']");
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].IssuedHospitalSheetNumber, "./*[local-name()='ePCnum']");
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].MedicalCentreName, "./*[local-name()='miname']");
            mapper.AddFunctionMap(d => d.ePatCharts.ePatChart[0].SysDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='sys_date']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    var format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff";
                    DateTime date;
                    CultureInfo culture = new CultureInfo("bg-BG");
                    DateTime.TryParseExact(dateNode.InnerText, format, culture, DateTimeStyles.None, out date);
                    return date;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].TemporaryDisibilityReason, "./*[local-name()='Reas']");
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].VacationFromDate, "./*[local-name()='date1']");
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].VacationToDate, "./*[local-name()='date2']");
            mapper.AddPropertyMap(d => d.ePatCharts.ePatChart[0].HospitalSheetOperation, "./*[local-name()='oper']");
            return mapper;
        }

        private static string ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        private static string ConvertIdentifierType(IdentifierType identifierType)
        {
            switch (identifierType)
            {
                case IdentifierType.LNCh:
                    return "2";
                case IdentifierType.EGN:
                    return "0";
                default:
                    return "";
            }
        }

        private static string GetFullExceptionDetails(Exception e, bool includeStackTrace = false)
        {
            string newLine = Environment.NewLine;
            string message = e.Message;
            string exceptionType = e.GetType().ToString();

            string stack = "";
            if (includeStackTrace && !string.IsNullOrEmpty(e.StackTrace))
            {
                stack = e.StackTrace + newLine;
            }

            string LinesSeparator = new string('=', 27);
            string result = string.Format("{0}{1}{2}{1}{3}{1}{4}{1}{5}",
                LinesSeparator,
                newLine,
                exceptionType,
                e.Source,
                message,
                stack);
            if (e.InnerException != null)
            {
                result = result + GetFullExceptionDetails(e.InnerException, includeStackTrace);
            }

            return result;
        }
    }
}
