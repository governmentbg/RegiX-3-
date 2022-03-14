//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.Globalization;
//using System.Linq.Expressions;
//using System.Xml;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.Xml.Linq;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.NoiRPAdapter.NoiService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.WebServiceAdapterService;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.Utils;

//namespace TechnoLogica.RegiX.NoiRPAdapter.AdapterService
//{
//    public class RPAdapter : SoapServiceBaseAdapterService, IRPAdapter, IAdapterService
//    {
//        private readonly string Nodata = "Nodata";
//        private readonly string[] DateFormats = { "dd.MM.yyyy", "dd.MM.yyyyг.", "dd.MM.yyyy г." };

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(RPAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//            new ParameterInfo<string>("https://172.18.253.241/egovapplications/ServiceGetData.asmx")
//            {
//                               Key = Constants.WebServiceUrlParameterKeyName,
//                               Description = "Web Service Url",
//                OwnerAssembly = typeof(RPAdapter).Assembly
//            };


//        public CommonSignedResponse<PensionRightRequestType, PensionRightResponseType> GetPensionRightInfoReport(PensionRightRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            const int repNum = 49;
//            const int toMonth = 0;
//            const int toYear = 0;
//            const int externalUserID = 1;
//            const string externalUserName = "Government";

//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                ServiceGetDataSoapClient serviceClient = new ServiceGetDataSoapClient("ServiceGetDataSoap", WebServiceUrl.Value);

//            string identifierString = argument.Identifier;
//            if (argument.IdentifierType == IdentifierType.ЕГН)
//            {
//                identifierString += "0";
//            }
//            else if (argument.IdentifierType == IdentifierType.ЛНЧ)
//            {
//                identifierString += "1";
//            }

//            int fromMonth = Conversions.GMonthToInt.Invoke(argument.Month.Month);
//            int fromYear = Conversions.GYearToInt(argument.Month.Year);

//                XElement serviceResult = serviceClient.GetDataGov(externalUserID, externalUserName, fromYear, fromMonth,
//                    toYear, toMonth, identifierString, repNum);

//            var xElement = serviceResult.Element("NODATA");
//            if (xElement != null && !string.IsNullOrWhiteSpace(xElement.Value.Trim()))
//            {
//                throw new Exception(xElement.Value);
//            }
//            XPathMapper<PensionRightResponseType> mapper = CreatePensionRightResponseMapper(accessMatrix);
//                PensionRightResponseType searchResults = new PensionRightResponseType();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        additionalParameters
//                        );
//        }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private XPathMapper<PensionRightResponseType> CreatePensionRightResponseMapper(AccessMatrix accessMatrix)
//        {
//            XPathMapper<PensionRightResponseType> mapper = new XPathMapper<PensionRightResponseType>(accessMatrix);

//            mapper.AddPropertyMap(p => p.Title, "/start/Pensioner/Title");
//            mapper.AddFunctionMap(p => p.ForDate, node =>
//            {
//                XmlNode dateNode =
//                        node.SelectSingleNode(
//                            "/start/Pensioner/ForDate");
//                if (dateNode != null &&
//                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
//                    dateNode.InnerText != Nodata)
//                {
//                    return DateTime.ParseExact(dateNode.InnerText,
//                                               DateFormats,
//                                               CultureInfo.InvariantCulture.DateTimeFormat,
//                                               DateTimeStyles.AllowWhiteSpaces);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(p => p.TerritorialDivisionNOI, "/start/Pensioner/RUSO");
//            mapper.AddPropertyMap(p => p.Identifier, "/start/Pensioner/EGN");
//            mapper.AddPropertyMap(p => p.Names.Name, "/start/Pensioner/FirstName");
//            mapper.AddPropertyMap(p => p.Names.Surname, "/start/Pensioner/SurName");
//            mapper.AddPropertyMap(p => p.Names.FamilyName, "/start/Pensioner/FamilyName");
//            mapper.AddPropertyMap(p => p.Status, "/start/Pensioner/PensionerStatus");
//            mapper.AddFunctionMap(p => p.DateOfDeath, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "/start/Pensioner/DateOfDeath");
//                if (dateNode != null &&
//                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
//                    dateNode.InnerText != Nodata)
//                {
//                    return DateTime.ParseExact(dateNode.InnerText,
//                                               DateFormats,
//                                               CultureInfo.InvariantCulture.DateTimeFormat,
//                                               DateTimeStyles.AllowWhiteSpaces);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(p => p.ContentText, "/start/Pensioner/Contents");
//            mapper.AddCollectionMap(p => p.PensionCharacteristics, "/start/Pension/Data");
//            mapper.AddPropertyMap(p => p.PensionCharacteristics[0].DataText, ".");
//            mapper.AddPropertyMap(p => p.PensionCharacteristics[0].ValueText, "../Value");

//            return mapper;
//        }

//        public CommonSignedResponse<UP7RequestType, UP7ResponseType> GetPensionTypeAndAmountReport(UP7RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            const int repNum = 55;
//            const int toMonth = 0;
//            const int toYear = 0;
//            const int externalUserID = 1;
//            const string externalUserName = "Government";

//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                ServiceGetDataSoapClient serviceClient = new ServiceGetDataSoapClient("ServiceGetDataSoap",
//                    WebServiceUrl.Value);

//            string identifierString = argument.Identifier;
//            if (argument.IdentifierType == IdentifierType.ЕГН)
//            {
//                identifierString += "0";
//            }
//            else if (argument.IdentifierType == IdentifierType.ЛНЧ)
//            {
//                identifierString += "1";
//            }

//            int fromMonth = Conversions.GMonthToInt.Invoke(argument.Month.Month);
//            int fromYear = Conversions.GYearToInt(argument.Month.Year);

//                XElement serviceResult = serviceClient.GetDataGov(externalUserID, externalUserName, fromYear, fromMonth,
//                    toYear, toMonth, identifierString, repNum);

//            var xElement = serviceResult.Element("NODATA");
//            if (xElement != null && !string.IsNullOrWhiteSpace(xElement.Value.Trim()))
//            {
//                throw new Exception(xElement.Value);
//            }

//            XPathMapper<UP7ResponseType> mapper = CreateUP7ResponseMapper(accessMatrix);
//                UP7ResponseType searchResults = new UP7ResponseType();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        additionalParameters
//                        );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private XPathMapper<UP7ResponseType> CreateUP7ResponseMapper(AccessMatrix accessMatrix)
//        {
//            XPathMapper<UP7ResponseType> mapper = new XPathMapper<UP7ResponseType>(accessMatrix);

//            mapper.AddPropertyMap(p => p.Title, "/start/Pensioner/Title");
//            mapper.AddFunctionMap(p => p.ForDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "/start/Pensioner/ForDate");
//                if (dateNode != null &&
//                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
//                    dateNode.InnerText != Nodata)
//                {
//                    return DateTime.ParseExact(dateNode.InnerText,
//                                               DateFormats,
//                                               CultureInfo.InvariantCulture.DateTimeFormat,
//                                               DateTimeStyles.AllowWhiteSpaces);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(p => p.TerritorialDivisionNOI, "/start/Pensioner/RUSO");
//            mapper.AddPropertyMap(p => p.Identifier, "/start/Pensioner/EGN");
//            mapper.AddPropertyMap(p => p.Names.Name, "/start/Pensioner/FirstName");
//            mapper.AddPropertyMap(p => p.Names.Surname, "/start/Pensioner/SurName");
//            mapper.AddPropertyMap(p => p.Names.FamilyName, "/start/Pensioner/FamilyName");
//            mapper.AddPropertyMap(p => p.PensionerStatus, "/start/Pensioner/PensionerStatus");
//            mapper.AddPropertyMap(p => p.ReceivingAmountNumbers, "/start/Pensioner/TotalSum");
//            mapper.AddFunctionMap(p => p.DateOfDeath, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "/start/Pensioner/DateOfDeath");
//                if (dateNode != null &&
//                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
//                    dateNode.InnerText != Nodata)
//                {
//                    return DateTime.ParseExact(dateNode.InnerText,
//                                               DateFormats,
//                                               CultureInfo.InvariantCulture.DateTimeFormat,
//                                               DateTimeStyles.AllowWhiteSpaces);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(p => p.ContentText, "/start/Pensioner/Contents");
//            mapper.AddCollectionMap(p => p.Pensions, "/start/Pensions/PensionsDetails");
//            mapper.AddPropertyMap(p => p.Pensions[0].PensionType, ".");
//            mapper.AddPropertyMap(p => p.Pensions[0].PensionAmount, "../Value");

//            mapper.AddCollectionMap(p => p.AdditionAndReductionAmounts, "/start/Addition_or_Debt/Details");
//            mapper.AddPropertyMap(p => p.AdditionAndReductionAmounts[0].TypeName, ".");
//            mapper.AddPropertyMap(p => p.AdditionAndReductionAmounts[0].Value, "../Value");

//            return mapper;
//        }

//        public CommonSignedResponse<UP8RequestType, UP8ResponseType> GetPensionIncomeAmountReport(UP8RequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            const int repNum = 57;
//            const int externalUserID = 1;
//            const string externalUserName = "Government";

//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                ServiceGetDataSoapClient serviceClient = new ServiceGetDataSoapClient("ServiceGetDataSoap",
//                    WebServiceUrl.Value);

//            string identifierString = argument.Identifier;
//            if (argument.IdentifierType == IdentifierType.ЕГН)
//            {
//                identifierString += "0";
//            }
//            else if (argument.IdentifierType == IdentifierType.ЛНЧ)
//            {
//                identifierString += "1";
//            }

//            int fromMonth = Conversions.GMonthToInt.Invoke(argument.Period.From.Month);
//            int fromYear = Conversions.GYearToInt(argument.Period.From.Year);
//            int toMonth = Conversions.GMonthToInt(argument.Period.To.Month);
//            int toYear = Conversions.GYearToInt(argument.Period.To.Year);

//                XElement serviceResult = serviceClient.GetDataGov(externalUserID, externalUserName, fromYear, fromMonth,
//                    toYear, toMonth, identifierString, repNum);
//            var xElement = serviceResult.Element("NODATA");
//            if (xElement != null && !string.IsNullOrWhiteSpace(xElement.Value.Trim()))
//            {
//                throw new Exception(xElement.Value);
//            }

//            XPathMapper<UP8ResponseType> mapper = CreateUP8ResponseMapper(accessMatrix);
//                UP8ResponseType searchResults = new UP8ResponseType();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        additionalParameters
//                        );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private XPathMapper<UP8ResponseType> CreateUP8ResponseMapper(AccessMatrix accessMatrix)
//        {
//            XPathMapper<UP8ResponseType> mapper = new XPathMapper<UP8ResponseType>(accessMatrix);

//            mapper.AddPropertyMap(p => p.Title, "/start/Pensioner/Title");
//            mapper.AddFunctionMap(p => p.ForDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "/start/Pensioner/ForDate");
//                if (dateNode != null &&
//                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
//                    dateNode.InnerText != Nodata)
//                {
//                    return DateTime.ParseExact(dateNode.InnerText,
//                                               DateFormats,
//                                               CultureInfo.InvariantCulture.DateTimeFormat,
//                                               DateTimeStyles.AllowWhiteSpaces);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(p => p.TerritorialDivisionNOI, "/start/Pensioner/RUSO");
//            mapper.AddPropertyMap(p => p.Identifier, "/start/Pensioner/EGN");
//            mapper.AddPropertyMap(p => p.Names.Name, "/start/Pensioner/FirstName");
//            mapper.AddPropertyMap(p => p.Names.Surname, "/start/Pensioner/SurName");
//            mapper.AddPropertyMap(p => p.Names.FamilyName, "/start/Pensioner/FamilyName");
//            mapper.AddPropertyMap(p => p.PensionerStatus, "/start/Pensioner/PensionerStatus");
//            mapper.AddFunctionMap(p => p.DateOfDeath, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "/start/Pensioner/DateOfDeath");
//                if (dateNode != null &&
//                    !string.IsNullOrWhiteSpace(dateNode.InnerText) &&
//                    dateNode.InnerText != Nodata)
//                {
//                    return DateTime.ParseExact(dateNode.InnerText,
//                                               DateFormats,
//                                               CultureInfo.InvariantCulture.DateTimeFormat,
//                                               DateTimeStyles.AllowWhiteSpaces);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(p => p.ContentText, "/start/Pensioner/Contents");

//            mapper.AddCollectionMap(p => p.PensionPayments, "/start/Payment/MonthOfPay");
//            mapper.AddPropertyMap(p => p.PensionPayments[0].Month, ".");
//            mapper.AddPropertyMap(p => p.PensionPayments[0].TotalAmount, "../TotalSum");
//            mapper.AddPropertyMap(p => p.PensionPayments[0].PensionAmount, "../PensionsSum");
//            mapper.AddPropertyMap(p => p.PensionPayments[0].AdditionForAssistance, "../AssistSum");
//            mapper.AddPropertyMap(p => p.PensionPayments[0].OtherAddition, "../AdditionSum");

//            return mapper;
//        }
//    }
//}
