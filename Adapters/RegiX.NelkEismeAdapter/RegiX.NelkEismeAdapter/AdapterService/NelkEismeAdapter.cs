using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.NelkEismeAdapter.XMLSchemas;
using TechnoLogica.RegiX.WebServiceAdapterService;

namespace TechnoLogica.RegiX.NelkEismeAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NelkEismeAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NelkEismeAdapter), typeof(IAdapterService))]
    public class NelkEismeAdapter : SoapServiceBaseAdapterService, INelkEismeAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NelkEismeAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           //new ParameterInfo<string>("http://194.12.245.241/NelkServices/CheckService")
           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com:8078/RegiX.NELKServiceMockup/CheckServiceImplementation.svc")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Web Service Url",
               OwnerAssembly = typeof(NelkEismeAdapter).Assembly
           };

        public CommonSignedResponse<GetAllExpertDecisionsByIdentifierRequest, ExpertDecisionsResponse> GetAllExpertDecisionsByIdentifier(GetAllExpertDecisionsByIdentifierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                NelkServiceReference.CheckServiceClient serviceClient = new NelkServiceReference.CheckServiceClient("CheckServiceImplPort", WebServiceUrl.Value);
                NelkServiceReference.ekspertizaWsObject[] serviceResult = serviceClient.getErAll(argument.Identifier, aditionalParameters.OrganizationUnit);
                ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> mapper = CreateExpertDecisionsResponseMapper(accessMatrix);
                ExpertDecisionsResponse searchResults = new ExpertDecisionsResponse();
                mapper.Map(serviceResult, searchResults);

                int counter = 0;
                foreach (var item in searchResults.ExpertDecisionDocument)
                {
                    ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> arrayMapper = ArrayMapper(accessMatrix, counter);
                    ExpertDecisionsResponse arrayResult = new ExpertDecisionsResponse();
                    arrayMapper.Map(serviceResult, arrayResult);
                    searchResults.ExpertDecisionDocument[counter].DisabilityReason.AddRange(arrayResult.ExpertDecisionDocument[counter].DisabilityReason);
                    searchResults.ExpertDecisionDocument[counter].CommisionMember.AddRange(arrayResult.ExpertDecisionDocument[counter].CommisionMember);
                    counter++;
                }

                return
                        SigningUtils.CreateAndSign(
                            argument,
                            searchResults,
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
        public CommonSignedResponse<GetLastExpertDecisionByIdentifierRequest, ExpertDecisionsResponse> GetLastExpertDecisionByIdentifier(GetLastExpertDecisionByIdentifierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                ExpertDecisionsResponse searchResults = new ExpertDecisionsResponse();
                NelkServiceReference.CheckServiceClient serviceClient = new NelkServiceReference.CheckServiceClient("CheckServiceImplPort", WebServiceUrl.Value);
                NelkServiceReference.ekspertizaWsObject serviceResult = serviceClient.getEr(argument.Identifier, aditionalParameters.OrganizationUnit);
                if (serviceResult != null)
                {

                    ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> mapper = CreateExpertDecisionsResponseMapper(accessMatrix);
                    mapper.Map(new NelkServiceReference.ekspertizaWsObject[] { serviceResult }, searchResults);
                    int counter = 0;
                    foreach (var item in searchResults.ExpertDecisionDocument)
                    {
                        ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> arrayMapper = ArrayMapper(accessMatrix, counter);
                        ExpertDecisionsResponse arrayResult = new ExpertDecisionsResponse();
                        arrayMapper.Map(new NelkServiceReference.ekspertizaWsObject[] { serviceResult }, arrayResult);
                        searchResults.ExpertDecisionDocument[counter].DisabilityReason.AddRange(arrayResult.ExpertDecisionDocument[counter].DisabilityReason);
                        searchResults.ExpertDecisionDocument[counter].CommisionMember.AddRange(arrayResult.ExpertDecisionDocument[counter].CommisionMember);
                        counter++;
                    }
                }
                return
                        SigningUtils.CreateAndSign(
                            argument,
                            searchResults,
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

        public static ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> CreateExpertDecisionsResponseMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> mapper = new ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse>(accessMatrix);

            mapper.AddCollectionMap<NelkServiceReference.ekspertizaWsObject[]>((o) => o.ExpertDecisionDocument, (c) => c);

            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, long>(ad => ad.ExpertDecisionDocument[0].RegistrationNumber, s => (long?)s.GetValueOrNull(t => t.regNumEr, isFromDb: false));
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, long>(ad => ad.ExpertDecisionDocument[0].MeetingNumber, s => (long?)s.GetValueOrNull(t => t.nomerZasedanie, isFromDb: false));
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].RegistrationDate, s => (DateTime?)s.GetValueOrNull(t => t.erDate, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].CommissionDescr, (c) => c[0].irKomisia);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].CommissionCode, (c) => c[0].irKomisiaCode);

            //mapper.AddCollectionMap<NelkServiceReference.ekspertizaWsObject[]>((o) => o.ExpertDecisionDocument[0].CommisionMember, c => c[0].komisiaList);
            //mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].CommisionMember[0].Name, (c) => c[0].komisiaList[0].imenaLekar);
            //mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].CommisionMember[0].Position, (c) => c[0].komisiaList[0].dlajnost);

            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].PersonNames, (c) => c[0].imena);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].PersonIdentifier, (c) => c[0].egnLnch);

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].IdentityDocument, (c) => c[0]);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].IdentityDocument.DocumentNumber, (c) => c[0].docNomer);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].IdentityDocument.IssueDate, s => (DateTime?)s.GetValueOrNull(t => t.docDataIzd, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].IdentityDocument.IssuePlace, (c) => c[0].docIzdadenOt);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].IdentityDocument.ValidDate, s => (DateTime?)s.GetValueOrNull(t => t.docDataValid, isFromDb: false));

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].PermanentAddress, (c) => c[0]);

            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].PermanentAddress.AddressDescription, (c) => c[0].postAdres);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].PermanentAddress.DistrictEKATTE, (c) => c[0].postOblastEKATTE);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].PermanentAddress.MunicipalityEKATTE, (c) => c[0].postObshtinaEKATTE);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, long>(ad => ad.ExpertDecisionDocument[0].PermanentAddress.SettlementEKATTE, s => (long?)s.GetValueOrNull(t => t.postNasMestoEKATTE, isFromDb: false));

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].TemporaryAddress, (c) => c[0]);

            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].TemporaryAddress.AddressDescription, (c) => c[0].nastAdres);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].TemporaryAddress.DistrictEKATTE, (c) => c[0].nastOblastEKATTE);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].TemporaryAddress.MunicipalityEKATTE, (c) => c[0].nastObshtinaEKATTE);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, long>(ad => ad.ExpertDecisionDocument[0].TemporaryAddress.SettlementEKATTE, s => (long?)s.GetValueOrNull(t => t.nastNasMestoEKATTE, isFromDb: false));

            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Employment, (c) => c[0].trudovaZaetost);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].EmploymentCode, (c) => c[0].trudovaZaetostCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Profession, (c) => c[0].profesia);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ConditionText, (c) => c[0].sastoyanieEkspText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ConditionCode, (c) => c[0].sastoyanieEkspCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ExpertiseType, (c) => c[0].vid);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ExpertiseTypeCode, (c) => c[0].vidCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ExpertiseDecisionMaking, (c) => c[0].nachinReshenie);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ExpertiseDecisionMakingCode, (c) => c[0].nachinReshenieCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ExpertisePlace, (c) => c[0].myasto);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ExpertisePlaceCode, (c) => c[0].myastoCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].EmployabilityAssessment, (c) => c[0].ocenkaRabText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].EmployabilityAssessmentCode, (c) => c[0].ocenkaRabCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].AppealedHospitalSheets, (c) => c[0].objBolnichniListove);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].DurationForeignAid, s => (DateTime?)s.GetValueOrNull(t => t.srokChujdaPomosht, isFromDb: false));
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].DurationDisabilityDate, s => (DateTime?)s.GetValueOrNull(t => t.srokInvalidnostDate, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].DurationDisability, (c) => c[0].srokInvalidnost);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].DurationDisabilityCode, (c) => c[0].srokInvalidnostCode);

            //mapper.AddCollectionMap<NelkServiceReference.ekspertizaWsObject[]>((o) => o.ExpertDecisionDocument[0].DisabilityReason, c => c[0].invalidnostList);

            //mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].DisabilityReason[0].Percent, (c) => c[0].invalidnostList[0].invalidnost);
            //mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaInvalidnostWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].DisabilityReason[0].Date, s => (DateTime?)s.GetValueOrNull(t => t.dateInval, isFromDb: false));
            //mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].DisabilityReason[0].Type, (c) => c[0].invalidnostList[0].vidInval);

            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Diagnosis, (c) => c[0].vdText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].DiagnosisCode, (c) => c[0].vdMkbCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].GeneralIllness, (c) => c[0].ozText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].GeneralIllnessCode, (c) => c[0].ozMkbCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].WorkAccident, (c) => c[0].tzText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].WorkAccidentCode, (c) => c[0].tzMkbCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].WorkDisease, (c) => c[0].pzText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].WorkDiseaseCode, (c) => c[0].pzMkbCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].MilitaryDisability, (c) => c[0].voennaInvlidnost);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].MilitaryDisabilityCode, (c) => c[0].viMkbCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ContradictionWorkingConditions, (c) => c[0].protivopokazania);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].RecommendationsForChild, (c) => c[0].preporaki);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].ArgumentsAndObservations, (c) => c[0].constataciq);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].ReceiptDate, s => (DateTime?)s.GetValueOrNull(t => t.datePoluchavane, isFromDb: false));

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].Appeal, (c) => c[0]);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, long>(ad => ad.ExpertDecisionDocument[0].Appeal.RegistrationNumber, s => (long?)s.GetValueOrNull(t => t.erNomObj, isFromDb: false));
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].Appeal.RegistrationDate, s => (DateTime?)s.GetValueOrNull(t => t.erDateObj, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Appeal.Institution, (c) => c[0].erInstanciaObj);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Appeal.InstitutionCode, (c) => c[0].erInstanciaObjCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Appeal.Stakeholders, (c) => c[0].iniciatorText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Appeal.StakeholdersCode, (c) => c[0].iniciatorCode);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Appeal.Condition, (c) => c[0].erReshenieObj);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Appeal.Decision, (c) => c[0].reshenieNelkText);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Appeal.DecisionCode, (c) => c[0].reshenieNelkCode);

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].Parent, (c) => c[0]);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Parent.EGN, (c) => c[0].egnNas);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Parent.LNCh, (c) => c[0].lnchNas);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Parent.PersonNames, (c) => c[0].imenaNas);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Parent.PermanentAddress, (c) => c[0].postAdresNas);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Parent.TemporaryAddress, (c) => c[0].nastAdresNas);

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].Parent.IdentityDocument, (c) => c[0]);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Parent.IdentityDocument.DocumentNumber, (c) => c[0].docNomerNas);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].Parent.IdentityDocument.IssueDate, s => (DateTime?)s.GetValueOrNull(t => t.docDataIzdNas, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].Parent.IdentityDocument.IssuePlace, (c) => c[0].docIzdadenOtNas);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].Parent.IdentityDocument.ValidDate, s => (DateTime?)s.GetValueOrNull(t => t.docDataValidNas, isFromDb: false));

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].AdditionalData, (c) => c[0]);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, long>(ad => ad.ExpertDecisionDocument[0].AdditionalData.EmployeeType, s => (long?)s.GetValueOrNull(t => t.tipSlujitel, isFromDb: false));
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, long>(ad => ad.ExpertDecisionDocument[0].AdditionalData.Status, s => (long?)s.GetValueOrNull(t => t.status, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].AdditionalData.ReasonForTermination, (c) => c[0].osnovanie);

            mapper.AddObjectMap(ad => ad.ExpertDecisionDocument[0].InitiateDocument, (c) => c[0]);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].InitiateDocument.RegistrationNumber, (c) => c[0].rnDoc);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].InitiateDocument.RegistrationDate, s => (DateTime?)s.GetValueOrNull(t => t.dateDoc, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].InitiateDocument.DocumentType, (c) => c[0].vidDoc);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].InitiateDocument.Annotation, (c) => c[0].anotDoc);

            return mapper;
        }

        public CommonSignedResponse<GetAllExpertDecisionsByPeriodRequest, ExpertDesisionShortInfoForPeriodList> GetAllExpertDecisionsByPeriod(GetAllExpertDecisionsByPeriodRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                ExpertDesisionShortInfoForPeriodList searchResults = new ExpertDesisionShortInfoForPeriodList();
                NelkServiceReference.CheckServiceClient serviceClient = new NelkServiceReference.CheckServiceClient("CheckServiceImplPort", WebServiceUrl.Value);
                NelkServiceReference.anyTypeArray1[] serviceResult = serviceClient.listErPeriod(argument.DateFrom, argument.DateTo, aditionalParameters.OrganizationUnit);
                if (serviceResult != null)
                {
                    ExpertDesisionShortInfoForPeriodList serviceObjectResult = new ExpertDesisionShortInfoForPeriodList();
                    serviceObjectResult.ExpertDesisionShortInfo = new List<ExpertDesisionShortInfo>();
                    foreach (var res in serviceResult)
                    {
                        ExpertDesisionShortInfo obj = new ExpertDesisionShortInfo();
                        try
                        {

                            obj.PersonIdentifier = res.item[0].ToString();
                        }
                        catch { }
                        try
                        {
                            obj.PersonNames = res.item[1].ToString();
                        }
                        catch { }
                        try
                        {
                            obj.RegistrationNumber = Convert.ToInt64(res.item[2]);
                            obj.RegistrationNumberSpecified = true;
                        }
                        catch
                        {
                            obj.RegistrationNumberSpecified = false;
                        }
                        try
                        {
                            obj.MeetingNumber = Convert.ToInt64(res.item[3]);
                            obj.MeetingNumberSpecified = true;
                        }
                        catch
                        {
                            obj.MeetingNumberSpecified = false;
                        }
                        try
                        {
                            obj.RegistrationDate = Convert.ToDateTime(res.item[4]);
                            obj.RegistrationDateSpecified = true;
                        }
                        catch
                        {
                            obj.RegistrationDateSpecified = false;
                        }
                        try
                        {
                            obj.CommissionCode = res.item[5].ToString();
                        }
                        catch { }

                        serviceObjectResult.ExpertDesisionShortInfo.Add(obj);
                    }

                    ObjectMapper<ExpertDesisionShortInfoForPeriodList, ExpertDesisionShortInfoForPeriodList> mapper = CreateExpertDesisionShortInfoMapper(accessMatrix);
                    mapper.Map(serviceObjectResult, searchResults);
                }
                return
                        SigningUtils.CreateAndSign(
                            argument,
                            searchResults,
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

        private static ObjectMapper<ExpertDesisionShortInfoForPeriodList, ExpertDesisionShortInfoForPeriodList> CreateExpertDesisionShortInfoMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<ExpertDesisionShortInfoForPeriodList, ExpertDesisionShortInfoForPeriodList> mapper = new ObjectMapper<ExpertDesisionShortInfoForPeriodList, ExpertDesisionShortInfoForPeriodList>(accessMatrix);

           // mapper.AddObjectMap<ExpertDesisionShortInfoForPeriodList, ExpertDesisionShortInfoForPeriodList>(o => o, s => s);
            mapper.AddCollectionMap<ExpertDesisionShortInfoForPeriodList>((o) => o.ExpertDesisionShortInfo, (c) => c.ExpertDesisionShortInfo);

           // mapper.AddObjectMap<ExpertDesisionShortInfo, ExpertDesisionShortInfo>(o => o.ExpertDesisionShortInfo[0], s => s.ExpertDesisionShortInfo[0]);

            mapper.AddPropertyMap((o) => o.ExpertDesisionShortInfo[0].PersonIdentifier, (c) => c.ExpertDesisionShortInfo[0].PersonIdentifier);
            mapper.AddPropertyMap((o) => o.ExpertDesisionShortInfo[0].PersonNames, (c) => c.ExpertDesisionShortInfo[0].PersonNames);
            mapper.AddPropertyMap((o) => o.ExpertDesisionShortInfo[0].CommissionCode, (c) => c.ExpertDesisionShortInfo[0].CommissionCode);
            mapper.AddFunctionMapNull<ExpertDesisionShortInfo, long>(ad => ad.ExpertDesisionShortInfo[0].RegistrationNumber, s => (long?)s.GetValueOrNull(t => t.RegistrationNumber, isFromDb: false));
            mapper.AddFunctionMapNull<ExpertDesisionShortInfo, long>(ad => ad.ExpertDesisionShortInfo[0].MeetingNumber, s => (long?)s.GetValueOrNull(t => t.MeetingNumber, isFromDb: false));
            mapper.AddFunctionMapNull<ExpertDesisionShortInfo, DateTime>(ad => ad.ExpertDesisionShortInfo[0].RegistrationDate, s => (DateTime?)s.GetValueOrNull(t => t.RegistrationDate, isFromDb: false));
            
            return mapper;
        }

        private static ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> ArrayMapper(AccessMatrix accessMatrix, int counter)
        {
            ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse> mapper = new ObjectMapper<NelkServiceReference.ekspertizaWsObject[], ExpertDecisionsResponse>(accessMatrix);
            mapper.AddCollectionMap<NelkServiceReference.ekspertizaWsObject[]>((o) => o.ExpertDecisionDocument, (c) => c);
            mapper.AddCollectionMap<NelkServiceReference.ekspertizaWsObject[]>((o) => o.ExpertDecisionDocument[0].CommisionMember, c => c[counter].komisiaList);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].CommisionMember[0].Name, (c) => c[0].komisiaList[0].imenaLekar);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].CommisionMember[0].Position, (c) => c[0].komisiaList[0].dlajnost);
            mapper.AddCollectionMap<NelkServiceReference.ekspertizaWsObject[]>((o) => o.ExpertDecisionDocument[0].DisabilityReason, c => c[counter].invalidnostList);
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].DisabilityReason[0].Percent, (c) => c[0].invalidnostList[0].invalidnost);
            mapper.AddFunctionMapNull<NelkServiceReference.ekspertizaInvalidnostWsObject, DateTime>(ad => ad.ExpertDecisionDocument[0].DisabilityReason[0].Date, s => (DateTime?)s.GetValueOrNull(t => t.dateInval, isFromDb: false));
            mapper.AddPropertyMap((o) => o.ExpertDecisionDocument[0].DisabilityReason[0].Type, (c) => c[0].invalidnostList[0].vidInval);
            return mapper;
        }


    }
}
