//using System;
//using System.ComponentModel.Composition;
//using System.Globalization;
//using System.Xml;
//using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.MVRERChAdapter.MVRERChServiceReference;
//using TechnoLogica.RegiX.WebServiceAdapterService;

//namespace TechnoLogica.RegiX.MVRERChAdapter.AdapterService
//{
//    public class MVRERChAdapter : SoapServiceBaseAdapterService, IMVRERChAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MVRERChAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MVRMockup/MVRMockupService.svc")
//                           {
//                               Key = Constants.WebServiceUrlParameterKeyName,
//                               Description = "Web Service Url",
//                               OwnerAssembly = typeof(MVRERChAdapter).Assembly
//                           };

//        public CommonSignedResponse<ForeignIdentityInfoRequestType, ForeignIdentityInfoResponseType> GetForeignIdentity(ForeignIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//            Request request = new Request();
//            request.Header.DateTime = System.DateTime.Now;
//            request.Header.Operation = "0002";
//            //request.Header.UserName = additionalParameters.EIDToken;
//            request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.EIDToken);
//            request.Header.OrganizationUnit = additionalParameters.OrganizationUnit;
//            request.Header.CallerIPAddress = additionalParameters.ClientIPAddress;
//                request.Header.CallContext = additionalParameters.CallContext != null ?  additionalParameters.CallContext.ToString() : null;

//            RequestDataTypeFC fc = new RequestDataTypeFC();
//            fc.Item = argument.Identifier;
//            switch (argument.IdentifierType)
//            {
//                case IdentifierType.EGN:
//                    fc.ItemElementName = ItemChoiceType.PID;
//                    break;
//                case IdentifierType.LNCh:
//                    fc.ItemElementName = ItemChoiceType.ID;
//                    break;
//            }

//            request.RequestData.Item = fc;
//            MVRERChServiceReference.IntSyncPortTypeClient client = new MVRERChServiceReference.IntSyncPortTypeClient("EGovermentWSServiceImplPort", WebServiceUrl.Value);
//            string response = client.Call(request.XmlSerialize());
//            XPathMapper<ForeignIdentityInfoResponseType> mapper = CreateForeignIdentityInfoMap(accessMatrix);
//            ForeignIdentityInfoResponseType result = new ForeignIdentityInfoResponseType();
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

//        private XPathMapper<ForeignIdentityInfoResponseType> CreateForeignIdentityInfoMap(AccessMatrix accessMatrix)
//        {
//            XPathMapper<ForeignIdentityInfoResponseType> mapper = new XPathMapper<ForeignIdentityInfoResponseType>(accessMatrix);

//            mapper.AddPropertyMap(d => d.ReturnInformations.ReturnCode, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
//            mapper.AddPropertyMap(d => d.ReturnInformations.Info, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

//            mapper.AddPropertyMap(d => d.EGN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PIN']");
//            mapper.AddPropertyMap(d => d.LNCh, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PN']");
//            mapper.AddPropertyMap(d => d.PersonNames.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
//            mapper.AddPropertyMap(d => d.PersonNames.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
//            mapper.AddPropertyMap(d => d.PersonNames.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
//            mapper.AddPropertyMap(d => d.PersonNames.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
//            mapper.AddPropertyMap(d => d.PersonNames.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
//            mapper.AddPropertyMap(d => d.PersonNames.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");

//            // от МВР казаха, че датата на раждане на чужденец е стринг (може да е попълнена само година например)
//            //mapper.AddFunctionMap(d => d.BirthDate, node =>
//            //{
//            //    XmlNode dateNode =
//            //           node.SelectSingleNode(
//            //               "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");
//            //    if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//            //    {
//            //        return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//            //    }
//            //    return null;
//            //});

//            mapper.AddPropertyMap(d => d.BirthDate, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");
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

//            mapper.AddCollectionMap(d => d.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
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

//            mapper.AddCollectionMap(d => d.Statuses, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Statuses']");
//            mapper.AddPropertyMap(d => d.Statuses[0].StatusName, "./*[local-name()='Status']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Statuses[0].StatusNameLatin, "./*[local-name()='Status']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.Statuses[0].DateFrom, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode("./*[local-name()='DateFrom']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });
//            mapper.AddFunctionMap(d => d.Statuses[0].DateTo, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode("./*[local-name()='DateTo']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });
//            //permanent address
//            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='District']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='District']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Municipality']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.PermanentAddress.SettlementCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.PermanentAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.PermanentAddress.LocationCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.PermanentAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='BuildingNumber']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Entrance']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Floor']");
//            mapper.AddPropertyMap(d => d.PermanentAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Apartment']");

//            //temporary address
//            mapper.AddPropertyMap(d => d.TemporaryAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='District']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='District']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Municipality']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.TemporaryAddress.SettlementCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.TemporaryAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.TemporaryAddress.LocationCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.TemporaryAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='BuildingNumber']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Entrance']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Floor']");
//            mapper.AddPropertyMap(d => d.TemporaryAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Apartment']");

//            //abroad address
//            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.NationalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.NationalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']/*[local-name()='Latin']");
//            mapper.AddFunctionMap(d => d.PermanentAddressAbroad.NationalityCode, node =>
//            {

//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']");
//                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
//                XmlAttribute attr = n.Attributes["code"];
//                if (attr != null)
//                {
//                    return attr.Value;
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Settlement']");
//            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.Street, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Street']");

//            mapper.AddPropertyMap(d => d.IdentityDocument.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.IdentityDocument.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='DocumentType']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.IdentityDocument.IdentityDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IdentityNumber']");
//            mapper.AddFunctionMap(p => p.IdentityDocument.IssueDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssueDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.IdentityDocument.IssuePlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.IdentityDocument.IssuePlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.IdentityDocument.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.IdentityDocument.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuerName']/*[local-name()='Latin']");

//            mapper.AddFunctionMap(d => d.IdentityDocument.ValidDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='ValidDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });

//            //travel document
//            mapper.AddPropertyMap(d => d.TravelDocument.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.TravelDocument.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='DocumentType']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.TravelDocument.TravelDocumentSeries, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='TravelDocumentSeries']");
//            mapper.AddPropertyMap(d => d.TravelDocument.TravelDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='TravelDocumentNumber']");
//            mapper.AddFunctionMap(p => p.TravelDocument.IssueDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssueDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.TravelDocument.IssuePlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.TravelDocument.IssuePlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.TravelDocument.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.TravelDocument.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuerName']/*[local-name()='Latin']");

//            mapper.AddFunctionMap(d => d.TravelDocument.ValidDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='ValidDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });

//            mapper.AddFunctionMap(d => d.Height, node =>
//            {
//                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Height']");
//                if (n != null && !string.IsNullOrWhiteSpace(n.InnerText))
//                {
//                    return double.Parse(n.InnerText, CultureInfo.InvariantCulture.NumberFormat);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.EyesColor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.EyesColorLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']/*[local-name()='Latin']");

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