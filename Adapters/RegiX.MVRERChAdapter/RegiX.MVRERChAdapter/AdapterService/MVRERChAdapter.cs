using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Xml;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.WebServiceAdapterService;

namespace TechnoLogica.RegiX.MVRERChAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MVRERChAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MVRERChAdapter), typeof(IAdapterService))]
    public class MVRERChAdapter : SoapServiceBaseAdapterService, IMVRERChAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRERChAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MVRMockup/MVRMockupService.svc")
                           {
                               Key = Constants.WebServiceUrlParameterKeyName,
                               Description = "Web Service Url",
                               OwnerAssembly = typeof(MVRERChAdapter).Assembly
                           };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRERChAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrlV2 =
                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MVRMockup/MVRMockupService.svc")
                           {
                               Key = "WebServiceUrlV2",
                               Description = "Web Service Url V2",
                               OwnerAssembly = typeof(MVRERChAdapter).Assembly
                           };

        public CommonSignedResponse<ForeignIdentityInfoRequestType, ForeignIdentityInfoResponseType> GetForeignIdentity(ForeignIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });

            try
            {
                //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient	
                //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception	
                // and not allow the operation to continue.	
                try
                {
                    ValidateCallContext(additionalParameters);
                }
                catch (ArgumentException ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                    throw ex;
                }
                #region Request
                Request request = new Request();
                request.Header.DateTime = System.DateTime.Now;
                request.Header.Operation = "0002";

                //request.Header.UserName = additionalParameters.EIDToken;
                if (!string.IsNullOrEmpty(additionalParameters.EIDToken))
                {
                    request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.EIDToken);
                }
                else
                {
                    if (additionalParameters.CallContext != null)
                    {
                        if (!string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeIdentifier))
                        {
                            request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.CallContext.EmployeeIdentifier);
                        }
                        else
                        {
                            request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.CallContext.ResponsiblePersonIdentifier);
                        }
                    }
                }

                request.Header.OrganizationUnit = additionalParameters.OrganizationUnit;
                request.Header.CallerIPAddress = additionalParameters.ClientIPAddress;
                request.Header.CallContext = additionalParameters.CallContext != null ? additionalParameters.CallContext.ToString() : null;

                RequestDataTypeFC fc = new RequestDataTypeFC();
                fc.Item = argument.Identifier;
                switch (argument.IdentifierType)
                {
                    case IdentifierType.EGN:
                        fc.ItemElementName = ItemChoiceType.PID;
                        break;
                    case IdentifierType.LNCh:
                        fc.ItemElementName = ItemChoiceType.ID;
                        break;
                }

                request.RequestData.Item = fc;
                #endregion

                MVRERChServiceReference.IntSyncPortTypeClient client = new MVRERChServiceReference.IntSyncPortTypeClient("EGovermentWSServiceImplPort", WebServiceUrl.Value);
                string response = client.Call(request.XmlSerialize());

                #region Result

                ForeignIdentityInfoResponseType result = new ForeignIdentityInfoResponseType();
                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<ForeignIdentityInfoResponseType> mapper = CreateForeignIdentityInfoMap(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    ForeignIdentityInfoResponseType tempresult = new ForeignIdentityInfoResponseType();
                    tempresult.ReturnInformations = new ReturnInformation();
                    tempresult.ReturnInformations.ReturnCode = "1111";
                    tempresult.ReturnInformations.Info = response;
                    ObjectMapper<ForeignIdentityInfoResponseType, ForeignIdentityInfoResponseType> selfmapper = CreateSelfMapper(accessMatrix);
                    selfmapper.Map(tempresult, result);
                }

                #endregion

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
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
        }
        private static ObjectMapper<ForeignIdentityInfoResponseType, ForeignIdentityInfoResponseType> CreateSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<ForeignIdentityInfoResponseType, ForeignIdentityInfoResponseType> mapper = new ObjectMapper<ForeignIdentityInfoResponseType, ForeignIdentityInfoResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.ReturnInformations, (c) => c.ReturnInformations);
            mapper.AddPropertyMap((o) => o.ReturnInformations.ReturnCode, (c) => c.ReturnInformations.ReturnCode);
            mapper.AddPropertyMap((o) => o.ReturnInformations.Info, (c) => c.ReturnInformations.Info);

            return mapper;
        }
        private XPathMapper<ForeignIdentityInfoResponseType> CreateForeignIdentityInfoMap(AccessMatrix accessMatrix)
        {
            XPathMapper<ForeignIdentityInfoResponseType> mapper = new XPathMapper<ForeignIdentityInfoResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.ReturnInformations.ReturnCode, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.ReturnInformations.Info, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

            mapper.AddPropertyMap(d => d.EGN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.LNCh, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");

            // от МВР казаха, че датата на раждане на чужденец е стринг (може да е попълнена само година например)
            //mapper.AddFunctionMap(d => d.BirthDate, node =>
            //{
            //    XmlNode dateNode =
            //           node.SelectSingleNode(
            //               "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");
            //    if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
            //    {
            //        return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
            //    }
            //    return null;
            //});

            mapper.AddPropertyMap(d => d.BirthDate, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");
            mapper.AddPropertyMap(d => d.BirthPlace.CountryName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.BirthPlace.CountryNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.BirthPlace.CountryCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.BirthPlace.TerritorialUnitName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='TerritorialUnitName']");
            mapper.AddPropertyMap(d => d.BirthPlace.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='DistrictName']");
            mapper.AddPropertyMap(d => d.BirthPlace.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='MunicipalityName']");

            mapper.AddPropertyMap(d => d.GenderName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.GenderNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Gender']/*[local-name()='Latin']");

            mapper.AddCollectionMap(d => d.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
            mapper.AddFunctionMap(d => d.NationalityList[0].NationalityCode, node =>
            {
                XmlAttribute attr = node.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.NationalityList[0].NationalityName, "./*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.NationalityList[0].NationalityNameLatin, "./*[local-name()='Latin']");

            mapper.AddCollectionMap(d => d.Statuses, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Statuses']");
            mapper.AddPropertyMap(d => d.Statuses[0].StatusName, "./*[local-name()='Status']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Statuses[0].StatusNameLatin, "./*[local-name()='Status']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.Statuses[0].DateFrom, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='DateFrom']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddFunctionMap(d => d.Statuses[0].DateTo, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='DateTo']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            //permanent address
            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='District']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='District']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Municipality']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.SettlementCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.PermanentAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.LocationCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.PermanentAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='BuildingNumber']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Entrance']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Floor']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Apartment']");

            //temporary address
            mapper.AddPropertyMap(d => d.TemporaryAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='District']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='District']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Municipality']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.TemporaryAddress.SettlementCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.TemporaryAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.TemporaryAddress.LocationCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.TemporaryAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='BuildingNumber']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Entrance']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Floor']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Apartment']");

            //abroad address
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.NationalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.NationalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddressAbroad.NationalityCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Settlement']");
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.Street, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Street']");

            mapper.AddPropertyMap(d => d.IdentityDocument.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IdentityDocument.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IdentityDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IdentityNumber']");
            mapper.AddFunctionMap(p => p.IdentityDocument.IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuePlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuePlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuerName']/*[local-name()='Latin']");

            mapper.AddFunctionMap(d => d.IdentityDocument.ValidDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='ValidDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            //travel document
            mapper.AddPropertyMap(d => d.TravelDocument.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TravelDocument.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TravelDocument.TravelDocumentSeries, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='TravelDocumentSeries']");
            mapper.AddPropertyMap(d => d.TravelDocument.TravelDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='TravelDocumentNumber']");
            mapper.AddFunctionMap(p => p.TravelDocument.IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.TravelDocument.IssuePlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TravelDocument.IssuePlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TravelDocument.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TravelDocument.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuerName']/*[local-name()='Latin']");

            mapper.AddFunctionMap(d => d.TravelDocument.ValidDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='ValidDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(d => d.Height, node =>
            {
                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Height']");
                if (n != null && !string.IsNullOrWhiteSpace(n.InnerText))
                {
                    return double.Parse(n.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.EyesColor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.EyesColorLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']/*[local-name()='Latin']");

            mapper.AddFunctionMap<byte[]>(d => d.Picture, node =>
            {
                XmlNode blobXML = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Picture']");
                if (blobXML != null && !string.IsNullOrWhiteSpace(blobXML.InnerText))
                {
                    return Convert.FromBase64String(blobXML.InnerText);
                }
                return null;
            });

            mapper.AddFunctionMap<byte[]>(d => d.IdentitySignature, node =>
            {
                XmlNode blobXML = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='IdentitySignature']");
                if (blobXML != null && !string.IsNullOrWhiteSpace(blobXML.InnerText))
                {
                    return Convert.FromBase64String(blobXML.InnerText);
                }
                return null;
            });

            return mapper;
        }

        public CommonSignedResponse<MVRERChAdapterV2.ForeignIdentityInfoRequestType, MVRERChAdapterV2.ForeignIdentityInfoResponseType> GetForeignIdentityV2(MVRERChAdapterV2.ForeignIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient	
                //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception	
                // and not allow the operation to continue.	
                try
                {
                    ValidateCallContext(additionalParameters);
                }
                catch (ArgumentException ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                    throw ex;
                }
                #region Request
                MVRERChAdapterV2.Request request = new MVRERChAdapterV2.Request();
                request.Header.DateTime = System.DateTime.Now;
                request.Header.Operation = "0002";

                //request.Header.UserName = additionalParameters.EIDToken;
                if (!string.IsNullOrEmpty(additionalParameters.EIDToken))
                {
                    request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.EIDToken);
                }
                else
                {
                    if (additionalParameters.CallContext != null)
                    {
                        if (!string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeIdentifier))
                        {
                            request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.CallContext.EmployeeIdentifier);
                        }
                        else
                        {
                            request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.CallContext.ResponsiblePersonIdentifier);
                        }
                    }
                }

                request.Header.OrganizationUnit = additionalParameters.OrganizationUnit;
                request.Header.CallerIPAddress = additionalParameters.ClientIPAddress;
                request.Header.CallContext = additionalParameters.CallContext != null ? additionalParameters.CallContext.ToString() : null;

                //BiometricFlag - дали консуматорът има достъп до подпис и снимка
                var am = accessMatrix.AMEntry.AccessMatrix.Keys;
                bool hasPicture = false;
                bool hasSignature = false;
                foreach (var key in am)
                {

                    if (key == "Picture" && accessMatrix.AMEntry.AccessMatrix[key].HasAccess)
                    {
                        hasPicture = true;
                    }
                    if (key == "IdentitySignature" && accessMatrix.AMEntry.AccessMatrix[key].HasAccess)
                    {
                        hasSignature = true;
                    }
                }
                request.Header.BiometricDataFlag = hasPicture && hasSignature;

                MVRERChAdapterV2.RequestDataTypeFC fc = new MVRERChAdapterV2.RequestDataTypeFC();
                fc.Item = argument.Identifier;
                switch (argument.IdentifierType)
                {
                    case MVRERChAdapterV2.IdentifierType.EGN:
                        fc.ItemElementName = MVRERChAdapterV2.ItemChoiceType.PID;
                        break;
                    case MVRERChAdapterV2.IdentifierType.LNCh:
                        fc.ItemElementName = MVRERChAdapterV2.ItemChoiceType.ID;
                        break;
                }

                request.RequestData.Item = fc;
                #endregion

                var client = new MVRERChv2ServiceReference.IntSyncPortTypeClient("genWSImplPort", WebServiceUrlV2.Value);
                string response = client.Call(request.XmlSerialize());
                #region Result

                MVRERChAdapterV2.ForeignIdentityInfoResponseType result = new MVRERChAdapterV2.ForeignIdentityInfoResponseType();
                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType> mapper = CreateForeignIdentityInfoMapV2(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch(Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    MVRERChAdapterV2.ForeignIdentityInfoResponseType tempresult = new MVRERChAdapterV2.ForeignIdentityInfoResponseType();
                    tempresult.ReturnInformations = new MVRERChAdapterV2.ReturnInformation();
                    tempresult.ReturnInformations.ReturnCode = "1111";
                    tempresult.ReturnInformations.Info = response;
                    ObjectMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType, MVRERChAdapterV2.ForeignIdentityInfoResponseType> selfmapper = CreateSelfMapperV2(accessMatrix);
                    selfmapper.Map(tempresult, result);
                }

                #endregion

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
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
        }
        private static ObjectMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType, MVRERChAdapterV2.ForeignIdentityInfoResponseType> CreateSelfMapperV2(AccessMatrix accessMatrix)
        {
            ObjectMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType, MVRERChAdapterV2.ForeignIdentityInfoResponseType> mapper = new ObjectMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType, MVRERChAdapterV2.ForeignIdentityInfoResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.ReturnInformations, (c) => c.ReturnInformations);
            mapper.AddPropertyMap((o) => o.ReturnInformations.ReturnCode, (c) => c.ReturnInformations.ReturnCode);
            mapper.AddPropertyMap((o) => o.ReturnInformations.Info, (c) => c.ReturnInformations.Info);

            return mapper;
        }
        private XPathMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType> CreateForeignIdentityInfoMapV2(AccessMatrix accessMatrix)
        {
            XPathMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType> mapper = new XPathMapper<MVRERChAdapterV2.ForeignIdentityInfoResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.ReturnInformations.ReturnCode, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.ReturnInformations.Info, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

            mapper.AddPropertyMap(d => d.EGN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.LNCh, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");

            // от МВР казаха, че датата на раждане на чужденец е стринг (може да е попълнена само година например)
            //mapper.AddFunctionMap(d => d.BirthDate, node =>
            //{
            //    XmlNode dateNode =
            //           node.SelectSingleNode(
            //               "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");
            //    if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
            //    {
            //        return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
            //    }
            //    return null;
            //});
            
            mapper.AddPropertyMap(d => d.BirthDate, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");

            mapper.AddFunctionMap(d => d.DeathDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DeathDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.BirthPlace.CountryName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.BirthPlace.CountryNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.BirthPlace.CountryCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='Country']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.BirthPlace.TerritorialUnitName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='TerritorialUnitName']");
            mapper.AddPropertyMap(d => d.BirthPlace.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='DistrictName']");
            mapper.AddPropertyMap(d => d.BirthPlace.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='BirthPlace']/*[local-name()='MunicipalityName']");

            mapper.AddPropertyMap(d => d.GenderName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.GenderNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Gender']/*[local-name()='Latin']");

            mapper.AddCollectionMap(d => d.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
            mapper.AddFunctionMap(d => d.NationalityList[0].NationalityCode, node =>
            {
                XmlAttribute attr = node.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.NationalityList[0].NationalityName, "./*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.NationalityList[0].NationalityNameLatin, "./*[local-name()='Latin']");

            mapper.AddCollectionMap(d => d.Statuses, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']");
            mapper.AddPropertyMap(d => d.Statuses[0].Status.StatusName, "./*[local-name()='Status']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Statuses[0].Status.StatusNameLatin, "./*[local-name()='Status']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.Statuses[0].Status.DateFrom, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='DateFrom']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddFunctionMap(d => d.Statuses[0].Status.DateTo, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='DateTo']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            //new
            mapper.AddPropertyMap(d => d.Employer, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='Employer']");
            mapper.AddPropertyMap(d => d.Position, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='Position']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PositionLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='Position']/*[local-name()='Latin']");

            mapper.AddPropertyMap(d => d.Statuses[0].StatusLawReason.Status, "./*[local-name()='LegalBasis']/*[local-name()='Cyrillic']");
            //"./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='LegalBasis']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Statuses[0].StatusLawReason.StatusLatin, "./*[local-name()='LegalBasis']/*[local-name()='Latin']");
                //"./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='LegalBasis']/*[local-name()='Latin']");

            //mapper.AddPropertyMap(d => d.StatusLawReason.Code, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='LegalBasis']/*[@code]");
            mapper.AddFunctionMap(d => d.Statuses[0].StatusLawReason.Code, node =>
            {
                XmlNode n = node.SelectSingleNode("./*[local-name()='LegalBasis']");
                //("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='LegalBasis']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddFunctionMap(d => d.Statuses[0].StatusDocument.StatusDocumentDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode("./*[local-name()='Document']/*[local-name()='RegDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Statuses[0].StatusDocument.DocumentNumber, "./*[local-name()='Document']/*[local-name()='RegNumber']");
            mapper.AddPropertyMap(d => d.Statuses[0].StatusDocument.DocumentType, "./*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Statuses[0].StatusDocument.DocumentTypeLatin, "./*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.Statuses[0].Category.CategoryLatin, "./*[local-name()='Category']/*[local-name()='Latin']");
            //mapper.AddPropertyMap(d => d.StatusLawReason.Code, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='Category']/*[@code]");

            mapper.AddFunctionMap(d => d.Statuses[0].Category.Code, node =>
            {
                XmlNode n = node.SelectSingleNode("./*[local-name()='Category']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Statuses[0].Category.CategoryCyrillic, "./*[local-name()='Category']/*[local-name()='Cyrillic']");

            //mapper.AddPropertyMap(d => d.Category[0]. , "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Statuses']/*[local-name()='Category']/*[local-name()='Cyrillic']");

            //permanent address
            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='District']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='District']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Municipality']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.SettlementCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Settlement']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.PermanentAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.LocationCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Location']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.PermanentAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='BuildingNumber']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Entrance']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Floor']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Permanent']/*[local-name()='Apartment']");

            //temporary address
            mapper.AddPropertyMap(d => d.TemporaryAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='District']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='District']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Municipality']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.TemporaryAddress.SettlementCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Settlement']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.TemporaryAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.TemporaryAddress.LocationCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Location']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.TemporaryAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='BuildingNumber']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Entrance']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Floor']");
            mapper.AddPropertyMap(d => d.TemporaryAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Temporary']/*[local-name()='Apartment']");

            //abroad address
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.NationalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.NationalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddressAbroad.NationalityCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Country']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Settlement']");
            mapper.AddPropertyMap(d => d.PermanentAddressAbroad.Street, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Abroad']/*[local-name()='Street']");

            mapper.AddPropertyMap(d => d.IdentityDocument.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IdentityDocument.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IdentityDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IdentityNumber']");
            mapper.AddFunctionMap(p => p.IdentityDocument.IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuePlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuePlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IdentityDocument.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='IssuerName']/*[local-name()='Latin']");

            // Актуален статус на документ
            mapper.AddPropertyMap(d => d.IdentityDocument.StatusCyrillic, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='Status']/*[local-name()='Status']/*[local-name()='Cyrillic']");
            //StatusDate 
            mapper.AddFunctionMap(d => d.IdentityDocument.StatusDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='Status']/*[local-name()='StatusDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            //ReasonCyrillic
            mapper.AddPropertyMap(d => d.IdentityDocument.StatusReasonCyrillic, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='Status']/*[local-name()='Reason']/*[local-name()='Cyrillic']");
            //RPTypeOfPermit
            mapper.AddPropertyMap(d => d.IdentityDocument.RPTypeOfPermit, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='RPTypeOfPermit']");
            //RPRemarks
            mapper.AddCollectionMap(d => d.IdentityDocument.RPRemarks, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='RPRemarks']/*[local-name()='RPRemark']");
            mapper.AddFunctionMap(d => d.IdentityDocument.RPRemarks, node =>
            {
                XmlNode remarks = node.SelectSingleNode(
                            "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='RPRemarks']");

                if (remarks != null)
                {
                    List<string> restrictionNode = remarks.ChildNodes.Cast<XmlNode>()
                        .Where(x => x.LocalName == "RPRemark")
                        .Select(x => x.InnerText)
                        .ToList();
                    return restrictionNode;
                }
                else
                {
                    return null;
                }

            });


            // Актуален статус на документ - travel
            mapper.AddPropertyMap(d => d.TravelDocument.StatusCyrillic, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='Status']/*[local-name()='Status']/*[local-name()='Cyrillic']");
            //StatusDate - travel
            mapper.AddFunctionMap(d => d.TravelDocument.StatusDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='Status']/*[local-name()='StatusDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            //ReasonCyrillic - travel
            mapper.AddPropertyMap(d => d.TravelDocument.StatusReasonCyrillic, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='Status']/*[local-name()='Reason']/*[local-name()='Cyrillic']");

            mapper.AddFunctionMap(d => d.IdentityDocument.ValidDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Identity']/*[local-name()='ValidDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            //travel document
            mapper.AddPropertyMap(d => d.TravelDocument.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TravelDocument.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TravelDocument.TravelDocumentSeries, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='TravelDocumentSeries']");
            mapper.AddPropertyMap(d => d.TravelDocument.TravelDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='TravelDocumentNumber']");
            mapper.AddFunctionMap(p => p.TravelDocument.IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.TravelDocument.IssuePlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TravelDocument.IssuePlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.TravelDocument.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.TravelDocument.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='IssuerName']/*[local-name()='Latin']");

            mapper.AddFunctionMap(d => d.TravelDocument.ValidDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Travel']/*[local-name()='ValidDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(d => d.Height, node =>
            {
                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Height']");
                if (n != null && !string.IsNullOrWhiteSpace(n.InnerText))
                {
                    return double.Parse(n.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.EyesColor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.EyesColorLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']/*[local-name()='Latin']");

            mapper.AddFunctionMap<byte[]>(d => d.Picture, node =>
            {
                XmlNode blobXML = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Picture']");
                if (blobXML != null && !string.IsNullOrWhiteSpace(blobXML.InnerText))
                {
                    return Convert.FromBase64String(blobXML.InnerText);
                }
                return null;
            });

            mapper.AddFunctionMap<byte[]>(d => d.IdentitySignature, node =>
            {
                XmlNode blobXML = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='IdentitySignature']");
                if (blobXML != null && !string.IsNullOrWhiteSpace(blobXML.InnerText))
                {
                    return Convert.FromBase64String(blobXML.InnerText);
                }
                return null;
            });

            return mapper;
        }
        private void ValidateCallContext(AdapterAdditionalParameters additionalParameters)
        {
            if (string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeIdentifier))
            {
                Exception ex = new ArgumentException("EmployeeIdentifier parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeNames))
            {
                Exception ex = new ArgumentException("EmployeeNames parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.ServiceURI))
            {
                Exception ex = new ArgumentException("ServiceURI parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.ServiceType))
            {
                Exception ex = new ArgumentException("ServiceType parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.LawReason))
            {
                Exception ex = new ArgumentException("LawReason parameter is required in CallContext");
                throw ex;
            }
        }
    }
}