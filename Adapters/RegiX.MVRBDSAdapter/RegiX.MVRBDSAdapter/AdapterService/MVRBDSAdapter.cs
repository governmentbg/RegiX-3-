using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.MVRBDSAdapter.MVRBDSServiceReference;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.DataContracts;
using System.Xml;
using System.Globalization;
using System;
using System.Linq;
using System.Xml.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.WebServiceAdapterService;
using System.Collections.Generic;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MVRBDSAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MVRBDSAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MVRBDSAdapter), typeof(IAdapterService))]
    public class MVRBDSAdapter : SoapServiceBaseAdapterService, IMVRBDSAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRBDSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MVRMockup/MVRMockupService.svc")
                           {
                               Key = Constants.WebServiceUrlParameterKeyName,
                               Description = "Web Service Url",
                               OwnerAssembly = typeof(MVRBDSAdapter).Assembly
                           };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRBDSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrlV2 =
                          new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MVRMockup/MVRMockupService.svc")
                          {
                              Key = "WebServiceUrlV2",
                              Description = "Web Service Url V2",
                              OwnerAssembly = typeof(MVRBDSAdapter).Assembly
                          };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRBDSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrlV3 =
                          new ParameterInfo<string>("http://zeus:9041/services/b3")
                          {
                              Key = "WebServiceUrlV3",
                              Description = "Web Service Url V3",
                              OwnerAssembly = typeof(MVRBDSAdapter).Assembly
                          };

        public CommonSignedResponse<PersonalIdentityInfoRequestType, PersonalIdentityInfoResponseType> GetPersonalIdentity(PersonalIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
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

            try
            {
                #region Request
                Request request = new Request();
                request.Header.DateTime = System.DateTime.Now;
                request.Header.Operation = "0001";
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

                PidAndDocIdType pd = new PidAndDocIdType();
                pd.DocID = argument.IdentityDocumentNumber;
                pd.PID = argument.EGN;
                request.RequestData.Item = pd;
                #endregion

                MVRBDSServiceReference.IntSyncPortTypeClient client = new IntSyncPortTypeClient("EGovermentWSServiceImplPort", WebServiceUrl.Value);
                string response = client.Call(request.XmlSerialize());

                #region Result

                PersonalIdentityInfoResponseType result = new PersonalIdentityInfoResponseType();

                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<PersonalIdentityInfoResponseType> mapper = CreatePersonalIdentityInfoMap(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    PersonalIdentityInfoResponseType tempresult = new PersonalIdentityInfoResponseType();
                    tempresult.ReturnInformations = new ReturnInformation();
                    tempresult.ReturnInformations.ReturnCode = "1111";
                    tempresult.ReturnInformations.Info = response;
                    ObjectMapper<PersonalIdentityInfoResponseType, PersonalIdentityInfoResponseType> selfmapper = CreateSelfMapper(accessMatrix);
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

        private static ObjectMapper<PersonalIdentityInfoResponseType, PersonalIdentityInfoResponseType> CreateSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<PersonalIdentityInfoResponseType, PersonalIdentityInfoResponseType> mapper = new ObjectMapper<PersonalIdentityInfoResponseType, PersonalIdentityInfoResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.ReturnInformations, (c) => c.ReturnInformations);
            mapper.AddPropertyMap((o) => o.ReturnInformations.ReturnCode, (c) => c.ReturnInformations.ReturnCode);
            mapper.AddPropertyMap((o) => o.ReturnInformations.Info, (c) => c.ReturnInformations.Info);

            return mapper;
        }
        private XPathMapper<PersonalIdentityInfoResponseType> CreatePersonalIdentityInfoMap(AccessMatrix accessMatrix)
        {
            XPathMapper<PersonalIdentityInfoResponseType> mapper = new XPathMapper<PersonalIdentityInfoResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.ReturnInformations.ReturnCode, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.ReturnInformations.Info, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

            mapper.AddPropertyMap(d => d.EGN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");

            mapper.AddPropertyMap(d => d.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IdentityDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IdentityNumber']");

            mapper.AddFunctionMap(p => p.IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.IssuerPlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IssuerPlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Latin']");

            mapper.AddFunctionMap(d => d.ValidDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='ValidDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(d => d.BirthDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Data']/*[local-name()='BirthDate']");
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

            mapper.AddCollectionMap(d => d.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
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

            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.SettlementCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.PermanentAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.LocationCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.PermanentAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='BuildingNumber']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Entrance']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Floor']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Apartment']");

            mapper.AddFunctionMap(d => d.Height, node =>
            {
                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Height']");
                if (n != null && !string.IsNullOrWhiteSpace(n.InnerText))
                {
                    return double.Parse(n.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.EyesColor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']");

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



        public CommonSignedResponse<MVRBDSAdapterV2.PersonalIdentityInfoRequestType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType> GetPersonalIdentityV2(MVRBDSAdapterV2.PersonalIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
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
            try
            {
                #region Request
                MVRBDSAdapterV2.Request request = new MVRBDSAdapterV2.Request();
                request.Header.DateTime = System.DateTime.Now;
                request.Header.Operation = "0001";
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


                MVRBDSAdapterV2.PidAndDocIdType pd = new MVRBDSAdapterV2.PidAndDocIdType();
                pd.DocID = argument.IdentityDocumentNumber;
                pd.PID = argument.EGN;
                request.RequestData.Item = pd;
                #endregion

                var client = new MVRBDSv2ServiceReference.IntSyncPortTypeClient("genWSImplPort", WebServiceUrlV2.Value);
                string response = client.Call(request.XmlSerialize());
                #region Result

                MVRBDSAdapterV2.PersonalIdentityInfoResponseType result = new MVRBDSAdapterV2.PersonalIdentityInfoResponseType();

                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType> mapper = CreatePersonalIdentityInfoMapV2(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    MVRBDSAdapterV2.PersonalIdentityInfoResponseType tempresult = new MVRBDSAdapterV2.PersonalIdentityInfoResponseType();
                    tempresult.ReturnInformations = new MVRBDSAdapterV2.ReturnInformation();
                    tempresult.ReturnInformations.ReturnCode = "1111";
                    tempresult.ReturnInformations.Info = response;
                    ObjectMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType> selfmapper = CreateSelfMapperV2(accessMatrix);
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
        private static ObjectMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType> CreateSelfMapperV2(AccessMatrix accessMatrix)
        {
            ObjectMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType> mapper = new ObjectMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.ReturnInformations, (c) => c.ReturnInformations);
            mapper.AddPropertyMap((o) => o.ReturnInformations.ReturnCode, (c) => c.ReturnInformations.ReturnCode);
            mapper.AddPropertyMap((o) => o.ReturnInformations.Info, (c) => c.ReturnInformations.Info);

            return mapper;
        }
        private XPathMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType> CreatePersonalIdentityInfoMapV2(AccessMatrix accessMatrix)
        {
            XPathMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType> mapper = new XPathMapper<MVRBDSAdapterV2.PersonalIdentityInfoResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.ReturnInformations.ReturnCode, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.ReturnInformations.Info, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

            mapper.AddPropertyMap(d => d.EGN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");

            mapper.AddPropertyMap(d => d.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IdentityDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IdentityNumber']");
            mapper.AddFunctionMap(p => p.IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.IssuerPlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IssuerPlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Latin']");

            mapper.AddFunctionMap(d => d.ValidDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='ValidDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.DocumentActualStatus, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Status']/*[local-name()='Status']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.DocumentStatusReason, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Status']/*[local-name()='Reason']/*[local-name()='Cyrillic']");
            mapper.AddFunctionMap(d => d.ActualStatusDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Status']/*[local-name()='StatusDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            //DLCategories
            mapper.AddCollectionMap(d => d.DLCategоries, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DLCategories']/*[local-name()='DLCategory']");
            mapper.AddPropertyMap(d => d.DLCategоries[0].Category, "./*[local-name()='Category']");
            mapper.AddFunctionMap(d => d.DLCategоries[0].Restrictions, node =>
            {
                if (node != null)
                {
                    List<string> restrictionNode = node.ChildNodes.Cast<XmlNode>()
                    .Where(x => x.LocalName == "Restrictions")
                    .Select(x => x.InnerText)
                    .ToList();
                    return restrictionNode;
                }
                else
                {
                    return null;
                }
                
            });
            mapper.AddFunctionMap(d => d.DLCategоries[0].DateCategory, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='DateCategory']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddFunctionMap(d => d.DLCategоries[0].EndDateCategory, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='EndDateCategory']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });


            //DLCommonRestrictions
            mapper.AddPropertyMap(d => d.DLCommonRestrictions, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DLCommonRestrictions']");
            //DataForeignCitizen
            mapper.AddPropertyMap(d => d.DataForeignCitizen.PIN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.PN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");
            mapper.AddCollectionMap(d => d.DataForeignCitizen.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.NationalityList[0].NationalityNameLatin, "./*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.NationalityList[0].NationalityName, "./*[local-name()='Cyrillic']");
            mapper.AddFunctionMap(d => d.DataForeignCitizen.NationalityList[0].NationalityCode, node =>
            {
                XmlAttribute attr = node.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.DataForeignCitizen.Gender.Cyrillic, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Gender.Latin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Gender']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.DataForeignCitizen.Gender.GenderCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Gender']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddFunctionMap(d => d.DataForeignCitizen.BirthDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='BirthDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            //RPRemarks
            mapper.AddCollectionMap(d => d.RPRemarks, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='RPRemarks']/*[local-name()='RPRemark']");
            mapper.AddFunctionMap(d => d.RPRemarks, node =>
            {
                XmlNode remarks = node.SelectSingleNode(
                            "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='RPRemarks']");
                if (remarks != null)
                {
                    List<string> restrictionNode = remarks.ChildNodes.Cast<XmlNode>()
                    .Where(x => x.LocalName == "RPRemark")
                    .Select(x => x.InnerText)
                    .ToList();
                    return restrictionNode;
                }
                else {
                    return null;
                }
            });
            //RPTypeofPermit
            mapper.AddPropertyMap(d => d.RPTypeofPermit, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='RPTypeOfPermit']");

            mapper.AddFunctionMap(d => d.BirthDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='BirthDate']");
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

            mapper.AddPropertyMap(d => d.GenderName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.GenderNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Gender']/*[local-name()='Latin']");

            mapper.AddCollectionMap(d => d.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
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

            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.SettlementCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.PermanentAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.LocationCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.PermanentAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='BuildingNumber']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Entrance']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Floor']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Apartment']");

            mapper.AddFunctionMap(d => d.Height, node =>
            {
                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Height']");
                if (n != null && !string.IsNullOrWhiteSpace(n.InnerText))
                {
                    return double.Parse(n.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.EyesColor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']");

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

        public CommonSignedResponse<MVRBDSAdapterV3.PersonalIdentityInfoRequestType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType> GetPersonalIdentityV3(MVRBDSAdapterV3.PersonalIdentityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
                MVRBDSAdapterV2.Request request = new MVRBDSAdapterV2.Request();
                request.Header.DateTime = System.DateTime.Now;
                request.Header.Operation = "0001";
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


                MVRBDSAdapterV2.PidAndDocIdType pd = new MVRBDSAdapterV2.PidAndDocIdType();
                pd.DocID = argument.IdentityDocumentNumber;
                pd.PID = argument.EGN;
                request.RequestData.Item = pd;
                #endregion

                var client = new MVRBDSv3ServiceReference.IntSyncPortTypeClient("genWSImplPortV3", WebServiceUrlV3.Value);
                string response = client.Call(request.XmlSerialize());
                #region Result

                MVRBDSAdapterV3.PersonalIdentityInfoResponseType result = new MVRBDSAdapterV3.PersonalIdentityInfoResponseType();

                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType> mapper = CreatePersonalIdentityInfoMapV3(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    MVRBDSAdapterV3.PersonalIdentityInfoResponseType tempresult = new MVRBDSAdapterV3.PersonalIdentityInfoResponseType();
                    tempresult.ReturnInformations = new MVRBDSAdapterV3.ReturnInformation();
                    tempresult.ReturnInformations.ReturnCode = "1111";
                    tempresult.ReturnInformations.Info = response;
                    ObjectMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType> selfmapper = CreateSelfMapperV3(accessMatrix);
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
        private static ObjectMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType> CreateSelfMapperV3(AccessMatrix accessMatrix)
        {
            ObjectMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType> mapper = new ObjectMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.ReturnInformations, (c) => c.ReturnInformations);
            mapper.AddPropertyMap((o) => o.ReturnInformations.ReturnCode, (c) => c.ReturnInformations.ReturnCode);
            mapper.AddPropertyMap((o) => o.ReturnInformations.Info, (c) => c.ReturnInformations.Info);

            return mapper;
        }
        private XPathMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType> CreatePersonalIdentityInfoMapV3(AccessMatrix accessMatrix)
        {
            XPathMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType> mapper = new XPathMapper<MVRBDSAdapterV3.PersonalIdentityInfoResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.ReturnInformations.ReturnCode, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.ReturnInformations.Info, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

            mapper.AddPropertyMap(d => d.EGN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.PersonNames.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.PersonNames.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.PersonNames.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");

            mapper.AddPropertyMap(d => d.DocumentType, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.DocumentTypeLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DocumentType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IdentityDocumentNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IdentityNumber']");
            mapper.AddFunctionMap(p => p.IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.IssuerPlace, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IssuerPlaceLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuePlace']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.IssuerName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.IssuerNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='IssuerName']/*[local-name()='Latin']");

            mapper.AddFunctionMap(d => d.ValidDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='ValidDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.DocumentActualStatus, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Status']/*[local-name()='Status']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.DocumentStatusReason, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Status']/*[local-name()='Reason']/*[local-name()='Cyrillic']");
            mapper.AddFunctionMap(d => d.ActualStatusDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='Status']/*[local-name()='StatusDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            //DLCategories
            mapper.AddCollectionMap(d => d.DLCategоries, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DLCategories']/*[local-name()='DLCategory']");
            mapper.AddPropertyMap(d => d.DLCategоries[0].Category, "./*[local-name()='Category']");
            mapper.AddFunctionMap(d => d.DLCategоries[0].Restrictions, node =>
            {
                if (node != null)
                {
                    List<string> restrictionNode = node.ChildNodes.Cast<XmlNode>()
                    .Where(x => x.LocalName == "Restrictions")
                    .Select(x => x.InnerText)
                    .ToList();
                    return restrictionNode;
                }
                else
                {
                    return null;
                }

            });
            mapper.AddFunctionMap(d => d.DLCategоries[0].DateCategory, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='DateCategory']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddFunctionMap(d => d.DLCategоries[0].EndDateCategory, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='EndDateCategory']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });


            //DLCommonRestrictions
            mapper.AddPropertyMap(d => d.DLCommonRestrictions, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='DLCommonRestrictions']");
            //DataForeignCitizen
            mapper.AddPropertyMap(d => d.DataForeignCitizen.PIN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.PN, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.FirstName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.FirstNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.Surname, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.SurnameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.FamilyName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Names.LastNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");
            mapper.AddCollectionMap(d => d.DataForeignCitizen.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.NationalityList[0].NationalityNameLatin, "./*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.NationalityList[0].NationalityName, "./*[local-name()='Cyrillic']");
            mapper.AddFunctionMap(d => d.DataForeignCitizen.NationalityList[0].NationalityCode, node =>
            {
                XmlAttribute attr = node.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.DataForeignCitizen.Gender.Cyrillic, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.DataForeignCitizen.Gender.Latin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Gender']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.DataForeignCitizen.Gender.GenderCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='Gender']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddFunctionMap(d => d.DataForeignCitizen.BirthDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataForeignCitizen']/*[local-name()='BirthDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            //RPRemarks
            mapper.AddCollectionMap(d => d.RPRemarks, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='RPRemarks']/*[local-name()='RPRemark']");
            mapper.AddFunctionMap(d => d.RPRemarks, node =>
            {
                XmlNode remarks = node.SelectSingleNode(
                            "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='RPRemarks']");
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
            //RPTypeofPermit
            mapper.AddPropertyMap(d => d.RPTypeofPermit, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Document']/*[local-name()='RPTypeOfPermit']");

            mapper.AddFunctionMap(d => d.BirthDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='BirthDate']");
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

            mapper.AddPropertyMap(d => d.GenderName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.GenderNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='DataBG']/*[local-name()='Gender']/*[local-name()='Latin']");

            mapper.AddCollectionMap(d => d.NationalityList, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='NationalityList']/*[local-name()='Nationality']");
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

            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.DistrictNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='District']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.MunicipalityNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Municipality']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.SettlementNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.SettlementCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Settlement']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.PermanentAddress.LocationName, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.PermanentAddress.LocationNameLatin, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']/*[local-name()='Latin']");
            mapper.AddFunctionMap(d => d.PermanentAddress.LocationCode, node =>
            {

                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Location']");
                if (n == null || string.IsNullOrWhiteSpace(n.InnerText)) return null;
                XmlAttribute attr = n.Attributes["code"];
                if (attr != null)
                {
                    return attr.Value;
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.PermanentAddress.BuildingNumber, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='BuildingNumber']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Entrance, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Entrance']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Floor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Floor']");
            mapper.AddPropertyMap(d => d.PermanentAddress.Apartment, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='Address']/*[local-name()='Apartment']");

            mapper.AddFunctionMap(d => d.Height, node =>
            {
                XmlNode n = node.SelectSingleNode("./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='Height']");
                if (n != null && !string.IsNullOrWhiteSpace(n.InnerText))
                {
                    return double.Parse(n.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.EyesColor, "./*[local-name()='PersonalIdentityInfoResponse']/*[local-name()='ResponseData']/*[local-name()='PersonData']/*[local-name()='EyesColor']");

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