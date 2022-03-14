//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Data;
//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.WebServiceAdapterService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;

//namespace TechnoLogica.RegiX.PvMarksAdapter.AdapterService
//{
//    public class PvMarksAdapter : SoapServiceBaseAdapterService, IPvMarksAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(PvMarksAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//            new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/PvMarks/PvMarksService.svc")
//                  //new ParameterInfo<string>("http://93.152.159.78:6668/bpo.register.ws.provider/services/BPOMarksSearchServiceDefaultPort")
//                  {
//                      Key = Constants.WebServiceUrlParameterKeyName,
//                      Description = "Web Service Url",
//                      OwnerAssembly = typeof(PvMarksAdapter).Assembly
//                  };

//        public CommonSignedResponse<GetMarkByAppNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_App_Number(GetMarkByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvMarksServiceReference.BPOMarksSearchClient serviceClient = new PvMarksServiceReference.BPOMarksSearchClient("BPOMarksSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvMarksServiceReference.getMarkByAppNumType arg = new PvMarksServiceReference.getMarkByAppNumType();
//                arg.appnum = argument.AppNum;
//                PvMarksServiceReference.TradeMarkType[] serviceResult = serviceClient.getMarkByAppNum(arg);
//                ObjectMapper<PvMarksServiceReference.TradeMarkType[], REG_MARKS_TradeMarkDetails_Response> mapper = CreateRegMarksAppNumberMapper(accessMatrix);
//                REG_MARKS_TradeMarkDetails_Response searchResults = new REG_MARKS_TradeMarkDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<PvMarksServiceReference.TradeMarkType[], REG_MARKS_TradeMarkDetails_Response> CreateRegMarksAppNumberMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<PvMarksServiceReference.TradeMarkType[], REG_MARKS_TradeMarkDetails_Response> mapper = new ObjectMapper<PvMarksServiceReference.TradeMarkType[], REG_MARKS_TradeMarkDetails_Response>(accessMatrix);
//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks, c => c);

//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails, (c) => c[0].ApplicantDetails);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant, (c) => c[0].ApplicantDetails.Applicant);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails);
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());

//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);

//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);

//            mapper.AddFunctionMap<PvMarksServiceReference.ApplicantType, List<string>>((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantIdentifier, (c) => c.ApplicantIdentifier.ToList());
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantDetails.Applicant.ApplicantNationalityCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantNationalityCode);

//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicantSideCaseKey, (c) => c[0].ApplicantSideCaseKey);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicationDate, (c) => c[0].ApplicationDate);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicationLanguageCode, (c) => c[0].ApplicationLanguageCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicationNumber, (c) => c[0].ApplicationNumber);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ApplicationReference, (c) => c[0].ApplicationReference);

//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks[0].ExhibitionPriorityDetails, c => c[0].ExhibitionPriorityDetails);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].Comment, (c) => c[0].ExhibitionPriorityDetails[0].Comment);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].Comment.LanguageCode, (c) => c[0].ExhibitionPriorityDetails[0].Comment.languageCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].Comment.SequenceNumber, (c) => c[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].Comment.Value, (c) => c[0].ExhibitionPriorityDetails[0].Comment.Value);

//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].ExhibitionCityName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCityName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].ExhibitionDate, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionDate);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExhibitionPriorityDetails[0].ExhibitionName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionName);

//            mapper.AddPropertyMap((o) => o.TradeMarks[0].ExpiryDate, (c) => c[0].ExpiryDate);

//            mapper.AddObjectMap((o) => o.TradeMarks[0].GoodsServicesDetails, (c) => c[0].GoodsServicesDetails);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].GoodsServicesDetails.GoodsServices, (c) => c[0].GoodsServicesDetails.GoodsServices);
//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails, c => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].ClassNumber, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].ClassNumber);
//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription, c => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].LanguageCode, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].languageCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].SequenceNumber, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].sequenceNumber);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].Value, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].Value);

//            mapper.AddPropertyMap((o) => o.TradeMarks[0].KindMark, (c) => c[0].KindMark);
//            mapper.AddFunctionMap<PvMarksServiceReference.TradeMarkType, MarkCurrentStatusCodeType>((o) => o.TradeMarks[0].MarkCurrentStatusCode, (c) => (MarkCurrentStatusCodeType)Enum.Parse(typeof(MarkCurrentStatusCodeType), c.MarkCurrentStatusCode.ToString()));
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkCurrentStatusCodeSpecified, (c) => c[0].MarkCurrentStatusCodeSpecified);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkCurrentStatusDate, (c) => c[0].MarkCurrentStatusDate);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkCurrentStatusDateSpecified, (c) => c[0].MarkCurrentStatusDateSpecified);
//            mapper.AddFunctionMap<PvMarksServiceReference.TradeMarkType, List<string>>((o) => o.TradeMarks[0].MarkDescriptionDetails, (c) => (c.MarkDescriptionDetails == null) ? null : c.MarkDescriptionDetails.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.TradeMarkType, List<string>>((o) => o.TradeMarks[0].MarkDisclaimerDetails, (c) => (c.MarkDisclaimerDetails == null) ? null : c.MarkDisclaimerDetails.ToList());
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkFeature, (c) => c[0].MarkFeature);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].MarkImageDetails, (c) => c[0].MarkImageDetails);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].MarkImageDetails.MarkImage, (c) => c[0].MarkImageDetails.MarkImage);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageBinary, (c) => c[0].MarkImageDetails.MarkImage.MarkImageBinary);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageCategory, (c) => c[0].MarkImageDetails.MarkImage.MarkImageCategory);
//            mapper.AddFunctionMap<PvMarksServiceReference.TradeMarkType, List<string>>((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageCategory.CategoryCodeDetails, (c) => (c.MarkImageDetails.MarkImage.MarkImageCategory.CategoryCodeDetails == null) ? null : c.MarkImageDetails.MarkImage.MarkImageCategory.CategoryCodeDetails.ToList());

//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText, c => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].LanguageCode, (c) => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].languageCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].SequenceNumber, (c) => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].sequenceNumber);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].Value, (c) => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].Value);

//            mapper.AddPropertyMap((o) => o.TradeMarks[0].MarkImageDetails.MarkImage.MarkImageFileFormat, (c) => c[0].MarkImageDetails.MarkImage.MarkImageFileFormat);
//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks[0].PriorityDetails, c => c[0].PriorityDetails);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PriorityDetails[0].PriorityCountryCode, (c) => c[0].PriorityDetails[0].PriorityCountryCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PriorityDetails[0].PriorityDate, (c) => c[0].PriorityDetails[0].PriorityDate);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PriorityDetails[0].PriorityDateSpecified, (c) => c[0].PriorityDetails[0].PriorityDateSpecified);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PriorityDetails[0].PriorityNumber, (c) => c[0].PriorityDetails[0].PriorityNumber);

//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks[0].PublicationDetails, c => c[0].PublicationDetails);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PublicationDetails[0].PublicationDate, (c) => c[0].PublicationDetails[0].PublicationDate);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PublicationDetails[0].PublicationDateSpecified, (c) => c[0].PublicationDetails[0].PublicationDateSpecified);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PublicationDetails[0].PublicationIdentifier, (c) => c[0].PublicationDetails[0].PublicationIdentifier);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PublicationDetails[0].PublicationSection, (c) => c[0].PublicationDetails[0].PublicationSection);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].PublicationDetails[0].PublicationSubsection, (c) => c[0].PublicationDetails[0].PublicationSubsection);

//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RegistrationDate, (c) => c[0].RegistrationDate);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RegistrationDateSpecified, (c) => c[0].RegistrationDateSpecified);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RegistrationNumber, (c) => c[0].RegistrationNumber);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RegistrationOfficeCode, (c) => c[0].RegistrationOfficeCode);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails, (c) => c[0].RepresentativeDetails);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative, (c) => c[0].RepresentativeDetails.Representative);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails);
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvMarksServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());

//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);

//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);

//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeIdentifier, (c) => c[0].RepresentativeDetails.Representative.RepresentativeIdentifier);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeLegalEntity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeLegalEntity);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].RepresentativeDetails.Representative.RepresentativeNationalityCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeNationalityCode);

//            mapper.AddObjectMap((o) => o.TradeMarks[0].WordMarkSpecification, (c) => c[0].WordMarkSpecification);
//            mapper.AddCollectionMap<PvMarksServiceReference.TradeMarkType[]>((o) => o.TradeMarks[0].WordMarkSpecification.MarkTranslation, c => c[0].WordMarkSpecification.MarkTranslation);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].WordMarkSpecification.MarkTranslation[0].LanguageCode, (c) => c[0].WordMarkSpecification.MarkTranslation[0].languageCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].WordMarkSpecification.MarkTranslation[0].SequenceNumber, (c) => c[0].WordMarkSpecification.MarkTranslation[0].sequenceNumber);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].WordMarkSpecification.MarkTranslation[0].Value, (c) => c[0].WordMarkSpecification.MarkTranslation[0].Value);

//            mapper.AddObjectMap((o) => o.TradeMarks[0].WordMarkSpecification.MarkVerbalElementText, (c) => c[0].WordMarkSpecification.MarkVerbalElementText);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].WordMarkSpecification.MarkVerbalElementText.LanguageCode, (c) => c[0].WordMarkSpecification.MarkVerbalElementText.languageCode);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].WordMarkSpecification.MarkVerbalElementText.SequenceNumber, (c) => c[0].WordMarkSpecification.MarkVerbalElementText.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.TradeMarks[0].WordMarkSpecification.MarkVerbalElementText.Value, (c) => c[0].WordMarkSpecification.MarkVerbalElementText.Value);

//            return mapper;
//        }

//        public CommonSignedResponse<GetMarksByNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Mark_Name(GetMarksByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvMarksServiceReference.BPOMarksSearchClient serviceClient = new PvMarksServiceReference.BPOMarksSearchClient("BPOMarksSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvMarksServiceReference.getMarksByNameType arg = new PvMarksServiceReference.getMarksByNameType();
//                arg.markname = argument.MarkName;
//                PvMarksServiceReference.TradeMarkType[] serviceResult = serviceClient.getMarksByName(arg);
//                ObjectMapper<PvMarksServiceReference.TradeMarkType[], REG_MARKS_TradeMarkDetails_Response> mapper = CreateRegMarksAppNumberMapper(accessMatrix);
//                REG_MARKS_TradeMarkDetails_Response searchResults = new REG_MARKS_TradeMarkDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<GetMarkByOwnersNameType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Owner(GetMarkByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvMarksServiceReference.BPOMarksSearchClient serviceClient = new PvMarksServiceReference.BPOMarksSearchClient("BPOMarksSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvMarksServiceReference.getMarkByOwnersNameType arg = new PvMarksServiceReference.getMarkByOwnersNameType();
//                arg.fname = argument.FName;
//                arg.lname = argument.LName;
//                arg.sname = argument.SName;
//                PvMarksServiceReference.TradeMarkType[] serviceResult = serviceClient.getMarkByOwnersName(arg);
//                ObjectMapper<PvMarksServiceReference.TradeMarkType[], REG_MARKS_TradeMarkDetails_Response> mapper = CreateRegMarksAppNumberMapper(accessMatrix);
//                REG_MARKS_TradeMarkDetails_Response searchResults = new REG_MARKS_TradeMarkDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<GetMarkByRegNumType, REG_MARKS_TradeMarkDetails_Response> GetREG_MARKS_Reg_Number(GetMarkByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvMarksServiceReference.BPOMarksSearchClient serviceClient = new PvMarksServiceReference.BPOMarksSearchClient("BPOMarksSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvMarksServiceReference.getMarkByRegNumType arg = new PvMarksServiceReference.getMarkByRegNumType();
//                arg.regnum = argument.RegNum;
//                PvMarksServiceReference.TradeMarkType[] serviceResult = serviceClient.getMarkByRegNum(arg);
//                ObjectMapper<PvMarksServiceReference.TradeMarkType[], REG_MARKS_TradeMarkDetails_Response> mapper = CreateRegMarksAppNumberMapper(accessMatrix);
//                REG_MARKS_TradeMarkDetails_Response searchResults = new REG_MARKS_TradeMarkDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }
//    }
//}
