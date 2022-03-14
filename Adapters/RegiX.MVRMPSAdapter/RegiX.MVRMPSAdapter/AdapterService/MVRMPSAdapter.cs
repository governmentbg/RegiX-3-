using System;
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

namespace TechnoLogica.RegiX.MVRMPSAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MVRMPSAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MVRMPSAdapter), typeof(IAdapterService))]
    public class MVRMPSAdapter : SoapServiceBaseAdapterService, IMVRMPSAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRMPSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com:8078/MVRMockup/MVRMockupService.svc")
                           {
                               Key = Constants.WebServiceUrlParameterKeyName,
                               Description = "Web Service Url",
                               OwnerAssembly = typeof(MVRMPSAdapter).Assembly
                           };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRMPSAdapter), typeof(ParameterInfo))]
        //public static ParameterInfo<string> WebServiceUrlV2 =
        //                  new ParameterInfo<string>("http://localhost:60456/MVRMockupService.svc")
        //                  {
        //                      Key = Constants.WebServiceUrlParameterKeyNameV2,
        //                      Description = "Web Service Url V2",
        //                      OwnerAssembly = typeof(MVRMPSAdapter).Assembly
        //                  };
        public static ParameterInfo<string> WebServiceUrlV2 =
                          new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com:8078/MVRMPSV2Mockup/MVRMockupService.svc")
                          {
                              // TODO: Fix Constants
                              Key = "WebServiceUrlV2", //Constants.WebServiceUrlParameterKeyNameV2,
                              Description = "Web Service Url V2",
                              OwnerAssembly = typeof(MVRMPSAdapter).Assembly
                          };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRMPSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrlV3 =
                      new ParameterInfo<string>("http://localhost:52889/MVRMockupService.svc")
                      {
                          Key = "WebServiceUrlV3",
                          Description = "Web Service Url V3",
                          OwnerAssembly = typeof(MVRMPSAdapter).Assembly
                      };


        public CommonSignedResponse<MotorVehicleRegistrationRequestType, MotorVehicleRegistrationResponseType> GetMotorVehicleRegistrationInfo(MotorVehicleRegistrationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
                request.Header.Operation = "0003";
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

                RequestDataTypeVehicle vehicle = new RequestDataTypeVehicle();
                vehicle.RegistrationNumber = argument.Identifier;
                request.RequestData.Item = vehicle;
                #endregion

                MVRMPSServiceReference.IntSyncPortTypeClient client = new MVRMPSServiceReference.IntSyncPortTypeClient("EGovermentWSServiceImplPort", WebServiceUrl.Value);
                string response = client.Call(request.XmlSerialize());

                #region Response
                MotorVehicleRegistrationResponseType result = new MotorVehicleRegistrationResponseType();
                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<MotorVehicleRegistrationResponseType> mapper = CreateMPSMap(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    MotorVehicleRegistrationResponseType tempresult = new MotorVehicleRegistrationResponseType();
                    tempresult.ReturnInformation = new ReturnInformation();
                    tempresult.ReturnInformation.ReturnCode = "1111";
                    tempresult.ReturnInformation.Info = response;
                    ObjectMapper<MotorVehicleRegistrationResponseType, MotorVehicleRegistrationResponseType> selfmapper = CreateSelfMapper(accessMatrix);
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


        public CommonSignedResponse<MotorVehicleRegistrationRequestTypeV2, GetMotorVehicleRegistrationInfoV2ResponseType> GetMotorVehicleRegistrationInfoV2(MotorVehicleRegistrationRequestTypeV2 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
                MVRMPSAdapterV2.RegixVehicleRequest request = new MVRMPSAdapterV2.RegixVehicleRequest();
                request.Header.DateTime = DateTime.Now;
                request.Header.Operation = "0003";
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

                request.Header.MessageID = id.ToString();
                request.Header.OrganizationUnit = additionalParameters.OrganizationUnit;
                request.Header.CallerIPAddress = additionalParameters.ClientIPAddress;
                request.Header.CallContext = additionalParameters.CallContext != null ? additionalParameters.CallContext.ToString() : null;

                MVRMPSAdapterV2.RequestByVehRegNumType vehicle = new MVRMPSAdapterV2.RequestByVehRegNumType();
                vehicle.VehRegistrationNumber = argument.Identifier;
                request.Request.RequestByVehRegNum = vehicle;

                #endregion

                MVRMPSServiceReferenceV2.IntSyncPortTypeClient client = new MVRMPSServiceReferenceV2.IntSyncPortTypeClient("genWSImplPort", WebServiceUrlV2.Value);
                var req = request.XmlSerialize();
                string response = client.Call(request.XmlSerialize());
                #region Response
                 GetMotorVehicleRegistrationInfoV2ResponseType result = new GetMotorVehicleRegistrationInfoV2ResponseType();
                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<GetMotorVehicleRegistrationInfoV2ResponseType> mapper = CreateMPSMapV2(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    GetMotorVehicleRegistrationInfoV2ResponseType tempresult = new GetMotorVehicleRegistrationInfoV2ResponseType();
                    tempresult.Response.ReturnInformation = new ReturnInformationType();
                    tempresult.Response.ReturnInformation.ReturnCode = "1111";
                    tempresult.Response.ReturnInformation.Info = response;
                    ObjectMapper<GetMotorVehicleRegistrationInfoV2ResponseType, GetMotorVehicleRegistrationInfoV2ResponseType> selfmapper = CreateSelfMapperV2(accessMatrix);
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

        public CommonSignedResponse<MotorVehicleRegistrationRequestTypeV3, GetMotorVehicleRegistrationInfoV3ResponseType> GetMotorVehicleRegistrationInfoV3(MotorVehicleRegistrationRequestTypeV3 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
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
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                MVRMPSAdapterV2.RegixVehicleRequest request = new MVRMPSAdapterV2.RegixVehicleRequest();
                request.Header.DateTime = DateTime.Now;
                request.Header.Operation = "0003";
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

                request.Header.MessageID = id.ToString();
                request.Header.OrganizationUnit = additionalParameters.OrganizationUnit;
                request.Header.CallerIPAddress = additionalParameters.ClientIPAddress;
                request.Header.CallContext = additionalParameters.CallContext != null ? additionalParameters.CallContext.ToString() : null;
                //!!!!!!!!!!!!!!!!!!!
                MVRMPSAdapterV2.RequestByVehRegNumType vehicle = new MVRMPSAdapterV2.RequestByVehRegNumType();
                vehicle.VehRegistrationNumber = argument.Identifier;
                request.Request.RequestByVehRegNum = vehicle;

                #endregion

                MVRMPSServiceReferenceV3.IntSyncPortTypeClient client = new MVRMPSServiceReferenceV3.IntSyncPortTypeClient("genWSImplPort", WebServiceUrlV3.Value);
                var req = request.XmlSerialize();
                string response = client.Call(request.XmlSerialize());

                //string response = ReadFile("C:\\RegiX\\Regix\\MockupAdapters\\RegiX.MVRMPSAdapterV3MockupAdapter\\XMLData\\V3TestResponse.xml");
                #region Response
                GetMotorVehicleRegistrationInfoV3ResponseType result = new GetMotorVehicleRegistrationInfoV3ResponseType();
                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    resultXmlDoc.LoadXml(response);
                    XPathMapper<GetMotorVehicleRegistrationInfoV3ResponseType> mapper = CreateMPSMapV3(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    GetMotorVehicleRegistrationInfoV3ResponseType tempresult = new GetMotorVehicleRegistrationInfoV3ResponseType();
                    tempresult.Response.ReturnInformation = new ReturnInformationTypeV3();
                    tempresult.Response.ReturnInformation.ReturnCode = "1111";
                    tempresult.Response.ReturnInformation.Info = response;
                    ObjectMapper<GetMotorVehicleRegistrationInfoV3ResponseType, GetMotorVehicleRegistrationInfoV3ResponseType> selfmapper = CreateSelfMapperV3(accessMatrix);
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


        private static ObjectMapper<MotorVehicleRegistrationResponseType, MotorVehicleRegistrationResponseType> CreateSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<MotorVehicleRegistrationResponseType, MotorVehicleRegistrationResponseType> mapper = new ObjectMapper<MotorVehicleRegistrationResponseType, MotorVehicleRegistrationResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.ReturnInformation, (c) => c.ReturnInformation);
            mapper.AddPropertyMap((o) => o.ReturnInformation.ReturnCode, (c) => c.ReturnInformation.ReturnCode);
            mapper.AddPropertyMap((o) => o.ReturnInformation.Info, (c) => c.ReturnInformation.Info);

            return mapper;
        }

        private static ObjectMapper<GetMotorVehicleRegistrationInfoV2ResponseType, GetMotorVehicleRegistrationInfoV2ResponseType> CreateSelfMapperV2(AccessMatrix accessMatrix)
        {
            ObjectMapper<GetMotorVehicleRegistrationInfoV2ResponseType, GetMotorVehicleRegistrationInfoV2ResponseType> mapper = new ObjectMapper<GetMotorVehicleRegistrationInfoV2ResponseType, GetMotorVehicleRegistrationInfoV2ResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.Response.ReturnInformation, (c) => c.Response.ReturnInformation);
            mapper.AddPropertyMap((o) => o.Response.ReturnInformation.ReturnCode, (c) => c.Response.ReturnInformation.ReturnCode);
            mapper.AddPropertyMap((o) => o.Response.ReturnInformation.Info, (c) => c.Response.ReturnInformation.Info);

            return mapper;
        }

        private static ObjectMapper<GetMotorVehicleRegistrationInfoV3ResponseType, GetMotorVehicleRegistrationInfoV3ResponseType> CreateSelfMapperV3(AccessMatrix accessMatrix)
        {
            ObjectMapper<GetMotorVehicleRegistrationInfoV3ResponseType, GetMotorVehicleRegistrationInfoV3ResponseType> mapper = new ObjectMapper<GetMotorVehicleRegistrationInfoV3ResponseType, GetMotorVehicleRegistrationInfoV3ResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.Response.ReturnInformation, (c) => c.Response.ReturnInformation);
            mapper.AddPropertyMap((o) => o.Response.ReturnInformation.ReturnCode, (c) => c.Response.ReturnInformation.ReturnCode);
            mapper.AddPropertyMap((o) => o.Response.ReturnInformation.Info, (c) => c.Response.ReturnInformation.Info);

            return mapper;
        }
        private XPathMapper<MotorVehicleRegistrationResponseType> CreateMPSMap(AccessMatrix accessMatrix)
        {
            XPathMapper<MotorVehicleRegistrationResponseType> mapper = new XPathMapper<MotorVehicleRegistrationResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.ReturnInformation.ReturnCode, "./*[local-name()='MotorVehicleRegistrationResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.ReturnInformation.Info, "./*[local-name()='MotorVehicleRegistrationResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

            mapper.AddCollectionMap(d => d.Vehicles, "./*[local-name()='MotorVehicleRegistrationResponse']/*[local-name()='ResponseData']/*[local-name()='VehicleData']");
            mapper.AddPropertyMap(d => d.Vehicles[0].VehicleRegistrationNumber, "./*[local-name()='Vehicle']/*[local-name()='RegistrationNumber']");
            mapper.AddFunctionMap(p => p.Vehicles[0].FirstRegistrationDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='Vehicle']/*[local-name()='FirstRegistrationDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleRegistrationCertificateNumber, "./*[local-name()='Vehicle']/*[local-name()='MotorVehicleRegistrationCertificateNumber']");

            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.EGN, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.FirstName, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.Surname, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.FamilyName, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.FirstNameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.SurnameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.LastNameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");
            mapper.AddFunctionMap(p => p.Vehicles[0].OwnerPersonData.BirthDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='BirthDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.GenderName, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.GenderNameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Gender']/*[local-name()='Latin']");

            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerEntityData.Identifier, "./*[local-name()='Owner']/*[local-name()='Company']/*[local-name()='Identifier']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerEntityData.Name, "./*[local-name()='Owner']/*[local-name()='Company']/*[local-name()='Name']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerEntityData.NameLatin, "./*[local-name()='Owner']/*[local-name()='Company']/*[local-name()='NameLatin']");

            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.EGN, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.LNCh, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.Names, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.NamesLatin, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.GenderName, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.GenderNameLatin, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Gender']/*[local-name()='Latin']");

            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleType, "./*[local-name()='Vehicle']/*[local-name()='VehicleType']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleTypeLatin, "./*[local-name()='Vehicle']/*[local-name()='VehicleType']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleModel, "./*[local-name()='Vehicle']/*[local-name()='Model']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleModelLatin, "./*[local-name()='Vehicle']/*[local-name()='Model']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleModelType, "./*[local-name()='Vehicle']/*[local-name()='ModelType']");
            mapper.AddPropertyMap(d => d.Vehicles[0].TradeDescription, "./*[local-name()='Vehicle']/*[local-name()='TradeDescription']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].TradeDescriptionLatin, "./*[local-name()='Vehicle']/*[local-name()='TradeDescription']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.Vehicles[0].VINNumber, "./*[local-name()='Vehicle']/*[local-name()='VIN']");
            mapper.AddFunctionMap(p => p.Vehicles[0].IssueDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='Vehicle']/*[local-name()='IssueDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Vehicles[0].Category, "./*[local-name()='Vehicle']/*[local-name()='Category']");
            mapper.AddPropertyMap(d => d.Vehicles[0].Color, "./*[local-name()='Vehicle']/*[local-name()='Color']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].ColorLatin, "./*[local-name()='Vehicle']/*[local-name()='Color']/*[local-name()='Latin']");
            mapper.AddPropertyMap(d => d.Vehicles[0].EngineNumber, "./*[local-name()='Vehicle']/*[local-name()='EngineNumber']");
            mapper.AddPropertyMap(d => d.Vehicles[0].ColorSecondary, "./*[local-name()='Vehicle']/*[local-name()='ColorSecondary']/*[local-name()='Cyrillic']");
            mapper.AddPropertyMap(d => d.Vehicles[0].ColorSecondaryLatin, "./*[local-name()='Vehicle']/*[local-name()='ColorSecondary']/*[local-name()='Latin']");


            return mapper;
        }

        private XPathMapper<GetMotorVehicleRegistrationInfoV2ResponseType> CreateMPSMapV2(AccessMatrix accessMatrix)
        {
            XPathMapper<GetMotorVehicleRegistrationInfoV2ResponseType> mapper = new XPathMapper<GetMotorVehicleRegistrationInfoV2ResponseType>(accessMatrix);
            mapper.AddCollectionMap(d => d.Response.Results, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='Results']");

            //ReturnInformation
            mapper.AddPropertyMap(d => d.Response.ReturnInformation.ReturnCode, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.Response.ReturnInformation.Info, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='ReturnInformation']/*[local-name()='Info']");
            //Header
            mapper.AddPropertyMap(d => d.Header.MessageID, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='MessageID']");
            mapper.AddPropertyMap(d => d.Header.MessageRefID, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='MessageRefID']");
            mapper.AddFunctionMap(p => p.Header.DateTime, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='DateTime']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.Parse(dateNode.InnerText);
                    //return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Header.Operation, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='Operation']");
            mapper.AddPropertyMap(d => d.Header.UserName, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='UserName']");
            mapper.AddPropertyMap(d => d.Header.OrganizationUnit, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='OrganizationUnit']");
            mapper.AddPropertyMap(d => d.Header.CallerIPAddress, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='CallerIPAddress']");
            mapper.AddPropertyMap(d => d.Header.CallContext, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='CallContext']");
            //VehicleData 
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.RegistrationNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='RegistrationNumber']");
            mapper.AddFunctionMap(p => p.Response.Results[0].VehicleData.FirstRegistrationDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='FirstRegistrationDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.Parse(dateNode.InnerText);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VIN, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.EngineNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='EngineNumber']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehicleType, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleType']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Model, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Model']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.TypeApprovalNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='TypeApprovalNumber']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.ApprovalType, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='Results']/*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='ApprovalType']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.TradeDescription, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='TradeDescription']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Color, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Color']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Category, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Category']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.OffRoadSymbols, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='OffRoadSymbols']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MassG, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MassG']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Capacity, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Capacity']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MassF1, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MassF1']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MaxPower, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MaxPower']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Fuel, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MaxPower']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.EnvironmentalCategory, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Fuel']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehicleDocument.VehDocumentNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleDocument']/*[local-name()='VehDocumentNumber']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehicleDocument.VehDocumentNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleDocument']/*[local-name()='VehDocumentNumber']");
            mapper.AddFunctionMap(p => p.Response.Results[0].VehicleData.VehicleDocument.VehDocumentDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleDocument']/*[local-name()='VehDocumentDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.Parse(dateNode.InnerText);
                }
                return null;
            });
            //OwnersData
            mapper.AddCollectionMap(d => d.Response.Results[0].OwnersData.Owner, "./*[local-name()='Result']/*[local-name()='OwnersData']/*[local-name()='Owner']");
                //BulgarianCitizen
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.PIN, "./*[local-name()='BulgarianCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.Names.First, "./*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.Names.Surname, "./*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.Names.Family, "./*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Family']");
                //ForeignCitizen
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.PIN, "./*[local-name()='ForeignCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.PN, "./*[local-name()='ForeignCitizen']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.NamesCyrillic, "./*[local-name()='ForeignCitizen']/*[local-name()='NamesCyrillic']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.NamesLatin, "./*[local-name()='ForeignCitizen']/*[local-name()='NamesLatin']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.Nationality, "./*[local-name()='ForeignCitizen']/*[local-name()='Nationality']");
                //Company
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].Company.ID, "./*[local-name()='Company']/*[local-name()='ID']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].Company.Name, "./*[local-name()='Company']/*[local-name()='Name']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].Company.NameLatin, "./*[local-name()='Company']/*[local-name()='NameLatin']");

            //UsersData
            mapper.AddCollectionMap(d => d.Response.Results[0].UsersData, "./*[local-name()='Result']/*[local-name()='UsersData']");
                //BulgarianCitizen
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.PIN, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.Names.First, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.Names.Surname, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.Names.Family, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Family']");
                //ForeignCitizen                                 
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.PIN, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.PN, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.NamesCyrillic, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='NamesCyrillic']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.NamesLatin, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='NamesLatin']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.Nationality, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='Nationality']");
                //Company                                        
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.Company.ID, "./*[local-name()='User']/*[local-name()='Company']/*[local-name()='ID']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.Company.Name, "./*[local-name()='User']/*[local-name()='Company']/*[local-name()='Name']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.Company.NameLatin, "./*[local-name()='User']/*[local-name()='Company']/*[local-name()='NameLatin']");

            return mapper;
        }

        private XPathMapper<GetMotorVehicleRegistrationInfoV3ResponseType> CreateMPSMapV3(AccessMatrix accessMatrix)
        {
            XPathMapper<GetMotorVehicleRegistrationInfoV3ResponseType> mapper = new XPathMapper<GetMotorVehicleRegistrationInfoV3ResponseType>(accessMatrix);
            mapper.AddCollectionMap(d => d.Response.Results, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='Results']");

            //ReturnInformation
            mapper.AddPropertyMap(d => d.Response.ReturnInformation.ReturnCode, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
            mapper.AddPropertyMap(d => d.Response.ReturnInformation.Info, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='ReturnInformation']/*[local-name()='Info']");
            //Header
            mapper.AddPropertyMap(d => d.Header.MessageID, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='MessageID']");
            mapper.AddPropertyMap(d => d.Header.MessageRefID, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='MessageRefID']");
            mapper.AddFunctionMap(p => p.Header.DateTime, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='DateTime']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.Parse(dateNode.InnerText);
                    //return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Header.Operation, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='Operation']");
            mapper.AddPropertyMap(d => d.Header.UserName, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='UserName']");
            mapper.AddPropertyMap(d => d.Header.OrganizationUnit, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='OrganizationUnit']");
            mapper.AddPropertyMap(d => d.Header.CallerIPAddress, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='CallerIPAddress']");
            mapper.AddPropertyMap(d => d.Header.CallContext, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Header']/*[local-name()='CallContext']");
            //VehicleData 
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.RegistrationNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='RegistrationNumber']");
            mapper.AddFunctionMap(p => p.Response.Results[0].VehicleData.FirstRegistrationDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='FirstRegistrationDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.Parse(dateNode.InnerText);
                }
                return null;
            });
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VIN, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.EngineNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='EngineNumber']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehicleType, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleType']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Model, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Model']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.TypeApprovalNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='TypeApprovalNumber']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.ApprovalType, "./*[local-name()='RegixVehicleResponse']/*[local-name()='Response']/*[local-name()='Results']/*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='ApprovalType']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.TradeDescription, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='TradeDescription']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Color, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Color']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Category, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Category']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.OffRoadSymbols, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='OffRoadSymbols']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MassG, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MassG']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Capacity, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Capacity']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MassF1, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MassF1']");

            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MassF2, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MassF2']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MassF3, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MassF3']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehMassO1, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehMassO1']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehMassO2, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehMassO2']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehNumOfAxles, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehNumOfAxles']");







            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.MaxPower, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='MaxPower']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.Fuel, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='Fuel']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.EnvironmentalCategory, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='EnvironmentalCategory']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehicleDocument.VehDocumentNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleDocument']/*[local-name()='VehDocumentNumber']");
            mapper.AddPropertyMap(d => d.Response.Results[0].VehicleData.VehicleDocument.VehDocumentNumber, "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleDocument']/*[local-name()='VehDocumentNumber']");
            mapper.AddFunctionMap(p => p.Response.Results[0].VehicleData.VehicleDocument.VehDocumentDate, node =>
            {
                XmlNode dateNode =
                       node.SelectSingleNode(
                           "./*[local-name()='Result']/*[local-name()='VehicleData']/*[local-name()='VehicleDocument']/*[local-name()='VehDocumentDate']");
                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
                {
                    return DateTime.Parse(dateNode.InnerText);
                }
                return null;
            });
            //OwnersData
            mapper.AddCollectionMap(d => d.Response.Results[0].OwnersData.Owner, "./*[local-name()='Result']/*[local-name()='OwnersData']/*[local-name()='Owner']");
            //BulgarianCitizen
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.PIN, "./*[local-name()='BulgarianCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.Names.First, "./*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.Names.Surname, "./*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].BulgarianCitizen.Names.Family, "./*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Family']");
            //ForeignCitizen
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.PIN, "./*[local-name()='ForeignCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.PN, "./*[local-name()='ForeignCitizen']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.NamesCyrillic, "./*[local-name()='ForeignCitizen']/*[local-name()='NamesCyrillic']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.NamesLatin, "./*[local-name()='ForeignCitizen']/*[local-name()='NamesLatin']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].ForeignCitizen.Nationality, "./*[local-name()='ForeignCitizen']/*[local-name()='Nationality']");
            //Company
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].Company.ID, "./*[local-name()='Company']/*[local-name()='ID']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].Company.Name, "./*[local-name()='Company']/*[local-name()='Name']");
            mapper.AddPropertyMap(d => d.Response.Results[0].OwnersData.Owner[0].Company.NameLatin, "./*[local-name()='Company']/*[local-name()='NameLatin']");

            //UsersData
            mapper.AddCollectionMap(d => d.Response.Results[0].UsersData, "./*[local-name()='Result']/*[local-name()='UsersData']");
            //BulgarianCitizen
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.PIN, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.Names.First, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='First']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.Names.Surname, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Surname']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.BulgarianCitizen.Names.Family, "./*[local-name()='User']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Family']");
            //ForeignCitizen                                 
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.PIN, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='PIN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.PN, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='PN']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.NamesCyrillic, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='NamesCyrillic']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.NamesLatin, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='NamesLatin']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.ForeignCitizen.Nationality, "./*[local-name()='User']/*[local-name()='ForeignCitizen']/*[local-name()='Nationality']");
            //Company                                        
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.Company.ID, "./*[local-name()='User']/*[local-name()='Company']/*[local-name()='ID']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.Company.Name, "./*[local-name()='User']/*[local-name()='Company']/*[local-name()='Name']");
            mapper.AddPropertyMap(d => d.Response.Results[0].UsersData[0].User.Company.NameLatin, "./*[local-name()='User']/*[local-name()='Company']/*[local-name()='NameLatin']");

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