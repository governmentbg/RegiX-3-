//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.MVRBDSAdapter.MVRBDSServiceReference;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common.DataContracts;
//using System.Xml;
//using System.Globalization;
//using System;
//using System.Xml.Linq;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.WebServiceAdapterService;

//namespace TechnoLogica.RegiX.MVRBDSAdapter.AdapterService
//{
//    public class MVRBDSAdapter : SoapServiceBaseAdapterService, IMVRBDSAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MVRBDSAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MVRMockup/MVRMockupService.svc")
//                           //new ParameterInfo<string>("http://localhost:65528/MVRService.asmx")
//                           {
//                               Key = Constants.WebServiceUrlParameterKeyName,
//                               Description = "Web Service Url",
//                               OwnerAssembly = typeof(MVRBDSAdapter).Assembly
//                           };

//        public CommonSignedResponse<PersonalIdentityInfoRequestType, PersonalIdentityInfoResponseType> GetPersonalIdentity(PersonalIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//            Request request = new Request();
//            request.Header.DateTime = System.DateTime.Now;
//            request.Header.Operation = "0001";
//            //request.Header.UserName = additionalParameters.EIDToken;
//            request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.EIDToken);
//            request.Header.OrganizationUnit = additionalParameters.OrganizationUnit;
//            request.Header.CallerIPAddress = additionalParameters.ClientIPAddress;
//                request.Header.CallContext = additionalParameters.CallContext != null ? additionalParameters.CallContext.ToString() : null;

//            PidAndDocIdType pd = new PidAndDocIdType();
//            pd.DocID = argument.IdentityDocumentNumber;
//            pd.PID = argument.EGN;
//            request.RequestData.Item = pd;

//            MVRBDSServiceReference.IntSyncPortTypeClient client = new IntSyncPortTypeClient("EGovermentWSServiceImplPort", WebServiceUrl.Value);
//            string response = client.Call(request.XmlSerialize());
//            XPathMapper<PersonalIdentityInfoResponseType> mapper = CreatePersonalIdentityInfoMap(accessMatrix);
//            PersonalIdentityInfoResponseType result = new PersonalIdentityInfoResponseType();
//            XmlDocument resultXmlDoc = new XmlDocument();
//            resultXmlDoc.LoadXml(response);
//            mapper.Map(resultXmlDoc, result);

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

//        private XPathMapper<PersonalIdentityInfoResponseType> CreatePersonalIdentityInfoMap(AccessMatrix accessMatrix)
//        {
//            XPathMapper<PersonalIdentityInfoResponseType> mapper = new XPathMapper<PersonalIdentityInfoResponseType>(accessMatrix);

//            mapper.AddPropertyMap(d => d.ReturnInformations.ReturnCode, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
//            mapper.AddPropertyMap(d => d.ReturnInformations.Info, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

//            mapper.AddPropertyMap(d => d.EGN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PIN']");
//            mapper.AddPropertyMap(d => d.PersonNames.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
//            mapper.AddPropertyMap(d => d.PersonNames.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
//            mapper.AddPropertyMap(d => d.PersonNames.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
//            mapper.AddPropertyMap(d => d.PersonNames.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
//            mapper.AddPropertyMap(d => d.PersonNames.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
//            mapper.AddPropertyMap(d => d.PersonNames.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");

//            mapper.AddPropertyMap(d => d.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.IdentityDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IdentityNumber']");

//            mapper.AddFunctionMap(p => p.IssueDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssueDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.IssuerPlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.IssuerPlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Latin']");

//            mapper.AddFunctionMap(d => d.ValidDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='ValidDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });

//            mapper.AddFunctionMap(d => d.BirthDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.BirthPlace.CountryName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.BirthPlace.CountryNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.BirthPlace.CountryCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.BirthPlace.TerritorialUnitName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='TerritorialUnitName']");
//            mapper.AddPropertyMap(d => d.BirthPlace.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='DistrictName']");
//            mapper.AddPropertyMap(d => d.BirthPlace.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='MunicipalityName']");

//            mapper.AddPropertyMap(d => d.GenderName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.GenderNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Gender']/*[local-name()='Latin']");

//            mapper.AddCollectionMap(d => d.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
//            mapper.AddFunctionMap(d => d.NationalityList[0].NationalityCode, node =>
//            {
//                XmlAttribute attr = node.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.NationalityList[0].NationalityName, "./*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.NationalityList[0].NationalityNameLatin, "./*[local-name()='Latin']");

//            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.PermanentAddress.SettlementCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.PermanentAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.PermanentAddress.LocationCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.PermanentAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='BuildingNumber']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Entrance']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Floor']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Apartment']");

//            mapper.AddFunctionMap(d => d.Height, node =>
//            {
//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Height']");
//                if (n != null && !string.IsNullOrWhiteSpace(n.InnerText))
//                {
//                    return double.Parse(n.InnerText, CultureInfo.InvariantCulture.NumberFormat);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.EyesColor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']");

//            mapper.AddFunctionMap<byte[]>(d => d.Picture, node =>
//            {
//                XmlNode blobXML = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Picture']");
//                if (blobXML != null && !string.IsNullOrWhiteSpace(blobXML.InnerText))
//                {
//                    return Convert.FromBase64String(blobXML.InnerText);
//                }
//                return null;
//            });

//            mapper.AddFunctionMap<byte[]>(d => d.IdentitySignature, node =>
//            {
//                XmlNode blobXML = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='IdentitySignature']");
//                if (blobXML != null && !string.IsNullOrWhiteSpace(blobXML.InnerText))
//                {
//                    return Convert.FromBase64String(blobXML.InnerText);
//                }
//                return null;
//            });

//            return mapper;
//        }

//    }
//}