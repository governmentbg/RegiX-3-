//using System;
//using System.ComponentModel.Composition;
//using System.Globalization;
//using System.Xml;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.WebServiceAdapterService;

//namespace TechnoLogica.RegiX.MVRMPSAdapter.AdapterService
//{
//    public class MVRMPSAdapter : SoapServiceBaseAdapterService, IMVRMPSAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(MVRMPSAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//                           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/MVRMockup/MVRMockupService.svc")
//                           {
//                               Key = Constants.WebServiceUrlParameterKeyName,
//                               Description = "Web Service Url",
//                               OwnerAssembly = typeof(MVRMPSAdapter).Assembly
//                           };
       

//        public CommonSignedResponse<MotorVehicleRegistrationRequestType, MotorVehicleRegistrationResponseType> GetMotorVehicleRegistrationInfo(MotorVehicleRegistrationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                Request request = new Request();
//                request.Header.DateTime = System.DateTime.Now;
//                request.Header.Operation = "0003";
//                //request.Header.UserName = additionalParameters.EIDToken;
//                request.Header.UserName = String.Format("<![CDATA[{0}]]>", additionalParameters.EIDToken);
//                request.Header.OrganizationUnit = additionalParameters.OrganizationUnit;
//                request.Header.CallerIPAddress = additionalParameters.ClientIPAddress;
//                request.Header.CallContext = additionalParameters.CallContext != null ? additionalParameters.CallContext.ToString() : null;

//                RequestDataTypeVehicle vehicle = new RequestDataTypeVehicle();
//                vehicle.RegistrationNumber = argument.Identifier;
//                request.RequestData.Item = vehicle;

//            MVRMPSServiceReference.IntSyncPortTypeClient client = new MVRMPSServiceReference.IntSyncPortTypeClient("EGovermentWSServiceImplPort", WebServiceUrl.Value);
//                string response = client.Call(request.XmlSerialize());
//                XPathMapper<MotorVehicleRegistrationResponseType> mapper = CreateMPSMap(accessMatrix);
//                MotorVehicleRegistrationResponseType result = new MotorVehicleRegistrationResponseType();
//                XmlDocument resultXmlDoc = new XmlDocument();
//                resultXmlDoc.LoadXml(response);
//                mapper.Map(resultXmlDoc, result);

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

//        private XPathMapper<MotorVehicleRegistrationResponseType> CreateMPSMap(AccessMatrix accessMatrix)
//        {
//            XPathMapper<MotorVehicleRegistrationResponseType> mapper = new XPathMapper<MotorVehicleRegistrationResponseType>(accessMatrix);

//            mapper.AddPropertyMap(d => d.ReturnInformation.ReturnCode, "./*[local-name()='MotorVehicleRegistrationResponse']/*[local-name()='ReturnInformation']/*[local-name()='ReturnCode']");
//            mapper.AddPropertyMap(d => d.ReturnInformation.Info, "./*[local-name()='MotorVehicleRegistrationResponse']/*[local-name()='ReturnInformation']/*[local-name()='Info']");

//            mapper.AddCollectionMap(d => d.Vehicles, "./*[local-name()='MotorVehicleRegistrationResponse']/*[local-name()='ResponseData']/*[local-name()='VehicleData']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].VehicleRegistrationNumber, "./*[local-name()='Vehicle']/*[local-name()='RegistrationNumber']");
//            mapper.AddFunctionMap(p => p.Vehicles[0].FirstRegistrationDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='Vehicle']/*[local-name()='FirstRegistrationDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });

//            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleRegistrationCertificateNumber, "./*[local-name()='Vehicle']/*[local-name()='MotorVehicleRegistrationCertificateNumber']");

//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.EGN, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='PIN']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.FirstName, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='First']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.Surname, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Surname']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.FamilyName, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']/*[local-name()='Family']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.FirstNameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='First']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.SurnameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Surname']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.LastNameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Names']/*[local-name()='Latin']/*[local-name()='Family']");
//            mapper.AddFunctionMap(p => p.Vehicles[0].OwnerPersonData.BirthDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='BirthDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.GenderName, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerPersonData.GenderNameLatin, "./*[local-name()='Owner']/*[local-name()='BulgarianCitizen']/*[local-name()='Gender']/*[local-name()='Latin']");

//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerEntityData.Identifier, "./*[local-name()='Owner']/*[local-name()='Company']/*[local-name()='Identifier']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerEntityData.Name, "./*[local-name()='Owner']/*[local-name()='Company']/*[local-name()='Name']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerEntityData.NameLatin, "./*[local-name()='Owner']/*[local-name()='Company']/*[local-name()='NameLatin']");

//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.EGN, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='PIN']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.LNCh, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='PN']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.Names, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Names']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.NamesLatin, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Names']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.GenderName, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Gender']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].OwnerForeignerPersonData.GenderNameLatin, "./*[local-name()='Owner']/*[local-name()='ForeignCitizen']/*[local-name()='Gender']/*[local-name()='Latin']");

//            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleType, "./*[local-name()='Vehicle']/*[local-name()='VehicleType']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleTypeLatin, "./*[local-name()='Vehicle']/*[local-name()='VehicleType']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleModel, "./*[local-name()='Vehicle']/*[local-name()='Model']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleModelLatin, "./*[local-name()='Vehicle']/*[local-name()='Model']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].MotorVehicleModelType, "./*[local-name()='Vehicle']/*[local-name()='ModelType']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].TradeDescription, "./*[local-name()='Vehicle']/*[local-name()='TradeDescription']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].TradeDescriptionLatin, "./*[local-name()='Vehicle']/*[local-name()='TradeDescription']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].VINNumber, "./*[local-name()='Vehicle']/*[local-name()='VIN']");
//            mapper.AddFunctionMap(p => p.Vehicles[0].IssueDate, node =>
//            {
//                XmlNode dateNode =
//                       node.SelectSingleNode(
//                           "./*[local-name()='Vehicle']/*[local-name()='IssueDate']");
//                if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
//                {
//                    return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(d => d.Vehicles[0].Category, "./*[local-name()='Vehicle']/*[local-name()='Category']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].Color, "./*[local-name()='Vehicle']/*[local-name()='Color']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].ColorLatin, "./*[local-name()='Vehicle']/*[local-name()='Color']/*[local-name()='Latin']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].EngineNumber, "./*[local-name()='Vehicle']/*[local-name()='EngineNumber']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].ColorSecondary, "./*[local-name()='Vehicle']/*[local-name()='ColorSecondary']/*[local-name()='Cyrillic']");
//            mapper.AddPropertyMap(d => d.Vehicles[0].ColorSecondaryLatin, "./*[local-name()='Vehicle']/*[local-name()='ColorSecondary']/*[local-name()='Latin']");


//            return mapper;
//        }


//    }
//}