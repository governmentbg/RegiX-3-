using System;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Xml;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.Xml.Linq;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.WebServiceAdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.Utils;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NoiRPAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(RPAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(RPAdapter), typeof(IAdapterService))]
    public class RPAdapter : SoapServiceBaseAdapterService, IRPAdapter, IAdapterService
    {
        private readonly string Nodata = "Nodata";
        private readonly string[] DateFormats = { "dd.MM.yyyy", "dd.MM.yyyyг.", "dd.MM.yyyy г." };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(RPAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com:8078/RegiX.NoiRPAdapterMockup/NoiService.svc")
            {
                Key = Constants.WebServiceUrlParameterKeyName,
                Description = "Web Service Url",
                OwnerAssembly = typeof(RPAdapter).Assembly
            };


        public CommonSignedResponse<PensionRightRequestType, PensionRightResponseType> GetPensionRightInfoReport(PensionRightRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            const int repNum = 49;
            const int toMonth = 0;
            const int toYear = 0;
            const int externalUserID = 1;
            const string externalUserName = "Government";

            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                NoiService.Service1Client serviceClient = new NoiService.Service1Client("ServiceGetDataSoap", WebServiceUrl.Value);

                string identifierString = argument.Identifier;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierString += "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierString += "1";
                }

                int fromMonth = Conversions.GMonthToInt.Invoke(argument.Month.Month);
                int fromYear = Conversions.GYearToInt(argument.Month.Year);

                string serviceStringResult = serviceClient.GetDataGov(externalUserID, externalUserName, fromYear, fromMonth,
                    toYear, toMonth, identifierString, repNum);
                XElement serviceResult;
                try
                {
                    serviceResult = XDocument.Parse(serviceStringResult).Root;
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Guid = id, ResultString = serviceStringResult });
                    throw new FaultException("Услугата на НОИ връща невалиден XML като резултат!");
                }

                PensionRightResponseType searchResults = new PensionRightResponseType();

                var xElement = serviceResult.Element("NODATA");
                if (xElement != null)
                {
                    if (!string.IsNullOrWhiteSpace(xElement.Value.Trim()))
                    {
                        LogError(additionalParameters, new Exception(xElement.Value), new { Guid = id, xElementContent = xElement.Value });
                        throw new Exception(xElement.Value);
                    }
                    else
                    {
                        searchResults.Names = null;
                        searchResults.PensionCharacteristics = null;
                    }
                }
                else
                {
                    XPathMapper<PensionRightResponseType> mapper = CreatePensionRightResponseMapper(accessMatrix);
                    mapper.Map(serviceResult, searchResults);
                }
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        searchResults,
                        accessMatrix,
                        additionalParameters
                        );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private XPathMapper<PensionRightResponseType> CreatePensionRightResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<PensionRightResponseType> mapper = new XPathMapper<PensionRightResponseType>(accessMatrix);

            mapper.AddPropertyMap(p => p.Title, "/start/Pensioner/Title");
            mapper.AddFunctionMap(p => p.ForDate, node =>
            {
                XmlNode dateNode =
                        node.SelectSingleNode(
                            "/start/Pensioner/ForDate");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.TerritorialDivisionNOI, "/start/Pensioner/RUSO");
            mapper.AddPropertyMap(p => p.Identifier, "/start/Pensioner/EGN");
            mapper.AddPropertyMap(p => p.Names.Name, "/start/Pensioner/FirstName");
            mapper.AddPropertyMap(p => p.Names.Surname, "/start/Pensioner/SurName");
            mapper.AddPropertyMap(p => p.Names.FamilyName, "/start/Pensioner/FamilyName");
            mapper.AddPropertyMap(p => p.Status, "/start/Pensioner/PensionerStatus");
            mapper.AddFunctionMap(p => p.DateOfDeath, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "/start/Pensioner/DateOfDeath");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });
            mapper.AddPropertyMap(p => p.ContentText, "/start/Pensioner/Contents");
            mapper.AddCollectionMap(p => p.PensionCharacteristics, "/start/Pension/Data");
            mapper.AddPropertyMap(p => p.PensionCharacteristics[0].DataText, ".");
            mapper.AddPropertyMap(p => p.PensionCharacteristics[0].ValueText, "../Value");

            return mapper;
        }

        public CommonSignedResponse<UP7RequestType, UP7ResponseType> GetPensionTypeAndAmountReport(UP7RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            const int repNum = 55;
            const int toMonth = 0;
            const int toYear = 0;
            const int externalUserID = 1;
            const string externalUserName = "Government";

            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                NoiService.Service1Client serviceClient = new NoiService.Service1Client("ServiceGetDataSoap",
                    WebServiceUrl.Value);

                string identifierString = argument.Identifier;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierString += "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierString += "1";
                }

                int fromMonth = Conversions.GMonthToInt.Invoke(argument.Month.Month);
                int fromYear = Conversions.GYearToInt(argument.Month.Year);

                string serviceStringResult = serviceClient.GetDataGov(externalUserID, externalUserName, fromYear, fromMonth,
                    toYear, toMonth, identifierString, repNum);

                XElement serviceResult;

                try
                {
                    serviceResult = XDocument.Parse(serviceStringResult).Root;
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Guid = id, ResultString = serviceStringResult });
                    throw new FaultException("Услугата на НОИ връща невалиден XML като резултат!");
                }

                UP7ResponseType searchResults = new UP7ResponseType();

                var xElement = serviceResult.Element("NODATA");
                if (xElement != null)
                {
                    if (!string.IsNullOrWhiteSpace(xElement.Value.Trim()))
                    {
                        throw new Exception(xElement.Value);
                    }
                    else
                    {
                        searchResults.AdditionAndReductionAmounts = null;
                        searchResults.Names = null;
                        searchResults.Pensions = null;
                    }
                }
                else
                {

                    XPathMapper<UP7ResponseType> mapper = CreateUP7ResponseMapper(accessMatrix);
                    mapper.Map(serviceResult, searchResults);
                }
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        searchResults,
                        accessMatrix,
                        additionalParameters
                        );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<UP7NewRequestType, UP7NewResponseType> GetPensionTypeAndAmountReportUP7(UP7NewRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            const int repNum = 55;
            const int toMonth = 0;
            const int toYear = 0;
            const int externalUserID = 1;
            const string externalUserName = "Government";

            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                NoiService.Service1Client serviceClient = new NoiService.Service1Client("ServiceGetDataSoap",
                    WebServiceUrl.Value);

                string identifierString = argument.Identifier;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierString += "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierString += "1";
                }

                //string serviceStringResult = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\" + "GetPensionTypeAndAmountReportUP7NEW.xml");
                string serviceStringResult = serviceClient.GetDataGovUP7(externalUserID, externalUserName, identifierString);

                XElement serviceResult;

                try
                {
                    serviceResult = XDocument.Parse(serviceStringResult).Root;
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Guid = id, ResultString = serviceStringResult });
                    throw new FaultException("Услугата на НОИ връща невалиден XML като резултат!");
                }

                UP7NewResponseType searchResults = new UP7NewResponseType();

                var xElement = serviceResult.Element("NODATA");
                if (xElement != null)
                {
                    if (!string.IsNullOrWhiteSpace(xElement.Value.Trim()))
                    {
                        throw new Exception(xElement.Value);
                    }
                    else
                    {
                        searchResults.AdditionAndReductionAmounts = null;
                        searchResults.Names = null;
                        searchResults.Pensions = null;
                    }
                }
                else
                {

                    XPathMapper<UP7NewResponseType> mapper = CreateUP7NewResponseMapper(accessMatrix);
                    mapper.Map(serviceResult, searchResults);
                }
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        searchResults,
                        accessMatrix,
                        additionalParameters
                        );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }


        private XPathMapper<UP7ResponseType> CreateUP7ResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<UP7ResponseType> mapper = new XPathMapper<UP7ResponseType>(accessMatrix);

            mapper.AddPropertyMap(p => p.Title, "/start/Pensioner/Title");
            mapper.AddFunctionMap(p => p.ForDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "/start/Pensioner/ForDate");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.TerritorialDivisionNOI, "/start/Pensioner/RUSO");
            mapper.AddPropertyMap(p => p.Identifier, "/start/Pensioner/EGN");
            mapper.AddPropertyMap(p => p.Names.Name, "/start/Pensioner/FirstName");
            mapper.AddPropertyMap(p => p.Names.Surname, "/start/Pensioner/SurName");
            mapper.AddPropertyMap(p => p.Names.FamilyName, "/start/Pensioner/FamilyName");
            mapper.AddPropertyMap(p => p.PensionerStatus, "/start/Pensioner/PensionerStatus");
            mapper.AddPropertyMap(p => p.ReceivingAmountNumbers, "/start/Pensioner/TotalSum");
            mapper.AddFunctionMap(p => p.DateOfDeath, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "/start/Pensioner/DateOfDeath");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });
            mapper.AddPropertyMap(p => p.ContentText, "/start/Pensioner/Contents");
            mapper.AddCollectionMap(p => p.Pensions, "/start/Pensions/PensionsDetails");
            mapper.AddPropertyMap(p => p.Pensions[0].PensionType, ".");
            mapper.AddPropertyMap(p => p.Pensions[0].PensionAmount, "../Value");

            mapper.AddCollectionMap(p => p.AdditionAndReductionAmounts, "/start/Addition_or_Debt/Details");
            mapper.AddPropertyMap(p => p.AdditionAndReductionAmounts[0].TypeName, ".");
            mapper.AddPropertyMap(p => p.AdditionAndReductionAmounts[0].Value, "../Value");

            return mapper;
        }

        private XPathMapper<UP7NewResponseType> CreateUP7NewResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<UP7NewResponseType> mapper = new XPathMapper<UP7NewResponseType>(accessMatrix);
            mapper.AddPropertyMap(p => p.Title, "/start/Pensioner/Title");
            mapper.AddFunctionMap(p => p.ForDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "/start/Pensioner/ForDate");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.TerritorialDivisionNOI, "/start/Pensioner/RUSO");
            mapper.AddPropertyMap(p => p.Identifier, "/start/Pensioner/EGN");
            mapper.AddPropertyMap(p => p.Names.Name, "/start/Pensioner/FirstName");
            mapper.AddPropertyMap(p => p.Names.Surname, "/start/Pensioner/SurName");
            mapper.AddPropertyMap(p => p.Names.FamilyName, "/start/Pensioner/FamilyName");
            mapper.AddPropertyMap(p => p.PensionerStatus, "/start/Pensioner/PensionerStatus");
            mapper.AddPropertyMap(p => p.ReceivingAmountNumbers, "/start/Pensioner/TotalSum");
            mapper.AddFunctionMap(p => p.DateOfDeath, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "/start/Pensioner/DateOfDeath");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });
            mapper.AddPropertyMap(p => p.ContentText, "/start/Pensioner/Contents");
            mapper.AddCollectionMap(p => p.Pensions, "/start/Pensions/PensionsDetails");
            mapper.AddPropertyMap(p => p.Pensions[0].PensionType, ".");
            mapper.AddPropertyMap(p => p.Pensions[0].PensionAmount, "../Value");

            mapper.AddCollectionMap(p => p.AdditionAndReductionAmounts, "/start/Addition_or_Debt/Details");
            mapper.AddPropertyMap(p => p.AdditionAndReductionAmounts[0].TypeName, ".");
            mapper.AddPropertyMap(p => p.AdditionAndReductionAmounts[0].Value, "../Value");
            return mapper;
        }

        public CommonSignedResponse<UP8RequestType, UP8ResponseType> GetPensionIncomeAmountReport(UP8RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            const int repNum = 57;
            const int externalUserID = 1;
            const string externalUserName = "Government";

            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                NoiService.Service1Client serviceClient = new NoiService.Service1Client("ServiceGetDataSoap",
                    WebServiceUrl.Value);

                string identifierString = argument.Identifier;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierString += "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierString += "1";
                }

                int fromMonth = Conversions.GMonthToInt.Invoke(argument.Period.From.Month);
                int fromYear = Conversions.GYearToInt(argument.Period.From.Year);
                int toMonth = Conversions.GMonthToInt(argument.Period.To.Month);
                int toYear = Conversions.GYearToInt(argument.Period.To.Year);

                string serviceStringResult = serviceClient.GetDataGov(externalUserID, externalUserName, fromYear, fromMonth,
                    toYear, toMonth, identifierString, repNum);

                XElement serviceResult;

                try
                {
                    serviceResult = XDocument.Parse(serviceStringResult).Root;
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Guid = id, ResultString = serviceStringResult });
                    throw new FaultException("Услугата на НОИ връща невалиден XML като резултат!");
                }

                UP8ResponseType searchResults = new UP8ResponseType();

                var xElement = serviceResult.Element("NODATA");
                if (xElement != null)
                {
                    if (!string.IsNullOrWhiteSpace(xElement.Value.Trim()))
                    {
                        throw new Exception(xElement.Value);
                    }
                    else
                    {
                        searchResults.PensionPayments = null;
                        searchResults.Names = null;
                    }
                }
                else
                {
                    XPathMapper<UP8ResponseType> mapper = CreateUP8ResponseMapper(accessMatrix);
                    mapper.Map(serviceResult, searchResults);
                }
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        searchResults,
                        accessMatrix,
                        additionalParameters
                        );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private XPathMapper<UP8ResponseType> CreateUP8ResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<UP8ResponseType> mapper = new XPathMapper<UP8ResponseType>(accessMatrix);

            mapper.AddPropertyMap(p => p.Title, "/start/Pensioner/Title");
            mapper.AddFunctionMap(p => p.ForDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "/start/Pensioner/ForDate");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.TerritorialDivisionNOI, "/start/Pensioner/RUSO");
            mapper.AddPropertyMap(p => p.Identifier, "/start/Pensioner/EGN");
            mapper.AddPropertyMap(p => p.Names.Name, "/start/Pensioner/FirstName");
            mapper.AddPropertyMap(p => p.Names.Surname, "/start/Pensioner/SurName");
            mapper.AddPropertyMap(p => p.Names.FamilyName, "/start/Pensioner/FamilyName");
            mapper.AddPropertyMap(p => p.PensionerStatus, "/start/Pensioner/PensionerStatus");
            mapper.AddFunctionMap(p => p.DateOfDeath, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "/start/Pensioner/DateOfDeath");
                if (dateNode != null &&
                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
                    dateNode.InnerText != Nodata)
                {
                    return DateTime.ParseExact(dateNode.InnerText,
                                               DateFormats,
                                               CultureInfo.InvariantCulture.DateTimeFormat,
                                               DateTimeStyles.AllowWhiteSpaces);
                }
                return null;
            });
            mapper.AddPropertyMap(p => p.ContentText, "/start/Pensioner/Contents");

            mapper.AddCollectionMap(p => p.PensionPayments, "/start/Payment/MonthOfPay");
            mapper.AddPropertyMap(p => p.PensionPayments[0].Month, ".");
            mapper.AddPropertyMap(p => p.PensionPayments[0].TotalAmount, "../TotalSum");
            mapper.AddPropertyMap(p => p.PensionPayments[0].PensionAmount, "../PensionsSum");
            mapper.AddPropertyMap(p => p.PensionPayments[0].AdditionForAssistance, "../AssistSum");
            mapper.AddPropertyMap(p => p.PensionPayments[0].OtherAddition, "../AdditionSum");

            return mapper;
        }
    }
}
