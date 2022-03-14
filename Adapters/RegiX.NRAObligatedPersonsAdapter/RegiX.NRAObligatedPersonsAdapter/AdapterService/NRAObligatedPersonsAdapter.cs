using Oracle.ManagedDataAccess.Client;
using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.WebServiceAdapterService;
namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NRAObligatedPersonsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NRAObligatedPersonsAdapter), typeof(IAdapterService))]
    public class NRAObligatedPersonsAdapter : RestServiceBaseAdapterService, INRAObligatedPersonsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAObligatedPersonsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           //new ParameterInfo<string>("http://172.16.69.13:8078/RegiX.NRAObligatedPersonsAdapterMockup/NRAObligatedPersonsService.svc/GetObligatedPerson")
           new ParameterInfo<string>("https://172.16.69.13:4434/RegiX.NRAObligatedPersonsAdapterMockupSSL/NRAObligatedPersonsService.svc/GetObligatedPerson")
           //new ParameterInfo<string>("https://nraapp01.nra.bg/rs/regix/obligation")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Web Service Url with method name",
               OwnerAssembly = typeof(NRAObligatedPersonsAdapter).Assembly
           };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAObligatedPersonsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ServiceSslCertificateThumbPrint =
               new ParameterInfo<string>("")
               {
                   Key = "ServiceSslCertificateThumbPrint",
                   Description = "Service certificate thumbprint for the underlying restful service",
                   OwnerAssembly = typeof(NRAObligatedPersonsAdapter).Assembly
               };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAObligatedPersonsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ClientSslCertificateThumbPrint =
                new ParameterInfo<string>("")
                {
                    Key = "ClientSslCertificateThumbPrint",
                    Description = "Client certificate thumbprint for the underlying restful service",
                    OwnerAssembly = typeof(NRAObligatedPersonsAdapter).Assembly
                };

        //Parameter for the GetSocialSecurityDataFromDeclrations operation which gets the data from a view.
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAObligatedPersonsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = )(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = RVD122)));User ID=IDS_DATA_NEW;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(NRAObligatedPersonsAdapter).Assembly
            };



        /// <summary>
        /// Проверява connection-a към услугата, като се подават и клиентски и сървърен сертификат, в случай че са конфигурирани за ssl
        /// </summary>
        /// <returns>Дали е успешна връзката с услугата</returns>
        public override string CheckRegisterConnection()
        {
            return CheckConnectionStatus(
                webServiceWithMethodUrl: WebServiceUrl.Value,
                webServiceUrl: WebServiceUrl.Value,
                clientCertThumbPrint: ClientSslCertificateThumbPrint.Value,
                serverCertThumbPrint: ServiceSslCertificateThumbPrint.Value
                ).Result;

        }

        /// <summary>
        /// Извлича резултат от извикването на услугата
        /// </summary>
        /// <param name="serviceClient">Клиент за услугата</param>
        /// <param name="argument">аргумент, сериализиран от входния обект</param>
        /// <param name="id">идентификатор на извикването, за логовете</param>
        /// <param name="aditionalParameters">допълнителните параметри към извикването, за логовете</param>
        /// <returns></returns>
        private async Task<string> GetResponse(HttpClient serviceClient, string argument, Guid id, AdapterAdditionalParameters aditionalParameters)
        {
            XmlDocument doc = new XmlDocument();
            doc.InnerXml = argument;
            HttpResponseMessage response = await serviceClient.PostAsXmlAsync("", doc.DocumentElement);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                LogData(aditionalParameters, new { NotSuccessfulResponse = response, Content = content, Guid = id });
                throw new Exception("StatusCode: " + response.StatusCode + "; Content: " + content);
            }
        }

        /// <summary>
        /// Формиране на заявка към услугата на НАП
        /// </summary>
        /// <param name="argument">Входен обект от операцията на адаптера</param>
        /// <returns>сериализиран обект-заявка за услугата на НАП</returns>
        private string GetRequest(ObligationRequest argument)
        {
            ServiceXMLShemas.ObligationRequest param = new ServiceXMLShemas.ObligationRequest();
            param.Identity = new ServiceXMLShemas.IdentityType();
            if (argument.Identity != null)
            {
                param.Identity.ID = argument.Identity.ID;
                param.Identity.TYPE = (EikTypeType)Enum.Parse(typeof(EikTypeType), argument.Identity.TYPE.ToString());
            }
            param.Threshold = argument.Threshold;
            param.ThresholdSpecified = argument.ThresholdSpecified;
            return param.XmlSerialize();
        }


        public CommonSignedResponse<ObligationRequest, ObligationResponse> GetObligatedPersons(ObligationRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                var serviceClient = GetClient(
                    webServiceUrl: WebServiceUrl.Value,
                    clientCertThumbPrint: ClientSslCertificateThumbPrint.Value,
                    serverCertThumbPrint: ServiceSslCertificateThumbPrint.Value);

                string request = GetRequest(argument);
                string responseString = GetResponse(serviceClient, request, id, aditionalParameters).Result;

                ObligationResponse response = new ObligationResponse();
                try
                {
                    XElement resultXmlElement = XDocument.Parse(responseString).Root;
                    XPathMapper<ObligationResponse> responseMapper = CreateObligatedPersonsMapper(accessMatrix, DateTime.Now);
                    responseMapper.Map(resultXmlElement, response);
                }
                catch (Exception ex)
                {
                    LogError(aditionalParameters, ex, new { Request = request, Response = responseString });
                    response.Status = new StatusType();
                    response.Status.Code = 1;
                    response.Status.Message = "Услугата на НАП връща невалиден XML";
                }

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        response,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static XPathMapper<ObligationResponse> CreateObligatedPersonsMapper(AccessMatrix accessMatrix, DateTime reportDate)
        {
            XPathMapper<ObligationResponse> mapper =
                new XPathMapper<ObligationResponse>(accessMatrix);

            mapper.AddConstantMap(p => p.ReportDate, reportDate);
            mapper.AddFunctionMap<string>(p => p.Identity.ID, node =>
            {
                var identityNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Identity']");

                if (identityNode != null)
                {
                    XmlNode idNode = identityNode.SelectSingleNode("./*[local-name()='ID']");
                    if (idNode != null)
                    {
                        return idNode.InnerText;
                    }
                }
                return null;
            });

            mapper.AddFunctionMap<EikTypeType>(p => p.Identity.TYPE, node =>
            {
                var identityNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Identity']");

                if (identityNode != null)
                {
                    XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='TYPE']");
                    if (typeNode != null)
                    {
                        return (EikTypeType)Enum.Parse(typeof(EikTypeType), typeNode.InnerText);
                    }
                }
                return null;
            });

            mapper.AddFunctionMap<ObligationStatusType>(p => p.ObligationStatus, node =>
            {
                var obligationStatusNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='ObligationStatus']");

                if (obligationStatusNode != null)
                {
                    return (ObligationStatusType)Enum.Parse(typeof(ObligationStatusType), obligationStatusNode.InnerText);
                }
                return null;
            });

            mapper.AddFunctionMap<int>(p => p.Status.Code, node =>
            {
                var statusNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Status']");

                if (statusNode != null)
                {
                    XmlNode codeNode = statusNode.SelectSingleNode("./*[local-name()='Code']");
                    if (codeNode != null)
                    {
                        return int.Parse(codeNode.InnerText);
                    }
                }
                return null;
            });

            mapper.AddFunctionMap<string>(p => p.Status.Message, node =>
            {
                var statusNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Status']");

                if (statusNode != null)
                {
                    XmlNode messageNode = statusNode.SelectSingleNode("./*[local-name()='Message']");
                    if (messageNode != null)
                    {
                        return messageNode.InnerText;
                    }
                }
                return null;
            });

            mapper.AddFunctionMap<uint>(p => p.Threshold, node =>
            {
                var thresholdNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Threshold']");

                if (thresholdNode != null && !String.IsNullOrEmpty(thresholdNode.InnerText))
                {
                    return uint.Parse(thresholdNode.InnerText);
                }
                return null;
            });

            mapper.AddFunctionMap<string>(p => p.Name, node =>
            {
                var nameNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Names']");

                if (nameNode != null && !String.IsNullOrEmpty(nameNode.InnerText))
                {
                    return nameNode.InnerText;
                }
                return null;
            });

            return mapper;
        }


        public CommonSignedResponse<SocialSecurityDataFromDeclarationRequestType, GetSocialSecurityDataFromDeclarationsResponse> GetSocialSecurityDataFromDeclarations(SocialSecurityDataFromDeclarationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"select * from vw_ins_H8	
                           where e_report_1.set_params_InsH8(
                                    :ipBulstat,  -- ЕИК на осигурител
                                    :ipStartMonth, -- от месец
                                    :ipStartYear, -- от година
                                    :ipEndMonth, -- до месец
                                    :ipEndYear, -- до година
                                    :ip_rows, -- 
                                    :ip_pin, -- идентификатор на осигуреното лице
                                    :ip_pin_type -- тип на идентификатора на осигуреното лице
                                    ) = 1";

                int fromMonth = Conversions.GMonthToInt.Invoke(argument.MonthFrom);
                int fromYear = Conversions.GYearToInt(argument.YearFrom);

                int toMonth = Conversions.GMonthToInt.Invoke(argument.MonthTo);
                int toYear = Conversions.GYearToInt(argument.YearTo);


                //PARAMETERS VALIDATION
                //Задължително е попълването на един от двата идентификатора (идентификатор на осигуреното лице или на осигурителя). 
                ValidateAtLeastOneIdentifierIsFilled(argument);
                //Попълнен ли е тип на идентификатора, при попълнен PersonIdentifierType
                IsIdentifierTypeFilled(argument);

                /*Трябва да разберем за какъв тип лице се изпраща заявката, за да можем 
                 правилно да валидираме максималния допустим период - за осигурени лица не по-голям от една година, 
                 а при избор идентификатор на осигурител – период не по - голям от един месец.
                 Този параметър се подава на метода за валидация на период*/
                string insuredPersonType = DetermineInsuredPersonType(argument.InsurerIdentificator, argument.PersonIdentifier);

                var ipBulstat = new OracleParameter("ipBulstat", OracleDbType.Varchar2, ParameterDirection.Input);
                ipBulstat.Value = argument.GetValueOrNull(x => x.InsurerIdentificator);
                command.Parameters.Add(ipBulstat);
                //Валидираме периода.
                if (ValidateInputPeriod(insuredPersonType, fromMonth, fromYear, toMonth, toYear))
                {
                    var ipStartMonth = new OracleParameter("ipStartMonth", OracleDbType.Varchar2, ParameterDirection.Input);
                    ipStartMonth.Value = fromMonth.ToString().PadLeft(2, '0'); //за да може да се подаде напр. 02, вместо 2
                    command.Parameters.Add(ipStartMonth);

                    var ipStartYear = new OracleParameter("ipStartYear", OracleDbType.Varchar2, ParameterDirection.Input);
                    ipStartYear.Value = fromYear.ToString().PadLeft(2, '0');//за да може да се подаде напр. 02, вместо 2
                    command.Parameters.Add(ipStartYear);

                    var ipEndMonth = new OracleParameter("ipEndMonth", OracleDbType.Varchar2, ParameterDirection.Input);
                    ipEndMonth.Value = toMonth.ToString();
                    command.Parameters.Add(ipEndMonth);

                    var ipEndYear = new OracleParameter("ipEndYear", OracleDbType.Varchar2, ParameterDirection.Input);
                    ipEndYear.Value = toYear.ToString();
                    command.Parameters.Add(ipEndYear);

                }

                var ip_rows = new OracleParameter("ip_rows", OracleDbType.Decimal, ParameterDirection.Input);
                ip_rows.Value = 100000; // TODO: hardcoded value
                command.Parameters.Add(ip_rows);

                var ip_pin = new OracleParameter("ip_pin", OracleDbType.Varchar2, ParameterDirection.Input);
                ip_pin.Value = argument.GetValueOrNull(x => x.PersonIdentifier);
                command.Parameters.Add(ip_pin);

                var ip_pin_type = new OracleParameter("ip_pin_type", OracleDbType.Varchar2, ParameterDirection.Input);
                ip_pin_type.Value = GetIdentifierTypeCodeForRequest(argument.PersonIdentifierType);
                command.Parameters.Add(ip_pin_type);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);

                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<GetSocialSecurityDataFromDeclarationsResponse> mapper = CreateSocialSecurityDataMapper(accessMatrix, argument);
                GetSocialSecurityDataFromDeclarationsResponse result = new GetSocialSecurityDataFromDeclarationsResponse();

                mapper.Map(ds, result);

                foreach (var item in result.SocialSecurityDataFromDeclarations)
                {
                    if (argument.PersonIdentifierTypeSpecified)
                    {
                        item.RequestPersonIdentifierTypeSpecified = true;
                    }
                }

                //Sorting the result 
                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    aditionalParameters
                );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private DataSetMapper<GetSocialSecurityDataFromDeclarationsResponse> CreateSocialSecurityDataMapper(AccessMatrix accessMatrix, SocialSecurityDataFromDeclarationRequestType request)
        {
            int fromMonth = Conversions.GMonthToInt.Invoke(request.MonthFrom);
            int fromYear = Conversions.GYearToInt(request.YearFrom);

            int toMonth = Conversions.GMonthToInt.Invoke(request.MonthTo);
            int toYear = Conversions.GYearToInt(request.YearTo);
            DataSetMapper<GetSocialSecurityDataFromDeclarationsResponse> mapper = new DataSetMapper<GetSocialSecurityDataFromDeclarationsResponse>(accessMatrix);
            mapper.AddDataSetMap((r) => r.SocialSecurityDataFromDeclarations, (d) => d.Tables[0].Rows);
            //Data coming directly from the request. 
            mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestInsurerIdentificator, request.InsurerIdentificator);
            mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestMonthFrom, fromMonth);
            mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestMonthTo, toMonth);
            mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestYearFrom, fromYear);
            mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestYearTo, toYear);
            mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestPersonIdentifier, request.PersonIdentifier);

            var requestPersonIdentifierType = /*request.PersonIdentifierTypeSpecified ?*/ Enum.Parse(typeof(PersonIdentifierTypeEnumeration), request.PersonIdentifierType.ToString()) /*: default(PersonIdentifierTypeEnum)*/;
            mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestPersonIdentifierType, requestPersonIdentifierType);
            //mapper.AddConstantMap((r) => r.SocialSecurityDataFromDeclarations[0].RequestPersonIdentifierTypeSpecified, request.PersonIdentifierTypeSpecified);
            mapper.AddFunctionMap<GetSocialSecurityDataFromDeclarationsResponse, bool>(
                            (r) => r.SocialSecurityDataFromDeclarations[0].RequestPersonIdentifierTypeSpecified,
                            (d) => request.PersonIdentifierTypeSpecified
                        );

            //Data from the NRA view
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].DeclarationType, "DECL_TYPE");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].PersonIdentifier, "CR51_IND_PIN");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].PersonLastNameAndInitials, "IND_NAME");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].InsurerIdentifier, "BULSTAT");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].InsurerName, "BUS_NAME");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].InsurerAdress, "BUS_ADDRESS");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].Month, "CA01_MONTH");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].Year, "CA01_YEAR");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].PersonType, "CA01_INSURED_TYPE");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].TotalInsuredDays, "CA01_INSURED_TOTAL_DAYS_2");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].DaysWorked, "CA01_INSURED_WORK_DAYS");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].LawEstablishedWorkHours, "CA01_INSURED_TOTAL_DAYS_3");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].DailyAgreedWorkHours, "CA01_INSURED_TOTAL_DAYS_4");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].SocialSecurityIncome, "INS_INCOME");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].GVRSFundFlag, "CA01_GRW");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].CorrectionCode, "CA01_CORR_CODE");
            mapper.AddDataColumnMap((r) => r.SocialSecurityDataFromDeclarations[0].SubmissionDate, "CA01_SEND_DATE", (o) => string.IsNullOrEmpty(o.ToString()) ? new DateTime() : DateTime.ParseExact(o.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture.DateTimeFormat));


            return mapper;
        }

        private object GetIdentifierTypeCodeForRequest(object enumObj)
        {
            if (enumObj == DBNull.Value || enumObj == null)
            {
                return DBNull.Value;
            }

            string enumValue = enumObj.ToString();

            //if (enumValue == "NOT_SPECIFIED")
            //{
            //    return DBNull.Value;
            //}
            const string _EgnCode = "03601";
            const string _LNChCode = "03602";
            const string _NRASystemNo = "03603";
            const string _EIK_BULSTAT = "03604";
            switch (enumValue)
            {
                case "EGN":
                    return _EgnCode;
                case "LNCh":
                    return _LNChCode;
                case "NRASystemNo":
                    return _NRASystemNo;
                case "EIK_BULSTAT":
                    return _EIK_BULSTAT;
                case "NOT_SPECIFIED":
                    return DBNull.Value;

                default:
                    return enumValue;
            }

        }

        /*При избор за извеждане на информация за осигурени лица не следва да се допуска избор на период по-голям от една година, 
        а при избор идентификатор на осигурител – период не по-голям от един месец. */
        /*При избор едновременно и на двата идентификатора (осигурено лице и осигурител) - също 1 година. */
        private bool ValidateInputPeriod(string insuredPersonType, int monthFrom, int yearFrom, int monthTo, int yearTo)
        {
            var firstDate = new DateTime(yearFrom, monthFrom, 1);
            var secondDate = new DateTime(yearTo, monthTo, 1);
            //Валидираме периода
            if (firstDate > secondDate)
            {
                throw new Exception("Моля, въведете валиден времеви период!");
            }
            //Попълнен е идентификатор на осигурено лице, т.е период не по-голям от 1 година
            if (insuredPersonType == "person" || insuredPersonType == "both")
            {
                var y = firstDate.AddMonths(12);
                if (y < secondDate)
                {
                    throw new Exception("Моля, въведете период не по-голям от 1 година");
                }
                else
                {
                    return true;
                }

            }
            //Попълнен е идентификатор на осигурител, т.е период не по-голям от 1 месец 
            else if (insuredPersonType == "company")
            {
                if (firstDate.AddMonths(1) > secondDate)
                {
                    throw new Exception("Моля, въведете период не по-голям от 1 месец");
                }
                else
                {
                    return true;
                }
            }
            throw new Exception("Грешен тип на осигурено лице/осигурител");
        }

        private string DetermineInsuredPersonType(string insurerIdentificator, string personIdentifier)
        {
            const string _both = "both";
            const string _person = "person";
            const string _company = "company";
            if (!string.IsNullOrEmpty(insurerIdentificator) && !string.IsNullOrEmpty(personIdentifier))
            {
                return _both;
            }
            else if (!string.IsNullOrEmpty(insurerIdentificator))
            {
                return _company;
            }
            else
            {
                return _person;
            }
        }

        private void ValidateAtLeastOneIdentifierIsFilled(SocialSecurityDataFromDeclarationRequestType argument)
        {
            //Валидираме, че поне единия идентификатор е попълнен - идентификатор на осигурител, или на осигуряващ.
            //Ако и двете са празни - хвърляме грешка.
            if (string.IsNullOrEmpty(argument.PersonIdentifier) && string.IsNullOrEmpty(argument.InsurerIdentificator))
            {
                throw new Exception("Задължително е попълването на един от двата идентификатора (Идентификатор на осигуреното лице или на осигурителя)!");
            }
        }

        //Дали е попълнен тип на идентификатор, в случай, че полето Идентификатор за осигуреното физическо лице е попълнено. 
        private void IsIdentifierTypeFilled(SocialSecurityDataFromDeclarationRequestType argument)
        {
            if (!string.IsNullOrEmpty(argument.PersonIdentifier))
            {
                if (argument.PersonIdentifierType == PersonIdentifierTypeEnumeration.NOT_SPECIFIED)
                {
                    throw new Exception("Задължително е попълването на тип на идентификатор (При попълнен Идентификатор за осигуреното физическо лице)!");

                }
            }
        }

    }
}
