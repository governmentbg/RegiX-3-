using System;
using System.Linq;
using TechnoLogica.RegiX.WebServiceAdapterService;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;
using AdapterServiceReference = TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;
using TechnoLogica.RegiX.AVBulstat2Adapter.XMLSchemas;
using System.Xml.Linq;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.AVBulstat2Adapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(AVBulstat2Adapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(AVBulstat2Adapter), typeof(IAdapterService))]
    public class AVBulstat2Adapter : SoapServiceBaseAdapterService, IAVBulstat2Adapter, IAdapterService
    {
        //Засега се обръщаме към mockup услуга.
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(AVBulstat2Adapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            new ParameterInfo<string>("http://172.16.69.13:8078/AVBulstat2MockService/AVBulstat2ServiceImplServiceInterface.svc")
            //new ParameterInfo<string>("http://localhost:57219/AVBulstat2ServiceImplServiceInterface.svc")            
            {
                Key = Constants.WebServiceUrlParameterKeyName,
                Description = "Connection String for SOAP Web Service",
                OwnerAssembly = typeof(IAdapterService).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(AVBulstat2Adapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrlValidUIC =
            new ParameterInfo<string>("http://<server:port>/bulstat/services/ActualUICService?wsdl")
            {
                Key = Constants.WebServiceUrlParameterKeyName,
                Description = "Connection String GetValidUICInfo",
                OwnerAssembly = typeof(IAdapterService).Assembly
            };

        //Засега се обръщаме към mockup услуга.
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(AVBulstat2Adapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> LogResultData =
            new ParameterInfo<string>("true")
            {
                Key = "LogResultData",
                Description = "Enables logging with Log4Net",
                OwnerAssembly = typeof(IAdapterService).Assembly
            };

        public CommonSignedResponse<AdapterServiceReference.GetStateOfPlayRequest, AdapterServiceReference.StateOfPlay> GetStateOfPlay
            (AdapterServiceReference.GetStateOfPlayRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                //Create Service Client
                AdapterServiceReference.StateOfPlayPortTypeClient serviceClient =
                    new AdapterServiceReference.StateOfPlayPortTypeClient("StateOfPlayPortType", WebServiceUrl.Value);

                //Construct Request object
                AdapterServiceReference.GetStateOfPlayRequest request = argument;//this.MapStateOfPlayServiceRequest(argument);

                //Call soap service
                AdapterServiceReference.StateOfPlay serviceResult = serviceClient.GetStateOfPlay(request);

                if (LogResultData.Value.Equals("true"))
                {
                    LogData(aditionalParameters, new {
                        Request = request.XmlSerialize(),
                        OriginalResult = serviceResult.XmlSerialize(),
                        Guid = id
                    });
                }

                XMLSchemas.StateOfPlay adapterResult = new XMLSchemas.StateOfPlay();
                AdapterServiceReference.StateOfPlay adapterRes;

                if (serviceResult != null
                    && !(serviceResult.AccountingRecordForm == null && serviceResult.ActivityDate == null
                    && serviceResult.AdditionalActivities2008 == null && serviceResult.Assignee == null
                    && serviceResult.Belonging == null && serviceResult.CollectiveBodies == null
                    && serviceResult.Event == null && serviceResult.FundingSources == null
                    && serviceResult.Installments == null && serviceResult.LifeTime == null
                    && serviceResult.MainActivity2003 == null && serviceResult.MainActivity2008 == null
                    && serviceResult.Managers == null && serviceResult.OwnershipForms == null
                    && serviceResult.Partners == null && serviceResult.Professions == null
                    && serviceResult.RepresentationType == null && serviceResult.ScopeOfActivity == null
                    && serviceResult.State == null && serviceResult.Subject == null
                    )
                    )
                {
                    // Create 3 mappers because the object is too large and causes StackOverflowException!
                    ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay> mapper1 = CreateGetStateOfPlayFirstMapper(accessMatrix);
                    ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay> mapper2 = CreateGetStateOfPlaySecondMapper(accessMatrix);
                    ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay> mapper3 = CreateGetStateOfPlayThirdMapper(accessMatrix);

                    // Map the results to the data

                    mapper1.Map(serviceResult, adapterResult);
                    mapper2.Map(serviceResult, adapterResult);
                    mapper3.Map(serviceResult, adapterResult);
                    adapterRes = GetStateOfPlayResult(adapterResult);
                }
                else
                {
                    adapterRes = new AdapterServiceReference.StateOfPlay();
                }

                
                return
                     SigningUtils.CreateAndSign(
                         argument,
                         adapterRes,
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

        public CommonSignedResponse<GetActualUICInfoRequestType, GetActualUICInfoResponseType> GetActualUICInfo(GetActualUICInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                //Client
                //MedicinalProductsRegistersConServiceClient client = new MedicinalProductsRegistersConServiceClient(MedicinalProductsRegistersConServiceClient.EndpointConfiguration.MedicinalProductsRegistersConServiceImplPort, WebServiceUrl.Value);
                
                //Service request
                //getMedicinalProductDataConRequest serviceRequest = new getMedicinalProductDataConRequest()
                //{
                //    medicinalProductIdentifier = long.Parse(argument.MedicinalProductIdentifier)
                //};

                //Service response
                //Task<getMedicinalProductDataConResponse> serviceResponse = client.getMedicinalProductDataConAsync(serviceRequest.medicinalProductIdentifier);
                //Task.WaitAll();

                //ObjectMapper<medicinalProductDataCon, GetActualUICInfoResponseType> mapper = CreateGetActualUICInfoDataMapper(accessMatrix);
                var result = new GetActualUICInfoResponseType();
                //mapper.Map(serviceResponse.Result.@return, result);
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
        private AdapterServiceReference.StateOfPlay GetStateOfPlayResult(XMLSchemas.StateOfPlay adapterResponse)
        {
            string adapterResponseXml = adapterResponse.XmlSerialize();
            string preparedXmlString = RemoveEmptyObjects(adapterResponseXml);
            return (AdapterServiceReference.StateOfPlay)preparedXmlString.XmlDeserialize(typeof(AdapterServiceReference.StateOfPlay));
        }

        private AdapterServiceReference.Nomenclatures GetNomenclaturesResult(XMLSchemas.Nomenclatures adapterResponse)
        {
            string adapterResponseXml = adapterResponse.XmlSerialize();
            string preparedXmlString = RemoveEmptyObjects(adapterResponseXml);
            return (AdapterServiceReference.Nomenclatures)preparedXmlString.XmlDeserialize(typeof(AdapterServiceReference.Nomenclatures));
        }

        private string RemoveEmptyObjects(string adapterResponseXml)
        {
            XDocument firstDoc = XDocument.Parse(adapterResponseXml);

            //Обхождаме всички Nodes, от най-вътрешните към най-външните (see Reverse) и ако текущия node е празен го изтриваме
            foreach (var child in firstDoc.Descendants().Reverse())
            {
                if (!child.HasElements && string.IsNullOrEmpty(child.Value))
                    child.Remove();
            }

            string preparedXmlString = firstDoc.Declaration + firstDoc.ToString();
            //firstDoc.Root

            return preparedXmlString;
        }

        public CommonSignedResponse<XMLSchemas.FetchNomenclatures, AdapterServiceReference.Nomenclatures> FetchNomenclatures
            (XMLSchemas.FetchNomenclatures argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                //Create Service Client
                AdapterServiceReference.StateOfPlayPortTypeClient serviceClient =
                    new AdapterServiceReference.StateOfPlayPortTypeClient("StateOfPlayPortType", WebServiceUrl.Value);

                //Call web service
                var countryMultilangNomElements = serviceClient.FetchNomenclatures();
                if (LogResultData.Value.Equals("true"))
                {
                    LogData(aditionalParameters, new { OriginalResult = countryMultilangNomElements.XmlSerialize(), Guid = id });
                }
                AdapterServiceReference.Nomenclatures adapterRes;
                XMLSchemas.Nomenclatures adapterResult = new XMLSchemas.Nomenclatures();
                if (countryMultilangNomElements != null)
                {
                    //Create mappers for elements
                    ObjectMapper<AdapterServiceReference.Nomenclatures, XMLSchemas.Nomenclatures> nomenclaturesMapper = CreateFetchNomenclaturesMapper(accessMatrix);

                    //Map from service reference result to Adapter result
                    nomenclaturesMapper.Map(countryMultilangNomElements, adapterResult);
                    adapterRes = GetNomenclaturesResult(adapterResult);
                }
                else
                {
                    adapterRes = new AdapterServiceReference.Nomenclatures();
                }

                return
                     SigningUtils.CreateAndSign(
                         argument,
                         adapterRes,
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


        #region Helper methods and mappers


        private static ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay> CreateGetStateOfPlayFirstMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay> mapper = new ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay>(accessMatrix);

            mapper.AddObjectMap(ad => ad, s => s);

            //Map AccountingRecordForm - Форма на счетоводно записване (форма на собственост, разкодира се през номенклатурата “Форма на счетоводно записване”)
            mapper.AddObjectMap(ad => ad.AccountingRecordForm, s => s.AccountingRecordForm);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropAccountingRecordForm, DateTime>(ad => ad.AccountingRecordForm.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.AccountingRecordForm.EntryTime, s => s.AccountingRecordForm.EntryTime);
            //mapper.AddPropertyMap(ad => ad.AccountingRecordForm.EntryTimeSpecified, s => s.AccountingRecordForm.EntryTimeSpecified);

            mapper.AddObjectMap(ad => ad.AccountingRecordForm.Form, s => s.AccountingRecordForm.Form);
            mapper.AddPropertyMap(ad => ad.AccountingRecordForm.Form.Code, s => s.AccountingRecordForm.Form.Code);

            //Map ActivityDate - (присъща само за Физически лица) - Дата на започване/ спиране/ възобновяване на дейността (дата и вид, който се разкодира през номенклатурата „Вид дата“)
            mapper.AddObjectMap(ad => ad.ActivityDate, s => s.ActivityDate);
            mapper.AddPropertyMap(ad => ad.ActivityDate.Date, s => s.ActivityDate.Date);
            //apper.AddPropertyMap(ad => ad.ActivityDate.DateSpecified, s => s.ActivityDate.DateSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropActivityDate, DateTime>(ad => ad.ActivityDate.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
           // mapper.AddPropertyMap(ad => ad.ActivityDate.EntryTime, s => s.ActivityDate.EntryTime);
           // mapper.AddPropertyMap(ad => ad.ActivityDate.EntryTimeSpecified, s => s.ActivityDate.EntryTimeSpecified);

            mapper.AddObjectMap(ad => ad.ActivityDate.Type, s => s.ActivityDate.Type);
            mapper.AddPropertyMap(ad => ad.ActivityDate.Type.Code, s => s.ActivityDate.Type.Code);

            //Map AdditionalActivities2008 - (присъща само за Физически лица) - Допълнителни дейности по КИД2008 (код, който се разкодира през класификатора за икономическите дейности “КИД2008”)
            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.AdditionalActivities2008, s => s.AdditionalActivities2008);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropActivityKID2008, DateTime>(ad => ad.AdditionalActivities2008[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
           // mapper.AddPropertyMap(ad => ad.AdditionalActivities2008[0].EntryTime, s => s.AdditionalActivities2008[0].EntryTime);
           // mapper.AddPropertyMap(ad => ad.AdditionalActivities2008[0].EntryTimeSpecified, s => s.AdditionalActivities2008[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.AdditionalActivities2008[0].KID2008, s => s.AdditionalActivities2008[0].KID2008);
            mapper.AddPropertyMap(ad => ad.AdditionalActivities2008[0].KID2008.Code, s => s.AdditionalActivities2008[0].KID2008.Code);

            #region Mapping Assignee - Правоприемство

            //Map Assignee - Правоприемство (правоприемник; вид правоприемство, разкодира се през номенклатурата „Вид правоприемство“)
            mapper.AddObjectMap(ad => ad.Assignee, s => s.Assignee);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelAssignee, DateTime>(ad => ad.Assignee.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.EntryTime, s => s.Assignee.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.EntryTimeSpecified, s => s.Assignee.EntryTimeSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelAssignee, XMLSchemas.SubscriptionElementOperationType>(
                ad => ad.Assignee.OperationType,
                s => s.OperationTypeSpecified ? (XMLSchemas.SubscriptionElementOperationType)Enum.Parse(typeof(XMLSchemas.SubscriptionElementOperationType), s.OperationType.ToString()) : (XMLSchemas.SubscriptionElementOperationType?)null);
            mapper.AddObjectMap(ad => ad.Assignee.Type, s => s.Assignee.Type);
            mapper.AddPropertyMap(ad => ad.Assignee.Type.Code, s => s.Assignee.Type.Code);
            
            #region Mapping Assignee.RelatedSubjects

            //Map Assignee.RelatedSubjects - Свързан субект - правоприемник
            mapper.AddCollectionMap<AdapterServiceReference.SubjectRelAssignee>(ad => ad.Assignee.RelatedSubjects, s => s.RelatedSubjects);

            //Map Assignee.RelatedSubjects.Addresses - Адреси на свързан субект
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Assignee.RelatedSubjects[0].Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].AddressType, s => s.Assignee.RelatedSubjects[0].Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].AddressType.Code, s => s.Assignee.RelatedSubjects[0].Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Apartment, s => s.Assignee.RelatedSubjects[0].Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Building, s => s.Assignee.RelatedSubjects[0].Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Country, s => s.Assignee.RelatedSubjects[0].Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Country.Code, s => s.Assignee.RelatedSubjects[0].Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Entrance, s => s.Assignee.RelatedSubjects[0].Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].EntryTime, s => s.Assignee.RelatedSubjects[0].Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].EntryTimeSpecified, s => s.Assignee.RelatedSubjects[0].Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Floor, s => s.Assignee.RelatedSubjects[0].Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].ForeignLocation, s => s.Assignee.RelatedSubjects[0].Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Location, s => s.Assignee.RelatedSubjects[0].Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Location.Code, s => s.Assignee.RelatedSubjects[0].Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].PostalBox, s => s.Assignee.RelatedSubjects[0].Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].PostalCode, s => s.Assignee.RelatedSubjects[0].Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Region, s => s.Assignee.RelatedSubjects[0].Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Region.Code, s => s.Assignee.RelatedSubjects[0].Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].Street, s => s.Assignee.RelatedSubjects[0].Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Addresses[0].StreetNumber, s => s.Assignee.RelatedSubjects[0].Addresses[0].StreetNumber);

            //Map Assignee.RelatedSubjects.Communications - Комуникации на свързан субект
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Assignee.RelatedSubjects[0].Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.Assignee.RelatedSubjects[0].Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Communications[0].EntryTime, s => s.Assignee.RelatedSubjects[0].Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Communications[0].EntryTimeSpecified, s => s.Assignee.RelatedSubjects[0].Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].Communications[0].Type, s => s.Assignee.RelatedSubjects[0].Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Communications[0].Type.Code, s => s.Assignee.RelatedSubjects[0].Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Communications[0].Value, s => s.Assignee.RelatedSubjects[0].Communications[0].Value);

            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].CountrySubject, s => s.Assignee.RelatedSubjects[0].CountrySubject);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].CountrySubject.Code, s => s.Assignee.RelatedSubjects[0].CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.Assignee.RelatedSubjects[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].EntryTime, s => s.Assignee.RelatedSubjects[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].EntryTimeSpecified, s => s.Assignee.RelatedSubjects[0].EntryTimeSpecified);

            //TODO: Assignee.RelatedSubjects.LegalEntitySubject - Данни за свързан субект - ако е Нефизическо лице
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.Country, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.Country.Code, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.CyrillicFullName, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.CyrillicShortName, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.EntryTime, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.EntryTimeSpecified, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.LatinFullName, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalForm, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalForm.Code, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalStatute, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalStatute.Code, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.SubjectGroup, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.SubjectGroup.Code, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.SubordinateLevel, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.SubordinateLevel.Code, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].LegalEntitySubject.TRStatus, s => s.Assignee.RelatedSubjects[0].LegalEntitySubject.TRStatus);

            //Map Assignee.RelatedSubjects.NaturalPersonSubject - Данни за свързан субект - ако е Физическо лице
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.BirthDate, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.BirthDate);
           // mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.BirthDateSpecified, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.Country, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.Country.Code, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.CyrillicName, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.EGN, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.EntryTime, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.EntryTimeSpecified, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.LatinName, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.LNC, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.LNC);

            //Map Assignee.RelatedSubjects.NaturalPersonSubject.IdentificationDoc - Данни за документ за самоличност на свързан субект - ако е Физическо лице
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDate);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDate);
           // mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.Assignee.RelatedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].Remark, s => s.Assignee.RelatedSubjects[0].Remark);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].SubjectType, s => s.Assignee.RelatedSubjects[0].SubjectType);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].SubjectType.Code, s => s.Assignee.RelatedSubjects[0].SubjectType.Code);

            //Map Assignee.RelatedSubjects.UIC - Код по БУЛСТАТ на свързан субект
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].UIC, s => s.Assignee.RelatedSubjects[0].UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.Assignee.RelatedSubjects[0].UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].UIC.EntryTime, s => s.Assignee.RelatedSubjects[0].UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].UIC.EntryTimeSpecified, s => s.Assignee.RelatedSubjects[0].UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].UIC.UIC1, s => s.Assignee.RelatedSubjects[0].UIC.UIC1);
            mapper.AddObjectMap(ad => ad.Assignee.RelatedSubjects[0].UIC.UICType, s => s.Assignee.RelatedSubjects[0].UIC.UICType);
            mapper.AddPropertyMap(ad => ad.Assignee.RelatedSubjects[0].UIC.UICType.Code, s => s.Assignee.RelatedSubjects[0].UIC.UICType.Code);
            #endregion

            #endregion

            #region Mapping Belonging - Принадлежност

            //Map Belonging - Принадлежност на субект
            mapper.AddObjectMap(ad => ad.Belonging, s => s.Belonging);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelBelonging, DateTime>(ad => ad.Belonging.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.EntryTime, s => s.Belonging.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.EntryTimeSpecified, s => s.Belonging.EntryTimeSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelBelonging, SubscriptionElementOperationType>(
                ad => ad.Belonging.OperationType,
                s => s.OperationTypeSpecified ? (SubscriptionElementOperationType)Enum.Parse(typeof(SubscriptionElementOperationType), s.OperationType.ToString()) : (SubscriptionElementOperationType?)null);
            mapper.AddObjectMap(ad => ad.Belonging.Type, s => s.Belonging.Type);
            mapper.AddPropertyMap(ad => ad.Belonging.Type.Code, s => s.Belonging.Type.Code);

            #region Belonging.RelatedSubject
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject, s => s.Belonging.RelatedSubject);

            //Map Belonging.RelatedSubject.Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Belonging.RelatedSubject.Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.Addresses[0].AddressType, s => s.Belonging.RelatedSubject.Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].AddressType.Code, s => s.Belonging.RelatedSubject.Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Apartment, s => s.Belonging.RelatedSubject.Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Building, s => s.Belonging.RelatedSubject.Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Country, s => s.Belonging.RelatedSubject.Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Country.Code, s => s.Belonging.RelatedSubject.Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Entrance, s => s.Belonging.RelatedSubject.Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.Belonging.RelatedSubject.Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].EntryTime, s => s.Belonging.RelatedSubject.Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].EntryTimeSpecified, s => s.Belonging.RelatedSubject.Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Floor, s => s.Belonging.RelatedSubject.Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].ForeignLocation, s => s.Belonging.RelatedSubject.Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Location, s => s.Belonging.RelatedSubject.Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Location.Code, s => s.Belonging.RelatedSubject.Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].PostalBox, s => s.Belonging.RelatedSubject.Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].PostalCode, s => s.Belonging.RelatedSubject.Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Region, s => s.Belonging.RelatedSubject.Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Region.Code, s => s.Belonging.RelatedSubject.Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].Street, s => s.Belonging.RelatedSubject.Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Addresses[0].StreetNumber, s => s.Belonging.RelatedSubject.Addresses[0].StreetNumber);

            //Map Belonging.RelatedSubject.Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Belonging.RelatedSubject.Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.Belonging.RelatedSubject.Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Communications[0].EntryTime, s => s.Belonging.RelatedSubject.Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Communications[0].EntryTimeSpecified, s => s.Belonging.RelatedSubject.Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.Communications[0].Type, s => s.Belonging.RelatedSubject.Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Communications[0].Type.Code, s => s.Belonging.RelatedSubject.Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Communications[0].Value, s => s.Belonging.RelatedSubject.Communications[0].Value);

            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.CountrySubject, s => s.Belonging.RelatedSubject.CountrySubject);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.CountrySubject.Code, s => s.Belonging.RelatedSubject.CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.Belonging.RelatedSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.EntryTime, s => s.Belonging.RelatedSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.EntryTimeSpecified, s => s.Belonging.RelatedSubject.EntryTimeSpecified);

            //Map Belonging.RelatedSubject.LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject, s => s.Belonging.RelatedSubject.LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.Country, s => s.Belonging.RelatedSubject.LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.Country.Code, s => s.Belonging.RelatedSubject.LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.CyrillicFullName, s => s.Belonging.RelatedSubject.LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.CyrillicShortName, s => s.Belonging.RelatedSubject.LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.EntryTime, s => s.Belonging.RelatedSubject.LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.EntryTimeSpecified, s => s.Belonging.RelatedSubject.LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.LatinFullName, s => s.Belonging.RelatedSubject.LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.LegalForm, s => s.Belonging.RelatedSubject.LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.LegalForm.Code, s => s.Belonging.RelatedSubject.LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.LegalStatute, s => s.Belonging.RelatedSubject.LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.LegalStatute.Code, s => s.Belonging.RelatedSubject.LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.SubjectGroup, s => s.Belonging.RelatedSubject.LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.SubjectGroup.Code, s => s.Belonging.RelatedSubject.LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.SubordinateLevel, s => s.Belonging.RelatedSubject.LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.SubordinateLevel.Code, s => s.Belonging.RelatedSubject.LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.LegalEntitySubject.TRStatus, s => s.Belonging.RelatedSubject.LegalEntitySubject.TRStatus);

            //Map Belonging.RelatedSubject.NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject, s => s.Belonging.RelatedSubject.NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.BirthDate, s => s.Belonging.RelatedSubject.NaturalPersonSubject.BirthDate);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.BirthDateSpecified, s => s.Belonging.RelatedSubject.NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.Country, s => s.Belonging.RelatedSubject.NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.Country.Code, s => s.Belonging.RelatedSubject.NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.CyrillicName, s => s.Belonging.RelatedSubject.NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.EGN, s => s.Belonging.RelatedSubject.NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.EntryTime, s => s.Belonging.RelatedSubject.NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.EntryTimeSpecified, s => s.Belonging.RelatedSubject.NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.LatinName, s => s.Belonging.RelatedSubject.NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.LNC, s => s.Belonging.RelatedSubject.NaturalPersonSubject.LNC);

            //Map Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate);
           // mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.Belonging.RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.Remark, s => s.Belonging.RelatedSubject.Remark);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.SubjectType, s => s.Belonging.RelatedSubject.SubjectType);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.SubjectType.Code, s => s.Belonging.RelatedSubject.SubjectType.Code);

            //Map Belonging.RelatedSubject.UIC
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.UIC, s => s.Belonging.RelatedSubject.UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.Belonging.RelatedSubject.UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.UIC.EntryTime, s => s.Belonging.RelatedSubject.UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.UIC.EntryTimeSpecified, s => s.Belonging.RelatedSubject.UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.UIC.UIC1, s => s.Belonging.RelatedSubject.UIC.UIC1);
            mapper.AddObjectMap(ad => ad.Belonging.RelatedSubject.UIC.UICType, s => s.Belonging.RelatedSubject.UIC.UICType);
            mapper.AddPropertyMap(ad => ad.Belonging.RelatedSubject.UIC.UICType.Code, s => s.Belonging.RelatedSubject.UIC.UICType.Code);

            #endregion

            #endregion

            return mapper;
        }

        private static ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay> CreateGetStateOfPlaySecondMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<AdapterServiceReference.StateOfPlay, StateOfPlay> mapper = new ObjectMapper<AdapterServiceReference.StateOfPlay, StateOfPlay>(accessMatrix);
            mapper.AddObjectMap(ad => ad, s => s);

            #region Mapping Collective Bodies - Колективни органи

            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.CollectiveBodies, s => s.CollectiveBodies);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropCollectiveBody, DateTime>(ad => ad.CollectiveBodies[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].EntryTime, s => s.CollectiveBodies[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].EntryTimeSpecified, s => s.CollectiveBodies[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Type, s => s.CollectiveBodies[0].Type);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Type.Code, s => s.CollectiveBodies[0].Type.Code);

            mapper.AddCollectionMap<AdapterServiceReference.SubjectPropCollectiveBody>(ad => ad.CollectiveBodies[0].Members, s => s.Members);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelCollectiveBodyMember, DateTime>(ad => ad.CollectiveBodies[0].Members[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].EntryTime, s => s.CollectiveBodies[0].Members[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].EntryTimeSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelCollectiveBodyMember, SubscriptionElementOperationType>
                (ad => ad.CollectiveBodies[0].Members[0].OperationType,
                 s => s.OperationTypeSpecified ? (SubscriptionElementOperationType)Enum.Parse(typeof(SubscriptionElementOperationType), s.OperationType.ToString()) : (SubscriptionElementOperationType?)null);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].Position, s => s.CollectiveBodies[0].Members[0].Position);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].Position.Code, s => s.CollectiveBodies[0].Members[0].Position.Code);

            #region Mapping CollectiveBodies.Members.RelatedSubject

            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject, s => s.CollectiveBodies[0].Members[0].RelatedSubject);

            //Map CollectiveBodies.Members.RelatedSubject.Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].AddressType, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].AddressType.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Apartment, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Building, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Country, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Country.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Entrance, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].EntryTime, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Floor, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].ForeignLocation, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Location, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Location.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].PostalBox, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].PostalCode, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Region, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Region.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Street, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].StreetNumber, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Addresses[0].StreetNumber);

            //Map CollectiveBodies.Members.RelatedSubject.Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].EntryTime, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].Type, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].Type.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].Value, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Communications[0].Value);

            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.CountrySubject, s => s.CollectiveBodies[0].Members[0].RelatedSubject.CountrySubject);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.CountrySubject.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.EntryTime, s => s.CollectiveBodies[0].Members[0].RelatedSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.EntryTimeSpecified);

            //Map CollectiveBodies.Members.RelatedSubject.LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.Country, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.Country.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.CyrillicFullName, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.CyrillicShortName, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.EntryTime, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LatinFullName, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalForm, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalForm.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalStatute, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalStatute.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubjectGroup, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubjectGroup.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubordinateLevel, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubordinateLevel.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.TRStatus, s => s.CollectiveBodies[0].Members[0].RelatedSubject.LegalEntitySubject.TRStatus);

            //Map CollectiveBodies.Members.RelatedSubject.NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.BirthDate, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.BirthDate);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.BirthDateSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.Country, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.Country.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.CyrillicName, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.EGN, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.EntryTime, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.LatinName, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.LNC, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.LNC);

            //Map CollectiveBodies.Members.RelatedSubject.NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate);
           // mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate);
           // mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.Remark, s => s.CollectiveBodies[0].Members[0].RelatedSubject.Remark);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.SubjectType, s => s.CollectiveBodies[0].Members[0].RelatedSubject.SubjectType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.SubjectType.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.SubjectType.Code);

            //Map CollectiveBodies.Members.RelatedSubject.UIC
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.UIC, s => s.CollectiveBodies[0].Members[0].RelatedSubject.UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.UIC.EntryTime, s => s.CollectiveBodies[0].Members[0].RelatedSubject.UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.UIC.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RelatedSubject.UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.UIC.UIC1, s => s.CollectiveBodies[0].Members[0].RelatedSubject.UIC.UIC1);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.UIC.UICType, s => s.CollectiveBodies[0].Members[0].RelatedSubject.UIC.UICType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RelatedSubject.UIC.UICType.Code, s => s.CollectiveBodies[0].Members[0].RelatedSubject.UIC.UICType.Code);



            #endregion

            #region Mapping CollectiveBodies.Members.RepresentSubjects

            mapper.AddCollectionMap<AdapterServiceReference.SubjectRelCollectiveBodyMember>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects, s => s.RepresentedSubjects);

            //Map CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].AddressType, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].AddressType.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Apartment, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Building, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Country, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Country.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Entrance, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].EntryTime, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Floor, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].ForeignLocation, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Location, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Location.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].PostalBox, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].PostalCode, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Region, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Region.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Street, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].StreetNumber, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Addresses[0].StreetNumber);

            //Map CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].EntryTime, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].Type, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].Type.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].Value, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Communications[0].Value);

            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].CountrySubject, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].CountrySubject);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].CountrySubject.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].EntryTime, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].EntryTimeSpecified);

            //Map CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.Country, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.Country.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicFullName, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicShortName, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.EntryTime, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LatinFullName, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.TRStatus, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].LegalEntitySubject.TRStatus);

            //Map CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDate, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDate);
           // mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDateSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.Country, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.Country.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.CyrillicName, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.EGN, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTime, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.LatinName, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.LNC, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.LNC);

            //Map CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDate);
           // mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDate);
          //  mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Remark, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].Remark);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].SubjectType, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].SubjectType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].SubjectType.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].SubjectType.Code);

            //Map CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.EntryTime, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.EntryTimeSpecified, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.UIC1, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.UIC1);
            mapper.AddObjectMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.UICType, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.UICType);
            mapper.AddPropertyMap(ad => ad.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.UICType.Code, s => s.CollectiveBodies[0].Members[0].RepresentedSubjects[0].UIC.UICType.Code);


            #endregion

            #endregion

            #region Mapping Event - Събитие

            mapper.AddObjectMap(ad => ad.Event, s => s.Event);

            //Map Event.Case
            mapper.AddObjectMap(ad => ad.Event.Case, s => s.Event.Case);
            mapper.AddPropertyMap(ad => ad.Event.Case.Batch, s => s.Event.Case.Batch);
            mapper.AddPropertyMap(ad => ad.Event.Case.Chapter, s => s.Event.Case.Chapter);
            mapper.AddObjectMap(ad => ad.Event.Case.Court, s => s.Event.Case.Court);
            mapper.AddPropertyMap(ad => ad.Event.Case.Court.Code, s => s.Event.Case.Court.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Case, DateTime>(ad => ad.Event.Case.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Case.EntryTime, s => s.Event.Case.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Case.EntryTimeSpecified, s => s.Event.Case.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Case.Number, s => s.Event.Case.Number);
            mapper.AddFunctionMapNull<AdapterServiceReference.Case, int>(ad => ad.Event.Case.PageNumber, s => (int?)s.GetValueOrNull(t => t.PageNumber, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Case.PageNumber, s => s.Event.Case.PageNumber);
            //mapper.AddPropertyMap(ad => ad.Event.Case.PageNumberSpecified, s => s.Event.Case.PageNumberSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.Case, int>(ad => ad.Event.Case.Register, s => (int?)s.GetValueOrNull(t => t.Register, isFromDb: false));

            //mapper.AddPropertyMap(ad => ad.Event.Case.Register, s => s.Event.Case.Register);
            //mapper.AddPropertyMap(ad => ad.Event.Case.RegisterSpecified, s => s.Event.Case.RegisterSpecified);

            mapper.AddFunctionMapNull<AdapterServiceReference.Case, int>(ad => ad.Event.Case.Year, s => (int?)s.GetValueOrNull(t => t.Year, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Case.Year, s => s.Event.Case.Year);
            //mapper.AddPropertyMap(ad => ad.Event.Case.YearSpecified, s => s.Event.Case.YearSpecified);

            //Map Event.Document
            mapper.AddObjectMap(ad => ad.Event.Document, s => s.Event.Document);
            mapper.AddPropertyMap(ad => ad.Event.Document.AuthorName, s => s.Event.Document.AuthorName);
            mapper.AddPropertyMap(ad => ad.Event.Document.DocumentDate, s => s.Event.Document.DocumentDate);
            //mapper.AddPropertyMap(ad => ad.Event.Document.DocumentDateSpecified, s => s.Event.Document.DocumentDateSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.DocumentName, s => s.Event.Document.DocumentName);
            mapper.AddPropertyMap(ad => ad.Event.Document.DocumentNumber, s => s.Event.Document.DocumentNumber);
            mapper.AddObjectMap(ad => ad.Event.Document.DocumentType, s => s.Event.Document.DocumentType);
            mapper.AddPropertyMap(ad => ad.Event.Document.DocumentType.Code, s => s.Event.Document.DocumentType.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Document, DateTime>(ad => ad.Event.Document.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.EntryTime, s => s.Event.Document.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.EntryTimeSpecified, s => s.Event.Document.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.ValidFromDate, s => s.Event.Document.ValidFromDate);
            //mapper.AddPropertyMap(ad => ad.Event.Document.ValidFromDateSpecified, s => s.Event.Document.ValidFromDateSpecified);

            #region Mapping Event.Document.Author

            //Map Event.Document.Author
            mapper.AddObjectMap(ad => ad.Event.Document.Author, s => s.Event.Document.Author);

            //Map Event.Document.Author.Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Event.Document.Author.Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.Addresses[0].AddressType, s => s.Event.Document.Author.Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].AddressType.Code, s => s.Event.Document.Author.Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Apartment, s => s.Event.Document.Author.Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Building, s => s.Event.Document.Author.Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.Addresses[0].Country, s => s.Event.Document.Author.Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Country.Code, s => s.Event.Document.Author.Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Entrance, s => s.Event.Document.Author.Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.Event.Document.Author.Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].EntryTime, s => s.Event.Document.Author.Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].EntryTimeSpecified, s => s.Event.Document.Author.Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Floor, s => s.Event.Document.Author.Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].ForeignLocation, s => s.Event.Document.Author.Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.Addresses[0].Location, s => s.Event.Document.Author.Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Location.Code, s => s.Event.Document.Author.Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].PostalBox, s => s.Event.Document.Author.Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].PostalCode, s => s.Event.Document.Author.Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.Addresses[0].Region, s => s.Event.Document.Author.Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Region.Code, s => s.Event.Document.Author.Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].Street, s => s.Event.Document.Author.Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Addresses[0].StreetNumber, s => s.Event.Document.Author.Addresses[0].StreetNumber);

            //Map Event.Document.Author.Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Event.Document.Author.Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.Event.Document.Author.Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.Communications[0].EntryTime, s => s.Event.Document.Author.Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.Communications[0].EntryTimeSpecified, s => s.Event.Document.Author.Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.Communications[0].Type, s => s.Event.Document.Author.Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Communications[0].Type.Code, s => s.Event.Document.Author.Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Communications[0].Value, s => s.Event.Document.Author.Communications[0].Value);

            mapper.AddObjectMap(ad => ad.Event.Document.Author.CountrySubject, s => s.Event.Document.Author.CountrySubject);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.CountrySubject.Code, s => s.Event.Document.Author.CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.Event.Document.Author.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.EntryTime, s => s.Event.Document.Author.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.EntryTimeSpecified, s => s.Event.Document.Author.EntryTimeSpecified);

            //Map Event.Document.Author.LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.Event.Document.Author.LegalEntitySubject, s => s.Event.Document.Author.LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.LegalEntitySubject.Country, s => s.Event.Document.Author.LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.Country.Code, s => s.Event.Document.Author.LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.CyrillicFullName, s => s.Event.Document.Author.LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.CyrillicShortName, s => s.Event.Document.Author.LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.Event.Document.Author.LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.EntryTime, s => s.Event.Document.Author.LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.EntryTimeSpecified, s => s.Event.Document.Author.LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.LatinFullName, s => s.Event.Document.Author.LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.LegalEntitySubject.LegalForm, s => s.Event.Document.Author.LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.LegalForm.Code, s => s.Event.Document.Author.LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.LegalEntitySubject.LegalStatute, s => s.Event.Document.Author.LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.LegalStatute.Code, s => s.Event.Document.Author.LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.LegalEntitySubject.SubjectGroup, s => s.Event.Document.Author.LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.SubjectGroup.Code, s => s.Event.Document.Author.LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.LegalEntitySubject.SubordinateLevel, s => s.Event.Document.Author.LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.SubordinateLevel.Code, s => s.Event.Document.Author.LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.LegalEntitySubject.TRStatus, s => s.Event.Document.Author.LegalEntitySubject.TRStatus);

            //Map Event.Document.Author.NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.Event.Document.Author.NaturalPersonSubject, s => s.Event.Document.Author.NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.BirthDate, s => s.Event.Document.Author.NaturalPersonSubject.BirthDate);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.BirthDateSpecified, s => s.Event.Document.Author.NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.NaturalPersonSubject.Country, s => s.Event.Document.Author.NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.Country.Code, s => s.Event.Document.Author.NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.CyrillicName, s => s.Event.Document.Author.NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.EGN, s => s.Event.Document.Author.NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.Event.Document.Author.NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.EntryTime, s => s.Event.Document.Author.NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.EntryTimeSpecified, s => s.Event.Document.Author.NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.LatinName, s => s.Event.Document.Author.NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.LNC, s => s.Event.Document.Author.NaturalPersonSubject.LNC);

            //Map Event.Document.Author.NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.Country, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.ExpiryDate);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IDType, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IssueDate);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.Event.Document.Author.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.Event.Document.Author.Remark, s => s.Event.Document.Author.Remark);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.SubjectType, s => s.Event.Document.Author.SubjectType);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.SubjectType.Code, s => s.Event.Document.Author.SubjectType.Code);

            //Map Event.Document.Author.UIC
            mapper.AddObjectMap(ad => ad.Event.Document.Author.UIC, s => s.Event.Document.Author.UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.Event.Document.Author.UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.UIC.EntryTime, s => s.Event.Document.Author.UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.Document.Author.UIC.EntryTimeSpecified, s => s.Event.Document.Author.UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.UIC.UIC1, s => s.Event.Document.Author.UIC.UIC1);
            mapper.AddObjectMap(ad => ad.Event.Document.Author.UIC.UICType, s => s.Event.Document.Author.UIC.UICType);
            mapper.AddPropertyMap(ad => ad.Event.Document.Author.UIC.UICType.Code, s => s.Event.Document.Author.UIC.UICType.Code);


            #endregion

            mapper.AddFunctionMapNull<AdapterServiceReference.Event, DateTime>(ad => ad.Event.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Event.EntryTime, s => s.Event.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Event.EntryTimeSpecified, s => s.Event.EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Event.EntryType, s => s.Event.EntryType);
            mapper.AddPropertyMap(ad => ad.Event.EntryType.Code, s => s.Event.EntryType.Code);
            mapper.AddPropertyMap(ad => ad.Event.EventDate, s => s.Event.EventDate);
            //mapper.AddPropertyMap(ad => ad.Event.EventDateSpecified, s => s.Event.EventDateSpecified);
            mapper.AddObjectMap(ad => ad.Event.EventType, s => s.Event.EventType);
            mapper.AddPropertyMap(ad => ad.Event.EventType.Code, s => s.Event.EventType.Code);
            mapper.AddObjectMap(ad => ad.Event.LegalBase, s => s.Event.LegalBase);
            mapper.AddPropertyMap(ad => ad.Event.LegalBase.Code, s => s.Event.LegalBase.Code);

            #endregion

            #region FundingSources - Източници на финансиране

            //Mapping FundingSources - Източници на финансиране
            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.FundingSources, s => s.FundingSources);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropFundingSource, DateTime>(ad => ad.FundingSources[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.FundingSources[0].EntryTime, s => s.FundingSources[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.FundingSources[0].EntryTimeSpecified, s => s.FundingSources[0].EntryTimeSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropFundingSource, decimal>(ad => ad.FundingSources[0].Percent, s => (decimal?)s.GetValueOrNull(t => t.Percent, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.FundingSources[0].Percent, s => s.FundingSources[0].Percent);
            //mapper.AddPropertyMap(ad => ad.FundingSources[0].PercentSpecified, s => s.FundingSources[0].PercentSpecified);
            mapper.AddObjectMap(ad => ad.FundingSources[0].Source, s => s.FundingSources[0].Source);
            mapper.AddPropertyMap(ad => ad.FundingSources[0].Source.Code, s => s.FundingSources[0].Source.Code);

            #endregion

            #region Installments - Вноски

            //Mapping Installments - Вноски
            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.Installments, s => s.Installments);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropInstallments, decimal>(ad => ad.Installments[0].Amount, s => (decimal?)s.GetValueOrNull(t => t.Amount, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Installments[0].Amount, s => s.Installments[0].Amount);
            //mapper.AddPropertyMap(ad => ad.Installments[0].AmountSpecified, s => s.Installments[0].AmountSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropInstallments, int>(ad => ad.Installments[0].Count, s => (int?)s.GetValueOrNull(t => t.Count, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Installments[0].Count, s => s.Installments[0].Count);
            //mapper.AddPropertyMap(ad => ad.Installments[0].CountSpecified, s => s.Installments[0].CountSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropInstallments, DateTime>(ad => ad.Installments[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Installments[0].EntryTime, s => s.Installments[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Installments[0].EntryTimeSpecified, s => s.Installments[0].EntryTimeSpecified);

            #endregion

            return mapper;
        }

        private static ObjectMapper<AdapterServiceReference.Nomenclatures, XMLSchemas.Nomenclatures> CreateFetchNomenclaturesMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<AdapterServiceReference.Nomenclatures, Nomenclatures> mapper =
                new ObjectMapper<AdapterServiceReference.Nomenclatures, Nomenclatures>(accessMatrix);

            mapper.AddObjectMap((o) => o, c => c);

            //SimpleNomenclature
            mapper.AddCollectionMap<AdapterServiceReference.Nomenclatures>((o) => o.SimpleNomenclature, c => c.SimpleNomenclature);

            mapper.AddObjectMap((o) => o.SimpleNomenclature[0].Definition, c => c.SimpleNomenclature[0].Definition);
            mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].Definition.Code, c => c.SimpleNomenclature[0].Definition.Code);
            mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].Definition.Name, c => c.SimpleNomenclature[0].Definition.Name);

            mapper.AddCollectionMap<AdapterServiceReference.SimpleNomenclature>((o) => o.SimpleNomenclature[0].NomElement, c => c.NomElement);
            mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].Active, c => c.SimpleNomenclature[0].NomElement[0].Active);
            mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].Code, c => c.SimpleNomenclature[0].NomElement[0].Code);
            mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].NameBG, c => c.SimpleNomenclature[0].NomElement[0].NameBG);
            mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].NameEN, c => c.SimpleNomenclature[0].NomElement[0].NameEN);
            mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].Ordering, c => c.SimpleNomenclature[0].NomElement[0].Ordering);


            //CountryMultilangNomElement
            mapper.AddCollectionMap<AdapterServiceReference.Nomenclatures>((o) => o.CountryNomElement, c => c.CountryNomElement);

            mapper.AddPropertyMap((o) => o.CountryNomElement[0].Active, c => c.CountryNomElement[0].Active);
            mapper.AddPropertyMap((o) => o.CountryNomElement[0].Code, c => c.CountryNomElement[0].Code);
            mapper.AddPropertyMap((o) => o.CountryNomElement[0].ISO2, c => c.CountryNomElement[0].ISO2);
            mapper.AddPropertyMap((o) => o.CountryNomElement[0].ISO3, c => c.CountryNomElement[0].ISO3);
            mapper.AddPropertyMap((o) => o.CountryNomElement[0].NameBG, c => c.CountryNomElement[0].NameBG);
            mapper.AddPropertyMap((o) => o.CountryNomElement[0].NameEN, c => c.CountryNomElement[0].NameEN);
            mapper.AddPropertyMap((o) => o.CountryNomElement[0].Ordering, c => c.CountryNomElement[0].Ordering);

            return mapper;
        }

        private static ObjectMapper<AdapterServiceReference.StateOfPlay, XMLSchemas.StateOfPlay> CreateGetStateOfPlayThirdMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<AdapterServiceReference.StateOfPlay, StateOfPlay> mapper = new ObjectMapper<AdapterServiceReference.StateOfPlay, StateOfPlay>(accessMatrix);
            mapper.AddObjectMap(ad => ad, s => s);

            #region LifeTime - Срок на съществуване

            //Mapping LifeTime - Срок на съществуване
            mapper.AddObjectMap(ad => ad.LifeTime, s => s.LifeTime);
            mapper.AddPropertyMap(ad => ad.LifeTime.Date, s => s.LifeTime.Date);
            //mapper.AddPropertyMap(ad => ad.LifeTime.DateSpecified, s => s.LifeTime.DateSpecified);
            mapper.AddPropertyMap(ad => ad.LifeTime.Description, s => s.LifeTime.Description);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropLifeTime, DateTime>(ad => ad.LifeTime.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.LifeTime.EntryTime, s => s.LifeTime.EntryTime);
            //mapper.AddPropertyMap(ad => ad.LifeTime.EntryTimeSpecified, s => s.LifeTime.EntryTimeSpecified);
            #endregion

            #region MainActivity2003 - Основна дейност (НКИД2003)

            //Mapping MainActivity2003 - Основна дейност (НКИД2003)
            mapper.AddObjectMap(ad => ad.MainActivity2003, s => s.MainActivity2003);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropActivityKID2003, DateTime>(ad => ad.MainActivity2003.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.MainActivity2003.EntryTime, s => s.MainActivity2003.EntryTime);
            //mapper.AddPropertyMap(ad => ad.MainActivity2003.EntryTimeSpecified, s => s.MainActivity2003.EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.MainActivity2003.NKID2003, s => s.MainActivity2003.NKID2003);
            mapper.AddPropertyMap(ad => ad.MainActivity2003.NKID2003.Code, s => s.MainActivity2003.NKID2003.Code);

            #endregion

            #region MainActivity2008 - Основна дейност (КИД2008)

            //Mapping MainActivity2008 - Основна дейност (КИД2008)
            mapper.AddObjectMap(ad => ad.MainActivity2008, s => s.MainActivity2008);
            mapper.AddPropertyMap(ad => ad.MainActivity2008.EntryTime, s => s.MainActivity2008.EntryTime);
            mapper.AddPropertyMap(ad => ad.MainActivity2008.EntryTimeSpecified, s => s.MainActivity2008.EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.MainActivity2008.KID2008, s => s.MainActivity2008.KID2008);
            mapper.AddPropertyMap(ad => ad.MainActivity2008.KID2008.Code, s => s.MainActivity2008.KID2008.Code);

            #endregion

            #region Managers - Управители

            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.Managers, s => s.Managers);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelManager, DateTime>(ad => ad.Managers[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].EntryTime, s => s.Managers[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].EntryTimeSpecified, s => s.Managers[0].EntryTimeSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelManager, SubscriptionElementOperationType>
                (ad => ad.Managers[0].OperationType, 
                 s => s.OperationTypeSpecified ? (SubscriptionElementOperationType)Enum.Parse(typeof(SubscriptionElementOperationType), s.OperationType.ToString()) : (SubscriptionElementOperationType?)null);
            mapper.AddObjectMap(ad => ad.Managers[0].Position, s => s.Managers[0].Position);
            mapper.AddPropertyMap(ad => ad.Managers[0].Position.Code, s => s.Managers[0].Position.Code);

            #region Managers.RelatedSubject

            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject, s => s.Managers[0].RelatedSubject);

            //Map Managers.RelatedSubject.Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Managers[0].RelatedSubject.Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].AddressType, s => s.Managers[0].RelatedSubject.Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].AddressType.Code, s => s.Managers[0].RelatedSubject.Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Apartment, s => s.Managers[0].RelatedSubject.Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Building, s => s.Managers[0].RelatedSubject.Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Country, s => s.Managers[0].RelatedSubject.Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Country.Code, s => s.Managers[0].RelatedSubject.Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Entrance, s => s.Managers[0].RelatedSubject.Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.Managers[0].RelatedSubject.Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].EntryTime, s => s.Managers[0].RelatedSubject.Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].EntryTimeSpecified, s => s.Managers[0].RelatedSubject.Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Floor, s => s.Managers[0].RelatedSubject.Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].ForeignLocation, s => s.Managers[0].RelatedSubject.Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Location, s => s.Managers[0].RelatedSubject.Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Location.Code, s => s.Managers[0].RelatedSubject.Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].PostalBox, s => s.Managers[0].RelatedSubject.Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].PostalCode, s => s.Managers[0].RelatedSubject.Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Region, s => s.Managers[0].RelatedSubject.Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Region.Code, s => s.Managers[0].RelatedSubject.Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].Street, s => s.Managers[0].RelatedSubject.Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Addresses[0].StreetNumber, s => s.Managers[0].RelatedSubject.Addresses[0].StreetNumber);

            //Map Managers.RelatedSubject.Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Managers[0].RelatedSubject.Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.Managers[0].RelatedSubject.Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Communications[0].EntryTime, s => s.Managers[0].RelatedSubject.Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Communications[0].EntryTimeSpecified, s => s.Managers[0].RelatedSubject.Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.Communications[0].Type, s => s.Managers[0].RelatedSubject.Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Communications[0].Type.Code, s => s.Managers[0].RelatedSubject.Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Communications[0].Value, s => s.Managers[0].RelatedSubject.Communications[0].Value);

            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.CountrySubject, s => s.Managers[0].RelatedSubject.CountrySubject);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.CountrySubject.Code, s => s.Managers[0].RelatedSubject.CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.Managers[0].RelatedSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.EntryTime, s => s.Managers[0].RelatedSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.EntryTimeSpecified, s => s.Managers[0].RelatedSubject.EntryTimeSpecified);

            //Map Managers.RelatedSubject.LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject, s => s.Managers[0].RelatedSubject.LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.Country, s => s.Managers[0].RelatedSubject.LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.Country.Code, s => s.Managers[0].RelatedSubject.LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.CyrillicFullName, s => s.Managers[0].RelatedSubject.LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.CyrillicShortName, s => s.Managers[0].RelatedSubject.LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.EntryTime, s => s.Managers[0].RelatedSubject.LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.EntryTimeSpecified, s => s.Managers[0].RelatedSubject.LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.LatinFullName, s => s.Managers[0].RelatedSubject.LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.LegalForm, s => s.Managers[0].RelatedSubject.LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.LegalForm.Code, s => s.Managers[0].RelatedSubject.LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.LegalStatute, s => s.Managers[0].RelatedSubject.LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.LegalStatute.Code, s => s.Managers[0].RelatedSubject.LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.SubjectGroup, s => s.Managers[0].RelatedSubject.LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.SubjectGroup.Code, s => s.Managers[0].RelatedSubject.LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.SubordinateLevel, s => s.Managers[0].RelatedSubject.LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.SubordinateLevel.Code, s => s.Managers[0].RelatedSubject.LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.LegalEntitySubject.TRStatus, s => s.Managers[0].RelatedSubject.LegalEntitySubject.TRStatus);

            //Map Managers.RelatedSubject.NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject, s => s.Managers[0].RelatedSubject.NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.BirthDate, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.BirthDate);
           // mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.BirthDateSpecified, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.Country, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.Country.Code, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.CyrillicName, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.EGN, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.EntryTime, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.EntryTimeSpecified, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.LatinName, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.LNC, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.LNC);

            //Map Managers.RelatedSubject.NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate);
           // mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate);
           // mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.Managers[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.Remark, s => s.Managers[0].RelatedSubject.Remark);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.SubjectType, s => s.Managers[0].RelatedSubject.SubjectType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.SubjectType.Code, s => s.Managers[0].RelatedSubject.SubjectType.Code);

            //Map Managers.RelatedSubject.UIC
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.UIC, s => s.Managers[0].RelatedSubject.UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.Managers[0].RelatedSubject.UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.UIC.EntryTime, s => s.Managers[0].RelatedSubject.UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.UIC.EntryTimeSpecified, s => s.Managers[0].RelatedSubject.UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.UIC.UIC1, s => s.Managers[0].RelatedSubject.UIC.UIC1);
            mapper.AddObjectMap(ad => ad.Managers[0].RelatedSubject.UIC.UICType, s => s.Managers[0].RelatedSubject.UIC.UICType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RelatedSubject.UIC.UICType.Code, s => s.Managers[0].RelatedSubject.UIC.UICType.Code);


            #endregion

            #region Managers.RepresentedSubjects
            
            mapper.AddCollectionMap<AdapterServiceReference.SubjectRelManager>(ad => ad.Managers[0].RepresentedSubjects, s => s.RepresentedSubjects);
            
            //Map Managers[0].RepresentedSubjects[0].Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Managers[0].RepresentedSubjects[0].Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].AddressType, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].AddressType.Code, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Apartment, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Building, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Country, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Country.Code, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Entrance, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].EntryTime, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].EntryTimeSpecified, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Floor, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].ForeignLocation, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Location, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Location.Code, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].PostalBox, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].PostalCode, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Region, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Region.Code, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].Street, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Addresses[0].StreetNumber, s => s.Managers[0].RepresentedSubjects[0].Addresses[0].StreetNumber);

            //Map Managers[0].RepresentedSubjects[0].Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Managers[0].RepresentedSubjects[0].Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.Managers[0].RepresentedSubjects[0].Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Communications[0].EntryTime, s => s.Managers[0].RepresentedSubjects[0].Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Communications[0].EntryTimeSpecified, s => s.Managers[0].RepresentedSubjects[0].Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].Communications[0].Type, s => s.Managers[0].RepresentedSubjects[0].Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Communications[0].Type.Code, s => s.Managers[0].RepresentedSubjects[0].Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Communications[0].Value, s => s.Managers[0].RepresentedSubjects[0].Communications[0].Value);

            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].CountrySubject, s => s.Managers[0].RepresentedSubjects[0].CountrySubject);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].CountrySubject.Code, s => s.Managers[0].RepresentedSubjects[0].CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.Managers[0].RepresentedSubjects[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].EntryTime, s => s.Managers[0].RepresentedSubjects[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].EntryTimeSpecified, s => s.Managers[0].RepresentedSubjects[0].EntryTimeSpecified);

            //Map Managers[0].RepresentedSubjects[0].LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.Country, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.Country.Code, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicFullName, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicShortName, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.EntryTime, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.EntryTimeSpecified, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LatinFullName, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm.Code, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute.Code, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup.Code, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel.Code, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].LegalEntitySubject.TRStatus, s => s.Managers[0].RepresentedSubjects[0].LegalEntitySubject.TRStatus);

            //Map Managers[0].RepresentedSubjects[0].NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDate, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDate);
           // mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDateSpecified, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.Country, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.Country.Code, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.CyrillicName, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.EGN, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTime, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTimeSpecified, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.LatinName, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.LNC, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.LNC);

            //Map Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDate);
           // mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDate);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.Managers[0].RepresentedSubjects[0].NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].Remark, s => s.Managers[0].RepresentedSubjects[0].Remark);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].SubjectType, s => s.Managers[0].RepresentedSubjects[0].SubjectType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].SubjectType.Code, s => s.Managers[0].RepresentedSubjects[0].SubjectType.Code);

            //Map Managers[0].RepresentedSubjects[0].UIC
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].UIC, s => s.Managers[0].RepresentedSubjects[0].UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.Managers[0].RepresentedSubjects[0].UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].UIC.EntryTime, s => s.Managers[0].RepresentedSubjects[0].UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].UIC.EntryTimeSpecified, s => s.Managers[0].RepresentedSubjects[0].UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].UIC.UIC1, s => s.Managers[0].RepresentedSubjects[0].UIC.UIC1);
            mapper.AddObjectMap(ad => ad.Managers[0].RepresentedSubjects[0].UIC.UICType, s => s.Managers[0].RepresentedSubjects[0].UIC.UICType);
            mapper.AddPropertyMap(ad => ad.Managers[0].RepresentedSubjects[0].UIC.UICType.Code, s => s.Managers[0].RepresentedSubjects[0].UIC.UICType.Code);



            #endregion

            #endregion

            #region OwnershipForms - Списък с форми на собственост

            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.OwnershipForms, s => s.OwnershipForms);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropOwnershipForm, DateTime>(ad => ad.OwnershipForms[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.OwnershipForms[0].EntryTime, s => s.OwnershipForms[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.OwnershipForms[0].EntryTimeSpecified, s => s.OwnershipForms[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.OwnershipForms[0].Form, s => s.OwnershipForms[0].Form);
            mapper.AddPropertyMap(ad => ad.OwnershipForms[0].Form.Code, s => s.OwnershipForms[0].Form.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropOwnershipForm, decimal>(ad => ad.OwnershipForms[0].Percent, s => (decimal?)s.GetValueOrNull(t => t.Percent, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.OwnershipForms[0].Percent, s => s.OwnershipForms[0].Percent);
            //mapper.AddPropertyMap(ad => ad.OwnershipForms[0].PercentSpecified, s => s.OwnershipForms[0].PercentSpecified);

            #endregion

            #region Partners - Списък със собственици/съдружници

            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.Partners, s => s.Partners);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelPartner, decimal>(ad => ad.Partners[0].Amount, s => (decimal?)s.GetValueOrNull(t => t.Amount, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].Amount, s => s.Partners[0].Amount);
            //mapper.AddPropertyMap(ad => ad.Partners[0].AmountSpecified, s => s.Partners[0].AmountSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelPartner, DateTime>(ad => ad.Partners[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].EntryTime, s => s.Partners[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].EntryTimeSpecified, s => s.Partners[0].EntryTimeSpecified);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelPartner, SubscriptionElementOperationType>
                (ad => ad.Partners[0].OperationType,
                 s => s.OperationTypeSpecified ? (SubscriptionElementOperationType)Enum.Parse(typeof(SubscriptionElementOperationType), s.OperationType.ToString()) : (SubscriptionElementOperationType?)null);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectRelPartner, decimal>(ad => ad.Partners[0].Percent, s => (decimal?)s.GetValueOrNull(t => t.Percent, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].Percent, s => s.Partners[0].Percent);
            //mapper.AddPropertyMap(ad => ad.Partners[0].PercentSpecified, s => s.Partners[0].PercentSpecified);
            mapper.AddObjectMap(ad => ad.Partners[0].Role, s => s.Partners[0].Role);
            mapper.AddPropertyMap(ad => ad.Partners[0].Role.Code, s => s.Partners[0].Role.Code);

            #region Partners.RelatedSubject

            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject, s => s.Partners[0].RelatedSubject);

            //Map Partners[0].RelatedSubject.Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Partners[0].RelatedSubject.Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].AddressType, s => s.Partners[0].RelatedSubject.Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].AddressType.Code, s => s.Partners[0].RelatedSubject.Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Apartment, s => s.Partners[0].RelatedSubject.Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Building, s => s.Partners[0].RelatedSubject.Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Country, s => s.Partners[0].RelatedSubject.Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Country.Code, s => s.Partners[0].RelatedSubject.Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Entrance, s => s.Partners[0].RelatedSubject.Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.Partners[0].RelatedSubject.Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].EntryTime, s => s.Partners[0].RelatedSubject.Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].EntryTimeSpecified, s => s.Partners[0].RelatedSubject.Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Floor, s => s.Partners[0].RelatedSubject.Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].ForeignLocation, s => s.Partners[0].RelatedSubject.Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Location, s => s.Partners[0].RelatedSubject.Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Location.Code, s => s.Partners[0].RelatedSubject.Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].PostalBox, s => s.Partners[0].RelatedSubject.Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].PostalCode, s => s.Partners[0].RelatedSubject.Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Region, s => s.Partners[0].RelatedSubject.Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Region.Code, s => s.Partners[0].RelatedSubject.Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].Street, s => s.Partners[0].RelatedSubject.Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Addresses[0].StreetNumber, s => s.Partners[0].RelatedSubject.Addresses[0].StreetNumber);

            //Map Partners[0].RelatedSubject.Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Partners[0].RelatedSubject.Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.Partners[0].RelatedSubject.Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Communications[0].EntryTime, s => s.Partners[0].RelatedSubject.Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Communications[0].EntryTimeSpecified, s => s.Partners[0].RelatedSubject.Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.Communications[0].Type, s => s.Partners[0].RelatedSubject.Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Communications[0].Type.Code, s => s.Partners[0].RelatedSubject.Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Communications[0].Value, s => s.Partners[0].RelatedSubject.Communications[0].Value);

            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.CountrySubject, s => s.Partners[0].RelatedSubject.CountrySubject);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.CountrySubject.Code, s => s.Partners[0].RelatedSubject.CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.Partners[0].RelatedSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.EntryTime, s => s.Partners[0].RelatedSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.EntryTimeSpecified, s => s.Partners[0].RelatedSubject.EntryTimeSpecified);

            //Map Partners[0].RelatedSubject.LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject, s => s.Partners[0].RelatedSubject.LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.Country, s => s.Partners[0].RelatedSubject.LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.Country.Code, s => s.Partners[0].RelatedSubject.LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.CyrillicFullName, s => s.Partners[0].RelatedSubject.LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.CyrillicShortName, s => s.Partners[0].RelatedSubject.LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.EntryTime, s => s.Partners[0].RelatedSubject.LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.EntryTimeSpecified, s => s.Partners[0].RelatedSubject.LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.LatinFullName, s => s.Partners[0].RelatedSubject.LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.LegalForm, s => s.Partners[0].RelatedSubject.LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.LegalForm.Code, s => s.Partners[0].RelatedSubject.LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.LegalStatute, s => s.Partners[0].RelatedSubject.LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.LegalStatute.Code, s => s.Partners[0].RelatedSubject.LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.SubjectGroup, s => s.Partners[0].RelatedSubject.LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.SubjectGroup.Code, s => s.Partners[0].RelatedSubject.LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.SubordinateLevel, s => s.Partners[0].RelatedSubject.LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.SubordinateLevel.Code, s => s.Partners[0].RelatedSubject.LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.LegalEntitySubject.TRStatus, s => s.Partners[0].RelatedSubject.LegalEntitySubject.TRStatus);

            //Map Partners[0].RelatedSubject.NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject, s => s.Partners[0].RelatedSubject.NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.BirthDate, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.BirthDate);
           // mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.BirthDateSpecified, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.Country, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.Country.Code, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.CyrillicName, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.EGN, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.EntryTime, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.EntryTimeSpecified, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.LatinName, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.LNC, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.LNC);

            //Map Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDate);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDate);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.Partners[0].RelatedSubject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.Remark, s => s.Partners[0].RelatedSubject.Remark);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.SubjectType, s => s.Partners[0].RelatedSubject.SubjectType);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.SubjectType.Code, s => s.Partners[0].RelatedSubject.SubjectType.Code);

            //Map Partners[0].RelatedSubject.UIC
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.UIC, s => s.Partners[0].RelatedSubject.UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.Partners[0].RelatedSubject.UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.UIC.EntryTime, s => s.Partners[0].RelatedSubject.UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.UIC.EntryTimeSpecified, s => s.Partners[0].RelatedSubject.UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.UIC.UIC1, s => s.Partners[0].RelatedSubject.UIC.UIC1);
            mapper.AddObjectMap(ad => ad.Partners[0].RelatedSubject.UIC.UICType, s => s.Partners[0].RelatedSubject.UIC.UICType);
            mapper.AddPropertyMap(ad => ad.Partners[0].RelatedSubject.UIC.UICType.Code, s => s.Partners[0].RelatedSubject.UIC.UICType.Code);

            #endregion

            #endregion

            //Mapping Professions - Професии
            mapper.AddCollectionMap<AdapterServiceReference.StateOfPlay>(ad => ad.Professions, s => s.Professions);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropProfession, DateTime>(ad => ad.Professions[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            mapper.AddObjectMap(ad => ad.Professions[0].Profession, s => s.Professions[0].Profession);
            mapper.AddPropertyMap(ad => ad.Professions[0].Profession.Code, s => s.Professions[0].Profession.Code);

            //Mapping RepresentationType - Начин на представяне
            mapper.AddObjectMap(ad => ad.RepresentationType, s => s.RepresentationType);
            mapper.AddPropertyMap(ad => ad.RepresentationType.Description, s => s.RepresentationType.Description);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropRepresentationType, DateTime>(ad => ad.RepresentationType.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.RepresentationType.EntryTime, s => s.RepresentationType.EntryTime);
            //mapper.AddPropertyMap(ad => ad.RepresentationType.EntryTimeSpecified, s => s.RepresentationType.EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.RepresentationType.Type, s => s.RepresentationType.Type);
            mapper.AddPropertyMap(ad => ad.RepresentationType.Type.Code, s => s.RepresentationType.Type.Code);

            //Mapping ScopeOfActivity - Предмет на дейност
            mapper.AddObjectMap(ad => ad.ScopeOfActivity, s => s.ScopeOfActivity);
            mapper.AddPropertyMap(ad => ad.ScopeOfActivity.Description, s => s.ScopeOfActivity.Description);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropScopeOfActivity, DateTime>(ad => ad.ScopeOfActivity.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.ScopeOfActivity.EntryTime, s => s.ScopeOfActivity.EntryTime);
            //mapper.AddPropertyMap(ad => ad.ScopeOfActivity.EntryTimeSpecified, s => s.ScopeOfActivity.EntryTimeSpecified);

            //Mapping State - Състояние на субект
            mapper.AddObjectMap(ad => ad.State, s => s.State);
            mapper.AddFunctionMapNull<AdapterServiceReference.SubjectPropState, DateTime>(ad => ad.State.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.State.EntryTime, s => s.State.EntryTime);
            //mapper.AddPropertyMap(ad => ad.State.EntryTimeSpecified, s => s.State.EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.State.State, s => s.State.State);
            mapper.AddPropertyMap(ad => ad.State.State.Code, s => s.State.State.Code);

            #region Subject - информация за субект
            
            mapper.AddObjectMap(ad => ad.Subject, s => s.Subject);

            //Map Subject.Addresses
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Subject.Addresses, s => s.Addresses);
            mapper.AddObjectMap(ad => ad.Subject.Addresses[0].AddressType, s => s.Subject.Addresses[0].AddressType);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].AddressType.Code, s => s.Subject.Addresses[0].AddressType.Code);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Apartment, s => s.Subject.Addresses[0].Apartment);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Building, s => s.Subject.Addresses[0].Building);
            mapper.AddObjectMap(ad => ad.Subject.Addresses[0].Country, s => s.Subject.Addresses[0].Country);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Country.Code, s => s.Subject.Addresses[0].Country.Code);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Entrance, s => s.Subject.Addresses[0].Entrance);
            mapper.AddFunctionMapNull<AdapterServiceReference.Address, DateTime>(ad => ad.Subject.Addresses[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].EntryTime, s => s.Subject.Addresses[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].EntryTimeSpecified, s => s.Subject.Addresses[0].EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Floor, s => s.Subject.Addresses[0].Floor);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].ForeignLocation, s => s.Subject.Addresses[0].ForeignLocation);
            mapper.AddObjectMap(ad => ad.Subject.Addresses[0].Location, s => s.Subject.Addresses[0].Location);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Location.Code, s => s.Subject.Addresses[0].Location.Code);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].PostalBox, s => s.Subject.Addresses[0].PostalBox);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].PostalCode, s => s.Subject.Addresses[0].PostalCode);
            mapper.AddObjectMap(ad => ad.Subject.Addresses[0].Region, s => s.Subject.Addresses[0].Region);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Region.Code, s => s.Subject.Addresses[0].Region.Code);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].Street, s => s.Subject.Addresses[0].Street);
            mapper.AddPropertyMap(ad => ad.Subject.Addresses[0].StreetNumber, s => s.Subject.Addresses[0].StreetNumber);

            //Map Subject.Communications
            mapper.AddCollectionMap<AdapterServiceReference.Subject>(ad => ad.Subject.Communications, s => s.Communications);
            mapper.AddFunctionMapNull<AdapterServiceReference.Communication, DateTime>(ad => ad.Subject.Communications[0].EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Subject.Communications[0].EntryTime, s => s.Subject.Communications[0].EntryTime);
            //mapper.AddPropertyMap(ad => ad.Subject.Communications[0].EntryTimeSpecified, s => s.Subject.Communications[0].EntryTimeSpecified);
            mapper.AddObjectMap(ad => ad.Subject.Communications[0].Type, s => s.Subject.Communications[0].Type);
            mapper.AddPropertyMap(ad => ad.Subject.Communications[0].Type.Code, s => s.Subject.Communications[0].Type.Code);
            mapper.AddPropertyMap(ad => ad.Subject.Communications[0].Value, s => s.Subject.Communications[0].Value);

            mapper.AddObjectMap(ad => ad.Subject.CountrySubject, s => s.Subject.CountrySubject);
            mapper.AddPropertyMap(ad => ad.Subject.CountrySubject.Code, s => s.Subject.CountrySubject.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.Subject, DateTime>(ad => ad.Subject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Subject.EntryTime, s => s.Subject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Subject.EntryTimeSpecified, s => s.Subject.EntryTimeSpecified);

            //Map Subject.LegalEntitySubject 
            mapper.AddObjectMap(ad => ad.Subject.LegalEntitySubject, s => s.Subject.LegalEntitySubject);
            mapper.AddObjectMap(ad => ad.Subject.LegalEntitySubject.Country, s => s.Subject.LegalEntitySubject.Country);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.Country.Code, s => s.Subject.LegalEntitySubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.CyrillicFullName, s => s.Subject.LegalEntitySubject.CyrillicFullName);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.CyrillicShortName, s => s.Subject.LegalEntitySubject.CyrillicShortName);
            mapper.AddFunctionMapNull<AdapterServiceReference.LegalEntity, DateTime>(ad => ad.Subject.LegalEntitySubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.EntryTime, s => s.Subject.LegalEntitySubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.EntryTimeSpecified, s => s.Subject.LegalEntitySubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.LatinFullName, s => s.Subject.LegalEntitySubject.LatinFullName);
            mapper.AddObjectMap(ad => ad.Subject.LegalEntitySubject.LegalForm, s => s.Subject.LegalEntitySubject.LegalForm);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.LegalForm.Code, s => s.Subject.LegalEntitySubject.LegalForm.Code);
            mapper.AddObjectMap(ad => ad.Subject.LegalEntitySubject.LegalStatute, s => s.Subject.LegalEntitySubject.LegalStatute);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.LegalStatute.Code, s => s.Subject.LegalEntitySubject.LegalStatute.Code);
            mapper.AddObjectMap(ad => ad.Subject.LegalEntitySubject.SubjectGroup, s => s.Subject.LegalEntitySubject.SubjectGroup);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.SubjectGroup.Code, s => s.Subject.LegalEntitySubject.SubjectGroup.Code);
            mapper.AddObjectMap(ad => ad.Subject.LegalEntitySubject.SubordinateLevel, s => s.Subject.LegalEntitySubject.SubordinateLevel);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.SubordinateLevel.Code, s => s.Subject.LegalEntitySubject.SubordinateLevel.Code);
            mapper.AddPropertyMap(ad => ad.Subject.LegalEntitySubject.TRStatus, s => s.Subject.LegalEntitySubject.TRStatus);

            //Map Subject.NaturalPersonSubject
            mapper.AddObjectMap(ad => ad.Subject.NaturalPersonSubject, s => s.Subject.NaturalPersonSubject);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.BirthDate, s => s.Subject.NaturalPersonSubject.BirthDate);
           // mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.BirthDateSpecified, s => s.Subject.NaturalPersonSubject.BirthDateSpecified);
            mapper.AddObjectMap(ad => ad.Subject.NaturalPersonSubject.Country, s => s.Subject.NaturalPersonSubject.Country);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.Country.Code, s => s.Subject.NaturalPersonSubject.Country.Code);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.CyrillicName, s => s.Subject.NaturalPersonSubject.CyrillicName);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.EGN, s => s.Subject.NaturalPersonSubject.EGN);
            mapper.AddFunctionMapNull<AdapterServiceReference.NaturalPerson, DateTime>(ad => ad.Subject.NaturalPersonSubject.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.EntryTime, s => s.Subject.NaturalPersonSubject.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.EntryTimeSpecified, s => s.Subject.NaturalPersonSubject.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.LatinName, s => s.Subject.NaturalPersonSubject.LatinName);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.LNC, s => s.Subject.NaturalPersonSubject.LNC);

            //Map Subject.NaturalPersonSubject.IdentificationDoc
            mapper.AddObjectMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc, s => s.Subject.NaturalPersonSubject.IdentificationDoc);
            mapper.AddObjectMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.Country, s => s.Subject.NaturalPersonSubject.IdentificationDoc.Country);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.Country.Code, s => s.Subject.NaturalPersonSubject.IdentificationDoc.Country.Code);
            mapper.AddFunctionMapNull<AdapterServiceReference.IdentificationDoc, DateTime>(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.EntryTime, s => s.Subject.NaturalPersonSubject.IdentificationDoc.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified, s => s.Subject.NaturalPersonSubject.IdentificationDoc.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.ExpiryDate, s => s.Subject.NaturalPersonSubject.IdentificationDoc.ExpiryDate);
           // mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified, s => s.Subject.NaturalPersonSubject.IdentificationDoc.ExpiryDateSpecified);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.IDNumber, s => s.Subject.NaturalPersonSubject.IdentificationDoc.IDNumber);
            mapper.AddObjectMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.IDType, s => s.Subject.NaturalPersonSubject.IdentificationDoc.IDType);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.IDType.Code, s => s.Subject.NaturalPersonSubject.IdentificationDoc.IDType.Code);
            mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.IssueDate, s => s.Subject.NaturalPersonSubject.IdentificationDoc.IssueDate);
            //mapper.AddPropertyMap(ad => ad.Subject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified, s => s.Subject.NaturalPersonSubject.IdentificationDoc.IssueDateSpecified);

            mapper.AddPropertyMap(ad => ad.Subject.Remark, s => s.Subject.Remark);
            mapper.AddObjectMap(ad => ad.Subject.SubjectType, s => s.Subject.SubjectType);
            mapper.AddPropertyMap(ad => ad.Subject.SubjectType.Code, s => s.Subject.SubjectType.Code);

            //Map Subject.UIC
            mapper.AddObjectMap(ad => ad.Subject.UIC, s => s.Subject.UIC);
            mapper.AddFunctionMapNull<AdapterServiceReference.UIC, DateTime>(ad => ad.Subject.UIC.EntryTime, s => (DateTime?)s.GetValueOrNull(t => t.EntryTime, isFromDb: false));
            //mapper.AddPropertyMap(ad => ad.Subject.UIC.EntryTime, s => s.Subject.UIC.EntryTime);
            //mapper.AddPropertyMap(ad => ad.Subject.UIC.EntryTimeSpecified, s => s.Subject.UIC.EntryTimeSpecified);
            mapper.AddPropertyMap(ad => ad.Subject.UIC.UIC1, s => s.Subject.UIC.UIC1);
            mapper.AddObjectMap(ad => ad.Subject.UIC.UICType, s => s.Subject.UIC.UICType);
            mapper.AddPropertyMap(ad => ad.Subject.UIC.UICType.Code, s => s.Subject.UIC.UICType.Code);


            #endregion

            return mapper;

        }
       

        //private static ObjectMapper<AdapterServiceReference.SimpleNomenclature[], FetchNomenclaturesResponse> CreateFetchNomenclaturesSimpleNomenclatureMapper(AccessMatrix accessMatrix)
        //{
        //    ObjectMapper<AdapterServiceReference.SimpleNomenclature[], FetchNomenclaturesResponse> mapper =
        //        new ObjectMapper<AdapterServiceReference.SimpleNomenclature[], FetchNomenclaturesResponse>(accessMatrix);

        //    mapper.AddCollectionMap<AdapterServiceReference.SimpleNomenclature[]>((o) => o.SimpleNomenclature, c => c);

        //    mapper.AddObjectMap((o) => o.SimpleNomenclature[0].Definition, c => c[0].Definition);
        //    mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].Definition.Code, c => c[0].Definition.Code);
        //    mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].Definition.Name, c => c[0].Definition.Name);

        //    mapper.AddCollectionMap<AdapterServiceReference.SimpleNomenclature[]>((o) => o.SimpleNomenclature[0].NomElement, c => c[0].NomElement);
        //    mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].Active, c => c[0].NomElement[0].Active);
        //    mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].Code, c => c[0].NomElement[0].Code);
        //    mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].NameBG, c => c[0].NomElement[0].NameBG);
        //    mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].NameEN, c => c[0].NomElement[0].NameEN);
        //    mapper.AddPropertyMap((o) => o.SimpleNomenclature[0].NomElement[0].Ordering, c => c[0].NomElement[0].Ordering);

        //    return mapper;
        //}

        //private static ObjectMapper<AdapterServiceReference.CountryMultilangNomElement[], FetchNomenclaturesResponse> CreateFetchNomenclaturesCountryNomElementMapper(AccessMatrix accessMatrix)
        //{
        //    ObjectMapper<AdapterServiceReference.CountryMultilangNomElement[], FetchNomenclaturesResponse> mapper =
        //        new ObjectMapper<AdapterServiceReference.CountryMultilangNomElement[], FetchNomenclaturesResponse>(accessMatrix);

        //    mapper.AddCollectionMap<AdapterServiceReference.CountryMultilangNomElement[]>((o) => o.CountryNomElement, c => c);

        //    mapper.AddPropertyMap((o) => o.CountryNomElement[0].Active, c => c[0].Active);
        //    mapper.AddPropertyMap((o) => o.CountryNomElement[0].Code, c => c[0].Code);
        //    mapper.AddPropertyMap((o) => o.CountryNomElement[0].ISO2, c => c[0].ISO2);
        //    mapper.AddPropertyMap((o) => o.CountryNomElement[0].ISO3, c => c[0].ISO3);
        //    mapper.AddPropertyMap((o) => o.CountryNomElement[0].NameBG, c => c[0].NameBG);
        //    mapper.AddPropertyMap((o) => o.CountryNomElement[0].NameEN, c => c[0].NameEN);
        //    mapper.AddPropertyMap((o) => o.CountryNomElement[0].Ordering, c => c[0].Ordering);

        //    return mapper;
        //}

        /// <summary>
        /// Създава входния обект на метода GetStateOfPlay от уеб услугата
        /// </summary>
        /// <param name="argument">Входния обект на адаптера</param>
        /// <returns>Входния обект на операцията GetStateOfPlay от уеб услугата</returns>
        //private AdapterServiceReference.GetStateOfPlayRequest MapStateOfPlayServiceRequest(GetStateOfPlay argument)
        //{
        //    AdapterServiceReference.GetStateOfPlayRequest serviceRequest = new AdapterServiceReference.GetStateOfPlayRequest();

        //    serviceRequest.UIC = argument.GetStateOfPlayRequest.UIC;

        //    if (argument.GetStateOfPlayRequest.Case != null)
        //    {
        //        var caseInfo = argument.GetStateOfPlayRequest.Case;

        //        serviceRequest.Case = new AdapterServiceReference.GetStateOfPlayRequestCase();
        //        serviceRequest.Case.Year = caseInfo.Year;
        //        serviceRequest.Case.Number = caseInfo.Number;

        //        if (caseInfo.Court != null)
        //        {
        //            serviceRequest.Case.Court = new AdapterServiceReference.NomenclatureEntry();
        //            serviceRequest.Case.Court.Code = caseInfo.Court.Code;
        //        }

        //    }

        //    return serviceRequest;
        //}

        #endregion
    }
}
