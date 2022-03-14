using System;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.NoiROAdapter.POVNForDatePayService;
using TechnoLogica.RegiX.NoiROAdapter.POVNForPeriodService;
using System.Xml.Linq;
using TechnoLogica.RegiX.NoiROAdapter.POBForDatePayService;
using TechnoLogica.RegiX.NoiROAdapter.POBPeriodService;
using TechnoLogica.RegiX.Common.Utils;
using System.Collections.Generic;
using System.Xml;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NoiROAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(ROAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(ROAdapter), typeof(IAdapterService))]
    public class ROAdapter : BaseAdapterService, IROAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ROAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ServicePOVNForDatePayUrl =
            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/NOI/ServPOVNDatePayTest/POVNForDatePay.asmx")
            {
                Key = "ServicePOVNForDatePayUrl",
                Description = "Disability Compensation For Date Pay Service Url",
                OwnerAssembly = typeof(ROAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ROAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ServicePOVNForPeriodUrl =
            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/NOI/ServPOVNPeriodTest/POVNForPeriod.asmx")
            {
                Key = "ServicePOVNForPeriodUrl",
                Description = "Disability Compensation For Period Service Url",
                OwnerAssembly = typeof(ROAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ROAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ServicePOBForDatePayUrl =
            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/NOI/ServPOBDatePayTest/POBForDatePay.asmx")
            {
                Key = "ServicePOBForDatePayUrl",
                Description = "Unemployment Compensation By Payment Period Service Url",
                OwnerAssembly = typeof(ROAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ROAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ServicePOBForPeriodUrl =
            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/NOI/ServPOBPeriodTest/POBForPeriod.asmx")
            {
                Key = "ServicePOBForPeriodUrl",
                Description = "Unemployment Compensation By Compensation Period Service Url",
                OwnerAssembly = typeof(ROAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ROAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> LogResultXml =
            new ParameterInfo<string>("true")
            {
                Key = "LogResultXml",
                Description = "Log result xml (true, false)",
                OwnerAssembly = typeof(ROAdapter).Assembly
            };

        public override string CheckRegisterConnection()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            string resultServicePOVNForDatePay = CheckConnectionsUtils.CheckSoapConnection(ServicePOVNForDatePayUrl.Value);
            string resultServicePOVNForPeriod = CheckConnectionsUtils.CheckSoapConnection(ServicePOVNForPeriodUrl.Value);
            string resultServicePOBForDatePay = CheckConnectionsUtils.CheckSoapConnection(ServicePOBForDatePayUrl.Value);
            string resultServicePOBForPeriod = CheckConnectionsUtils.CheckSoapConnection(ServicePOBForPeriodUrl.Value);

            results.Add("ServicePOVNForDatePayUrl", resultServicePOVNForDatePay);
            results.Add("ServicePOVNForPeriodUrl", resultServicePOVNForPeriod);
            results.Add("ServicePOBForDatePayUrl", resultServicePOBForDatePay);
            results.Add("ServicePOBForPeriodUrl", resultServicePOBForPeriod);

            string description = string.Empty;
            int statusOk = 0;
            int statusNotSet = 0;
            int ststusError = 0;
            foreach (var res in results)
            {
                description += String.Format("{0}: {1}\r\n", res.Key, res.Value);
                if (res.Value == Constants.ConnectionOk)
                {
                    statusOk++;
                }
                else
                {
                    if (res.Value == Constants.WebServiceUrlNotSet)
                    {
                        statusNotSet++;
                    }
                    else
                    {
                        ststusError++;
                    }
                }
            }
            if (ststusError > 0)
            {
                return description;
            }
            else
            {
                if (statusNotSet > 0)
                {
                    return Constants.WebServiceUrlNotSet;
                }
                else
                {
                    return Constants.ConnectionOk;
                }
            }
        }
        public CommonSignedResponse<POVNPOBRequestType, POVNPOBResponseType> SearchDisabilityCompensationByCompensationPeriod(POVNPOBRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                POVNForPeriodSoapClient serviceClient = new POVNForPeriodSoapClient("POVNForPeriodSoap", ServicePOVNForPeriodUrl.Value);

                string identifierTypeString = String.Empty;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierTypeString = "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierTypeString = "2";
                }

                string dateFromString = String.Empty;
                //if (argument.DateFromSpecified == true)
                //{
                dateFromString = argument.DateFrom.ToString("dd-MM-yyyy");
                //}

                string dateToString = String.Empty;
                //if (argument.DateToSpecified == true)
                //{
                dateToString = argument.DateTo.ToString("dd-MM-yyyy");
                //}

                XElement serviceResult = serviceClient.GetPOVNForPeriod(argument.Identifier,
                                                                        identifierTypeString,
                                                                        dateFromString,
                                                                        dateToString);
                if( LogResultXml.Value == "true")
                {
                    LogData(additionalParameters, new { Request = argument.XmlSerialize(), serviceResult = serviceResult, Guid = id });
                }
                var xElement = serviceResult.Element("Error");
                if (xElement != null && xElement.Value.Trim() != "0")
                {
                    throw new Exception(xElement.Value.Trim().Substring(1));
                }

                XPathMapper<POVNPOBResponseType> mapper = CreatePOVNPOBMapper(accessMatrix);
                POVNPOBResponseType searchResult = new POVNPOBResponseType();
                mapper.Map(serviceResult, searchResult);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        searchResult,
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

        public CommonSignedResponse<POVNVEDRequestType, POVNVEDResponseType> SearchDisabilityCompensationByPaymentPeriod(POVNVEDRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                POVNForDatePaySoapClient serviceClient = new POVNForDatePaySoapClient("POVNForDatePaySoap", ServicePOVNForDatePayUrl.Value);

                string identifierTypeString = String.Empty;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierTypeString = "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierTypeString = "2";
                }

                string dateFromString = String.Empty;
                //if (argument.DateFromSpecified == true)
                //{
                dateFromString = argument.DateFrom.ToString("dd-MM-yyyy");
                //}

                string dateToString = String.Empty;
                //if (argument.DateToSpecified == true)
                //{
                dateToString = argument.DateTo.ToString("dd-MM-yyyy");
                //}

                XElement serviceResult = serviceClient.GetPOVNForDatePay(argument.Identifier,
                                                                         identifierTypeString,
                                                                         dateFromString,
                                                                         dateToString);
                if (LogResultXml.Value == "true")
                {
                    LogData(additionalParameters, new { Request = argument.XmlSerialize(), serviceResult = serviceResult, Guid = id });
                }
                var xElement = serviceResult.Element("Error");
                if (xElement != null && xElement.Value.Trim() != "0")
                {
                    throw new Exception(xElement.Value.Trim().Substring(1));
                }

                XPathMapper<POVNVEDResponseType> mapper = CreatePOVNVEDMapper(accessMatrix);
                POVNVEDResponseType searchResult = new POVNVEDResponseType();
                mapper.Map(serviceResult, searchResult);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        searchResult,
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

        public CommonSignedResponse<POBPOBRequestType, POBPOBResponseType> SearchUnemploymentCompensationByCompensationPeriod(POBPOBRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                POBForPeriodSoapClient serviceClient = new POBForPeriodSoapClient("POBForPeriodSoap", ServicePOBForPeriodUrl.Value);

                string identifierTypeString = String.Empty;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierTypeString = "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierTypeString = "2";
                }

                string dateFromString = String.Empty;
                //if (argument.DateFromSpecified == true)
                //{
                dateFromString = argument.DateFrom.ToString("dd-MM-yyyy");
                //}

                string dateToString = String.Empty;
                //if (argument.DateToSpecified == true)
                //{
                dateToString = argument.DateTo.ToString("dd-MM-yyyy");
                //}
                XElement serviceResult = serviceClient.GetPOBForPeriod(argument.Identifier, identifierTypeString,
                    dateFromString, dateToString);

                if (LogResultXml.Value == "true")
                {
                    LogData(additionalParameters, new { Request = argument.XmlSerialize(), serviceResult = serviceResult, Guid = id });
                }

                var xElement = serviceResult.Element("Error");
                if (xElement != null && xElement.Value.Trim() != "0")
                {
                    throw new Exception(xElement.Value.Trim().Substring(1));
                }

                XPathMapper<POBPOBResponseType> mapper = CreatePOBPOBMapper(accessMatrix);
                POBPOBResponseType result = new POBPOBResponseType();
                mapper.Map(serviceResult, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
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

        public CommonSignedResponse<POBVEDRequestType, POBVEDResponseType> SearchUnemploymentCompensationByPaymentPeriod(POBVEDRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                POBForDatePaySoapClient serviceClient = new POBForDatePaySoapClient("POBForDatePaySoap", ServicePOBForDatePayUrl.Value);

                string identifierTypeString = String.Empty;
                if (argument.IdentifierType == IdentifierType.ЕГН)
                {
                    identifierTypeString = "0";
                }
                else if (argument.IdentifierType == IdentifierType.ЛНЧ)
                {
                    identifierTypeString = "2";
                }

                string dateFromString = String.Empty;
                //if (argument.DateFromSpecified == true)
                //{
                dateFromString = argument.DateFrom.ToString("dd-MM-yyyy");
                //}

                string dateToString = String.Empty;
                //if (argument.DateToSpecified == true)
                //{
                dateToString = argument.DateTo.ToString("dd-MM-yyyy");
                //}

                XElement serviceResult = serviceClient.GetPOBForDatePay(argument.Identifier, identifierTypeString,
                    dateFromString, dateToString);

                if (LogResultXml.Value == "true")
                {
                    LogData(additionalParameters, new { Request = argument.XmlSerialize(), serviceResult = serviceResult, Guid = id });
                }

                var xElement = serviceResult.Element("Error");
                if (xElement != null && xElement.Value.Trim() != "0")
                {
                    throw new Exception(xElement.Value.Trim().Substring(1));
                }

                XPathMapper<POBVEDResponseType> mapper = CreatePOBVEDMapper(accessMatrix);
                POBVEDResponseType result = new POBVEDResponseType();
                mapper.Map(serviceResult, result);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
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

        #region Help Methods
        private static XPathMapper<POVNPOBResponseType> CreatePOVNPOBMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<POVNPOBResponseType> mapper =
                new XPathMapper<POVNPOBResponseType>(accessMatrix);

            mapper.AddPropertyMap(p => p.Identifier, "/root/egn");
            mapper.AddPropertyMap(p => p.IdentifierType, "/root/flag_egn");
            mapper.AddPropertyMap(p => p.Names, "/root/egn_names");
            mapper.AddPropertyMap(p => p.MissingData, "/root/MissingData");
            mapper.AddCollectionMap(p => p.PaymentData, "/root/payment_data/benefit");
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitAmount, "./benefit_amount");
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitDatePayment, "./benefit_date_payment", (o) => DateTime.ParseExact(o.ToString(), "dd-MM-yyyy", null));
            mapper.AddFunctionMap(p => p.PaymentData[0].BenefitMonth, node => AddLeadingZeroToMonthPOV(node));
            //mapper.AddPropertyMap(p => p.PaymentData[0].BenefitMonth, "./benefit_month", Conversions.ToGMonth);
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitType, "./benefit_type");
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitYear, "./benefit_year");

            return mapper;
        }

        private static XPathMapper<POVNVEDResponseType> CreatePOVNVEDMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<POVNVEDResponseType> mapper =
                new XPathMapper<POVNVEDResponseType>(accessMatrix);

            mapper.AddPropertyMap(p => p.Identifier, "/root/egn");
            mapper.AddPropertyMap(p => p.IdentifierType, "/root/flag_egn");
            mapper.AddPropertyMap(p => p.Names, "/root/egn_names");
            mapper.AddPropertyMap(p => p.MissingData, "/root/MissingData");
            mapper.AddCollectionMap(p => p.PaymentData, "/root/payment_data/benefit");
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitAmount, "./benefit_amount");
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitDatePayment, "./benefit_date_payment", (o) => DateTime.ParseExact(o.ToString(), "dd-MM-yyyy", null));
            mapper.AddFunctionMap(p => p.PaymentData[0].BenefitMonth, node => AddLeadingZeroToMonthPOV(node));
            //mapper.AddPropertyMap(p => p.PaymentData[0].BenefitMonth, "./benefit_month", Conversions.ToGMonth);
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitType, "./benefit_type");
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitYear, "./benefit_year");

            return mapper;
        }

        private static string AddLeadingZeroToMonthPOV(XmlNode source)
        {
            string target = null;

            try
            {
                var benefitMonth = source.SelectSingleNode("./benefit_month");
                if (benefitMonth != null)
                {
                    int bMonth = Convert.ToInt32(benefitMonth.InnerText);
                    target = string.Format("--{0:00}", bMonth);
                }
            }
            catch (Exception)
            {
                target = null;
            }

            return target;
        }

        private static XPathMapper<POBVEDResponseType> CreatePOBVEDMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<POBVEDResponseType> mapper = new XPathMapper<POBVEDResponseType>(accessMatrix);

            mapper.AddPropertyMap(p => p.Identifier, "/root/egn");
            mapper.AddPropertyMap(p => p.IdentifierType, "/root/flag_egn");
            mapper.AddPropertyMap(p => p.Names, "/root/egn_names");
            mapper.AddPropertyMap(p => p.MissingData, "/root/MissingData");
            mapper.AddCollectionMap(p => p.PaymentData, "/root/payment_data/payment");
            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitType, "./payment_type");
            mapper.AddCollectionMap(p => p.PaymentData[0].Payments, "./benefits/benefit");
            mapper.AddFunctionMap(p => p.PaymentData[0].Payments[0].BenefitMonth, node => AddLeadingZeroToMonthPOB(node));
            //mapper.AddPropertyMap(p => p.PaymentData[0].Payments[0].BenefitMonth, "./POB_benefit_month", Conversions.ToGMonth);
            mapper.AddPropertyMap(p => p.PaymentData[0].Payments[0].BenefitYear, "./POB_benefit_year");
            mapper.AddPropertyMap(p => p.PaymentData[0].Payments[0].BenefitAmount, "./POB_benefit_amount");

            return mapper;
        }

        private static XPathMapper<POBPOBResponseType> CreatePOBPOBMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<POBPOBResponseType> mapper = new XPathMapper<POBPOBResponseType>(accessMatrix);

            mapper.AddPropertyMap(p => p.Identifier, "/root/egn");
            mapper.AddPropertyMap(p => p.IdentifierType, "/root/flag_egn");
            mapper.AddPropertyMap(p => p.Names, "/root/egn_names");
            mapper.AddPropertyMap(p => p.MissingData, "/root/MissingData");
            mapper.AddCollectionMap(p => p.PaymentData, "/root/payment_data/payment");
            mapper.AddPropertyMap(p => p.PaymentData[0].RegNumberDate, "./POB_reg_number_date");
            mapper.AddCollectionMap(p => p.PaymentData[0].PaymentsByType, "./POB_Benefit_type");
            mapper.AddPropertyMap(p => p.PaymentData[0].PaymentsByType[0].BenefitType, "./benefit_type");
            mapper.AddCollectionMap(p => p.PaymentData[0].PaymentsByType[0].Payments, "./benefit");
            mapper.AddFunctionMap(p => p.PaymentData[0].PaymentsByType[0].Payments[0].BenefitMonth, node => AddLeadingZeroToMonthPOB(node));
            //mapper.AddPropertyMap(p => p.PaymentData[0].PaymentsByType[0].Payments[0].BenefitMonth, "./POB_benefit_month", Conversions.ToGMonth);
            mapper.AddPropertyMap(p => p.PaymentData[0].PaymentsByType[0].Payments[0].BenefitAmount, "./POB_benefit_amount");
            mapper.AddPropertyMap(p => p.PaymentData[0].PaymentsByType[0].Payments[0].BenefitYear, "./POB_benefit_year");

            return mapper;
        }

        private static string AddLeadingZeroToMonthPOB(XmlNode source)
        {
            string target = null;

            try
            {
                var benefitMonth = source.SelectSingleNode("./POB_benefit_month");
                if (benefitMonth != null)
                {
                    int bMonth = Convert.ToInt32(benefitMonth.InnerText);
                    target = string.Format("--{0:00}", bMonth);
                }
            }
            catch (Exception)
            {
                target = null;
            }

            return target;
        }

        #endregion
    }
}
